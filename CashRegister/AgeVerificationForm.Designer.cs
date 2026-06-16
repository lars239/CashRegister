// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026

namespace CashRegister;

partial class AgeVerificationForm
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
    lblQuestion = new Label();
    btnYes = new Button();
    btnNo = new Button();
    SuspendLayout();

    lblQuestion.AutoSize = false;
    lblQuestion.Font = new Font("Segoe UI", 11F);
    lblQuestion.Location = new Point(20, 25);
    lblQuestion.Size = new Size(360, 50);
    lblQuestion.Text = "В чеке есть алкоголь.\nПокупатель совершеннолетний?";
    lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

    btnYes.DialogResult = DialogResult.None;
    btnYes.Location = new Point(60, 95);
    btnYes.Size = new Size(120, 35);
    btnYes.Text = "Да";
    btnYes.Click += BtnYes_Click;

    btnNo.DialogResult = DialogResult.None;
    btnNo.Location = new Point(220, 95);
    btnNo.Size = new Size(120, 35);
    btnNo.Text = "Нет";
    btnNo.Click += BtnNo_Click;

    AcceptButton = btnYes;
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(400, 150);
    Controls.Add(btnNo);
    Controls.Add(btnYes);
    Controls.Add(lblQuestion);
    FormBorderStyle = FormBorderStyle.FixedDialog;
    MaximizeBox = false;
    MinimizeBox = false;
    StartPosition = FormStartPosition.CenterParent;
    Text = "Проверка возраста";
    ResumeLayout(false);
  }

  private Label lblQuestion;
  private Button btnYes;
  private Button btnNo;
}
