using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ContactsManager
{
    class DBIO
    {
        public DataGridView TargetDataGridView;
        public ListView TargetListView;
        public string InsertString;
        public string DBPath;
        public string TableName;
        public string ConnectionInfo()
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DBPath;
        }
        public string QueryCommand;

        #region Common
        //检查行列数
        internal void CheckElementsAndCols(int ElementNums, int Cols)
        {
            if (ElementNums != Cols)
            {
                throw new Exception("要插入的元素数量不正确，应为" + ElementNums + "个。");
            }
        }

        //获取当前时间
        internal static string DT()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        #endregion

        #region Oledb

        #region OleDbCommon
        //检查数据库是否存在
        internal void CheckOleDbExists(string DBName)
        {
            //File exists?
            if (!File.Exists(DBPath))
            {
                //Need confirmation
                if (MessageBox.Show(DBPath + " 不存在，是否创建？", "Emmmmmm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    System.Reflection.Assembly DBAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                    var DBStream = DBAssembly.GetManifestResourceStream(DBName);
                    byte[] DBResource = new Byte[DBStream.Length];
                    DBStream.Read(DBResource, 0, (int)DBStream.Length);
                    var DBFileStream = new FileStream(DBPath, FileMode.Create);
                    DBFileStream.Write(DBResource, 0, (int)DBStream.Length);
                    DBFileStream.Close();
                }
                else
                {
                    throw new OperationCanceledByUserException("数据库创建操作被用户取消。");
                }
            }
        }

        //读取到操作数据框的重载
        internal DataSet OleDbQuery2DataSet()
        {
            DataSet ReadData = new DataSet();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo()))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = QueryCommand,
                    Connection = Connection
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter
                {
                    SelectCommand = Command
                };

                Adapter.Fill(ReadData, TableName);
            }
            return ReadData;
        }

        //行优先查询到列表
        internal List<string> OleDbQuery2List()
        {
            List<string> Result = new List<string>();
            DataSet DS = OleDbQuery2DataSet();
            DataTable Dt = DS.Tables[0];
            for (int CurrentRow = 0; CurrentRow < Dt.Rows.Count; CurrentRow++)  //遍历数据表的行，一行构造一个Item
            {
                for (int CurrentColumn = 0; CurrentColumn < Dt.Columns.Count; CurrentColumn++)  //遍历数据表每行的列
                {
                    Result.Add(Dt.Rows[CurrentRow][CurrentColumn].ToString());
                }
            }
            return Result;
        }

        //保存操作
        internal void OleDbNonQuery2DB()
        {
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo()))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = QueryCommand,
                    Connection = Connection
                };
                Command.ExecuteNonQuery();
            }
        }

        #endregion

        #region OleDbDataGridView
        //读取整张表操作
        internal void OleDbQuery2DataGridViewFull()
        {
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo()))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = "SELECT * FROM " + TableName,
                    Connection = Connection
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter
                {
                    SelectCommand = Command
                };
                DataSet ReadData = new DataSet();
                Adapter.Fill(ReadData, TableName);
                TargetDataGridView.DataSource = ReadData.Tables[TableName];
                Command.ExecuteReader();
            }
        }

        //查询操作
        internal void OleDbQuery2DataGridView()
        {
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo()))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = QueryCommand,
                    Connection = Connection
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter
                {
                    SelectCommand = Command
                };
                DataSet ReadData = new DataSet();
                Adapter.Fill(ReadData, TableName);
                TargetDataGridView.DataSource = ReadData.Tables[TableName];
                Command.ExecuteReader();
            }
        }

        //删除操作
        internal void OleDbDataGridViewDeleteFromDB(int RowIndex)
        {
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo()))
            {
                Connection.Open();
                string DeleteRow = TargetDataGridView.Rows[RowIndex].Cells[0].Value.ToString();
                OleDbCommand DeleteCommand = new OleDbCommand
                {
                    CommandText = "DELETE FROM " + TableName + " WHERE ID = " + DeleteRow,
                    Connection = Connection
                };
                DeleteCommand.ExecuteNonQuery();
                if (MessageBox.Show("删除第" + (RowIndex + 1).ToString() + "行数据成功！") == DialogResult.OK)
                {
                    OleDbQuery2DataGridView();
                }
            }
        }

        //插入操作
        internal void OleDbDataGridViewInsert2DB(string Cols, string[] InputStringArray, int ColumnCount)
        {
            string Command = "INSERT INTO " + TableName + " " + Cols + " VALUES ('" + DT() + "', ";
            for (int i = 0; i < ColumnCount; i++)
            {
                if (i < ColumnCount - 1)
                {
                    Command += InputStringArray[i] + ", ";
                }
                if (i == ColumnCount - 1)
                {
                    Command += InputStringArray[i] + ")";
                }
            }
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo()))
            {
                Connection.Open();
                OleDbCommand CreateCommand = new OleDbCommand
                {
                    CommandText = Command,
                    Connection = Connection
                };
                CreateCommand.ExecuteNonQuery();
                if (MessageBox.Show("插入成功！") == DialogResult.OK)
                {
                    OleDbQuery2DataGridView();
                }
            }
        }

        //更新操作
        internal void OleDbDataGridViewUpdate2DB(int ColumnIndex, int RowIndex)
        {
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo()))
            {
                Connection.Open();
                string UpdateCols = TargetDataGridView.Columns[ColumnIndex].HeaderText;  //Get column header
                string UpdateRows = TargetDataGridView.Rows[RowIndex].Cells[0].Value.ToString(); //Get the value of the first cell in the row focused
                string NewValue = TargetDataGridView.CurrentCell.Value.ToString();   //Get the value of currently selected cell
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = "UPDATE " + TableName + " SET " + UpdateCols + " = " + NewValue + " WHERE ID = " + UpdateRows,
                    Connection = Connection
                };
                Command.ExecuteNonQuery();
            }
        }
        #endregion

        #region OleDbListView
        //查询操作
        internal void OleDbQuery2ListView(ListView TargetListView, int[] ColumnWidth, out int ResultCount)
        {
            DataSet DS = new DataSet();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo()))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = QueryCommand,
                    Connection = Connection
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter
                {
                    SelectCommand = Command
                };
                Adapter.Fill(DS, TableName);
                Command.ExecuteReader();
            }
            DataTable Dt = DS.Tables[0];
            ResultCount = Dt.Rows.Count;
            if (ColumnWidth.Length != Dt.Columns.Count)
            {
                throw new ColumnCheckException("用户定义的列表列数数组长度与查询结果表列数不符。");
            }
            TargetListView.Items.Clear();
            TargetListView.Columns.Clear();

            for (int CurrentColumn = 0; CurrentColumn < Dt.Columns.Count; CurrentColumn++)  //遍历数据表每行的列获取标题
            {
                TargetListView.Columns.Add(Dt.Columns[CurrentColumn].ColumnName, ColumnWidth[CurrentColumn], HorizontalAlignment.Left);
            }

            for (int CurrentRow = 0; CurrentRow < Dt.Rows.Count; CurrentRow++)  //遍历数据表的行，一行构造一个Item
            {
                ListViewItem LVI = new ListViewItem();
                for (int CurrentColumn = 0; CurrentColumn < Dt.Columns.Count; CurrentColumn++)  //遍历数据表每行的列
                {
                    if (CurrentColumn == 0) //遍历到第一列时添加Item的文本（第一列文字）
                    {
                        LVI.Text = Dt.Rows[CurrentRow][0].ToString();
                    }
                    else  //遍历非第一列时添加子项
                    {
                        LVI.SubItems.Add(Dt.Rows[CurrentRow][CurrentColumn].ToString());
                    }
                }
                TargetListView.Items.Add(LVI);
            }
        }
        #endregion
        
        #endregion

        #region Exceptions
        [Serializable]
        public class ColumnCheckException : Exception
        {
            public ColumnCheckException() { }
            public ColumnCheckException(string message) : base(message) { }
            public ColumnCheckException(string message, Exception inner) : base(message, inner) { }
            protected ColumnCheckException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        public class OperationCanceledByUserException : Exception
        {
            public OperationCanceledByUserException() { }
            public OperationCanceledByUserException(string message) : base(message) { }
            public OperationCanceledByUserException(string message, Exception inner) : base(message, inner) { }
            protected OperationCanceledByUserException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        #endregion
    }
}
