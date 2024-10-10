namespace School.UI.Report
{
    partial class frmStudentSummaryReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentSummaryReport));
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            this.lblStandard = new System.Windows.Forms.Label();
            this.cbStandard = new System.Windows.Forms.ComboBox();
            this.lblDivision = new System.Windows.Forms.Label();
            this.cbDivision = new System.Windows.Forms.ComboBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnAllStudent = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.rvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.epStudentSummary = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbSearch.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epStudentSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerateReport.BackgroundImage")));
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(371, 19);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(117, 28);
            this.btnGenerateReport.TabIndex = 1;
            this.btnGenerateReport.Text = "&Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
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
            // lblStandard
            // 
            this.lblStandard.AutoSize = true;
            this.lblStandard.ForeColor = System.Drawing.Color.Black;
            this.lblStandard.Location = new System.Drawing.Point(10, 23);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(60, 13);
            this.lblStandard.TabIndex = 182;
            this.lblStandard.Text = "Standard :*";
            // 
            // cbStandard
            // 
            this.cbStandard.BackColor = System.Drawing.SystemColors.Window;
            this.cbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStandard.FormattingEnabled = true;
            this.cbStandard.Location = new System.Drawing.Point(109, 19);
            this.cbStandard.Name = "cbStandard";
            this.cbStandard.Size = new System.Drawing.Size(237, 22);
            this.cbStandard.TabIndex = 181;
            // 
            // lblDivision
            // 
            this.lblDivision.AutoSize = true;
            this.lblDivision.ForeColor = System.Drawing.Color.Black;
            this.lblDivision.Location = new System.Drawing.Point(10, 51);
            this.lblDivision.Name = "lblDivision";
            this.lblDivision.Size = new System.Drawing.Size(54, 13);
            this.lblDivision.TabIndex = 188;
            this.lblDivision.Text = "Division :*";
            // 
            // cbDivision
            // 
            this.cbDivision.BackColor = System.Drawing.SystemColors.Window;
            this.cbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDivision.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDivision.FormattingEnabled = true;
            this.cbDivision.Location = new System.Drawing.Point(109, 47);
            this.cbDivision.Name = "cbDivision";
            this.cbDivision.Size = new System.Drawing.Size(237, 22);
            this.cbDivision.TabIndex = 187;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnAllStudent);
            this.gbSearch.Controls.Add(this.cbDivision);
            this.gbSearch.Controls.Add(this.lblDivision);
            this.gbSearch.Controls.Add(this.cbStandard);
            this.gbSearch.Controls.Add(this.lblStandard);
            this.gbSearch.Controls.Add(this.btnExist);
            this.gbSearch.Controls.Add(this.btnGenerateReport);
            this.gbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(124)))), ((int)(((byte)(151)))));
            this.gbSearch.Location = new System.Drawing.Point(-3, 38);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1049, 83);
            this.gbSearch.TabIndex = 48;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // btnAllStudent
            // 
            this.btnAllStudent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAllStudent.BackgroundImage")));
            this.btnAllStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAllStudent.ForeColor = System.Drawing.Color.White;
            this.btnAllStudent.Location = new System.Drawing.Point(371, 54);
            this.btnAllStudent.Name = "btnAllStudent";
            this.btnAllStudent.Size = new System.Drawing.Size(117, 28);
            this.btnAllStudent.TabIndex = 189;
            this.btnAllStudent.Text = "&All Student Report";
            this.btnAllStudent.UseVisualStyleBackColor = true;
            this.btnAllStudent.Click += new System.EventHandler(this.btnAllStudent_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Student Summary Report";
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
            this.pnlTitle.Size = new System.Drawing.Size(1046, 36);
            this.pnlTitle.TabIndex = 44;
            // 
            // rvReport
            // 
            this.rvReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rvReport.LocalReport.ReportEmbeddedResource = "";
            this.rvReport.Location = new System.Drawing.Point(0, 127);
            this.rvReport.Name = "rvReport";
            this.rvReport.Size = new System.Drawing.Size(1046, 509);
            this.rvReport.TabIndex = 49;
            // 
            // epStudentSummary
            // 
            this.epStudentSummary.ContainerControl = this;
            // 
            // frmStudentSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 636);
            this.Controls.Add(this.rvReport);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.pnlTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudentSummaryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Summary Report";
            this.Load += new System.EventHandler(this.frmStudentSummaryReport_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epStudentSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Label lblStandard;
        public System.Windows.Forms.ComboBox cbStandard;
        private System.Windows.Forms.Label lblDivision;
        public System.Windows.Forms.ComboBox cbDivision;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTitle;
        private Microsoft.Reporting.WinForms.ReportViewer rvReport;
        private System.Windows.Forms.ErrorProvider epStudentSummary;
        private System.Windows.Forms.Button btnAllStudent;
    }
}