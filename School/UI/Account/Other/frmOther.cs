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
using Microsoft.Reporting.WinForms;

namespace School.UI.Account.Other
{
    public partial class frmOther : Form
    {
        #region Variables

        private DepartmentService _DepartmentService = new DepartmentService();
        private LedgerService _LedgerService = new LedgerService();
        private VoucherService _VoucherService = new VoucherService();
        private Control _Control = null;
        private string _Message = "";
        private int? _OtherReceiptVouncher = null;

        #endregion

        #region Page events and constructor
        public frmOther()
        {
            InitializeComponent();
        }
        private void frmOther_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillDepartment();
            //FillLedger();
            FillVoucherNo();
            FillCr();
           
            this.Cursor = Cursors.Default;
        }

        
        #endregion

        #region Control Event
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
                epOther.SetIconPadding(_Control, 10);
                epOther.SetError(_Control, Messages.RequiredMsg);
            }
        }       

        private void txtCrAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private void txtDrAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
            //    epOther.SetIconPadding(_Control, 10);
            //    epOther.SetError(_Control, Messages.RequiredMsg);
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCrAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCrAmount.Text))
            {
                txtDrTotal.Text = txtDrAmount.Text = txtCrTotal.Text = txtCrAmount.Text;
            }
            else
            {
                txtDrTotal.Text = txtCrAmount.Text = txtCrTotal.Text = txtDrAmount.Text = string.Empty;
            }
        }

        private void txtDrAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDrAmount.Text))
            {
                txtDrTotal.Text = txtCrAmount.Text = txtCrTotal.Text = txtDrAmount.Text;
            }
            else
            {
                txtDrTotal.Text = txtCrAmount.Text = txtCrTotal.Text = txtDrAmount.Text = string.Empty;
            }
        }

        #endregion

        #region Private Method

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
            Result<DataTable> _ResultDr = _LedgerService.GetAllLedger(Convert.ToString(Properties.Settings.Default.Year));

            if (_ResultDr.IsSuccess)
            {
                DataRow _DataRow = _ResultDr.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _ResultDr.Data.Rows.InsertAt(_DataRow, 0);
                cbDr1.DataSource = _ResultDr.Data;
                cbDr1.DisplayMember = "Ledger";
                cbDr1.ValueMember = "LedgerID";                
            }           
        }

        private void FillCr()
        {
            Result<DataTable> _Result = _LedgerService.GetAllLedger(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                
                cbCr1.DataSource = _Result.Data;
                cbCr1.DisplayMember = "Ledger";
                cbCr1.ValueMember = "LedgerID";
            }
        }

        private void FillVoucherNo()
        {
            try
            {
                Result<string> _VoucherNoResult = _VoucherService.GetVoucherNo(Convert.ToString(VoucherPrefix.OR), Convert.ToString(Properties.Settings.Default.Year), Convert.ToString(VoucherID.OtherReceiptId), Convert.ToString(TableType.OtherReceiptVoucher));

                if (_VoucherNoResult.IsSuccess)
                {
                    txtReceiptNo.Text = _VoucherNoResult.Data;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveOtherReceiptVoucher()
        {
            List<OtherReceipt> _ListOfOtherReceipt = new List<OtherReceipt>();

             OtherReceipt _CreditOtherReceipt = new OtherReceipt();

            _CreditOtherReceipt.DepartmentId = Convert.ToInt32(cbDepartmentnm.SelectedValue);
            _CreditOtherReceipt.VoucherNo = Convert.ToString(txtReceiptNo.Text);
            _CreditOtherReceipt.DebitorID = 0;
            _CreditOtherReceipt.CreditorID = Convert.ToInt32(cbCr1.SelectedValue);
            _CreditOtherReceipt.DrAmount = 0;
            _CreditOtherReceipt.CrAmount = Convert.ToInt32(txtCrAmount.Text);
            _CreditOtherReceipt.ReceiveFrom = txtReceiveFrom.Text;
            _CreditOtherReceipt.Narration = txtNarration.Text;

             OtherReceipt _DebitOtherReceipt = new OtherReceipt();

            _DebitOtherReceipt.DepartmentId = Convert.ToInt32(cbDepartmentnm.SelectedValue);
            _DebitOtherReceipt.VoucherNo = Convert.ToString(txtReceiptNo.Text);
            _DebitOtherReceipt.DebitorID = Convert.ToInt32(cbDr1.SelectedValue);
            _DebitOtherReceipt.CreditorID = 0;
            _DebitOtherReceipt.DrAmount = Convert.ToInt32(txtDrAmount.Text);
            _DebitOtherReceipt.CrAmount = 0;
            _DebitOtherReceipt.ReceiveFrom = txtReceiveFrom.Text;
            _DebitOtherReceipt.Narration = txtNarration.Text;

            _ListOfOtherReceipt.Add(_CreditOtherReceipt);
            _ListOfOtherReceipt.Add(_DebitOtherReceipt);

            Result<bool> _Result = _VoucherService.SaveOtherReceiptVoucher(_ListOfOtherReceipt, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));
            
            if (_Result.IsSuccess)
            {
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
            cbCr1.SelectedIndex = 0;
            cbDr1.SelectedIndex = 0;
            txtReceiveFrom.Text = "";
            txtNarration.Text = "";
            txtCrAmount.Text = "";
            txtDrAmount.Text = "";
            txtCrTotal.Text = "";
            txtDrTotal.Text = "";
            FillVoucherNo();
        }

        private bool ValidateControl()
        {
            epOther.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (cbDepartmentnm.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Department!";
                if (_Control == null)
                    _Control = cbDepartmentnm;
                _Result = false;
            }
            if (!Helper.CheckRequired(txtReceiptNo.Text.Trim(), ref _Message, "Receipt No."))
            {
                if (_Control == null)
                    _Control = txtReceiptNo;
                _Result = false;
            }
            if (cbDr1.SelectedIndex <= 0)
            {
                _Message += "\n--> Select Dr!";
                if (_Control == null)
                    _Control = cbDr1;
                _Result = false;
            }
            if (cbCr1.SelectedIndex <= 0)
            {
                _Message += "\n--> Select Cr!";
                if (_Control == null)
                    _Control = cbCr1;
                _Result = false;
            }
            if (!Helper.CheckRequired(txtCrAmount.Text.Trim(), ref _Message, "Dr Amount"))
            {
                if (_Control == null)
                    _Control = txtCrAmount;
                _Result = false;
            }
            if (!Helper.CheckRequired(txtDrAmount.Text.Trim(), ref _Message, "Cr Amount"))
            {
                if (_Control == null)
                    _Control = txtDrAmount;
                _Result = false;
            }
            if (!Helper.CheckRequired(txtReceiveFrom.Text.Trim(), ref _Message, "Payment To"))
            {
                if (_Control == null)
                    _Control = txtReceiveFrom;
                _Result = false;
            }
            if (!Helper.CheckRequired(txtNarration.Text.Trim(), ref _Message, "Narration"))
            {
                if (_Control == null)
                    _Control = txtNarration;
                _Result = false;
            }
            if (_Result && txtCrAmount.Text != txtDrAmount.Text)
            {
                _Control = txtDrTotal;
                _Message = "Debit amount and Credit amount should be same.";
                _Result = false;
            }
            return _Result;
        }

        private bool SaveRecord()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want save Other Receipt Voucher detail ?", Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SaveOtherReceiptVoucher())
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                    //frmMaster _frmMaster = (frmMaster)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmMaster").FirstOrDefault();
                    //if (_frmMaster != null)
                    //{
                    //    _frmMaster.UpdateDashBoardDetail();
                    //}
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
            Result<DataTable> _Result = _VoucherService.GetVoucherByVoucherNo(Convert.ToInt32(txtReceiptNo.Text), Convert.ToString(Properties.Settings.Default.Year));

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
