using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections;
using System.Threading;

namespace OnLineUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
        private string GetTheLastUpdateTime(string Dir)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string theLastsUpdateDate = GetTheLastUpdateTime(System.Environment.CurrentDirectory);
            fileUpDown.Download(CommonStaticParameter.TEMP, "UpdateConfig.xml", "EnergyEquipment");
            string thePreUpdateDate = GetTheLastUpdateTime(CommonStaticParameter.TEMP);
            if (thePreUpdateDate != "")
            {
                //如果客户端将升级的应用程序的更新日期大于服务器端升级的应用程序的更新日期    
                if (thePreUpdateDate == theLastsUpdateDate)
                {
                    if (MessageBox.Show("当前软件已经是最新的，无需更新！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }
                }
            }
            File.Copy(CommonStaticParameter.TEMP + "\\UpdateConfig.xml", System.Environment.CurrentDirectory + "\\UpdateConfig.xml", true);

            //关闭原有的应用程序     
            this.labDownFile.Text = "正在关闭程序....";
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("EnergyEquipmentProject");
            //关闭原有应用程序的所有进程     
            foreach (System.Diagnostics.Process pro in proc)
            {
                pro.Kill();
            }


            this.labDownFile.Text = "下载更新文件";
            this.button1.Enabled = false;  
            this.progressBarTotal.Value = 0;
            BatchDownload();
            MessageBox.Show("更新成功！");

            this.labDownFile.Text = "正在启动程序....";
            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + "EnergyEquipmentProject.exe");
            this.Close();
        }

        private void BatchDownload()
        {
            try
            {
                if (!File.Exists(System.Environment.CurrentDirectory + "\\UpdateConfig.xml"))
                    return;//打开xml文件     
                FileStream myFile = new FileStream(System.Environment.CurrentDirectory + "\\UpdateConfig.xml", FileMode.Open);//xml文件阅读器     
                XmlTextReader xml = new XmlTextReader(myFile);
                IList<string[]> fileList = new List<string[]>();
                while (xml.Read())
                {
                    if (xml.Name == "UpdateFile")
                    {
                        //获取升级文档的最后一次更新日期     
                        string[] s = { xml.GetAttribute("FileName"), xml.GetAttribute("DestPath") };
                        fileList.Add(s);
                    }
                }
                xml.Close();
                myFile.Close();

                progressBarTotal.Maximum = fileList.Count;
                int filesum = 0;
                foreach (string[] SourceFile in fileList)  //循环取服务器更新路径文件
                {
                    string FileName = SourceFile[0].Substring(SourceFile[0].LastIndexOf("/") + 1);//取更新文件名
                    string FilePath = SourceFile[0].Substring(0,SourceFile[0].LastIndexOf("/"));//取更新文件名
                    fileUpDown.Download(CommonStaticParameter.TEMP + FilePath, SourceFile[0], "EnergyEquipment");
                    string source = CommonStaticParameter.TEMP +FilePath.Replace('/','\\')+ "\\" + FileName;
                    string destFile = System.Environment.CurrentDirectory + SourceFile[1];
                    while (File.Exists(source) != true)
                    {
                        fileUpDown.Download(CommonStaticParameter.TEMP + FilePath, SourceFile[0], "EnergyEquipment");
                    }
                    this.labDownFile.Text = "正在下载文件：" + FileName + "，文件总数量：" + fileList.Count.ToString();
                    this.labDownFile.Refresh();
                    //本地目录有相同文件名就需要判断是否为可用更新文件   
                    if (File.Exists(destFile) == true)
                    {
                        DateTime dtLocal = File.GetLastWriteTime(destFile);//本地文件修改日期   
                        DateTime dtUpdate = File.GetLastWriteTime(source);//更新目录文件的修改日期   

                        if (dtUpdate != dtLocal)//可用更新   
                        {
                            ++filesum;
                            this.labDownFile.Text = "正在复制文件：" + FileName + "，文件总数量：" + fileList.Count.ToString();
                            this.labDownFile.Refresh();
                            File.Copy(source, destFile + FileName, true);
                        }
                    }
                    else
                    {
                        ++filesum;
                        this.labDownFile.Text = "正在复制文件：" + FileName + "，文件总数量：" + fileList.Count.ToString();
                        this.labDownFile.Refresh();
                        File.Copy(source, destFile + FileName, true);
                    }
                    progressBarTotal.Value = filesum;
                }
                progressBarTotal.Value = fileList.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败！"+ex.Message);
            }
        }


    }
}
