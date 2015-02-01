using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using CommonMethod;

namespace EnergyEquipmentProject
{
    public partial class Login : Form
    {
        Service.UserInfoService userInfoService = new Service.UserInfoService();
        private UserInfo userInfo;

        public UserInfo UserInfo
        {
            get { return userInfo; }
            set { userInfo = value; }
        }
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 将用户信息存入临时文件
            if (rem_checkBox.Checked)
            {
                FileReadAndWrite.IniWriteValue("temp", "rem", CommonStaticParameter.YES);
            }
            else
            {
                FileReadAndWrite.IniWriteValue("temp", "rem", CommonStaticParameter.NO);
            }
            if (auto_checkBox.Checked)
            {
                FileReadAndWrite.IniWriteValue("temp", "auto", CommonStaticParameter.YES);
            }
            else
            {
                FileReadAndWrite.IniWriteValue("temp", "auto", CommonStaticParameter.NO);
            }
            FileReadAndWrite.IniWriteValue("temp", "un", Securit.DES(textBox1.Text.Trim()));
            FileReadAndWrite.IniWriteValue("temp", "pw", Securit.DES(textBox2.Text.Trim()));
            #endregion
            IList userInfoList = userInfoService.getUserInfoByNameAndPwd(textBox1.Text.Trim(), textBox2.Text.Trim());
            if (userInfoList != null && userInfoList.Count == 1)
            {
                this.UserInfo = (UserInfo)userInfoList[0];
                userInfoService.ExecuteSQL("update UserInfo set TimeStamp=" + DateTime.Now.Ticks + " where Id=" + UserInfo.Id);//更新用户的最近一次登录时间
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (FileReadAndWrite.IniReadValue("temp", "rem").Equals(CommonStaticParameter.YES))
            {
                string un = Securit.DeDES(FileReadAndWrite.IniReadValue("temp", "un"));
                string pwd = Securit.DeDES(FileReadAndWrite.IniReadValue("temp", "pw"));
                rem_checkBox.Checked = true;
                textBox1.Text = un != null && un != "" ? un : "输入用户名";
                if (pwd != null && pwd != "")
                {
                    textBox2.UseSystemPasswordChar = true;
                    textBox2.Text = pwd;
                }
                else
                {
                    textBox2.UseSystemPasswordChar = false;
                    textBox2.Text = "输入密码";
                }
            }
            if (FileReadAndWrite.IniReadValue("temp", "auto").Equals(CommonStaticParameter.YES))
            {
                auto_checkBox.Checked = true;
                button1_Click(button1, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
