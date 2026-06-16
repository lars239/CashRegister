// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: классы моделей данных кассового терминала

namespace CashRegister;

/// <summary>
/// Товар из справочника супермаркета.
/// </summary>
public class Product
{
  /// <summary>Штрих-код товара.</summary>
  public string Barcode { get; set; } = string.Empty;

  /// <summary>Наименование товара.</summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>Цена за единицу или за килограмм.</summary>
  public double Price { get; set; }

  /// <summary>true — весовой товар, false — штучный.</summary>
  public bool IsWeighted { get; set; }

  /// <summary>true — алкогольная продукция.</summary>
  public bool IsAlcohol { get; set; }
}

/// <summary>
/// Кассир (данные для авторизации).
/// </summary>
public class Cashier
{
  /// <summary>Штрих-код карты кассира.</summary>
  public string CardBarcode { get; set; } = string.Empty;

  /// <summary>Пароль для входа.</summary>
  public string Password { get; set; } = string.Empty;

  /// <summary>ФИО кассира.</summary>
  public string FullName { get; set; } = string.Empty;
}

/// <summary>
/// Строка текущего чека.
/// </summary>
public class CheckLine
{
  /// <summary>Товар в позиции чека.</summary>
  public Product Product { get; set; } = null!;

  /// <summary>Количество (шт.) или вес (кг).</summary>
  public double QuantityOrWeight { get; set; }

  /// <summary>Сумма по строке чека.</summary>
  public double LineTotal { get; set; }
}

/// <summary>
/// Результат проверки продажи алкоголя.
/// </summary>
public enum AlcoholCheckResult
{
  /// <summary>В чеке нет алкоголя — ограничения не применяются.</summary>
  NoAlcohol,

  /// <summary>Продажа алкоголя разрешена.</summary>
  Allowed,

  /// <summary>Запрет после 22:00.</summary>
  ForbiddenAfter22,

  /// <summary>Требуется подтверждение возраста покупателя.</summary>
  NeedAgeVerification,

  /// <summary>Возраст не подтверждён.</summary>
  AgeDenied
}
