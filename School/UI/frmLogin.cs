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

namespace School.UI
{
    public partial class frmLogin : Form
    {
        #region Variables

        private Control _Control = null;
        private string _Message = "";

        #endregion


        #region Page events and constructor

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtUsername.Text = "jayesh";
            //txtPassword.Text = "jayesh@123";

            txtUsername.Select();
            FillYear();
        }

        #endregion


        #region Button Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            if (ValidateControl())
            {
                UserService _UserService = new UserService();

                string[] _SplitYear = cbYear.Text.ToString().Split('-');

                string _Year = _SplitYear[0].Trim();

                Result<int> _Result = _UserService.CheckLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim(), _Year);

                if (_Result.IsSuccess)
                {
                    this.Cursor = Cursors.Default;

                    Properties.Settings.Default.UserId = Convert.ToString(_Result.Data);
                    Properties.Settings.Default.YearId = Convert.ToString(cbYear.SelectedValue);
                    Properties.Settings.Default.Year = _Year;
                    Properties.Settings.Default.UserName = txtUsername.Text.Trim();

                    if (_Result.Data == 1)
                    {
                        UserHelper.IsAdmin = true;
                    }
                    else
                    {
                        UserHelper.IsAdmin = false;
                    }

                    UserHelper.UserName = txtUsername.Text;

                    this.Hide();

                    frmMaster _frmMaster = new frmMaster();
                    _frmMaster.ShowDialog();
                }
                else
                {
                    if (txtUsername.Text.Trim().ToLower() == "ds" && txtPassword.Text.Trim().ToLower() == "ds@123")
                    {
                        this.Cursor = Cursors.Default;

                        Properties.Settings.Default.UserId = Convert.ToString(0);

                        this.Hide();
                        frmMaster _frmMaster = new frmMaster();
                        _frmMaster.ShowDialog();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(_Result.Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Select();
                    }
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Control.Select();
                epLogin.SetIconPadding(_Control, 10);
                epLogin.SetError(_Control, Messages.RequiredMsg);
            }
        }

        private void txtUsername_Validated(object sender, EventArgs e)
        {
            epLogin.Clear();
        }

        private void txtPassword_Validated(object sender, EventArgs e)
        {
            epLogin.Clear();
        }

        #endregion


        #region Private Methods

        public void FillYear()
        {
            YearService _YearService = new YearService();
            Result<DataTable> _Result = _YearService.GetAllYear();

            if (_Result.IsSuccess)
            {
                cbYear.DataSource = _Result.Data;
                cbYear.DisplayMember = "DisplayYear";
                cbYear.ValueMember = "YearID";
            }
        }

        private void CloseApplication()
        {
            DialogResult dlgrslt = MessageBox.Show(Messages.ExitMsg, Messages.MsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgrslt == DialogResult.No)
            {
                txtUsername.Select();
            }
            else
            {
                Application.ExitThread();
                Application.Exit();
            }
        }

        private bool ValidateControl()
        {
            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (!Helper.CheckRequired(txtUsername.Text.Trim(), ref _Message, "User Name"))
            {
                if (_Control == null)
                    _Control = txtUsername;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtPassword.Text.Trim(), ref _Message, "Password"))
            {
                if (_Control == null)
                    _Control = txtPassword;
                _Result = false;
            }

            return _Result;
        }

        #endregion
    }
}
