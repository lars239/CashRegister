// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026

namespace CashRegister;

partial class RevenueForm
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
    lblInfo = new Label();
    lblRemain = new Label();
    btnConfirm = new Button();
    btnCancel = new Button();
    SuspendLayout();

    lblInfo.AutoSize = false;
    lblInfo.Location = new Point(20, 20);
    lblInfo.Size = new Size(420, 60);
    lblInfo.Text =
      "Выручка достигла 200 000 руб.\nСдайте излишек менеджеру и подтвердите операцию.";

    lblRemain.AutoSize = true;
    lblRemain.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
    lblRemain.Location = new Point(20, 90);
    lblRemain.Text = "В кассе должно остаться: 5 000 руб.";

    btnConfirm.Location = new Point(80, 130);
    btnConfirm.Size = new Size(140, 35);
    btnConfirm.Text = "Подтвердить";
    btnConfirm.Click += BtnConfirm_Click;

    btnCancel.Location = new Point(240, 130);
    btnCancel.Size = new Size(140, 35);
    btnCancel.Text = "Отмена";
    btnCancel.Click += BtnCancel_Click;

    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(460, 190);
    Controls.Add(btnCancel);
    Controls.Add(btnConfirm);
    Controls.Add(lblRemain);
    Controls.Add(lblInfo);
    FormBorderStyle = FormBorderStyle.FixedDialog;
    MaximizeBox = false;
    MinimizeBox = false;
    StartPosition = FormStartPosition.CenterParent;
    Text = "Сдача выручки";
    ResumeLayout(false);
    PerformLayout();
  }

  private Label lblInfo;
  private Label lblRemain;
  private Button btnConfirm;
  private Button btnCancel;
}
