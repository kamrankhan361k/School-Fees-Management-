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

namespace School.UI.Account.Ledger
{
    public partial class frmLedger : Form
    {
        #region Variables

        private LedgerService _LedgerService = new LedgerService();
        private DataTable _LedgerDataTable = null;
        private int? _LedgerId = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;
        private Control _Control = null;
        private string _Message = "";
        public int _PageId = 0;

        #endregion

        #region Page events and constructor

        public frmLedger()
        {
            InitializeComponent();
        }

        private void frmLedger_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtSearch.Select();

            gvLedger.Columns["Edit"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));
            gvLedger.Columns["Delete"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));

            FillLedgerDataTable();
            FillAutoSuggestLedger();
            FillLeaderHeader();

            gvLedger.AutoGenerateColumns = false;

            FillGrid();

            _FirstLoad = false;

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Button Event


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillLedgerDataTable();
            FillAutoSuggestLedger();
            FillGrid();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (ValidateControl())
                {
                    SaveLedger();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Control.Select();
                    epLedger.SetIconPadding(_Control, 10);
                    epLedger.SetError(_Control, Messages.RequiredMsg);
                }
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _PageNo = cbPages.Items.Count;
            cbPages.Text = _PageNo.ToString();
        }


        private void gvLedger_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvLedger.CurrentCell.RowIndex;
                int colindex = gvLedger.CurrentCell.ColumnIndex;
                if (gvLedger.Columns[colindex].Name == "Edit")
                {
                    int _Id = Convert.ToInt32(gvLedger.Rows[rowindex].Cells["Id"].Value);
                    cbLedgerHeader.Text = Convert.ToString(gvLedger.Rows[rowindex].Cells["LedgerHeaderId"].Value);
                    txtLedgernm.Text = Convert.ToString(gvLedger.Rows[rowindex].Cells["Ledger"].Value);
                    cbTypeLedger.SelectedItem = Convert.ToString(gvLedger.Rows[rowindex].Cells["LedgerType"].Value);
                    txtOpeningBalance.Text = Convert.ToString(gvLedger.Rows[rowindex].Cells["OpeningBalance"].Value);
                    _LedgerId = _Id;
                }
                else if (gvLedger.Columns[colindex].Name == "Delete")
                {
                    int _Id = Convert.ToInt32(gvLedger.Rows[rowindex].Cells["Id"].Value);
                    if (MessageBox.Show(string.Format(Messages.DeleteMsg, "Ledger"), Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Result<bool> _Result = _LedgerService.DeleteLedgerHeaderById(_Id, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                        if (_Result.IsSuccess)
                        {
                            DataRow[] _DataRow = _LedgerDataTable.Select("LedgerId=" + _Id);

                            if (_DataRow.Count() > 0)
                            {
                                _LedgerDataTable.Rows.Remove(_DataRow[0]);
                                _LedgerDataTable.AcceptChanges();
                            }

                            FillAutoSuggestLedger();
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

        private void gvLedger_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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

        private void FillLedgerDataTable()
        {
            Result<DataTable> _Result = _LedgerService.GetAllLedger(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _LedgerDataTable = _Result.Data;
            }
        }

        private void FillAutoSuggestLedger()
        {
            if (_LedgerDataTable != null)
            {
                AutoCompleteStringCollection _AutoComplete = new AutoCompleteStringCollection();

                string[] postSource = _LedgerDataTable
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("Ledger"))
                    .ToArray();

                _AutoComplete.AddRange(postSource);

                txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtSearch.AutoCompleteCustomSource = _AutoComplete;
            }
        }

        private void FillLeaderHeader()
        {
            Result<DataTable> _Result = _LedgerService.GetAllLedgerHeader(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbLedgerHeader.DataSource = _Result.Data;
                cbLedgerHeader.DisplayMember = "LedgerHeader";
                cbLedgerHeader.ValueMember = "LedgerHeaderID";
            }
        }
        //private void FillControls()
        //{

        //    if (_LedgerId != null)
        //    {
        //        Result<LedgerMaster> _Result = _LedgerService.GetLedgerById(_LedgerId.Value, Convert.ToString(Properties.Settings.Default.Year));

        //        if (_Result.IsSuccess)
        //        {
        //            cbLedgerHeader.SelectedValue = _Result.Data.LedgerHeaderID;
        //            cbTypeLedger.SelectedIndex = cbTypeLedger.FindString(_Result.Data.LedgerType);
        //            txtLedgernm.Text = _Result.Data.Ledger.ToString();
        //            txtOpeningBalance.Text = _Result.Data.OpeningBalance.ToString();


        //        }
        //    }
        //}
        private void FillGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvLedger.DataSource = null;
                gvLedger.Rows.Clear();

                DataTable _DataTable = _LedgerDataTable;

                if (_LedgerDataTable != null)
                {
                    if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                    {
                        string _Search = txtSearch.Text.Trim().ToLower();

                        EnumerableRowCollection<DataRow> _Query = from l in _LedgerDataTable.AsEnumerable()
                                                                  where l.Field<string>("LedgerHeader").ToLower().Contains(_Search) ||
                                                                  l.Field<string>("Ledger").ToLower().Contains(_Search) ||
                                                                  l.Field<string>("LedgerType").ToLower().Contains(_Search)
                                                                  select l;                       

                        _DataTable = _Query.AsDataView().ToTable();
                    }

                    if (_DataTable != null)
                    {
                        _TotalRecords = _DataTable.Rows.Count;
                    }

                    CommonFunction.GridPagging(_DataTable, _TotalRecords, gvLedger, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
                }
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool ValidateControl()
        {
            epLedger.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (cbLedgerHeader.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Ledger Header!";
                if (_Control == null)
                    _Control = cbLedgerHeader;
                _Result = false;
            }
            if (cbTypeLedger.SelectedItem == "Select")
            {
                _Message += "\n ---> Select Type Of Ledger!";
                if (_Control == null)
                    _Control = cbTypeLedger;
                _Result = false;
            }
            if (!Helper.CheckRequired(txtLedgernm.Text.Trim(), ref _Message, "Ledger"))
            {
                if (_Control == null)
                    _Control = txtLedgernm;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtOpeningBalance.Text.Trim(), ref _Message, "OpeningBalance"))
            {
                if (_Control == null)
                    _Control = txtOpeningBalance;
                _Result = false;
            }

            if (_Result)
            {
                Result<bool> _ResultData = _LedgerService.CheckDuplicateLedger(txtLedgernm.Text.Trim(), _LedgerId, Convert.ToString(Properties.Settings.Default.Year));

                if (_ResultData.IsSuccess)
                {
                    if (!_ResultData.Data)
                    {
                        _Result = true;
                    }
                    else
                    {
                        txtLedgernm.Select();
                        _Result = false;
                        _Message = string.Format(Messages.DuplicateMsg, "Ledger");
                        if (_Control == null)
                            _Control = txtLedgernm;
                    }
                }
                else
                {
                    txtLedgernm.Select();
                    _Result = false;
                    _Message = _ResultData.Message;
                    if (_Control == null)
                        _Control = txtLedgernm;
                }
            }

            return _Result;
        }

        private void ClearControl()
        {
            epLedger.Clear();
            cbLedgerHeader.SelectedIndex = 0;
            cbTypeLedger.SelectedIndex = 0;
            txtLedgernm.Text = string.Empty;
            txtOpeningBalance.Text = string.Empty;
            _LedgerId = null;
        }

        private void txtLedger_TextChanged(object sender, EventArgs e)
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

        private void txtOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void SaveLedger()
        {
            LedgerMaster _LedgerMaster = new LedgerMaster();

            _LedgerMaster.LedgerID = _LedgerId;
            _LedgerMaster.LedgerHeaderID = Convert.ToInt32(cbLedgerHeader.SelectedValue);
            _LedgerMaster.LedgerType = Convert.ToString(cbTypeLedger.SelectedItem);
            _LedgerMaster.Ledger = txtLedgernm.Text.Trim();
            _LedgerMaster.OpeningBalance = Convert.ToInt32(txtOpeningBalance.Text.Trim());
            _LedgerMaster.IsActive = true;

            Result<bool> _Result = _LedgerService.SaveLedger(_LedgerMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                switch (_PageId)
                {
                    case 0:
                        MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillLedgerDataTable();
                        FillAutoSuggestLedger();
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
