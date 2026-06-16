// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026
// Файл: точка входа приложения

namespace CashRegister;

static class Program
{
  /// <summary>
  /// Точка входа в приложение кассового терминала.
  /// </summary>
  [STAThread]
  static void Main()
  {
    ApplicationConfiguration.Initialize();

    DatabaseHelper.Initialize();

    Application.Run(new TitulForm());
  }
}
