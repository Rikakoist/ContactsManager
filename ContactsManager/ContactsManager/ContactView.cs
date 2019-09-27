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
using System.IO;

namespace ContactsManager
{
    public partial class ContactView : Form
    {
        public ContactView()
        {
            InitializeComponent();
        }

        Thread DBProcessingThread = null;
        internal List<string> ComboBoxList = new List<string>();
        static string WorkFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string DBPath = WorkFolder + @"\Contacts.mdb";
        int[] ColumnWidth = { 60, 100, 60, 120, 180 };  //设定每列的宽度

        public enum OrderMethod
        {
            NONE = 0,
            ASC = 1,
            DESC = 2,
        }

        DBIO ContactQu = new DBIO
        {
            DBPath = WorkFolder + @"\Contacts.mdb",
            TableName = "Contacts",
        };

        //Load事件
        private void InitForm(object sender, EventArgs e)
        {
            SetHint("你好，" + Environment.UserName + "。");
            CheckDBExists();
            InitGroup();
            //GroupComboBox.SelectedIndex = 0;
            Query();
        }

        #region DB
        //数据库文件检查
        private void CheckDBExists()
        {
            try
            {
                //File exists?
                if (!File.Exists(DBPath))
                {
                    System.Reflection.Assembly DBAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                    var DBStream = DBAssembly.GetManifestResourceStream("ContactsManager.Contacts.mdb");
                    byte[] DBResource = new Byte[DBStream.Length];
                    DBStream.Read(DBResource, 0, (int)DBStream.Length);
                    var DBFileStream = new FileStream(DBPath, FileMode.Create);
                    DBFileStream.Write(DBResource, 0, (int)DBStream.Length);
                    DBFileStream.Close();
                }
            }
            catch (Exception err)
            {
                SetHint(err.Message);
            }
        }

