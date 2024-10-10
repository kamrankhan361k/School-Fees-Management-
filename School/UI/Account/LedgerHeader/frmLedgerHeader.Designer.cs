namespace School.UI.Account.LedgerHeader
{
    partial class frmLedgerHeader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLedgerHeader));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gvLedgerHeader = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.LedgerHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.cbPages = new System.Windows.Forms.ComboBox();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.lblSelectRow = new System.Windows.Forms.Label();
            this.txtLedgerHeader = new System.Windows.Forms.TextBox();
            this.lblLedgerHeader = new System.Windows.Forms.Label();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.epLedgerHeader = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlSave = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtLedgerHeadernm = new System.Windows.Forms.TextBox();
            this.lblLedgerHeadernm = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedgerHeader)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLedgerHeader)).BeginInit();
            this.pnlSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.LightBlue;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(828, 39);
            this.pnlTitle.TabIndex = 57;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(158, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "View Ledger Header";
            // 
            // gvLedgerHeader
            // 
            this.gvLedgerHeader.AllowUserToAddRows = false;
            this.gvLedgerHeader.AllowUserToDeleteRows = false;
            this.gvLedgerHeader.AllowUserToResizeColumns = false;
            this.gvLedgerHeader.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gvLedgerHeader.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLedgerHeader.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvLedgerHeader.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvLedgerHeader.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gvLedgerHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvLedgerHeader.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLedgerHeader.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvLedgerHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLedgerHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete,
            this.LedgerHeader,
            this.Description,
            this.Id});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLedgerHeader.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvLedgerHeader.Location = new System.Drawing.Point(0, 130);
            this.gvLedgerHeader.MultiSelect = false;
            this.gvLedgerHeader.Name = "gvLedgerHeader";
            this.gvLedgerHeader.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLedgerHeader.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvLedgerHeader.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gvLedgerHeader.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvLedgerHeader.RowTemplate.Height = 35;
            this.gvLedgerHeader.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLedgerHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLedgerHeader.Size = new System.Drawing.Size(566, 392);
            this.gvLedgerHeader.TabIndex = 56;
            this.gvLedgerHeader.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLedgerHeader_CellContentClick);
            this.gvLedgerHeader.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gvLedgerHeader_RowStateChanged);
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.FillWeight = 105.1208F;
            this.Edit.Frozen = true;
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = global::School.Properties.Resources.Edit;
            this.Edit.Name = "Edit";
            this.Edit.ToolTipText = "Edit";
            this.Edit.Width = 50;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.FillWeight = 119.8521F;
            this.Delete.Frozen = true;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = global::School.Properties.Resources.Delete;
            this.Delete.Name = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.Width = 60;
            // 
            // LedgerHeader
            // 
            this.LedgerHeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LedgerHeader.DataPropertyName = "LedgerHeader";
            this.LedgerHeader.FillWeight = 61.81106F;
            this.LedgerHeader.HeaderText = "Ledger Header";
            this.LedgerHeader.Name = "LedgerHeader";
            this.LedgerHeader.ReadOnly = true;
            this.LedgerHeader.Width = 200;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "LedgerHeaderId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnExist);
            this.pnlFooter.Controls.Add(this.btnLast);
            this.pnlFooter.Controls.Add(this.btnFirst);
            this.pnlFooter.Controls.Add(this.btnNext);
            this.pnlFooter.Controls.Add(this.btnPrevious);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 528);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(828, 46);
            this.pnlFooter.TabIndex = 59;
            // 
            // btnExist
            // 
            this.btnExist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExist.BackgroundImage")));
            this.btnExist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExist.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExist.ForeColor = System.Drawing.Color.White;
            this.btnExist.Location = new System.Drawing.Point(742, 9);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 30);
            this.btnExist.TabIndex = 4;
            this.btnExist.Text = "&Exit";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLast.BackgroundImage")));
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLast.ForeColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(285, 9);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 30);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = "&Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFirst.BackgroundImage")));
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.Location = new System.Drawing.Point(12, 9);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "&First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(194, 9);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrevious.BackgroundImage")));
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(103, 9);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 30);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // cbPages
            // 
            this.cbPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPages.FormattingEnabled = true;
            this.cbPages.Location = new System.Drawing.Point(752, 8);
            this.cbPages.Name = "cbPages";
            this.cbPages.Size = new System.Drawing.Size(62, 23);
            this.cbPages.TabIndex = 0;
            this.cbPages.SelectedIndexChanged += new System.EventHandler(this.cbPages_SelectedIndexChanged);
            // 
            // lblPageNo
            // 
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.Location = new System.Drawing.Point(650, 11);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(101, 15);
            this.lblPageNo.TabIndex = 31;
            this.lblPageNo.Text = "Select Page No : ";
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.lblSelectRow);
            this.pnlAction.Controls.Add(this.cbPages);
            this.pnlAction.Controls.Add(this.lblPageNo);
            this.pnlAction.Location = new System.Drawing.Point(0, 92);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(829, 39);
            this.pnlAction.TabIndex = 58;
            // 
            // lblSelectRow
            // 
            this.lblSelectRow.AutoSize = true;
            this.lblSelectRow.Location = new System.Drawing.Point(13, 11);
            this.lblSelectRow.Name = "lblSelectRow";
            this.lblSelectRow.Size = new System.Drawing.Size(97, 15);
            this.lblSelectRow.TabIndex = 23;
            this.lblSelectRow.Text = "Select Row No : ";
            // 
            // txtLedgerHeader
            // 
            this.txtLedgerHeader.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLedgerHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLedgerHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerHeader.Location = new System.Drawing.Point(110, 20);
            this.txtLedgerHeader.Margin = new System.Windows.Forms.Padding(0);
            this.txtLedgerHeader.MaxLength = 200;
            this.txtLedgerHeader.Name = "txtLedgerHeader";
            this.txtLedgerHeader.Size = new System.Drawing.Size(306, 21);
            this.txtLedgerHeader.TabIndex = 0;
            this.txtLedgerHeader.TextChanged += new System.EventHandler(this.txtLedgerHeader_TextChanged);
            // 
            // lblLedgerHeader
            // 
            this.lblLedgerHeader.AutoSize = true;
            this.lblLedgerHeader.ForeColor = System.Drawing.Color.Black;
            this.lblLedgerHeader.Location = new System.Drawing.Point(15, 23);
            this.lblLedgerHeader.Name = "lblLedgerHeader";
            this.lblLedgerHeader.Size = new System.Drawing.Size(96, 15);
            this.lblLedgerHeader.TabIndex = 35;
            this.lblLedgerHeader.Text = "Ledger Header: ";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnRefresh);
            this.gbSearch.Controls.Add(this.txtLedgerHeader);
            this.gbSearch.Controls.Add(this.lblLedgerHeader);
            this.gbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(124)))), ((int)(((byte)(151)))));
            this.gbSearch.Location = new System.Drawing.Point(3, 36);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(823, 54);
            this.gbSearch.TabIndex = 60;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(739, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // epLedgerHeader
            // 
            this.epLedgerHeader.ContainerControl = this;
            // 
            // pnlSave
            // 
            this.pnlSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSave.Controls.Add(this.txtDescription);
            this.pnlSave.Controls.Add(this.lblDescription);
            this.pnlSave.Controls.Add(this.btnCancel);
            this.pnlSave.Controls.Add(this.txtLedgerHeadernm);
            this.pnlSave.Controls.Add(this.lblLedgerHeadernm);
            this.pnlSave.Controls.Add(this.btnSave);
            this.pnlSave.Location = new System.Drawing.Point(564, 130);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(265, 392);
            this.pnlSave.TabIndex = 61;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(35, 134);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(0);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(199, 76);
            this.txtDescription.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(35, 108);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 15);
            this.lblDescription.TabIndex = 54;
            this.lblDescription.Text = "Description :*";
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(159, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtLedgerHeadernm
            // 
            this.txtLedgerHeadernm.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLedgerHeadernm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLedgerHeadernm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLedgerHeadernm.Location = new System.Drawing.Point(35, 66);
            this.txtLedgerHeadernm.Margin = new System.Windows.Forms.Padding(0);
            this.txtLedgerHeadernm.MaxLength = 200;
            this.txtLedgerHeadernm.Name = "txtLedgerHeadernm";
            this.txtLedgerHeadernm.Size = new System.Drawing.Size(199, 21);
            this.txtLedgerHeadernm.TabIndex = 0;
            // 
            // lblLedgerHeadernm
            // 
            this.lblLedgerHeadernm.AutoSize = true;
            this.lblLedgerHeadernm.ForeColor = System.Drawing.Color.Black;
            this.lblLedgerHeadernm.Location = new System.Drawing.Point(35, 40);
            this.lblLedgerHeadernm.Name = "lblLedgerHeadernm";
            this.lblLedgerHeadernm.Size = new System.Drawing.Size(91, 15);
            this.lblLedgerHeadernm.TabIndex = 51;
            this.lblLedgerHeadernm.Text = "Ledger Name:*";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(35, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.FillWeight = 105.1208F;
            this.dataGridViewImageColumn1.Frozen = true;
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.Image = global::School.Properties.Resources.Edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ToolTipText = "Edit";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.FillWeight = 119.8521F;
            this.dataGridViewImageColumn2.Frozen = true;
            this.dataGridViewImageColumn2.HeaderText = "Delete";
            this.dataGridViewImageColumn2.Image = global::School.Properties.Resources.Delete;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ToolTipText = "Delete";
            this.dataGridViewImageColumn2.Width = 60;
            // 
            // frmLedgerHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 574);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.gvLedgerHeader);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.pnlSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLedgerHeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ledger Header";
            this.Load += new System.EventHandler(this.frmLedgerHeader_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedgerHeader)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLedgerHeader)).EndInit();
            this.pnlSave.ResumeLayout(false);
            this.pnlSave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gvLedgerHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.ComboBox cbPages;
        private System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Label lblSelectRow;
        private System.Windows.Forms.TextBox txtLedgerHeader;
        private System.Windows.Forms.Label lblLedgerHeader;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ErrorProvider epLedgerHeader;
        private System.Windows.Forms.Panel pnlSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLedgerHeadernm;
        private System.Windows.Forms.Label lblLedgerHeadernm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn LedgerHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}