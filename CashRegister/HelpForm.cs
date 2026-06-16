// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: краткая инструкция пользователя

namespace CashRegister;

/// <summary>
/// Дополнительная форма: руководство пользователя.
/// </summary>
public partial class HelpForm : Form
{
  public HelpForm()
  {
    InitializeComponent();
  }

  private void BtnClose_Click(object? sender, EventArgs e)
  {
    Close();
  }
}
