namespace School.UI.PrintSetting
{
    partial class frmSavePrintSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSavePrintSetting));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.epPrintSetting = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtOutputFormat = new System.Windows.Forms.TextBox();
            this.lblOutputFormat = new System.Windows.Forms.Label();
            this.lblPageHeight = new System.Windows.Forms.Label();
            this.txtPageHeight = new System.Windows.Forms.TextBox();
            this.lblPageWidth = new System.Windows.Forms.Label();
            this.txtPageWidth = new System.Windows.Forms.TextBox();
            this.lblMarginTop = new System.Windows.Forms.Label();
            this.txtMarginTop = new System.Windows.Forms.TextBox();
            this.lblMarginLeft = new System.Windows.Forms.Label();
            this.txtMarginLeft = new System.Windows.Forms.TextBox();
            this.lblMarginBottom = new System.Windows.Forms.Label();
            this.txtMarginBottom = new System.Windows.Forms.TextBox();
            this.lblMarginRight = new System.Windows.Forms.Label();
            this.txtMarginRight = new System.Windows.Forms.TextBox();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPrintSetting)).BeginInit();
            this.pnlFooter.SuspendLayout();
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
            this.pnlTitle.Size = new System.Drawing.Size(611, 36);
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
            this.lblTitle.Size = new System.Drawing.Size(116, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Save Print Setting";
            // 
            // epPrintSetting
            // 
            this.epPrintSetting.ContainerControl = this;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnExist);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 409);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(611, 43);
            this.pnlFooter.TabIndex = 7;
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
            this.btnExist.Location = new System.Drawing.Point(517, 8);
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
            // txtOutputFormat
            // 
            this.txtOutputFormat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtOutputFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFormat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputFormat.Location = new System.Drawing.Point(217, 87);
            this.txtOutputFormat.Margin = new System.Windows.Forms.Padding(0);
            this.txtOutputFormat.MaxLength = 50;
            this.txtOutputFormat.Name = "txtOutputFormat";
            this.txtOutputFormat.Size = new System.Drawing.Size(237, 22);
            this.txtOutputFormat.TabIndex = 0;
            // 
            // lblOutputFormat
            // 
            this.lblOutputFormat.AutoSize = true;
            this.lblOutputFormat.ForeColor = System.Drawing.Color.Black;
            this.lblOutputFormat.Location = new System.Drawing.Point(111, 91);
            this.lblOutputFormat.Name = "lblOutputFormat";
            this.lblOutputFormat.Size = new System.Drawing.Size(95, 14);
            this.lblOutputFormat.TabIndex = 56;
            this.lblOutputFormat.Text = "Output Format  :*";
            // 
            // lblPageHeight
            // 
            this.lblPageHeight.AutoSize = true;
            this.lblPageHeight.ForeColor = System.Drawing.Color.Black;
            this.lblPageHeight.Location = new System.Drawing.Point(111, 129);
            this.lblPageHeight.Name = "lblPageHeight";
            this.lblPageHeight.Size = new System.Drawing.Size(78, 14);
            this.lblPageHeight.TabIndex = 73;
            this.lblPageHeight.Text = "Page Height :*";
            // 
            // txtPageHeight
            // 
            this.txtPageHeight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPageHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPageHeight.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageHeight.Location = new System.Drawing.Point(217, 125);
            this.txtPageHeight.Margin = new System.Windows.Forms.Padding(0);
            this.txtPageHeight.MaxLength = 6;
            this.txtPageHeight.Name = "txtPageHeight";
            this.txtPageHeight.Size = new System.Drawing.Size(237, 22);
            this.txtPageHeight.TabIndex = 1;
            this.txtPageHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblPageWidth
            // 
            this.lblPageWidth.AutoSize = true;
            this.lblPageWidth.ForeColor = System.Drawing.Color.Black;
            this.lblPageWidth.Location = new System.Drawing.Point(111, 167);
            this.lblPageWidth.Name = "lblPageWidth";
            this.lblPageWidth.Size = new System.Drawing.Size(76, 14);
            this.lblPageWidth.TabIndex = 75;
            this.lblPageWidth.Text = "Page Width :*";
            // 
            // txtPageWidth
            // 
            this.txtPageWidth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPageWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPageWidth.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageWidth.Location = new System.Drawing.Point(217, 163);
            this.txtPageWidth.Margin = new System.Windows.Forms.Padding(0);
            this.txtPageWidth.MaxLength = 6;
            this.txtPageWidth.Name = "txtPageWidth";
            this.txtPageWidth.Size = new System.Drawing.Size(237, 22);
            this.txtPageWidth.TabIndex = 2;
            this.txtPageWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblMarginTop
            // 
            this.lblMarginTop.AutoSize = true;
            this.lblMarginTop.ForeColor = System.Drawing.Color.Black;
            this.lblMarginTop.Location = new System.Drawing.Point(111, 205);
            this.lblMarginTop.Name = "lblMarginTop";
            this.lblMarginTop.Size = new System.Drawing.Size(74, 14);
            this.lblMarginTop.TabIndex = 77;
            this.lblMarginTop.Text = "Margin Top :*";
            // 
            // txtMarginTop
            // 
            this.txtMarginTop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMarginTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarginTop.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarginTop.Location = new System.Drawing.Point(217, 201);
            this.txtMarginTop.Margin = new System.Windows.Forms.Padding(0);
            this.txtMarginTop.MaxLength = 6;
            this.txtMarginTop.Name = "txtMarginTop";
            this.txtMarginTop.Size = new System.Drawing.Size(237, 22);
            this.txtMarginTop.TabIndex = 3;
            this.txtMarginTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblMarginLeft
            // 
            this.lblMarginLeft.AutoSize = true;
            this.lblMarginLeft.ForeColor = System.Drawing.Color.Black;
            this.lblMarginLeft.Location = new System.Drawing.Point(111, 243);
            this.lblMarginLeft.Name = "lblMarginLeft";
            this.lblMarginLeft.Size = new System.Drawing.Size(75, 14);
            this.lblMarginLeft.TabIndex = 79;
            this.lblMarginLeft.Text = "Margin Left :*";
            // 
            // txtMarginLeft
            // 
            this.txtMarginLeft.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMarginLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarginLeft.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarginLeft.Location = new System.Drawing.Point(217, 239);
            this.txtMarginLeft.Margin = new System.Windows.Forms.Padding(0);
            this.txtMarginLeft.MaxLength = 6;
            this.txtMarginLeft.Name = "txtMarginLeft";
            this.txtMarginLeft.Size = new System.Drawing.Size(237, 22);
            this.txtMarginLeft.TabIndex = 4;
            this.txtMarginLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblMarginBottom
            // 
            this.lblMarginBottom.AutoSize = true;
            this.lblMarginBottom.ForeColor = System.Drawing.Color.Black;
            this.lblMarginBottom.Location = new System.Drawing.Point(111, 318);
            this.lblMarginBottom.Name = "lblMarginBottom";
            this.lblMarginBottom.Size = new System.Drawing.Size(94, 14);
            this.lblMarginBottom.TabIndex = 83;
            this.lblMarginBottom.Text = "Margin Bottom :*";
            // 
            // txtMarginBottom
            // 
            this.txtMarginBottom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMarginBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarginBottom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarginBottom.Location = new System.Drawing.Point(217, 314);
            this.txtMarginBottom.Margin = new System.Windows.Forms.Padding(0);
            this.txtMarginBottom.MaxLength = 6;
            this.txtMarginBottom.Name = "txtMarginBottom";
            this.txtMarginBottom.Size = new System.Drawing.Size(237, 22);
            this.txtMarginBottom.TabIndex = 6;
            this.txtMarginBottom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblMarginRight
            // 
            this.lblMarginRight.AutoSize = true;
            this.lblMarginRight.ForeColor = System.Drawing.Color.Black;
            this.lblMarginRight.Location = new System.Drawing.Point(111, 280);
            this.lblMarginRight.Name = "lblMarginRight";
            this.lblMarginRight.Size = new System.Drawing.Size(83, 14);
            this.lblMarginRight.TabIndex = 82;
            this.lblMarginRight.Text = "Margin Right :*";
            // 
            // txtMarginRight
            // 
            this.txtMarginRight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMarginRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarginRight.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarginRight.Location = new System.Drawing.Point(217, 276);
            this.txtMarginRight.Margin = new System.Windows.Forms.Padding(0);
            this.txtMarginRight.MaxLength = 6;
            this.txtMarginRight.Name = "txtMarginRight";
            this.txtMarginRight.Size = new System.Drawing.Size(237, 22);
            this.txtMarginRight.TabIndex = 5;
            this.txtMarginRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // frmSavePrintSetting
            // 
            this.AcceptButton = this.btnSave;
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExist;
            this.ClientSize = new System.Drawing.Size(611, 452);
            this.Controls.Add(this.lblMarginBottom);
            this.Controls.Add(this.txtMarginBottom);
            this.Controls.Add(this.lblMarginRight);
            this.Controls.Add(this.txtMarginRight);
            this.Controls.Add(this.lblMarginLeft);
            this.Controls.Add(this.txtMarginLeft);
            this.Controls.Add(this.lblMarginTop);
            this.Controls.Add(this.txtMarginTop);
            this.Controls.Add(this.lblPageWidth);
            this.Controls.Add(this.txtPageWidth);
            this.Controls.Add(this.lblPageHeight);
            this.Controls.Add(this.txtPageHeight);
            this.Controls.Add(this.lblOutputFormat);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.txtOutputFormat);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSavePrintSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Print Setting";
            this.Load += new System.EventHandler(this.frmSavePrintSetting_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPrintSetting)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider epPrintSetting;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblOutputFormat;
        private System.Windows.Forms.TextBox txtOutputFormat;
        private System.Windows.Forms.Label lblMarginLeft;
        private System.Windows.Forms.TextBox txtMarginLeft;
        private System.Windows.Forms.Label lblMarginTop;
        private System.Windows.Forms.TextBox txtMarginTop;
        private System.Windows.Forms.Label lblPageWidth;
        private System.Windows.Forms.TextBox txtPageWidth;
        private System.Windows.Forms.Label lblPageHeight;
        private System.Windows.Forms.TextBox txtPageHeight;
        private System.Windows.Forms.Label lblMarginBottom;
        private System.Windows.Forms.TextBox txtMarginBottom;
        private System.Windows.Forms.Label lblMarginRight;
        private System.Windows.Forms.TextBox txtMarginRight;
    }
}