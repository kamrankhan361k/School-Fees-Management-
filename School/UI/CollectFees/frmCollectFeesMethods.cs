using School.Common;
using School.DataAccess;
using School.DataModel;
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
    public partial class frmCollectFeesMethods : Form
    {

        #region Variables

        private Control _Control = null;
        private CollectFeesService _CollectFeesService = new CollectFeesService();
        public List<ReceiptDetail> _ListOfReceiptDetail = new List<ReceiptDetail>();
        private int _ReceiptID = 0;
        private double _Amount = 0;
        private string _Message = "";

        #endregion

        #region Page events and constructor

        public frmCollectFeesMethods(double p_Amount)
        {
            InitializeComponent();
            this._Amount = p_Amount;
            pnlBank.Visible = false;
            pnlWaiver.Visible = false;
        }


        #endregion

        #region Button Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ValidateControl())

            //    {


            //        if (!string.IsNullOrEmpty(txtBank.Text) && Convert.ToInt32(txtBank.Text) > 0)
            //        {
            //            ReceiptDetail _BankReceiptDetail = new ReceiptDetail();
            //            _BankReceiptDetail.ReceiptID = _ReceiptID;
            //            _BankReceiptDetail.PaymentType = Convert.ToInt32(Helper.GetEnumDescription(PaymentType.Bank));
            //            _BankReceiptDetail.Amount = Convert.ToInt32(txtBank.Text);
            //            _BankReceiptDetail.BankName = txtBankName.Text;
            //            _BankReceiptDetail.BranchName = txtBranchName.Text;
            //            _BankReceiptDetail.AccountNumber = txtAccountNumber.Text;
            //            _BankReceiptDetail.WaiverReason = string.Empty;
            //            this._ListOfReceiptDetail.Add(_BankReceiptDetail);
            //        }

            //        if (!string.IsNullOrEmpty(txtWayOff.Text) && Convert.ToInt32(txtWayOff.Text) > 0)
            //        {
            //            ReceiptDetail _WaiverReceiptDetail = new ReceiptDetail();
            //            _WaiverReceiptDetail.ReceiptID = _ReceiptID;
            //            _WaiverReceiptDetail.PaymentType = Convert.ToInt32(Helper.GetEnumDescription(PaymentType.Waiver)); 
            //            _WaiverReceiptDetail.Amount = Convert.ToInt32(txtWayOff.Text);
            //            _WaiverReceiptDetail.BankName = string.Empty;
            //            _WaiverReceiptDetail.BranchName = string.Empty;
            //            _WaiverReceiptDetail.AccountNumber = string.Empty;
            //            _WaiverReceiptDetail.WaiverReason = txtWaiverReason.Text;
            //            this._ListOfReceiptDetail.Add(_WaiverReceiptDetail);
            //        }
            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        epCollectFeesMethods.SetIconPadding(_Control, 10);
            //        epCollectFeesMethods.SetError(_Control, Messages.RequiredMsg);
            //    }
            //}
            //catch (Exception)
            //{

            //}
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtWayOff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBank_KeyUp(object sender, KeyEventArgs e)
        {
            double _BankAmount;

            try
            {
                double.TryParse(txtBank.Text, out _BankAmount);

                if (_BankAmount > 0)
                {
                    pnlBank.Visible = true;
                }
                else
                {
                    pnlBank.Visible = false;
                    txtBankName.Text = string.Empty;
                    txtBranchName.Text = string.Empty;
                    txtAccountNumber.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtWayOff_KeyUp(object sender, KeyEventArgs e)
        {
            double _WaiverAmount;

            double.TryParse(txtWayOff.Text, out _WaiverAmount);

            if (_WaiverAmount > 0)
            {
                pnlWaiver.Visible = true;
            }
            else
            {
                pnlWaiver.Visible = false;
                txtWaiverReason.Text = string.Empty;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBank.Text = string.Empty;
            //txtCash.Text = string.Empty;
            txtWayOff.Text = string.Empty;

            txtBankName.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtAccountNumber.Text = string.Empty;
            txtWaiverReason.Text = string.Empty;
            pnlBank.Visible = false;
            pnlWaiver.Visible = false;
            epCollectFeesMethods.Clear();
            //txtCash.Focus();
            this.DialogResult = DialogResult.None;
        }

        #endregion

        #region Private Methods

        private bool ValidateControl()
        {

            epCollectFeesMethods.Clear();
            _Message = Messages.ErrorMsgTitle;
            bool _Isvalid = true;
            _Control = null;
            double _BankAmount, _WaiverAmount, _TotalAmount;

            double.TryParse(txtBank.Text, out _BankAmount);
           // double.TryParse(txtCash.Text, out _CashAmount);
            double.TryParse(txtWayOff.Text, out _WaiverAmount);

            _TotalAmount =   _BankAmount + _WaiverAmount;

            if (_BankAmount > 0)
            {
                if (!Helper.CheckRequired(txtBankName.Text.Trim(), ref _Message, "Bank Name"))
                {
                    if (_Control == null)
                        _Control = txtBankName;
                    _Isvalid = false;
                }
                if (!Helper.CheckRequired(txtBranchName.Text.Trim(), ref _Message, "Branch Name"))
                {
                    if (_Control == null)
                        _Control = txtBranchName;
                    _Isvalid = false;
                }
                if (!Helper.CheckRequired(txtAccountNumber.Text.Trim(), ref _Message, "Account Number"))
                {
                    if (_Control == null)
                        _Control = txtAccountNumber;
                    _Isvalid = false;
                }
            }

            if (_WaiverAmount > 0)
            {
                if (!Helper.CheckRequired(txtWaiverReason.Text.Trim(), ref _Message, "Waiver Reason"))
                {
                    if (_Control == null)
                        _Control = txtWaiverReason;
                    _Isvalid = false;
                }
            }

            //if (_Isvalid)
            //{
            //    if (_Amount !=_TotalAmount)
            //    {
            //        _Message += "\n ---> please enter valid total amount("+_Amount+")";
            //        _Isvalid = false;
            //    }
            //    else
            //    {
            //        _Isvalid = true;
            //    }
            //}

            return _Isvalid;
        }
        private void FillPendingFees()
        {
            //gvPendingFees.DataSource = null;
            //gvPendingFees.Rows.Clear();

            //Result<DataTable> _Result = _CollectFeesService.GetAllPendingFees(Convert.ToInt32(cbStudent.SelectedValue), _IsOtherFees, Convert.ToString(Properties.Settings.Default.Year));

            //if (_Result.IsSuccess)
            //{
            //    if (_Result.Data != null)
            //    {
            //        //gvPendingFees.DataSource = _Result.Data;

            //        object sumObject;
            //        sumObject = _Result.Data.Compute("Sum(PendingFees)", "");

            //        lblTotalPendingFees.Text = Convert.ToString(sumObject);
                }
               #endregion
    }
}
