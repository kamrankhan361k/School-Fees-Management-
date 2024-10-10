using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using School.UI.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI.Division
{
    public partial class frmDivision : Form
    {
        #region Variables

        private DivisionService _DivisionService = new DivisionService();
        private DataTable _DivisionDataTable = null;
        private int? _DivisionId = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;
        private Control _Control = null;
        private string _Message = "";
        public int _PageId = 0;

        #endregion

        #region Page events and constructor

        public frmDivision()
        {
            InitializeComponent();
        }

        private void frmDivision_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtDivision.Select();

            gvDivision.Columns["Edit"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));
            gvDivision.Columns["Delete"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));

            gvDivision.Columns["Edit"].Visible = UserHelper.IsAdmin;

            FillDivisionDataTable();
            FillAutoSuggestDivision();

            gvDivision.AutoGenerateColumns = false;

            FillGrid();

            _FirstLoad = false;

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Button Events

        private void txtDivision_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControl())
            {
                SaveDivision();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Control.Select();
                epDivision.SetIconPadding(_Control, 10);
                epDivision.SetError(_Control, Messages.RequiredMsg);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDivisionDataTable();
            FillAutoSuggestDivision();
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

        private void gvDivision_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvDivision.CurrentCell.RowIndex;
                int colindex = gvDivision.CurrentCell.ColumnIndex;
                if (gvDivision.Columns[colindex].Name == "Edit")
                {
                    int _Id = Convert.ToInt32(gvDivision.Rows[rowindex].Cells["Id"].Value);

                    txtDivisionName.Text = Convert.ToString(gvDivision.Rows[rowindex].Cells["Division"].Value);
                    _DivisionId = _Id;
                }
                else if (gvDivision.Columns[colindex].Name == "Delete")
                {
                    int _Id = Convert.ToInt32(gvDivision.Rows[rowindex].Cells["Id"].Value);

                    if (MessageBox.Show(string.Format(Messages.DeleteMsg, "Division"), Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Result<bool> _Result = _DivisionService.DeleteDivisionById(_Id, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                        if (_Result.IsSuccess)
                        {
                            DataRow[] _DataRow = _DivisionDataTable.Select("DivisionID=" + _Id);
                            if (_DataRow.Count() > 0)
                            {
                                _DivisionDataTable.Rows.Remove(_DataRow[0]);
                                _DivisionDataTable.AcceptChanges();
                            }

                            FillAutoSuggestDivision();
                            FillGrid();
                            ClearControl();
                        }
                        else
                        {
                            MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void gvDivision_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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

        private void FillDivisionDataTable()
        {
            Result<DataTable> _Result = _DivisionService.GetAllDivision( Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _DivisionDataTable = _Result.Data;
            }
        }

        private void FillAutoSuggestDivision()
        {
            if (_DivisionDataTable != null)
            {
                AutoCompleteStringCollection _AutoComplete = new AutoCompleteStringCollection();

                string[] postSource = _DivisionDataTable
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("Division"))
                    .ToArray();

                _AutoComplete.AddRange(postSource);

                txtDivision.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtDivision.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtDivision.AutoCompleteCustomSource = _AutoComplete;
            }
        }

        private void FillGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvDivision.DataSource = null;
            gvDivision.Rows.Clear();

            DataTable _DataTable = _DivisionDataTable;

            if (_DivisionDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtDivision.Text.Trim()))
                {
                    _DivisionDataTable.DefaultView.RowFilter = "Division ='" + txtDivision.Text.Trim() + "'";
                    _DataTable = _DivisionDataTable.DefaultView.ToTable();
                }

                if (_DataTable != null)
                {
                    _TotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _TotalRecords, gvDivision, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
            }

            this.Cursor = Cursors.Default;
        }

        private bool ValidateControl()
        {
            epDivision.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (!Helper.CheckRequired(txtDivisionName.Text.Trim(), ref _Message, "Division"))
            {
                if (_Control == null)
                    _Control = txtDivisionName;
                _Result = false;
            }

            if (_Result)
            {
                Result<bool> _ResultData = _DivisionService.CheckDuplicateDivision(txtDivisionName.Text.Trim(), _DivisionId, Convert.ToString(Properties.Settings.Default.Year));

                if (_ResultData.IsSuccess)
                {
                    if (!_ResultData.Data)
                    {
                        _Result = true;
                    }
                    else
                    {
                        txtDivisionName.Select();
                        _Result = false;
                        _Message = string.Format(Messages.DuplicateMsg, "Division");
                        if (_Control == null)
                            _Control = txtDivisionName;
                    }
                }
                else
                {
                    txtDivisionName.Select();
                    _Result = false;
                    _Message = _ResultData.Message;
                    if (_Control == null)
                        _Control = txtDivisionName;
                }
            }

            return _Result;
        }

        private void ClearControl()
        {
            epDivision.Clear();
            txtDivisionName.Text = string.Empty;
            _DivisionId = null;
        }

        private void SaveDivision()
        {
            DivisionMaster _DivisionMaster = new DivisionMaster();

            _DivisionMaster.DivisionID = _DivisionId;
            _DivisionMaster.Division = txtDivisionName.Text.Trim();
            _DivisionMaster.IsActive = true;

            Result<bool> _Result = _DivisionService.SaveDivision(_DivisionMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                switch (_PageId)
                {
                    case 0:
                        MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillDivisionDataTable();
                        FillAutoSuggestDivision();
                        FillGrid();
                        ClearControl();
                        break;
                    case 1:
                       frmSaveStudent _frmSaveStudent = (frmSaveStudent)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveStudent").FirstOrDefault();
                        if (_frmSaveStudent != null)
                        {
                            _frmSaveStudent.FillDivision();
                            _frmSaveStudent.cbDivision.SelectedValue = _Result.Id;
                            _frmSaveStudent.Focus();
                            this.Close();
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
