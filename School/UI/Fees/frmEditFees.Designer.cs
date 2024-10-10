namespace School.UI.Fees
{
    partial class frmEditFees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditFees));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.epFees = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStandard = new System.Windows.Forms.Label();
            this.txtFeesName = new System.Windows.Forms.TextBox();
            this.lblFeesName = new System.Windows.Forms.Label();
            this.cbStandard = new System.Windows.Forms.ComboBox();
            this.lblFees = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.pbStandard = new System.Windows.Forms.PictureBox();
            this.pbDepartment = new System.Windows.Forms.PictureBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFees)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStandard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepartment)).BeginInit();
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
            this.pnlTitle.Size = new System.Drawing.Size(599, 36);
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
            this.lblTitle.Size = new System.Drawing.Size(69, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Save Fees";
            // 
            // epFees
            // 
            this.epFees.ContainerControl = this;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnExist);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 345);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(599, 43);
            this.pnlFooter.TabIndex = 55;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(102, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 1;
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
            this.btnExist.Location = new System.Drawing.Point(508, 8);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 28);
            this.btnExist.TabIndex = 2;
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
            this.btnSave.Location = new System.Drawing.Point(11, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStandard
            // 
            this.lblStandard.AutoSize = true;
            this.lblStandard.ForeColor = System.Drawing.Color.Black;
            this.lblStandard.Location = new System.Drawing.Point(128, 105);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(62, 14);
            this.lblStandard.TabIndex = 51;
            this.lblStandard.Text = "Standard :*";
            // 
            // txtFeesName
            // 
            this.txtFeesName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFeesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFeesName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeesName.Location = new System.Drawing.Point(217, 181);
            this.txtFeesName.Margin = new System.Windows.Forms.Padding(0);
            this.txtFeesName.MaxLength = 50;
            this.txtFeesName.Name = "txtFeesName";
            this.txtFeesName.Size = new System.Drawing.Size(237, 22);
            this.txtFeesName.TabIndex = 2;
            // 
            // lblFeesName
            // 
            this.lblFeesName.AutoSize = true;
            this.lblFeesName.ForeColor = System.Drawing.Color.Black;
            this.lblFeesName.Location = new System.Drawing.Point(128, 185);
            this.lblFeesName.Name = "lblFeesName";
            this.lblFeesName.Size = new System.Drawing.Size(75, 14);
            this.lblFeesName.TabIndex = 56;
            this.lblFeesName.Text = "Fees Name :*";
            // 
            // cbStandard
            // 
            this.cbStandard.BackColor = System.Drawing.SystemColors.Window;
            this.cbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStandard.FormattingEnabled = true;
            this.cbStandard.Location = new System.Drawing.Point(217, 101);
            this.cbStandard.Name = "cbStandard";
            this.cbStandard.Size = new System.Drawing.Size(237, 22);
            this.cbStandard.TabIndex = 0;
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.ForeColor = System.Drawing.Color.Black;
            this.lblFees.Location = new System.Drawing.Point(128, 226);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(45, 14);
            this.lblFees.TabIndex = 62;
            this.lblFees.Text = "Fees :* ";
            // 
            // txtFees
            // 
            this.txtFees.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFees.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFees.Location = new System.Drawing.Point(217, 222);
            this.txtFees.Margin = new System.Windows.Forms.Padding(0);
            this.txtFees.MaxLength = 10;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(237, 22);
            this.txtFees.TabIndex = 3;
            this.txtFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // pbStandard
            // 
            this.pbStandard.Image = global::School.Properties.Resources.Add;
            this.pbStandard.Location = new System.Drawing.Point(474, 97);
            this.pbStandard.Name = "pbStandard";
            this.pbStandard.Size = new System.Drawing.Size(28, 30);
            this.pbStandard.TabIndex = 64;
            this.pbStandard.TabStop = false;
            this.pbStandard.Click += new System.EventHandler(this.pbStandard_Click);
            // 
            // pbDepartment
            // 
            this.pbDepartment.Image = global::School.Properties.Resources.Add;
            this.pbDepartment.Location = new System.Drawing.Point(474, 137);
            this.pbDepartment.Name = "pbDepartment";
            this.pbDepartment.Size = new System.Drawing.Size(28, 30);
            this.pbDepartment.TabIndex = 69;
            this.pbDepartment.TabStop = false;
            this.pbDepartment.Click += new System.EventHandler(this.pbDepartment_Click);
            // 
            // cbDepartment
            // 
            this.cbDepartment.BackColor = System.Drawing.SystemColors.Window;
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(217, 142);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(237, 22);
            this.cbDepartment.TabIndex = 1;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(128, 145);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(78, 14);
            this.lblDepartment.TabIndex = 68;
            this.lblDepartment.Text = "Department :*";
            // 
            // frmEditFees
            // 
            this.AcceptButton = this.btnSave;
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExist;
            this.ClientSize = new System.Drawing.Size(599, 388);
            this.Controls.Add(this.pbDepartment);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.pbStandard);
            this.Controls.Add(this.lblFees);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.cbStandard);
            this.Controls.Add(this.lblFeesName);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.txtFeesName);
            this.Controls.Add(this.lblStandard);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditFees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Fees";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSaveFees_FormClosed);
            this.Load += new System.EventHandler(this.frmSaveFees_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFees)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStandard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepartment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider epFees;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFeesName;
        private System.Windows.Forms.TextBox txtFeesName;
        private System.Windows.Forms.Label lblStandard;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.PictureBox pbStandard;
        public System.Windows.Forms.ComboBox cbStandard;
        private System.Windows.Forms.PictureBox pbDepartment;
        public System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label lblDepartment;
    }
}