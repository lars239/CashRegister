// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: титульная форма курсовой работы

namespace CashRegister;

/// <summary>
/// Титульная форма: сведения о работе и переход к основному приложению.
/// </summary>
public partial class TitulForm : Form
{
    public TitulForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Открывает основную форму кассового терминала.
    /// </summary>
    private void BtnStart_Click(object? sender, EventArgs e)
    {
        Hide();
        using var mainForm = new MainForm();
        mainForm.ShowDialog();
        Show();
    }

    private void TitulForm_Load(object sender, EventArgs e)
    {

    }
}
