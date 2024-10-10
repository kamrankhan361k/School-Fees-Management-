namespace School.UI
{
    partial class frmMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaster));
            this.tsmReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDateWiseFeesReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPendingFeesWiseReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStandardWiseFeesReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReceiptWiseFeesReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmbalanceSheetReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmstudentSummaryReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrintSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUpdateStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tMaster = new System.Windows.Forms.Timer(this.components);
            this.lblOtherFees = new System.Windows.Forms.Label();
            this.lblRegularFees = new System.Windows.Forms.Label();
            this.tvRegularFees = new System.Windows.Forms.TreeView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tlpDateTime = new System.Windows.Forms.TableLayoutPanel();
            this.lblToday = new System.Windows.Forms.Label();
            this.lblTimeNow = new System.Windows.Forms.Label();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.tsmViewReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.tvOtherFees = new System.Windows.Forms.TreeView();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDivision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFeesParticular = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOtherFeesParticular = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmYear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmledgerHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLedger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaymentVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmJournalVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmContraVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOtherReceiptVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOtherReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOtherFees = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tlpDateTime.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmReports
            // 
            this.tsmReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDateWiseFeesReport,
            this.tsmPendingFeesWiseReport,
            this.tsmStandardWiseFeesReport,
            this.tsmReceiptWiseFeesReport,
            this.tsmbalanceSheetReport,
            this.tsmstudentSummaryReport});
            this.tsmReports.Name = "tsmReports";
            this.tsmReports.Size = new System.Drawing.Size(67, 35);
            this.tsmReports.Text = "Reports";
            // 
            // tsmDateWiseFeesReport
            // 
            this.tsmDateWiseFeesReport.Name = "tsmDateWiseFeesReport";
            this.tsmDateWiseFeesReport.Size = new System.Drawing.Size(239, 22);
            this.tsmDateWiseFeesReport.Text = "Date Wise Fees Report";
            this.tsmDateWiseFeesReport.Click += new System.EventHandler(this.tsmDateWiseFeesReport_Click);
            // 
            // tsmPendingFeesWiseReport
            // 
            this.tsmPendingFeesWiseReport.Name = "tsmPendingFeesWiseReport";
            this.tsmPendingFeesWiseReport.Size = new System.Drawing.Size(239, 22);
            this.tsmPendingFeesWiseReport.Text = "Pending Fees Wise Report";
            this.tsmPendingFeesWiseReport.Click += new System.EventHandler(this.tsmPendingFeesWiseReport_Click);
            // 
            // tsmStandardWiseFeesReport
            // 
            this.tsmStandardWiseFeesReport.Name = "tsmStandardWiseFeesReport";
            this.tsmStandardWiseFeesReport.Size = new System.Drawing.Size(239, 22);
            this.tsmStandardWiseFeesReport.Text = "Standard Wise Fees Report";
            this.tsmStandardWiseFeesReport.Click += new System.EventHandler(this.tsmStandardWiseFeesReport_Click);
            // 
            // tsmReceiptWiseFeesReport
            // 
            this.tsmReceiptWiseFeesReport.Name = "tsmReceiptWiseFeesReport";
            this.tsmReceiptWiseFeesReport.Size = new System.Drawing.Size(239, 22);
            this.tsmReceiptWiseFeesReport.Text = "Receipt Wise Fees Report";
            this.tsmReceiptWiseFeesReport.Click += new System.EventHandler(this.tsmReceiptWiseFeesReport_Click);
            // 
            // tsmbalanceSheetReport
            // 
            this.tsmbalanceSheetReport.Name = "tsmbalanceSheetReport";
            this.tsmbalanceSheetReport.Size = new System.Drawing.Size(239, 22);
            this.tsmbalanceSheetReport.Text = "Balance Sheet Report";
            this.tsmbalanceSheetReport.Click += new System.EventHandler(this.tsmbalanceSheetReport_Click);
            // 
            // tsmstudentSummaryReport
            // 
            this.tsmstudentSummaryReport.Name = "tsmstudentSummaryReport";
            this.tsmstudentSummaryReport.Size = new System.Drawing.Size(239, 22);
            this.tsmstudentSummaryReport.Text = "Student Summary Report";
            this.tsmstudentSummaryReport.Click += new System.EventHandler(this.tsmstudentSummaryReport_Click);
            // 
            // tsmPrintSetting
            // 
            this.tsmPrintSetting.Name = "tsmPrintSetting";
            this.tsmPrintSetting.Size = new System.Drawing.Size(95, 35);
            this.tsmPrintSetting.Text = "&Print Setting";
            this.tsmPrintSetting.Click += new System.EventHandler(this.tsmPrintSetting_Click);
            // 
            // tsmUpdateStudent
            // 
            this.tsmUpdateStudent.Name = "tsmUpdateStudent";
            this.tsmUpdateStudent.Size = new System.Drawing.Size(117, 35);
            this.tsmUpdateStudent.Text = "&Update Student";
            this.tsmUpdateStudent.Click += new System.EventHandler(this.tsmUpdateStudent_Click);
            // 
            // tMaster
            // 
            this.tMaster.Enabled = true;
            this.tMaster.Tick += new System.EventHandler(this.tMaster_Tick);
            // 
            // lblOtherFees
            // 
            this.lblOtherFees.AutoSize = true;
            this.lblOtherFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherFees.Location = new System.Drawing.Point(697, 148);
            this.lblOtherFees.Name = "lblOtherFees";
            this.lblOtherFees.Size = new System.Drawing.Size(77, 15);
            this.lblOtherFees.TabIndex = 52;
            this.lblOtherFees.Text = "Other Fees";
            // 
            // lblRegularFees
            // 
            this.lblRegularFees.AutoSize = true;
            this.lblRegularFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegularFees.Location = new System.Drawing.Point(206, 148);
            this.lblRegularFees.Name = "lblRegularFees";
            this.lblRegularFees.Size = new System.Drawing.Size(93, 15);
            this.lblRegularFees.TabIndex = 50;
            this.lblRegularFees.Text = "Regular Fees";
            // 
            // tvRegularFees
            // 
            this.tvRegularFees.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvRegularFees.Location = new System.Drawing.Point(12, 166);
            this.tvRegularFees.Name = "tvRegularFees";
            this.tvRegularFees.Size = new System.Drawing.Size(463, 378);
            this.tvRegularFees.TabIndex = 49;
            this.tvRegularFees.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRegularFees_AfterSelect);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHeader.BackgroundImage")));
            this.pnlHeader.Controls.Add(this.tlpRight);
            this.pnlHeader.Controls.Add(this.pnlLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(986, 91);
            this.pnlHeader.TabIndex = 47;
            // 
            // tlpRight
            // 
            this.tlpRight.BackColor = System.Drawing.Color.Transparent;
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tlpRight.Controls.Add(this.panel4, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlpRight.Location = new System.Drawing.Point(535, 0);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRight.Size = new System.Drawing.Size(451, 91);
            this.tlpRight.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.btnLogOff, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(445, 48);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // btnLogOff
            // 
            this.btnLogOff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogOff.BackgroundImage")));
            this.btnLogOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOff.FlatAppearance.BorderSize = 0;
            this.btnLogOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOff.ForeColor = System.Drawing.Color.White;
            this.btnLogOff.Location = new System.Drawing.Point(355, 0);
            this.btnLogOff.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(71, 30);
            this.btnLogOff.TabIndex = 2;
            this.btnLogOff.Text = "&Log Off";
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.tlpDateTime);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(3, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(445, 31);
            this.panel4.TabIndex = 2;
            // 
            // tlpDateTime
            // 
            this.tlpDateTime.ColumnCount = 3;
            this.tlpDateTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tlpDateTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpDateTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpDateTime.Controls.Add(this.lblToday, 0, 0);
            this.tlpDateTime.Controls.Add(this.lblTimeNow, 2, 0);
            this.tlpDateTime.Controls.Add(this.lblTimeIn, 1, 0);
            this.tlpDateTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpDateTime.Location = new System.Drawing.Point(0, 11);
            this.tlpDateTime.Name = "tlpDateTime";
            this.tlpDateTime.RowCount = 1;
            this.tlpDateTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDateTime.Size = new System.Drawing.Size(445, 20);
            this.tlpDateTime.TabIndex = 3;
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblToday.ForeColor = System.Drawing.Color.White;
            this.lblToday.Location = new System.Drawing.Point(155, 0);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(37, 20);
            this.lblToday.TabIndex = 0;
            this.lblToday.Text = "Today";
            // 
            // lblTimeNow
            // 
            this.lblTimeNow.AutoSize = true;
            this.lblTimeNow.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTimeNow.ForeColor = System.Drawing.Color.White;
            this.lblTimeNow.Location = new System.Drawing.Point(378, 0);
            this.lblTimeNow.Name = "lblTimeNow";
            this.lblTimeNow.Size = new System.Drawing.Size(64, 20);
            this.lblTimeNow.TabIndex = 2;
            this.lblTimeNow.Text = "Time Now : ";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTimeIn.ForeColor = System.Drawing.Color.White;
            this.lblTimeIn.Location = new System.Drawing.Point(265, 0);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(51, 20);
            this.lblTimeIn.TabIndex = 1;
            this.lblTimeIn.Text = "Time In : ";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = global::School.Properties.Resources.Logo;
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLogo.Location = new System.Drawing.Point(3, 3);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(230, 85);
            this.pnlLogo.TabIndex = 0;
            // 
            // tsmViewReceipt
            // 
            this.tsmViewReceipt.Name = "tsmViewReceipt";
            this.tsmViewReceipt.Size = new System.Drawing.Size(97, 35);
            this.tsmViewReceipt.Text = "&View Receipt";
            this.tsmViewReceipt.Click += new System.EventHandler(this.tsmViewReceipt_Click);
            // 
            // tvOtherFees
            // 
            this.tvOtherFees.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvOtherFees.Location = new System.Drawing.Point(503, 166);
            this.tvOtherFees.Name = "tvOtherFees";
            this.tvOtherFees.Size = new System.Drawing.Size(461, 378);
            this.tvOtherFees.TabIndex = 51;
            this.tvOtherFees.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOtherFees_AfterSelect);
            // 
            // msMain
            // 
            this.msMain.AutoSize = false;
            this.msMain.BackColor = System.Drawing.Color.LightBlue;
            this.msMain.Dock = System.Windows.Forms.DockStyle.None;
            this.msMain.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.msMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMaster,
            this.tsmStudent,
            this.tsmAccount,
            this.tsmReceipt,
            this.tsmOtherReceipt,
            this.tsmFees,
            this.tsmViewReceipt,
            this.tsmReports,
            this.tsmPrintSetting,
            this.tsmUpdateStudent});
            this.msMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.msMain.Location = new System.Drawing.Point(0, 91);
            this.msMain.MinimumSize = new System.Drawing.Size(500, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(986, 39);
            this.msMain.TabIndex = 48;
            this.msMain.Text = "msMain";
            // 
            // tsmMaster
            // 
            this.tsmMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStandard,
            this.tsmDivision,
            this.tsmDepartment,
            this.tsmFeesParticular,
            this.tsmOtherFeesParticular,
            this.tsmYear});
            this.tsmMaster.Name = "tsmMaster";
            this.tsmMaster.Size = new System.Drawing.Size(64, 35);
            this.tsmMaster.Text = "&Master";
            // 
            // tsmStandard
            // 
            this.tsmStandard.Name = "tsmStandard";
            this.tsmStandard.Size = new System.Drawing.Size(203, 22);
            this.tsmStandard.Text = "&Standard";
            this.tsmStandard.Click += new System.EventHandler(this.tsmStandard_Click);
            // 
            // tsmDivision
            // 
            this.tsmDivision.Name = "tsmDivision";
            this.tsmDivision.Size = new System.Drawing.Size(203, 22);
            this.tsmDivision.Text = "&Division";
            this.tsmDivision.Click += new System.EventHandler(this.tsmDivision_Click);
            // 
            // tsmDepartment
            // 
            this.tsmDepartment.Name = "tsmDepartment";
            this.tsmDepartment.Size = new System.Drawing.Size(203, 22);
            this.tsmDepartment.Text = "D&epartment";
            this.tsmDepartment.Click += new System.EventHandler(this.tsmDepartment_Click);
            // 
            // tsmFeesParticular
            // 
            this.tsmFeesParticular.Name = "tsmFeesParticular";
            this.tsmFeesParticular.Size = new System.Drawing.Size(203, 22);
            this.tsmFeesParticular.Text = "&Fees Particular";
            this.tsmFeesParticular.Click += new System.EventHandler(this.tsmFeesParticular_Click);
            // 
            // tsmOtherFeesParticular
            // 
            this.tsmOtherFeesParticular.Name = "tsmOtherFeesParticular";
            this.tsmOtherFeesParticular.Size = new System.Drawing.Size(203, 22);
            this.tsmOtherFeesParticular.Text = "&Other Fees Particular";
            this.tsmOtherFeesParticular.Click += new System.EventHandler(this.tsmOtherFeesParticular_Click);
            // 
            // tsmYear
            // 
            this.tsmYear.Name = "tsmYear";
            this.tsmYear.Size = new System.Drawing.Size(203, 22);
            this.tsmYear.Text = "&Year";
            this.tsmYear.Click += new System.EventHandler(this.tsmYear_Click);
            // 
            // tsmStudent
            // 
            this.tsmStudent.Name = "tsmStudent";
            this.tsmStudent.Size = new System.Drawing.Size(68, 35);
            this.tsmStudent.Text = "&Student";
            this.tsmStudent.Click += new System.EventHandler(this.tsmStudent_Click);
            // 
            // tsmAccount
            // 
            this.tsmAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmledgerHeader,
            this.tsmLedger,
            this.tsmPaymentVoucher,
            this.tsmJournalVoucher,
            this.tsmContraVoucher,
            this.tsmOtherReceiptVoucher});
            this.tsmAccount.Name = "tsmAccount";
            this.tsmAccount.Size = new System.Drawing.Size(70, 35);
            this.tsmAccount.Text = "&Account";
            // 
            // tsmledgerHeader
            // 
            this.tsmledgerHeader.Name = "tsmledgerHeader";
            this.tsmledgerHeader.Size = new System.Drawing.Size(211, 22);
            this.tsmledgerHeader.Text = "Ledger Header";
            this.tsmledgerHeader.Click += new System.EventHandler(this.tsmledgerHeader_Click);
            // 
            // tsmLedger
            // 
            this.tsmLedger.Name = "tsmLedger";
            this.tsmLedger.Size = new System.Drawing.Size(211, 22);
            this.tsmLedger.Text = "Ledger";
            this.tsmLedger.Click += new System.EventHandler(this.tsmLedger_Click);
            // 
            // tsmPaymentVoucher
            // 
            this.tsmPaymentVoucher.Name = "tsmPaymentVoucher";
            this.tsmPaymentVoucher.Size = new System.Drawing.Size(211, 22);
            this.tsmPaymentVoucher.Text = "&Payment Voucher";
            this.tsmPaymentVoucher.Click += new System.EventHandler(this.tsmPaymentVoucher_Click);
            // 
            // tsmJournalVoucher
            // 
            this.tsmJournalVoucher.Name = "tsmJournalVoucher";
            this.tsmJournalVoucher.Size = new System.Drawing.Size(211, 22);
            this.tsmJournalVoucher.Text = "&Journal Voucher";
            this.tsmJournalVoucher.Click += new System.EventHandler(this.tsmJournalVoucher_Click);
            // 
            // tsmContraVoucher
            // 
            this.tsmContraVoucher.Name = "tsmContraVoucher";
            this.tsmContraVoucher.Size = new System.Drawing.Size(211, 22);
            this.tsmContraVoucher.Text = "&Contra Voucher";
            this.tsmContraVoucher.Click += new System.EventHandler(this.tsmContraVoucher_Click);
            // 
            // tsmOtherReceiptVoucher
            // 
            this.tsmOtherReceiptVoucher.Name = "tsmOtherReceiptVoucher";
            this.tsmOtherReceiptVoucher.Size = new System.Drawing.Size(211, 22);
            this.tsmOtherReceiptVoucher.Text = "&Other Receipt Voucher";
            this.tsmOtherReceiptVoucher.Click += new System.EventHandler(this.tsmOtherReceiptVoucher_Click);
            // 
            // tsmReceipt
            // 
            this.tsmReceipt.Name = "tsmReceipt";
            this.tsmReceipt.Size = new System.Drawing.Size(64, 35);
            this.tsmReceipt.Text = "&Receipt";
            this.tsmReceipt.Click += new System.EventHandler(this.tsmReceipt_Click);
            // 
            // tsmOtherReceipt
            // 
            this.tsmOtherReceipt.Name = "tsmOtherReceipt";
            this.tsmOtherReceipt.Size = new System.Drawing.Size(102, 35);
            this.tsmOtherReceipt.Text = "&Other Receipt";
            this.tsmOtherReceipt.Click += new System.EventHandler(this.tsmOtherReceipt_Click);
            // 
            // tsmFees
            // 
            this.tsmFees.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFees,
            this.tsmOtherFees});
            this.tsmFees.Name = "tsmFees";
            this.tsmFees.Size = new System.Drawing.Size(47, 35);
            this.tsmFees.Text = "&Fees";
            // 
            // tsmiFees
            // 
            this.tsmiFees.Name = "tsmiFees";
            this.tsmiFees.Size = new System.Drawing.Size(152, 22);
            this.tsmiFees.Text = "&Fees";
            this.tsmiFees.Click += new System.EventHandler(this.tsmiFees_Click);
            // 
            // tsmOtherFees
            // 
            this.tsmOtherFees.Name = "tsmOtherFees";
            this.tsmOtherFees.Size = new System.Drawing.Size(152, 22);
            this.tsmOtherFees.Text = "&Other Fees";
            this.tsmOtherFees.Click += new System.EventHandler(this.tsmOtherFees_Click);
            // 
            // frmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 546);
            this.Controls.Add(this.lblOtherFees);
            this.Controls.Add(this.lblRegularFees);
            this.Controls.Add(this.tvRegularFees);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tvOtherFees);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMaster";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaster_FormClosing);
            this.Load += new System.EventHandler(this.frmMaster_Load);
            this.pnlHeader.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tlpDateTime.ResumeLayout(false);
            this.tlpDateTime.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmReports;
        private System.Windows.Forms.ToolStripMenuItem tsmDateWiseFeesReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPendingFeesWiseReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStandardWiseFeesReport;
        private System.Windows.Forms.ToolStripMenuItem tsmReceiptWiseFeesReport;
        private System.Windows.Forms.ToolStripMenuItem tsmbalanceSheetReport;
        private System.Windows.Forms.ToolStripMenuItem tsmstudentSummaryReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPrintSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdateStudent;
        private System.Windows.Forms.Timer tMaster;
        private System.Windows.Forms.Label lblOtherFees;
        private System.Windows.Forms.Label lblRegularFees;
        public System.Windows.Forms.TreeView tvRegularFees;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnLogOff;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tlpDateTime;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.Label lblTimeNow;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.ToolStripMenuItem tsmViewReceipt;
        public System.Windows.Forms.TreeView tvOtherFees;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmMaster;
        private System.Windows.Forms.ToolStripMenuItem tsmStandard;
        private System.Windows.Forms.ToolStripMenuItem tsmDivision;
        private System.Windows.Forms.ToolStripMenuItem tsmDepartment;
        private System.Windows.Forms.ToolStripMenuItem tsmFeesParticular;
        private System.Windows.Forms.ToolStripMenuItem tsmOtherFeesParticular;
        private System.Windows.Forms.ToolStripMenuItem tsmYear;
        private System.Windows.Forms.ToolStripMenuItem tsmStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmledgerHeader;
        private System.Windows.Forms.ToolStripMenuItem tsmLedger;
        private System.Windows.Forms.ToolStripMenuItem tsmPaymentVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmJournalVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmContraVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmOtherReceiptVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmReceipt;
        private System.Windows.Forms.ToolStripMenuItem tsmOtherReceipt;
        private System.Windows.Forms.ToolStripMenuItem tsmFees;
        private System.Windows.Forms.ToolStripMenuItem tsmiFees;
        private System.Windows.Forms.ToolStripMenuItem tsmOtherFees;
    }
}