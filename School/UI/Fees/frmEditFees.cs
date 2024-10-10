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
    public partial class frmEditFees : Form
    {
        #region Variables

        private FeesService _FeesService = new FeesService();
        private StandardService _StandardService = new StandardService();
        private DepartmentService _DepartmentService = new DepartmentService();
        private int _FeesId;
        private string _DisplayFeesName;
        private Control _Control = null;
        private string _Message = "";
        private bool _IsRefresh = false;
        private bool _IsOtherFees = false;

        #endregion

        #region Page events and constructor

        public frmEditFees()
        {
            InitializeComponent();
        }

        public frmEditFees(int p_FeesId, bool p_IsOtherFees)
        {
            InitializeComponent();
            _FeesId = p_FeesId;
            _IsOtherFees = p_IsOtherFees;
        }

        private void frmSaveFees_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillStandard();
            FillDepartment();
            FillControls();

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
            FillControls();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pbStandard_Click(object sender, EventArgs e)
        {
            frmStandard _frmStandard = (frmStandard)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmStandard").FirstOrDefault();
            if (_frmStandard != null)
            {
                _frmStandard._PageId = 2;
                _frmStandard.Focus();
            }
            else
            {
                _frmStandard = new frmStandard();
                _frmStandard._PageId = 2;
                _frmStandard.Show();
                _frmStandard.Focus();
            }
        }

        private void pbDepartment_Click(object sender, EventArgs e)
        {
            frmDepartment _frmDepartment = (frmDepartment)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmDepartment").FirstOrDefault();
            if (_frmDepartment != null)
            {
                _frmDepartment._PageId = 2;
                _frmDepartment.Focus();
            }
            else
            {
                _frmDepartment = new frmDepartment();
                _frmDepartment._PageId = 2;
                _frmDepartment.Show();
                _frmDepartment.Focus();
            }
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

        private void FillControls()
        {
            cbStandard.Select();

            Result<FeesMaster> _Result = _FeesService.GetFeesById(_FeesId, Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                txtFeesName.Text = _Result.Data.FeesName;
                _DisplayFeesName = _Result.Data.DisplayFeesName;
                txtFees.Text = Convert.ToString(_Result.Data.Fees);
                cbStandard.SelectedValue = _Result.Data.StandardId;
                cbDepartment.SelectedValue = _Result.Data.DepartmentId;
            }
            else
            {
                this.Close();
            }
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

            if (!Helper.CheckRequired(txtFees.Text.Trim(), ref _Message, "Fees"))
            {
                if (_Control == null)
                    _Control = txtFees;
                _Result = false;
            }
            else if (Convert.ToInt32(txtFees.Text.Trim())<=0)
            {
                _Message += "\n ---> Please enter fees more than 0!";
                if (_Control == null)
                    _Control = txtFees;
                _Result = false;
            }

            //if (_Result)
            //{
            //    Result<bool> _ResultData = _FeesService.CheckFeesReferences(_FeesId, Convert.ToDecimal(txtFees.Text.Trim()), Convert.ToString(Properties.Settings.Default.Year));

            //    if (_ResultData.IsSuccess)
            //    {
            //        if (!_ResultData.Data)
            //        {
            //            _Result = true;
            //        }
            //        else
            //        {
            //            txtFees.Select();
            //            _Result = false;
            //            _Message =Messages.CheckFeesMsg;
            //            if (_Control == null)
            //                _Control = txtFees;
            //        }
            //    }
            //    else
            //    {
            //        txtFees.Select();
            //        _Result = false;
            //        _Message = _ResultData.Message;
            //        if (_Control == null)
            //            _Control = txtFees;
            //    }
            //}

            if (_Result)
            {
                FeesMaster _FeesMaster = new FeesMaster();

                _FeesMaster.FeesID = _FeesId;
                _FeesMaster.StandardId=Convert.ToInt32(cbStandard.SelectedValue);
                _FeesMaster.DepartmentId=Convert.ToInt32(cbDepartment.SelectedValue);
                _FeesMaster.FeesName=txtFeesName.Text.Trim();
                _FeesMaster.DisplayFeesName = _DisplayFeesName;
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

            _FeesMaster.FeesID = _FeesId;
            _FeesMaster.StandardId = Convert.ToInt32(cbStandard.SelectedValue);
            _FeesMaster.DepartmentId = Convert.ToInt32(cbDepartment.SelectedValue);
            _FeesMaster.FeesName = txtFeesName.Text.Trim();
            _FeesMaster.Fees = Convert.ToDecimal(txtFees.Text);

            Result<bool> _Result = _FeesService.SaveFees(_FeesMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _IsRefresh = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

       

    }
}
