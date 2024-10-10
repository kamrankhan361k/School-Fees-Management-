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

namespace School.UI.Account.Contra
{
    public partial class frmContra : Form
    {
        #region Variables

        private DepartmentService _DepartmentService = new DepartmentService();
        //private DivisionService _DivisionService = new DivisionService();
        //private StandardService _StandardService = new StandardService();
        private LedgerService _LedgerService = new LedgerService();
        private VoucherService _VoucherService = new VoucherService();
        private Control _Control = null;
        private string _Message = "";

        #endregion


        #region Page events and constructor

        public frmContra()
        {
            InitializeComponent();
        }

        private void frmContra_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillDepartment();
            FillVoucherNo();
            FillDebitorAndCreditor();
            lblDateValue.Text = DateTime.Now.ToShortDateString();

            this.Cursor = Cursors.Default;
        }

        

        #endregion


        #region Control Events

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
                epContra.SetIconPadding(_Control, 10);
                epContra.SetError(_Control, Messages.RequiredMsg);
            }
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (ValidateControl())
            {
                if (MessageBox.Show("Are you sure you want print Journal Voucher details ?", Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (SaveRecord())
                    {
                        PrintReceipt();
                    }
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Control.Select();
                epContra.SetIconPadding(_Control, 10);
                epContra.SetError(_Control, Messages.RequiredMsg);
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
            if (!string.IsNullOrEmpty(txtDrAmount.Text))
            {
                txtDrTotal.Text = txtCrAmount.Text = txtCrTotal.Text =  txtDrAmount.Text;
            }
            else
            {
                txtDrTotal.Text = txtCrAmount.Text = txtCrTotal.Text = txtDrAmount.Text = string.Empty;
            }
        }

        private void txtCrAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCrAmount.Text))
            {
                txtCrTotal.Text = txtDrAmount.Text = txtDrTotal.Text = txtCrAmount.Text;
            }
            else
            {
                txtCrTotal.Text = txtDrAmount.Text = txtDrTotal.Text = txtCrAmount.Text = string.Empty;
            }
        }

        private void cbDr_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCr.Text = ChangeSelection(cbDr.SelectedValue.ToString());
        }

        private void cbCr_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDr.Text = ChangeSelection(cbCr.SelectedValue.ToString());
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

        private void FillDebitorAndCreditor()
        {
            List<Item> _CreditorList = new List<Item>();
            _CreditorList.Insert(0, new Item() { Text = "-- Select --", Other = "" });
            _CreditorList.Insert(1, new Item() { Text = "Cash", Other = "Cash" });
            _CreditorList.Insert(2, new Item() { Text = "Bank", Other = "Bank" });

            cbCr.DataSource = _CreditorList;
            cbCr.DisplayMember = "Text";
            cbCr.ValueMember = "Other";

            cbDr.BindingContext = new BindingContext();
            cbDr.DataSource = _CreditorList;
            cbDr.DisplayMember = "Text";
            cbDr.ValueMember = "Other";
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
                cbDr.DataSource = _Result.Data;
                cbDr.DisplayMember = "Ledger";
                cbDr.ValueMember = "LedgerID";

            }
        }

        private bool ValidateControl()
        {
            epContra.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (cbDepartmentnm.SelectedIndex <= 0)
            {
                _Message += "\n ----> Select Department!";
                if (_Control == null)
                    _Control = cbDepartmentnm;
                _Result = false;
            }
            //if (cbStandard.SelectedIndex <= 0)
            //{
            //    _Message += "\n----> Select Standard!";
            //    if (_Control == null)
            //        _Control = cbStandard;
            //    _Result = false;
            //}
            //if (cbDivision.SelectedIndex <= 0)
            //{
            //    _Message += "\n----> Select Division!";
            //    if (_Control == null)
            //        _Control = cbDivision;
            //    _Result = false;
            //}
            if (!Helper.CheckRequired(txtVoucherNo.Text.Trim(), ref _Message, "Voucher No."))
            {
                if (_Control == null)
                    _Control = txtVoucherNo;
                _Result = false;
            }
            if (cbDr.SelectedIndex <= 0)
            {
                _Message += "\n----> Select Dr!";
                if (_Control == null)
                    _Control = cbDr;
                _Result = false;
            }
            if (cbCr.SelectedItem == "Select")
            {
                _Message += "\n----> Select Cr!";
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
            return _Result;
        }

        private bool SaveContraVoucher()
        {
            ContraVouncher _DebitContraVouncher = new ContraVouncher();
            
            _DebitContraVouncher.DepartmentID = Convert.ToInt32(cbDepartmentnm.SelectedValue);
            _DebitContraVouncher.VoucherNo = txtVoucherNo.Text;
            _DebitContraVouncher.DebitorID = GetTypeID(cbDr.SelectedValue.ToString());
            _DebitContraVouncher.CreditorID = GetTypeID(cbCr.SelectedValue.ToString());
            _DebitContraVouncher.DrAmount = Convert.ToInt32(txtDrAmount.Text);
            _DebitContraVouncher.CrAmount = 0;
            _DebitContraVouncher.PaymentBy = txtPayment.Text;
            _DebitContraVouncher.Narration = txtNarration.Text;

            ContraVouncher _CreditContraVouncher = new ContraVouncher();

            _CreditContraVouncher.DepartmentID = Convert.ToInt32(cbDepartmentnm.SelectedValue);
            _CreditContraVouncher.VoucherNo = txtVoucherNo.Text;
            _CreditContraVouncher.DebitorID = GetTypeID(cbDr.SelectedValue.ToString());
            _CreditContraVouncher.CreditorID = GetTypeID(cbCr.SelectedValue.ToString());
            _CreditContraVouncher.DrAmount = 0;
            _CreditContraVouncher.CrAmount = Convert.ToInt32(txtCrAmount.Text);
            _CreditContraVouncher.PaymentBy = txtPayment.Text;
            _CreditContraVouncher.Narration = txtNarration.Text;

            List<ContraVouncher> _ListContraVouncher = new List<ContraVouncher>();
            _ListContraVouncher.Add(_DebitContraVouncher);
            _ListContraVouncher.Add(_CreditContraVouncher);

            Result<bool> _Result = _VoucherService.SaveContraVoucher(_ListContraVouncher, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                FillVoucherNo();
                ClearControl();               

                return true;
            }
            else
            {
                MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void ClearControl()
        {
            cbDepartmentnm.SelectedIndex = 0;
            cbDr.SelectedIndex = 0;
            cbCr.SelectedIndex = 0;
            txtPayment.Text = string.Empty;
            txtNarration.Text = string.Empty;
            txtDrAmount.Text = string.Empty;
            txtDrTotal.Text= string.Empty;
            txtCrAmount.Text= string.Empty;
            txtCrTotal.Text= string.Empty;
        }

        private void FillVoucherNo()
        {
            try
            {
                Result<string> _VoucherNoResult = _VoucherService.GetVoucherNo(Convert.ToString(VoucherPrefix.CV), Convert.ToString(Properties.Settings.Default.Year), Convert.ToString(VoucherID.ContraVoucherId), Convert.ToString(TableType.ContraVoucher));

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

        private bool SaveRecord()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want save Contra Voucher detail ?", Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(SaveContraVoucher())
                    {
                        this.Cursor = Cursors.Default;
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

        private int GetTypeID(string p_Type)
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
        
        private string ChangeSelection(string p_selectedValue)
        {
            if (p_selectedValue == PaymentType.Bank.ToString())
            {
                return PaymentType.Cash.ToString();
            }
            else
            {
                return PaymentType.Bank.ToString();
            }
        }

        #endregion        
    }
}
