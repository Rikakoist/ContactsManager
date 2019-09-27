namespace ContactsManager
{
    partial class ContactView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactView));
            this.ContactStatusStrip = new System.Windows.Forms.StatusStrip();
            this.HintLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AboutStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.QueryGroupBox = new System.Windows.Forms.GroupBox();
            this.QueryTextBox = new System.Windows.Forms.TextBox();
            this.GroupComboBox = new System.Windows.Forms.ComboBox();
            this.VagueQueryLabel = new System.Windows.Forms.Label();
            this.ContactGroupLabel = new System.Windows.Forms.Label();
            this.QueryResultListView = new System.Windows.Forms.ListView();
            this.ContactID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactRemark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OperationContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddContactStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditContactStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteContactStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewContactStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactStatusStrip.SuspendLayout();
            this.QueryGroupBox.SuspendLayout();
            this.OperationContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactStatusStrip
            // 
            this.ContactStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContactStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HintLabel,
            this.AboutStripStatusLabel});
            this.ContactStatusStrip.Location = new System.Drawing.Point(0, 356);
            this.ContactStatusStrip.Name = "ContactStatusStrip";
            this.ContactStatusStrip.Size = new System.Drawing.Size(586, 25);
            this.ContactStatusStrip.TabIndex = 0;
            // 
            // HintLabel
            // 
            this.HintLabel.Image = ((System.Drawing.Image)(resources.GetObject("HintLabel.Image")));
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(20, 20);
            // 
            // AboutStripStatusLabel
            // 
            this.AboutStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutStripStatusLabel.Image = ((System.Drawing.Image)(resources.GetObject("AboutStripStatusLabel.Image")));
            this.AboutStripStatusLabel.Name = "AboutStripStatusLabel";
            this.AboutStripStatusLabel.Size = new System.Drawing.Size(20, 20);
            this.AboutStripStatusLabel.Text = "About";
            this.AboutStripStatusLabel.Click += new System.EventHandler(this.ShowAbout);
            // 
            // QueryGroupBox
            // 
            this.QueryGroupBox.Controls.Add(this.QueryTextBox);
            this.QueryGroupBox.Controls.Add(this.GroupComboBox);
            this.QueryGroupBox.Controls.Add(this.VagueQueryLabel);
            this.QueryGroupBox.Controls.Add(this.ContactGroupLabel);
            this.QueryGroupBox.Location = new System.Drawing.Point(12, 10);
            this.QueryGroupBox.Name = "QueryGroupBox";
            this.QueryGroupBox.Size = new System.Drawing.Size(562, 78);
            this.QueryGroupBox.TabIndex = 0;
            this.QueryGroupBox.TabStop = false;
            // 
            // QueryTextBox
            // 
            this.QueryTextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QueryTextBox.Location = new System.Drawing.Point(352, 30);
            this.QueryTextBox.MaxLength = 20;
            this.QueryTextBox.Name = "QueryTextBox";
            this.QueryTextBox.Size = new System.Drawing.Size(135, 20);
            this.QueryTextBox.TabIndex = 0;
            this.QueryTextBox.TextChanged += new System.EventHandler(this.VagueQueryCtrl);
            // 
            // GroupComboBox
            // 
            this.GroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupComboBox.FormattingEnabled = true;
            this.GroupComboBox.ItemHeight = 11;
            this.GroupComboBox.Location = new System.Drawing.Point(66, 31);
            this.GroupComboBox.Name = "GroupComboBox";
            this.GroupComboBox.Size = new System.Drawing.Size(121, 19);
            this.GroupComboBox.TabIndex = 1;
            this.GroupComboBox.SelectedIndexChanged += new System.EventHandler(this.VagueQueryCtrl);
            // 
            // VagueQueryLabel
            // 
            this.VagueQueryLabel.AutoSize = true;
            this.VagueQueryLabel.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VagueQueryLabel.Location = new System.Drawing.Point(263, 34);
            this.VagueQueryLabel.Name = "VagueQueryLabel";
            this.VagueQueryLabel.Size = new System.Drawing.Size(83, 12);
            this.VagueQueryLabel.TabIndex = 0;
            this.VagueQueryLabel.Text = "模糊查询条件";
            this.VagueQueryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContactGroupLabel
            // 
            this.ContactGroupLabel.AutoSize = true;
            this.ContactGroupLabel.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContactGroupLabel.Location = new System.Drawing.Point(29, 34);
            this.ContactGroupLabel.Name = "ContactGroupLabel";
            this.ContactGroupLabel.Size = new System.Drawing.Size(31, 12);
            this.ContactGroupLabel.TabIndex = 0;
            this.ContactGroupLabel.Text = "分组";
            this.ContactGroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QueryResultListView
            // 
            this.QueryResultListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.QueryResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ContactID,
            this.ContactName,
            this.ContactGroup,
            this.ContactNum,
            this.ContactRemark});
            this.QueryResultListView.ContextMenuStrip = this.OperationContextMenuStrip;
            this.QueryResultListView.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QueryResultListView.FullRowSelect = true;
            this.QueryResultListView.GridLines = true;
            this.QueryResultListView.HideSelection = false;
            this.QueryResultListView.Location = new System.Drawing.Point(12, 94);
            this.QueryResultListView.Name = "QueryResultListView";
            this.QueryResultListView.Size = new System.Drawing.Size(562, 262);
            this.QueryResultListView.TabIndex = 2;
            this.QueryResultListView.UseCompatibleStateImageBehavior = false;
            this.QueryResultListView.View = System.Windows.Forms.View.Details;
            this.QueryResultListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoubleClickListViewOperation);
            // 
            // ContactID
            // 
            this.ContactID.Text = "联系人ID";
            // 
            // ContactName
            // 
            this.ContactName.Text = "姓名";
            this.ContactName.Width = 100;
            // 
            // ContactGroup
            // 
            this.ContactGroup.Text = "分组";
            // 
            // ContactNum
            // 
            this.ContactNum.Text = "联系方式";
            this.ContactNum.Width = 120;
            // 
            // ContactRemark
            // 
            this.ContactRemark.Text = "备注";
            this.ContactRemark.Width = 180;
            // 
            // OperationContextMenuStrip
            // 
            this.OperationContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.OperationContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddContactStripMenuItem,
            this.EditContactStripMenuItem,
            this.DeleteContactStripMenuItem,
            this.ToolStripSeparator1,
            this.ViewContactStripMenuItem});
            this.OperationContextMenuStrip.Name = "OperationContextMenuStrip";
            this.OperationContextMenuStrip.Size = new System.Drawing.Size(137, 98);
            this.OperationContextMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ConfigAvailability);
            this.OperationContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ConfigAvailability);
            // 
            // AddContactStripMenuItem
            // 
            this.AddContactStripMenuItem.Name = "AddContactStripMenuItem";
            this.AddContactStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.AddContactStripMenuItem.Text = "添加联系人";
            this.AddContactStripMenuItem.Click += new System.EventHandler(this.ContactOperation);
            // 
            // EditContactStripMenuItem
            // 
            this.EditContactStripMenuItem.Name = "EditContactStripMenuItem";
            this.EditContactStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.EditContactStripMenuItem.Text = "修改联系人";
            this.EditContactStripMenuItem.Click += new System.EventHandler(this.ContactOperation);
            // 
            // DeleteContactStripMenuItem
            // 
            this.DeleteContactStripMenuItem.Name = "DeleteContactStripMenuItem";
            this.DeleteContactStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.DeleteContactStripMenuItem.Text = "删除联系人";
            this.DeleteContactStripMenuItem.Click += new System.EventHandler(this.ContactOperation);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // ViewContactStripMenuItem
            // 
            this.ViewContactStripMenuItem.Name = "ViewContactStripMenuItem";
            this.ViewContactStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ViewContactStripMenuItem.Text = "查看联系人";
            this.ViewContactStripMenuItem.Click += new System.EventHandler(this.ContactOperation);
            // 
            // ContactView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 381);
            this.Controls.Add(this.QueryResultListView);
            this.Controls.Add(this.QueryGroupBox);
            this.Controls.Add(this.ContactStatusStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("幼圆", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ContactView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "联系人管理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExitApp);
            this.Load += new System.EventHandler(this.InitForm);
            this.ContactStatusStrip.ResumeLayout(false);
            this.ContactStatusStrip.PerformLayout();
            this.QueryGroupBox.ResumeLayout(false);
            this.QueryGroupBox.PerformLayout();
            this.OperationContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ContactStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel HintLabel;
        private System.Windows.Forms.GroupBox QueryGroupBox;
        private System.Windows.Forms.Label ContactGroupLabel;
        private System.Windows.Forms.ComboBox GroupComboBox;
        private System.Windows.Forms.ListView QueryResultListView;
        private System.Windows.Forms.Label VagueQueryLabel;
        private System.Windows.Forms.TextBox QueryTextBox;
        private System.Windows.Forms.ContextMenuStrip OperationContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddContactStripMenuItem;
        private System.Windows.Forms.ColumnHeader ContactID;
        private System.Windows.Forms.ColumnHeader ContactName;
        private System.Windows.Forms.ColumnHeader ContactGroup;
        private System.Windows.Forms.ColumnHeader ContactNum;
        private System.Windows.Forms.ColumnHeader ContactRemark;
        private System.Windows.Forms.ToolStripStatusLabel AboutStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem EditContactStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteContactStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ViewContactStripMenuItem;
    }
}

