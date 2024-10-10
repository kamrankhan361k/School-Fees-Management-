using School.DataAccess;
using School.DataModel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI.Report
{
    public partial class frmBalanceSheet : Form
    {
        #region Variables

        private ReportService _ReportService = new ReportService();

        #endregion


        #region Page events and constructor

        public frmBalanceSheet()
        {
            InitializeComponent();
        }

        private void frmBalanceSheet_Load(object sender, EventArgs e)
        {
            FillBalanceSheetReport();
        }

        #endregion


        #region Private Methods       

        private void FillBalanceSheetReport()
        {
            try
            {
                Result<DataTable> _Result = _ReportService.GetBalanceSheetData(Convert.ToString(Properties.Settings.Default.Year));

                if (_Result.IsSuccess)
                {
                    rvReport.Reset();

                    rvReport.LocalReport.ReportEmbeddedResource = "School.UI.Report.BalanceSheet.rdlc";

                    rvReport.LocalReport.DataSources.Add(new ReportDataSource("dsBalanceSheet", _Result.Data));

                    rvReport.RefreshReport();
                }
            }
            catch (Exception _Exception)
            {
                string Err_Msg = _Exception.Message;
            }
        }

        #endregion
    }
}
