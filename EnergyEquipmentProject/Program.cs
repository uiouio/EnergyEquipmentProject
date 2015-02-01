using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonMethod;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace EnergyEquipmentProject
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                string theLastsUpdateDate = GetTheLastUpdateTime(System.Environment.CurrentDirectory);
                fileUpDown.Download(CommonStaticParameter.TEMP, "UpdateConfig.xml", "EnergyEquipment");
                string thePreUpdateDate = GetTheLastUpdateTime(CommonStaticParameter.TEMP);
                if (thePreUpdateDate != "")
                {
                    //如果客户端将升级的应用程序的更新日期大于服务器端升级的应用程序的更新日期    
                    if (thePreUpdateDate != theLastsUpdateDate)
                    {
                        MessageBox.Show("当前软件不是最新的，请更新后登陆！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        {
                            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + "OnLineUpdate.exe");
                            return;
                        }
                    }
                }

                //处理未捕获的异常，始终将异常传送到 ThreadException 处理程序。忽略应用程序配置文件。   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //订阅ThreadException事件，处理UI线程异常，处理方法为 Application_ThreadException，关于事件的相关知识就不在这叙述了  
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ErrorManage.Application_ThreadException);
                //订阅UnhandledException事件，处理非UI线程异常 ，处理方法为 CurrentDomain_UnhandledException  
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorManage.CurrentDomain_UnhandledException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Login login = new Login();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    MainForm1 mainForm = new MainForm1();
                    mainForm.UserInfo = login.UserInfo;
                    string ip = FileReadAndWrite.IniReadValue("connect", "ip");
                    string id = FileReadAndWrite.IniReadValue("connect", "id");
                    string pwd = FileReadAndWrite.IniReadValue("connect", "pwd");
                    string db = FileReadAndWrite.IniReadValue("connect", "db");
                    //SqlDependency.Start("UID=" + Securit.DeDES(id) + ";PWD=" + Securit.DeDES(pwd) + ";Database=" + Securit.DeDES(db) + ";server=" + Securit.DeDES(ip));
                    Application.Run(mainForm);
                }
            }
            catch(Exception e)
            {
                CommonMethod.ErrorManage.DealErrorByFile(e);
            }
        }

        public static string GetTheLastUpdateTime(string Dir)
        {
            string LastUpdateTime = "";
            string AutoUpdaterFileName = Dir + @"\UpdateConfig.xml";
            if (!File.Exists(AutoUpdaterFileName))
                return LastUpdateTime;//打开xml文件     
            FileStream myFile = new FileStream(AutoUpdaterFileName, FileMode.Open);//xml文件阅读器     
            XmlTextReader xml = new XmlTextReader(myFile);
            while (xml.Read())
            {
                if (xml.Name == "Version")
                {
                    //获取升级文档的最后一次更新日期     
                    LastUpdateTime = xml.GetAttribute("Num"); break;
                }
            }
            xml.Close();
            myFile.Close();
            return LastUpdateTime;
        }
    }
}
