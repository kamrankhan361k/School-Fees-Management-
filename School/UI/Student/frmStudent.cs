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

namespace School.UI.Student
{
    public partial class frmStudent : Form
    {
        #region Variables

        private StudentService _StudentService = new StudentService();
        private DataTable _StudentDataTable = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;

        #endregion

        #region Page events and constructor

        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            txtSearch.Select();

            gvStudent.Columns["Edit"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));
            gvStudent.Columns["Leave"].Visible = Helper.IsEditDeletePower(Convert.ToString(Properties.Settings.Default.UserName));

            FillStudentDataTable();

            gvStudent.AutoGenerateColumns = false;

            FillGrid();

            _FirstLoad = false;

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Button Events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenSaveStudent(null);
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillStudentDataTable();
            FillGrid();
        }

        private void cbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_FirstLoad)
            {
                if (cbPages.SelectedIndex >= 0)
                {
                    _PageNo = Convert.ToInt32(cbPages.Text);
                }
                FillGrid();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            _PageNo = 1;
            cbPages.Text = _PageNo.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_PageNo > 1)
            {
                _PageNo--;
                cbPages.Text = _PageNo.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _PageNo++;
            cbPages.Text = _PageNo.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _PageNo = cbPages.Items.Count;
            cbPages.Text = _PageNo.ToString();
        }

        private void gvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int rowindex = gvStudent.CurrentCell.RowIndex;
                int colindex = gvStudent.CurrentCell.ColumnIndex;
                if (gvStudent.Columns[colindex].Name == "Edit")
                {
                    int _Id = Convert.ToInt32(gvStudent.Rows[rowindex].Cells["Id"].Value);

                    OpenSaveStudent(_Id);
                }
                else if (gvStudent.Columns[colindex].Name == "Leave")
                {
                    int _Id = Convert.ToInt32(gvStudent.Rows[rowindex].Cells["Id"].Value);

                    if (MessageBox.Show(string.Format(Messages.LeaveMsg, "Student"), Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Result<bool> _Result = _StudentService.DeleteStudentById(_Id, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                        if (_Result.IsSuccess)
                        {
                            DataRow[] _DataRow = _StudentDataTable.Select("StudentID=" + _Id);
                            if (_DataRow.Count() > 0)
                            {
                                _DataRow[0]["IsActive"] = false;
                            }

                            FillGrid();
                            frmMaster _frmMaster = (frmMaster)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmMaster").FirstOrDefault();
                            if (_frmMaster != null)
                            {
                                _frmMaster.UpdateDashBoardDetail();
                            }
                        }
                        else
                        {
                            MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void gvStudent_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Selected == true)
            {
                if (!string.IsNullOrEmpty(cbPages.Text))
                {
                    int _RowNo = (((Convert.ToInt32(cbPages.Text) * 10) - 10) + 1 + e.Row.Index);

                    CommonFunction.SetSelectRowNo(_RowNo, _TotalRecords, lblSelectRow);
                }
            }
        }

        private void gvStudent_Sorted(object sender, EventArgs e)
        {
            GridSettings();
        }

        #endregion

        #region Private Methods

        public void FillStudentDataTable()
        {
            Result<DataTable> _Result = _StudentService.GetAllStudent(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                _StudentDataTable = _Result.Data;
            }
        }

        public void FillGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvStudent.DataSource = null;
            gvStudent.Rows.Clear();

            DataTable _DataTable = _StudentDataTable;

            if (_StudentDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    string _Search = txtSearch.Text.Trim().ToLower();

                    EnumerableRowCollection<DataRow> _Query = from s in _StudentDataTable.AsEnumerable()
                                                              where s.Field<string>("Standard").ToLower().Contains(_Search) || s.Field<string>("Division").ToLower().Contains(_Search) || s.Field<string>("Department").ToLower().Contains(_Search) || s.Field<string>("Name").ToLower().Contains(_Search) || s.Field<string>("Gender").ToLower().Contains(_Search) 
                                                              select s;

                    _DataTable = _Query.AsDataView().ToTable();
                }

                if (_DataTable != null)
                {
                    _TotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _TotalRecords, gvStudent, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
            }

            GridSettings();

            this.Cursor = Cursors.Default;
        }

        private void GridSettings()
        {
            foreach (DataGridViewRow _Row in gvStudent.Rows)
            {
                if (!Convert.ToBoolean(_Row.Cells["IsActive"].Value))
                {
                    _Row.Cells["Edit"].Value = (System.Drawing.Image)Properties.Resources.Empty;
                    _Row.Cells["Leave"].Value = (System.Drawing.Image)Properties.Resources.Empty;
                    _Row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F95959");
                }
            }
        }

        private void OpenSaveStudent(int? p_StudentId)
        {
            frmSaveStudent _frmSaveStudent = (frmSaveStudent)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmSaveStudent").FirstOrDefault();
            if (_frmSaveStudent != null)
            {
                _frmSaveStudent.Focus();
            }
            else
            {
                _frmSaveStudent = new frmSaveStudent(p_StudentId);
                _frmSaveStudent.Show();
                _frmSaveStudent.Focus();
            }
        }

        #endregion

       
    }
}
