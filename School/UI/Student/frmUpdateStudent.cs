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

namespace School.UI.Student
{
    public partial class frmUpdateStudent : Form
    {
        #region Variables

        private StudentService _StudentService = new StudentService();
        private StandardService _StandardService = new StandardService();
        private DepartmentService _DepartmentService = new DepartmentService();
        private DivisionService _DivisionService = new DivisionService();

        private Control _Control = null;
        private string _Message = "";

        #endregion


        #region Page events and constructor

        public frmUpdateStudent()
        {
            InitializeComponent();
        }

        private void frmUpdateStudent_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillDepartment();
            FillStandard();
            FillDivision();

            gvOldStudent.AutoGenerateColumns = false;
            gvNewStudent.AutoGenerateColumns = false;

            this.Cursor = Cursors.Default;
        }

        #endregion


        #region Button Events

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (ValidateControl())
                {
                    if (MessageBox.Show(Messages.UpProcessMsg, Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ProcessStudent();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Control.Select();
                    epUpdateStudent.SetIconPadding(_Control, 10);
                    epUpdateStudent.SetError(_Control, Messages.RequiredMsg);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void cbOldStandardDivisionDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOldStudent();
        }

        private void cbNewStandardDivisionDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillNewStudent();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gvOldStudent.Rows)
            {
                row.Cells["IsContinue"].Value = chkSelectAll.Checked;
            }
        }

        private void gvOldStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvOldStudent.CurrentCell.RowIndex;
                int colindex = gvOldStudent.CurrentCell.ColumnIndex;

