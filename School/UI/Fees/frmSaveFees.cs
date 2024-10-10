using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using School.UI.Department;
using School.UI.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI.Fees
{
    public partial class frmSaveFees : Form
    {
        #region Variables

        private FeesService _FeesService = new FeesService();
        private StandardService _StandardService = new StandardService();
        private DepartmentService _DepartmentService = new DepartmentService();
        private Control _Control = null;
        private string _Message = "";
        private bool _IsRefresh = false;
        private bool _IsOtherFees = false;

        #endregion

        #region Page events and constructor

        public frmSaveFees()
        {
            InitializeComponent();
        }

        public frmSaveFees(bool p_IsOtherFees)
        {
            InitializeComponent();
            _IsOtherFees = p_IsOtherFees;
        }

        private void frmSaveFees_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillStandard();
            FillDepartment();

            this.Cursor = Cursors.Default;
        }

        private void frmSaveFees_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_IsRefresh)
            {
                frmFees _frmFees = (frmFees)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmFees").FirstOrDefault();
                if (_frmFees != null)
                {
                    _frmFees.Focus();
                    _frmFees.FillFeesDataTable();
                    _frmFees.FillGrid();
                }
                else
                {
                    _frmFees = new frmFees(_IsOtherFees);
                    _frmFees.Show();
                    _frmFees.Focus();
                }
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
                if (ValidateControl())
                {
                    SaveFees();

                    frmMaster _frmMaster = (frmMaster)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmMaster").FirstOrDefault();
                    if (_frmMaster != null)
                    {
                        _frmMaster.UpdateDashBoardDetail();
                    }

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Control.Select();
                    epFees.SetIconPadding(_Control, 10);
                    epFees.SetError(_Control, Messages.RequiredMsg);
                }
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void pbStandard_Click(object sender, EventArgs e)
        {
            frmStandard _frmStandard = (frmStandard)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmStandard").FirstOrDefault();
            if (_frmStandard != null)
            {
                _frmStandard._PageId = 1;
                _frmStandard.Focus();
            }
            else
            {
                _frmStandard = new frmStandard();
                _frmStandard._PageId = 1;
                _frmStandard.Show();
                _frmStandard.Focus();
            }
        }

        private void pbDepartment_Click(object sender, EventArgs e)
        {
            frmDepartment _frmDepartment = (frmDepartment)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmDepartment").FirstOrDefault();
            if (_frmDepartment != null)
            {
                _frmDepartment._PageId = 1;
                _frmDepartment.Focus();
            }
            else
            {
                _frmDepartment = new frmDepartment();
                _frmDepartment._PageId = 1;
                _frmDepartment.Show();
                _frmDepartment.Focus();
            }
        }

        private void rbtnOneTime_CheckedChanged(object sender, EventArgs e)
        {
            pnlMonthly.Visible = false;

            if (rbtnMonthly.Checked)
            {
                pnlMonthly.Visible = true;
            }
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFees_TextChanged(object sender, EventArgs e)
        {
            txtJanuary.Text = txtFebruary.Text = txtMarch.Text = txtApril.Text = txtMay.Text = txtJune.Text = txtJuly.Text = txtAugust.Text = txtSeptember.Text = txtOctober.Text = txtNovember.Text = txtDecember.Text = txtFees.Text;
        }

        #endregion

        #region Private Methods

        public void FillStandard()
        {
            Result<DataTable> _Result = _StandardService.GetAllStandard(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbStandard.DataSource = _Result.Data;
                cbStandard.DisplayMember = "Standard";
                cbStandard.ValueMember = "StandardID";
            }
        }

        public void FillDepartment()
        {
            Result<DataTable> _Result = _DepartmentService.GetAllDepartment(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbDepartment.DataSource = _Result.Data;
                cbDepartment.DisplayMember = "Department";
                cbDepartment.ValueMember = "DepartmentID";
            }
        }

        private void ClearControls()
        {
            epFees.Clear();

            cbStandard.SelectedIndex = 0;
            cbDepartment.SelectedIndex = 0;
            txtFeesName.Text = string.Empty;
            rbtnOneTime.Checked = true;
            txtFees.Text = string.Empty;

            cbStandard.Select();
        }

        private bool ValidateControl()
        {
            epFees.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (cbStandard.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Standard!";
                if (_Control == null)
                    _Control = cbStandard;
                _Result = false;
            }

            if (cbDepartment.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Department!";
                if (_Control == null)
                    _Control = cbDepartment;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtFeesName.Text.Trim(), ref _Message, "Fees Name"))
            {
                if (_Control == null)
                    _Control = txtFeesName;
                _Result = false;
            }

            if (rbtnOneTime.Checked)
            {
                if (!Helper.CheckRequired(txtFees.Text.Trim(), ref _Message, "Fees"))
                {
                    if (_Control == null)
                        _Control = txtFees;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtFees.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter fees more than 0!";
                    if (_Control == null)
                        _Control = txtFees;
                    _Result = false;
                }
            }
            else
            {
                if (!Helper.CheckRequired(txtJanuary.Text.Trim(), ref _Message, "January Fees"))
                {
                    if (_Control == null)
                        _Control = txtJanuary;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtJanuary.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter january fees more than 0!";
                    if (_Control == null)
                        _Control = txtJanuary;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtFebruary.Text.Trim(), ref _Message, "February Fees"))
                {
                    if (_Control == null)
                        _Control = txtFebruary;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtFebruary.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter february fees more than 0!";
                    if (_Control == null)
                        _Control = txtFebruary;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtMarch.Text.Trim(), ref _Message, "March Fees"))
                {
                    if (_Control == null)
                        _Control = txtMarch;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtMarch.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter march fees more than 0!";
                    if (_Control == null)
                        _Control = txtMarch;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtApril.Text.Trim(), ref _Message, "April Fees"))
                {
                    if (_Control == null)
                        _Control = txtApril;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtApril.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter april fees more than 0!";
                    if (_Control == null)
                        _Control = txtApril;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtMay.Text.Trim(), ref _Message, "May Fees"))
                {
                    if (_Control == null)
                        _Control = txtMay;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtMay.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter may fees more than 0!";
                    if (_Control == null)
                        _Control = txtMay;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtJune.Text.Trim(), ref _Message, "June Fees"))
                {
                    if (_Control == null)
                        _Control = txtJune;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtJune.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter june fees more than 0!";
                    if (_Control == null)
                        _Control = txtJune;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtJuly.Text.Trim(), ref _Message, "July Fees"))
                {
                    if (_Control == null)
                        _Control = txtJuly;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtJuly.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter july fees more than 0!";
                    if (_Control == null)
                        _Control = txtJuly;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtAugust.Text.Trim(), ref _Message, "August Fees"))
                {
                    if (_Control == null)
                        _Control = txtAugust;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtAugust.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter august fees more than 0!";
                    if (_Control == null)
                        _Control = txtAugust;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtSeptember.Text.Trim(), ref _Message, "September Fees"))
                {
                    if (_Control == null)
                        _Control = txtSeptember;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtSeptember.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter september fees more than 0!";
                    if (_Control == null)
                        _Control = txtSeptember;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtOctober.Text.Trim(), ref _Message, "October Fees"))
                {
                    if (_Control == null)
                        _Control = txtOctober;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtOctober.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter october fees more than 0!";
                    if (_Control == null)
                        _Control = txtOctober;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtNovember.Text.Trim(), ref _Message, "November Fees"))
                {
                    if (_Control == null)
                        _Control = txtNovember;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtNovember.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter november fees more than 0!";
                    if (_Control == null)
                        _Control = txtNovember;
                    _Result = false;
                }

                if (!Helper.CheckRequired(txtDecember.Text.Trim(), ref _Message, "December Fees"))
                {
                    if (_Control == null)
                        _Control = txtDecember;
                    _Result = false;
                }
                else if (Convert.ToInt32(txtDecember.Text.Trim()) <= 0)
                {
                    _Message += "\n ---> Please enter december fees more than 0!";
                    if (_Control == null)
                        _Control = txtDecember;
                    _Result = false;
                }
            }

            if (_Result)
            {
                FeesMaster _FeesMaster = new FeesMaster();

                _FeesMaster.FeesID = null;
                _FeesMaster.StandardId = Convert.ToInt32(cbStandard.SelectedValue);
                _FeesMaster.DepartmentId = Convert.ToInt32(cbDepartment.SelectedValue);
                _FeesMaster.FeesName = txtFeesName.Text.Trim();
                _FeesMaster.DisplayFeesName = txtFeesName.Text.Trim();
                _FeesMaster.IsOtherFees = _IsOtherFees;

                Result<bool> _ResultData = _FeesService.CheckDuplicateFees(_FeesMaster, Convert.ToString(Properties.Settings.Default.Year));

                if (_ResultData.IsSuccess)
                {
                    if (!_ResultData.Data)
                    {
                        _Result = true;
                    }
                    else
                    {
                        txtFeesName.Select();
                        _Result = false;
                        _Message = string.Format(Messages.DuplicateMsg, "Fees Name");
                        if (_Control == null)
                            _Control = txtFeesName;
                    }
                }
                else
                {
                    txtFeesName.Select();
                    _Result = false;
                    _Message = _ResultData.Message;
                    if (_Control == null)
                        _Control = txtFeesName;
                }
            }

            return _Result;
        }

        private void SaveFees()
        {
            FeesMaster _FeesMaster = new FeesMaster();

            _FeesMaster.FeesID = null;
            _FeesMaster.StandardId = Convert.ToInt32(cbStandard.SelectedValue);
            _FeesMaster.DepartmentId = Convert.ToInt32(cbDepartment.SelectedValue);
            _FeesMaster.FeesName = txtFeesName.Text.Trim();
            _FeesMaster.IsOneTime = rbtnOneTime.Checked;
            _FeesMaster.IsOtherFees = _IsOtherFees;

            string _Message = string.Empty;

            Result<bool> _Result;

            if (rbtnOneTime.Checked)
            {
                _FeesMaster.Fees = Convert.ToDecimal(txtFees.Text);
                _FeesMaster.DisplayFeesName = txtFeesName.Text.Trim();

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = _Result.Message;
                }
            }
            else
            {
                _FeesMaster.Fees = Convert.ToDecimal(txtJune.Text);
                _FeesMaster.DisplayFeesName = "June";
                _FeesMaster.MonthNumber = 1;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "June" : _Message + ", June";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtJuly.Text);
                _FeesMaster.DisplayFeesName = "July";
                _FeesMaster.MonthNumber = 2;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "July" : _Message + ", July";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtAugust.Text);
                _FeesMaster.DisplayFeesName = "August";
                _FeesMaster.MonthNumber = 3;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "August" : _Message + ", August";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtSeptember.Text);
                _FeesMaster.DisplayFeesName = "September";
                _FeesMaster.MonthNumber = 4;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "September" : _Message + ", September";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtOctober.Text);
                _FeesMaster.DisplayFeesName = "October";
                _FeesMaster.MonthNumber = 5;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "October" : _Message + ", October";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtNovember.Text);
                _FeesMaster.DisplayFeesName = "November";
                _FeesMaster.MonthNumber = 6;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "November" : _Message + ", November";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtDecember.Text);
                _FeesMaster.DisplayFeesName = "December";
                _FeesMaster.MonthNumber = 7;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "December" : _Message + ", December";
                }

                if (!string.IsNullOrEmpty(_Message))
                {
                    _Message = _Message + Messages.ExceptionMsg;
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtJanuary.Text);
                _FeesMaster.DisplayFeesName = "January";
                _FeesMaster.MonthNumber = 8;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "January" : _Message + ", January";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtFebruary.Text);
                _FeesMaster.DisplayFeesName = "February";
                _FeesMaster.MonthNumber = 9;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "February" : _Message + ", February";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtMarch.Text);
                _FeesMaster.DisplayFeesName = "March";
                _FeesMaster.MonthNumber = 10;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "March" : _Message + ", March";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtApril.Text);
                _FeesMaster.DisplayFeesName = "April";
                _FeesMaster.MonthNumber = 11;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "April" : _Message + ", April";
                }

                _FeesMaster.Fees = Convert.ToDecimal(txtMay.Text);
                _FeesMaster.DisplayFeesName = "May";
                _FeesMaster.MonthNumber = 12;

                _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (!_Result.IsSuccess)
                {
                    _Message = string.IsNullOrEmpty(_Message) ? "May" : _Message + ", May";
                }
            }

            if (string.IsNullOrEmpty(_Message))
            {
                MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _IsRefresh = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
