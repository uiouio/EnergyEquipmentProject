using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CommonMethod
{
    public class ErrorManage
    {
        /// <summary>
        ///这就是我们要在发生未处理异常时处理的方法，我这是写出错详细信息到文本，给大家做个参考
        ///做法很多，可以是把出错详细信息记录到文本、数据库，发送出错邮件到作者信箱或出错后重新初始化等等
        ///这就是仁者见仁智者见智，大家自己做了。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            DealErrorByFile(e.Exception);
            MessageBox.Show("操作有误，请检查后重新操作！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            DealErrorByFile(e.ExceptionObject as Exception);
            MessageBox.Show("发生错误，您可以对错误进行记录，上报作者进行改进！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void DealErrorByFile(Exception e)
        {
            string str = "";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "/r/n";
            if (e != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}/r/n异常消息：{1}/r/n异常信息：{2}/r/n",
                     e.GetType().Name, e.Message, e.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", e);
            }

            if (!Directory.Exists("ErrorLog"))
            {
                Directory.CreateDirectory("ErrorLog");
            }
            FileReadAndWrite.writeLog(str,"ErrorLog","ErrorLog.txt");
        }
    }
}
