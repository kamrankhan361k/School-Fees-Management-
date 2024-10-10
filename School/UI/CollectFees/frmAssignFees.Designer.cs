namespace School.UI.CollectFees
{
    partial class frmAssignFees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignFees));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFees = new System.Windows.Forms.Panel();
            this.gbOtherFees = new System.Windows.Forms.GroupBox();
            this.tvOtherFees = new System.Windows.Forms.TreeView();
            this.chkAllOtherFees = new System.Windows.Forms.CheckBox();
            this.gbRegularFees = new System.Windows.Forms.GroupBox();
            this.tvRegularFees = new System.Windows.Forms.TreeView();
            this.chkAllRegularFees = new System.Windows.Forms.CheckBox();
            this.pnlTitle.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFees.SuspendLayout();
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
            this.pnlTitle.TabIndex = 43;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(9, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Assign Fees";
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
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnExist);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 496);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(828, 43);
            this.pnlFooter.TabIndex = 44;
            // 
            // pnlFees
            // 
            this.pnlFees.Controls.Add(this.gbOtherFees);
            this.pnlFees.Controls.Add(this.gbRegularFees);
            this.pnlFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFees.Location = new System.Drawing.Point(0, 36);
            this.pnlFees.Name = "pnlFees";
            this.pnlFees.Padding = new System.Windows.Forms.Padding(3);
            this.pnlFees.Size = new System.Drawing.Size(828, 460);
            this.pnlFees.TabIndex = 45;
            // 
            // gbOtherFees
            // 
            this.gbOtherFees.Controls.Add(this.tvOtherFees);
            this.gbOtherFees.Controls.Add(this.chkAllOtherFees);
            this.gbOtherFees.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbOtherFees.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbOtherFees.Location = new System.Drawing.Point(414, 3);
            this.gbOtherFees.Name = "gbOtherFees";
            this.gbOtherFees.Size = new System.Drawing.Size(411, 454);
            this.gbOtherFees.TabIndex = 48;
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
            this.chkAllOtherFees.Size = new System.Drawing.Size(37, 17);
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
            this.gbRegularFees.Size = new System.Drawing.Size(397, 454);
            this.gbRegularFees.TabIndex = 47;
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
            this.chkAllRegularFees.Size = new System.Drawing.Size(37, 17);
            this.chkAllRegularFees.TabIndex = 0;
            this.chkAllRegularFees.Text = "All";
            this.chkAllRegularFees.UseVisualStyleBackColor = true;
            this.chkAllRegularFees.CheckedChanged += new System.EventHandler(this.chkAllRegularFees_CheckedChanged);
            // 
            // frmAssignFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 539);
            this.Controls.Add(this.pnlFees);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAssignFees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Fees";
            this.Load += new System.EventHandler(this.frmAssignFees_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFees.ResumeLayout(false);
            this.gbOtherFees.ResumeLayout(false);
            this.gbOtherFees.PerformLayout();
            this.gbRegularFees.ResumeLayout(false);
            this.gbRegularFees.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlFees;
        private System.Windows.Forms.GroupBox gbOtherFees;
        private System.Windows.Forms.TreeView tvOtherFees;
        private System.Windows.Forms.CheckBox chkAllOtherFees;
        private System.Windows.Forms.GroupBox gbRegularFees;
        private System.Windows.Forms.TreeView tvRegularFees;
        private System.Windows.Forms.CheckBox chkAllRegularFees;



    }
}