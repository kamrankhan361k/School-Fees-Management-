using School.Common;
using School.DataAccess;
using School.DataModel;
using School.Helpers;
using School.UI.Fees;
using School.UI.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.UI.Year
{
    public partial class frmYear : Form
    {
        #region Variables

        private YearService _YearService = new YearService();
        private DataTable _YearDataTable = null;
        private int _PageNo = 1, _TotalRecords = 0;
        private bool _FirstLoad = true;
        private Control _Control = null;
        private string _Message = "";
        public int _PageId = 0;

        #endregion

        #region Page events and constructor

        public frmYear()
        {
            InitializeComponent();
        }

        private void frmYear_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            txtYearName.Text = Convert.ToString(DateTime.Now.Year) + " - " + Convert.ToString(DateTime.Now.Year + 1);

            txtYear.Select();
            FillYearDataTable();
            FillAutoSuggestYear();

            gvYear.AutoGenerateColumns = false;

            FillGrid();

            _FirstLoad = false;

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Button Events

        private void txtStandard_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControl())
            {
                SaveYear();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Control.Select();
                epYear.SetIconPadding(_Control, 10);
                epYear.SetError(_Control, Messages.RequiredMsg);
            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillYearDataTable();
            FillAutoSuggestYear();
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

        private void gvYear_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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

        #endregion

        #region Private Methods

        private void FillYearDataTable()
        {
            Result<DataTable> _Result = _YearService.GetAllYear();

            if (_Result.IsSuccess)
            {
                _YearDataTable = _Result.Data;
            }
        }

        private void FillAutoSuggestYear()
        {
            if (_YearDataTable != null)
            {
                AutoCompleteStringCollection _AutoComplete = new AutoCompleteStringCollection();

                string[] postSource = _YearDataTable
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("DisplayYear"))
                    .ToArray();

                _AutoComplete.AddRange(postSource);

                txtYear.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtYear.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtYear.AutoCompleteCustomSource = _AutoComplete;
            }
        }

        private void FillGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            gvYear.DataSource = null;
            gvYear.Rows.Clear();

            DataTable _DataTable = _YearDataTable;

            if (_YearDataTable != null)
            {
                if (!string.IsNullOrEmpty(txtYear.Text.Trim()))
                {
                    _YearDataTable.DefaultView.RowFilter = "DisplayYear ='" + txtYear.Text.Trim() + "'";
                    _DataTable = _YearDataTable.DefaultView.ToTable();
                }

                if (_DataTable != null)
                {
                    _TotalRecords = _DataTable.Rows.Count;
                }

                CommonFunction.GridPagging(_DataTable, _TotalRecords, gvYear, this._PageNo, lblSelectRow, cbPages, btnFirst, btnPrevious, btnLast, btnNext);
            }

            this.Cursor = Cursors.Default;
        }

        private bool ValidateControl()
        {
            epYear.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (!Helper.CheckRequired(txtYearName.Text.Trim(), ref _Message, "Year"))
            {
                if (_Control == null)
                    _Control = txtYearName;
                _Result = false;
            }

            if (_Result)
            {
                Result<bool> _ResultData = _YearService.CheckDuplicateYear(Convert.ToString(DateTime.Now.Year));

                if (_ResultData.IsSuccess)
                {
                    if (!_ResultData.Data)
                    {
                        _Result = true;
                    }
                    else
                    {
                        txtYearName.Select();
                        _Result = false;
                        _Message = string.Format(Messages.DuplicateMsg, "Year");
                        if (_Control == null)
                            _Control = txtYearName;
                    }
                }
                else
                {
                    txtYearName.Select();
                    _Result = false;
                    _Message = _ResultData.Message;
                    if (_Control == null)
                        _Control = txtYearName;
                }
            }

            return _Result;
        }

        private void SaveYear()
        {
            YearMaster _YearMaster = new YearMaster();

            _YearMaster.Year = Convert.ToString(DateTime.Now.Year);
            _YearMaster.DisplayYear = txtYearName.Text.Trim();

            Result<int> _Result = _YearService.SaveYear(_YearMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                CreateYearDatabase();

                CollectFeesService _CollectFeesService = new CollectFeesService();
                StudentService _StudentService = new StudentService();

                string _FilePath = Application.StartupPath + "/School_" + Convert.ToString(DateTime.Now.Year) + ".accdb";
                bool _IsResult = false;

                if (File.Exists(_FilePath))
                {
                    Result<bool> _ResultActive = _StudentService.UpdateAllStudent(Convert.ToString(DateTime.Now.Year));

                    if (_ResultActive.IsSuccess)
                    {
                        _ResultActive = _CollectFeesService.TruncateCollectFeesMaster(Convert.ToString(DateTime.Now.Year));

                        if (_ResultActive.IsSuccess)
                        {
                            ReceiptService _ReceiptService = new ReceiptService();

                            _ResultActive = _ReceiptService.TruncateReceiptMaster(Convert.ToString(DateTime.Now.Year));

                            if (_ResultActive.IsSuccess)
                            {
                                _ResultActive = _YearService.ActiveYearById(_Result.Data, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

                                if (_ResultActive.IsSuccess)
                                {
                                    _IsResult = true;
                                    frmLogin _frmLogin = (frmLogin)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmLogin").FirstOrDefault();

                                    if (_frmLogin != null)
                                    {
                                        _frmLogin.FillYear();
                                    }

                                    frmMaster _frmMaster = (frmMaster)Application.OpenForms.Cast<Form>().Where(q => q.Name == "frmMaster").FirstOrDefault();

                                    _frmMaster.LogOff();
                                }
                            }
                        }
                    }

                    if (_IsResult==false)
                    {
                        File.Delete(_FilePath);
                        MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(Messages.ExceptionMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateYearDatabase()
        {
            string _FilePath = Application.StartupPath + "/School_" + Convert.ToString(DateTime.Now.Year) + ".accdb";

            if (File.Exists(_FilePath))
            {
                File.Delete(_FilePath);
            }

            File.Copy("School_" + Convert.ToString(Properties.Settings.Default.Year) + ".accdb", "School_" + Convert.ToString(DateTime.Now.Year) + ".accdb");
        }

        #endregion
    }
}
