using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using School.UI.Fees;
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

namespace School.UI.Standard
{
    public partial class frmStandard : Form
    {
        #region Variables

        private StandardService _StandardService = new StandardService();
        private DataTable _StandardDataTable = null;
        private int? _StandardId = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;
        private Control _Control = null;
        private string _Message = "";
        public int _PageId = 0;

        #endregion

        #region Page events and constructor

        public frmStandard()
        {
            InitializeComponent();
        }

        private void frmStandard_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtStandard.Select();

            gvStandard.Columns["Edit"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));
            gvStandard.Columns["Delete"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));

            gvStandard.Columns["Edit"].Visible = UserHelper.IsAdmin;

            FillStandardDataTable();
            FillAutoSuggestStandard();

            gvStandard.AutoGenerateColumns = false;

            FillGrid();

            _FirstLoad = false;

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Button Events

        private void txtStandard_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControl())
            {
                SaveStandard();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Control.Select();
                epStandard.SetIconPadding(_Control, 10);
                epStandard.SetError(_Control, Messages.RequiredMsg);
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
            FillStandardDataTable();
            FillAutoSuggestStandard();
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

        private void gvStandard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvStandard.CurrentCell.RowIndex;
                int colindex = gvStandard.CurrentCell.ColumnIndex;
                if (gvStandard.Columns[colindex].Name == "Edit")
                {
                    int _Id = Convert.ToInt32(gvStandard.Rows[rowindex].Cells["Id"].Value);

                    txtStandardName.Text = Convert.ToString(gvStandard.Rows[rowindex].Cells["Standard"].Value);
                    _StandardId = _Id;

                }
                else if (gvStandard.Columns[colindex].Name == "Delete")
                {
                    int _Id = Convert.ToInt32(gvStandard.Rows[rowindex].Cells["Id"].Value);

                    if (MessageBox.Show(string.Format(Messages.DeleteMsg, "Standard"), Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Result<bool> _Result = _StandardService.DeleteStandardById(_Id, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                        if (_Result.IsSuccess)
                        {
                            DataRow[] _DataRow = _StandardDataTable.Select("StandardID=" + _Id);
                            if (_DataRow.Count() > 0)
                            {
                                _StandardDataTable.Rows.Remove(_DataRow[0]);
                                _StandardDataTable.AcceptChanges();
                            }

                            FillAutoSuggestStandard();
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

        private void gvStandard_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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

        private void FillStandardDataTable()
        {
            Result<DataTable> _Result = _StandardService.GetAllStandard(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _StandardDataTable = _Result.Data;
            }
        }

        private void FillAutoSuggestStandard()
        {
            if (_StandardDataTable != null)
            {
                AutoCompleteStringCollection _AutoComplete = new AutoCompleteStringCollection();

                string[] postSource = _StandardDataTable
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("Standard"))
                    .ToArray();

                _AutoComplete.AddRange(postSource);

                txtStandard.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtStandard.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtStandard.AutoCompleteCustomSource = _AutoComplete;
            }
        }

        private void FillGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvStandard.DataSource = null;
            gvStandard.Rows.Clear();

            DataTable _DataTable = _StandardDataTable;

            if (_StandardDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtStandard.Text.Trim()))
                {
                    _StandardDataTable.DefaultView.RowFilter = "Standard ='" + txtStandard.Text.Trim() + "'";
                    _DataTable = _StandardDataTable.DefaultView.ToTable();
                }

                if (_DataTable != null)
                {
                    _TotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _TotalRecords, gvStandard, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
            }

            this.Cursor = Cursors.Default;
        }

        private bool ValidateControl()
        {
            epStandard.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (!Helper.CheckRequired(txtStandardName.Text.Trim(), ref _Message, "Standard"))
            {
                if (_Control == null)
                    _Control = txtStandardName;
                _Result = false;
            }

            if (_Result)
            {
                Result<bool> _ResultData = _StandardService.CheckDuplicateStandard(txtStandardName.Text.Trim(), _StandardId, Convert.ToString(Properties.Settings.Default.Year));

                if (_ResultData.IsSuccess)
                {
                    if (!_ResultData.Data)
                    {
                        _Result = true;
                    }
                    else
                    {
                        txtStandardName.Select();
                        _Result = false;
                        _Message = string.Format(Messages.DuplicateMsg, "Standard");
                        if (_Control == null)
                            _Control = txtStandardName;
                    }
                }
                else
                {
                    txtStandardName.Select();
                    _Result = false;
                    _Message = _ResultData.Message;
                    if (_Control == null)
                        _Control = txtStandardName;
                }
            }

            return _Result;
        }

        private void ClearControl()
        {
            epStandard.Clear();
            txtStandardName.Text = string.Empty;
            _StandardId = null;
        }

        private void SaveStandard()
        {
            StandardMaster _StandardMaster = new StandardMaster();

            _StandardMaster.StandardID = _StandardId;
            _StandardMaster.Standard = txtStandardName.Text.Trim();
            _StandardMaster.IsActive = true;

            Result<bool> _Result = _StandardService.SaveStandard(_StandardMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                switch (_PageId)
                {
                    case 0:
                        MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillStandardDataTable();
                        FillAutoSuggestStandard();
                        FillGrid();
                        ClearControl();
                        break;
                    case 1:
                        frmSaveFees _frmSaveFees = (frmSaveFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveFees").FirstOrDefault();
                        if (_frmSaveFees != null)
                        {
                            _frmSaveFees.FillStandard();
                            _frmSaveFees.cbStandard.SelectedValue = _Result.Id;
                            _frmSaveFees.Focus();
                            this.Close();
                        }
                        break;
                    case 2:
                        frmEditFees _frmEditFees = (frmEditFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmEditFees").FirstOrDefault();
                        if (_frmEditFees != null)
                        {
                            _frmEditFees.FillStandard();
                            _frmEditFees.cbStandard.SelectedValue = _Result.Id;
                            _frmEditFees.Focus();
                            this.Close();
                        }
                        break;
                    case 3:
                        frmSaveStudent _frmSaveStudent = (frmSaveStudent)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveStudent").FirstOrDefault();
                        if (_frmSaveStudent != null)
                        {
                            _frmSaveStudent.FillStandard();
                            _frmSaveStudent.cbStandard.SelectedValue = _Result.Id;
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
