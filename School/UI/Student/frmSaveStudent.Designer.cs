namespace School.UI.Student
{
    partial class frmSaveStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaveStudent));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.epStudent = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbStudentDetail = new System.Windows.Forms.TabControl();
            this.tbiStudentDetail = new System.Windows.Forms.TabPage();
            this.lblAgeValue = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtGRNumber = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.dtBirthDate = new System.Windows.Forms.DateTimePicker();
            this.dtRegistrationDate = new System.Windows.Forms.DateTimePicker();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblMotherName = new System.Windows.Forms.Label();
            this.txtMotherName = new System.Windows.Forms.TextBox();
            this.lblFatherName = new System.Windows.Forms.Label();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblGRNo = new System.Windows.Forms.Label();
            this.pbDivision = new System.Windows.Forms.PictureBox();
            this.cbDivision = new System.Windows.Forms.ComboBox();
            this.lblDivision = new System.Windows.Forms.Label();
            this.pbDepartment = new System.Windows.Forms.PictureBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.pbStandard = new System.Windows.Forms.PictureBox();
            this.rbtnFeMale = new System.Windows.Forms.RadioButton();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.cbStandard = new System.Windows.Forms.ComboBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblStandard = new System.Windows.Forms.Label();
            this.tbiFeesDetail = new System.Windows.Forms.TabPage();
            this.gbOtherFees = new System.Windows.Forms.GroupBox();
            this.tvOtherFees = new System.Windows.Forms.TreeView();
            this.chkAllOtherFees = new System.Windows.Forms.CheckBox();
            this.gbRegularFees = new System.Windows.Forms.GroupBox();
            this.tvRegularFees = new System.Windows.Forms.TreeView();
            this.chkAllRegularFees = new System.Windows.Forms.CheckBox();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epStudent)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.tbStudentDetail.SuspendLayout();
            this.tbiStudentDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStandard)).BeginInit();
            this.tbiFeesDetail.SuspendLayout();
            this.gbOtherFees.SuspendLayout();
            this.gbRegularFees.SuspendLayout();
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
            this.pnlTitle.Size = new System.Drawing.Size(828, 36);
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
            this.lblTitle.Size = new System.Drawing.Size(89, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Save Student";
            // 
            // epStudent
            // 
            this.epStudent.ContainerControl = this;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.btnExist);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 496);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(828, 43);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(102, 8);
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
            this.btnExist.Location = new System.Drawing.Point(731, 8);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 28);
            this.btnExist.TabIndex = 2;
            this.btnExist.Text = "&Exit";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(11, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbStudentDetail
            // 
            this.tbStudentDetail.Controls.Add(this.tbiStudentDetail);
            this.tbStudentDetail.Controls.Add(this.tbiFeesDetail);
            this.tbStudentDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStudentDetail.Location = new System.Drawing.Point(0, 36);
            this.tbStudentDetail.Name = "tbStudentDetail";
            this.tbStudentDetail.SelectedIndex = 0;
            this.tbStudentDetail.Size = new System.Drawing.Size(828, 460);
            this.tbStudentDetail.TabIndex = 0;
            // 
            // tbiStudentDetail
            // 
            this.tbiStudentDetail.Controls.Add(this.lblAgeValue);
            this.tbiStudentDetail.Controls.Add(this.lblAge);
            this.tbiStudentDetail.Controls.Add(this.cbCategory);
            this.tbiStudentDetail.Controls.Add(this.lblCategory);
            this.tbiStudentDetail.Controls.Add(this.lblLastName);
            this.tbiStudentDetail.Controls.Add(this.txtSurname);
            this.tbiStudentDetail.Controls.Add(this.txtGRNumber);
            this.tbiStudentDetail.Controls.Add(this.txtCity);
            this.tbiStudentDetail.Controls.Add(this.lblState);
            this.tbiStudentDetail.Controls.Add(this.txtAddress);
            this.tbiStudentDetail.Controls.Add(this.lblAddress);
            this.tbiStudentDetail.Controls.Add(this.txtMobileNo);
            this.tbiStudentDetail.Controls.Add(this.lblMobileNo);
            this.tbiStudentDetail.Controls.Add(this.txtPhoneNo);
            this.tbiStudentDetail.Controls.Add(this.lblPhoneNo);
            this.tbiStudentDetail.Controls.Add(this.dtBirthDate);
            this.tbiStudentDetail.Controls.Add(this.dtRegistrationDate);
            this.tbiStudentDetail.Controls.Add(this.lblRegistrationDate);
            this.tbiStudentDetail.Controls.Add(this.lblBirthDate);
            this.tbiStudentDetail.Controls.Add(this.lblMotherName);
            this.tbiStudentDetail.Controls.Add(this.txtMotherName);
            this.tbiStudentDetail.Controls.Add(this.lblFatherName);
            this.tbiStudentDetail.Controls.Add(this.txtFatherName);
            this.tbiStudentDetail.Controls.Add(this.lblMiddleName);
            this.tbiStudentDetail.Controls.Add(this.txtMiddleName);
            this.tbiStudentDetail.Controls.Add(this.lblGRNo);
            this.tbiStudentDetail.Controls.Add(this.pbDivision);
            this.tbiStudentDetail.Controls.Add(this.cbDivision);
            this.tbiStudentDetail.Controls.Add(this.lblDivision);
            this.tbiStudentDetail.Controls.Add(this.pbDepartment);
            this.tbiStudentDetail.Controls.Add(this.cbDepartment);
            this.tbiStudentDetail.Controls.Add(this.lblDepartment);
            this.tbiStudentDetail.Controls.Add(this.pbStandard);
            this.tbiStudentDetail.Controls.Add(this.rbtnFeMale);
            this.tbiStudentDetail.Controls.Add(this.rbtnMale);
            this.tbiStudentDetail.Controls.Add(this.lblGender);
            this.tbiStudentDetail.Controls.Add(this.cbStandard);
            this.tbiStudentDetail.Controls.Add(this.lblFirstName);
            this.tbiStudentDetail.Controls.Add(this.txtFirstName);
            this.tbiStudentDetail.Controls.Add(this.lblStandard);
            this.tbiStudentDetail.Location = new System.Drawing.Point(4, 23);
            this.tbiStudentDetail.Name = "tbiStudentDetail";
            this.tbiStudentDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tbiStudentDetail.Size = new System.Drawing.Size(820, 433);
            this.tbiStudentDetail.TabIndex = 0;
            this.tbiStudentDetail.Text = "Student Detail";
            this.tbiStudentDetail.UseVisualStyleBackColor = true;
            // 
            // lblAgeValue
            // 
            this.lblAgeValue.AutoSize = true;
            this.lblAgeValue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeValue.Location = new System.Drawing.Point(581, 94);
            this.lblAgeValue.Name = "lblAgeValue";
            this.lblAgeValue.Size = new System.Drawing.Size(13, 14);
            this.lblAgeValue.TabIndex = 205;
            this.lblAgeValue.Text = "0";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(463, 91);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 14);
            this.lblAge.TabIndex = 204;
            this.lblAge.Text = "Age :";
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "General",
            "O.B.C.",
            "S.C.",
            "S.T.",
            "Other"});
            this.cbCategory.Location = new System.Drawing.Point(159, 388);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(237, 22);
            this.cbCategory.TabIndex = 11;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCategory.Location = new System.Drawing.Point(60, 392);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 14);
            this.lblCategory.TabIndex = 203;
            this.lblCategory.Text = "Category :*";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.Black;
            this.lblLastName.Location = new System.Drawing.Point(60, 167);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(62, 14);
            this.lblLastName.TabIndex = 201;
            this.lblLastName.Text = "Surname :*";
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSurname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.Location = new System.Drawing.Point(159, 163);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(0);
            this.txtSurname.MaxLength = 50;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(237, 22);
            this.txtSurname.TabIndex = 4;
            // 
            // txtGRNumber
            // 
            this.txtGRNumber.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtGRNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGRNumber.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGRNumber.Location = new System.Drawing.Point(159, 127);
            this.txtGRNumber.Margin = new System.Windows.Forms.Padding(0);
            this.txtGRNumber.MaxLength = 50;
            this.txtGRNumber.Name = "txtGRNumber";
            this.txtGRNumber.Size = new System.Drawing.Size(237, 22);
            this.txtGRNumber.TabIndex = 3;
            this.txtGRNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGRNumber_KeyPress);
            // 
            // txtCity
            // 
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(584, 359);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(177, 22);
            this.txtCity.TabIndex = 17;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(463, 363);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(37, 14);
            this.lblState.TabIndex = 199;
            this.lblState.Text = "City :*";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(584, 279);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtAddress.MaxLength = 255;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(177, 66);
            this.txtAddress.TabIndex = 16;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(463, 280);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 14);
            this.lblAddress.TabIndex = 198;
            this.lblAddress.Text = "Address :*";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobileNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(584, 205);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtMobileNo.MaxLength = 20;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(177, 22);
            this.txtMobileNo.TabIndex = 14;
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.Location = new System.Drawing.Point(463, 209);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(70, 14);
            this.lblMobileNo.TabIndex = 197;
            this.lblMobileNo.Text = "Mobile No :*";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(584, 243);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtPhoneNo.MaxLength = 20;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(177, 22);
            this.txtPhoneNo.TabIndex = 15;
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNo.Location = new System.Drawing.Point(463, 247);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(60, 14);
            this.lblPhoneNo.TabIndex = 196;
            this.lblPhoneNo.Text = "Phone No :";
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtBirthDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBirthDate.Location = new System.Drawing.Point(584, 129);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(177, 22);
            this.dtBirthDate.TabIndex = 12;
            this.dtBirthDate.Value = new System.DateTime(2000, 1, 8, 0, 0, 0, 0);
            this.dtBirthDate.Leave += new System.EventHandler(this.dtBirthDate_Leave);
            // 
            // dtRegistrationDate
            // 
            this.dtRegistrationDate.CustomFormat = "dd/MM/yyyy";
            this.dtRegistrationDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtRegistrationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRegistrationDate.Location = new System.Drawing.Point(584, 167);
            this.dtRegistrationDate.Name = "dtRegistrationDate";
            this.dtRegistrationDate.Size = new System.Drawing.Size(177, 22);
            this.dtRegistrationDate.TabIndex = 13;
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrationDate.Location = new System.Drawing.Point(463, 171);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(108, 14);
            this.lblRegistrationDate.TabIndex = 195;
            this.lblRegistrationDate.Text = "Registration Date :* ";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDate.Location = new System.Drawing.Point(463, 133);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(63, 14);
            this.lblBirthDate.TabIndex = 194;
            this.lblBirthDate.Text = "Birth Date :";
            // 
            // lblMotherName
            // 
            this.lblMotherName.AutoSize = true;
            this.lblMotherName.ForeColor = System.Drawing.Color.Black;
            this.lblMotherName.Location = new System.Drawing.Point(60, 319);
            this.lblMotherName.Name = "lblMotherName";
            this.lblMotherName.Size = new System.Drawing.Size(82, 14);
            this.lblMotherName.TabIndex = 193;
            this.lblMotherName.Text = "Mother Name :";
            // 
            // txtMotherName
            // 
            this.txtMotherName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotherName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherName.Location = new System.Drawing.Point(159, 315);
            this.txtMotherName.Margin = new System.Windows.Forms.Padding(0);
            this.txtMotherName.MaxLength = 150;
            this.txtMotherName.Name = "txtMotherName";
            this.txtMotherName.Size = new System.Drawing.Size(237, 22);
            this.txtMotherName.TabIndex = 8;
            // 
            // lblFatherName
            // 
            this.lblFatherName.AutoSize = true;
            this.lblFatherName.ForeColor = System.Drawing.Color.Black;
            this.lblFatherName.Location = new System.Drawing.Point(60, 281);
            this.lblFatherName.Name = "lblFatherName";
            this.lblFatherName.Size = new System.Drawing.Size(78, 14);
            this.lblFatherName.TabIndex = 192;
            this.lblFatherName.Text = "Father Name :";
            // 
            // txtFatherName
            // 
            this.txtFatherName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFatherName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherName.Location = new System.Drawing.Point(159, 277);
            this.txtFatherName.Margin = new System.Windows.Forms.Padding(0);
            this.txtFatherName.MaxLength = 150;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(237, 22);
            this.txtFatherName.TabIndex = 7;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.ForeColor = System.Drawing.Color.Black;
            this.lblMiddleName.Location = new System.Drawing.Point(60, 244);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(92, 14);
            this.lblMiddleName.TabIndex = 190;
            this.lblMiddleName.Text = "Father\'s Name :*";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(159, 240);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(0);
            this.txtMiddleName.MaxLength = 50;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(237, 22);
            this.txtMiddleName.TabIndex = 6;
            // 
            // lblGRNo
            // 
            this.lblGRNo.AutoSize = true;
            this.lblGRNo.ForeColor = System.Drawing.Color.Black;
            this.lblGRNo.Location = new System.Drawing.Point(60, 129);
            this.lblGRNo.Name = "lblGRNo";
            this.lblGRNo.Size = new System.Drawing.Size(54, 14);
            this.lblGRNo.TabIndex = 188;
            this.lblGRNo.Text = "GR No. :*";
            // 
            // pbDivision
            // 
            this.pbDivision.Image = global::School.Properties.Resources.Add;
            this.pbDivision.Location = new System.Drawing.Point(413, 87);
            this.pbDivision.Name = "pbDivision";
            this.pbDivision.Size = new System.Drawing.Size(28, 30);
            this.pbDivision.TabIndex = 187;
            this.pbDivision.TabStop = false;
            this.pbDivision.Click += new System.EventHandler(this.pbDivision_Click);
            // 
            // cbDivision
            // 
            this.cbDivision.BackColor = System.Drawing.SystemColors.Window;
            this.cbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDivision.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDivision.FormattingEnabled = true;
            this.cbDivision.Location = new System.Drawing.Point(159, 91);
            this.cbDivision.Name = "cbDivision";
            this.cbDivision.Size = new System.Drawing.Size(237, 22);
            this.cbDivision.TabIndex = 2;
            // 
            // lblDivision
            // 
            this.lblDivision.AutoSize = true;
            this.lblDivision.ForeColor = System.Drawing.Color.Black;
            this.lblDivision.Location = new System.Drawing.Point(60, 95);
            this.lblDivision.Name = "lblDivision";
            this.lblDivision.Size = new System.Drawing.Size(57, 14);
            this.lblDivision.TabIndex = 186;
            this.lblDivision.Text = "Division :*";
            // 
            // pbDepartment
            // 
            this.pbDepartment.Image = global::School.Properties.Resources.Add;
            this.pbDepartment.Location = new System.Drawing.Point(413, 9);
            this.pbDepartment.Name = "pbDepartment";
            this.pbDepartment.Size = new System.Drawing.Size(28, 30);
            this.pbDepartment.TabIndex = 185;
            this.pbDepartment.TabStop = false;
            this.pbDepartment.Click += new System.EventHandler(this.pbDepartment_Click);
            // 
            // cbDepartment
            // 
            this.cbDepartment.BackColor = System.Drawing.SystemColors.Window;
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(159, 13);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(237, 22);
            this.cbDepartment.TabIndex = 0;
            this.cbDepartment.SelectedIndexChanged += new System.EventHandler(this.cbDepartment_SelectedIndexChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(60, 17);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(78, 14);
            this.lblDepartment.TabIndex = 184;
            this.lblDepartment.Text = "Department :*";
            // 
            // pbStandard
            // 
            this.pbStandard.Image = global::School.Properties.Resources.Add;
            this.pbStandard.Location = new System.Drawing.Point(413, 49);
            this.pbStandard.Name = "pbStandard";
            this.pbStandard.Size = new System.Drawing.Size(28, 30);
            this.pbStandard.TabIndex = 183;
            this.pbStandard.TabStop = false;
            this.pbStandard.Click += new System.EventHandler(this.pbStandard_Click);
            // 
            // rbtnFeMale
            // 
            this.rbtnFeMale.AutoSize = true;
            this.rbtnFeMale.Location = new System.Drawing.Point(265, 355);
            this.rbtnFeMale.Name = "rbtnFeMale";
            this.rbtnFeMale.Size = new System.Drawing.Size(62, 18);
            this.rbtnFeMale.TabIndex = 10;
            this.rbtnFeMale.Text = "FeMale";
            this.rbtnFeMale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Checked = true;
            this.rbtnMale.Location = new System.Drawing.Point(173, 355);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(50, 18);
            this.rbtnMale.TabIndex = 9;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "Male";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.Location = new System.Drawing.Point(60, 357);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(55, 14);
            this.lblGender.TabIndex = 182;
            this.lblGender.Text = "Gender :*";
            // 
            // cbStandard
            // 
            this.cbStandard.BackColor = System.Drawing.SystemColors.Window;
            this.cbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStandard.FormattingEnabled = true;
            this.cbStandard.Location = new System.Drawing.Point(159, 53);
            this.cbStandard.Name = "cbStandard";
            this.cbStandard.Size = new System.Drawing.Size(237, 22);
            this.cbStandard.TabIndex = 1;
            this.cbStandard.SelectedIndexChanged += new System.EventHandler(this.cbStandard_SelectedIndexChanged);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.Color.Black;
            this.lblFirstName.Location = new System.Drawing.Point(60, 206);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(49, 14);
            this.lblFirstName.TabIndex = 181;
            this.lblFirstName.Text = "Name :*";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(159, 202);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(0);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(237, 22);
            this.txtFirstName.TabIndex = 5;
            // 
            // lblStandard
            // 
            this.lblStandard.AutoSize = true;
            this.lblStandard.ForeColor = System.Drawing.Color.Black;
            this.lblStandard.Location = new System.Drawing.Point(60, 57);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(62, 14);
            this.lblStandard.TabIndex = 180;
            this.lblStandard.Text = "Standard :*";
            // 
            // tbiFeesDetail
            // 
            this.tbiFeesDetail.Controls.Add(this.gbOtherFees);
            this.tbiFeesDetail.Controls.Add(this.gbRegularFees);
            this.tbiFeesDetail.Location = new System.Drawing.Point(4, 23);
            this.tbiFeesDetail.Name = "tbiFeesDetail";
            this.tbiFeesDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tbiFeesDetail.Size = new System.Drawing.Size(820, 433);
            this.tbiFeesDetail.TabIndex = 1;
            this.tbiFeesDetail.Text = "Fees Detail";
            this.tbiFeesDetail.UseVisualStyleBackColor = true;
            // 
            // gbOtherFees
            // 
            this.gbOtherFees.Controls.Add(this.tvOtherFees);
            this.gbOtherFees.Controls.Add(this.chkAllOtherFees);
            this.gbOtherFees.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbOtherFees.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbOtherFees.Location = new System.Drawing.Point(406, 3);
            this.gbOtherFees.Name = "gbOtherFees";
            this.gbOtherFees.Size = new System.Drawing.Size(411, 427);
            this.gbOtherFees.TabIndex = 1;
            this.gbOtherFees.TabStop = false;
            this.gbOtherFees.Text = "Other Fees";
            // 
            // tvOtherFees
            // 
            this.tvOtherFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvOtherFees.CheckBoxes = true;
            this.tvOtherFees.Location = new System.Drawing.Point(45, 58);
            this.tvOtherFees.Name = "tvOtherFees";
            this.tvOtherFees.ShowLines = false;
            this.tvOtherFees.ShowPlusMinus = false;
            this.tvOtherFees.ShowRootLines = false;
            this.tvOtherFees.Size = new System.Drawing.Size(346, 357);
            this.tvOtherFees.TabIndex = 3;
            // 
            // chkAllOtherFees
            // 
            this.chkAllOtherFees.AutoSize = true;
            this.chkAllOtherFees.ForeColor = System.Drawing.Color.Black;
            this.chkAllOtherFees.Location = new System.Drawing.Point(46, 33);
            this.chkAllOtherFees.Name = "chkAllOtherFees";
            this.chkAllOtherFees.Size = new System.Drawing.Size(39, 18);
            this.chkAllOtherFees.TabIndex = 2;
            this.chkAllOtherFees.Text = "All";
            this.chkAllOtherFees.UseVisualStyleBackColor = true;
            this.chkAllOtherFees.CheckedChanged += new System.EventHandler(this.chkAllOtherFees_CheckedChanged);
            // 
            // gbRegularFees
            // 
            this.gbRegularFees.Controls.Add(this.tvRegularFees);
            this.gbRegularFees.Controls.Add(this.chkAllRegularFees);
            this.gbRegularFees.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbRegularFees.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbRegularFees.Location = new System.Drawing.Point(3, 3);
            this.gbRegularFees.Name = "gbRegularFees";
            this.gbRegularFees.Size = new System.Drawing.Size(397, 427);
            this.gbRegularFees.TabIndex = 0;
            this.gbRegularFees.TabStop = false;
            this.gbRegularFees.Text = "Regular Fees";
            // 
            // tvRegularFees
            // 
            this.tvRegularFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvRegularFees.CheckBoxes = true;
            this.tvRegularFees.Location = new System.Drawing.Point(36, 58);
            this.tvRegularFees.Name = "tvRegularFees";
            this.tvRegularFees.ShowLines = false;
            this.tvRegularFees.ShowPlusMinus = false;
            this.tvRegularFees.ShowRootLines = false;
            this.tvRegularFees.Size = new System.Drawing.Size(321, 357);
            this.tvRegularFees.TabIndex = 1;
            // 
            // chkAllRegularFees
            // 
            this.chkAllRegularFees.AutoSize = true;
            this.chkAllRegularFees.ForeColor = System.Drawing.Color.Black;
            this.chkAllRegularFees.Location = new System.Drawing.Point(39, 33);
            this.chkAllRegularFees.Name = "chkAllRegularFees";
            this.chkAllRegularFees.Size = new System.Drawing.Size(39, 18);
            this.chkAllRegularFees.TabIndex = 0;
            this.chkAllRegularFees.Text = "All";
            this.chkAllRegularFees.UseVisualStyleBackColor = true;
            this.chkAllRegularFees.CheckedChanged += new System.EventHandler(this.chkAllRegularFees_CheckedChanged);
            // 
            // frmSaveStudent
            // 
            this.AcceptButton = this.btnSave;
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExist;
            this.ClientSize = new System.Drawing.Size(828, 539);
            this.Controls.Add(this.tbStudentDetail);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaveStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Student";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSaveStudent_FormClosed);
            this.Load += new System.EventHandler(this.frmSaveStudent_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epStudent)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.tbStudentDetail.ResumeLayout(false);
            this.tbiStudentDetail.ResumeLayout(false);
            this.tbiStudentDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStandard)).EndInit();
            this.tbiFeesDetail.ResumeLayout(false);
            this.gbOtherFees.ResumeLayout(false);
            this.gbOtherFees.PerformLayout();
            this.gbRegularFees.ResumeLayout(false);
            this.gbRegularFees.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider epStudent;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tbStudentDetail;
        private System.Windows.Forms.TabPage tbiStudentDetail;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.DateTimePicker dtBirthDate;
        private System.Windows.Forms.DateTimePicker dtRegistrationDate;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblMotherName;
        private System.Windows.Forms.TextBox txtMotherName;
        private System.Windows.Forms.Label lblFatherName;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblGRNo;
        private System.Windows.Forms.PictureBox pbDivision;
        public System.Windows.Forms.ComboBox cbDivision;
        private System.Windows.Forms.Label lblDivision;
        private System.Windows.Forms.PictureBox pbDepartment;
        public System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.PictureBox pbStandard;
        private System.Windows.Forms.RadioButton rbtnFeMale;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.Label lblGender;
        public System.Windows.Forms.ComboBox cbStandard;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblStandard;
        private System.Windows.Forms.TabPage tbiFeesDetail;
        private System.Windows.Forms.GroupBox gbOtherFees;
        private System.Windows.Forms.GroupBox gbRegularFees;
        private System.Windows.Forms.CheckBox chkAllRegularFees;
        private System.Windows.Forms.CheckBox chkAllOtherFees;
        private System.Windows.Forms.TreeView tvRegularFees;
        private System.Windows.Forms.TreeView tvOtherFees;
        private System.Windows.Forms.TextBox txtGRNumber;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtSurname;
        public System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblAgeValue;
        private System.Windows.Forms.Label lblAge;
    }
}