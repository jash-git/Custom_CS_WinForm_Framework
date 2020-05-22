using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Finisar.SQLite;//http://einboch.pixnet.net/blog/post/248187728-c%23%E6%93%8D%E4%BD%9Csqlite%E8%B3%87%E6%96%99%E5%BA%AB


namespace SetCPUCardParameter
{
    class SQLite
    {
        //--
        //SQLite
        public static String DBpath = "SetCPUCardParameter.db";//直接修改成相對路徑這樣就可克服中文路徑問題 at 20160905 public static String DBpath = System.Windows.Forms.Application.StartupPath + "\\SYRIS_V8.db";
        public static String StrModifyuid = "";
        public static SQLiteConnection m_icn = new SQLiteConnection();
        public static void initSQLiteDatabase()
        {

            if (!System.IO.File.Exists(DBpath))//偵測不到DB就建立新的
            {
                CreateSQLiteDatabase(DBpath);
                string createtablestring = "";

                createtablestring = "CREATE TABLE List (uid INTEGER PRIMARY KEY,cpucode TEXT,type TEXT,time TEXT,data TEXT,folderid TEXT,filename TEXT);";
                CreateSQLiteTable(DBpath, createtablestring);

            }
        }
        public static SQLiteConnection OpenConn(string Database)//資料庫連線程式
        {
            string cnstr = string.Format("Data Source=" + Database + ";Version=3;New=False;Compress=True;");
            if (m_icn.State == ConnectionState.Closed)//if (m_icn.State != ConnectionState.Open)
            {
                m_icn.ConnectionString = cnstr;
                m_icn.Open();
            }
            return m_icn;
        }

        public static void CloseConn()
        {
            m_icn.Close();
        }

        public static void CreateSQLiteDatabase(string Database)//建立資料庫程式
        {
            string cnstr = string.Format("Data Source=" + Database + ";Version=3;New=True;Compress=True;");
            SQLiteConnection icn = new SQLiteConnection();
            icn.ConnectionString = cnstr;
            icn.Open();
            icn.Close();
        }

        public static void CreateSQLiteTable(string Database, string CreateTableString)//建立資料表程式
        {
            SQLiteConnection icn = OpenConn(Database);
            SQLiteCommand cmd = new SQLiteCommand(CreateTableString, icn);
            SQLiteTransaction mySqlTransaction = icn.BeginTransaction();
            try
            {
                cmd.Transaction = mySqlTransaction;
                cmd.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                mySqlTransaction.Rollback();
                throw (ex);
            }
            if (icn.State == ConnectionState.Open) icn.Close();
        }

        public static void SQLiteInsertImge(string Database, string SqlSelectString, byte[] buffer)//新增資料程式
        {
            SQLiteConnection icn = OpenConn(Database);
            SQLiteCommand cmd = new SQLiteCommand(SqlSelectString, icn);
            //SQLiteTransaction mySqlTransaction = icn.BeginTransaction();
            try
            {
                //cmd.Transaction = mySqlTransaction;

                SQLiteParameter para = new SQLiteParameter("@data", DbType.Binary);
                para.Value = buffer;
                cmd.Parameters.Add(para);

                cmd.ExecuteNonQuery();
                //mySqlTransaction.Commit();
            }
            catch //(Exception ex)
            {
                //mySqlTransaction.Rollback();
                //throw (ex);
            }
            if (icn.State == ConnectionState.Open) icn.Close();
        }

        public static void SQLiteInsertUpdateDelete(string Database, string SqlSelectString)//新增資料程式
        {
            SQLiteConnection icn = OpenConn(Database);
            SQLiteCommand cmd = new SQLiteCommand(SqlSelectString, icn);
            SQLiteTransaction mySqlTransaction = icn.BeginTransaction();
            try
            {
                cmd.Transaction = mySqlTransaction;
                cmd.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch //(Exception ex)
            {
                mySqlTransaction.Rollback();
                //throw (ex);
            }
            if (icn.State == ConnectionState.Open) icn.Close();
        }

        public static SQLiteDataReader GetDataReader(string Database, string SQLiteString)//讀取資料程式
        {
            SQLiteConnection icn = OpenConn(Database);
            SQLiteDataAdapter da = new SQLiteDataAdapter(SQLiteString, icn);

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = icn.CreateCommand();// 要下任何命令先取得該連結的執行命令物件
            sqlite_cmd.CommandText = SQLiteString;

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();// 執行查詢塞入 sqlite_datareader
            return sqlite_datareader;
        }

        public static DataTable GetDataTable(string Database, string SQLiteString)//讀取資料程式
        {
            DataTable myDataTable = new DataTable();
            SQLiteConnection icn = OpenConn(Database);
            SQLiteDataAdapter da = new SQLiteDataAdapter(SQLiteString, icn);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            myDataTable = ds.Tables[0];
            return myDataTable;
        }
        //--

        public static void SQLite_clearDB()//清空資料庫紀錄
        {
            SQLiteInsertUpdateDelete(DBpath, "DELETE FROM SyrisCpuCard;");//清空
            //---
            //壓縮DB
            //http://milkgreenteaprogramecsharp.blogspot.com/2015/05/sqlite-vacuum-sqlite.html
            SQLiteConnection icn = OpenConn(DBpath);
            SQLiteCommand cmd = icn.CreateCommand();
            cmd.CommandText = "vacuum;";
            cmd.ExecuteNonQuery();
            if (icn.State == ConnectionState.Open) icn.Close();
            //---壓縮DB
        }

        public static void SQLite_testAdd()//將測試資料寫入DB
        {

        }
    }

}
