using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using CommonMethod;

namespace SQLProvider.Connection
{
    public class Connection
    {
        private static Configuration cfg = null;

        public static Configuration getConfiguration()
        {
            if (cfg == null)
            {
                cfg = new Configuration();
                string ip = FileReadAndWrite.IniReadValue("connect", "ip");
                string id = FileReadAndWrite.IniReadValue("connect", "id");
                string pwd = FileReadAndWrite.IniReadValue("connect", "pwd");
                string db = FileReadAndWrite.IniReadValue("connect", "db");
                cfg.SetProperty("connection.connection_string", "UID=" + Securit.DeDES(id) + ";PWD=" + Securit.DeDES(pwd) + ";Database=" + Securit.DeDES(db) + ";server=" + Securit.DeDES(ip));
                cfg.AddAssembly("EntityClassLibrary");
            }
            return cfg;
        }

        private static ISessionFactory factory = null;

        public static ISessionFactory getSessionFactory()
        {
            if (factory == null||factory.IsClosed)
            {
                factory = Connection.getConfiguration().BuildSessionFactory();
            }
            return factory;
        }

        private static SqlConnection connection = null;

        public static SqlConnection getSqlConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                string ip = FileReadAndWrite.IniReadValue("connect", "ip");
                string id = FileReadAndWrite.IniReadValue("connect", "id");
                string pwd = FileReadAndWrite.IniReadValue("connect", "pwd");
                string db = FileReadAndWrite.IniReadValue("connect", "db");
                connection = new SqlConnection("UID=" + Securit.DeDES(id) + ";PWD=" + Securit.DeDES(pwd) + ";Database=" + Securit.DeDES(db) + ";server=" + Securit.DeDES(ip));
            }
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    throw;
                }
            }
            return connection;
        }

    }
}
