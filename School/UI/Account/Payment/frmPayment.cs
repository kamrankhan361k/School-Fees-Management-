using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;

namespace School.UI.Account.Payment
{
    public partial class frmPayment : Form
    {
        #region Variables

        private DepartmentService _DepartmentService = new DepartmentService();
        private LedgerService _LedgerService = new LedgerService();
        private VoucherService _VoucherService = new VoucherService();
        private Control _Control = null;
        private string _Message = "";
        private int? _PaymentVoucherId = null;

        #endregion


        #region Page events and constructor

        public frmPayment()
        {
            InitializeComponent();
        }

        public frmPayment(int p_PaymentVoucherId)
        {
            InitializeComponent();
            _PaymentVoucherId = p_PaymentVoucherId;

        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillDepartment();
            FillLedger();
            FillVoucherNo();
            FillCrediter();

            this.Cursor = Cursors.Default;
        }

        #endregion


        #region Control Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (ValidateControl())
                {
                    //SaveRecord();
                    SavePaymentVoucher();
                }
                else
                {   
                    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Control.Select();
                    epPayment.SetIconPadding(_Control, 10);
                    epPayment.SetError(_Control, Messages.RequiredMsg);
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

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //if (ValidateControl())
            //{
            //    if (MessageBox.Show("Are you sure you want print Journal Voucher details ?", Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        PrintReceipt();
            //    }
            //}
            //else
            //{
            //    this.Cursor = Cursors.Default;
            //    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    _Control.Select();
            //    epPayment.SetIconPadding(_Control, 10);
            //    epPayment.SetError(_Control, Messages.RequiredMsg);
            //}
        }

