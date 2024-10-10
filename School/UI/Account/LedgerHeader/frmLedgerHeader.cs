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

namespace School.UI.Account.LedgerHeader
{
    public partial class frmLedgerHeader : Form
    {
        #region Variables

        private LedgerService _LedgerService = new LedgerService();
        private DataTable _LedgerHeaderDataTable = null;
        private int? _LedgerHeaderId = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;
        private Control _Control = null;
        private string _Message = "";
        public int _PageId = 0;

        #endregion

        #region Page events and constructor

        public frmLedgerHeader()
        {
            InitializeComponent();
        }
        private void frmLedgerHeader_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtLedgerHeader.Select();

            gvLedgerHeader.Columns["Edit"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));
            gvLedgerHeader.Columns["Delete"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));

            FillLedgerHeaderDataTable();
            FillAutoSuggestLedgerHeader();

            gvLedgerHeader.AutoGenerateColumns = false;

            FillGrid();

            _FirstLoad = false;

            this.Cursor = Cursors.Default;
        }
        #endregion

        #region Button Event
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillLedgerHeaderDataTable();
            FillAutoSuggestLedgerHeader();
            FillGrid();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControl())
            {
                SaveLedgerHeader();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Control.Select();
                epLedgerHeader.SetIconPadding(_Control, 10);
                epLedgerHeader.SetError(_Control, Messages.RequiredMsg);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
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
        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLedgerHeader_TextChanged(object sender, EventArgs e)
        {
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

        private void gvLedgerHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvLedgerHeader.CurrentCell.RowIndex;
                int colindex = gvLedgerHeader.CurrentCell.ColumnIndex;
                if (gvLedgerHeader.Columns[colindex].Name == "Edit")
                {
                    int _Id = Convert.ToInt32(gvLedgerHeader.Rows[rowindex].Cells["Id"].Value);

                    txtLedgerHeadernm.Text = Convert.ToString(gvLedgerHeader.Rows[rowindex].Cells["LedgerHeader"].Value);
                    txtDescription.Text = Convert.ToString(gvLedgerHeader.Rows[rowindex].Cells["Description"].Value);
                    _LedgerHeaderId = _Id;
                }
                else if (gvLedgerHeader.Columns[colindex].Name == "Delete")
                {
                    int _Id = Convert.ToInt32(gvLedgerHeader.Rows[rowindex].Cells["Id"].Value);
                    if (MessageBox.Show(string.Format(Messages.DeleteMsg, "LedgerHeader"), Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Result<bool> _Result = _LedgerService.DeleteLedgerHeaderById(_Id, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                        if (_Result.IsSuccess)
                        {
                            DataRow[] _DataRow = _LedgerHeaderDataTable.Select("LedgerHeaderId=" + _Id);

                            if (_DataRow.Count() > 0)
                            {
                                _LedgerHeaderDataTable.Rows.Remove(_DataRow[0]);
                                _LedgerHeaderDataTable.AcceptChanges();
                            }

                            FillAutoSuggestLedgerHeader();
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

        private void gvLedgerHeader_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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

        private void FillLedgerHeaderDataTable()
        {
            Result<DataTable> _Result = _LedgerService.GetAllLedgerHeader(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _LedgerHeaderDataTable = _Result.Data;
            }
        }

        private void FillAutoSuggestLedgerHeader()
        {
            if (_LedgerHeaderDataTable != null)
            {
                AutoCompleteStringCollection _AutoComplete = new AutoCompleteStringCollection();

                string[] postSource = _LedgerHeaderDataTable
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("LedgerHeader"))
                    .ToArray();

                _AutoComplete.AddRange(postSource);

                txtLedgerHeader.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtLedgerHeader.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtLedgerHeader.AutoCompleteCustomSource = _AutoComplete;
            }
        }

        private void FillGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvLedgerHeader.DataSource = null;
                gvLedgerHeader.Rows.Clear();

                DataTable _DataTable = _LedgerHeaderDataTable;

                if (_LedgerHeaderDataTable != null)
                {
                    if (!string.IsNullOrEmpty(txtLedgerHeader.Text.Trim()))
                    {
                        _LedgerHeaderDataTable.DefaultView.RowFilter = "LedgerHeader ='" + txtLedgerHeader.Text.Trim() + "'";
                        _DataTable = _LedgerHeaderDataTable.DefaultView.ToTable();
                    }

                    if (_DataTable != null)
                    {
                        _TotalRecords = _DataTable.Rows.Count;
                    }

                    CommonFunction.GridPagging(_DataTable, _TotalRecords, gvLedgerHeader, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
                }
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool ValidateControl()
        {
            epLedgerHeader.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (!Helper.CheckRequired(txtLedgerHeadernm.Text.Trim(), ref _Message, "LedgerHeader"))
            {
                if (_Control == null)
                    _Control = txtLedgerHeadernm;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtDescription.Text.Trim(), ref _Message, "Description"))
            {
                if (_Control == null)
                    _Control = txtDescription;
                _Result = false;
            }

            if (_Result)
            {
                Result<bool> _ResultData = _LedgerService.CheckDuplicateLedgerHeader(txtLedgerHeadernm.Text.Trim(), _LedgerHeaderId, Convert.ToString(Properties.Settings.Default.Year));

                if (_ResultData.IsSuccess)
                {
                    if (!_ResultData.Data)
                    {
                        _Result = true;
                    }
                    else
                    {
                        txtLedgerHeadernm.Select();
                        _Result = false;
                        _Message = string.Format(Messages.DuplicateMsg, "LedgerHeader");
                        if (_Control == null)
                            _Control = txtLedgerHeadernm;
                    }
                }
                else
                {
                    txtLedgerHeadernm.Select();
                    _Result = false;
                    _Message = _ResultData.Message;
                    if (_Control == null)
                        _Control = txtLedgerHeadernm;
                }
            }

            return _Result;
        }

        private void ClearControl()
        {
            epLedgerHeader.Clear();
            txtLedgerHeadernm.Text = string.Empty;
            txtDescription.Text = string.Empty;
            _LedgerHeaderId = null;
        }

        private void SaveLedgerHeader()
        {
            LedgerHeaderMaster _LedgerHeader = new LedgerHeaderMaster();
          
            _LedgerHeader.LedgerHeaderID = _LedgerHeaderId;
            _LedgerHeader.LedgerHeader = txtLedgerHeadernm.Text.Trim();
            _LedgerHeader.Description = txtDescription.Text.Trim();
            _LedgerHeader.IsActive = true;

            Result<bool> _Result = _LedgerService.SaveLedgerHeader(_LedgerHeader, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                switch (_PageId)
                {
                    case 0:
                        MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillLedgerHeaderDataTable();
                        FillAutoSuggestLedgerHeader();
                        FillGrid();
                        ClearControl();
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
