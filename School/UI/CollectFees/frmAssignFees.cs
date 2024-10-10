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

namespace School.UI.CollectFees
{
    public partial class frmAssignFees : Form
    {
        #region Variables

        private FeesService _FeesService = new FeesService();
        private CollectFeesService _CollectFeesService = new CollectFeesService();
        private List<CollectFeesMaster> _ListOfCollectRegularFees = null;
        private List<CollectFeesMaster> _ListOfCollectOtherFees = null;
        private int _DepartmentId = 0, _StandardId = 0, _StudentId = 0;

        #endregion


        #region Page events and constructor

        public frmAssignFees()
        {
            InitializeComponent();
        }

        public frmAssignFees(int p_DepartmentId, int p_StandardId, int p_StudentId)
        {
            InitializeComponent();
            _DepartmentId = p_DepartmentId;
            _StandardId = p_StandardId;
            _StudentId = p_StudentId;
        }

        private void frmAssignFees_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FillFeesDetail();

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
            this.Cursor = Cursors.WaitCursor;

            if (_StudentId > 0)
                SaveFeesDetail(_StudentId);

            this.Cursor = Cursors.Default;
        }

        private void chkAllRegularFees_CheckedChanged(object sender, EventArgs e)
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

        private void chkAllOtherFees_CheckedChanged(object sender, EventArgs e)
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

        #endregion


        #region Private Method

        private void FillFeesDetail()
        {
            chkAllRegularFees.Checked = false;
            tvRegularFees.Nodes.Clear();

            if (_DepartmentId > 0 && _StandardId > 0)
            {
                Result<DataTable> _Result = _FeesService.GetAllFeesByStandardDepartment(_StandardId, _DepartmentId, false, Convert.ToString(Properties.Settings.Default.Year));

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

            chkAllOtherFees.Checked = false;
            tvOtherFees.Nodes.Clear();

            if (_DepartmentId > 0 && _StandardId > 0)
            {
                Result<DataTable> _Result = _FeesService.GetAllFeesByStandardDepartment(_StandardId, _DepartmentId, true, Convert.ToString(Properties.Settings.Default.Year));

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

        private void SaveFeesDetail(int p_StudentId)
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
            Result<Boolean> _ResultRegularFees = _CollectFeesService.SaveCollectFees(_ListOfCollectRegularFees, p_StudentId, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));

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
            Result<Boolean> _ResultOtherFees = _CollectFeesService.SaveCollectFees(_ListOfCollectOtherFees, p_StudentId, Convert.ToInt32(Properties.Settings.Default.UserId), Convert.ToString(Properties.Settings.Default.Year));
            
            MessageBox.Show(Messages.SaveSuccessMsg, Messages.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}
