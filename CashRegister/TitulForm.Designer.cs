// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026

namespace CashRegister;

partial class TitulForm
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
        lblTitle = new Label();
        lblTopic = new Label();
        lblSupervisor = new Label();
        lblStudent = new Label();
        lblGroup = new Label();
        lblDirection = new Label();
        lblYear = new Label();
        btnStart = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(57, 50);
        lblTitle.Margin = new Padding(4, 0, 4, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(743, 67);
        lblTitle.TabIndex = 7;
        lblTitle.Text = "Курсовая работа";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTopic
        // 
        lblTopic.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTopic.Location = new Point(57, 133);
        lblTopic.Margin = new Padding(4, 0, 4, 0);
        lblTopic.Name = "lblTopic";
        lblTopic.Size = new Size(743, 100);
        lblTopic.TabIndex = 6;
        lblTopic.Text = "«Модель кассового терминала супермаркета»";
        lblTopic.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSupervisor
        // 
        lblSupervisor.AutoSize = true;
        lblSupervisor.Font = new Font("Segoe UI", 10F);
        lblSupervisor.Location = new Point(114, 283);
        lblSupervisor.Margin = new Padding(4, 0, 4, 0);
        lblSupervisor.Name = "lblSupervisor";
        lblSupervisor.Size = new Size(287, 28);
        lblSupervisor.TabIndex = 5;
        lblSupervisor.Text = "Руководитель: Беднякова Т.М.";
        // 
        // lblStudent
        // 
        lblStudent.AutoSize = true;
        lblStudent.Font = new Font("Segoe UI", 10F);
        lblStudent.Location = new Point(114, 333);
        lblStudent.Margin = new Padding(4, 0, 4, 0);
        lblStudent.Name = "lblStudent";
        lblStudent.Size = new Size(322, 28);
        lblStudent.TabIndex = 4;
        lblStudent.Text = "Выполнил(а): Старосветский М. А.";
        // 
        // lblGroup
        // 
        lblGroup.AutoSize = true;
        lblGroup.Font = new Font("Segoe UI", 10F);
        lblGroup.Location = new Point(114, 383);
        lblGroup.Margin = new Padding(4, 0, 4, 0);
        lblGroup.Name = "lblGroup";
        lblGroup.Size = new Size(185, 28);
        lblGroup.TabIndex = 3;
        lblGroup.Text = "Группа: ПРОГ-С-25";
        // 
        // lblDirection
        // 
        lblDirection.AutoSize = true;
        lblDirection.Font = new Font("Segoe UI", 10F);
        lblDirection.Location = new Point(114, 433);
        lblDirection.Margin = new Padding(4, 0, 4, 0);
        lblDirection.Name = "lblDirection";
        lblDirection.Size = new Size(383, 28);
        lblDirection.TabIndex = 2;
        lblDirection.Text = "Направление: Программная инженерия";
        // 
        // lblYear
        // 
        lblYear.AutoSize = true;
        lblYear.Font = new Font("Segoe UI", 10F);
        lblYear.Location = new Point(114, 500);
        lblYear.Margin = new Padding(4, 0, 4, 0);
        lblYear.Name = "lblYear";
        lblYear.Size = new Size(73, 28);
        lblYear.TabIndex = 1;
        lblYear.Text = "2026 г.";
        // 
        // btnStart
        // 
        btnStart.Font = new Font("Segoe UI", 11F);
        btnStart.Location = new Point(286, 600);
        btnStart.Margin = new Padding(4, 5, 4, 5);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(286, 75);
        btnStart.TabIndex = 0;
        btnStart.Text = "Перейти к работе";
        btnStart.UseVisualStyleBackColor = true;
        btnStart.Click += BtnStart_Click;
        // 
        // TitulForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(857, 733);
        Controls.Add(btnStart);
        Controls.Add(lblYear);
        Controls.Add(lblDirection);
        Controls.Add(lblGroup);
        Controls.Add(lblStudent);
        Controls.Add(lblSupervisor);
        Controls.Add(lblTopic);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        Name = "TitulForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Титульный лист";
        Load += TitulForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
  private Label lblTopic;
  private Label lblSupervisor;
  private Label lblStudent;
  private Label lblGroup;
  private Label lblDirection;
  private Label lblYear;
  private Button btnStart;
}
