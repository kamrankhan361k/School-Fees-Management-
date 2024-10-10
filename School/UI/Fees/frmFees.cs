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

namespace School.UI.Fees
{
    public partial class frmFees : Form
    {
        #region Variables

        private FeesService _FeesService = new FeesService();
        private DataTable _FeesDataTable = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;
        private bool _IsOtherFees = false;

        #endregion

        #region Page events and constructor

        public frmFees()
        {
            InitializeComponent();
        }

        public frmFees(bool p_IsOtherFees)
        {
            InitializeComponent();
            _IsOtherFees = p_IsOtherFees;
        }

        private void frmFees_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtSearch.Select();

            gvFees.Columns["Edit"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));
            gvFees.Columns["Delete"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));

            gvFees.Columns["Edit"].Visible = UserHelper.IsAdmin;

            FillFeesDataTable();

            gvFees.AutoGenerateColumns = false;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenSaveFees(null);
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillFeesDataTable();
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

        private void gvFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvFees.CurrentCell.RowIndex;
                int colindex = gvFees.CurrentCell.ColumnIndex;
                if (gvFees.Columns[colindex].Name == "Edit")
                {
                    int _Id = Convert.ToInt32(gvFees.Rows[rowindex].Cells["Id"].Value);

                    OpenSaveFees(_Id);
                }
                else if (gvFees.Columns[colindex].Name == "Delete")
                {
                    int _Id = Convert.ToInt32(gvFees.Rows[rowindex].Cells["Id"].Value);

                    if (MessageBox.Show(string.Format(Messages.DeleteMsg, "Fees"), Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Result<bool> _Result = _FeesService.DeleteFeesById(_Id, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                        if (_Result.IsSuccess)
                        {
                            DataRow[] _DataRow = _FeesDataTable.Select("FeesID=" + _Id);
                            if (_DataRow.Count() > 0)
                            {
                                _FeesDataTable.Rows.Remove(_DataRow[0]);
                                _FeesDataTable.AcceptChanges();
                            }

                            FillGrid();
                        }
                        else
                        {
                            MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void gvFees_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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

        public void FillFeesDataTable()
        {
            Result<DataTable> _Result = _FeesService.GetAllFees(_IsOtherFees, Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _FeesDataTable = _Result.Data;
            }
        }

        public void FillGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvFees.DataSource = null;
            gvFees.Rows.Clear();

            DataTable _DataTable = _FeesDataTable;

            if (_FeesDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    EnumerableRowCollection<DataRow> _Query = from fees in _FeesDataTable.AsEnumerable()
                                                              where fees.Field<string>("DisplayFeesName").ToLower().Contains(txtSearch.Text.Trim().ToLower()) || fees.Field<string>("FeesType").ToLower().Contains(txtSearch.Text.Trim().ToLower()) || fees.Field<string>("Standard").ToLower().Contains(txtSearch.Text.Trim().ToLower()) || fees.Field<string>("Department").ToLower().Contains(txtSearch.Text.Trim().ToLower())
                                                              select fees;

                    _DataTable = _Query.AsDataView().ToTable();
                }

                if (_DataTable != null)
                {
                    _TotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _TotalRecords, gvFees, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
            }

            this.Cursor = Cursors.Default;
        }

        private void OpenSaveFees(int? p_FeesId)
        {
            if (p_FeesId.HasValue)
            {
                frmEditFees _frmEditFees = (frmEditFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmEditFees").FirstOrDefault();
                if (_frmEditFees != null)
                {
                    _frmEditFees.Focus();
                }
                else
                {
                    _frmEditFees = new frmEditFees(p_FeesId.Value, _IsOtherFees);
                    _frmEditFees.Show();
                    _frmEditFees.Focus();
                }
            }
            else
            {
                frmSaveFees _frmSaveFees = (frmSaveFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveFees").FirstOrDefault();
                if (_frmSaveFees != null)
                {
                    _frmSaveFees.Focus();
                }
                else
                {
                    _frmSaveFees = new frmSaveFees(_IsOtherFees);
                    _frmSaveFees.Show();
                    _frmSaveFees.Focus();
                }
            }
        }

        #endregion
    }
}