                if (gvOldStudent.Columns[colindex].Name == "Leave")
                {
                    int _Id = Convert.ToInt32(gvOldStudent.Rows[rowindex].Cells["OldStudentID"].Value);

                    if (MessageBox.Show(string.Format(Messages.LeaveMsg, "Student"), Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Result<bool> _Result = _StudentService.DeleteStudentById(_Id, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                        if (_Result.IsSuccess)
                        {
                            FillOldStudent();
                        }
                        else
                        {
                            MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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
                cbOldDepartment.DataSource = _Result.Data;
                cbOldDepartment.DisplayMember = "Department";
                cbOldDepartment.ValueMember = "DepartmentID";

                cbNewDepartment.DataSource = _Result.Data.Copy();
                cbNewDepartment.DisplayMember = "Department";
                cbNewDepartment.ValueMember = "DepartmentID";
            }
        }

        private void FillStandard()
        {
            Result<DataTable> _Result = _StandardService.GetAllStandard(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbOldStandard.DataSource = _Result.Data;
                cbOldStandard.DisplayMember = "Standard";
                cbOldStandard.ValueMember = "StandardID";

                cbNewStandard.DataSource = _Result.Data.Copy();
                cbNewStandard.DisplayMember = "Standard";
                cbNewStandard.ValueMember = "StandardID";
            }
        }

        private void FillDivision()
        {
            Result<DataTable> _Result = _DivisionService.GetAllDivision(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                DataRow _DataRow = _Result.Data.NewRow();
                _DataRow[0] = 0;
                _DataRow[1] = "-- Select --";

                _Result.Data.Rows.InsertAt(_DataRow, 0);
                cbOldDivision.DataSource = _Result.Data;
                cbOldDivision.DisplayMember = "Division";
                cbOldDivision.ValueMember = "DivisionID";

                cbNewDivision.DataSource = _Result.Data.Copy();
                cbNewDivision.DisplayMember = "Division";
                cbNewDivision.ValueMember = "DivisionID";
            }
        }

        private void FillOldStudent()
        {
            gvOldStudent.DataSource = null;
            gvOldStudent.Rows.Clear();

            if (cbOldStandard.SelectedIndex > 0 && cbOldDivision.SelectedIndex > 0 && cbOldDepartment.SelectedIndex > 0)
            {
                Result<DataTable> _Result = _StudentService.GetOldStudentByStandardDivisionDepartment(Convert.ToInt32(cbOldStandard.SelectedValue), Convert.ToInt32(cbOldDivision.SelectedValue), Convert.ToInt32(cbOldDepartment.SelectedValue), Convert.ToString(Properties.Settings.Default.Year));

                if (_Result.IsSuccess)
                {
                    if (_Result.Data != null)
                    {
                        gvOldStudent.DataSource = _Result.Data;
                    }
                }
            }
        }

        private void FillNewStudent()
        {
            gvNewStudent.DataSource = null;
            gvNewStudent.Rows.Clear();

            if (cbNewStandard.SelectedIndex > 0 && cbNewDivision.SelectedIndex > 0 && cbNewDepartment.SelectedIndex > 0)
            {
                Result<DataTable> _Result = _StudentService.GetNewStudentByStandardDivisionDepartment(Convert.ToInt32(cbNewStandard.SelectedValue), Convert.ToInt32(cbNewDivision.SelectedValue), Convert.ToInt32(cbNewDepartment.SelectedValue), Convert.ToString(Properties.Settings.Default.Year));

                if (_Result.IsSuccess)
                {
                    if (_Result.Data != null)
                    {
                        gvNewStudent.DataSource = _Result.Data;
                    }
                }
            }
        }

        private void ClearControls()
        {
            epUpdateStudent.Clear();
            cbOldDepartment.Select();
            cbOldStandard.SelectedIndex = 0;
            cbOldDivision.SelectedIndex = 0;
            cbOldDepartment.SelectedIndex = 0;
            cbNewStandard.SelectedIndex = 0;
            cbNewDivision.SelectedIndex = 0;
            cbNewDepartment.SelectedIndex = 0;

            gvOldStudent.DataSource = null;
            gvOldStudent.Rows.Clear();

            gvNewStudent.DataSource = null;
            gvNewStudent.Rows.Clear();
        }

        private bool ValidateControl()
        {
            epUpdateStudent.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (cbNewDepartment.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Department!";
                if (_Control == null)
                    _Control = cbNewDepartment;
                _Result = false;
            }

            if (cbNewStandard.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Standard!";
                if (_Control == null)
                    _Control = cbNewStandard;
                _Result = false;
            }

            if (cbNewDivision.SelectedIndex <= 0)
            {
                _Message += "\n ---> Select Division!";
                if (_Control == null)
                    _Control = cbNewDivision;
                _Result = false;
            }

            if (_Result)
            {
                _Result = false;
                if (gvOldStudent.DataSource != null)
                {
                    foreach (DataGridViewRow _Row in gvOldStudent.Rows)
                    {
                        if (Convert.ToBoolean(_Row.Cells["IsContinue"].Value))
                        {
                            _Result = true;
                            break;
                        }
                    }
                }

                if (!_Result)
                {
                    _Message += "\n ---> Please select atleast one continue student!";
                    if (_Control == null)
                        _Control = gvOldStudent;
                }
            }

            return _Result;
        }

        private void ProcessStudent()
        {
            string _StudentIds = string.Empty;
            foreach (DataGridViewRow _Row in gvOldStudent.Rows)
            {
                if (Convert.ToBoolean(_Row.Cells["IsContinue"].Value))
                {
                    if (string.IsNullOrEmpty(_StudentIds))
                    {
                        _StudentIds = Convert.ToString(_Row.Cells["OldStudentID"].Value);
                    }
                    else
                    {
                        _StudentIds = _StudentIds + "," + Convert.ToString(_Row.Cells["OldStudentID"].Value);
                    }
                }
            }

            if (!string.IsNullOrEmpty(_StudentIds))
            {
                Result<bool> _Result = _StudentService.UpdateUpStudentByStudentIds(_StudentIds,Convert.ToInt32(cbNewStandard.SelectedValue), Convert.ToInt32(cbNewDivision.SelectedValue), Convert.ToInt32(cbNewDepartment.SelectedValue), Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                if (_Result.IsSuccess)
                {
                    bool _IsClose = false;

                    Result<bool> _ResultCheck = _StudentService.CheckUpdateStudent(Convert.ToString(Properties.Settings.Default.Year));

                    if (_ResultCheck.IsSuccess)
                    {
                        if (!_ResultCheck.Data)
                        {
                            _IsClose = true;
                        }
                    }

                    if (_IsClose)
                    {
                        frmMaster _frmMaster = (frmMaster)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmMaster").FirstOrDefault();
                        _frmMaster.CheckUpdateStudent();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Messages.UpProcessSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FillOldStudent();
                        FillNewStudent();
                    }
                }
                else
                {
                    MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

    }
}
