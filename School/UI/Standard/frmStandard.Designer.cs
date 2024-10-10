namespace School.UI.Standard
{
    partial class frmStandard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStandard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.cbPages = new System.Windows.Forms.ComboBox();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.lblSelectRow = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtStandard = new System.Windows.Forms.TextBox();
            this.lblStandard = new System.Windows.Forms.Label();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.gvStandard = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Standard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epStandard = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlSave = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtStandardName = new System.Windows.Forms.TextBox();
            this.lblStandardName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvStandard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epStandard)).BeginInit();
            this.pnlSave.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(104, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "View Standards";
            // 
            // btnExist
            // 
            this.btnExist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExist.BackgroundImage")));
            this.btnExist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExist.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExist.ForeColor = System.Drawing.Color.White;
            this.btnExist.Location = new System.Drawing.Point(742, 8);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 28);
            this.btnExist.TabIndex = 5;
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
            this.btnLast.Location = new System.Drawing.Point(285, 8);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 28);
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
            this.btnFirst.Location = new System.Drawing.Point(12, 8);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 28);
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
            this.btnNext.Location = new System.Drawing.Point(194, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 28);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
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
            this.pnlFooter.Location = new System.Drawing.Point(0, 490);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(828, 43);
            this.pnlFooter.TabIndex = 44;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrevious.BackgroundImage")));
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(103, 8);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 28);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // cbPages
            // 
            this.cbPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPages.FormattingEnabled = true;
            this.cbPages.Location = new System.Drawing.Point(752, 7);
            this.cbPages.Name = "cbPages";
            this.cbPages.Size = new System.Drawing.Size(62, 22);
            this.cbPages.TabIndex = 0;
            this.cbPages.SelectedIndexChanged += new System.EventHandler(this.cbPages_SelectedIndexChanged);
            // 
            // lblPageNo
            // 
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.Location = new System.Drawing.Point(650, 10);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(89, 14);
            this.lblPageNo.TabIndex = 31;
            this.lblPageNo.Text = "Select Page No : ";
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.lblSelectRow);
            this.pnlAction.Controls.Add(this.cbPages);
            this.pnlAction.Controls.Add(this.lblPageNo);
            this.pnlAction.Location = new System.Drawing.Point(0, 91);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(829, 36);
            this.pnlAction.TabIndex = 43;
            // 
            // lblSelectRow
            // 
            this.lblSelectRow.AutoSize = true;
            this.lblSelectRow.Location = new System.Drawing.Point(13, 10);
            this.lblSelectRow.Name = "lblSelectRow";
            this.lblSelectRow.Size = new System.Drawing.Size(87, 14);
            this.lblSelectRow.TabIndex = 23;
            this.lblSelectRow.Text = "Select Row No : ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(739, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtStandard
            // 
            this.txtStandard.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtStandard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStandard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStandard.Location = new System.Drawing.Point(97, 17);
            this.txtStandard.Margin = new System.Windows.Forms.Padding(0);
            this.txtStandard.MaxLength = 50;
            this.txtStandard.Name = "txtStandard";
            this.txtStandard.Size = new System.Drawing.Size(246, 22);
            this.txtStandard.TabIndex = 0;
            this.txtStandard.TextChanged += new System.EventHandler(this.txtStandard_TextChanged);
            // 
            // lblStandard
            // 
            this.lblStandard.AutoSize = true;
            this.lblStandard.ForeColor = System.Drawing.Color.Black;
            this.lblStandard.Location = new System.Drawing.Point(15, 21);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(59, 14);
            this.lblStandard.TabIndex = 35;
            this.lblStandard.Text = "Standard : ";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnRefresh);
            this.gbSearch.Controls.Add(this.txtStandard);
            this.gbSearch.Controls.Add(this.lblStandard);
            this.gbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(124)))), ((int)(((byte)(151)))));
            this.gbSearch.Location = new System.Drawing.Point(3, 39);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(823, 50);
            this.gbSearch.TabIndex = 45;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // gvStandard
            // 
            this.gvStandard.AllowUserToAddRows = false;
            this.gvStandard.AllowUserToDeleteRows = false;
            this.gvStandard.AllowUserToResizeColumns = false;
            this.gvStandard.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gvStandard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvStandard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvStandard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvStandard.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.gvStandard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvStandard.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvStandard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvStandard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStandard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete,
            this.Standard,
            this.Id});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvStandard.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvStandard.Location = new System.Drawing.Point(0, 126);
            this.gvStandard.MultiSelect = false;
            this.gvStandard.Name = "gvStandard";
            this.gvStandard.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvStandard.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvStandard.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gvStandard.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvStandard.RowTemplate.Height = 35;
            this.gvStandard.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvStandard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvStandard.Size = new System.Drawing.Size(498, 364);
            this.gvStandard.TabIndex = 41;
            this.gvStandard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvStandard_CellContentClick);
            this.gvStandard.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gvStandard_RowStateChanged);
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
            this.Edit.Width = 60;
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
            // Standard
            // 
            this.Standard.DataPropertyName = "Standard";
            this.Standard.FillWeight = 61.81106F;
            this.Standard.HeaderText = "Standard";
            this.Standard.Name = "Standard";
            this.Standard.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "StandardID";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // epStandard
            // 
            this.epStandard.ContainerControl = this;
            // 
            // pnlSave
            // 
            this.pnlSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSave.Controls.Add(this.btnCancel);
            this.pnlSave.Controls.Add(this.txtStandardName);
            this.pnlSave.Controls.Add(this.lblStandardName);
            this.pnlSave.Controls.Add(this.btnSave);
            this.pnlSave.Location = new System.Drawing.Point(498, 126);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(331, 364);
            this.pnlSave.TabIndex = 49;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(179, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 52;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtStandardName
            // 
            this.txtStandardName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtStandardName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStandardName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStandardName.Location = new System.Drawing.Point(110, 132);
            this.txtStandardName.Margin = new System.Windows.Forms.Padding(0);
            this.txtStandardName.MaxLength = 50;
            this.txtStandardName.Name = "txtStandardName";
            this.txtStandardName.Size = new System.Drawing.Size(171, 22);
            this.txtStandardName.TabIndex = 50;
            // 
            // lblStandardName
            // 
            this.lblStandardName.AutoSize = true;
            this.lblStandardName.ForeColor = System.Drawing.Color.Black;
            this.lblStandardName.Location = new System.Drawing.Point(33, 136);
            this.lblStandardName.Name = "lblStandardName";
            this.lblStandardName.Size = new System.Drawing.Size(62, 14);
            this.lblStandardName.TabIndex = 51;
            this.lblStandardName.Text = "Standard :*";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(79, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmStandard
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExist;
            this.ClientSize = new System.Drawing.Size(828, 533);
            this.Controls.Add(this.pnlSave);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gvStandard);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStandard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Standards";
            this.Load += new System.EventHandler(this.frmStandard_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvStandard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epStandard)).EndInit();
            this.pnlSave.ResumeLayout(false);
            this.pnlSave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.ComboBox cbPages;
        private System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Label lblSelectRow;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStandard;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.DataGridView gvStandard;
        private System.Windows.Forms.TextBox txtStandard;
        private System.Windows.Forms.ErrorProvider epStandard;
        private System.Windows.Forms.Panel pnlSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtStandardName;
        private System.Windows.Forms.Label lblStandardName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}