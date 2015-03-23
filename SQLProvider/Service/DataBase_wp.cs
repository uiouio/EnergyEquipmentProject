using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CommonMethod;

namespace SQLProvider.Service
{
    public class DataBase_wp
    {
        //private SqlConnection myCon;  //创建连接对象

        private static SqlConnection myCon = null;

        public static SqlConnection getSqlConnection()
        {
            if (myCon == null || myCon.State == ConnectionState.Closed)
            {
                string ip = FileReadAndWrite.IniReadValue("connect", "ip");
                string id = FileReadAndWrite.IniReadValue("connect", "id");
                string pwd = FileReadAndWrite.IniReadValue("connect", "pwd");
                string db = FileReadAndWrite.IniReadValue("connect", "db");
                myCon = new SqlConnection("UID=" + Securit.DeDES(id) + ";PWD=" + Securit.DeDES(pwd) + ";Database=" + Securit.DeDES(db) + ";server=" + Securit.DeDES(ip));
            }
            if (myCon.State != ConnectionState.Open)
            {
                try
                {
                    myCon.Open();
                }
                catch
                {
                    throw;
                }
            }
            return myCon;
        }
        
        #region   打开数据库连接
        /// <summary>
        /// 打开数据库连接.
        /// </summary>
        private void Open()
        {
            // 打开数据库连接
            myCon = getSqlConnection();
            if (myCon.State == System.Data.ConnectionState.Closed)
                myCon.Open();

        }
        #endregion

        #region  关闭连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (myCon != null)
                myCon.Close();
        }
        #endregion

        #region 释放数据库连接资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            // 确认连接是否已经关闭
            if (myCon != null)
            {
                myCon.Dispose();
                myCon = null;
            }
        }
        #endregion



        #region   执行参数命令文本(无数据库中数据返回)

        /// <summary>
        /// 直接执行SQL语句
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <returns></returns>
        public int RunProc(string procName)
        {
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, myCon);
            cmd.ExecuteNonQuery();
            this.Close();
            return 1;
        }

        #endregion

        #region   执行参数命令文本(有返回值)

        /// <summary>
        /// 执行命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName">命令文本</param>
        /// <param name="tbName">数据表名称</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcReturn(string procName, string tbName)
        {
            //OleDbDataAdapter dap = CreateDataAdaper(procName, null);
            this.Open();
            SqlDataAdapter dap = new SqlDataAdapter(procName, myCon);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            //得到执行成功返回值
            return ds;
        }

        #endregion

    }
}
