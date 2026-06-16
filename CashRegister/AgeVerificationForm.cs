// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: подтверждение возраста при продаже алкоголя

namespace CashRegister;

/// <summary>
/// Дополнительная форма: подтверждение совершеннолетия покупателя.
/// </summary>
public partial class AgeVerificationForm : Form
{
  public AgeVerificationForm()
  {
    InitializeComponent();
  }

  /// <summary>
  /// Покупатель совершеннолетний — разрешить закрытие чека.
  /// </summary>
  private void BtnYes_Click(object? sender, EventArgs e)
  {
    DialogResult = DialogResult.Yes;
    Close();
  }

  /// <summary>
  /// Покупатель несовершеннолетний — запретить закрытие чека.
  /// </summary>
  private void BtnNo_Click(object? sender, EventArgs e)
  {
    DialogResult = DialogResult.No;
    Close();
  }
}
