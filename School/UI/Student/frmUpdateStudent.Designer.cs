namespace School.UI.Student
{
    partial class frmUpdateStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateStudent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.epUpdateStudent = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblOldStandard = new System.Windows.Forms.Label();
            this.cbOldStandard = new System.Windows.Forms.ComboBox();
            this.cbOldDepartment = new System.Windows.Forms.ComboBox();
            this.lblOldDepartment = new System.Windows.Forms.Label();
            this.cbOldDivision = new System.Windows.Forms.ComboBox();
            this.lblOldDivision = new System.Windows.Forms.Label();
            this.gvOldStudent = new System.Windows.Forms.DataGridView();
            this.IsContinue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Leave = new System.Windows.Forms.DataGridViewImageColumn();
            this.OldGRNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvNewStudent = new System.Windows.Forms.DataGridView();
            this.NewGRNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbNewDivision = new System.Windows.Forms.ComboBox();
            this.lblNewDivision = new System.Windows.Forms.Label();
            this.cbNewDepartment = new System.Windows.Forms.ComboBox();
            this.lblNewDepartment = new System.Windows.Forms.Label();
            this.cbNewStandard = new System.Windows.Forms.ComboBox();
            this.lblNewStandard = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUpdateStudent)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOldStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNewStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.LightBlue;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1059, 36);
            this.pnlTitle.TabIndex = 42;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(106, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Update Student";
            // 
            // epUpdateStudent
            // 
            this.epUpdateStudent.ContainerControl = this;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnExist);
            this.pnlFooter.Controls.Add(this.btnProcess);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 629);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1059, 50);
            this.pnlFooter.TabIndex = 55;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(11, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExist
            // 
            this.btnExist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExist.BackgroundImage")));
            this.btnExist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExist.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExist.ForeColor = System.Drawing.Color.White;
            this.btnExist.Location = new System.Drawing.Point(972, 10);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 28);
            this.btnExist.TabIndex = 2;
            this.btnExist.Text = "&Exit";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcess.BackgroundImage")));
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(490, 10);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 28);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "&Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblOldStandard
            // 
            this.lblOldStandard.AutoSize = true;
            this.lblOldStandard.ForeColor = System.Drawing.Color.Black;
            this.lblOldStandard.Location = new System.Drawing.Point(40, 91);
            this.lblOldStandard.Name = "lblOldStandard";
            this.lblOldStandard.Size = new System.Drawing.Size(62, 14);
            this.lblOldStandard.TabIndex = 51;
            this.lblOldStandard.Text = "Standard :*";
            // 
            // cbOldStandard
            // 
            this.cbOldStandard.BackColor = System.Drawing.SystemColors.Window;
            this.cbOldStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOldStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOldStandard.FormattingEnabled = true;
            this.cbOldStandard.Location = new System.Drawing.Point(139, 87);
            this.cbOldStandard.Name = "cbOldStandard";
            this.cbOldStandard.Size = new System.Drawing.Size(271, 22);
            this.cbOldStandard.TabIndex = 1;
            this.cbOldStandard.SelectedIndexChanged += new System.EventHandler(this.cbOldStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // cbOldDepartment
            // 
            this.cbOldDepartment.BackColor = System.Drawing.SystemColors.Window;
            this.cbOldDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOldDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOldDepartment.FormattingEnabled = true;
            this.cbOldDepartment.Location = new System.Drawing.Point(139, 50);
            this.cbOldDepartment.Name = "cbOldDepartment";
            this.cbOldDepartment.Size = new System.Drawing.Size(271, 22);
            this.cbOldDepartment.TabIndex = 0;
            this.cbOldDepartment.SelectedIndexChanged += new System.EventHandler(this.cbOldStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // lblOldDepartment
            // 
            this.lblOldDepartment.AutoSize = true;
            this.lblOldDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblOldDepartment.Location = new System.Drawing.Point(40, 54);
            this.lblOldDepartment.Name = "lblOldDepartment";
            this.lblOldDepartment.Size = new System.Drawing.Size(78, 14);
            this.lblOldDepartment.TabIndex = 65;
            this.lblOldDepartment.Text = "Department :*";
            // 
            // cbOldDivision
            // 
            this.cbOldDivision.BackColor = System.Drawing.SystemColors.Window;
            this.cbOldDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOldDivision.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOldDivision.FormattingEnabled = true;
            this.cbOldDivision.Location = new System.Drawing.Point(139, 125);
            this.cbOldDivision.Name = "cbOldDivision";
            this.cbOldDivision.Size = new System.Drawing.Size(271, 22);
            this.cbOldDivision.TabIndex = 2;
            this.cbOldDivision.SelectedIndexChanged += new System.EventHandler(this.cbOldStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // lblOldDivision
            // 
            this.lblOldDivision.AutoSize = true;
            this.lblOldDivision.ForeColor = System.Drawing.Color.Black;
            this.lblOldDivision.Location = new System.Drawing.Point(40, 129);
            this.lblOldDivision.Name = "lblOldDivision";
            this.lblOldDivision.Size = new System.Drawing.Size(57, 14);
            this.lblOldDivision.TabIndex = 68;
            this.lblOldDivision.Text = "Division :*";
            // 
            // gvOldStudent
            // 
            this.gvOldStudent.AllowUserToAddRows = false;
            this.gvOldStudent.AllowUserToDeleteRows = false;
            this.gvOldStudent.AllowUserToResizeColumns = false;
            this.gvOldStudent.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.gvOldStudent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gvOldStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvOldStudent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvOldStudent.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gvOldStudent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvOldStudent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvOldStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gvOldStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOldStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsContinue,
            this.Leave,
            this.OldGRNo,
            this.OldStudentName,
            this.OldStudentID});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvOldStudent.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvOldStudent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvOldStudent.Location = new System.Drawing.Point(12, 166);
            this.gvOldStudent.MultiSelect = false;
            this.gvOldStudent.Name = "gvOldStudent";
            this.gvOldStudent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvOldStudent.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gvOldStudent.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.gvOldStudent.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gvOldStudent.RowTemplate.Height = 35;
            this.gvOldStudent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvOldStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvOldStudent.Size = new System.Drawing.Size(505, 444);
            this.gvOldStudent.TabIndex = 4;
            this.gvOldStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvOldStudent_CellContentClick);
            // 
            // IsContinue
            // 
            this.IsContinue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsContinue.FalseValue = "False";
            this.IsContinue.HeaderText = "IsContinue";
            this.IsContinue.IndeterminateValue = "";
            this.IsContinue.Name = "IsContinue";
            this.IsContinue.TrueValue = "True";
            this.IsContinue.Width = 90;
            // 
            // Leave
            // 
            this.Leave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Leave.HeaderText = "Leave";
            this.Leave.Image = global::School.Properties.Resources.Delete;
            this.Leave.Name = "Leave";
            this.Leave.Width = 80;
            // 
            // OldGRNo
            // 
            this.OldGRNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OldGRNo.DataPropertyName = "GRNo";
            this.OldGRNo.HeaderText = "GR No";
            this.OldGRNo.Name = "OldGRNo";
            this.OldGRNo.ReadOnly = true;
            this.OldGRNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OldGRNo.Width = 130;
            // 
            // OldStudentName
            // 
            this.OldStudentName.DataPropertyName = "StudentName";
            this.OldStudentName.HeaderText = "Student Name";
            this.OldStudentName.Name = "OldStudentName";
            this.OldStudentName.ReadOnly = true;
            // 
            // OldStudentID
            // 
            this.OldStudentID.DataPropertyName = "StudentID";
            this.OldStudentID.HeaderText = "Id";
            this.OldStudentID.Name = "OldStudentID";
            this.OldStudentID.Visible = false;
            // 
            // gvNewStudent
            // 
            this.gvNewStudent.AllowUserToAddRows = false;
            this.gvNewStudent.AllowUserToDeleteRows = false;
            this.gvNewStudent.AllowUserToResizeColumns = false;
            this.gvNewStudent.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gvNewStudent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvNewStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvNewStudent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvNewStudent.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gvNewStudent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvNewStudent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvNewStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvNewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvNewStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewGRNo,
            this.NewStudentName,
            this.NewStudentID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvNewStudent.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvNewStudent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvNewStudent.Location = new System.Drawing.Point(543, 166);
            this.gvNewStudent.MultiSelect = false;
            this.gvNewStudent.Name = "gvNewStudent";
            this.gvNewStudent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvNewStudent.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvNewStudent.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gvNewStudent.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvNewStudent.RowTemplate.Height = 35;
            this.gvNewStudent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvNewStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvNewStudent.Size = new System.Drawing.Size(505, 444);
            this.gvNewStudent.TabIndex = 69;
            // 
            // NewGRNo
            // 
            this.NewGRNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NewGRNo.DataPropertyName = "GRNo";
            this.NewGRNo.HeaderText = "GR No";
            this.NewGRNo.Name = "NewGRNo";
            this.NewGRNo.ReadOnly = true;
            this.NewGRNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NewGRNo.Width = 150;
            // 
            // NewStudentName
            // 
            this.NewStudentName.DataPropertyName = "StudentName";
            this.NewStudentName.HeaderText = "Student Name";
            this.NewStudentName.Name = "NewStudentName";
            this.NewStudentName.ReadOnly = true;
            // 
            // NewStudentID
            // 
            this.NewStudentID.DataPropertyName = "StudentID";
            this.NewStudentID.HeaderText = "Id";
            this.NewStudentID.Name = "NewStudentID";
            this.NewStudentID.Visible = false;
            // 
            // cbNewDivision
            // 
            this.cbNewDivision.BackColor = System.Drawing.SystemColors.Window;
            this.cbNewDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewDivision.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNewDivision.FormattingEnabled = true;
            this.cbNewDivision.Location = new System.Drawing.Point(662, 124);
            this.cbNewDivision.Name = "cbNewDivision";
            this.cbNewDivision.Size = new System.Drawing.Size(271, 22);
            this.cbNewDivision.TabIndex = 7;
            this.cbNewDivision.SelectedIndexChanged += new System.EventHandler(this.cbNewStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // lblNewDivision
            // 
            this.lblNewDivision.AutoSize = true;
            this.lblNewDivision.ForeColor = System.Drawing.Color.Black;
            this.lblNewDivision.Location = new System.Drawing.Point(563, 128);
            this.lblNewDivision.Name = "lblNewDivision";
            this.lblNewDivision.Size = new System.Drawing.Size(57, 14);
            this.lblNewDivision.TabIndex = 75;
            this.lblNewDivision.Text = "Division :*";
            // 
            // cbNewDepartment
            // 
            this.cbNewDepartment.BackColor = System.Drawing.SystemColors.Window;
            this.cbNewDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNewDepartment.FormattingEnabled = true;
            this.cbNewDepartment.Location = new System.Drawing.Point(662, 49);
            this.cbNewDepartment.Name = "cbNewDepartment";
            this.cbNewDepartment.Size = new System.Drawing.Size(271, 22);
            this.cbNewDepartment.TabIndex = 5;
            this.cbNewDepartment.SelectedIndexChanged += new System.EventHandler(this.cbNewStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // lblNewDepartment
            // 
            this.lblNewDepartment.AutoSize = true;
            this.lblNewDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblNewDepartment.Location = new System.Drawing.Point(563, 53);
            this.lblNewDepartment.Name = "lblNewDepartment";
            this.lblNewDepartment.Size = new System.Drawing.Size(78, 14);
            this.lblNewDepartment.TabIndex = 74;
            this.lblNewDepartment.Text = "Department :*";
            // 
            // cbNewStandard
            // 
            this.cbNewStandard.BackColor = System.Drawing.SystemColors.Window;
            this.cbNewStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNewStandard.FormattingEnabled = true;
            this.cbNewStandard.Location = new System.Drawing.Point(662, 86);
            this.cbNewStandard.Name = "cbNewStandard";
            this.cbNewStandard.Size = new System.Drawing.Size(271, 22);
            this.cbNewStandard.TabIndex = 6;
            this.cbNewStandard.SelectedIndexChanged += new System.EventHandler(this.cbNewStandardDivisionDepartment_SelectedIndexChanged);
            // 
            // lblNewStandard
            // 
            this.lblNewStandard.AutoSize = true;
            this.lblNewStandard.ForeColor = System.Drawing.Color.Black;
            this.lblNewStandard.Location = new System.Drawing.Point(563, 90);
            this.lblNewStandard.Name = "lblNewStandard";
            this.lblNewStandard.Size = new System.Drawing.Size(62, 14);
            this.lblNewStandard.TabIndex = 73;
            this.lblNewStandard.Text = "Standard :*";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(429, 129);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(71, 18);
            this.chkSelectAll.TabIndex = 3;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // frmUpdateStudent
            // 
            this.AcceptButton = this.btnProcess;
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExist;
            this.ClientSize = new System.Drawing.Size(1059, 679);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.cbNewDivision);
            this.Controls.Add(this.lblNewDivision);
            this.Controls.Add(this.cbNewDepartment);
            this.Controls.Add(this.lblNewDepartment);
            this.Controls.Add(this.cbNewStandard);
            this.Controls.Add(this.lblNewStandard);
            this.Controls.Add(this.gvNewStudent);
            this.Controls.Add(this.gvOldStudent);
            this.Controls.Add(this.cbOldDivision);
            this.Controls.Add(this.lblOldDivision);
            this.Controls.Add(this.cbOldDepartment);
            this.Controls.Add(this.lblOldDepartment);
            this.Controls.Add(this.cbOldStandard);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.lblOldStandard);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Student";
            this.Load += new System.EventHandler(this.frmUpdateStudent_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUpdateStudent)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvOldStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNewStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider epUpdateStudent;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblOldStandard;
        private System.Windows.Forms.Label lblOldDepartment;
        private System.Windows.Forms.Label lblOldDivision;
        private System.Windows.Forms.ComboBox cbOldStandard;
        private System.Windows.Forms.ComboBox cbOldDepartment;
        private System.Windows.Forms.ComboBox cbOldDivision;
        private System.Windows.Forms.DataGridView gvOldStudent;
        private System.Windows.Forms.DataGridView gvNewStudent;
        private System.Windows.Forms.ComboBox cbNewDivision;
        private System.Windows.Forms.Label lblNewDivision;
        private System.Windows.Forms.ComboBox cbNewDepartment;
        private System.Windows.Forms.Label lblNewDepartment;
        private System.Windows.Forms.ComboBox cbNewStandard;
        private System.Windows.Forms.Label lblNewStandard;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewGRNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewStudentID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsContinue;
        private System.Windows.Forms.DataGridViewImageColumn Leave;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldGRNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldStudentID;
    }
}