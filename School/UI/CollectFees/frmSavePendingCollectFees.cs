using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using School.UI.Department;
using School.UI.Division;
using School.UI.Standard;
using School.UI.Student;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI.CollectFees
{
    public partial class frmSavePendingCollectFees : Form
    {
        #region Variables

        private StudentService _StudentService = new StudentService();
        private CollectFeesService _CollectFeesService = new CollectFeesService();
        private ReceiptService _ReceiptService = new ReceiptService();
        public List<ReceiptDetail> _ListOfReceiptDetail = new List<ReceiptDetail>();
        private int _ReceiptID = 0;
        private bool _IsOtherFees = false;
        private Control _Control = null;
        private string _Message = "";
        private List<CollectFeesMaster> _ListOfCollectFees = null;
        private int _StudentId = 0;
        private string _Year = Convert.ToString(Properties.Settings.Default.Year);

        #endregion


        #region Page events and constructor

        public frmSavePendingCollectFees()
        {
            InitializeComponent();
        }

        public frmSavePendingCollectFees(int p_StudentId, bool p_IsOtherFees)
        {
            InitializeComponent();

            _IsOtherFees = p_IsOtherFees;
            _StudentId = p_StudentId;
        }

        private void frmSaveCollectFees_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            dtReceivedDate.Enabled = UserHelper.IsAdmin;

            gvPendingFees.AutoGenerateColumns = false;
            gvCompleteFees.AutoGenerateColumns = false;

            _Year = Convert.ToString(Convert.ToInt32(_Year) - 1);

            if(_IsOtherFees)
            {
                lblTitle.Text = "Save Other Collect Fees";
            }
            else
            {
                lblTitle.Text = "Save Regular Collect Fees";
            }

            FillFeesDetails();

            this.Cursor = Cursors.Default;
        }

        private void frmSaveCollectFees_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C))
            {
                txtCash.Focus();
            }
            if ((e.Control && e.KeyCode == Keys.B))
            {
                txtBank.Focus();
            }
            if ((e.Control && e.KeyCode == Keys.W))
            {
                txtWaiver.Focus();
            }
        }

        #endregion


        #region Button Events

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int _Cash_Bank_Waiver = 0;

                if (ValidateControl())
                {
                    if (!string.IsNullOrEmpty(txtCash.Text) && Convert.ToInt32(txtCash.Text) > 0)
                    {
                        ReceiptDetail _CashReceiptDetail = new ReceiptDetail();
                        _CashReceiptDetail.ReceiptID = _ReceiptID;
                        _CashReceiptDetail.PaymentType = Convert.ToInt32(Helper.GetEnumDescription(PaymentType.Cash));
                        _CashReceiptDetail.CreditAmount = Convert.ToInt32(txtCash.Text);
                        _CashReceiptDetail.DebitAmount = 0;
                        _CashReceiptDetail.Narration = "";
                        _CashReceiptDetail.VoucherTypeId = Convert.ToInt32(VoucherType.OtherReceiptVoucher);
                        _Cash_Bank_Waiver = Convert.ToInt32(txtCash.Text);
                        this._ListOfReceiptDetail.Add(_CashReceiptDetail);
                    }

                    if (!string.IsNullOrEmpty(txtBank.Text) && Convert.ToInt32(txtCash.Text) > 0)
                    {
                        ReceiptDetail _BankReceiptDetail = new ReceiptDetail();
                        _BankReceiptDetail.ReceiptID = _ReceiptID;
                        _BankReceiptDetail.PaymentType = Convert.ToInt32(Helper.GetEnumDescription(PaymentType.Bank));
                        _BankReceiptDetail.CreditAmount = Convert.ToInt32(txtBank.Text);
                        _BankReceiptDetail.DebitAmount = 0;
                        _BankReceiptDetail.Narration = txtBankNarration.Text;
                        _BankReceiptDetail.VoucherTypeId = Convert.ToInt32(VoucherType.OtherReceiptVoucher);
                        _Cash_Bank_Waiver = _Cash_Bank_Waiver + Convert.ToInt32(txtBank.Text);
                        this._ListOfReceiptDetail.Add(_BankReceiptDetail);
                    }

                    if (!string.IsNullOrEmpty(txtWaiver.Text) && Convert.ToInt32(txtWaiver.Text) > 0)
                    {
                        ReceiptDetail _WaiverReceiptDetail = new ReceiptDetail();
                        _WaiverReceiptDetail.ReceiptID = _ReceiptID;
                        _WaiverReceiptDetail.PaymentType = Convert.ToInt32(Helper.GetEnumDescription(PaymentType.Waiver));
                        _WaiverReceiptDetail.CreditAmount = Convert.ToInt32(txtWaiver.Text);
                        _WaiverReceiptDetail.DebitAmount = 0;
                        _WaiverReceiptDetail.Narration = txtWaiverNarration.Text;
                        _WaiverReceiptDetail.VoucherTypeId = Convert.ToInt32(VoucherType.OtherReceiptVoucher);
                        _Cash_Bank_Waiver = _Cash_Bank_Waiver + Convert.ToInt32(txtWaiver.Text);
                        this._ListOfReceiptDetail.Add(_WaiverReceiptDetail);
                    }

                    Int64 _ReceiptNo = SaveCollectFees();

                    if (_ReceiptNo > 0)
                    {
                        if (_ListOfReceiptDetail != null && _ListOfReceiptDetail.Count > 0)
                        {
                            foreach (var _ReceiptDetail in _ListOfReceiptDetail)
                            {
                                _ReceiptDetail.ReceiptID = Convert.ToInt32(_ReceiptNo);
                            }

                            Result<bool> _IsAdded = _ReceiptService.SaveReceiptDetails(_ListOfReceiptDetail, Convert.ToInt32(Properties.Settings.Default.UserId), _Year);
                        }

                        if (MessageBox.Show("Are you sure you want print receipt?", Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PrintReceipt(_ReceiptNo);
                        }

                        MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Control.Select();
                    epCollectFees.SetIconPadding(_Control, 10);
                    epCollectFees.SetError(_Control, Messages.RequiredMsg);
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

        private void gvPendingFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvPendingFees.CurrentCell.RowIndex;
                int colindex = gvPendingFees.CurrentCell.ColumnIndex;
                if (gvPendingFees.Columns[colindex].Name == "IsPay")
                {
                    bool _IsPay = (bool)gvPendingFees[colindex, rowindex].EditedFormattedValue;

                    if (_IsPay)
                    {
                        gvPendingFees.Rows[rowindex].Cells["PayFees"].Value = Convert.ToString(gvPendingFees.Rows[rowindex].Cells["Fees"].Value);
                    }
                    else
                    {
                        gvPendingFees.Rows[rowindex].Cells["PayFees"].Value = string.Empty;
                    }

                    int _TotalPayFees = 0;
                    foreach (DataGridViewRow item in gvPendingFees.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells["IsPay"].EditedFormattedValue))
                        {
                            if (item.Cells["PayFees"].Value != null && !string.IsNullOrEmpty(Convert.ToString(item.Cells["PayFees"].Value)))
                            {
                                _TotalPayFees = _TotalPayFees + Convert.ToInt32(item.Cells["PayFees"].Value);
                            }
                        }
                    }

                    lblTotalPayFees.Text = Convert.ToString(_TotalPayFees);
                    txtCash.Text = Convert.ToString(_TotalPayFees);

                    lblTotalCurrentPendingFees.Text = Convert.ToString(Convert.ToInt32(lblTotalPendingFees.Text) - _TotalPayFees);
                    ManageBankDetails(false);
                    ManageWaiverDetails(false);
                }
            }
        }

        private void gvPendingFees_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvPendingFees.CurrentCell.RowIndex;
                int colindex = gvPendingFees.CurrentCell.ColumnIndex;
                if (gvPendingFees.Columns[colindex].Name == "PayFees")
                {
                    string _PayFeesString = Convert.ToString(gvPendingFees.Rows[rowindex].Cells["PayFees"].Value);
                    int _PayFees;
                    int.TryParse(_PayFeesString, out _PayFees);

                    int _Fees = Convert.ToInt32(gvPendingFees.Rows[rowindex].Cells["Fees"].Value);

                    if (_PayFees < 1 || _Fees < _PayFees)
                    {
                        MessageBox.Show(Messages.PayFeesEmptyMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gvPendingFees.Rows[rowindex].Cells["PayFees"].Value = Convert.ToString(gvPendingFees.Rows[rowindex].Cells["Fees"].Value);
                    }
                    else
                    {
                        int _TotalPayFees = 0;
                        foreach (DataGridViewRow item in gvPendingFees.Rows)
                        {
                            if (Convert.ToBoolean(item.Cells["IsPay"].EditedFormattedValue))
                            {
                                if (item.Cells["PayFees"].Value != null && !string.IsNullOrEmpty(Convert.ToString(item.Cells["PayFees"].Value)))
                                {
                                    _TotalPayFees = _TotalPayFees + Convert.ToInt32(item.Cells["PayFees"].Value);
                                }
                            }
                        }

                        lblTotalPayFees.Text = Convert.ToString(_TotalPayFees);
                        txtCash.Text = lblTotalPayFees.Text;

                        lblTotalCurrentPendingFees.Text = Convert.ToString(Convert.ToInt32(lblTotalPendingFees.Text) - _TotalPayFees);
                    }
                }
            }
        }

        private void txtCash_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int _Total = Convert.ToInt32(lblTotalPayFees.Text);
                int _Cash = txtCash.Text.Length > 0 ? Convert.ToInt32(txtCash.Text) : 0;

                if (_Cash < _Total)
                {
                    ManageBankDetails(true);
                }
                else
                {
                    ManageBankDetails(false);
                    ManageWaiverDetails(false);
                }
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.Message);
            }
        }

        private void txtBank_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int _Total = Convert.ToInt32(lblTotalPayFees.Text);
                int _Cash = txtCash.Text.Length > 0 ? Convert.ToInt32(txtCash.Text) : 0;
                int _Bank = txtBank.Text.Length > 0 ? Convert.ToInt32(txtBank.Text) : 0;

                if (_Cash + _Bank < _Total)
                {
                    ManageWaiverDetails(true);
                }
                else
                {
                    ManageWaiverDetails(false);
                }
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.Message);
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtWaiver_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        #endregion


        #region Private Methods

        private void FillPendingFees()
        {
            gvPendingFees.DataSource = null;
            gvPendingFees.Rows.Clear();

            Result<DataTable> _Result = _CollectFeesService.GetAllPendingFees(_StudentId, _IsOtherFees, _Year);

            if (_Result.IsSuccess)
            {
                if (_Result.Data != null)
                {
                    gvPendingFees.DataSource = _Result.Data;

                    object sumObject;
                    sumObject = _Result.Data.Compute("Sum(PendingFees)", "");

                    lblTotalPendingFees.Text = Convert.ToString(sumObject);
                }
            }
        }

        private void FillCompleteFees()
        {
            gvCompleteFees.DataSource = null;
            gvCompleteFees.Rows.Clear();

            Result<DataTable> _Result = _ReceiptService.GetReceipt(_StudentId, _IsOtherFees, _Year);

            if (_Result.IsSuccess)
            {
                if (_Result.Data != null)
                {
                    gvCompleteFees.DataSource = _Result.Data;

                    object sumObject;
                    sumObject = _Result.Data.Compute("Sum(PayFees)", "");

                    lblTotalPaidFees.Text = Convert.ToString(sumObject);
                }
            }
        }

        private bool ValidateControl()
        {
            epCollectFees.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;
            double _CashAmount, _TotalAmount;

            double.TryParse(txtCash.Text, out _CashAmount);

            _TotalAmount = _CashAmount;

            _ListOfCollectFees = null;

            if (_Result)
            {
                _ListOfCollectFees = new List<CollectFeesMaster>();

                foreach (DataGridViewRow _Row in gvPendingFees.Rows)
                {
                    if (Convert.ToBoolean(_Row.Cells["IsPay"].Value))
                    {
                        CollectFeesMaster _CollectFeesMaster = new CollectFeesMaster();

                        _CollectFeesMaster.CollectFeesID = Convert.ToInt32(_Row.Cells["CollectFeesID"].Value);
                        _CollectFeesMaster.Fees = Convert.ToDecimal(_Row.Cells["Fees"].Value);
                        _CollectFeesMaster.PayFees = Convert.ToDecimal(_Row.Cells["PayFees"].Value);
                        _CollectFeesMaster.StudentId =_StudentId;
                        _CollectFeesMaster.FeesId = Convert.ToInt32(_Row.Cells["FeesId"].Value);

                        _ListOfCollectFees.Add(_CollectFeesMaster);
                    }
                }
            }

            if (_ListOfCollectFees == null)
            {
                _Message += "\n ---> Select Pay Fees!";
                if (_Control == null)
                    _Control = gvPendingFees;
                _Result = false;
            }
            else if (_ListOfCollectFees.Count < 1)
            {
                _Message += "\n ---> Select Pay Fees!";
                if (_Control == null)
                    _Control = gvPendingFees;
                _Result = false;
            }

            if (_Result)
            {
                int _TotalFees = Convert.ToInt32(lblTotalPayFees.Text);
                int _Cash_Bank_Waiver = 0;

                if (!string.IsNullOrEmpty(txtCash.Text) && Convert.ToInt32(txtCash.Text) > 0)
                {
                    _Cash_Bank_Waiver = _Cash_Bank_Waiver + Convert.ToInt32(txtCash.Text);
                }

                if (!string.IsNullOrEmpty(txtBank.Text) && Convert.ToInt32(txtBank.Text) > 0)
                {
                    _Cash_Bank_Waiver = _Cash_Bank_Waiver + Convert.ToInt32(txtBank.Text);
                }

                if (!string.IsNullOrEmpty(txtWaiver.Text) && Convert.ToInt32(txtWaiver.Text) > 0)
                {
                    _Cash_Bank_Waiver = _Cash_Bank_Waiver + Convert.ToInt32(txtWaiver.Text);
                }

                if (_TotalFees != _Cash_Bank_Waiver)
                {
                    _Message += "\n ---> please enter valid total amount(" + _TotalFees + ")";
                    _Control = txtCash;
                    _Result = false;
                }
            }
            return _Result;
        }

        private Int64 SaveCollectFees()
        {
            Result<bool> _Result = _CollectFeesService.UpdateCollectFees(_ListOfCollectFees, Convert.ToInt32(Properties.Settings.Default.UserId), _Year);

            if (_Result.IsSuccess)
            {
                List<ReceiptMaster> _ListOfReceipt = new List<ReceiptMaster>();

                foreach (CollectFeesMaster _CollectFeesMaster in _ListOfCollectFees)
                {
                    ReceiptMaster _ReceiptMaster = new ReceiptMaster();

                    _ReceiptMaster.FeesId = _CollectFeesMaster.FeesId;
                    _ReceiptMaster.StudentId = _CollectFeesMaster.StudentId;
                    _ReceiptMaster.ReceivedBy = txtReceivedBy.Text.Trim();
                    _ReceiptMaster.GivenBy = txtGivenBy.Text.Trim();
                    _ReceiptMaster.ReceivedDate = dtReceivedDate.Value.ToString();
                    _ReceiptMaster.PayFees = _CollectFeesMaster.PayFees;
                    _ReceiptMaster.YearId = Convert.ToInt32(Properties.Settings.Default.YearId)-1;

                    _ListOfReceipt.Add(_ReceiptMaster);
                }

                Result<Int64> _ResultReceipt = _ReceiptService.SaveReceipt(_ListOfReceipt, Convert.ToInt32(Properties.Settings.Default.UserId), _Year);

                if (_ResultReceipt.IsSuccess)
                {                    
                    return _ResultReceipt.Data;
                }
            }
            else
            {
                MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0;
        }

        private void FillFeesDetails()
        {
            txtReceivedBy.Text = Properties.Settings.Default.UserName;
            lblReceiptNo.Text = Convert.ToString(_ReceiptService.GetReceiptNo(_Year) + 1);

            ManageBankDetails(false);
            ManageWaiverDetails(false);

            lblTotalFees.Text = "0";
            lblTotalPaidFees.Text = "0";
            lblTotalPayFees.Text = "0";
            lblTotalPendingFees.Text = "0";

            Result<StudentMaster> _Result = _StudentService.GetStudentDetailById(_StudentId, _Year);

            if (_Result.IsSuccess)
            {
                lblGRNoD.Text = Convert.ToString(_Result.Data.GRNumber);
                lblDepartmentName.Text = _Result.Data.Department;
                lblStandardName.Text = _Result.Data.Standard;
                lblDivisionName.Text = _Result.Data.Division;
                lblStudentName.Text = _Result.Data.FirstName;
            }

            FillPendingFees();
            FillCompleteFees();

            if (!string.IsNullOrEmpty(lblTotalPaidFees.Text))
            {
                lblTotalFees.Text = lblTotalPaidFees.Text;
            }
            else
            {
                lblTotalPaidFees.Text = "0";
            }
            if (!string.IsNullOrEmpty(lblTotalPendingFees.Text))
            {
                lblTotalFees.Text = Convert.ToString(Convert.ToInt32(lblTotalFees.Text) + Convert.ToInt32(lblTotalPendingFees.Text));
            }
            else
            {
                lblTotalPendingFees.Text = "0";
            }
        }

        private void ManageWaiverDetails(bool p_IsVisible)
        {
            lblWaiver.Visible = lblWaiverNarration.Visible = txtWaiver.Visible = txtWaiverNarration.Visible = p_IsVisible;
            if (!p_IsVisible)
            {
                txtWaiver.Text = txtWaiverNarration.Text = string.Empty;
            }
        }

        private void ManageBankDetails(bool p_IsVisible)
        {
            lblBank.Visible = lblBankNarration.Visible = txtBankNarration.Visible = txtBank.Visible = p_IsVisible;
            if (!p_IsVisible)
            {
                txtBank.Text = txtBankNarration.Text = string.Empty;
            }
        }

        #endregion


        #region Print

        private void PrintReceipt(Int64 p_No)
        {
            Result<DataTable> _Result = _ReceiptService.GetFeesReceiptByReceiptNo(p_No, _Year);

            if (_Result.IsSuccess)
            {
                LocalReport report = new LocalReport();
                report.ReportEmbeddedResource = "School.UI.Report.FeesReceipt.rdlc";
                report.DataSources.Add(
                   new ReportDataSource("DataSet", _Result.Data));

                PrintFunction _PrintFunction = new PrintFunction();

                _PrintFunction.Export(report);
                _PrintFunction.Print();
            }
        }

        #endregion
    }
}
