namespace School.UI.CollectFees
{
    partial class frmSaveCollectFees
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaveCollectFees));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.epCollectFees = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAssignFees = new System.Windows.Forms.Button();
            this.lblStandard = new System.Windows.Forms.Label();
            this.txtGivenBy = new System.Windows.Forms.TextBox();
            this.lblGivenBy = new System.Windows.Forms.Label();
            this.cbStandard = new System.Windows.Forms.ComboBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cbDivision = new System.Windows.Forms.ComboBox();
            this.lblDivision = new System.Windows.Forms.Label();
            this.lblReceivedBy = new System.Windows.Forms.Label();
            this.txtReceivedBy = new System.Windows.Forms.TextBox();
            this.dtReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.lblReceivedDate = new System.Windows.Forms.Label();
            this.cbStudent = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblGRNo = new System.Windows.Forms.Label();
            this.lblGRNoD = new System.Windows.Forms.Label();
            this.gvCompleteFees = new System.Windows.Forms.DataGridView();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvPendingFees = new System.Windows.Forms.DataGridView();
            this.IsPay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectFeesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblTotalPaidFees = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalPendingFees = new System.Windows.Forms.Label();
            this.lblTotalPayFees = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalCurrentPendingFees = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.txtBankNarration = new System.Windows.Forms.TextBox();
            this.lblBankNarration = new System.Windows.Forms.Label();
            this.lblWaiverNarration = new System.Windows.Forms.Label();
            this.txtWaiverNarration = new System.Windows.Forms.TextBox();
            this.txtWaiver = new System.Windows.Forms.TextBox();
            this.lblWaiver = new System.Windows.Forms.Label();
            this.btnPendingFees = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectFees)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompleteFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPendingFees)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.LightBlue;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1021, 36);
            this.pnlTitle.TabIndex = 42;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(115, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Save Collect Fees";
            // 
            // epCollectFees
            // 
            this.epCollectFees.ContainerControl = this;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnExist);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 641);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1021, 50);
            this.pnlFooter.TabIndex = 55;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(119, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExist
            // 
            this.btnExist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExist.BackgroundImage")));
            this.btnExist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExist.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExist.ForeColor = System.Drawing.Color.White;
            this.btnExist.Location = new System.Drawing.Point(929, 10);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 28);
            this.btnExist.TabIndex = 3;
            this.btnExist.Text = "&Exit";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(16, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAssignFees
            // 
            this.btnAssignFees.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAssignFees.BackgroundImage")));
            this.btnAssignFees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignFees.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAssignFees.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAssignFees.ForeColor = System.Drawing.Color.White;
            this.btnAssignFees.Location = new System.Drawing.Point(382, 165);
            this.btnAssignFees.Name = "btnAssignFees";
            this.btnAssignFees.Size = new System.Drawing.Size(85, 25);
            this.btnAssignFees.TabIndex = 152;
            this.btnAssignFees.Text = "&Assign Fees";
            this.btnAssignFees.UseVisualStyleBackColor = true;
            this.btnAssignFees.Visible = false;
            this.btnAssignFees.Click += new System.EventHandler(this.btnAssignFees_Click);
            // 
            // lblStandard
            // 
            this.lblStandard.AutoSize = true;
            this.lblStandard.ForeColor = System.Drawing.Color.Black;
            this.lblStandard.Location = new System.Drawing.Point(40, 91);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(62, 14);
            this.lblStandard.TabIndex = 51;
            this.lblStandard.Text = "Standard :*";
            // 
            // txtGivenBy
            // 
            this.txtGivenBy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtGivenBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGivenBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGivenBy.Location = new System.Drawing.Point(540, 50);
            this.txtGivenBy.Margin = new System.Windows.Forms.Padding(0);
            this.txtGivenBy.MaxLength = 150;
            this.txtGivenBy.Name = "txtGivenBy";
            this.txtGivenBy.Size = new System.Drawing.Size(237, 22);
            this.txtGivenBy.TabIndex = 8;
            // 
            // lblGivenBy
            // 
            this.lblGivenBy.AutoSize = true;
            this.lblGivenBy.ForeColor = System.Drawing.Color.Black;
            this.lblGivenBy.Location = new System.Drawing.Point(441, 54);
            this.lblGivenBy.Name = "lblGivenBy";
            this.lblGivenBy.Size = new System.Drawing.Size(56, 14);
            this.lblGivenBy.TabIndex = 56;
            this.lblGivenBy.Text = "Given By :";
            // 
            // cbStandard
            // 
            this.cbStandard.BackColor = System.Drawing.SystemColors.Window;
            this.cbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStandard.FormattingEnabled = true;
            this.cbStandard.Location = new System.Drawing.Point(139, 87);
            this.cbStandard.Name = "cbStandard";
            this.cbStandard.Size = new System.Drawing.Size(237, 22);
            this.cbStandard.TabIndex = 6;
            this.cbStandard.SelectedIndexChanged += new System.EventHandler(this.cbStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // cbDepartment
            // 
            this.cbDepartment.BackColor = System.Drawing.SystemColors.Window;
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(139, 50);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(237, 22);
            this.cbDepartment.TabIndex = 5;
            this.cbDepartment.SelectedIndexChanged += new System.EventHandler(this.cbStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(40, 54);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(78, 14);
            this.lblDepartment.TabIndex = 65;
            this.lblDepartment.Text = "Department :*";
            // 
            // cbDivision
            // 
            this.cbDivision.BackColor = System.Drawing.SystemColors.Window;
            this.cbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDivision.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDivision.FormattingEnabled = true;
            this.cbDivision.Location = new System.Drawing.Point(139, 125);
            this.cbDivision.Name = "cbDivision";
            this.cbDivision.Size = new System.Drawing.Size(237, 22);
            this.cbDivision.TabIndex = 7;
            this.cbDivision.SelectedIndexChanged += new System.EventHandler(this.cbStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // lblDivision
            // 
            this.lblDivision.AutoSize = true;
            this.lblDivision.ForeColor = System.Drawing.Color.Black;
            this.lblDivision.Location = new System.Drawing.Point(40, 129);
            this.lblDivision.Name = "lblDivision";
            this.lblDivision.Size = new System.Drawing.Size(57, 14);
            this.lblDivision.TabIndex = 68;
            this.lblDivision.Text = "Division :*";
            // 
            // lblReceivedBy
            // 
            this.lblReceivedBy.AutoSize = true;
            this.lblReceivedBy.ForeColor = System.Drawing.Color.Black;
            this.lblReceivedBy.Location = new System.Drawing.Point(441, 92);
            this.lblReceivedBy.Name = "lblReceivedBy";
            this.lblReceivedBy.Size = new System.Drawing.Size(72, 14);
            this.lblReceivedBy.TabIndex = 73;
            this.lblReceivedBy.Text = "Received By :";
            // 
            // txtReceivedBy
            // 
            this.txtReceivedBy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtReceivedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceivedBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedBy.Location = new System.Drawing.Point(540, 88);
            this.txtReceivedBy.Margin = new System.Windows.Forms.Padding(0);
            this.txtReceivedBy.MaxLength = 150;
            this.txtReceivedBy.Name = "txtReceivedBy";
            this.txtReceivedBy.Size = new System.Drawing.Size(237, 22);
            this.txtReceivedBy.TabIndex = 9;
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.CustomFormat = "dd/MM/yyyy";
            this.dtReceivedDate.Enabled = false;
            this.dtReceivedDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivedDate.Location = new System.Drawing.Point(540, 126);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.Size = new System.Drawing.Size(177, 22);
            this.dtReceivedDate.TabIndex = 10;
            // 
            // lblReceivedDate
            // 
            this.lblReceivedDate.AutoSize = true;
            this.lblReceivedDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivedDate.Location = new System.Drawing.Point(441, 130);
            this.lblReceivedDate.Name = "lblReceivedDate";
            this.lblReceivedDate.Size = new System.Drawing.Size(83, 14);
            this.lblReceivedDate.TabIndex = 134;
            this.lblReceivedDate.Text = "Received Date :";
            // 
            // cbStudent
            // 
            this.cbStudent.BackColor = System.Drawing.SystemColors.Window;
            this.cbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudent.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStudent.FormattingEnabled = true;
            this.cbStudent.Location = new System.Drawing.Point(139, 166);
            this.cbStudent.Name = "cbStudent";
            this.cbStudent.Size = new System.Drawing.Size(237, 22);
            this.cbStudent.TabIndex = 4;
            this.cbStudent.SelectedIndexChanged += new System.EventHandler(this.cbStudent_SelectedIndexChanged);
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.ForeColor = System.Drawing.Color.Black;
            this.lblStudent.Location = new System.Drawing.Point(40, 170);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(56, 14);
            this.lblStudent.TabIndex = 136;
            this.lblStudent.Text = "Student :*";
            // 
            // lblGRNo
            // 
            this.lblGRNo.AutoSize = true;
            this.lblGRNo.ForeColor = System.Drawing.Color.Black;
            this.lblGRNo.Location = new System.Drawing.Point(486, 170);
            this.lblGRNo.Name = "lblGRNo";
            this.lblGRNo.Size = new System.Drawing.Size(45, 14);
            this.lblGRNo.TabIndex = 137;
            this.lblGRNo.Text = "GR No :";
            // 
            // lblGRNoD
            // 
            this.lblGRNoD.AutoSize = true;
            this.lblGRNoD.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblGRNoD.ForeColor = System.Drawing.Color.Black;
            this.lblGRNoD.Location = new System.Drawing.Point(540, 170);
            this.lblGRNoD.Name = "lblGRNoD";
            this.lblGRNoD.Size = new System.Drawing.Size(39, 14);
            this.lblGRNoD.TabIndex = 138;
            this.lblGRNoD.Text = "GR No";
            // 
            // gvCompleteFees
            // 
            this.gvCompleteFees.AllowUserToAddRows = false;
            this.gvCompleteFees.AllowUserToDeleteRows = false;
            this.gvCompleteFees.AllowUserToResizeColumns = false;
            this.gvCompleteFees.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.gvCompleteFees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gvCompleteFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCompleteFees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvCompleteFees.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gvCompleteFees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvCompleteFees.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCompleteFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gvCompleteFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCompleteFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptNo,
            this.FeesType,
            this.FeesName,
            this.PaidFees,
            this.ReceivedDate});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCompleteFees.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvCompleteFees.Location = new System.Drawing.Point(472, 204);
            this.gvCompleteFees.MultiSelect = false;
            this.gvCompleteFees.Name = "gvCompleteFees";
            this.gvCompleteFees.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCompleteFees.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gvCompleteFees.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.gvCompleteFees.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gvCompleteFees.RowTemplate.Height = 35;
            this.gvCompleteFees.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCompleteFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCompleteFees.Size = new System.Drawing.Size(533, 347);
            this.gvCompleteFees.TabIndex = 139;
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ReceiptNo.DataPropertyName = "ReceiptNo";
            this.ReceiptNo.HeaderText = "Receipt No";
            this.ReceiptNo.Name = "ReceiptNo";
            this.ReceiptNo.ReadOnly = true;
            this.ReceiptNo.Width = 90;
            // 
            // FeesType
            // 
            this.FeesType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FeesType.DataPropertyName = "FeesType";
            this.FeesType.HeaderText = "Fees Type";
            this.FeesType.Name = "FeesType";
            this.FeesType.ReadOnly = true;
            this.FeesType.Width = 80;
            // 
            // FeesName
            // 
            this.FeesName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FeesName.DataPropertyName = "DisplayFeesName";
            this.FeesName.HeaderText = "Fees Name";
            this.FeesName.Name = "FeesName";
            this.FeesName.ReadOnly = true;
            this.FeesName.Width = 150;
            // 
            // PaidFees
            // 
            this.PaidFees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PaidFees.DataPropertyName = "PayFees";
            this.PaidFees.HeaderText = "Paid Fees";
            this.PaidFees.Name = "PaidFees";
            this.PaidFees.ReadOnly = true;
            this.PaidFees.Width = 80;
            // 
            // ReceivedDate
            // 
            this.ReceivedDate.DataPropertyName = "ReceivedDate";
            this.ReceivedDate.HeaderText = "Received Date";
            this.ReceivedDate.Name = "ReceivedDate";
            this.ReceivedDate.ReadOnly = true;
            // 
            // gvPendingFees
            // 
            this.gvPendingFees.AllowUserToAddRows = false;
            this.gvPendingFees.AllowUserToDeleteRows = false;
            this.gvPendingFees.AllowUserToResizeColumns = false;
            this.gvPendingFees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gvPendingFees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPendingFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPendingFees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvPendingFees.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gvPendingFees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvPendingFees.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPendingFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvPendingFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPendingFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsPay,
            this.Fees,
            this.PayFees,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CollectFeesID,
            this.FeesId});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPendingFees.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvPendingFees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvPendingFees.Location = new System.Drawing.Point(17, 204);
            this.gvPendingFees.MultiSelect = false;
            this.gvPendingFees.Name = "gvPendingFees";
            this.gvPendingFees.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPendingFees.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvPendingFees.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gvPendingFees.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvPendingFees.RowTemplate.Height = 35;
            this.gvPendingFees.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPendingFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPendingFees.Size = new System.Drawing.Size(438, 347);
            this.gvPendingFees.TabIndex = 11;
            this.gvPendingFees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPendingFees_CellContentClick);
            this.gvPendingFees.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPendingFees_CellValueChanged);
            // 
            // IsPay
            // 
            this.IsPay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsPay.FalseValue = "False";
            this.IsPay.HeaderText = "IsPay";
            this.IsPay.IndeterminateValue = "";
            this.IsPay.Name = "IsPay";
            this.IsPay.TrueValue = "True";
            this.IsPay.Width = 50;
            // 
            // Fees
            // 
            this.Fees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fees.DataPropertyName = "PendingFees";
            this.Fees.HeaderText = "Fees";
            this.Fees.Name = "Fees";
            this.Fees.ReadOnly = true;
            this.Fees.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Fees.Width = 70;
            // 
            // PayFees
            // 
            this.PayFees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PayFees.HeaderText = "Pay Fees";
            this.PayFees.Name = "PayFees";
            this.PayFees.Width = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FeesType";
            this.dataGridViewTextBoxColumn1.HeaderText = "Fees Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DisplayFeesName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Fees Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CollectFeesID
            // 
            this.CollectFeesID.DataPropertyName = "CollectFeesID";
            this.CollectFeesID.HeaderText = "Id";
            this.CollectFeesID.Name = "CollectFeesID";
            this.CollectFeesID.Visible = false;
            // 
            // FeesId
            // 
            this.FeesId.DataPropertyName = "FeesID";
            this.FeesId.HeaderText = "FeesId";
            this.FeesId.Name = "FeesId";
            this.FeesId.Visible = false;
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblReceiptNo.ForeColor = System.Drawing.Color.Black;
            this.lblReceiptNo.Location = new System.Drawing.Point(744, 170);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(61, 14);
            this.lblReceiptNo.TabIndex = 141;
            this.lblReceiptNo.Text = "Receipt No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(670, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 140;
            this.label2.Text = "Receipt No :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(401, 559);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(66, 17);
            this.lblTotal.TabIndex = 142;
            this.lblTotal.Text = "Total Fees";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalFees.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFees.Location = new System.Drawing.Point(401, 585);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(15, 17);
            this.lblTotalFees.TabIndex = 143;
            this.lblTotalFees.Text = "0";
            // 
            // lblTotalPaidFees
            // 
            this.lblTotalPaidFees.AutoSize = true;
            this.lblTotalPaidFees.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaidFees.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPaidFees.Location = new System.Drawing.Point(488, 585);
            this.lblTotalPaidFees.Name = "lblTotalPaidFees";
            this.lblTotalPaidFees.Size = new System.Drawing.Size(15, 17);
            this.lblTotalPaidFees.TabIndex = 144;
            this.lblTotalPaidFees.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(488, 559);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 145;
            this.label1.Text = "Total Paid Fees";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(599, 559);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 146;
            this.label3.Text = "Total Pending Fees";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(731, 559);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 147;
            this.label4.Text = "Total Pay Fees";
            // 
            // lblTotalPendingFees
            // 
            this.lblTotalPendingFees.AutoSize = true;
            this.lblTotalPendingFees.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalPendingFees.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPendingFees.Location = new System.Drawing.Point(599, 585);
            this.lblTotalPendingFees.Name = "lblTotalPendingFees";
            this.lblTotalPendingFees.Size = new System.Drawing.Size(15, 17);
            this.lblTotalPendingFees.TabIndex = 148;
            this.lblTotalPendingFees.Text = "0";
            // 
            // lblTotalPayFees
            // 
            this.lblTotalPayFees.AutoSize = true;
            this.lblTotalPayFees.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalPayFees.ForeColor = System.Drawing.Color.Green;
            this.lblTotalPayFees.Location = new System.Drawing.Point(731, 585);
            this.lblTotalPayFees.Name = "lblTotalPayFees";
            this.lblTotalPayFees.Size = new System.Drawing.Size(15, 17);
            this.lblTotalPayFees.TabIndex = 149;
            this.lblTotalPayFees.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(847, 559);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 17);
            this.label5.TabIndex = 150;
            this.label5.Text = "Total Current Pending Fees";
            // 
            // lblTotalCurrentPendingFees
            // 
            this.lblTotalCurrentPendingFees.AutoSize = true;
            this.lblTotalCurrentPendingFees.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCurrentPendingFees.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCurrentPendingFees.Location = new System.Drawing.Point(847, 585);
            this.lblTotalCurrentPendingFees.Name = "lblTotalCurrentPendingFees";
            this.lblTotalCurrentPendingFees.Size = new System.Drawing.Size(15, 17);
            this.lblTotalCurrentPendingFees.TabIndex = 151;
            this.lblTotalCurrentPendingFees.Text = "0";
            // 
            // txtCash
            // 
            this.txtCash.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCash.Location = new System.Drawing.Point(109, 556);
            this.txtCash.MaxLength = 10;
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(43, 22);
            this.txtCash.TabIndex = 156;
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            this.txtCash.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCash_KeyUp);
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(26, 558);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(36, 14);
            this.lblCash.TabIndex = 155;
            this.lblCash.Text = "C&ash :";
            // 
            // txtBank
            // 
            this.txtBank.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBank.Location = new System.Drawing.Point(109, 585);
            this.txtBank.MaxLength = 10;
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(43, 22);
            this.txtBank.TabIndex = 158;
            this.txtBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBank_KeyPress);
            this.txtBank.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBank_KeyUp);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(26, 585);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(37, 14);
            this.lblBank.TabIndex = 157;
            this.lblBank.Text = "&Bank :";
            // 
            // txtBankNarration
            // 
            this.txtBankNarration.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBankNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankNarration.Location = new System.Drawing.Point(241, 584);
            this.txtBankNarration.MaxLength = 250;
            this.txtBankNarration.Name = "txtBankNarration";
            this.txtBankNarration.Size = new System.Drawing.Size(107, 22);
            this.txtBankNarration.TabIndex = 159;
            // 
            // lblBankNarration
            // 
            this.lblBankNarration.AutoSize = true;
            this.lblBankNarration.Location = new System.Drawing.Point(158, 588);
            this.lblBankNarration.Name = "lblBankNarration";
            this.lblBankNarration.Size = new System.Drawing.Size(60, 14);
            this.lblBankNarration.TabIndex = 160;
            this.lblBankNarration.Text = "Narration :";
            // 
            // lblWaiverNarration
            // 
            this.lblWaiverNarration.AutoSize = true;
            this.lblWaiverNarration.Location = new System.Drawing.Point(158, 617);
            this.lblWaiverNarration.Name = "lblWaiverNarration";
            this.lblWaiverNarration.Size = new System.Drawing.Size(60, 14);
            this.lblWaiverNarration.TabIndex = 164;
            this.lblWaiverNarration.Text = "Narration :";
            // 
            // txtWaiverNarration
            // 
            this.txtWaiverNarration.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtWaiverNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaiverNarration.Location = new System.Drawing.Point(241, 613);
            this.txtWaiverNarration.MaxLength = 250;
            this.txtWaiverNarration.Name = "txtWaiverNarration";
            this.txtWaiverNarration.Size = new System.Drawing.Size(107, 22);
            this.txtWaiverNarration.TabIndex = 163;
            // 
            // txtWaiver
            // 
            this.txtWaiver.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtWaiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaiver.Location = new System.Drawing.Point(109, 613);
            this.txtWaiver.MaxLength = 10;
            this.txtWaiver.Name = "txtWaiver";
            this.txtWaiver.Size = new System.Drawing.Size(43, 22);
            this.txtWaiver.TabIndex = 162;
            this.txtWaiver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaiver_KeyPress);
            // 
            // lblWaiver
            // 
            this.lblWaiver.AutoSize = true;
            this.lblWaiver.Location = new System.Drawing.Point(26, 617);
            this.lblWaiver.Name = "lblWaiver";
            this.lblWaiver.Size = new System.Drawing.Size(48, 14);
            this.lblWaiver.TabIndex = 161;
            this.lblWaiver.Text = "&Waiver :";
            // 
            // btnPendingFees
            // 
            this.btnPendingFees.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPendingFees.BackgroundImage")));
            this.btnPendingFees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPendingFees.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPendingFees.ForeColor = System.Drawing.Color.White;
            this.btnPendingFees.Location = new System.Drawing.Point(382, 166);
            this.btnPendingFees.Name = "btnPendingFees";
            this.btnPendingFees.Size = new System.Drawing.Size(85, 25);
            this.btnPendingFees.TabIndex = 165;
            this.btnPendingFees.Text = "&Pending Fees";
            this.btnPendingFees.UseVisualStyleBackColor = true;
            this.btnPendingFees.Visible = false;
            this.btnPendingFees.Click += new System.EventHandler(this.btnPendingFees_Click);
            // 
            // frmSaveCollectFees
            // 
            this.AcceptButton = this.btnSave;
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExist;
            this.ClientSize = new System.Drawing.Size(1021, 691);
            this.Controls.Add(this.btnPendingFees);
            this.Controls.Add(this.lblWaiverNarration);
            this.Controls.Add(this.txtWaiverNarration);
            this.Controls.Add(this.txtWaiver);
            this.Controls.Add(this.lblWaiver);
            this.Controls.Add(this.lblBankNarration);
            this.Controls.Add(this.txtBankNarration);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.btnAssignFees);
            this.Controls.Add(this.lblTotalCurrentPendingFees);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotalPayFees);
            this.Controls.Add(this.lblTotalPendingFees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalPaidFees);
            this.Controls.Add(this.lblTotalFees);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvPendingFees);
            this.Controls.Add(this.gvCompleteFees);
            this.Controls.Add(this.lblGRNoD);
            this.Controls.Add(this.lblGRNo);
            this.Controls.Add(this.cbStudent);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.dtReceivedDate);
            this.Controls.Add(this.lblReceivedDate);
            this.Controls.Add(this.lblReceivedBy);
            this.Controls.Add(this.txtReceivedBy);
            this.Controls.Add(this.cbDivision);
            this.Controls.Add(this.lblDivision);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cbStandard);
            this.Controls.Add(this.lblGivenBy);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.txtGivenBy);
            this.Controls.Add(this.lblStandard);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaveCollectFees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Collect Fees";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSaveCollectFees_FormClosed);
            this.Load += new System.EventHandler(this.frmSaveCollectFees_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSaveCollectFees_KeyDown);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectFees)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCompleteFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPendingFees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider epCollectFees;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblGivenBy;
        private System.Windows.Forms.TextBox txtGivenBy;
        private System.Windows.Forms.Label lblStandard;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblDivision;
        private System.Windows.Forms.Label lblReceivedBy;
        private System.Windows.Forms.TextBox txtReceivedBy;
        private System.Windows.Forms.DateTimePicker dtReceivedDate;
        private System.Windows.Forms.Label lblReceivedDate;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblGRNoD;
        private System.Windows.Forms.Label lblGRNo;
        private System.Windows.Forms.ComboBox cbStandard;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.ComboBox cbDivision;
        private System.Windows.Forms.ComboBox cbStudent;
        private System.Windows.Forms.DataGridView gvCompleteFees;
        private System.Windows.Forms.DataGridView gvPendingFees;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fees;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectFeesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeesId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedDate;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalPayFees;
        private System.Windows.Forms.Label lblTotalPendingFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPaidFees;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblTotalCurrentPendingFees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAssignFees;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.TextBox txtBankNarration;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblBankNarration;
        private System.Windows.Forms.Label lblWaiverNarration;
        private System.Windows.Forms.TextBox txtWaiverNarration;
        private System.Windows.Forms.TextBox txtWaiver;
        private System.Windows.Forms.Label lblWaiver;
        private System.Windows.Forms.Button btnPendingFees;
    }
}