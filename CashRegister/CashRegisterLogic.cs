// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: бизнес-логика кассового терминала

namespace CashRegister;

/// <summary>
/// Класс бизнес-логики кассового аппарата: авторизация, чек, выручка, алкоголь.
/// </summary>
public class CashRegisterLogic
{
  private const double RevenueLimit = 200_000;

  private const double RevenueAfterSubmit = 5_000;

  private Cashier? _currentCashier;

  private readonly List<CheckLine> _checkLines = new();

  private double _totalRevenue;

  /// <summary>Текущий кассир после успешной авторизации.</summary>
  public Cashier? CurrentCashier => _currentCashier;

  /// <summary>Строки текущего чека (только чтение).</summary>
  public IReadOnlyList<CheckLine> CheckLines => _checkLines;

  /// <summary>Накопленная выручка.</summary>
  public double TotalRevenue => _totalRevenue;

  /// <summary>Признак успешной авторизации.</summary>
  public bool IsAuthorized => _currentCashier is not null;

  /// <summary>
  /// Загружает выручку из БД при создании логики.
  /// </summary>
  public CashRegisterLogic()
  {
    _totalRevenue = DatabaseHelper.LoadRevenue();
  }

  /// <summary>
  /// Авторизация кассира по карте и паролю.
  /// </summary>
  /// <param name="cardCode">Штрих-код карты.</param>
  /// <param name="password">Пароль.</param>
  /// <returns>true — вход выполнен.</returns>
  public bool Authorize(string cardCode, string password)
  {
    var cashier = DatabaseHelper.FindCashierByCard(cardCode.Trim());
    if (cashier is null)
    {
      return false;
    }

    if (!string.Equals(cashier.Password, password, StringComparison.Ordinal))
    {
      return false;
    }

    _currentCashier = cashier;
    return true;
  }

  /// <summary>
  /// Выход из учётной записи кассира.
  /// </summary>
  public void Logout()
  {
    _currentCashier = null;
  }

  /// <summary>
  /// Поиск товара по штрих-коду в справочнике.
  /// </summary>
  /// <param name="barcode">Штрих-код.</param>
  /// <returns>Товар или null.</returns>
  public Product? FindProductByBarcode(string barcode)
  {
    return DatabaseHelper.FindProductByBarcode(barcode.Trim());
  }

  /// <summary>
  /// Добавляет позицию в текущий чек.
  /// </summary>
  /// <param name="product">Товар.</param>
  /// <param name="quantityOrWeight">Количество или вес.</param>
  public void AddProductToCheck(Product product, double quantityOrWeight)
  {
    var lineTotal = Math.Round(product.Price * quantityOrWeight, 2);
    _checkLines.Add(new CheckLine
    {
      Product = product,
      QuantityOrWeight = quantityOrWeight,
      LineTotal = lineTotal
    });
  }

  /// <summary>
  /// Удаляет последнюю позицию из чека.
  /// </summary>
  public void RemoveLastLine()
  {
    if (_checkLines.Count > 0)
    {
      _checkLines.RemoveAt(_checkLines.Count - 1);
    }
  }

  /// <summary>
  /// Пересчитывает итоговую сумму чека.
  /// </summary>
  /// <returns>Сумма к оплате.</returns>
  public double CalculateTotal()
  {
    return Math.Round(_checkLines.Sum(l => l.LineTotal), 2);
  }

  /// <summary>
  /// Формирует текст чека для печати.
  /// </summary>
  /// <param name="paidAmount">Сумма, внесённая покупателем.</param>
  /// <param name="change">Сдача.</param>
  /// <returns>Текст чека.</returns>
  public string PrintCheck(double paidAmount, double change)
  {
    var lines = new List<string>
    {
      "════════════════════════════════",
      "     СУПЕРМАРКЕТ «ПРОДУКТЫ»",
      "════════════════════════════════",
      $"Кассир: {_currentCashier?.FullName ?? "—"}",
      $"Дата:   {DateTime.Now:dd.MM.yyyy HH:mm}",
      "────────────────────────────────"
    };

    var index = 1;
    foreach (var line in _checkLines)
    {
      var unit = line.Product.IsWeighted ? "кг" : "шт";
      lines.Add($"{index,2}. {line.Product.Name}");
      lines.Add($"    {line.QuantityOrWeight:0.###} {unit} x {line.Product.Price:0.00} = {line.LineTotal:0.00} руб.");
      index++;
    }

    lines.Add("────────────────────────────────");
    lines.Add($"ИТОГО:              {CalculateTotal(),10:0.00} руб.");
    lines.Add($"ВНЕСЕНО:            {paidAmount,10:0.00} руб.");
    lines.Add($"СДАЧА:              {change,10:0.00} руб.");
    lines.Add("════════════════════════════════");
    lines.Add("        Спасибо за покупку!");

    return string.Join(Environment.NewLine, lines);
  }

  /// <summary>
  /// Проверяет алкогольные ограничения (время продажи).
  /// </summary>
  /// <param name="saleTime">Время продажи (для учёта ограничения после 22:00).</param>
  /// <returns>Результат проверки.</returns>
  public AlcoholCheckResult CheckAlcoholRestrictions(DateTime saleTime)
  {
    if (!_checkLines.Any(l => l.Product.IsAlcohol))
    {
      return AlcoholCheckResult.NoAlcohol;
    }

    if (saleTime.Hour >= 22)
    {
      return AlcoholCheckResult.ForbiddenAfter22;
    }

    return AlcoholCheckResult.NeedAgeVerification;
  }

  /// <summary>
  /// Завершает проверку алкоголя после подтверждения возраста.
  /// </summary>
  /// <param name="ageConfirmed">Покупатель совершеннолетний.</param>
  /// <returns>Итоговый результат.</returns>
  public AlcoholCheckResult CompleteAgeVerification(bool ageConfirmed)
  {
    return ageConfirmed ? AlcoholCheckResult.Allowed : AlcoholCheckResult.AgeDenied;
  }

  /// <summary>
  /// Контроль порога выручки: требуется ли сдача перед новым чеком.
  /// </summary>
  /// <returns>true — новый чек разрешён.</returns>
  public bool HandleRevenueLimit()
  {
    return _totalRevenue < RevenueLimit;
  }

  /// <summary>
  /// Признак необходимости сдачи выручки.
  /// </summary>
  public bool NeedsRevenueSubmission() => _totalRevenue >= RevenueLimit;

  /// <summary>
  /// Сдача выручки: в кассе остаётся 5000 руб.
  /// </summary>
  public void SubmitRevenue()
  {
    _totalRevenue = RevenueAfterSubmit;
    DatabaseHelper.SaveRevenue(_totalRevenue);
  }

  /// <summary>
  /// Очищает текущий чек.
  /// </summary>
  public void NewCheck()
  {
    _checkLines.Clear();
  }

  /// <summary>
  /// Закрывает чек: увеличивает выручку и сохраняет в БД.
  /// </summary>
  /// <param name="checkTotal">Сумма закрываемого чека.</param>
  public void RegisterClosedCheck(double checkTotal)
  {
    _totalRevenue = Math.Round(_totalRevenue + checkTotal, 2);
    DatabaseHelper.SaveRevenue(_totalRevenue);
    _checkLines.Clear();
  }
}
