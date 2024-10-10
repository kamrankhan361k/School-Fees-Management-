using School.Common;
using School.DataAccess;
using School.DataModel;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace School.UI.Report
{
    public partial class frmStudentSummaryReport : Form
    {
        #region Variables

        private ReportService _ReportService = new ReportService();
        private StandardService _StandardService = new StandardService();
        private DivisionService _DivisionService = new DivisionService();
        private Control _Control = null;
        private string _Message = "";

        #endregion

        #region Page events and constructor

        public frmStudentSummaryReport()
        {
            InitializeComponent();
        }

        private void frmStudentSummaryReport_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillStandard();
            FillDivision();

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Button Events

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAllStudent_Click(object sender, EventArgs e)
        {
            ProcessReport(true);
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            ProcessReport(false);           
        }

        #endregion

        #region Private Methods

        private void ProcessReport(bool p_All)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;               

                if (p_All || ValidateControl())
                {
                    Result<DataTable> _Result = _ReportService.GetStudentSummaryData(Convert.ToString(Properties.Settings.Default.Year), cbStandard.SelectedValue.ToString(), cbDivision.SelectedValue.ToString(), p_All);

                    if (_Result.IsSuccess)
                    {
                        int Girls_General_Count = _Result.Data.AsEnumerable().Where(a => (bool)a["Gender"] == false && a["Category"].ToString() == "General").Count();
                        int Boys_General_Count = _Result.Data.AsEnumerable().Where(a => (bool)a["Gender"] == true && a["Category"].ToString() == "General").Count();
                        int General_Count = Girls_General_Count + Boys_General_Count;

                        int Girls_OBC_Count = _Result.Data.AsEnumerable().Where(a => (bool)a["Gender"] == false && a["Category"].ToString() == "O.B.C.").Count();
                        int Boys_OBC_Count = _Result.Data.AsEnumerable().Where(a => (bool)a["Gender"] == true && a["Category"].ToString() == "O.B.C.").Count();
                        int OBC_Count = Girls_OBC_Count + Boys_OBC_Count;

                        int Girls_SC_Count = _Result.Data.AsEnumerable().Where(a => (bool)a["Gender"] == false && a["Category"].ToString() == "S.C.").Count();
                        int Boys_SC_Count = _Result.Data.AsEnumerable().Where(a => (bool)a["Gender"] == true && a["Category"].ToString() == "S.C.").Count();
                        int SC_Count = Girls_SC_Count + Boys_SC_Count;

                        int Girls_ST_Count = _Result.Data.AsEnumerable().Where(a => (bool)a["Gender"] == false && a["Category"].ToString() == "S.T.").Count();
                        int Boys_ST_Count = _Result.Data.AsEnumerable().Where(a => (bool)a["Gender"] == true && a["Category"].ToString() == "S.T.").Count();
                        int ST_Count = Girls_ST_Count + Boys_ST_Count;

                        int Girls_Count = Girls_General_Count + Girls_OBC_Count + Girls_SC_Count + Girls_ST_Count;
                        int Boy_Count = Boys_General_Count + Boys_OBC_Count + Boys_SC_Count + Boys_ST_Count;
                        int Total_Student = Girls_Count + Boy_Count;

                        rvReport.Reset();

                        rvReport.LocalReport.ReportEmbeddedResource = "School.UI.Report.StudentSummary.rdlc";

                        rvReport.LocalReport.DataSources.Add(new ReportDataSource("dsStudentSummary", _Result.Data));

                        // General
                        ReportParameter rpGirlsGeneral = new ReportParameter("glGeneral", Girls_General_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpGirlsGeneral);

                        ReportParameter rpBoysGeneral = new ReportParameter("byGeneral", Boys_General_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpBoysGeneral);

                        ReportParameter rpTotalGeneral = new ReportParameter("TotalGeneral", General_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpTotalGeneral);

                        // OBC
                        ReportParameter rpGirlsOBC = new ReportParameter("glOBC", Girls_OBC_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpGirlsOBC);

                        ReportParameter rpBoysOBC = new ReportParameter("byOBC", Boys_OBC_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpBoysOBC);

                        ReportParameter rpTotalOBC = new ReportParameter("TotalOBC", OBC_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpTotalOBC);

                        // SC
                        ReportParameter rpGirlsSC = new ReportParameter("glSC", Girls_SC_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpGirlsSC);

                        ReportParameter rpBoysSC = new ReportParameter("bySC", Boys_SC_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpBoysSC);

                        ReportParameter rpTotalSC = new ReportParameter("TotalSC", SC_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpTotalSC);

                        // ST
                        ReportParameter rpGirlsST = new ReportParameter("glST", Girls_ST_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpGirlsST);

                        ReportParameter rpBoysST = new ReportParameter("byST", Boys_ST_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpBoysST);

                        ReportParameter rpTotalST = new ReportParameter("TotalST", ST_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpTotalST);

                        // Total
                        ReportParameter rpGirlsTotal = new ReportParameter("glTotal", Girls_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpGirlsTotal);

                        ReportParameter rpBoyssTotal = new ReportParameter("byTotal", Boy_Count.ToString());
                        rvReport.LocalReport.SetParameters(rpBoyssTotal);

                        ReportParameter rpTotal = new ReportParameter("Total", Total_Student.ToString());
                        rvReport.LocalReport.SetParameters(rpTotal);

                        rvReport.RefreshReport();
                    }
                }
                else
                {
                    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Control.Select();
                    epStudentSummary.SetIconPadding(_Control, 10);
                    epStudentSummary.SetError(_Control, Messages.RequiredMsg);
                }
            }
            catch (Exception _Exception)
            {
                string msg = _Exception.Message;
                MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool ValidateControl()
        {
            epStudentSummary.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (cbStandard.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Standard!";
                if (_Control == null)
                    _Control = cbStandard;
                _Result = false;
            }

            if (cbDivision.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Division!";
                if (_Control == null)
                    _Control = cbDivision;
                _Result = false;
            }
            return _Result;
        }

        public void FillStandard()
        {
            Result<DataTable> _Result = _StandardService.GetAllStandard(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbStandard.DataSource = _Result.Data;
                cbStandard.DisplayMember = "Standard";
                cbStandard.ValueMember = "StandardID";
            }
        }

        public void FillDivision()
        {
            Result<DataTable> _Result = _DivisionService.GetAllDivision(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbDivision.DataSource = _Result.Data;
                cbDivision.DisplayMember = "Division";
                cbDivision.ValueMember = "DivisionID";
            }
        }

        #endregion       

       
    }
}
