// Автор: Старосветским М. А., группа ПРОГ-С-25
// Дата: 23.05.2026

namespace CashRegister;

partial class MainForm
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
        tabMain = new TabControl();
        tabAuth = new TabPage();
        btnLogout = new Button();
        lblCashier = new Label();
        btnLogin = new Button();
        txtPassword = new TextBox();
        lblPassword = new Label();
        cmbCard = new ComboBox();
        lblCard = new Label();
        tabWork = new TabPage();
        btnCashDrawer = new Button();
        dtpSaleTime = new DateTimePicker();
        lblTime = new Label();
        rtbReceipt = new RichTextBox();
        lblReceipt = new Label();
        btnCloseCheck = new Button();
        txtPaidAmount = new TextBox();
        lblPaid = new Label();
        lblTotal = new Label();
        lblTotalTitle = new Label();
        dgvCheck = new DataGridView();
        colName = new DataGridViewTextBoxColumn();
        colQty = new DataGridViewTextBoxColumn();
        colPrice = new DataGridViewTextBoxColumn();
        colSum = new DataGridViewTextBoxColumn();
        btnNewCheck = new Button();
        btnRemoveLast = new Button();
        btnAdd = new Button();
        txtWeight = new TextBox();
        lblWeight = new Label();
        nudQuantity = new NumericUpDown();
        lblQty = new Label();
        lblProductDisplay = new Label();
        txtBarcode = new TextBox();
        cmbProducts = new ComboBox();
        lblBarcode = new Label();
        btnHelp = new Button();
        btnSubmitRevenue = new Button();
        lblRevenue = new Label();
        lblRevenueTitle = new Label();
        tabMain.SuspendLayout();
        tabAuth.SuspendLayout();
        tabWork.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCheck).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
        SuspendLayout();
        // 
        // tabMain
        // 
        tabMain.Controls.Add(tabAuth);
        tabMain.Controls.Add(tabWork);
        tabMain.Dock = DockStyle.Fill;
        tabMain.Location = new Point(0, 0);
        tabMain.Margin = new Padding(4, 5, 4, 5);
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(1400, 1102);
        tabMain.TabIndex = 0;
        // 
        // tabAuth
        // 
        tabAuth.Controls.Add(btnLogout);
        tabAuth.Controls.Add(lblCashier);
        tabAuth.Controls.Add(btnLogin);
        tabAuth.Controls.Add(txtPassword);
        tabAuth.Controls.Add(lblPassword);
        tabAuth.Controls.Add(cmbCard);
        tabAuth.Controls.Add(lblCard);
        tabAuth.Location = new Point(4, 34);
        tabAuth.Margin = new Padding(4, 5, 4, 5);
        tabAuth.Name = "tabAuth";
        tabAuth.Padding = new Padding(4, 5, 4, 5);
        tabAuth.Size = new Size(1398, 1064);
        tabAuth.TabIndex = 0;
        tabAuth.Text = "Авторизация";
        tabAuth.UseVisualStyleBackColor = true;
        // 
        // btnLogout
        // 
        btnLogout.Enabled = false;
        btnLogout.Location = new Point(514, 267);
        btnLogout.Margin = new Padding(4, 5, 4, 5);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(200, 58);
        btnLogout.TabIndex = 0;
        btnLogout.Text = "Сменить кассира";
        btnLogout.Click += BtnLogout_Click;
        // 
        // lblCashier
        // 
        lblCashier.AutoSize = true;
        lblCashier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCashier.Location = new Point(114, 367);
        lblCashier.Margin = new Padding(4, 0, 4, 0);
        lblCashier.Name = "lblCashier";
        lblCashier.Size = new Size(247, 28);
        lblCashier.TabIndex = 1;
        lblCashier.Text = "Кассир: не авторизован";
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(286, 267);
        btnLogin.Margin = new Padding(4, 5, 4, 5);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(200, 58);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "Войти";
        btnLogin.Click += BtnLogin_Click;
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(286, 195);
        txtPassword.Margin = new Padding(4, 5, 4, 5);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new Size(284, 31);
        txtPassword.TabIndex = 2;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(114, 200);
        lblPassword.Margin = new Padding(4, 0, 4, 0);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(78, 25);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "Пароль:";
        // 
        // cmbCard
        // 
        cmbCard.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCard.Location = new Point(286, 128);
        cmbCard.Margin = new Padding(4, 5, 4, 5);
        cmbCard.Name = "cmbCard";
        cmbCard.Size = new Size(570, 33);
        cmbCard.TabIndex = 1;
        // 
        // lblCard
        // 
        lblCard.AutoSize = true;
        lblCard.Location = new Point(114, 133);
        lblCard.Margin = new Padding(4, 0, 4, 0);
        lblCard.Name = "lblCard";
        lblCard.Size = new Size(131, 25);
        lblCard.TabIndex = 4;
        lblCard.Text = "Карта кассира:";
        // 
        // tabWork
        // 
        tabWork.Controls.Add(btnCashDrawer);
        tabWork.Controls.Add(dtpSaleTime);
        tabWork.Controls.Add(lblTime);
        tabWork.Controls.Add(rtbReceipt);
        tabWork.Controls.Add(lblReceipt);
        tabWork.Controls.Add(btnCloseCheck);
        tabWork.Controls.Add(txtPaidAmount);
        tabWork.Controls.Add(lblPaid);
        tabWork.Controls.Add(lblTotal);
        tabWork.Controls.Add(lblTotalTitle);
        tabWork.Controls.Add(dgvCheck);
        tabWork.Controls.Add(btnNewCheck);
        tabWork.Controls.Add(btnRemoveLast);
        tabWork.Controls.Add(btnAdd);
        tabWork.Controls.Add(txtWeight);
        tabWork.Controls.Add(lblWeight);
        tabWork.Controls.Add(nudQuantity);
        tabWork.Controls.Add(lblQty);
        tabWork.Controls.Add(lblProductDisplay);
        tabWork.Controls.Add(txtBarcode);
        tabWork.Controls.Add(cmbProducts);
        tabWork.Controls.Add(lblBarcode);
        tabWork.Controls.Add(btnHelp);
        tabWork.Controls.Add(btnSubmitRevenue);
        tabWork.Controls.Add(lblRevenue);
        tabWork.Controls.Add(lblRevenueTitle);
        tabWork.Enabled = false;
        tabWork.Location = new Point(4, 34);
        tabWork.Margin = new Padding(4, 5, 4, 5);
        tabWork.Name = "tabWork";
        tabWork.Padding = new Padding(4, 5, 4, 5);
        tabWork.Size = new Size(1392, 1064);
        tabWork.TabIndex = 1;
        tabWork.Text = "Касса";
        tabWork.UseVisualStyleBackColor = true;
        // 
        // btnCashDrawer
        // 
        btnCashDrawer.Enabled = false;
        btnCashDrawer.Location = new Point(1229, 17);
        btnCashDrawer.Margin = new Padding(4, 5, 4, 5);
        btnCashDrawer.Name = "btnCashDrawer";
        btnCashDrawer.Size = new Size(129, 47);
        btnCashDrawer.TabIndex = 0;
        btnCashDrawer.Text = "Ящик";
        btnCashDrawer.Click += BtnCashDrawer_Click;
        // 
        // dtpSaleTime
        // 
        dtpSaleTime.CustomFormat = "dd.MM.yyyy HH:mm";
        dtpSaleTime.Format = DateTimePickerFormat.Custom;
        dtpSaleTime.Location = new Point(986, 20);
        dtpSaleTime.Margin = new Padding(4, 5, 4, 5);
        dtpSaleTime.Name = "dtpSaleTime";
        dtpSaleTime.ShowUpDown = true;
        dtpSaleTime.Size = new Size(227, 31);
        dtpSaleTime.TabIndex = 1;
        // 
        // lblTime
        // 
        lblTime.AutoSize = true;
        lblTime.Location = new Point(829, 25);
        lblTime.Margin = new Padding(4, 0, 4, 0);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(147, 25);
        lblTime.TabIndex = 2;
        lblTime.Text = "Время продажи:";
        // 
        // rtbReceipt
        // 
        rtbReceipt.Font = new Font("Consolas", 9F);
        rtbReceipt.Location = new Point(829, 128);
        rtbReceipt.Margin = new Padding(4, 5, 4, 5);
        rtbReceipt.Name = "rtbReceipt";
        rtbReceipt.ReadOnly = true;
        rtbReceipt.Size = new Size(527, 864);
        rtbReceipt.TabIndex = 3;
        rtbReceipt.Text = "";
        // 
        // lblReceipt
        // 
        lblReceipt.AutoSize = true;
        lblReceipt.Location = new Point(829, 92);
        lblReceipt.Margin = new Padding(4, 0, 4, 0);
        lblReceipt.Name = "lblReceipt";
        lblReceipt.Size = new Size(115, 25);
        lblReceipt.TabIndex = 4;
        lblReceipt.Text = "Печать чека:";
        // 
        // btnCloseCheck
        // 
        btnCloseCheck.Location = new Point(457, 801);
        btnCloseCheck.Margin = new Padding(4, 5, 4, 5);
        btnCloseCheck.Name = "btnCloseCheck";
        btnCloseCheck.Size = new Size(200, 47);
        btnCloseCheck.TabIndex = 5;
        btnCloseCheck.Text = "Закрыть чек";
        btnCloseCheck.Click += BtnCloseCheck_Click;
        // 
        // txtPaidAmount
        // 
        txtPaidAmount.Location = new Point(257, 805);
        txtPaidAmount.Margin = new Padding(4, 5, 4, 5);
        txtPaidAmount.Name = "txtPaidAmount";
        txtPaidAmount.Size = new Size(170, 31);
        txtPaidAmount.TabIndex = 6;
        // 
        // lblPaid
        // 
        lblPaid.AutoSize = true;
        lblPaid.Location = new Point(29, 810);
        lblPaid.Margin = new Padding(4, 0, 4, 0);
        lblPaid.Name = "lblPaid";
        lblPaid.Size = new Size(193, 25);
        lblPaid.TabIndex = 7;
        lblPaid.Text = "Внесено покупателем:";
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotal.ForeColor = Color.DarkGreen;
        lblTotal.Location = new Point(214, 748);
        lblTotal.Margin = new Padding(4, 0, 4, 0);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(120, 32);
        lblTotal.TabIndex = 8;
        lblTotal.Text = "0.00 руб.";
        // 
        // lblTotalTitle
        // 
        lblTotalTitle.AutoSize = true;
        lblTotalTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTotalTitle.Location = new Point(29, 751);
        lblTotalTitle.Margin = new Padding(4, 0, 4, 0);
        lblTotalTitle.Name = "lblTotalTitle";
        lblTotalTitle.Size = new Size(178, 30);
        lblTotalTitle.TabIndex = 9;
        lblTotalTitle.Text = "Итого к оплате:";
        // 
        // dgvCheck
        // 
        dgvCheck.AllowUserToAddRows = false;
        dgvCheck.AllowUserToDeleteRows = false;
        dgvCheck.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCheck.Columns.AddRange(new DataGridViewColumn[] { colName, colQty, colPrice, colSum });
        dgvCheck.Location = new Point(29, 368);
        dgvCheck.Margin = new Padding(4, 5, 4, 5);
        dgvCheck.Name = "dgvCheck";
        dgvCheck.ReadOnly = true;
        dgvCheck.RowHeadersVisible = false;
        dgvCheck.RowHeadersWidth = 62;
        dgvCheck.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCheck.Size = new Size(771, 367);
        dgvCheck.TabIndex = 10;
        // 
        // colName
        // 
        colName.HeaderText = "Наименование";
        colName.MinimumWidth = 8;
        colName.Name = "colName";
        colName.ReadOnly = true;
        colName.Width = 220;
        // 
        // colQty
        // 
        colQty.HeaderText = "Кол-во/Вес";
        colQty.MinimumWidth = 8;
        colQty.Name = "colQty";
        colQty.ReadOnly = true;
        colQty.Width = 90;
        // 
        // colPrice
        // 
        colPrice.HeaderText = "Цена";
        colPrice.MinimumWidth = 8;
        colPrice.Name = "colPrice";
        colPrice.ReadOnly = true;
        colPrice.Width = 90;
        // 
        // colSum
        // 
        colSum.HeaderText = "Сумма";
        colSum.MinimumWidth = 8;
        colSum.Name = "colSum";
        colSum.ReadOnly = true;
        colSum.Width = 90;
        // 
        // btnNewCheck
        // 
        btnNewCheck.Location = new Point(260, 294);
        btnNewCheck.Margin = new Padding(4, 5, 4, 5);
        btnNewCheck.Name = "btnNewCheck";
        btnNewCheck.Size = new Size(171, 47);
        btnNewCheck.TabIndex = 11;
        btnNewCheck.Text = "Новый чек";
        btnNewCheck.Click += BtnNewCheck_Click;
        // 
        // btnRemoveLast
        // 
        btnRemoveLast.Location = new Point(29, 294);
        btnRemoveLast.Margin = new Padding(4, 5, 4, 5);
        btnRemoveLast.Name = "btnRemoveLast";
        btnRemoveLast.Size = new Size(200, 47);
        btnRemoveLast.TabIndex = 12;
        btnRemoveLast.Text = "Удалить последнюю";
        btnRemoveLast.Click += BtnRemoveLast_Click;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(600, 233);
        btnAdd.Margin = new Padding(4, 5, 4, 5);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(200, 47);
        btnAdd.TabIndex = 13;
        btnAdd.Text = "Добавить в чек";
        btnAdd.Click += BtnAdd_Click;
        // 
        // txtWeight
        // 
        txtWeight.Location = new Point(457, 237);
        txtWeight.Margin = new Padding(4, 5, 4, 5);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(113, 31);
        txtWeight.TabIndex = 14;
        txtWeight.Text = "0.500";
        txtWeight.Visible = false;
        // 
        // lblWeight
        // 
        lblWeight.AutoSize = true;
        lblWeight.Location = new Point(357, 242);
        lblWeight.Margin = new Padding(4, 0, 4, 0);
        lblWeight.Name = "lblWeight";
        lblWeight.Size = new Size(74, 25);
        lblWeight.TabIndex = 15;
        lblWeight.Text = "Вес (кг):";
        lblWeight.Visible = false;
        // 
        // nudQuantity
        // 
        nudQuantity.Location = new Point(214, 237);
        nudQuantity.Margin = new Padding(4, 5, 4, 5);
        nudQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudQuantity.Name = "nudQuantity";
        nudQuantity.Size = new Size(114, 31);
        nudQuantity.TabIndex = 16;
        nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblQty
        // 
        lblQty.AutoSize = true;
        lblQty.Location = new Point(29, 242);
        lblQty.Margin = new Padding(4, 0, 4, 0);
        lblQty.Name = "lblQty";
        lblQty.Size = new Size(151, 25);
        lblQty.TabIndex = 17;
        lblQty.Text = "Количество (шт.):";
        // 
        // lblProductDisplay
        // 
        lblProductDisplay.BorderStyle = BorderStyle.FixedSingle;
        lblProductDisplay.Location = new Point(29, 175);
        lblProductDisplay.Margin = new Padding(4, 0, 4, 0);
        lblProductDisplay.Name = "lblProductDisplay";
        lblProductDisplay.Size = new Size(771, 45);
        lblProductDisplay.TabIndex = 18;
        lblProductDisplay.Text = "Товар не выбран";
        lblProductDisplay.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtBarcode
        // 
        txtBarcode.Location = new Point(543, 125);
        txtBarcode.Margin = new Padding(4, 5, 4, 5);
        txtBarcode.Name = "txtBarcode";
        txtBarcode.Size = new Size(255, 31);
        txtBarcode.TabIndex = 19;
        txtBarcode.Leave += TxtBarcode_Leave;
        // 
        // cmbProducts
        // 
        cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProducts.Location = new Point(29, 125);
        cmbProducts.Margin = new Padding(4, 5, 4, 5);
        cmbProducts.Name = "cmbProducts";
        cmbProducts.Size = new Size(498, 33);
        cmbProducts.TabIndex = 20;
        cmbProducts.SelectedIndexChanged += CmbProducts_SelectedIndexChanged;
        // 
        // lblBarcode
        // 
        lblBarcode.AutoSize = true;
        lblBarcode.Location = new Point(29, 92);
        lblBarcode.Margin = new Padding(4, 0, 4, 0);
        lblBarcode.Name = "lblBarcode";
        lblBarcode.Size = new Size(241, 25);
        lblBarcode.TabIndex = 21;
        lblBarcode.Text = "Товар (сканер / штрих-код):";
        // 
        // btnHelp
        // 
        btnHelp.Location = new Point(643, 17);
        btnHelp.Margin = new Padding(4, 5, 4, 5);
        btnHelp.Name = "btnHelp";
        btnHelp.Size = new Size(143, 47);
        btnHelp.TabIndex = 22;
        btnHelp.Text = "Помощь";
        btnHelp.Click += BtnHelp_Click;
        // 
        // btnSubmitRevenue
        // 
        btnSubmitRevenue.Location = new Point(400, 17);
        btnSubmitRevenue.Margin = new Padding(4, 5, 4, 5);
        btnSubmitRevenue.Name = "btnSubmitRevenue";
        btnSubmitRevenue.Size = new Size(214, 47);
        btnSubmitRevenue.TabIndex = 23;
        btnSubmitRevenue.Text = "Сдать выручку";
        btnSubmitRevenue.Click += BtnSubmitRevenue_Click;
        // 
        // lblRevenue
        // 
        lblRevenue.AutoSize = true;
        lblRevenue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblRevenue.Location = new Point(200, 25);
        lblRevenue.Margin = new Padding(4, 0, 4, 0);
        lblRevenue.Name = "lblRevenue";
        lblRevenue.Size = new Size(99, 28);
        lblRevenue.TabIndex = 24;
        lblRevenue.Text = "0.00 руб.";
        // 
        // lblRevenueTitle
        // 
        lblRevenueTitle.AutoSize = true;
        lblRevenueTitle.Location = new Point(29, 25);
        lblRevenueTitle.Margin = new Padding(4, 0, 4, 0);
        lblRevenueTitle.Name = "lblRevenueTitle";
        lblRevenueTitle.Size = new Size(150, 25);
        lblRevenueTitle.TabIndex = 25;
        lblRevenueTitle.Text = "Выручка в кассе:";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1400, 1102);
        Controls.Add(tabMain);
        Margin = new Padding(4, 5, 4, 5);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Кассовый терминал супермаркета";
        Load += MainForm_Load;
        tabMain.ResumeLayout(false);
        tabAuth.ResumeLayout(false);
        tabAuth.PerformLayout();
        tabWork.ResumeLayout(false);
        tabWork.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCheck).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
        ResumeLayout(false);
    }

    private TabControl tabMain;
  private TabPage tabAuth;
  private TabPage tabWork;
  private Label lblCard;
  private ComboBox cmbCard;
  private Label lblPassword;
  private TextBox txtPassword;
  private Button btnLogin;
  private Label lblCashier;
  private Button btnLogout;
  private Label lblRevenueTitle;
  private Label lblRevenue;
  private Button btnSubmitRevenue;
  private Button btnHelp;
  private Label lblBarcode;
  private ComboBox cmbProducts;
  private TextBox txtBarcode;
  private Label lblProductDisplay;
  private Label lblQty;
  private NumericUpDown nudQuantity;
  private Label lblWeight;
  private TextBox txtWeight;
  private Button btnAdd;
  private Button btnRemoveLast;
  private Button btnNewCheck;
  private DataGridView dgvCheck;
  private DataGridViewTextBoxColumn colName;
  private DataGridViewTextBoxColumn colQty;
  private DataGridViewTextBoxColumn colPrice;
  private DataGridViewTextBoxColumn colSum;
  private Label lblTotalTitle;
  private Label lblTotal;
  private Label lblPaid;
  private TextBox txtPaidAmount;
  private Button btnCloseCheck;
  private Label lblReceipt;
  private RichTextBox rtbReceipt;
  private Label lblTime;
  private DateTimePicker dtpSaleTime;
  private Button btnCashDrawer;
}
