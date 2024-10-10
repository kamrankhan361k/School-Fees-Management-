namespace School.UI.Account.Contra
{
    partial class frmContra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContra));
            this.cbCr = new System.Windows.Forms.ComboBox();
            this.txtCrTotal = new System.Windows.Forms.TextBox();
            this.txtDrTotal = new System.Windows.Forms.TextBox();
            this.txtCrAmount = new System.Windows.Forms.TextBox();
            this.txtDrAmount = new System.Windows.Forms.TextBox();
            this.lblCrAmount = new System.Windows.Forms.Label();
            this.lblDrAmount = new System.Windows.Forms.Label();
            this.epContra = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbDr = new System.Windows.Forms.ComboBox();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.btnSavePrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblReasonFor = new System.Windows.Forms.Label();
            this.lblCr = new System.Windows.Forms.Label();
            this.lblDr = new System.Windows.Forms.Label();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.lblVoucherNo = new System.Windows.Forms.Label();
            this.cbDepartmentnm = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.gbPayment = new System.Windows.Forms.GroupBox();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epContra)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.gbPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCr
            // 
            this.cbCr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCr.FormattingEnabled = true;
            this.cbCr.Items.AddRange(new object[] {
            "Cash",
            "Bank"});
            this.cbCr.Location = new System.Drawing.Point(120, 154);
            this.cbCr.Name = "cbCr";
            this.cbCr.Size = new System.Drawing.Size(265, 23);
            this.cbCr.TabIndex = 4;
            this.cbCr.SelectedIndexChanged += new System.EventHandler(this.cbCr_SelectedIndexChanged);
            // 
            // txtCrTotal
            // 
            this.txtCrTotal.Location = new System.Drawing.Point(562, 182);
            this.txtCrTotal.Name = "txtCrTotal";
            this.txtCrTotal.ReadOnly = true;
            this.txtCrTotal.Size = new System.Drawing.Size(132, 21);
            this.txtCrTotal.TabIndex = 69;
            // 
            // txtDrTotal
            // 
            this.txtDrTotal.Location = new System.Drawing.Point(430, 182);
            this.txtDrTotal.Name = "txtDrTotal";
            this.txtDrTotal.ReadOnly = true;
            this.txtDrTotal.Size = new System.Drawing.Size(132, 21);
            this.txtDrTotal.TabIndex = 68;
            // 
            // txtCrAmount
            // 
            this.txtCrAmount.Location = new System.Drawing.Point(562, 153);
            this.txtCrAmount.MaxLength = 15;
            this.txtCrAmount.Name = "txtCrAmount";
            this.txtCrAmount.Size = new System.Drawing.Size(132, 21);
            this.txtCrAmount.TabIndex = 10;
            this.txtCrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrAmount_KeyPress);
            this.txtCrAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCrAmount_KeyUp);
            // 
            // txtDrAmount
            // 
            this.txtDrAmount.Location = new System.Drawing.Point(430, 121);
            this.txtDrAmount.MaxLength = 15;
            this.txtDrAmount.Name = "txtDrAmount";
            this.txtDrAmount.Size = new System.Drawing.Size(132, 21);
            this.txtDrAmount.TabIndex = 3;
            this.txtDrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrAmount_KeyPress);
            this.txtDrAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDrAmount_KeyUp);
            // 
            // lblCrAmount
            // 
            this.lblCrAmount.AutoSize = true;
            this.lblCrAmount.Location = new System.Drawing.Point(605, 84);
            this.lblCrAmount.Name = "lblCrAmount";
            this.lblCrAmount.Size = new System.Drawing.Size(49, 15);
            this.lblCrAmount.TabIndex = 65;
            this.lblCrAmount.Text = "Amount";
            // 
            // lblDrAmount
            // 
            this.lblDrAmount.AutoSize = true;
            this.lblDrAmount.Location = new System.Drawing.Point(472, 85);
            this.lblDrAmount.Name = "lblDrAmount";
            this.lblDrAmount.Size = new System.Drawing.Size(49, 15);
            this.lblDrAmount.TabIndex = 64;
            this.lblDrAmount.Text = "Amount";
            // 
            // epContra
            // 
            this.epContra.ContainerControl = this;
            // 
            // cbDr
            // 
            this.cbDr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDr.FormattingEnabled = true;
            this.cbDr.Location = new System.Drawing.Point(120, 120);
            this.cbDr.Name = "cbDr";
            this.cbDr.Size = new System.Drawing.Size(265, 23);
            this.cbDr.TabIndex = 2;
            this.cbDr.SelectedIndexChanged += new System.EventHandler(this.cbDr_SelectedIndexChanged);
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(120, 252);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(265, 42);
            this.txtNarration.TabIndex = 6;
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSavePrint.BackgroundImage")));
            this.btnSavePrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSavePrint.ForeColor = System.Drawing.Color.White;
            this.btnSavePrint.Location = new System.Drawing.Point(485, 316);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(128, 23);
            this.btnSavePrint.TabIndex = 8;
            this.btnSavePrint.Text = "&Save And  Print";
            this.btnSavePrint.UseVisualStyleBackColor = true;
            this.btnSavePrint.Click += new System.EventHandler(this.btnSavePrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(404, 316);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(120, 204);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(265, 21);
            this.txtPayment.TabIndex = 5;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(31, 255);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(66, 15);
            this.lblNarration.TabIndex = 78;
            this.lblNarration.Text = "Narration:*";
            // 
            // lblReasonFor
            // 
            this.lblReasonFor.AutoSize = true;
            this.lblReasonFor.Location = new System.Drawing.Point(31, 207);
            this.lblReasonFor.Name = "lblReasonFor";
            this.lblReasonFor.Size = new System.Drawing.Size(82, 15);
            this.lblReasonFor.TabIndex = 77;
            this.lblReasonFor.Text = "Reason For :*";
            // 
            // lblCr
            // 
            this.lblCr.AutoSize = true;
            this.lblCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCr.Location = new System.Drawing.Point(34, 159);
            this.lblCr.Name = "lblCr";
            this.lblCr.Size = new System.Drawing.Size(35, 17);
            this.lblCr.TabIndex = 74;
            this.lblCr.Text = " Cr.* ";
            // 
            // lblDr
            // 
            this.lblDr.AutoSize = true;
            this.lblDr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDr.Location = new System.Drawing.Point(34, 124);
            this.lblDr.Name = "lblDr";
            this.lblDr.Size = new System.Drawing.Size(36, 17);
            this.lblDr.TabIndex = 71;
            this.lblDr.Text = " Dr.* ";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtVoucherNo.Location = new System.Drawing.Point(120, 60);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.ReadOnly = true;
            this.txtVoucherNo.Size = new System.Drawing.Size(265, 21);
            this.txtVoucherNo.TabIndex = 1;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(31, 63);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(82, 15);
            this.lblVoucherNo.TabIndex = 69;
            this.lblVoucherNo.Text = "Voucher No.:*";
            // 
            // cbDepartmentnm
            // 
            this.cbDepartmentnm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartmentnm.FormattingEnabled = true;
            this.cbDepartmentnm.Location = new System.Drawing.Point(120, 22);
            this.cbDepartmentnm.Name = "cbDepartmentnm";
            this.cbDepartmentnm.Size = new System.Drawing.Size(265, 23);
            this.cbDepartmentnm.TabIndex = 0;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.BackColor = System.Drawing.Color.White;
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(31, 22);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(80, 15);
            this.lblDepartment.TabIndex = 67;
            this.lblDepartment.Text = "Department:*";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(126, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Contra Voucher";
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.LightBlue;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(731, 39);
            this.pnlTitle.TabIndex = 45;
            // 
            // gbPayment
            // 
            this.gbPayment.Controls.Add(this.lblDateValue);
            this.gbPayment.Controls.Add(this.lblDate);
            this.gbPayment.Controls.Add(this.lblCrAmount);
            this.gbPayment.Controls.Add(this.txtCrTotal);
            this.gbPayment.Controls.Add(this.lblDrAmount);
            this.gbPayment.Controls.Add(this.btnExit);
            this.gbPayment.Controls.Add(this.txtDrTotal);
            this.gbPayment.Controls.Add(this.cbDr);
            this.gbPayment.Controls.Add(this.txtCrAmount);
            this.gbPayment.Controls.Add(this.cbCr);
            this.gbPayment.Controls.Add(this.txtDrAmount);
            this.gbPayment.Controls.Add(this.txtNarration);
            this.gbPayment.Controls.Add(this.btnSavePrint);
            this.gbPayment.Controls.Add(this.btnSave);
            this.gbPayment.Controls.Add(this.txtPayment);
            this.gbPayment.Controls.Add(this.lblNarration);
            this.gbPayment.Controls.Add(this.lblReasonFor);
            this.gbPayment.Controls.Add(this.lblCr);
            this.gbPayment.Controls.Add(this.lblDr);
            this.gbPayment.Controls.Add(this.txtVoucherNo);
            this.gbPayment.Controls.Add(this.lblVoucherNo);
            this.gbPayment.Controls.Add(this.cbDepartmentnm);
            this.gbPayment.Controls.Add(this.lblDepartment);
            this.gbPayment.Location = new System.Drawing.Point(8, 41);
            this.gbPayment.Name = "gbPayment";
            this.gbPayment.Size = new System.Drawing.Size(717, 351);
            this.gbPayment.TabIndex = 0;
            this.gbPayment.TabStop = false;
            // 
            // lblDateValue
            // 
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Location = new System.Drawing.Point(605, 22);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(31, 15);
            this.lblDateValue.TabIndex = 91;
            this.lblDateValue.Text = "date";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(472, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 15);
            this.lblDate.TabIndex = 90;
            this.lblDate.Text = "Date";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(619, 316);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmContra
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(731, 400);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.gbPayment);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contra Voucher";
            this.Load += new System.EventHandler(this.frmContra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epContra)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.gbPayment.ResumeLayout(false);
            this.gbPayment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCrTotal;
        private System.Windows.Forms.TextBox txtDrTotal;
        private System.Windows.Forms.TextBox txtCrAmount;
        private System.Windows.Forms.TextBox txtDrAmount;
        private System.Windows.Forms.Label lblCrAmount;
        private System.Windows.Forms.Label lblDrAmount;
        private System.Windows.Forms.ErrorProvider epContra;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbPayment;
        private System.Windows.Forms.ComboBox cbDr;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Button btnSavePrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Label lblReasonFor;
        private System.Windows.Forms.Label lblCr;
        private System.Windows.Forms.Label lblDr;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Label lblVoucherNo;
        private System.Windows.Forms.ComboBox cbDepartmentnm;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.ComboBox cbCr;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblDate;
    }
}