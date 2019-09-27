using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ContactsManager
{
    public partial class ContactOperationForm : Form
    {
        public Contact ResultContact = new Contact();
        bool CheckPassed = false;

        #region 构造函数
        public ContactOperationForm()
        {
            InitializeComponent();
        }

        //新增模式
        public ContactOperationForm(List<string> GroupList)
        {
            InitializeComponent();
            CheckPassed = true;
            OKButton.Text = "创建联系人";
            AbortButton.Text = "取消";
            if (InitGroup(GroupList))
            {

            }
            else
            {
                throw new Exception("初始化分组列表时出现异常。");
            }
        }
        //编辑模式
        public ContactOperationForm(List<string> GroupList, Contact EditContact)
        {
            InitializeComponent();
            CheckPassed = true;
            OKButton.Text = "确认修改";
            AbortButton.Text = "放弃";
            if (InitGroup(GroupList))
            {
                NameTextBox.Text = EditContact?.Name ?? "#REF";
                GroupComboBox.SelectedIndex = GroupList.IndexOf(EditContact.Group) - 1;
                NumTextBox.Text = EditContact?.Num ?? "#REF";
                RemarkTextBox.Text = EditContact?.Remark ?? "#REF";
                ResultContact = EditContact;
            }
            else
            {
                throw new Exception("初始化分组列表时出现异常。");
            }
        }
        //查看模式
        public ContactOperationForm(Contact ViewContact)
        {
            InitializeComponent();
            CheckPassed = true;
            OKButton.Text = "确认";
            AbortButton.Text = "确认";
            NameTextBox.ReadOnly = true;
            GroupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GroupComboBox.Items.Add(ViewContact.Group);
            NumTextBox.ReadOnly = true;
            RemarkTextBox.ReadOnly = true;

            NameTextBox.Text = ViewContact?.Name ?? "#REF";
            GroupComboBox.SelectedIndex = 0;
            NumTextBox.Text = ViewContact?.Num ?? "#REF";
            RemarkTextBox.Text = ViewContact?.Remark ?? "#REF";
            ResultContact = ViewContact;
        }
        #endregion

        //Load事件
        private void SelectOperation(object sender, EventArgs e)
        {

        }

        private bool InitGroup(List<string> Groups)
        {
            try
            {
                GroupComboBox.Items.Clear();
                foreach (string Str in Groups)
                {
                    GroupComboBox.Items.Add(Str);
                }
                GroupComboBox.Items.RemoveAt(0);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ButtonOperation(object sender, EventArgs e)
        {
            try
            {
                if (sender == OKButton)
                {
                    CheckPassed = true;
                    if (GroupComboBox.Text == "全部联系人")
                    {
                        CheckPassed = false;
                        GroupComboBox.BackColor = Color.Red;
                    }
                    if (String.IsNullOrWhiteSpace(NameTextBox.Text))
                    {
                        CheckPassed = false;
                        NameTextBox.BackColor = Color.Red;
                    }
                    if (String.IsNullOrWhiteSpace(NumTextBox.Text))
                    {
                        CheckPassed = false;
                        NumTextBox.BackColor = Color.Red;
                    }
                    if (!CheckPassed)
                    {
                        throw new Exception("请检查所填内容。");
                    }
                    

                    if (CheckPassed)
                    {
                        ResultContact.Name = NameTextBox.Text.Replace("'", "''");
                        ResultContact.Group = GroupComboBox.Text.Replace("'", "''");
                        ResultContact.Num = NumTextBox.Text.Replace("'", "''");
                        ResultContact.Remark = RemarkTextBox.Text.Replace("'", "''");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                if (sender == AbortButton)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    this.Dispose();
                }
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message, "请检查内容", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ResetBackColor(object sender, EventArgs e)
        {
            if (GroupComboBox.Focused && GroupComboBox.BackColor != System.Drawing.SystemColors.Window)
            {
                GroupComboBox.BackColor = System.Drawing.SystemColors.Window;
            }
            if (NameTextBox.Focused && NameTextBox.BackColor != System.Drawing.SystemColors.Window)
            {
                NameTextBox.BackColor = System.Drawing.SystemColors.Window;
            }
            if (NumTextBox.Focused && NumTextBox.BackColor != System.Drawing.SystemColors.Window)
            {
                NumTextBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }
    }
}
