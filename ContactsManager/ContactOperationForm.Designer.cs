namespace ContactsManager
{
    partial class ContactOperationForm
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
            this.ContactOperationGroupBox = new System.Windows.Forms.GroupBox();
            this.GroupComboBox = new System.Windows.Forms.ComboBox();
            this.RemarkTextBox = new System.Windows.Forms.TextBox();
            this.NumTextBox = new System.Windows.Forms.TextBox();
            this.RemarkLabel = new System.Windows.Forms.Label();
            this.NumLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.ContactOperationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactOperationGroupBox
            // 
            this.ContactOperationGroupBox.Controls.Add(this.GroupComboBox);
            this.ContactOperationGroupBox.Controls.Add(this.RemarkTextBox);
            this.ContactOperationGroupBox.Controls.Add(this.NumTextBox);
            this.ContactOperationGroupBox.Controls.Add(this.RemarkLabel);
            this.ContactOperationGroupBox.Controls.Add(this.NumLabel);
            this.ContactOperationGroupBox.Controls.Add(this.NameTextBox);
            this.ContactOperationGroupBox.Controls.Add(this.GroupLabel);
            this.ContactOperationGroupBox.Controls.Add(this.NameLabel);
            this.ContactOperationGroupBox.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContactOperationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ContactOperationGroupBox.Name = "ContactOperationGroupBox";
            this.ContactOperationGroupBox.Size = new System.Drawing.Size(302, 286);
            this.ContactOperationGroupBox.TabIndex = 0;
            this.ContactOperationGroupBox.TabStop = false;
            // 
            // GroupComboBox
            // 
            this.GroupComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.GroupComboBox.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupComboBox.FormattingEnabled = true;
            this.GroupComboBox.ItemHeight = 14;
            this.GroupComboBox.Location = new System.Drawing.Point(88, 91);
            this.GroupComboBox.MaxLength = 255;
            this.GroupComboBox.Name = "GroupComboBox";
            this.GroupComboBox.Size = new System.Drawing.Size(175, 22);
            this.GroupComboBox.TabIndex = 1;
            this.GroupComboBox.DropDown += new System.EventHandler(this.ResetBackColor);
            this.GroupComboBox.TextChanged += new System.EventHandler(this.ResetBackColor);
            // 
            // RemarkTextBox
            // 
            this.RemarkTextBox.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RemarkTextBox.Location = new System.Drawing.Point(88, 193);
            this.RemarkTextBox.MaxLength = 255;
            this.RemarkTextBox.Multiline = true;
            this.RemarkTextBox.Name = "RemarkTextBox";
            this.RemarkTextBox.Size = new System.Drawing.Size(175, 71);
            this.RemarkTextBox.TabIndex = 3;
            // 
            // NumTextBox
            // 
            this.NumTextBox.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumTextBox.Location = new System.Drawing.Point(120, 141);
            this.NumTextBox.MaxLength = 255;
            this.NumTextBox.Name = "NumTextBox";
            this.NumTextBox.Size = new System.Drawing.Size(143, 23);
            this.NumTextBox.TabIndex = 2;
            this.NumTextBox.TextChanged += new System.EventHandler(this.ResetBackColor);
            // 
            // RemarkLabel
            // 
            this.RemarkLabel.AutoSize = true;
            this.RemarkLabel.Location = new System.Drawing.Point(26, 193);
            this.RemarkLabel.Name = "RemarkLabel";
            this.RemarkLabel.Size = new System.Drawing.Size(56, 16);
            this.RemarkLabel.TabIndex = 0;
            this.RemarkLabel.Text = "备注：";
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.Location = new System.Drawing.Point(26, 143);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(88, 16);
            this.NumLabel.TabIndex = 0;
            this.NumLabel.Text = "联系方式：";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameTextBox.Location = new System.Drawing.Point(89, 41);
            this.NameTextBox.MaxLength = 255;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(174, 23);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.TextChanged += new System.EventHandler(this.ResetBackColor);
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Location = new System.Drawing.Point(26, 93);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(56, 16);
            this.GroupLabel.TabIndex = 0;
            this.GroupLabel.Text = "分组：";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(26, 43);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(56, 16);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "姓名：";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(50, 312);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 30);
            this.OKButton.TabIndex = 1;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.ButtonOperation);
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(200, 312);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 30);
            this.AbortButton.TabIndex = 2;
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.ButtonOperation);
            // 
            // ContactOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 357);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ContactOperationGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ContactOperationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SelectOperation);
            this.ContactOperationGroupBox.ResumeLayout(false);
            this.ContactOperationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ContactOperationGroupBox;
        private System.Windows.Forms.TextBox NumTextBox;
        private System.Windows.Forms.Label NumLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.ComboBox GroupComboBox;
        private System.Windows.Forms.TextBox RemarkTextBox;
        private System.Windows.Forms.Label RemarkLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button AbortButton;
    }
}