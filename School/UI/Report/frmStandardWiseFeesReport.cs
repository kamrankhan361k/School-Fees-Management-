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
    public partial class frmStandardWiseFeesReport : Form
    {
        #region Variables

        private ReportService _ReportService = new ReportService();

        #endregion


        #region Page events and constructor

        public frmStandardWiseFeesReport()
        {
            InitializeComponent();
        }

        private void frmDateWiseFeesReport_Load(object sender, EventArgs e)
        {
            this.rvReport.RefreshReport();
            FillStandard();
        }

        #endregion


        #region Button Events

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string _Standard = string.Empty;
          
            for (int no = 0; no < chklStandard.Items.Count; no++)
            {
                if (chklStandard.GetItemChecked(no))
                {
                    _Standard = string.IsNullOrEmpty(_Standard) ? "'" + chklStandard.Items[no].ToString() + "'" : _Standard + ",'" + chklStandard.Items[no].ToString() + "'";
                }
            }

            if (string.IsNullOrEmpty(_Standard))
            {
                MessageBox.Show("Please select atleast one standard.", Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Result<DataTable> _Result = _ReportService.GetAllFeesDetailByStandardWise(_Standard, rbtnOther.Checked, Convert.ToString(Properties.Settings.Default.Year));

                if (_Result.IsSuccess)
                {
                    rvReport.Reset();

                    rvReport.LocalReport.ReportEmbeddedResource = "School.UI.Report.StandardWiseFeesReport.rdlc";

                    rvReport.LocalReport.DataSources.Add(new ReportDataSource("DataSet", _Result.Data));

                    rvReport.RefreshReport();
                }
            }
        }

        #endregion


        #region Private Methods

        public void FillStandard()
        {
            StandardService _StandardService = new StandardService();
            Result<DataTable> _Result = _StandardService.GetAllStandard(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                foreach (DataRow _DataRow in _Result.Data.Rows)
                {
                    chklStandard.Items.Add(_DataRow["Standard"]);
                }
            }
        }

        #endregion
    }
}