        //控制查询线程
        private void VagueQueryCtrl(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(QueryTextBox.Text) || String.IsNullOrWhiteSpace(GroupComboBox.Text))
                {
                    Query();
                }
                else
                {
                    Query(("%" + String.Join("%", QueryTextBox.Text.ToArray()) + "%").Replace("'", "''"));   //模 糊 查 询
                }
            }
            catch (System.Data.OleDb.OleDbException)
            {
                SetHint("查询条件中包含非法字符！");
            }
            catch (Exception)
            {
                SetHint("出现了未定义的错误。");
            }
            //if (!first&&QueryThread.IsAlive)
            //{
            //    QueryThread.Abort();
            //}
            //QueryThread = new Thread(VagueQuery)
            //{
            //    Priority = ThreadPriority.Normal
            //};
            //QueryThread.Start();
            //first = false;
        }

        //不带参数整表查询
        private void Query()
        {
            ContactQu.QueryCommand =
                  "SELECT ID as 联系人ID, ContactName as 姓名, ContactGroup as 分组, ContactNum as 联系方式, ContactRemark as 备注 " +
                  "FROM " + ContactQu.TableName;
            if (GroupComboBox.SelectedIndex > 0)
            {
                ContactQu.QueryCommand += " WHERE ContactGroup = '" + GroupComboBox.SelectedItem.ToString().Replace("'", "''") + "'";
            }
            ContactQu.OleDbQuery2ListView(QueryResultListView, ColumnWidth, out int ResultCount);
            //SetHint("显示整张表。");
        }

        //带参数查询
        private void Query(string Str)
        {
            ContactQu.QueryCommand =
                "SELECT ID as 联系人ID, ContactName as 姓名, ContactGroup as 分组, ContactNum as 联系方式, ContactRemark as 备注 " +
                "FROM " + ContactQu.TableName +
                " WHERE (ContactName LIKE '" + Str + "' OR ContactNum LIKE '" + Str + "' OR ContactRemark LIKE '" + Str + "')";
            if (GroupComboBox.SelectedIndex > 0)
            {
                ContactQu.QueryCommand += " AND ContactGroup='" + GroupComboBox.SelectedItem.ToString().Replace("'", "''") + "'";
            }
            else
            {
                ContactQu.QueryCommand += " OR ContactGroup LIKE '" + Str + "'";
            }
            ContactQu.OleDbQuery2ListView(QueryResultListView, ColumnWidth, out int ResultCount);
            SetHint("查询到" + ResultCount + "个符合条件的结果。");
        }

        //更新操作
        private bool NonQuery(Contact Ct, int Method)
        {
            switch (Method)
            {
                case 0:
                    {
                        ContactQu.QueryCommand =
                            "UPDATE " + ContactQu.TableName +
                            " SET ContactName = '" + Ct.Name + "', ContactGroup = '" + Ct.Group + "', ContactNum = '" + Ct.Num + "', ContactRemark = '" + Ct.Remark +
                            "' WHERE ID = " + Ct.ID;
                        break;
                    }
                case 1:
                    {
                        ContactQu.QueryCommand =
                            "INSERT INTO " + ContactQu.TableName +
                            " (ContactName, ContactGroup, ContactNum, ContactRemark) VALUES ('" + Ct.Name + "', '" + Ct.Group + "', '" + Ct.Num + "', '" + Ct.Remark + "')";
                        break;
                    }
                case 2:
                    {
                        ContactQu.QueryCommand =
                            "DELETE FROM " + ContactQu.TableName +
                            " WHERE ID = " + Ct.ID;
                        break;
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException("操作方法无效。");
                    }
            }
            ContactQu.OleDbNonQuery2DB();
            return true;
        }

        #endregion

        //重载分组
        private void InitGroup()
        {
            try
            {
                string CurrentText = GroupComboBox.Text;
                ComboBoxList.Clear();
                ComboBoxList.Add("全部联系人");
                ContactQu.QueryCommand =
                    "SELECT DISTINCT ContactGroup FROM " + ContactQu.TableName;
                ComboBoxList.AddRange(ContactQu.OleDbQuery2List());
                GroupComboBox.Items.Clear();
                foreach (string Str in ComboBoxList)
                {
                    GroupComboBox.Items.Add(Str);
                }
                if (ComboBoxList.IndexOf(CurrentText) < 0)
                {
                    GroupComboBox.SelectedIndex = 0;
                }
                else
                {
                    GroupComboBox.SelectedIndex = ComboBoxList.IndexOf(CurrentText);
                }
            }
            catch (Exception)
            {
                SetHint("在初始化分组列表过程中出现了问题。");
            }
        }

        //右键菜单可用性
        private void ConfigAvailability(object sender, CancelEventArgs e)
        {
            if (QueryResultListView.SelectedItems.Count < 1)
            {
                EditContactStripMenuItem.Enabled = false;
                DeleteContactStripMenuItem.Enabled = false;
                ViewContactStripMenuItem.Enabled = false;
            }
            if (QueryResultListView.SelectedItems.Count > 1)
            {
                ViewContactStripMenuItem.Enabled = false;
            }
        }
        private void ConfigAvailability(object sender, ToolStripDropDownClosedEventArgs e)
        {
            EditContactStripMenuItem.Enabled = true;
            DeleteContactStripMenuItem.Enabled = true;
            ViewContactStripMenuItem.Enabled = true;
        }

        //联系人操作
        private void ContactOperation(object sender, EventArgs e)
        {
            try
            {
                //添加
                if (sender == AddContactStripMenuItem)
                {
                    ContactOperationForm AddContact = new ContactOperationForm(ComboBoxList)
                    {
                        Text = "添加联系人",
                    };
                    if (AddContact.ShowDialog() == DialogResult.OK)
                    {
                        Contact CurrentContact = AddContact.ResultContact;
                        if (NonQuery(CurrentContact, 1))
                        {
                            SetHint("成功新建联系人记录至" + CurrentContact.Group + "分组。");
                        }
                        else
                        {
                            throw new Exception("尝试更新记录失败。");
                        }
                    }
                    else
                    {
                        throw new OperationCanceledException("添加操作被用户取消。");
                    }
                    AddContact.Dispose();
                }
                //编辑
                if (sender == EditContactStripMenuItem)
                {
                    for (int i = 0; i < QueryResultListView.SelectedItems.Count; i++)
                    {
                        Contact CurrentContact = new Contact()
                        {
                            ID = QueryResultListView.SelectedItems[i]?.Text ?? null,
                            Name = QueryResultListView.SelectedItems[i]?.SubItems[1]?.Text ?? null,
                            Group = QueryResultListView.SelectedItems[i]?.SubItems[2]?.Text ?? null,
                            Num = QueryResultListView.SelectedItems[i]?.SubItems[3]?.Text ?? null,
                            Remark = QueryResultListView.SelectedItems[i]?.SubItems[4]?.Text ?? null,
                        };
                        ContactOperationForm EditContact = new ContactOperationForm(ComboBoxList, CurrentContact)
                        {
                            Text = "编辑联系人",
                        };
                        if (EditContact.ShowDialog() == DialogResult.OK)
                        {
                            CurrentContact = EditContact.ResultContact;
                            if (NonQuery(CurrentContact, 0))
                            {
                                SetHint("成功更新联系人记录");
                            }
                            else
                            {
                                throw new Exception("尝试更新记录失败。");
                            }
                        }
                        else
                        {
                            throw new OperationCanceledException("编辑操作被用户取消。");
                        }
                        EditContact.Dispose();
                    }
                }
                //删除
                if (sender == DeleteContactStripMenuItem)
                {
                    if (QueryResultListView.SelectedItems.Count < 1)
                    {
                        throw new ArgumentException("未选中项目。");
                    }
                    if (MessageBox.Show("你确定？", "删除选定的项？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < QueryResultListView.SelectedItems.Count; i++)
                        {
                            Contact CurrentContact = new Contact()
                            {
                                ID = QueryResultListView.SelectedItems[i]?.Text ?? null,
                                Name = QueryResultListView.SelectedItems[i]?.SubItems[1]?.Text ?? null,
                                Group = QueryResultListView.SelectedItems[i]?.SubItems[2]?.Text ?? null,
                                Num = QueryResultListView.SelectedItems[i]?.SubItems[3]?.Text ?? null,
                                Remark = QueryResultListView.SelectedItems[i]?.SubItems[4]?.Text ?? null,
                            };
                            NonQuery(CurrentContact, 2);
                        }
                    }
                    else
                    {
                        throw new OperationCanceledException("删除操作被用户取消");
                    }
                }
                //查看
                if (sender == ViewContactStripMenuItem)
                {
                    Contact CurrentContact = new Contact()
                    {
                        ID = QueryResultListView.SelectedItems[0]?.Text ?? null,
                        Name = QueryResultListView.SelectedItems[0]?.SubItems[1]?.Text ?? null,
                        Group = QueryResultListView.SelectedItems[0]?.SubItems[2]?.Text ?? null,
                        Num = QueryResultListView.SelectedItems[0]?.SubItems[3]?.Text ?? null,
                        Remark = QueryResultListView.SelectedItems[0]?.SubItems[4]?.Text ?? null,
                    };
                    ContactOperationForm ViewContact = new ContactOperationForm(CurrentContact)
                    {
                        Text = "查看联系人",
                    };
                    if (ViewContact.ShowDialog() != DialogResult.None)
                    {
                        ViewContact.Dispose();
                    }
                }
                Thread.Sleep(1);
                InitGroup();
                VagueQueryCtrl(null, null);
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
                SetHint(err.Message.Replace("\r\n", "。"));
            }
        }
        private void DoubleClickListViewOperation(object sender, MouseEventArgs e)
        {
            if (QueryResultListView.SelectedItems.Count == 1)
            {
                ContactOperation(this.EditContactStripMenuItem, null);
            }
            if (QueryResultListView.SelectedItems is null)  //双击空白处新建项目，为啥没用？
            {
                ContactOperation(this.AddContactStripMenuItem, null);
            }
        }

        #region Others
        //设置反馈
        private void SetHint(string Hint)
        {
            HintLabel.Text = Hint;
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            AboutThisApp ATA = new AboutThisApp();
            ATA.ShowDialog();
        }

        //关闭窗口
        private void ExitApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

    }
}
