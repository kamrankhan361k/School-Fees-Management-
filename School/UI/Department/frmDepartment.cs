using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using School.UI.Fees;
using School.UI.Student;
using School.UI.Account.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI.Department
{
    public partial class frmDepartment : Form
    {
        #region Variables

        private DepartmentService _DepartmentService = new DepartmentService();
        private DataTable _DepartmentDataTable = null;
        private int? _DepartmentId = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;
        private Control _Control = null;
        private string _Message = "";
        public int _PageId = 0;

        #endregion

        #region Page events and constructor

        public frmDepartment()
        {
            InitializeComponent();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtDepartment.Select();

            gvDepartment.Columns["Edit"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));
            gvDepartment.Columns["Delete"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));

            gvDepartment.Columns["Edit"].Visible = UserHelper.IsAdmin;

            FillDepartmentDataTable();
            FillAutoSuggestDepartment();

            gvDepartment.AutoGenerateColumns = false;

            FillGrid();

            _FirstLoad = false;

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Button Events

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControl())
            {
                SaveDepartment();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Control.Select();
                epDepartment.SetIconPadding(_Control, 10);
                epDepartment.SetError(_Control, Messages.RequiredMsg);
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
            FillDepartmentDataTable();
            FillAutoSuggestDepartment();
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

        private void gvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvDepartment.CurrentCell.RowIndex;
                int colindex = gvDepartment.CurrentCell.ColumnIndex;
                if (gvDepartment.Columns[colindex].Name == "Edit")
                {
                    int _Id = Convert.ToInt32(gvDepartment.Rows[rowindex].Cells["Id"].Value);

                    txtDepartmentName.Text = Convert.ToString(gvDepartment.Rows[rowindex].Cells["Department"].Value);
                    txtAddress.Text = Convert.ToString(gvDepartment.Rows[rowindex].Cells["Address"].Value);
                    _DepartmentId = _Id;
                }
                else if (gvDepartment.Columns[colindex].Name == "Delete")
                {
                    int _Id = Convert.ToInt32(gvDepartment.Rows[rowindex].Cells["Id"].Value);

                    if (MessageBox.Show(string.Format(Messages.DeleteMsg, "Department"), Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Result<bool> _Result = _DepartmentService.DeleteDepartmentById(_Id, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                        if (_Result.IsSuccess)
                        {
                            DataRow[] _DataRow = _DepartmentDataTable.Select("DepartmentID=" + _Id);
                            if (_DataRow.Count() > 0)
                            {
                                _DepartmentDataTable.Rows.Remove(_DataRow[0]);
                                _DepartmentDataTable.AcceptChanges();
                            }

                            FillAutoSuggestDepartment();
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

        private void gvDepartment_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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

        private void FillDepartmentDataTable()
        {
            Result<DataTable> _Result = _DepartmentService.GetAllDepartment(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _DepartmentDataTable = _Result.Data;
            }
        }

        private void FillAutoSuggestDepartment()
        {
            if (_DepartmentDataTable != null)
            {
                AutoCompleteStringCollection _AutoComplete = new AutoCompleteStringCollection();

                string[] postSource = _DepartmentDataTable
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("Department"))
                    .ToArray();

                _AutoComplete.AddRange(postSource);

                txtDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtDepartment.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtDepartment.AutoCompleteCustomSource = _AutoComplete;
            }
        }

        private void FillGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvDepartment.DataSource = null;
            gvDepartment.Rows.Clear();

            DataTable _DataTable = _DepartmentDataTable;

            if (_DepartmentDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtDepartment.Text.Trim()))
                {
                    _DepartmentDataTable.DefaultView.RowFilter = "Department ='" + txtDepartment.Text.Trim() + "'";
                    _DataTable = _DepartmentDataTable.DefaultView.ToTable();
                }

                if (_DataTable != null)
                {
                    _TotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _TotalRecords, gvDepartment, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
            }

            this.Cursor = Cursors.Default;
        }

        private bool ValidateControl()
        {
            epDepartment.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (!Helper.CheckRequired(txtDepartmentName.Text.Trim(), ref _Message, "Department"))
            {
                if (_Control == null)
                    _Control = txtDepartmentName;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtAddress.Text.Trim(), ref _Message, "Address"))
            {
                if (_Control == null)
                    _Control = txtAddress;
                _Result = false;
            }

            if (_Result)
            {
                Result<bool> _ResultData = _DepartmentService.CheckDuplicateDepartment(txtDepartmentName.Text.Trim(), _DepartmentId, Convert.ToString(Properties.Settings.Default.Year));

                if (_ResultData.IsSuccess)
                {
                    if (!_ResultData.Data)
                    {
                        _Result = true;
                    }
                    else
                    {
                        txtDepartmentName.Select();
                        _Result = false;
                        _Message = string.Format(Messages.DuplicateMsg, "Department");
                        if (_Control == null)
                            _Control = txtDepartmentName;
                    }
                }
                else
                {
                    txtDepartmentName.Select();
                    _Result = false;
                    _Message = _ResultData.Message;
                    if (_Control == null)
                        _Control = txtDepartmentName;
                }
            }

            return _Result;
        }

        private void ClearControl()
        {
            epDepartment.Clear();
            txtDepartmentName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            _DepartmentId = null;
        }

        private void SaveDepartment()
        {
            DepartmentMaster _DepartmentMaster = new DepartmentMaster();

            _DepartmentMaster.DepartmentID = _DepartmentId;
            _DepartmentMaster.Department = txtDepartmentName.Text.Trim();
            _DepartmentMaster.Address = txtAddress.Text.Trim();
            _DepartmentMaster.IsActive = true;

            Result<bool> _Result = _DepartmentService.SaveDepartment(_DepartmentMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                switch (_PageId)
                {
                    case 0:
                        MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillDepartmentDataTable();
                        FillAutoSuggestDepartment();
                        FillGrid();
                        ClearControl();
                        break;
                    case 1:
                        frmSaveFees _frmSaveFees = (frmSaveFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveFees").FirstOrDefault();
                        if (_frmSaveFees != null)
                        {
                            _frmSaveFees.FillDepartment();
                            _frmSaveFees.cbDepartment.SelectedValue = _Result.Id;
                            _frmSaveFees.Focus();
                            this.Close();
                        }
                        break;
                    case 2:
                        frmEditFees _frmEditFees = (frmEditFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmEditFees").FirstOrDefault();
                        if (_frmEditFees != null)
                        {
                            _frmEditFees.FillDepartment();
                            _frmEditFees.cbDepartment.SelectedValue = _Result.Id;
                            _frmEditFees.Focus();
                            this.Close();
                        }
                        break;
                    case 3:
                        frmSaveStudent _frmSaveStudent = (frmSaveStudent)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveStudent").FirstOrDefault();
                        if (_frmSaveStudent != null)
                        {
                            _frmSaveStudent.FillDepartment();
                            _frmSaveStudent.cbDepartment.SelectedValue = _Result.Id;
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
