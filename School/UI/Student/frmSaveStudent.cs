using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using School.UI.Department;
using School.UI.Division;
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

namespace School.UI.Student
{
    public partial class frmSaveStudent : Form
    {
        #region Variables

        private StudentService _StudentService = new StudentService();
        private StandardService _StandardService = new StandardService();
        private DepartmentService _DepartmentService = new DepartmentService();
        private DivisionService _DivisionService = new DivisionService();
        private FeesService _FeesService = new FeesService();
        private CollectFeesService _CollectFeesService = new CollectFeesService();
        private int? _StudentId = null;
        private Control _Control = null;
        private string _Message = "";
        private bool _IsRefresh = false;
        private List<CollectFeesMaster> _ListOfCollectRegularFees = null;
        private List<CollectFeesMaster> _ListOfCollectOtherFees = null;
        private bool _IsSaveRegularFees = true, _IsSaveOtherFees = true;

        #endregion

        #region Page events and constructor

        public frmSaveStudent()
        {
            InitializeComponent();
        }

        public frmSaveStudent(int? p_StudentId)
        {
            InitializeComponent();
            _StudentId = p_StudentId;
        }

        private void frmSaveStudent_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillStandard();
            FillDivision();
            FillDepartment();

            FillControls();
            FillLastRegistrationDate();

            this.Cursor = Cursors.Default;
        }       

