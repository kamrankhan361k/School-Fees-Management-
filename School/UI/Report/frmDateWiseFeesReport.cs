using School.Common;
using School.DataAccess;
using School.DataModel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI.Report
{
    public partial class frmDateWiseFeesReport : Form
    {
        #region Variables

        private ReportService _ReportService = new ReportService();

        #endregion

        #region Page events and constructor

        public frmDateWiseFeesReport()
        {
            InitializeComponent();
        }

        private void frmDateWiseFeesReport_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();
            dtpFrom.MinDate = Convert.ToDateTime(Convert.ToString(Properties.Settings.Default.Year) + "-01-01");
            dtpFrom.MaxDate = DateTime.Now;
            dtpFrom.Value = DateTime.UtcNow.AddDays(-30);
            dtpTo.MinDate = Convert.ToDateTime(Convert.ToString(Properties.Settings.Default.Year) + "-01-01");
            dtpTo.MaxDate = DateTime.Now;
            dtpTo.Value = DateTime.UtcNow;
        }

        #endregion

        #region Button Events

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Result<DataTable> _Result = _ReportService.GetAllFeesReceiptByDateWise(dtpFrom.Value, dtpTo.Value, rbtnOther.Checked, Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                rvReport.Reset();

                rvReport.LocalReport.ReportEmbeddedResource = "School.UI.Report.DateWiseFeesReport.rdlc";

                rvReport.LocalReport.DataSources.Add(new ReportDataSource("DataSet", _Result.Data));

                rvReport.RefreshReport();
            }
        }

        #endregion


    }
}
