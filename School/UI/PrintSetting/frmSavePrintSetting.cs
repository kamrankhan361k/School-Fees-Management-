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

namespace School.UI.PrintSetting
{
    public partial class frmSavePrintSetting : Form
    {
        #region Variables

        private PrintSettingService _PrintSettingService = new PrintSettingService();
        private int? _PrintSettingId = null;
        private Control _Control = null;
        private string _Message = "";

        #endregion

        #region Page events and constructor

        public frmSavePrintSetting()
        {
            InitializeComponent();
        }

        private void frmSavePrintSetting_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillControls();

            this.Cursor = Cursors.Default;
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
                    SavePrintSetting();

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(_Message, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Control.Select();
                    epPrintSetting.SetIconPadding(_Control, 10);
                    epPrintSetting.SetError(_Control, Messages.RequiredMsg);
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Private Methods

        private void FillControls()
        {
            txtOutputFormat.Select();

            txtOutputFormat.Text = string.Empty;
            txtPageHeight.Text = string.Empty;
            txtPageWidth.Text = string.Empty;
            txtMarginTop.Text = string.Empty;
            txtMarginLeft.Text = string.Empty;
            txtMarginRight.Text = string.Empty;
            txtMarginBottom.Text = string.Empty;
            _PrintSettingId = null;

            Result<PrintSettingMaster> _Result = _PrintSettingService.GetPrintSetting(Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                if (_Result.Data != null)
                {
                    _PrintSettingId = _Result.Data.PrintSettingID;
                    txtOutputFormat.Text = _Result.Data.OutPutFormat;
                    txtPageHeight.Text = Convert.ToString(_Result.Data.PageHeight);
                    txtPageWidth.Text = Convert.ToString(_Result.Data.PageWidth);
                    txtMarginTop.Text = Convert.ToString(_Result.Data.MarginTop);
                    txtMarginLeft.Text = Convert.ToString(_Result.Data.MarginLeft);
                    txtMarginRight.Text = Convert.ToString(_Result.Data.MarginRight);
                    txtMarginBottom.Text = Convert.ToString(_Result.Data.MarginBottom);
                }
            }
        }

        private bool ValidateControl()
        {
            epPrintSetting.Clear();

            bool _Result = true; _Control = null;
            _Message = Messages.ErrorMsgTitle;

            if (!Helper.CheckRequired(txtOutputFormat.Text.Trim(), ref _Message, "Output Format"))
            {
                if (_Control == null)
                    _Control = txtOutputFormat;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtPageHeight.Text.Trim(), ref _Message, "Page Height"))
            {
                if (_Control == null)
                    _Control = txtPageHeight;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtPageWidth.Text.Trim(), ref _Message, "Page Width"))
            {
                if (_Control == null)
                    _Control = txtPageWidth;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtMarginTop.Text.Trim(), ref _Message, "Margin Top"))
            {
                if (_Control == null)
                    _Control = txtMarginTop;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtMarginLeft.Text.Trim(), ref _Message, "Margin Left"))
            {
                if (_Control == null)
                    _Control = txtMarginLeft;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtMarginRight.Text.Trim(), ref _Message, "Margin Right"))
            {
                if (_Control == null)
                    _Control = txtMarginRight;
                _Result = false;
            }

            if (!Helper.CheckRequired(txtMarginBottom.Text.Trim(), ref _Message, "Margin Bottom"))
            {
                if (_Control == null)
                    _Control = txtMarginBottom;
                _Result = false;
            }

            return _Result;
        }

        private void SavePrintSetting()
        {
            PrintSettingMaster _PrintSettingMaster = new PrintSettingMaster();

            _PrintSettingMaster.PrintSettingID = _PrintSettingId;

            _PrintSettingMaster.OutPutFormat = txtOutputFormat.Text.Trim();
            _PrintSettingMaster.PageHeight = Convert.ToDecimal(txtPageHeight.Text.Trim());
            _PrintSettingMaster.PageWidth = Convert.ToDecimal(txtPageWidth.Text.Trim());
            _PrintSettingMaster.MarginTop = Convert.ToDecimal(txtMarginTop.Text.Trim());
            _PrintSettingMaster.MarginLeft = Convert.ToDecimal(txtMarginLeft.Text.Trim());
            _PrintSettingMaster.MarginRight = Convert.ToDecimal(txtMarginRight.Text.Trim());
            _PrintSettingMaster.MarginBottom = Convert.ToDecimal(txtMarginBottom.Text.Trim());

            Result<bool> _Result = _PrintSettingService.SavePrintSetting(_PrintSettingMaster, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

            if (_Result.IsSuccess)
            {
                MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
