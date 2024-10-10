using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
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
    public partial class frmCollectFees : Form
    {
        #region Variables

        private CollectFeesService _CollectFeesService = new CollectFeesService();
        private DataTable _InCompleteFeesDataTable = null, _PendingFeesDataTable = null;
        private int _InCompletePageNo = 1, _InCompleteTotalRecords = 0, _PendingPageNo = 1, _PendingTotalRecords = 0;
        private bool _FirstInCompleteLoad = true, _FirstPendingLoad = true;
        private bool _IsOtherFees = false;

        #endregion


        #region Page events and constructor

        public frmCollectFees()
        {
            InitializeComponent();
        }

        public frmCollectFees(bool p_IsOtherFees)
        {
            InitializeComponent();
            _IsOtherFees = p_IsOtherFees;
        }

        private void frmCollectFees_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            txtInCompleteSearch.Select();

            FillInCompleteFeesDataTable();
            FillPendingFeesDataTable();

            gvInCompleteFees.AutoGenerateColumns = false;
            gvPendingFees.AutoGenerateColumns = false;

            FillInCompleteFeesGrid();
            FillPendingFeesGrid();

            _FirstInCompleteLoad = false;
            _FirstPendingLoad = false;

            this.Cursor = Cursors.Default;
        }

        #endregion


        #region Button Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenSaveCollectFees(0, 0, 0, 0);
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Private Methods

        private void OpenSaveCollectFees(int p_StandardId, int p_DivisionId, int p_DepartmentId, int p_StudentId)
        {
            frmSaveCollectFees _frmSaveCollectFees = (frmSaveCollectFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveCollectFees").FirstOrDefault();
            if (_frmSaveCollectFees != null)
            {
                _frmSaveCollectFees.Focus();
            }
            else
            {
                _frmSaveCollectFees = new frmSaveCollectFees(_IsOtherFees, p_StandardId, p_DivisionId, p_DepartmentId, p_StudentId);
                _frmSaveCollectFees.Show();
                _frmSaveCollectFees.Focus();
            }
        }

        private void OpenFeesReceipt(int p_StudentId)
        {
            frmFeesReceipt _frmFeesReceipt = (frmFeesReceipt)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmFeesReceipt").FirstOrDefault();
            if (_frmFeesReceipt != null)
            {
                _frmFeesReceipt.Focus();
            }
            else
            {
                _frmFeesReceipt = new frmFeesReceipt(_IsOtherFees, p_StudentId);
                _frmFeesReceipt.Show();
                _frmFeesReceipt.Focus();
            }
        }

        #endregion


        #region InComplete Fees

        public void FillInCompleteFeesDataTable()
        {
            Result<DataTable> _Result = _CollectFeesService.GetAllInCompleteFeesStudent(_IsOtherFees, Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _InCompleteFeesDataTable = _Result.Data;
            }
        }

        public void FillInCompleteFeesGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvInCompleteFees.DataSource = null;
            gvInCompleteFees.Rows.Clear();

            DataTable _DataTable = _InCompleteFeesDataTable;

            if (_InCompleteFeesDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtInCompleteSearch.Text.Trim()))
                {
                    string _Search = txtInCompleteSearch.Text.Trim().ToLower();

                    EnumerableRowCollection<DataRow> _Query = from s in _InCompleteFeesDataTable.AsEnumerable()
                                                              where  s.Field<string>("Standard").ToLower().Contains(_Search) || s.Field<string>("Division").ToLower().Contains(_Search) || s.Field<string>("Department").ToLower().Contains(_Search) || s.Field<string>("Name").ToLower().Contains(_Search) || s.Field<string>("Gender").ToLower().Contains(_Search)
                                                              select s;

                    _DataTable = _Query.AsDataView().ToTable();
                }

                if (_DataTable != null)
                {
                    _InCompleteTotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _InCompleteTotalRecords, gvInCompleteFees, this._InCompletePageNo, lblInCompleteSelectRow, cbInCompletePages, btnInCompleteFirst, btnInCompletePrevious, btnInCompleteLast, btnInCompleteNext);
            }

            this.Cursor = Cursors.Default;
        }

        private void txtInCompleteSearch_TextChanged(object sender, EventArgs e)
        {
            FillInCompleteFeesGrid();
        }

        private void btnInCompleteRefresh_Click(object sender, EventArgs e)
        {
            FillInCompleteFeesDataTable();
            FillInCompleteFeesGrid();
        }

        private void cbInCompletePages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_FirstInCompleteLoad)
            {
                if (cbInCompletePages.SelectedIndex >= 0)
                {
                    _InCompletePageNo = Convert.ToInt32(cbInCompletePages.Text);
                }
                FillInCompleteFeesGrid();
            }
        }

        private void btnInCompleteFirst_Click(object sender, EventArgs e)
        {
            _InCompletePageNo = 1;
            cbInCompletePages.Text = _InCompletePageNo.ToString();
        }

        private void btnInCompletePrevious_Click(object sender, EventArgs e)
        {
            if (_InCompletePageNo > 1)
            {
                _InCompletePageNo--;
                cbInCompletePages.Text = _InCompletePageNo.ToString();
            }
        }

        private void btnInCompleteNext_Click(object sender, EventArgs e)
        {
            _InCompletePageNo++;
            cbInCompletePages.Text = _InCompletePageNo.ToString();
        }

        private void btnInCompleteLast_Click(object sender, EventArgs e)
        {
            _InCompletePageNo = cbInCompletePages.Items.Count;
            cbInCompletePages.Text = _InCompletePageNo.ToString();
        }

        private void gvInCompleteFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvInCompleteFees.CurrentCell.RowIndex;
                int colindex = gvInCompleteFees.CurrentCell.ColumnIndex;

                if (gvInCompleteFees.Columns[colindex].Name == "Action")
                {
                    int _PendingFees = Convert.ToInt32(gvInCompleteFees.Rows[rowindex].Cells["PendingFees"].Value);

                    if (_PendingFees > 0)
                    {
                        int _StandardId = Convert.ToInt32(gvInCompleteFees.Rows[rowindex].Cells["StandardId"].Value);
                        int _DivisionId = Convert.ToInt32(gvInCompleteFees.Rows[rowindex].Cells["DivisionId"].Value);
                        int _DepartmentId = Convert.ToInt32(gvInCompleteFees.Rows[rowindex].Cells["DepartmentId"].Value);
                        int _StudentId = Convert.ToInt32(gvInCompleteFees.Rows[rowindex].Cells["StudentId"].Value);

                        OpenSaveCollectFees(_StandardId, _DivisionId, _DepartmentId, _StudentId);
                    }
                    else
                    {
                        MessageBox.Show(Messages.PaidCollectFeesMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (gvInCompleteFees.Columns[colindex].Name == "View")
                {
                    int _StudentId = Convert.ToInt32(gvInCompleteFees.Rows[rowindex].Cells["StudentId"].Value);

                    OpenFeesReceipt(_StudentId);
                }
            }
        }

        private void gvInComplete_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Selected == true)
            {
                if (!string.IsNullOrEmpty(cbInCompletePages.Text))
                {
                    int _RowNo = (((Convert.ToInt32(cbInCompletePages.Text) * 10) - 10) + 1 + e.Row.Index);

                    CommonFunction.SetSelectRowNo(_RowNo, _InCompleteTotalRecords, lblInCompleteSelectRow);
                }
            }
        }

        #endregion


        #region Pending Fees

        public void FillPendingFeesDataTable()
        {
            Result<DataTable> _Result = _CollectFeesService.GetAllPendingFeesStudent(_IsOtherFees, Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _PendingFeesDataTable = _Result.Data;
            }
        }

        public void FillPendingFeesGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvPendingFees.DataSource = null;
            gvPendingFees.Rows.Clear();

            DataTable _DataTable = _PendingFeesDataTable;

            if (_PendingFeesDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtPendingSearch.Text.Trim()))
                {
                    string _Search = txtPendingSearch.Text.Trim().ToLower();

                    EnumerableRowCollection<DataRow> _Query = from s in _PendingFeesDataTable.AsEnumerable()
                                                              where s.Field<string>("Standard").ToLower().Contains(_Search) || s.Field<string>("Division").ToLower().Contains(_Search) || s.Field<string>("Department").ToLower().Contains(_Search) || s.Field<string>("Name").ToLower().Contains(_Search) || s.Field<string>("Gender").ToLower().Contains(_Search)
                                                              select s;

                    _DataTable = _Query.AsDataView().ToTable();
                }

                if (_DataTable != null)
                {
                    _PendingTotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _PendingTotalRecords, gvPendingFees, this._PendingPageNo, lblPendingSelectRow, cbPendingPages, btnPendingFirst, btnPendingPrevious, btnPendingLast, btnPendingNext);
            }

            this.Cursor = Cursors.Default;
        }

        private void txtPendingSearch_TextChanged(object sender, EventArgs e)
        {
            FillPendingFeesGrid();
        }

        private void btnPendingRefresh_Click(object sender, EventArgs e)
        {
            FillPendingFeesDataTable();
            FillPendingFeesGrid();
        }

        private void cbPendingPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_FirstPendingLoad)
            {
                if (cbPendingPages.SelectedIndex >= 0)
                {
                    _PendingPageNo = Convert.ToInt32(cbPendingPages.Text);
                }
                FillPendingFeesGrid();
            }
        }

        private void btnPendingFirst_Click(object sender, EventArgs e)
        {
            _PendingPageNo = 1;
            cbPendingPages.Text = _PendingPageNo.ToString();
        }

        private void btnPendingPrevious_Click(object sender, EventArgs e)
        {
            if (_PendingPageNo > 1)
            {
                _PendingPageNo--;
                cbPendingPages.Text = _PendingPageNo.ToString();
            }
        }

        private void btnPendingNext_Click(object sender, EventArgs e)
        {
            _PendingPageNo++;
            cbPendingPages.Text = _PendingPageNo.ToString();
        }

        private void btnPendingLast_Click(object sender, EventArgs e)
        {
            _PendingPageNo = cbPendingPages.Items.Count;
            cbPendingPages.Text = _PendingPageNo.ToString();
        }

        private void gvPendingFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvPendingFees.CurrentCell.RowIndex;
                int colindex = gvPendingFees.CurrentCell.ColumnIndex;
                if (gvPendingFees.Columns[colindex].Name == "ActionAdd")
                {
                    int _StandardId = Convert.ToInt32(gvPendingFees.Rows[rowindex].Cells["PendingStandardId"].Value);
                    int _DivisionId = Convert.ToInt32(gvPendingFees.Rows[rowindex].Cells["PendingDivisionId"].Value);
                    int _DepartmentId = Convert.ToInt32(gvPendingFees.Rows[rowindex].Cells["PendingDepartmentId"].Value);
                    int _StudentId = Convert.ToInt32(gvPendingFees.Rows[rowindex].Cells["PendingStudentId"].Value);

                    OpenSaveCollectFees(_StandardId, _DivisionId, _DepartmentId, _StudentId);
                }
            }
        }

        private void gvPending_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Selected == true)
            {
                if (!string.IsNullOrEmpty(cbPendingPages.Text))
                {
                    int _RowNo = (((Convert.ToInt32(cbPendingPages.Text) * 10) - 10) + 1 + e.Row.Index);

                    CommonFunction.SetSelectRowNo(_RowNo, _PendingTotalRecords, lblPendingSelectRow);
                }
            }
        }

        #endregion
    }
}
