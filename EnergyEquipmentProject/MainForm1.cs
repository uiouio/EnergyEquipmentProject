using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLProvider.Service;
using EntityClassLibrary;
using CommonControl;
using System.Reflection;
using CommonMethod;
using System.Collections;
using System.IO;
using System.Data.SqlClient;

namespace EnergyEquipmentProject
{
    public partial class MainForm1 : CommonControl.BaseForm
    {
        public delegate void dataChangedHandler(object sender, SqlNotificationEventArgs e);
        Service.UserInfoService userInfoService = new Service.UserInfoService();
        public MainForm1()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //listenMethod_Login();
            this.Opacity = 0;
            this.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            MainPage u = new MainPage(this.UserInfo);
            u.Name = "首页";
            commonTabControl1.AddTabPage(u);
            IList resourceList = userInfoService.getAllOneLevelResource();
            if (resourceList != null && resourceList.Count > 0)
            {
                foreach (Resource resource in resourceList)
                {
                    TitleNode node = new TitleNode();
                    node.PResource = resource;
                    if (resource.PicturePath != null)
                    {
                        string tempPath = CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE + "\\" + resource.PicturePath;
                        if (File.Exists(tempPath))
                        {
                            node.NodePic = new Bitmap(tempPath);
                        }
                        else
                        {
                            CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                            fileUpDown.Download(CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE, resource.PicturePath, CommonStaticParameter.TITLE_RSOURCE);
                            if (File.Exists(tempPath))
                            {
                                node.NodePic = new Bitmap(tempPath);
                            }
                        }
                    }
                    node.NodeText = resource.ResourceName;
                    node.OnControlClick += new EventHandler(TitleNodeClick);
                    if (resource.TypeFullName != null)
                    {
                        string[] assembleAndClass = resource.TypeFullName.Split('|');
                        node.Tag = getAssemblyByReflection(assembleAndClass[0], assembleAndClass[1], resource.ResourceName, resource);
                    }
                    node.Parent = flowLayoutPanel1;
                }
            }
            this.Opacity = 1;
            this.Visible = true;
        }

        private Object getAssemblyByReflection(string assemblyName, string objectName, string title,Resource resource)
        {
            try
            {
                Assembly ass = Assembly.LoadFrom(CommonMethod.CommonStaticParameter.BASE_PATH + assemblyName + ".dll");
                Type type = ass.GetType(assemblyName + "." + objectName);
                Object obj = Activator.CreateInstance(type);
                PropertyInfo propertyInfo_Name = type.GetProperty("Name");
                propertyInfo_Name.SetValue(obj, title, null);
                PropertyInfo propertyInfo_Tag = type.GetProperty("Tag");
                propertyInfo_Tag.SetValue(obj, resource, null);
                PropertyInfo propertyInfo_User = type.GetProperty("User");
                propertyInfo_User.SetValue(obj, this.UserInfo, null);
                return obj;
            }
            catch(Exception e)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(e);
                return null;
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FileReadAndWrite.IniWriteValue("temp", "auto", CommonStaticParameter.NO);
            Application.Restart();
        }

        private void TitleNodeClick(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType() == typeof(Label))
                {
                    Label label = (Label)sender;
                    commonTabControl1.AddTabPage((CommonTabPage)label.Parent.Tag);
                }
                else if (sender.GetType() == typeof(TitleNode))
                {
                    UserControl uc = (UserControl)sender;
                    commonTabControl1.AddTabPage((CommonTabPage)uc.Tag);
                }
                else if (sender.GetType() == typeof(PictureBox))
                {
                    PictureBox pic = (PictureBox)sender;
                    commonTabControl1.AddTabPage((CommonTabPage)pic.Parent.Tag);
                }
            }
            catch (Exception exc)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(exc);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                String s = fileUpDown.Upload(openFileDialog1.FileName,CommonStaticParameter.TITLE_RSOURCE);
                MessageBox.Show(s);
            }
        }

        private void MainForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ip = FileReadAndWrite.IniReadValue("connect", "ip");
            string id = FileReadAndWrite.IniReadValue("connect", "id");
            string pwd = FileReadAndWrite.IniReadValue("connect", "pwd");
            string db = FileReadAndWrite.IniReadValue("connect", "db");
            //SqlDependency.Stop("UID=" + Securit.DeDES(id) + ";PWD=" + Securit.DeDES(pwd) + ";Database=" + Securit.DeDES(db) + ";server=" + Securit.DeDES(ip));
        }

        private void listenMethod_Login()
        {
            OnChangeEventHandler onChangeLogin = new OnChangeEventHandler(userLoginChange);
            BaseService.autoUpdateForm(onChangeLogin, "select TimeStamp from UserInfo where Id="+UserInfo.Id+" and State=" + (int)BaseEntity.stateEnum.Normal);
        }
        private void userLoginChange(object sender, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                dataChangedHandler dch = new dataChangedHandler(userLoginChange);
                this.Invoke(dch, new object[] { sender, e });
            }
            else
            {
                if (MessageBox.Show("您的账号在其他地方登陆！", "提示", MessageBoxButtons.OK) == DialogResult.OK) //友情提示框
                {
                    FileReadAndWrite.IniWriteValue("temp", "auto", CommonStaticParameter.NO);
                    System.Diagnostics.Process.Start(System.Environment.CurrentDirectory+@"\EnergyEquipmentProject.exe");
                    //this.Close();
                    Environment.Exit(0);
                    //Application.Exit();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            EidtUserInfo eui = new EidtUserInfo();
            eui.UserInfo = this.UserInfo;
            eui.ShowDialog();
        }


        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
                commonPictureButton1.NonSelectBackGroundImage = EnergyEquipmentProject.Properties.Resources.ToRight1;
                commonPictureButton1.SelectBackGroundImage = EnergyEquipmentProject.Properties.Resources.ToRight1;
            }
            else
            {
                panel4.Visible = true;
                commonPictureButton1.NonSelectBackGroundImage = EnergyEquipmentProject.Properties.Resources.ToLeft1;
                commonPictureButton1.SelectBackGroundImage = EnergyEquipmentProject.Properties.Resources.ToLeft1;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
