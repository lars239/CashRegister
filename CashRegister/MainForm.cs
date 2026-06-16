// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: основная форма кассового терминала

namespace CashRegister;

/// <summary>
/// Основная рабочая форма кассового аппарата.
/// </summary>
public partial class MainForm : Form
{
  private readonly CashRegisterLogic _logic = new();

  private List<Product> _products = new();

  private Product? _selectedProduct;

  public MainForm()
  {
    InitializeComponent();
  }

  /// <summary>
  /// Загрузка формы: справочники и начальное состояние.
  /// </summary>
  private void MainForm_Load(object? sender, EventArgs e)
  {
    var cashiers = DatabaseHelper.GetAllCashiers();
    _products = DatabaseHelper.GetAllProducts();

    cmbCard.DisplayMember = "FullName";
    cmbCard.ValueMember = "CardBarcode";
    cmbCard.DataSource = cashiers;

    cmbProducts.DisplayMember = "Name";
    cmbProducts.ValueMember = "Barcode";
    cmbProducts.DataSource = _products.ToList();

    dtpSaleTime.Value = DateTime.Now;

    UpdateRevenueDisplay();
    UpdateWorkAreaState();
    RefreshCheckGrid();
  }

  /// <summary>
  /// Обновляет отображение выручки и блокировку нового чека.
  /// </summary>
  private void UpdateRevenueDisplay()
  {
    lblRevenue.Text = $"{_logic.TotalRevenue:N2} руб.";
    btnNewCheck.Enabled = _logic.IsAuthorized && _logic.HandleRevenueLimit();
    if (_logic.NeedsRevenueSubmission() && _logic.IsAuthorized)
    {
      btnNewCheck.Enabled = false;
    }
  }

  /// <summary>
  /// Блокирует/разблокирует рабочую область в зависимости от авторизации.
  /// </summary>
  private void UpdateWorkAreaState()
  {
    var authorized = _logic.IsAuthorized;
    tabWork.Enabled = authorized;
    btnLogout.Enabled = authorized;
    btnCashDrawer.Enabled = authorized;
    lblCashier.Text = authorized
      ? $"Кассир: {_logic.CurrentCashier!.FullName}"
      : "Кассир: не авторизован";
  }

