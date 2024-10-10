namespace School.UI.Report
{
    partial class frmReceiptWiseFeesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceiptWiseFeesReport));
            this.rvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.lblFeesType = new System.Windows.Forms.Label();
            this.rbtnOther = new System.Windows.Forms.RadioButton();
            this.rbtnRegular = new System.Windows.Forms.RadioButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // rvReport
            // 
            this.rvReport.LocalReport.ReportEmbeddedResource = "";
            this.rvReport.Location = new System.Drawing.Point(1, 95);
            this.rvReport.Name = "rvReport";
            this.rvReport.Size = new System.Drawing.Size(1052, 519);
            this.rvReport.TabIndex = 0;
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
            this.pnlTitle.Size = new System.Drawing.Size(1055, 36);
            this.pnlTitle.TabIndex = 43;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Receipt Wise Fees Report";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.lblFeesType);
            this.gbSearch.Controls.Add(this.rbtnOther);
            this.gbSearch.Controls.Add(this.rbtnRegular);
            this.gbSearch.Controls.Add(this.dtpTo);
            this.gbSearch.Controls.Add(this.lblTo);
            this.gbSearch.Controls.Add(this.dtpFrom);
            this.gbSearch.Controls.Add(this.btnExist);
            this.gbSearch.Controls.Add(this.btnGenerateReport);
            this.gbSearch.Controls.Add(this.lblFrom);
            this.gbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(124)))), ((int)(((byte)(151)))));
            this.gbSearch.Location = new System.Drawing.Point(1, 39);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1052, 50);
            this.gbSearch.TabIndex = 46;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // lblFeesType
            // 
            this.lblFeesType.AutoSize = true;
            this.lblFeesType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeesType.ForeColor = System.Drawing.Color.Black;
            this.lblFeesType.Location = new System.Drawing.Point(466, 21);
            this.lblFeesType.Name = "lblFeesType";
            this.lblFeesType.Size = new System.Drawing.Size(80, 15);
            this.lblFeesType.TabIndex = 42;
            this.lblFeesType.Text = "Fees Type :";
            // 
            // rbtnOther
            // 
            this.rbtnOther.AutoSize = true;
            this.rbtnOther.ForeColor = System.Drawing.Color.Black;
            this.rbtnOther.Location = new System.Drawing.Point(647, 19);
            this.rbtnOther.Name = "rbtnOther";
            this.rbtnOther.Size = new System.Drawing.Size(55, 19);
            this.rbtnOther.TabIndex = 41;
            this.rbtnOther.Text = "Other";
            this.rbtnOther.UseVisualStyleBackColor = true;
            // 
            // rbtnRegular
            // 
            this.rbtnRegular.AutoSize = true;
            this.rbtnRegular.Checked = true;
            this.rbtnRegular.ForeColor = System.Drawing.Color.Black;
            this.rbtnRegular.Location = new System.Drawing.Point(556, 19);
            this.rbtnRegular.Name = "rbtnRegular";
            this.rbtnRegular.Size = new System.Drawing.Size(69, 19);
            this.rbtnRegular.TabIndex = 40;
            this.rbtnRegular.TabStop = true;
            this.rbtnRegular.Text = "Regular";
            this.rbtnRegular.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(254, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(117, 22);
            this.dtpTo.TabIndex = 39;
            this.dtpTo.Value = new System.DateTime(2000, 1, 8, 0, 0, 0, 0);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.ForeColor = System.Drawing.Color.Black;
            this.lblTo.Location = new System.Drawing.Point(221, 21);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(27, 15);
            this.lblTo.TabIndex = 38;
            this.lblTo.Text = "To :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(63, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(117, 22);
            this.dtpFrom.TabIndex = 37;
            this.dtpFrom.Value = new System.DateTime(2000, 1, 8, 0, 0, 0, 0);
            // 
            // btnExist
            // 
            this.btnExist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExist.BackgroundImage")));
            this.btnExist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExist.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExist.ForeColor = System.Drawing.Color.White;
            this.btnExist.Location = new System.Drawing.Point(967, 14);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 28);
            this.btnExist.TabIndex = 36;
            this.btnExist.Text = "&Exit";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerateReport.BackgroundImage")));
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(831, 14);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(117, 28);
            this.btnGenerateReport.TabIndex = 1;
            this.btnGenerateReport.Text = "&Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.ForeColor = System.Drawing.Color.Black;
            this.lblFrom.Location = new System.Drawing.Point(15, 21);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(42, 15);
            this.lblFrom.TabIndex = 35;
            this.lblFrom.Text = "From :";
            // 
            // frmReceiptWiseFeesReport
            // 
            this.AcceptButton = this.btnGenerateReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExist;
            this.ClientSize = new System.Drawing.Size(1055, 615);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.rvReport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReceiptWiseFeesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt Wise Fees Report";
            this.Load += new System.EventHandler(this.frmReceiptWiseFeesReport_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReport;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFeesType;
        private System.Windows.Forms.RadioButton rbtnOther;
        private System.Windows.Forms.RadioButton rbtnRegular;
    }
}