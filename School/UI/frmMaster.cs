using School.Common;
using School.DataAccess;
using School.DataModel;
using School.UI.Account.Contra;
using School.UI.Account.Journal;
using School.UI.Account.Ledger;
using School.UI.Account.LedgerHeader;
using School.UI.Account.Other;
using School.UI.Account.Payment;
using School.UI.CollectFees;
using School.UI.Department;
using School.UI.Division;
using School.UI.Fees;
using School.UI.PrintSetting;
using School.UI.Report;
using School.UI.Standard;
using School.UI.Student;
using School.UI.Year;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI
{
    public partial class frmMaster : Form
    {
        #region Variables

        private List<TreeList> _ListOfTreeList = null;
        private List<TreeList> _ListOfOtherTreeList = null;
        bool _IsExist = true;

        #endregion


        #region Page events and constructor

        public frmMaster()
        {
            InitializeComponent();
        }

        private void frmMaster_Load(object sender, EventArgs e)
        {
            SetInitialControl();
            CheckUpdateStudent();
        }

        private void frmMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.UserId = string.Empty;
            Properties.Settings.Default.YearId = string.Empty;
            Properties.Settings.Default.Year = string.Empty;
            Properties.Settings.Default.UserName = string.Empty;

            if (_IsExist)
            {
                if (MessageBox.Show(Messages.ExitMsg, Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.ExitThread();
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion


        #region Button Events

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.LogoffMsg, Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LogOff();
            }
        }

        private void tMaster_Tick(object sender, EventArgs e)
        {
            lblTimeNow.Text = "Time Now: " + System.DateTime.Now.ToString("T");
        }

        #endregion


        #region Menu item click events

        private void tsmStandard_Click(object sender, EventArgs e)
        {
            frmStandard _frmStandard = (frmStandard)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmStandard").FirstOrDefault();
            if (_frmStandard != null)
            {
                _frmStandard.Focus();
            }
            else
            {
                _frmStandard = new frmStandard();
                _frmStandard.Show();
                _frmStandard.Focus();
            }
        }

        private void tsmDivision_Click(object sender, EventArgs e)
        {
            frmDivision _frmDivision = (frmDivision)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmDivision").FirstOrDefault();
            if (_frmDivision != null)
            {
                _frmDivision.Focus();
            }
            else
            {
                _frmDivision = new frmDivision();
                _frmDivision.Show();
                _frmDivision.Focus();
            }
        }

        private void tsmDepartment_Click(object sender, EventArgs e)
        {
            frmDepartment _frmDepartment = (frmDepartment)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmDepartment").FirstOrDefault();
            if (_frmDepartment != null)
            {
                _frmDepartment.Focus();
            }
            else
            {
                _frmDepartment = new frmDepartment();
                _frmDepartment.Show();
                _frmDepartment.Focus();
            }
        }

        private void tsmFeesParticular_Click(object sender, EventArgs e)
        {
            frmFees _frmFees = (frmFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmFees").FirstOrDefault();
            if (_frmFees != null)
            {
                _frmFees.Focus();
            }
            else
            {
                _frmFees = new frmFees(false);
                _frmFees.Show();
                _frmFees.Focus();
            }
        }

        private void tsmOtherFeesParticular_Click(object sender, EventArgs e)
        {
            frmFees _frmFees = (frmFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmFees").FirstOrDefault();
            if (_frmFees != null)
            {
                _frmFees.Focus();
            }
            else
            {
                _frmFees = new frmFees(true);
                _frmFees.Show();
                _frmFees.Focus();
            }
        }

        private void tsmYear_Click(object sender, EventArgs e)
        {
            frmYear _frmYear = (frmYear)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmYear").FirstOrDefault();
            if (_frmYear != null)
            {
                _frmYear.Focus();
            }
            else
            {
                _frmYear = new frmYear();
                _frmYear.Show();
                _frmYear.Focus();
            }
        }

        private void tsmStudent_Click(object sender, EventArgs e)
        {
            frmStudent _frmStudent = (frmStudent)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmStudent").FirstOrDefault();
            if (_frmStudent != null)
            {
                _frmStudent.Focus();
            }
            else
            {
                _frmStudent = new frmStudent();
                _frmStudent.Show();
                _frmStudent.Focus();
            }
        }

        private void tsmiFees_Click(object sender, EventArgs e)
        {
            frmCollectFees _frmCollectFees = (frmCollectFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmCollectFees").FirstOrDefault();
            if (_frmCollectFees != null)
            {
                _frmCollectFees.Focus();
            }
            else
            {
                _frmCollectFees = new frmCollectFees(false);
                _frmCollectFees.Show();
                _frmCollectFees.Focus();
            }
        }

        private void tsmOtherFees_Click(object sender, EventArgs e)
        {
            frmCollectFees _frmCollectFees = (frmCollectFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmCollectFees").FirstOrDefault();
            if (_frmCollectFees != null)
            {
                _frmCollectFees.Focus();
            }
            else
            {
                _frmCollectFees = new frmCollectFees(true);
                _frmCollectFees.Show();
                _frmCollectFees.Focus();
            }
        }

        private void tsmPrintSetting_Click(object sender, EventArgs e)
        {
            frmSavePrintSetting _frmSavePrintSetting = (frmSavePrintSetting)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSavePrintSetting").FirstOrDefault();
            if (_frmSavePrintSetting != null)
            {
                _frmSavePrintSetting.Focus();
            }
            else
            {
                _frmSavePrintSetting = new frmSavePrintSetting();
                _frmSavePrintSetting.Show();
                _frmSavePrintSetting.Focus();
            }

            //frmReport _frmReport = (frmReport)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmReport").FirstOrDefault();
            //if (_frmReport != null)
            //{
            //    _frmReport.Focus();
            //}
            //else
            //{
            //    _frmReport = new frmReport();
            //    _frmReport.Show();
            //    _frmReport.Focus();
            //}
        }

        private void tsmReceipt_Click(object sender, EventArgs e)
        {
            frmSaveCollectFees _frmSaveCollectFees = (frmSaveCollectFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveCollectFees").FirstOrDefault();
            if (_frmSaveCollectFees != null)
            {
                _frmSaveCollectFees.Focus();
            }
            else
            {
                _frmSaveCollectFees = new frmSaveCollectFees(false, 0, 0, 0, 0);
                _frmSaveCollectFees.Show();
                _frmSaveCollectFees.Focus();
            }
        }

        private void tsmOtherReceipt_Click(object sender, EventArgs e)
        {
            frmSaveCollectFees _frmSaveCollectFees = (frmSaveCollectFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveCollectFees").FirstOrDefault();
            if (_frmSaveCollectFees != null)
            {
                _frmSaveCollectFees.Focus();
            }
            else
            {
                _frmSaveCollectFees = new frmSaveCollectFees(true, 0, 0, 0, 0);
                _frmSaveCollectFees.Show();
                _frmSaveCollectFees.Focus();
            }
        }

        private void tsmViewReceipt_Click(object sender, EventArgs e)
        {
            frmViewReceipt _frmViewReceipt = (frmViewReceipt)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmViewReceipt").FirstOrDefault();
            if (_frmViewReceipt != null)
            {
                _frmViewReceipt.Focus();
            }
            else
            {
                _frmViewReceipt = new frmViewReceipt();
                _frmViewReceipt.Show();
                _frmViewReceipt.Focus();
            }
        }

        private void tsmDateWiseFeesReport_Click(object sender, EventArgs e)
        {
            frmDateWiseFeesReport _frmDateWiseFeesReport = (frmDateWiseFeesReport)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmDateWiseFeesReport").FirstOrDefault();
            if (_frmDateWiseFeesReport != null)
            {
                _frmDateWiseFeesReport.Focus();
            }
            else
            {
                _frmDateWiseFeesReport = new frmDateWiseFeesReport();
                _frmDateWiseFeesReport.Show();
                _frmDateWiseFeesReport.Focus();
            }
        }

        private void tsmPendingFeesWiseReport_Click(object sender, EventArgs e)
        {
            frmPendingFeesReport _frmPendingFeesReport = (frmPendingFeesReport)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmPendingFeesReport").FirstOrDefault();
            if (_frmPendingFeesReport != null)
            {
                _frmPendingFeesReport.Focus();
            }
            else
            {
                _frmPendingFeesReport = new frmPendingFeesReport();
                _frmPendingFeesReport.Show();
                _frmPendingFeesReport.Focus();
            }
        }

        private void tsmStandardWiseFeesReport_Click(object sender, EventArgs e)
        {
            frmStandardWiseFeesReport _frmStandardWiseFeesReport = (frmStandardWiseFeesReport)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmStandardWiseFeesReport").FirstOrDefault();
            if (_frmStandardWiseFeesReport != null)
            {
                _frmStandardWiseFeesReport.Focus();
            }
            else
            {
                _frmStandardWiseFeesReport = new frmStandardWiseFeesReport();
                _frmStandardWiseFeesReport.Show();
                _frmStandardWiseFeesReport.Focus();
            }
        }

        private void tsmReceiptWiseFeesReport_Click(object sender, EventArgs e)
        {
            frmReceiptWiseFeesReport _frmReceiptWiseFeesReport = (frmReceiptWiseFeesReport)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmReceiptWiseFeesReport").FirstOrDefault();
            if (_frmReceiptWiseFeesReport != null)
            {
                _frmReceiptWiseFeesReport.Focus();
            }
            else
            {
                _frmReceiptWiseFeesReport = new frmReceiptWiseFeesReport();
                _frmReceiptWiseFeesReport.Show();
                _frmReceiptWiseFeesReport.Focus();
            }
        }

        private void tsmPaymentVoucher_Click(object sender, EventArgs e)
        {
            frmPayment _frmPayment = (frmPayment)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmPayment").FirstOrDefault();
            if (_frmPayment != null)
            {

                _frmPayment.Focus();
            }
            else
            {
                _frmPayment = new frmPayment();
                _frmPayment.Show();
                _frmPayment.Focus();
            }
        }

        private void tsmJournalVoucher_Click(object sender, EventArgs e)
        {
            frmJournal _frmJournal = (frmJournal)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmJournal").FirstOrDefault();
            if (_frmJournal != null)
            {
                _frmJournal.Focus();
            }
            else
            {
                _frmJournal = new frmJournal();
                _frmJournal.Show();
                _frmJournal.Focus();
            }
        }

        private void tsmContraVoucher_Click(object sender, EventArgs e)
        {
            frmContra _frmContra = (frmContra)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmContra").FirstOrDefault();
            if (_frmContra != null)
            {
                _frmContra.Focus();
            }
            else
            {
                _frmContra = new frmContra();
                _frmContra.Show();
                _frmContra.Focus();
            }
        }

        private void tsmLedger_Click(object sender, EventArgs e)
        {
            frmLedger _frmLedger = (frmLedger)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmLedger").FirstOrDefault();
            if (_frmLedger != null)
            {
                _frmLedger.Focus();
            }
            else
            {
                _frmLedger = new frmLedger();
                _frmLedger.Show();
                _frmLedger.Focus();
            }
        }

        private void tsmOtherReceiptVoucher_Click(object sender, EventArgs e)
        {
            frmOther _frmOther = (frmOther)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmOther").FirstOrDefault();
            if (_frmOther != null)
            {
                _frmOther.Focus();
            }
            else
            {
                _frmOther = new frmOther();
                _frmOther.Show();
                _frmOther.Focus();
            }
        }

        private void tsmledgerHeader_Click(object sender, EventArgs e)
        {
            frmLedgerHeader _frmLedgerHeader = (frmLedgerHeader)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmLedgerHeader").FirstOrDefault();
            if (_frmLedgerHeader != null)
            {
                _frmLedgerHeader.Focus();
            }
            else
            {
                _frmLedgerHeader = new frmLedgerHeader();
                _frmLedgerHeader.Show();
                _frmLedgerHeader.Focus();
            }
        }

        private void tsmbalanceSheetReport_Click(object sender, EventArgs e)
        {
            frmBalanceSheet _frmBalanceSheet = (frmBalanceSheet)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmBalanceSheet").FirstOrDefault();
            if (_frmBalanceSheet != null)
            {
                _frmBalanceSheet.Focus();
            }
            else
            {
                _frmBalanceSheet = new frmBalanceSheet();
                _frmBalanceSheet.Show();
                _frmBalanceSheet.Focus();
            }
        }

        private void tsmstudentSummaryReport_Click(object sender, EventArgs e)
        {
            frmStudentSummaryReport _frmStudentSummaryReport = (frmStudentSummaryReport)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmStudentSummaryReport").FirstOrDefault();
            if (_frmStudentSummaryReport != null)
            {
                _frmStudentSummaryReport.Focus();
            }
            else
            {
                _frmStudentSummaryReport = new frmStudentSummaryReport();
                _frmStudentSummaryReport.Show();
                _frmStudentSummaryReport.Focus();
            }
        }

        private void tsmUpdateStudent_Click(object sender, EventArgs e)
        {
            frmUpdateStudent _frmUpdateStudent = (frmUpdateStudent)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmUpdateStudent").FirstOrDefault();
            if (_frmUpdateStudent != null)
            {
                _frmUpdateStudent.Focus();
            }
            else
            {
                _frmUpdateStudent = new frmUpdateStudent();
                _frmUpdateStudent.Show();
                _frmUpdateStudent.Focus();
            }
        }

        #endregion


        #region Private Methods

        private void SetInitialControl()
        {
            lblToday.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            lblTimeIn.Text = "Time In: " + DateTime.Now.ToLongTimeString();
        }

        public void LogOff()
        {
            _IsExist = false;

            Form[] _ListOfForm = Application.OpenForms.Cast<Form>().Where(q => q.Name != "frmLogin").ToArray();
            foreach (Form _Form in _ListOfForm)
            {
                _Form.Close();
                _Form.Dispose();
            }

            int cnt = Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmLogin").Count();
            if (cnt == 0)
            {
                frmLogin _frmLogin = new frmLogin();
                _frmLogin.BringToFront();
                _frmLogin.ShowDialog();
                _frmLogin.Focus();
            }
            else
            {
                frmLogin _frmLogin = (frmLogin)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmLogin").FirstOrDefault();
                _frmLogin.Show();
                _frmLogin.Focus();
            }
        }

        private void FillRegularFeesDetailDataTable()
        {
            CollectFeesService _CollectFeesService = new CollectFeesService();

            Result<List<TreeList>> _Result = _CollectFeesService.GetCollectFeesDetail(Convert.ToString(Properties.Settings.Default.Year), false);

            if (_Result.IsSuccess)
            {
                _ListOfTreeList = _Result.Data;
            }
        }

        private void FillRegularFeesTree()
        {
            this.Cursor = Cursors.WaitCursor;

            tvRegularFees.Nodes.Clear();

            if (_ListOfTreeList != null)
            {
                List<TreeList> _Root = _ListOfTreeList.Where(m => m.ParentId == string.Empty).ToList();
                if (_Root != null)
                {
                    foreach (TreeList _TreeList in _Root)
                    {
                        TreeNode _TreeNode = new TreeNode();
                        _TreeNode.Text = _TreeList.TreeText;
                        _TreeNode.Name = _TreeList.ChildId.ToString();

                        if (_TreeNode.Text.Contains("= 0"))
                        {
                            _TreeNode.ForeColor = System.Drawing.Color.Green;
                        }

                        tvRegularFees.Nodes.Add(_TreeNode);

                        FillChildNodeRegularTree(ref _TreeNode, _TreeList.ChildId);
                    }

                    tvRegularFees.Select();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void FillChildNodeRegularTree(ref TreeNode p_TreeNode, string p_ParentId)
        {
            List<TreeList> _Childs = _ListOfTreeList.Where(m => m.ParentId == p_ParentId).ToList();
            if (_Childs != null)
            {
                foreach (TreeList _TreeList in _Childs)
                {
                    TreeNode _TreeNode = new TreeNode();
                    _TreeNode.Text = _TreeList.TreeText;
                    _TreeNode.Name = _TreeList.ChildId.ToString();

                    if (_TreeNode.Text.Contains("= 0"))
                    {
                        _TreeNode.ForeColor = System.Drawing.Color.Green;
                    }

                    p_TreeNode.Nodes.Add(_TreeNode);

                    FillChildNodeRegularTree(ref _TreeNode, _TreeList.ChildId);
                }
            }
        }

        private void FillOtherFeesDetailDataTable()
        {
            CollectFeesService _CollectFeesService = new CollectFeesService();

            Result<List<TreeList>> _Result = _CollectFeesService.GetCollectFeesDetail(Convert.ToString(Properties.Settings.Default.Year), true);

            if (_Result.IsSuccess)
            {
                _ListOfOtherTreeList = _Result.Data;
            }
        }

        private void FillOtherFeesTree()
        {
            this.Cursor = Cursors.WaitCursor;

            tvOtherFees.Nodes.Clear();

            if (_ListOfOtherTreeList != null)
            {
                List<TreeList> _Root = _ListOfOtherTreeList.Where(m => m.ParentId == string.Empty).ToList();

                if (_Root != null)
                {
                    foreach (TreeList _TreeList in _Root)
                    {
                        TreeNode _TreeNode = new TreeNode();
                        _TreeNode.Text = _TreeList.TreeText;
                        _TreeNode.Name = _TreeList.ChildId.ToString();

                        if (_TreeNode.Text.Contains("= 0"))
                        {
                            _TreeNode.ForeColor = System.Drawing.Color.Green;
                        }

                        tvOtherFees.Nodes.Add(_TreeNode);

                        FillChildNodeOtherTree(ref _TreeNode, _TreeList.ChildId);
                    }

                    tvOtherFees.Select();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void FillChildNodeOtherTree(ref TreeNode p_TreeNode, string p_ParentId)
        {
            List<TreeList> _Childs = _ListOfOtherTreeList.Where(m => m.ParentId == p_ParentId).ToList();
            if (_Childs != null)
            {
                foreach (TreeList _TreeList in _Childs)
                {
                    TreeNode _TreeNode = new TreeNode();
                    _TreeNode.Text = _TreeList.TreeText;
                    _TreeNode.Name = _TreeList.ChildId.ToString();

                    if (_TreeNode.Text.Contains("= 0"))
                    {
                        _TreeNode.ForeColor = System.Drawing.Color.Green;
                    }

                    p_TreeNode.Nodes.Add(_TreeNode);

                    FillChildNodeOtherTree(ref _TreeNode, _TreeList.ChildId);
                }
            }
        }

        public void UpdateDashBoardDetail()
        {
            FillRegularFeesDetailDataTable();
            FillRegularFeesTree();

            FillOtherFeesDetailDataTable();
            FillOtherFeesTree();
        }

        private void OpenSaveCollectFees(int p_StudentId, bool p_IsOtherFees)
        {
            frmSaveCollectFees _frmSaveCollectFees = (frmSaveCollectFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveCollectFees").FirstOrDefault();
            if (_frmSaveCollectFees != null)
            {
                _frmSaveCollectFees.Focus();
            }
            else
            {
                StudentService _StudentService = new StudentService();

                Result<StudentMaster> _Result = _StudentService.GetStudentById(p_StudentId, Convert.ToString(Properties.Settings.Default.Year));

                if (_Result.IsSuccess)
                {
                    _frmSaveCollectFees = new frmSaveCollectFees(p_IsOtherFees, _Result.Data.StandardId, _Result.Data.DivisionId, _Result.Data.DepartmentId, p_StudentId);
                    _frmSaveCollectFees.Focus();
                    _frmSaveCollectFees.ShowDialog();
                }
            }
        }

        #endregion

        private void tvRegularFees_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string _StudentId = tvRegularFees.SelectedNode.Name;

            if (_StudentId.Length < 15)
            {
                OpenSaveCollectFees(Convert.ToInt32(_StudentId), false);
            }
        }

        private void tvOtherFees_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string _StudentId = tvOtherFees.SelectedNode.Name;

            if (_StudentId.Length < 15)
            {
                OpenSaveCollectFees(Convert.ToInt32(_StudentId), true);
            }
        }

        public void CheckUpdateStudent()
        {
            tsmUpdateStudent.Visible = true;
            lblRegularFees.Visible = lblOtherFees.Visible = tvRegularFees.Visible = tvOtherFees.Visible = false;
            tsmMaster.Visible = tsmStudent.Visible = tsmAccount.Visible = tsmReceipt.Visible = tsmOtherReceipt.Visible = false;
            tsmFees.Visible = tsmViewReceipt.Visible = tsmReports.Visible = tsmPrintSetting.Visible = false;

            StudentService _StudentService = new StudentService();

            Result<bool> _Result = _StudentService.CheckUpdateStudent(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                if (!_Result.Data)
                {
                    tsmUpdateStudent.Visible = false;
                    lblRegularFees.Visible = lblOtherFees.Visible = tvRegularFees.Visible = tvOtherFees.Visible = true;
                    tsmMaster.Visible = tsmStudent.Visible = tsmReceipt.Visible = tsmOtherReceipt.Visible = true;
                    tsmFees.Visible = tsmViewReceipt.Visible = tsmReports.Visible = tsmPrintSetting.Visible = true;

                    FillRegularFeesDetailDataTable();
                    FillRegularFeesTree();

                    FillOtherFeesDetailDataTable();
                    FillOtherFeesTree();
                }
            }
        }
    }
}
