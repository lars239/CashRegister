// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: сдача выручки менеджеру

namespace CashRegister;

/// <summary>
/// Дополнительная форма: подтверждение сдачи выручки с остатком 5000 руб.
/// </summary>
public partial class RevenueForm : Form
{
  public RevenueForm()
  {
    InitializeComponent();
  }

  /// <summary>
  /// Кассир подтверждает сдачу выручки.
  /// </summary>
  private void BtnConfirm_Click(object? sender, EventArgs e)
  {
    DialogResult = DialogResult.OK;
    Close();
  }

  /// <summary>
  /// Отмена сдачи выручки.
  /// </summary>
  private void BtnCancel_Click(object? sender, EventArgs e)
  {
    DialogResult = DialogResult.Cancel;
    Close();
  }
}
