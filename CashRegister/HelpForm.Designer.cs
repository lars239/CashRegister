// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026

namespace CashRegister;

partial class HelpForm
{
  private System.ComponentModel.IContainer components = null;

  protected override void Dispose(bool disposing)
  {
    if (disposing && (components != null))
    {
      components.Dispose();
    }

    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    rtbHelp = new RichTextBox();
    btnClose = new Button();
    SuspendLayout();

    rtbHelp.Font = new Font("Consolas", 9.5F);
    rtbHelp.Location = new Point(12, 12);
    rtbHelp.ReadOnly = true;
    rtbHelp.Size = new Size(560, 380);
    rtbHelp.Text = """
      РУКОВОДСТВО ПОЛЬЗОВАТЕЛЯ — КАССОВЫЙ ТЕРМИНАЛ

      1. АВТОРИЗАЦИЯ
         • Выберите карту кассира в списке или введите штрих-код.
         • Введите пароль (тест: 1111, 2222, 3333).
         • Нажмите «Войти».

      2. НОВЫЙ ЧЕК
         • Кнопка «Новый чек» очищает таблицу.
         • При выручке ≥ 200 000 руб. нужна сдача выручки.

      3. ДОБАВЛЕНИЕ ТОВАРА
         • Выберите товар в ComboBox или введите штрих-код.
         • Для штучного — количество в NumericUpDown.
         • Для весового — вес в TextBox (до 3 знаков после запятой).
         • «Добавить в чек».

      4. ЗАКРЫТИЕ ЧЕКА
         • Введите сумму от покупателя.
         • При алкоголе после 22:00 — запрет.
         • При алкоголе до 22:00 — подтверждение возраста.

      5. СДАЧА ВЫРУЧКИ
         • Кнопка «Сдать выручку» — остаток 5 000 руб.

      Тестовые карты: 1001, 1002, 1003.
      """;

    btnClose.Location = new Point(220, 405);
    btnClose.Size = new Size(140, 32);
    btnClose.Text = "Закрыть";
    btnClose.Click += BtnClose_Click;

    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(584, 450);
    Controls.Add(btnClose);
    Controls.Add(rtbHelp);
    FormBorderStyle = FormBorderStyle.FixedDialog;
    MaximizeBox = false;
    StartPosition = FormStartPosition.CenterParent;
    Text = "Помощь";
    ResumeLayout(false);
  }

  private RichTextBox rtbHelp;
  private Button btnClose;
}
