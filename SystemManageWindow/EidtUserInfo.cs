using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SQLProvider.Service;
using CommonMethod;
using EntityClassLibrary;

namespace SystemManageWindow
{
    public partial class EidtUserInfo : CommonControl.BaseForm
    {
        BaseService baseService = new BaseService();
        private bool isNew;
        public int entrance;
        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }
        public EidtUserInfo()
        {
            InitializeComponent();
        }

        private void updateCombox()
        { 
            Service.DepartmentService OP_DP=new Service.DepartmentService();
            System.Collections.IList ds = OP_DP.getAllDepts();
            if (ds.Count != 0)
            {
                this.comboBox_dept.DataSource = ds;
                this.comboBox_dept.DisplayMember = "DepartmentName";
                this.comboBox_dept.ValueMember = "Itself";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestInput testInput = new TestInput();
            if (!testInput.TestEmail(textBox_mail.Text.Trim()) && textBox_mail.Text != "")
            {
                MessageBox.Show("邮编格式不正确！");
                textBox_mail.Text = "";
                textBox_mail.Focus();
            }
            if (!testInput.TestIdCard(textBox_sfzh.Text.Trim()) && textBox_sfzh.Text != "")
            {
                MessageBox.Show("身份证号格式不正确！");
                textBox_sfzh.Text = "";
                textBox_sfzh.Focus();
            }
            if (!testInput.TestNum(textBox_age.Text.Trim()) && textBox_age.Text != "")
            {
                MessageBox.Show("年龄必须为数字！");
                textBox_age.Text = "";
                textBox_age.Focus();
            }
            if (this.UserInfo == null)
                this.UserInfo = new UserInfo();
            this.UserInfo.UserName = textBox_username.Text;
            this.UserInfo.Name = textBox_name.Text;
            this.UserInfo.IdentifyCardNo = textBox_sfzh.Text.Trim();
            this.UserInfo.Age = textBox_age.Text.Trim() != "" ? Convert.ToInt32(textBox_age.Text.Trim()) : 0;
            this.UserInfo.QQ = textBox_qq.Text.Trim();
            this.UserInfo.Phone = textBox_phone.Text.Trim();
            this.UserInfo.Email = textBox_mail.Text.Trim();
            this.UserInfo.Address = textBox_address.Text.Trim();
            this.UserInfo.Postcode = textBox_code.Text.Trim();
            this.UserInfo.Password = textBox_password.Text.Trim();
            this.UserInfo.Dept = (Department)comboBox_dept.SelectedValue;
            baseService.SaveOrUpdateEntity(this.UserInfo);
            this.DialogResult=DialogResult.OK;
        }
        private void EidtUserInfo_Load(object sender, EventArgs e)
        {
            updateCombox();
            if (entrance == 1)
            {
                textBox_username.Enabled = false;
                textBox_name.Enabled = false;
                //comboBox_dept.Enabled = false;
            }
            else if (entrance == 0)
            {
                textBox_username.Enabled = true;
                textBox_name.Enabled = true;
                return;
            }

            textBox_username.Text = this.UserInfo.UserName;
            textBox_name.Text = this.UserInfo.Name;
            textBox_address.Text = this.UserInfo.Address;
            textBox_age.Text = this.UserInfo.Age.ToString();
            textBox_code.Text = this.UserInfo.Postcode;
            textBox_mail.Text = this.UserInfo.Email;
            textBox_phone.Text = this.UserInfo.Phone;
            textBox_qq.Text = this.UserInfo.QQ;
            textBox_sfzh.Text = this.UserInfo.IdentifyCardNo;
            textBox_password.Text = this.UserInfo.Password;
            textBox_password1.Text = this.UserInfo.Password;
            comboBox_dept.SelectedValue = this.UserInfo.Dept;
            comboBox_dept.Text = this.UserInfo.Dept.DepartmentName;
            textBox_sex.Text = this.UserInfo.Sex;
            textBox_nation.Text = this.UserInfo.Nation;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
