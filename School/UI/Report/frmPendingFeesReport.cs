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
    public partial class frmPendingFeesReport : Form
    {
        #region Variables

        private ReportService _ReportService = new ReportService();

        #endregion


        #region Page events and constructor

        public frmPendingFeesReport()
        {
            InitializeComponent();
        }

        private void frmPendingFeesReport_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();
        }

        #endregion

        #region Button Events

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Result<DataTable> _Result = _ReportService.GetAllPendingFeesStudent(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                rvReport.Reset();

                rvReport.LocalReport.ReportEmbeddedResource = "School.UI.Report.PendingFeesReport.rdlc";

                ReportParameter _ReportParameter = new ReportParameter("Note", txtNote.Text.Trim());

                rvReport.LocalReport.SetParameters(new ReportParameter[] { _ReportParameter });

                rvReport.LocalReport.DataSources.Add(new ReportDataSource("DataSet", _Result.Data));

                rvReport.RefreshReport();
            }
        }

        #endregion
        
    }
}
