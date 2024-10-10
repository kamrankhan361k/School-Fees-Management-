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

namespace School.UI.Account.Journal
{
    public partial class frmJournal : Form
    {
        #region Variables

        private DepartmentService _DepartmentService = new DepartmentService();
        private LedgerService _LedgerService = new LedgerService();
        private VoucherService _VoucherService = new VoucherService();
        private Control _Control = null;
        private string _Message = "";

        #endregion


        #region Page events and constructor

        public frmJournal()
        {
            InitializeComponent();
        }

        private void frmJournal_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillDepartment();
            FillLedger();
            FillVoucherNo();
          
            cbDrDepartmentnm.Focus();

            this.Cursor = Cursors.Default;
        }        

        #endregion


        #region Button Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (ValidateControl())
            {
                SaveRecord();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Control.Select();
                epJournal.SetIconPadding(_Control, 10);
                epJournal.SetError(_Control, Messages.RequiredMsg);
            }
        }
        
        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //if (ValidateControl())
            //{ 
            //    if (MessageBox.Show("Are you sure you want print Journal Voucher details ?", Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {

            //        if (SaveRecord())
            //        {
            //            PrintReceipt();
            //        }
            //    }
            //}
            //else
            //{
            //    this.Cursor = Cursors.Default;
            //    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    _Control.Select();
            //    epJournal.SetIconPadding(_Control, 10);
            //    epJournal.SetError(_Control, Messages.RequiredMsg);
            //}
        }

        private void txtDrAmount_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDrAmount.Text))
            {
                txtDrTotalAmount.Text = txtDrAmount.Text;
            }
        }

        private void txtCrAmount_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCrAmount.Text))
            {
                txtCrTotalAmount.Text = txtCrAmount.Text;
            }
        }

        private void txtDrAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCrAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDrAmount_KeyUp(object sender, KeyEventArgs e)
        {
            txtCrAmount.Text = txtCrTotalAmount.Text = txtDrTotalAmount.Text = txtDrAmount.Text;
        }

        private void txtCrAmount_KeyUp(object sender, KeyEventArgs e)
        {
            txtCrTotalAmount.Text = txtDrTotalAmount.Text = txtDrAmount.Text = txtCrAmount.Text;
        }

        #endregion


        #region Private Methods

        private void FillDepartment()
        {
            Result<DataTable> _Result = _DepartmentService.GetAllDepartment(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbDrDepartmentnm.DataSource = _Result.Data;
                cbDrDepartmentnm.DisplayMember = "Department";
                cbDrDepartmentnm.ValueMember = "DepartmentID";

                cbCrDepartmentnm.BindingContext = new BindingContext();
                cbCrDepartmentnm.DataSource = _Result.Data;
                cbCrDepartmentnm.DisplayMember = "Department";
                cbCrDepartmentnm.ValueMember = "DepartmentID";
            }
        }
        
        private void FillLedger()
        {
            Result<DataTable> _Result = _LedgerService.GetAllLedger(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "--Select--";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbDrLedger.DataSource = _Result.Data;
                cbDrLedger.DisplayMember = "Ledger";
                cbDrLedger.ValueMember = "LedgerID";

                cbCr.BindingContext = new BindingContext();
                cbCr.DataSource = _Result.Data;
                cbCr.DisplayMember = "Ledger";
                cbCr.ValueMember = "LedgerID";
            }

        }
        
        private void FillVoucherNo()
        {
            try
            {
                Result<string> _VoucherNoResult = _VoucherService.GetVoucherNo(Convert.ToString(VoucherPrefix.JV), Convert.ToString(Properties.Settings.Default.Year), Convert.ToString(VoucherID.JournalVoucherId), Convert.ToString(TableType.JournalVoucher));

                if (_VoucherNoResult.IsSuccess)
                {
                    txtVoucherNo.Text = _VoucherNoResult.Data;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveJournalVoucher()
        {
            JournalVoucher _DebitJournalVoucher = new JournalVoucher();
            
            _DebitJournalVoucher.VoucherNo = Convert.ToString(txtVoucherNo.Text);
            _DebitJournalVoucher.DrDepartmentID = Convert.ToInt32(cbDrLedger.SelectedValue);
            _DebitJournalVoucher.DrAmount = Convert.ToInt32(txtDrAmount.Text);
            _DebitJournalVoucher.CrDepartmentID = Convert.ToInt32(cbCr.SelectedValue);
            _DebitJournalVoucher.CrAmount = 0;
            _DebitJournalVoucher.DrLedgerID = Convert.ToInt32(cbDrDepartmentnm.SelectedValue);
            _DebitJournalVoucher.CrLedgerID = Convert.ToInt32(cbCrDepartmentnm.SelectedValue);
            _DebitJournalVoucher.Narration = txtNarration.Text;

            JournalVoucher _CreditJournalVoucher = new JournalVoucher();

            _CreditJournalVoucher.VoucherNo = Convert.ToString(txtVoucherNo.Text);
            _CreditJournalVoucher.DrDepartmentID = Convert.ToInt32(cbDrLedger.SelectedValue);
            _CreditJournalVoucher.DrAmount = 0;
            _CreditJournalVoucher.CrDepartmentID = Convert.ToInt32(cbCr.SelectedValue);
            _CreditJournalVoucher.CrAmount = Convert.ToInt32(txtCrAmount.Text);
            _CreditJournalVoucher.DrLedgerID = Convert.ToInt32(cbDrDepartmentnm.SelectedValue);
            _CreditJournalVoucher.CrLedgerID = Convert.ToInt32(cbCrDepartmentnm.SelectedValue);
            _CreditJournalVoucher.Narration = txtNarration.Text;

            List<JournalVoucher> _ListOfJournalVoucher = new List<JournalVoucher>();
            _ListOfJournalVoucher.Add(_DebitJournalVoucher);
            _ListOfJournalVoucher.Add(_CreditJournalVoucher);

            VoucherBalanceSheet _VoucherBalanceSheet = new VoucherBalanceSheet();
            _VoucherBalanceSheet.Cr = 0;
            _VoucherBalanceSheet.Dr = Convert.ToDouble(txtDrAmount.Text);
            _VoucherBalanceSheet.Particular = cbDrLedger.SelectedText;
            _VoucherBalanceSheet.VoucherNumber = txtVoucherNo.Text;

            Result<bool> _Result = _VoucherService.SaveJournalVoucher(_ListOfJournalVoucher, _VoucherBalanceSheet, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                return true;
            }
            else
            {
                MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool ValidateControl()
        {
            bool _Result = true;
            try
            {
                epJournal.Clear();

                _Control = null;
                _Message = Messages.ErrorMsgTitle;

                if (!Helper.CheckRequired(txtVoucherNo.Text.Trim(), ref _Message, "Voucher No."))
                {
                    if (_Control == null)
                        _Control = txtVoucherNo;
                    _Result = false;
                }
                if (cbDrDepartmentnm.SelectedIndex <= 0)
                {
                    _Message += "\n ----> Select Debit Department!";
                    if (_Control == null)
                        _Control = cbDrDepartmentnm;
                    _Result = false;
                }
                if (cbDrLedger.SelectedIndex <= 0)
                {
                    _Message += "\n----> Select Debit Ledger!";
                    if (_Control == null)
                        _Control = cbDrLedger;
                    _Result = false;
                }
                if (cbCrDepartmentnm.SelectedIndex <= 0)
                {
                    _Message += "\n----> Select Credit Department!";
                    if (_Control == null)
                        _Control = cbCrDepartmentnm;
                    _Result = false;
                }

                if (cbCr.SelectedIndex <= 0)
                {
                    _Message += "\n----> Select Credit Ledger!";
                    if (_Control == null)
                        _Control = cbCr;
                    _Result = false;
                }
                if (!Helper.CheckRequired(txtNarration.Text.Trim(), ref _Message, "Narration"))
                {
                    if (_Control == null)
                        _Control = txtNarration;
                    _Result = false;
                }
                if (!Helper.CheckRequired(txtDrAmount.Text.Trim(), ref _Message, "Dr Amount"))
                {
                    if (_Control == null)
                        _Control = txtDrAmount;
                    _Result = false;
                }
                if (!Helper.CheckRequired(txtCrAmount.Text.Trim(), ref _Message, "Cr Amount"))
                {
                    if (_Control == null)
                        _Control = txtCrAmount;
                    _Result = false;
                }
            }
            catch (Exception)
            {
                _Result = false;
            }
            return _Result;
        }

        private bool SaveRecord()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want save Journal Voucher details ?", Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SaveJournalVoucher())
                    {
                        this.Cursor = Cursors.Default;
                        FillVoucherNo();
                        ClearControl();
                        MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }                   
                }
            }
            catch
            {
                MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            return false;
        }

        private void ClearControl()
        {
            cbDrDepartmentnm.SelectedIndex = 0;
            cbDrLedger.SelectedIndex = 0;
            cbCrDepartmentnm.SelectedIndex = 0;
            cbCr.SelectedIndex = 0;
            txtCrAmount.Text = txtCrTotalAmount.Text = txtDrTotalAmount.Text = txtDrAmount.Text = txtNarration.Text = string.Empty;
        }

        private void PrintReceipt()
        {
            Result<DataTable> _Result = _VoucherService.GetVoucherByVoucherNo(Convert.ToInt32(txtVoucherNo.Text), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                LocalReport report = new LocalReport();
                report.ReportEmbeddedResource = "School.UI.Report.PaymentVoucherReceipt.rdlc";
                report.DataSources.Add(new ReportDataSource("DataSet", _Result.Data));

                PrintFunction _PrintFunction = new PrintFunction();

                _PrintFunction.Export(report);
                _PrintFunction.Print();
            }
        }

        #endregion      
    }
}