  /// <summary>
  /// Авторизация кассира.
  /// </summary>
  private void BtnLogin_Click(object? sender, EventArgs e)
  {
    var cardCode = cmbCard.SelectedValue?.ToString() ?? string.Empty;
    var password = txtPassword.Text;

    if (string.IsNullOrWhiteSpace(cardCode))
    {
      MessageBox.Show("Выберите карту кассира.", "Авторизация",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    if (!_logic.Authorize(cardCode, password))
    {
      MessageBox.Show("Неверная карта или пароль. Доступ к функциям кассы закрыт.",
        "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
      txtPassword.Clear();
      return;
    }

    txtPassword.Clear();
    UpdateWorkAreaState();
    UpdateRevenueDisplay();
    tabMain.SelectedTab = tabWork;
    MessageBox.Show($"Добро пожаловать, {_logic.CurrentCashier!.FullName}!",
      "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
  }

  /// <summary>
  /// Смена кассира — выход из учётной записи.
  /// </summary>
  private void BtnLogout_Click(object? sender, EventArgs e)
  {
    _logic.Logout();
    UpdateWorkAreaState();
    tabMain.SelectedTab = tabAuth;
  }

  /// <summary>
  /// Выбор товара из ComboBox (эмуляция сканера).
  /// </summary>
  private void CmbProducts_SelectedIndexChanged(object? sender, EventArgs e)
  {
    if (cmbProducts.SelectedItem is Product product)
    {
      SelectProduct(product);
      txtBarcode.Text = product.Barcode;
    }
  }

  /// <summary>
  /// Ручной ввод штрих-кода.
  /// </summary>
  private void TxtBarcode_Leave(object? sender, EventArgs e)
  {
    LookupBarcode(txtBarcode.Text);
  }

  /// <summary>
  /// Поиск товара по штрих-коду и отображение на дисплее.
  /// </summary>
  private void LookupBarcode(string barcode)
  {
    if (string.IsNullOrWhiteSpace(barcode))
    {
      _selectedProduct = null;
      lblProductDisplay.Text = "Товар не выбран";
      return;
    }

    var product = _logic.FindProductByBarcode(barcode);
    if (product is null)
    {
      _selectedProduct = null;
      lblProductDisplay.Text = "Товар не найден";
      MessageBox.Show("Товар не найден", "Справочник",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    SelectProduct(product);
    var index = _products.FindIndex(p => p.Barcode == product.Barcode);
    if (index >= 0)
    {
      cmbProducts.SelectedIndex = index;
    }
  }

  /// <summary>
  /// Отображает товар и переключает поля количества/веса.
  /// </summary>
  private void SelectProduct(Product product)
  {
    _selectedProduct = product;
    var typeText = product.IsWeighted ? "весовой" : "штучный";
    var alcoholText = product.IsAlcohol ? ", алкоголь" : string.Empty;
    lblProductDisplay.Text =
      $"{product.Name} | {product.Price:N2} руб. ({typeText}{alcoholText})";

    var isWeighted = product.IsWeighted;
    lblQty.Visible = !isWeighted;
    nudQuantity.Visible = !isWeighted;
    lblWeight.Visible = isWeighted;
    txtWeight.Visible = isWeighted;
  }

  /// <summary>
  /// Новый чек — очистка таблицы.
  /// </summary>
  private void BtnNewCheck_Click(object? sender, EventArgs e)
  {
    if (!_logic.HandleRevenueLimit())
    {
      MessageBox.Show(
        "Выручка достигла 200 000 руб. Сдайте выручку менеджеру перед открытием нового чека.",
        "Контроль выручки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    _logic.NewCheck();
    rtbReceipt.Clear();
    txtPaidAmount.Clear();
    RefreshCheckGrid();
    UpdateTotalLabel();
  }

  /// <summary>
  /// Добавление товара в чек.
  /// </summary>
  private void BtnAdd_Click(object? sender, EventArgs e)
  {
    if (string.IsNullOrWhiteSpace(txtBarcode.Text) && _selectedProduct is null)
    {
      MessageBox.Show("Штрих-код не может быть пустым", "Добавление",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    if (_selectedProduct is null)
    {
      LookupBarcode(txtBarcode.Text);
      if (_selectedProduct is null)
      {
        return;
      }
    }

    var product = _selectedProduct!;

    double quantityOrWeight;
    if (product.IsWeighted)
    {
      if (!TryParseWeight(txtWeight.Text, out quantityOrWeight))
      {
        return;
      }
    }
    else
    {
      quantityOrWeight = (double)nudQuantity.Value;
      if (quantityOrWeight <= 0)
      {
        MessageBox.Show("Количество должно быть больше нуля.", "Добавление",
          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }
    }

    _logic.AddProductToCheck(product, quantityOrWeight);
    RefreshCheckGrid();
    UpdateTotalLabel();
  }

  /// <summary>
  /// Разбор веса с проверкой формата (до 3 знаков после запятой).
  /// </summary>
  private bool TryParseWeight(string text, out double weight)
  {
    weight = 0;
    try
    {
      if (!double.TryParse(text.Replace(',', '.'),
            System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out weight))
      {
        MessageBox.Show("Введите корректный вес числом (например: 0.350).",
          "Вес", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
    }
    catch (Exception)
    {
      MessageBox.Show("Ошибка ввода веса. Введите число.", "Вес",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return false;
    }

    if (weight <= 0)
    {
      MessageBox.Show("Вес должен быть больше нуля.", "Вес",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return false;
    }

    var rounded = Math.Round(weight, 3);
    if (Math.Abs(weight - rounded) > 0.0001)
    {
      MessageBox.Show("Допускается не более 3 знаков после запятой.", "Вес",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return false;
    }

    weight = rounded;
    return true;
  }

  /// <summary>
  /// Удаление последней позиции чека.
  /// </summary>
  private void BtnRemoveLast_Click(object? sender, EventArgs e)
  {
    _logic.RemoveLastLine();
    RefreshCheckGrid();
    UpdateTotalLabel();
  }

  /// <summary>
  /// Закрытие чека с оплатой и печатью.
  /// </summary>
  private void BtnCloseCheck_Click(object? sender, EventArgs e)
  {
    if (_logic.CheckLines.Count == 0)
    {
      MessageBox.Show("Чек пуст. Добавьте товары.", "Закрытие чека",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    var total = _logic.CalculateTotal();

    if (!double.TryParse(txtPaidAmount.Text.Replace(',', '.'),
          System.Globalization.NumberStyles.Float,
          System.Globalization.CultureInfo.InvariantCulture, out var paid))
    {
      MessageBox.Show("Введите корректную сумму, внесённую покупателем.",
        "Закрытие чека", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    if (paid < total)
    {
      MessageBox.Show("Сумма внесена меньше суммы чека. Чек не закрывается.",
        "Закрытие чека", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    var alcoholResult = _logic.CheckAlcoholRestrictions(dtpSaleTime.Value);
    switch (alcoholResult)
    {
      case AlcoholCheckResult.ForbiddenAfter22:
        MessageBox.Show("Продажа крепкого алкоголя после 22:00 запрещена.",
          "Алкоголь", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      case AlcoholCheckResult.NeedAgeVerification:
        using (var ageForm = new AgeVerificationForm())
        {
          if (ageForm.ShowDialog(this) != DialogResult.Yes)
          {
            MessageBox.Show("Продажа алкоголя несовершеннолетним запрещена. Чек не закрыт.",
              "Алкоголь", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
          }
        }

        if (_logic.CompleteAgeVerification(true) == AlcoholCheckResult.AgeDenied)
        {
          return;
        }

        break;
    }

    var change = Math.Round(paid - total, 2);
    rtbReceipt.Text = _logic.PrintCheck(paid, change);
    _logic.RegisterClosedCheck(total);

    RefreshCheckGrid();
    UpdateTotalLabel();
    UpdateRevenueDisplay();
    txtPaidAmount.Clear();

    if (_logic.NeedsRevenueSubmission())
    {
      MessageBox.Show(
        "Выручка достигла 200 000 руб. Необходимо сдать выручку менеджеру.",
        "Контроль выручки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    MessageBox.Show($"Чек закрыт. Сдача: {change:N2} руб.", "Касса",
      MessageBoxButtons.OK, MessageBoxIcon.Information);
  }

  /// <summary>
  /// Сдача выручки через дополнительную форму.
  /// </summary>
  private void BtnSubmitRevenue_Click(object? sender, EventArgs e)
  {
    using var revenueForm = new RevenueForm();
    if (revenueForm.ShowDialog(this) == DialogResult.OK)
    {
      _logic.SubmitRevenue();
      UpdateRevenueDisplay();
      MessageBox.Show("Выручка сдана. В кассе осталось 5 000 руб.",
        "Инкассация", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }

  /// <summary>
  /// Открытие формы помощи.
  /// </summary>
  private void BtnHelp_Click(object? sender, EventArgs e)
  {
    using var helpForm = new HelpForm();
    helpForm.ShowDialog(this);
  }

  /// <summary>
  /// Имитация открытия денежного ящика.
  /// </summary>
  private void BtnCashDrawer_Click(object? sender, EventArgs e)
  {
    MessageBox.Show("Денежный ящик открыт (имитация).",
      "Денежный ящик", MessageBoxButtons.OK, MessageBoxIcon.Information);
  }

  /// <summary>
  /// Обновляет таблицу текущего чека.
  /// </summary>
  private void RefreshCheckGrid()
  {
    dgvCheck.Rows.Clear();
    foreach (var line in _logic.CheckLines)
    {
      var unit = line.Product.IsWeighted ? "кг" : "шт";
      dgvCheck.Rows.Add(
        line.Product.Name,
        $"{line.QuantityOrWeight:0.###} {unit}",
        $"{line.Product.Price:N2}",
        $"{line.LineTotal:N2}");
    }
  }

  /// <summary>
  /// Обновляет метку итоговой суммы.
  /// </summary>
  private void UpdateTotalLabel()
  {
    lblTotal.Text = $"{_logic.CalculateTotal():N2} руб.";
  }
}