        private void txtDrAmount_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDrAmount.Text))
            {
                txtDrTotal.Text = txtDrAmount.Text;
            }
        }

        private void txtDrAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCrAmount_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCrAmount.Text))
            {
                txtCrTotal.Text = txtCrAmount.Text;
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
            if (!string.IsNullOrEmpty(txtDrAmount.Text))
            {
                txtCrAmount.Text = txtDrAmount.Text;
                txtCrTotal.Text = txtDrTotal.Text = txtDrAmount.Text;
            }
            else
            {
                txtCrTotal.Text = txtDrTotal.Text = txtDrAmount.Text = txtCrAmount.Text = string.Empty;
            }
        }

        private void txtCrAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCrAmount.Text))
            {
                txtDrAmount.Text = txtCrAmount.Text;
                txtCrTotal.Text = txtDrTotal.Text = txtCrAmount.Text;
            }
            else
            {
                txtCrTotal.Text = txtDrTotal.Text = txtDrAmount.Text = txtCrAmount.Text = string.Empty;
            }
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
                cbDepartmentnm.DataSource = _Result.Data;
                cbDepartmentnm.DisplayMember = "Department";
                cbDepartmentnm.ValueMember = "DepartmentID";
            }
        }

        private void FillLedger()
        {
            Result<DataTable> _Result = _LedgerService.GetAllLedgerForDDL(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "--Select--";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbDr.DataSource = _Result.Data;
                cbDr.DisplayMember = "Ledger";
                cbDr.ValueMember = "LedgerID";

                cbCr.DataSource = _Result.Data;
                cbCr.DisplayMember = "Ledger";
                cbCr.ValueMember = "LedgerID";
            }

        }

        private void SavePaymentVoucher()
        {
            PaymentVoucher _DebitPaymentVoucher = new PaymentVoucher();

            _DebitPaymentVoucher.DepartmentId = Convert.ToInt32(cbDepartmentnm.SelectedValue);
            _DebitPaymentVoucher.VoucherNo = Convert.ToString(txtVoucherNo.Text);
            _DebitPaymentVoucher.DebitorID = Convert.ToInt32(cbDr.SelectedValue);
            _DebitPaymentVoucher.CreditorID = 0;
            _DebitPaymentVoucher.DrAmount = Convert.ToInt32(txtDrAmount.Text);
            _DebitPaymentVoucher.CrAmount = 0;
            _DebitPaymentVoucher.PaymentTo = txtPayment.Text;
            _DebitPaymentVoucher.Narration = txtNarration.Text;

            PaymentVoucher _CreditPaymentVoucher = new PaymentVoucher();

            _CreditPaymentVoucher.DepartmentId = Convert.ToInt32(cbDepartmentnm.SelectedValue);
            _CreditPaymentVoucher.VoucherNo = Convert.ToString(txtVoucherNo.Text);
            _CreditPaymentVoucher.DebitorID = 0;
            _CreditPaymentVoucher.CreditorID = GetCreditorID(cbCr.SelectedValue.ToString());
            _CreditPaymentVoucher.CrAmount = Convert.ToInt32(txtCrAmount.Text);
            _CreditPaymentVoucher.DrAmount = 0;
            _CreditPaymentVoucher.PaymentTo = txtPayment.Text;
            _CreditPaymentVoucher.Narration = txtNarration.Text;

            List<PaymentVoucher> _ListPaymentVoucher = new List<PaymentVoucher>();
            _ListPaymentVoucher.Add(_DebitPaymentVoucher);
            _ListPaymentVoucher.Add(_CreditPaymentVoucher);

            Result<bool> _Result = _VoucherService.SavePaymentVoucher(_ListPaymentVoucher, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls();
            }
            else
            {
                MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCreditorID(string p_Type)
        {
            if (p_Type == PaymentType.Cash.ToString())
            {
                return Convert.ToInt32(PaymentType.Cash);
            }
            else if (p_Type == PaymentType.Bank.ToString())
            {
                return Convert.ToInt32(PaymentType.Bank);
            }
            else
            {
                return Convert.ToInt32(PaymentType.Waiver);
            }
        }

        private void ClearControls()
        {
            epPayment.Clear();

            cbDepartmentnm.SelectedIndex = 0;
            cbDr.SelectedIndex = 0;
            cbCr.SelectedIndex = 0;
            txtDrTotal.Text = string.Empty;
            txtDrAmount.Text = string.Empty;
            txtCrTotal.Text = string.Empty;
            txtCrAmount.Text = string.Empty;
            txtPayment.Text = string.Empty;
            txtNarration.Text = string.Empty;
            FillVoucherNo();
        }

        private bool ValidateControl()
        {
            epPayment.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (cbDepartmentnm.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Department!";
                if (_Control == null)
                    _Control = cbDepartmentnm;
                _Result = false;
            }
            if (!Helper.CheckRequired(txtVoucherNo.Text.Trim(), ref _Message, "Voucher No."))
            {
                if (_Control == null)
                    _Control = txtVoucherNo;
                _Result = false;
            }
            if (cbDr.SelectedIndex <= 0)
            {
                _Message += "\n--> Select Dr!";
                if (_Control == null)
                    _Control = cbDr;
                _Result = false;
            }
            if (cbCr.SelectedIndex <= 0)
            {
                _Message += "\n--> Select Cr!";
                if (_Control == null)
                    _Control = cbCr;
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
            if (!Helper.CheckRequired(txtPayment.Text.Trim(), ref _Message, "Payment To"))
            {
                if (_Control == null)
                    _Control = txtPayment;
                _Result = false;
            }
            if (!Helper.CheckRequired(txtNarration.Text.Trim(), ref _Message, "Narration"))
            {
                if (_Control == null)
                    _Control = txtNarration;
                _Result = false;
            }
            if (_Result && txtDrTotal.Text != txtCrAmount.Text)
            {
                _Control = txtCrTotal;
                _Message = "Debit amount and Credit amount should be same.";
                _Result = false;
            }
            return _Result;
        }

        private void FillVoucherNo()
        {
            try
            {
                Result<string> _VoucherNoResult = _VoucherService.GetVoucherNo(Convert.ToString(VoucherPrefix.PV), Convert.ToString(Properties.Settings.Default.Year), Convert.ToString(VoucherID.PaymentVoucherId), Convert.ToString(TableType.PaymentVoucher));

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

        private void FillCrediter()
        {
            List<Item> _CreditorList = new List<Item>();
            _CreditorList.Insert(0, new Item() { Text = "-- Select --", Other = "" });
            _CreditorList.Insert(1, new Item() { Text = "Cash", Other = "Cash" });
            _CreditorList.Insert(2, new Item() { Text = "Bank", Other = "Bank" });
            _CreditorList.Insert(2, new Item() { Text = "Waive", Other = "Waive" });

            cbCr.DataSource = _CreditorList;
            cbCr.DisplayMember = "Text";
            cbCr.ValueMember = "Other";
        }

        #endregion        
    }
}
