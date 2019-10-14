using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DotNetSample.Utils
{
    public class SQLiteHelper
    {
        //创建数据库文件
        public static void CreateDBFile(string fileName)
        {
            string path = System.Environment.CurrentDirectory + @"/Data/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string databaseFileName = path + fileName;
            if (!File.Exists(databaseFileName))
            {
                SQLiteConnection.CreateFile(databaseFileName);
            }
        }

        //生成连接字符串
        private static string CreateConnectionString()
        {
            SQLiteConnectionStringBuilder connectionString = new SQLiteConnectionStringBuilder();
            connectionString.DataSource = @"data/ScriptHelper.db";

            string conStr = connectionString.ToString();
            return conStr;
        }

        /// <summary>
        /// 对插入到数据库中的空值进行处理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDbValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 对从数据库中读取的空值进行处理
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object FromDbValue(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 执行非查询的数据库操作
        /// </summary>
        /// <param name="sqlString">要执行的sql语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回受影响的条数</returns>
        public static int ExecuteNonQuery(string sqlString, params SQLiteParameter[] parameters)
        {
            string connectionString = CreateConnectionString();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlString;
                    foreach (SQLiteParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行查询并返回查询结果第一行第一列
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="sqlparams">参数列表</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlString, params SQLiteParameter[] parameters)
        {
            string connectionString = CreateConnectionString();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlString;
                    foreach (SQLiteParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询多条数据
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回查询的数据表</returns>
        public static DataTable GetDataTable(string sqlString, params SQLiteParameter[] parameters)
        {
            string connectionString = CreateConnectionString();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlString;
                    foreach (SQLiteParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    DataSet ds = new DataSet();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        public static DataTable GetDataTable(SQLiteConnection conn, string sqlString, params SQLiteParameter[] parameters)
        {
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqlString;
                foreach (SQLiteParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                DataSet ds = new DataSet();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(ds);
                return ds.Tables[0];
            }
        }
        public static SQLiteConnection GetConnection(string dbPath)
        {
            string connStr = string.Empty;
            if (!string.IsNullOrEmpty(dbPath))
            {
                connStr = "Data Source=" + dbPath;
            }
            else
            {
                connStr = ConfigurationManager.ConnectionStrings["DbSQLite"].ToString();
            }
            SQLiteConnection conn = new SQLiteConnection(connStr);
            return conn;
        }
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="dbPath">指定数据库文件</param>
        /// <param name="tableName">表名称</param>
        public static int NewTable(SQLiteConnection sqliteConn, string tableName)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = sqliteConn;
            cmd.CommandText = "CREATE TABLE " + tableName + "(Name varchar(20),Team varchar(20), Number varchar(20));";
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sqliteConnString">连接</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="originalPassword">原始密码</param>
        public static bool ChangePassword(string sqliteConnString, string newPassword, string originalPassword = "")
        {
            var isCorrect = false;
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(sqliteConnString))
                {
                    if (!string.IsNullOrEmpty(originalPassword))
                    {
                        conn.SetPassword(originalPassword);
                    }
                    conn.Open();
                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        conn.ChangePassword(newPassword);
                        conn.Close();
                        isCorrect = true;
                    }
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("无法连接到数据库!" + ex.Message);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                isCorrect = false;
                throw e;
            }
            return isCorrect;
        }
    }
    class SqliteHelper
    {
        public SqliteHelper()
        {
            //  
            //TODO: 在此处添加构造函数逻辑  
            //  
        }

        private static SQLiteConnection GetConnection()
        {
            string connStr = System.Configuration.ConfigurationManager.AppSettings["DbSQLite"].ToString();
            SQLiteConnection conn = new SQLiteConnection(connStr);
            conn.Open();
            return conn;
        }

        public static int ExecuteSql(string sql)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                var cmd = new SQLiteCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
        }
        public static int ExecuteSql(string sql, List<SQLiteParameter> paras)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                var cmd = new SQLiteCommand(sql, conn);
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras.ToArray());
                }
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, List<SQLiteParameter> paras = null)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                var cmd = new SQLiteCommand(sql, conn);
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras.ToArray());
                }
                return cmd.ExecuteScalar();
            }
        }
        public static SQLiteDataReader ExecuteReader(string sql)
        {
            SQLiteConnection conn = GetConnection();
            var cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        }

        internal static DataTable ExecDataTable(string sql, List<SQLiteParameter> paras)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                var cmd = new SQLiteCommand(sql, conn);
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras.ToArray());
                }
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds.Tables[0];
            }
        }

        public static DataSet ExecDataSet(string sql)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                var cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
        }
        public static DataTable ExecDataTable(string sql)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                var cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds.Tables[0];
            }
        }
    }
}