        private void frmSaveStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_IsRefresh)
            {
                frmStudent _frmStudent = (frmStudent)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmStudent").FirstOrDefault();
                if (_frmStudent != null)
                {
                    _frmStudent.Focus();
                    _frmStudent.FillStudentDataTable();
                    _frmStudent.FillGrid();
                }
                else
                {
                    _frmStudent = new frmStudent();
                    _frmStudent.Show();
                    _frmStudent.Focus();
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
                    bool _Flag = false;

                    if (_IsSaveRegularFees)
                    {
                        foreach (TreeNode _Node in tvRegularFees.Nodes)
                        {
                            if (_Node.Checked)
                            {
                                _Flag = true;
                            }
                        }
                    }

                    if (!_Flag)
                    {
                        if (_IsSaveOtherFees)
                        {
                            foreach (TreeNode _Node in tvOtherFees.Nodes)
                            {
                                if (_Node.Checked)
                                {
                                    _Flag = true;
                                }
                            }
                        }
                    }

                    if (_Flag)
                    {
                        SaveStudent();

                        frmMaster _frmMaster = (frmMaster)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmMaster").FirstOrDefault();
                        if (_frmMaster != null)
                        {
                            _frmMaster.UpdateDashBoardDetail();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you want save student detail without select fees ?", Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SaveStudent();

                            frmMaster _frmMaster = (frmMaster)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmMaster").FirstOrDefault();
                            if (_frmMaster != null)
                            {
                                _frmMaster.UpdateDashBoardDetail();
                            }
                        }
                    }

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Control.Select();
                    epStudent.SetIconPadding(_Control, 10);
                    epStudent.SetError(_Control, Messages.RequiredMsg);
                }
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_StudentId != null)
            {
                FillControls();
            }
            else
            {
                ClearControls();
            }
        }

        private void pbStandard_Click(object sender, EventArgs e)
        {
            frmStandard _frmStandard = (frmStandard)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmStandard").FirstOrDefault();
            if (_frmStandard != null)
            {
                _frmStandard._PageId = 3;
                _frmStandard.Focus();
            }
            else
            {
                _frmStandard = new frmStandard();
                _frmStandard._PageId = 3;
                _frmStandard.Show();
                _frmStandard.Focus();
            }
        }

        private void pbDivision_Click(object sender, EventArgs e)
        {
            frmDivision _frmDivision = (frmDivision)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmDivision").FirstOrDefault();
            if (_frmDivision != null)
            {
                _frmDivision._PageId = 1;
                _frmDivision.Focus();
            }
            else
            {
                _frmDivision = new frmDivision();
                _frmDivision._PageId = 1;
                _frmDivision.Show();
                _frmDivision.Focus();
            }
        }

        private void pbDepartment_Click(object sender, EventArgs e)
        {
            frmDepartment _frmDepartment = (frmDepartment)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmDepartment").FirstOrDefault();
            if (_frmDepartment != null)
            {
                _frmDepartment._PageId = 3;
                _frmDepartment.Focus();
            }
            else
            {
                _frmDepartment = new frmDepartment();
                _frmDepartment._PageId = 3;
                _frmDepartment.Show();
                _frmDepartment.Focus();
            }
        }

        private void cbStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFeesDetail();
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_StudentId == null)
            {
                if (cbDepartment.SelectedIndex > 0)
                {
                    Result<int> _Result = _StudentService.GetGRNumberByDepartmentId(Convert.ToInt32(cbDepartment.SelectedValue), Convert.ToString(Properties.Settings.Default.Year));

                    if (_Result.IsSuccess)
                    {
                        txtGRNumber.Text = Convert.ToString(_Result.Data);
                    }
                }
                else
                {
                    txtGRNumber.Text = "0";
                }
            }

            FillFeesDetail();
        }

        private void chkAllRegularFees_CheckedChanged(object sender, EventArgs e)
        {
            if (_IsSaveRegularFees)
            {
                foreach (TreeNode _TreeNode in tvRegularFees.Nodes)
                {
                    _TreeNode.Checked = chkAllRegularFees.Checked;
                }

                if (!chkAllRegularFees.Checked)
                {
                    _ListOfCollectRegularFees = null;
                }
            }
        }

        private void chkAllOtherFees_CheckedChanged(object sender, EventArgs e)
        {
            if (_IsSaveOtherFees)
            {
                foreach (TreeNode _TreeNode in tvOtherFees.Nodes)
                {
                    _TreeNode.Checked = chkAllOtherFees.Checked;
                }

                if (!chkAllOtherFees.Checked)
                {
                    _ListOfCollectOtherFees = null;
                }
            }
        }

        private void txtGRNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        public void FillDivision()
        {
            Result<DataTable> _Result = _DivisionService.GetAllDivision(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbDivision.DataSource = _Result.Data;
                cbDivision.DisplayMember = "Division";
                cbDivision.ValueMember = "DivisionID";
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

            dtRegistrationDate.MaxDate = DateTime.Now;
            dtRegistrationDate.Value = DateTime.UtcNow;
            dtBirthDate.MaxDate = DateTime.Now.AddDays(-1);
            dtBirthDate.Value = DateTime.UtcNow.AddYears(-15);
            cbCategory.SelectedIndex = 0;

            if (_StudentId != null)
            {
                Result<StudentMaster> _Result = _StudentService.GetStudentById(_StudentId.Value, Convert.ToString(Properties.Settings.Default.Year));

                if (_Result.IsSuccess)
                {
                    cbStandard.SelectedValue = _Result.Data.StandardId;
                    cbDivision.SelectedValue = _Result.Data.DivisionId;
                    cbDepartment.SelectedValue = _Result.Data.DepartmentId;
                    txtGRNumber.Text = _Result.Data.GRNumber.ToString();
                    txtFirstName.Text = _Result.Data.FirstName;
                    txtMiddleName.Text = _Result.Data.MiddleName;
                    txtSurname.Text = _Result.Data.LastName;
                    txtFatherName.Text = _Result.Data.FatherName;
                    txtMotherName.Text = _Result.Data.MotherName;
                    cbCategory.SelectedIndex = cbCategory.FindString(_Result.Data.Category);

                    if (_Result.Data.IsGender)
                    {
                        rbtnMale.Checked = true;
                        rbtnFeMale.Checked = false;
                    }
                    else
                    {
                        rbtnMale.Checked = false;
                        rbtnFeMale.Checked = true;
                    }

                    dtBirthDate.Value = _Result.Data.BirthDate;
                    dtRegistrationDate.Value = _Result.Data.RegisterDate;
                    txtMobileNo.Text = _Result.Data.MobileNo;
                    txtPhoneNo.Text = _Result.Data.PhoneNo;
                    txtCity.Text = _Result.Data.City;
                    txtAddress.Text = _Result.Data.Address;

                    Result<DataTable> _ResultFees = _CollectFeesService.GetCollectFeesByStudentId(Convert.ToInt32(_StudentId), false, Convert.ToString(Properties.Settings.Default.Year));

                    if (_ResultFees.IsSuccess)
                    {
                        if (_ResultFees.Data != null)
                        {
                            if (_ResultFees.Data.Rows.Count > 0)
                            {
                                tvRegularFees.Nodes.Clear();

                                DataColumn _Column = new DataColumn("ViewFees", typeof(System.String));

                                _ResultFees.Data.Columns.Add(_Column);

                                _Column = new DataColumn("ID", typeof(System.String));

                                _ResultFees.Data.Columns.Add(_Column);

                                foreach (DataRow _Row in _ResultFees.Data.Rows)
                                {
                                    _Row["ViewFees"] = _Row["DisplayFeesName"] + " --> " + Convert.ToString(_Row["Fees"]);
                                    _Row["ID"] = _Row["FeesID"] + "_" + Convert.ToString(_Row["Fees"]);

                                    TreeNode _TreeNode = new TreeNode();
                                    _TreeNode.Text = Convert.ToString(_Row["ViewFees"]);
                                    _TreeNode.Name = Convert.ToString(_Row["ID"]);
                                    _TreeNode.Checked = true;

                                    tvRegularFees.Nodes.Add(_TreeNode);
                                }

                                chkAllRegularFees.Checked = true;
                                _IsSaveRegularFees = false;
                                chkAllRegularFees.Enabled = false;
                                tvRegularFees.Enabled = false;
                            }
                        }
                    }

                    _ResultFees = _CollectFeesService.GetCollectFeesByStudentId(Convert.ToInt32(_StudentId), true, Convert.ToString(Properties.Settings.Default.Year));

                    if (_ResultFees.IsSuccess)
                    {
                        if (_ResultFees.Data != null)
                        {
                            if (_ResultFees.Data.Rows.Count > 0)
                            {
                                tvRegularFees.Nodes.Clear();

                                DataColumn _Column = new DataColumn("ViewFees", typeof(System.String));

                                _ResultFees.Data.Columns.Add(_Column);

                                _Column = new DataColumn("ID", typeof(System.String));

                                _ResultFees.Data.Columns.Add(_Column);

                                foreach (DataRow _Row in _ResultFees.Data.Rows)
                                {
                                    _Row["ViewFees"] = _Row["DisplayFeesName"] + " --> " + Convert.ToString(_Row["Fees"]);
                                    _Row["ID"] = _Row["FeesID"] + "_" + Convert.ToString(_Row["Fees"]);

                                    TreeNode _TreeNode = new TreeNode();
                                    _TreeNode.Text = Convert.ToString(_Row["ViewFees"]);
                                    _TreeNode.Name = Convert.ToString(_Row["ID"]);
                                    _TreeNode.Checked = true;

                                    tvOtherFees.Nodes.Add(_TreeNode);
                                }

                                chkAllOtherFees.Checked = true;
                                _IsSaveOtherFees = false;
                                chkAllOtherFees.Enabled = false;
                                tvOtherFees.Enabled = false;
                            }
                        }
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void ClearControls()
        {
            epStudent.Clear();

            cbStandard.Select();

            dtRegistrationDate.MaxDate = DateTime.Now;
            dtRegistrationDate.Value = DateTime.UtcNow;
            dtBirthDate.MaxDate = DateTime.Now.AddDays(-1);
            dtBirthDate.Value = DateTime.UtcNow.AddYears(-15);
            cbStandard.SelectedIndex = 0;
            cbDivision.SelectedIndex = 0;
            cbDepartment.SelectedIndex = 0;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtMotherName.Text = string.Empty;
            rbtnMale.Checked = true;
            txtCity.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            cbCategory.SelectedIndex = 0;
        }

        private bool ValidateControl()
        {
            epStudent.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (cbDepartment.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Department!";
                if (_Control == null)
                    _Control = cbDepartment;
                _Result = false;
            }

            if (cbStandard.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Standard!";
                if (_Control == null)
                    _Control = cbStandard;
                _Result = false;
            }

            if (cbDivision.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Division!";
                if (_Control == null)
                    _Control = cbDivision;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtGRNumber.Text.Trim(), ref _Message, "GR No."))
            {
                if (_Control == null)
                    _Control = txtGRNumber;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtFirstName.Text.Trim(), ref _Message, "Name"))
            {
                if (_Control == null)
                    _Control = txtFirstName;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtSurname.Text.Trim(), ref _Message, "Surname"))
            {
                if (_Control == null)
                    _Control = txtSurname;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtMiddleName.Text.Trim(), ref _Message, "Father's Name"))
            {
                if (_Control == null)
                    _Control = txtMiddleName;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtMobileNo.Text.Trim(), ref _Message, "Mobile No"))
            {
                if (_Control == null)
                    _Control = txtMobileNo;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtCity.Text.Trim(), ref _Message, "City"))
            {
                if (_Control == null)
                    _Control = txtCity;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtAddress.Text.Trim(), ref _Message, "Address"))
            {
                if (_Control == null)
                    _Control = txtAddress;
                _Result = false;
            }

            //if(_Result)
            //{
            //    Result<bool> _ReslutDemo = _StudentService.GetIsDemoValid(Convert.ToInt32(cbStandard.SelectedValue), Convert.ToString(Properties.Settings.Default.Year));

            //    if (_ReslutDemo.IsSuccess)
            //    {
            //        if (_ReslutDemo.Data)
            //        {
            //            _Result = false;
            //            _Message = "You can not add more than 3 student in perticular standard because this software is demo purpose. If you need full access then call 9824405764 or email chadasaniya.nilesh@gmail.com";
            //        }
            //    }
            //}

            if (_Result)
            {
                if (txtGRNumber.Text.Trim() != "0")
                {
                    Result<bool> _ResultData = _StudentService.CheckDuplicateGRNo(Convert.ToInt32(txtGRNumber.Text.Trim()), _StudentId, Convert.ToString(Properties.Settings.Default.Year));

                    if (_ResultData.IsSuccess)
                    {
                        if (!_ResultData.Data)
                        {
                            _Result = true;
                        }
                        else
                        {
                            txtGRNumber.Select();
                            _Result = false;
                            _Message = string.Format(Messages.DuplicateMsg, "GR Number");
                            if (_Control == null)
                                _Control = txtGRNumber;
                        }
                    }
                    else
                    {
                        txtGRNumber.Select();
                        _Result = false;
                        _Message = _ResultData.Message;
                        if (_Control == null)
                            _Control = txtGRNumber;
                    }
                }
            }

            return _Result;
        }

        private void SaveStudent()
        {
            StudentMaster _StudentMaster = new StudentMaster();

            _StudentMaster.StudentID = _StudentId;
            _StudentMaster.StandardId = Convert.ToInt32(cbStandard.SelectedValue);
            _StudentMaster.DivisionId = Convert.ToInt32(cbDivision.SelectedValue);
            _StudentMaster.DepartmentId = Convert.ToInt32(cbDepartment.SelectedValue);
            _StudentMaster.GRNumber = Convert.ToInt32(txtGRNumber.Text.Trim());
            _StudentMaster.FirstName = txtFirstName.Text.Trim();
            _StudentMaster.MiddleName = txtMiddleName.Text.Trim();
            _StudentMaster.LastName = txtSurname.Text.Trim();
            _StudentMaster.FatherName = txtFatherName.Text.Trim();
            _StudentMaster.MotherName = txtMotherName.Text.Trim();
            _StudentMaster.BirthDate = dtBirthDate.Value;
            _StudentMaster.RegisterDate = dtRegistrationDate.Value;
            _StudentMaster.IsGender = rbtnMale.Checked;
            _StudentMaster.City = txtCity.Text.Trim();
            _StudentMaster.Address = txtAddress.Text.Trim();
            _StudentMaster.MobileNo = txtMobileNo.Text.Trim();
            _StudentMaster.PhoneNo = txtPhoneNo.Text.Trim();
            _StudentMaster.YearId = Convert.ToInt32(Properties.Settings.Default.YearId);
            _StudentMaster.Category = Convert.ToString(cbCategory.SelectedItem);

            Result<bool> _Result = _StudentService.SaveStudent(_StudentMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                SaveFeesDetail(Convert.ToInt32(_Result.Id));

                MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _IsRefresh = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFeesDetail()
        {
            if (_IsSaveRegularFees)
            {
                chkAllRegularFees.Checked = false;
                tvRegularFees.Nodes.Clear();

                if (cbStandard.SelectedIndex > 0 && cbDepartment.SelectedIndex > 0)
                {
                    Result<DataTable> _Result = _FeesService.GetAllFeesByStandardDepartment(Convert.ToInt32(cbStandard.SelectedValue), Convert.ToInt32(cbDepartment.SelectedValue), false, Convert.ToString(Properties.Settings.Default.Year));

                    if (_Result.IsSuccess)
                    {
                        if (_Result.Data != null)
                        {
                            DataColumn _Column = new DataColumn("ViewFees", typeof(System.String));

                            _Result.Data.Columns.Add(_Column);

                            _Column = new DataColumn("ID", typeof(System.String));

                            _Result.Data.Columns.Add(_Column);

                            foreach (DataRow _Row in _Result.Data.Rows)
                            {
                                _Row["ViewFees"] = _Row["DisplayFeesName"] + " --> " + Convert.ToString(_Row["Fees"]);
                                _Row["ID"] = _Row["FeesID"] + "_" + Convert.ToString(_Row["Fees"]);

                                TreeNode _TreeNode = new TreeNode();
                                _TreeNode.Text = Convert.ToString(_Row["ViewFees"]);
                                _TreeNode.Name = Convert.ToString(_Row["ID"]);
                                _TreeNode.Checked = false;

                                tvRegularFees.Nodes.Add(_TreeNode);
                            }
                        }
                    }
                }
            }

            if (_IsSaveOtherFees)
            {
                chkAllOtherFees.Checked = false;
                tvOtherFees.Nodes.Clear();

                if (cbStandard.SelectedIndex > 0 && cbDepartment.SelectedIndex > 0)
                {
                    Result<DataTable> _Result = _FeesService.GetAllFeesByStandardDepartment(Convert.ToInt32(cbStandard.SelectedValue), Convert.ToInt32(cbDepartment.SelectedValue), true, Convert.ToString(Properties.Settings.Default.Year));

                    if (_Result.IsSuccess)
                    {
                        if (_Result.Data != null)
                        {
                            DataColumn _Column = new DataColumn("ViewFees", typeof(System.String));

                            _Result.Data.Columns.Add(_Column);

                            _Column = new DataColumn("ID", typeof(System.String));

                            _Result.Data.Columns.Add(_Column);

                            foreach (DataRow _Row in _Result.Data.Rows)
                            {
                                _Row["ViewFees"] = _Row["DisplayFeesName"] + " --> " + Convert.ToString(_Row["Fees"]);
                                _Row["ID"] = _Row["FeesID"] + "_" + Convert.ToString(_Row["Fees"]);

                                TreeNode _TreeNode = new TreeNode();
                                _TreeNode.Text = Convert.ToString(_Row["ViewFees"]);
                                _TreeNode.Name = Convert.ToString(_Row["ID"]);
                                _TreeNode.Checked = false;

                                tvOtherFees.Nodes.Add(_TreeNode);
                            }
                        }
                    }
                }
            }
        }

        private void SaveFeesDetail(int p_StudentId)
        {
            if (_IsSaveRegularFees)
            {
                foreach (TreeNode _Node in tvRegularFees.Nodes)
                {
                    if (_Node.Checked)
                    {
                        if (_ListOfCollectRegularFees == null)
                        {
                            _ListOfCollectRegularFees = new List<CollectFeesMaster>();
                        }

                        CollectFeesMaster _CollectFeesMaster = new CollectFeesMaster();

                        _CollectFeesMaster.FeesId = Convert.ToInt32(_Node.Name.Split('_')[0]);
                        _CollectFeesMaster.Fees = Convert.ToDecimal(_Node.Name.Split('_')[1]);
                        _CollectFeesMaster.PayFees = _CollectFeesMaster.Fees;
                        _CollectFeesMaster.YearId = Convert.ToInt32(Properties.Settings.Default.YearId);

                        _ListOfCollectRegularFees.Add(_CollectFeesMaster);
                    }
                }

                _CollectFeesService.SaveCollectFees(_ListOfCollectRegularFees, p_StudentId, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));
            }

            if (_IsSaveOtherFees)
            {
                foreach (TreeNode _Node in tvOtherFees.Nodes)
                {
                    if (_Node.Checked)
                    {
                        if (_ListOfCollectOtherFees == null)
                        {
                            _ListOfCollectOtherFees = new List<CollectFeesMaster>();
                        }

                        CollectFeesMaster _CollectFeesMaster = new CollectFeesMaster();

                        _CollectFeesMaster.FeesId = Convert.ToInt32(_Node.Name.Split('_')[0]);
                        _CollectFeesMaster.Fees = Convert.ToDecimal(_Node.Name.Split('_')[1]);
                        _CollectFeesMaster.PayFees = _CollectFeesMaster.Fees;
                        _CollectFeesMaster.YearId = Convert.ToInt32(Properties.Settings.Default.YearId);

                        _ListOfCollectOtherFees.Add(_CollectFeesMaster);
                    }
                }

                _CollectFeesService.SaveCollectFees(_ListOfCollectOtherFees, p_StudentId, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));
            }
        }

        private void dtBirthDate_ValueChanged(object sender, EventArgs e)
        {
            //DateTime compareTo;
            //DateTime.TryParse(dtBirthDate.ToString(),out compareTo);
            //DateTime now = DateTime.Now;
            //int dateSpan = DateTime.Compare(compareTo, now);
            //Console.WriteLine("Years: " + dateSpan.Years);
            //Console.WriteLine("Months: " + dateSpan.Months);
        }

        private void dtBirthDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //DateTime compareTo;
            //DateTime.TryParse(dtBirthDate.ToString(), out compareTo);
            //DateTime now = DateTime.Now;
            //int dateSpan = DateTime.Compare(compareTo, now);
            //Console.WriteLine("Years: " + dateSpan.Years);
            //Console.WriteLine("Months: " + dateSpan.Months);
        }

        private void dtBirthDate_Leave(object sender, EventArgs e)
        {
            DateTime _Now = DateTime.Now;
            DateTime _DOB = Convert.ToDateTime(dtBirthDate.Value);

            double _Month = _Now.Subtract(_DOB).Days / (365.25 / 12);

            int _Mnth = Convert.ToInt32(_Month);

            if (_Mnth > 0)
            {
                if (_Mnth > 12)
                {
                    int _Year =_Mnth / 12;
                    int _Months = _Mnth % 12;

                    lblAgeValue.Text = _Year + " Years and " + _Months + " Months";
                }
            }
        }

        private void FillLastRegistrationDate()
        {   
            try
            {
                Result<DateTime> _Result = _StudentService.GetLastRegistrationDate();

                if (_Result.IsSuccess)
                {
                    dtRegistrationDate.Value = _Result.Data;
                }
                else
                {
                    dtRegistrationDate.Value = DateTime.Now;
                }
            }
            catch (Exception)
            {
               // MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        #endregion

    }
}
