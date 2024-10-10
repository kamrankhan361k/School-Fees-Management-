namespace School.UI.Account.Journal
{
    partial class frmJournal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournal));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.epJournal = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbJournal = new System.Windows.Forms.GroupBox();
            this.txtCrTotalAmount = new System.Windows.Forms.TextBox();
            this.txtDrTotalAmount = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbCr = new System.Windows.Forms.ComboBox();
            this.txtCrAmount = new System.Windows.Forms.TextBox();
            this.txtDrAmount = new System.Windows.Forms.TextBox();
            this.cbDrLedger = new System.Windows.Forms.ComboBox();
            this.lblCrAmount = new System.Windows.Forms.Label();
            this.lblDrAmount = new System.Windows.Forms.Label();
            this.btnSavePrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.lblVoucherNo = new System.Windows.Forms.Label();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblCr = new System.Windows.Forms.Label();
            this.cbCrDepartmentnm = new System.Windows.Forms.ComboBox();
            this.lblCrDepartment = new System.Windows.Forms.Label();
            this.lblDr = new System.Windows.Forms.Label();
            this.cbDrDepartmentnm = new System.Windows.Forms.ComboBox();
            this.lblDrDepartmentnm = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epJournal)).BeginInit();
            this.gbJournal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.LightBlue;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(731, 39);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(131, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Journal Voucher";
            // 
            // epJournal
            // 
            this.epJournal.ContainerControl = this;
            // 
            // gbJournal
            // 
            this.gbJournal.Controls.Add(this.txtCrTotalAmount);
            this.gbJournal.Controls.Add(this.txtDrTotalAmount);
            this.gbJournal.Controls.Add(this.btnExit);
            this.gbJournal.Controls.Add(this.cbCr);
            this.gbJournal.Controls.Add(this.txtCrAmount);
            this.gbJournal.Controls.Add(this.txtDrAmount);
            this.gbJournal.Controls.Add(this.cbDrLedger);
            this.gbJournal.Controls.Add(this.lblCrAmount);
            this.gbJournal.Controls.Add(this.lblDrAmount);
            this.gbJournal.Controls.Add(this.btnSavePrint);
            this.gbJournal.Controls.Add(this.btnSave);
            this.gbJournal.Controls.Add(this.txtNarration);
            this.gbJournal.Controls.Add(this.txtVoucherNo);
            this.gbJournal.Controls.Add(this.lblVoucherNo);
            this.gbJournal.Controls.Add(this.lblNarration);
            this.gbJournal.Controls.Add(this.lblCr);
            this.gbJournal.Controls.Add(this.cbCrDepartmentnm);
            this.gbJournal.Controls.Add(this.lblCrDepartment);
            this.gbJournal.Controls.Add(this.lblDr);
            this.gbJournal.Controls.Add(this.cbDrDepartmentnm);
            this.gbJournal.Controls.Add(this.lblDrDepartmentnm);
            this.gbJournal.Controls.Add(this.dtDate);
            this.gbJournal.Controls.Add(this.lblDate);
            this.gbJournal.Location = new System.Drawing.Point(8, 41);
            this.gbJournal.Name = "gbJournal";
            this.gbJournal.Size = new System.Drawing.Size(717, 356);
            this.gbJournal.TabIndex = 0;
            this.gbJournal.TabStop = false;
            // 
            // txtCrTotalAmount
            // 
            this.txtCrTotalAmount.Location = new System.Drawing.Point(566, 222);
            this.txtCrTotalAmount.Name = "txtCrTotalAmount";
            this.txtCrTotalAmount.ReadOnly = true;
            this.txtCrTotalAmount.Size = new System.Drawing.Size(132, 21);
            this.txtCrTotalAmount.TabIndex = 111;
            // 
            // txtDrTotalAmount
            // 
            this.txtDrTotalAmount.Location = new System.Drawing.Point(436, 222);
            this.txtDrTotalAmount.Name = "txtDrTotalAmount";
            this.txtDrTotalAmount.ReadOnly = true;
            this.txtDrTotalAmount.Size = new System.Drawing.Size(132, 21);
            this.txtDrTotalAmount.TabIndex = 110;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(623, 318);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbCr
            // 
            this.cbCr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCr.FormattingEnabled = true;
            this.cbCr.Location = new System.Drawing.Point(118, 180);
            this.cbCr.Name = "cbCr";
            this.cbCr.Size = new System.Drawing.Size(265, 23);
            this.cbCr.TabIndex = 5;
            // 
            // txtCrAmount
            // 
            this.txtCrAmount.Location = new System.Drawing.Point(566, 174);
            this.txtCrAmount.MaxLength = 15;
            this.txtCrAmount.Name = "txtCrAmount";
            this.txtCrAmount.Size = new System.Drawing.Size(132, 21);
            this.txtCrAmount.TabIndex = 109;
            this.txtCrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrAmount_KeyPress);
            this.txtCrAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCrAmount_KeyUp);
            // 
            // txtDrAmount
            // 
            this.txtDrAmount.Location = new System.Drawing.Point(436, 108);
            this.txtDrAmount.MaxLength = 15;
            this.txtDrAmount.Name = "txtDrAmount";
            this.txtDrAmount.Size = new System.Drawing.Size(132, 21);
            this.txtDrAmount.TabIndex = 3;
            this.txtDrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrAmount_KeyPress);
            this.txtDrAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDrAmount_KeyUp);
            // 
            // cbDrLedger
            // 
            this.cbDrLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrLedger.FormattingEnabled = true;
            this.cbDrLedger.Location = new System.Drawing.Point(118, 108);
            this.cbDrLedger.Name = "cbDrLedger";
            this.cbDrLedger.Size = new System.Drawing.Size(265, 23);
            this.cbDrLedger.TabIndex = 2;
            // 
            // lblCrAmount
            // 
            this.lblCrAmount.AutoSize = true;
            this.lblCrAmount.Location = new System.Drawing.Point(600, 74);
            this.lblCrAmount.Name = "lblCrAmount";
            this.lblCrAmount.Size = new System.Drawing.Size(49, 15);
            this.lblCrAmount.TabIndex = 107;
            this.lblCrAmount.Text = "Amount";
            // 
            // lblDrAmount
            // 
            this.lblDrAmount.AutoSize = true;
            this.lblDrAmount.Location = new System.Drawing.Point(468, 74);
            this.lblDrAmount.Name = "lblDrAmount";
            this.lblDrAmount.Size = new System.Drawing.Size(49, 15);
            this.lblDrAmount.TabIndex = 106;
            this.lblDrAmount.Text = "Amount";
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSavePrint.BackgroundImage")));
            this.btnSavePrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSavePrint.ForeColor = System.Drawing.Color.White;
            this.btnSavePrint.Location = new System.Drawing.Point(489, 318);
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
            this.btnSave.Location = new System.Drawing.Point(408, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(118, 254);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(265, 42);
            this.txtNarration.TabIndex = 6;
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Location = new System.Drawing.Point(118, 32);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.ReadOnly = true;
            this.txtVoucherNo.Size = new System.Drawing.Size(265, 21);
            this.txtVoucherNo.TabIndex = 0;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(20, 35);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(82, 15);
            this.lblVoucherNo.TabIndex = 88;
            this.lblVoucherNo.Text = "Voucher No.:*";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(20, 254);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(66, 15);
            this.lblNarration.TabIndex = 106;
            this.lblNarration.Text = "Narration:*";
            // 
            // lblCr
            // 
            this.lblCr.AutoSize = true;
            this.lblCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCr.Location = new System.Drawing.Point(23, 183);
            this.lblCr.Name = "lblCr";
            this.lblCr.Size = new System.Drawing.Size(35, 17);
            this.lblCr.TabIndex = 101;
            this.lblCr.Text = " Cr.* ";
            // 
            // cbCrDepartmentnm
            // 
            this.cbCrDepartmentnm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCrDepartmentnm.FormattingEnabled = true;
            this.cbCrDepartmentnm.Location = new System.Drawing.Point(118, 142);
            this.cbCrDepartmentnm.Name = "cbCrDepartmentnm";
            this.cbCrDepartmentnm.Size = new System.Drawing.Size(265, 23);
            this.cbCrDepartmentnm.TabIndex = 4;
            // 
            // lblCrDepartment
            // 
            this.lblCrDepartment.AutoSize = true;
            this.lblCrDepartment.Location = new System.Drawing.Point(20, 145);
            this.lblCrDepartment.Name = "lblCrDepartment";
            this.lblCrDepartment.Size = new System.Drawing.Size(80, 15);
            this.lblCrDepartment.TabIndex = 99;
            this.lblCrDepartment.Text = "Department:*";
            // 
            // lblDr
            // 
            this.lblDr.AutoSize = true;
            this.lblDr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDr.Location = new System.Drawing.Point(23, 108);
            this.lblDr.Name = "lblDr";
            this.lblDr.Size = new System.Drawing.Size(36, 17);
            this.lblDr.TabIndex = 96;
            this.lblDr.Text = " Dr.* ";
            // 
            // cbDrDepartmentnm
            // 
            this.cbDrDepartmentnm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrDepartmentnm.FormattingEnabled = true;
            this.cbDrDepartmentnm.Location = new System.Drawing.Point(118, 71);
            this.cbDrDepartmentnm.Name = "cbDrDepartmentnm";
            this.cbDrDepartmentnm.Size = new System.Drawing.Size(265, 23);
            this.cbDrDepartmentnm.TabIndex = 1;
            // 
            // lblDrDepartmentnm
            // 
            this.lblDrDepartmentnm.AutoSize = true;
            this.lblDrDepartmentnm.Location = new System.Drawing.Point(20, 74);
            this.lblDrDepartmentnm.Name = "lblDrDepartmentnm";
            this.lblDrDepartmentnm.Size = new System.Drawing.Size(80, 15);
            this.lblDrDepartmentnm.TabIndex = 92;
            this.lblDrDepartmentnm.Text = "Department:*";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Enabled = false;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(476, 29);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(222, 21);
            this.dtDate.TabIndex = 91;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(419, 35);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 15);
            this.lblDate.TabIndex = 90;
            this.lblDate.Text = "Date :";
            // 
            // frmJournal
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(731, 406);
            this.Controls.Add(this.gbJournal);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJournal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journal Voucher";
            this.Load += new System.EventHandler(this.frmJournal_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epJournal)).EndInit();
            this.gbJournal.ResumeLayout(false);
            this.gbJournal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider epJournal;
        private System.Windows.Forms.GroupBox gbJournal;
        private System.Windows.Forms.TextBox txtCrTotalAmount;
        private System.Windows.Forms.TextBox txtDrTotalAmount;
        private System.Windows.Forms.TextBox txtCrAmount;
        private System.Windows.Forms.TextBox txtDrAmount;
        private System.Windows.Forms.Label lblCrAmount;
        private System.Windows.Forms.Label lblDrAmount;
        private System.Windows.Forms.ComboBox cbDrLedger;
        private System.Windows.Forms.Button btnSavePrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Label lblCr;
        private System.Windows.Forms.ComboBox cbCrDepartmentnm;
        private System.Windows.Forms.Label lblCrDepartment;
        private System.Windows.Forms.Label lblDr;
        private System.Windows.Forms.ComboBox cbDrDepartmentnm;
        private System.Windows.Forms.Label lblDrDepartmentnm;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Label lblVoucherNo;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.ComboBox cbCr;
    }
}