using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
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

namespace School.UI.CollectFees
{
    public partial class frmFeesReceipt : Form
    {
        #region Variables

        private CollectFeesService _CollectFeesService = new CollectFeesService();
        private ReceiptService _ReceiptService = new ReceiptService();
        private DataTable _FeesDataTable = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;
        private bool _IsOtherFees = false;
        private int _StudentId = 0;

        #endregion

        #region Page events and constructor

        public frmFeesReceipt()
        {
            InitializeComponent();
        }

        public frmFeesReceipt(bool p_IsOtherFees,int p_StudentId)
        {
            InitializeComponent();
            _IsOtherFees = p_IsOtherFees;
            _StudentId = p_StudentId;
        }

        private void frmFeesReceipt_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtSearch.Select();
            FillFeesReceiptDataTable();

            gvFeesReceipt.AutoGenerateColumns = false;

            FillGrid();

            _FirstLoad = false;

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Button Events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillFeesReceiptDataTable();
            FillGrid();
        }

        private void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_FirstLoad)
            {
                if (cbPages.SelectedIndex >= 0)
                {
                    _PageNo = Convert.ToInt32(cbPages.Text);
                }
                FillGrid();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            _PageNo = 1;
            cbPages.Text = _PageNo.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_PageNo > 1)
            {
                _PageNo--;
                cbPages.Text = _PageNo.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _PageNo++;
            cbPages.Text = _PageNo.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _PageNo = cbPages.Items.Count;
            cbPages.Text = _PageNo.ToString();
        }

        private void gvFeesReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvFeesReceipt.CurrentCell.RowIndex;
                int colindex = gvFeesReceipt.CurrentCell.ColumnIndex;
                if (gvFeesReceipt.Columns[colindex].Name == "Print")
                {
                    Int64 _ReceiptNo = Convert.ToInt32(gvFeesReceipt.Rows[rowindex].Cells["ReceiptNo"].Value);

                    PrintReceipt(_ReceiptNo);
                }
            }
        }

        private void gvFeesReceipt_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Selected == true)
            {
                if (!string.IsNullOrEmpty(cbPages.Text))
                {
                    int _RowNo = (((Convert.ToInt32(cbPages.Text) * 10) - 10) + 1 + e.Row.Index);

                    CommonFunction.SetSelectRowNo(_RowNo, _TotalRecords, lblSelectRow);
                }
            }
        }

        #endregion

        #region Private Methods

        public void FillFeesReceiptDataTable()
        {
            Result<DataTable> _Result = _ReceiptService.GetAllFeesReceiptByStudentId(_StudentId, _IsOtherFees, Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _FeesDataTable = _Result.Data;
            }
        }

        public void FillGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvFeesReceipt.DataSource = null;
            gvFeesReceipt.Rows.Clear();

            DataTable _DataTable = _FeesDataTable;

            if (_FeesDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    string _Search = txtSearch.Text.Trim().ToLower();
                    EnumerableRowCollection<DataRow> _Query = from fees in _FeesDataTable.AsEnumerable()
                                                              where fees.Field<string>("Name").ToLower().Contains(_Search) || fees.Field<string>("Standard").ToLower().Contains(_Search) || fees.Field<string>("Division").ToLower().Contains(_Search) || fees.Field<string>("Department").ToLower().Contains(_Search)
                                                              select fees;

                    _DataTable = _Query.AsDataView().ToTable();
                }

                if (_DataTable != null)
                {
                    _TotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _TotalRecords, gvFeesReceipt, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
            }

            this.Cursor = Cursors.Default;
        }

        private void PrintReceipt(Int64 p_No)
        {
            Result<DataTable> _Result = _ReceiptService.GetFeesReceiptByReceiptNo(p_No, Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                LocalReport report = new LocalReport();
                report.ReportEmbeddedResource = "School.UI.Report.FeesReceipt.rdlc";
                report.DataSources.Add(
                   new ReportDataSource("DataSet", _Result.Data));

                PrintFunction _PrintFunction = new PrintFunction();

                _PrintFunction.Export(report);
                _PrintFunction.Print();
            }
        }

        #endregion
    }
}
