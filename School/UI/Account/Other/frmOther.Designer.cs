namespace School.UI.Account.Other
{
    partial class frmOther
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOther));
            this.epOther = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDrTotal = new System.Windows.Forms.TextBox();
            this.txtCrTotal = new System.Windows.Forms.TextBox();
            this.txtDrAmount = new System.Windows.Forms.TextBox();
            this.txtCrAmount = new System.Windows.Forms.TextBox();
            this.lblCrAmount = new System.Windows.Forms.Label();
            this.lblDrAmount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSavePrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtReceiveFrom = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblReceiveFrom = new System.Windows.Forms.Label();
            this.lblDr = new System.Windows.Forms.Label();
            this.lblCr = new System.Windows.Forms.Label();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.cbDepartmentnm = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.gbPayment = new System.Windows.Forms.GroupBox();
            this.cbDr1 = new System.Windows.Forms.ComboBox();
            this.cbCr1 = new System.Windows.Forms.ComboBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.epOther)).BeginInit();
            this.gbPayment.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // epOther
            // 
            this.epOther.ContainerControl = this;
            // 
            // txtDrTotal
            // 
            this.txtDrTotal.Location = new System.Drawing.Point(554, 206);
            this.txtDrTotal.Name = "txtDrTotal";
            this.txtDrTotal.ReadOnly = true;
            this.txtDrTotal.Size = new System.Drawing.Size(132, 22);
            this.txtDrTotal.TabIndex = 85;
            // 
            // txtCrTotal
            // 
            this.txtCrTotal.Location = new System.Drawing.Point(422, 206);
            this.txtCrTotal.Name = "txtCrTotal";
            this.txtCrTotal.ReadOnly = true;
            this.txtCrTotal.Size = new System.Drawing.Size(132, 22);
            this.txtCrTotal.TabIndex = 84;
            // 
            // txtDrAmount
            // 
            this.txtDrAmount.Location = new System.Drawing.Point(554, 165);
            this.txtDrAmount.MaxLength = 15;
            this.txtDrAmount.Name = "txtDrAmount";
            this.txtDrAmount.Size = new System.Drawing.Size(132, 22);
            this.txtDrAmount.TabIndex = 81;
            this.txtDrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrAmount_KeyPress);
            this.txtDrAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDrAmount_KeyUp);
            // 
            // txtCrAmount
            // 
            this.txtCrAmount.Location = new System.Drawing.Point(423, 128);
            this.txtCrAmount.MaxLength = 15;
            this.txtCrAmount.Name = "txtCrAmount";
            this.txtCrAmount.Size = new System.Drawing.Size(132, 22);
            this.txtCrAmount.TabIndex = 3;
            this.txtCrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrAmount_KeyPress);
            this.txtCrAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCrAmount_KeyUp);
            // 
            // lblCrAmount
            // 
            this.lblCrAmount.AutoSize = true;
            this.lblCrAmount.Location = new System.Drawing.Point(607, 103);
            this.lblCrAmount.Name = "lblCrAmount";
            this.lblCrAmount.Size = new System.Drawing.Size(46, 14);
            this.lblCrAmount.TabIndex = 83;
            this.lblCrAmount.Text = "Amount";
            // 
            // lblDrAmount
            // 
            this.lblDrAmount.AutoSize = true;
            this.lblDrAmount.Location = new System.Drawing.Point(464, 103);
            this.lblDrAmount.Name = "lblDrAmount";
            this.lblDrAmount.Size = new System.Drawing.Size(46, 14);
            this.lblDrAmount.TabIndex = 82;
            this.lblDrAmount.Text = "Amount";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(611, 337);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(119, 258);
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(265, 45);
            this.txtNarration.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Other Receipt Voucher";
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSavePrint.BackgroundImage")));
            this.btnSavePrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSavePrint.ForeColor = System.Drawing.Color.White;
            this.btnSavePrint.Location = new System.Drawing.Point(477, 337);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(128, 25);
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
            this.btnSave.Location = new System.Drawing.Point(396, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReceiveFrom
            // 
            this.txtReceiveFrom.Location = new System.Drawing.Point(119, 206);
            this.txtReceiveFrom.Name = "txtReceiveFrom";
            this.txtReceiveFrom.Size = new System.Drawing.Size(265, 22);
            this.txtReceiveFrom.TabIndex = 5;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Location = new System.Drawing.Point(30, 261);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(63, 14);
            this.lblNarration.TabIndex = 78;
            this.lblNarration.Text = "Narration:*";
            // 
            // lblReceiveFrom
            // 
            this.lblReceiveFrom.AutoSize = true;
            this.lblReceiveFrom.Location = new System.Drawing.Point(30, 209);
            this.lblReceiveFrom.Name = "lblReceiveFrom";
            this.lblReceiveFrom.Size = new System.Drawing.Size(83, 14);
            this.lblReceiveFrom.TabIndex = 77;
            this.lblReceiveFrom.Text = "Receive From:*";
            // 
            // lblDr
            // 
            this.lblDr.AutoSize = true;
            this.lblDr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDr.Location = new System.Drawing.Point(33, 169);
            this.lblDr.Name = "lblDr";
            this.lblDr.Size = new System.Drawing.Size(34, 16);
            this.lblDr.TabIndex = 74;
            this.lblDr.Text = " Dr.* ";
            // 
            // lblCr
            // 
            this.lblCr.AutoSize = true;
            this.lblCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCr.Location = new System.Drawing.Point(34, 135);
            this.lblCr.Name = "lblCr";
            this.lblCr.Size = new System.Drawing.Size(33, 16);
            this.lblCr.TabIndex = 71;
            this.lblCr.Text = " Cr.* ";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtReceiptNo.Location = new System.Drawing.Point(120, 67);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(265, 22);
            this.txtReceiptNo.TabIndex = 1;
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(31, 70);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(73, 14);
            this.lblReceiptNo.TabIndex = 69;
            this.lblReceiptNo.Text = "Receipt No.:*";
            // 
            // cbDepartmentnm
            // 
            this.cbDepartmentnm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartmentnm.FormattingEnabled = true;
            this.cbDepartmentnm.Location = new System.Drawing.Point(120, 24);
            this.cbDepartmentnm.Name = "cbDepartmentnm";
            this.cbDepartmentnm.Size = new System.Drawing.Size(265, 22);
            this.cbDepartmentnm.TabIndex = 0;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.BackColor = System.Drawing.Color.White;
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(31, 24);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(75, 14);
            this.lblDepartment.TabIndex = 67;
            this.lblDepartment.Text = "Department:*";
            // 
            // gbPayment
            // 
            this.gbPayment.Controls.Add(this.cbDr1);
            this.gbPayment.Controls.Add(this.cbCr1);
            this.gbPayment.Controls.Add(this.txtDrTotal);
            this.gbPayment.Controls.Add(this.txtCrTotal);
            this.gbPayment.Controls.Add(this.txtDrAmount);
            this.gbPayment.Controls.Add(this.txtCrAmount);
            this.gbPayment.Controls.Add(this.lblCrAmount);
            this.gbPayment.Controls.Add(this.lblDrAmount);
            this.gbPayment.Controls.Add(this.btnExit);
            this.gbPayment.Controls.Add(this.txtNarration);
            this.gbPayment.Controls.Add(this.btnSavePrint);
            this.gbPayment.Controls.Add(this.btnSave);
            this.gbPayment.Controls.Add(this.txtReceiveFrom);
            this.gbPayment.Controls.Add(this.lblNarration);
            this.gbPayment.Controls.Add(this.lblReceiveFrom);
            this.gbPayment.Controls.Add(this.lblDr);
            this.gbPayment.Controls.Add(this.lblCr);
            this.gbPayment.Controls.Add(this.txtReceiptNo);
            this.gbPayment.Controls.Add(this.lblReceiptNo);
            this.gbPayment.Controls.Add(this.cbDepartmentnm);
            this.gbPayment.Controls.Add(this.lblDepartment);
            this.gbPayment.Location = new System.Drawing.Point(7, 43);
            this.gbPayment.Name = "gbPayment";
            this.gbPayment.Size = new System.Drawing.Size(717, 378);
            this.gbPayment.TabIndex = 0;
            this.gbPayment.TabStop = false;
            // 
            // cbDr1
            // 
            this.cbDr1.BackColor = System.Drawing.SystemColors.Window;
            this.cbDr1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDr1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDr1.FormattingEnabled = true;
            this.cbDr1.Items.AddRange(new object[] {
            "Cash",
            "Bank",
            "Waiver"});
            this.cbDr1.Location = new System.Drawing.Point(120, 169);
            this.cbDr1.Name = "cbDr1";
            this.cbDr1.Size = new System.Drawing.Size(264, 22);
            this.cbDr1.TabIndex = 4;
            // 
            // cbCr1
            // 
            this.cbCr1.BackColor = System.Drawing.SystemColors.Window;
            this.cbCr1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCr1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCr1.FormattingEnabled = true;
            this.cbCr1.Location = new System.Drawing.Point(119, 129);
            this.cbCr1.Name = "cbCr1";
            this.cbCr1.Size = new System.Drawing.Size(266, 22);
            this.cbCr1.TabIndex = 2;
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
            this.pnlTitle.Size = new System.Drawing.Size(731, 42);
            this.pnlTitle.TabIndex = 2;
            // 
            // frmOther
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(731, 429);
            this.Controls.Add(this.gbPayment);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOther";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Receipt Voucher";
            this.Load += new System.EventHandler(this.frmOther_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epOther)).EndInit();
            this.gbPayment.ResumeLayout(false);
            this.gbPayment.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider epOther;
        private System.Windows.Forms.GroupBox gbPayment;
        private System.Windows.Forms.TextBox txtDrTotal;
        private System.Windows.Forms.TextBox txtCrTotal;
        private System.Windows.Forms.TextBox txtDrAmount;
        private System.Windows.Forms.TextBox txtCrAmount;
        private System.Windows.Forms.Label lblCrAmount;
        private System.Windows.Forms.Label lblDrAmount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Button btnSavePrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtReceiveFrom;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Label lblReceiveFrom;
        private System.Windows.Forms.Label lblDr;
        private System.Windows.Forms.Label lblCr;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.ComboBox cbDepartmentnm;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.ComboBox cbCr1;
        public System.Windows.Forms.ComboBox cbDr1;
    }
}