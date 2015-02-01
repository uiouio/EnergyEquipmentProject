using System;
using System.Drawing;
using System.Windows.Forms;
using EntityClassLibrary;
using CustomManageWindow.Service;
using Iesi.Collections.Generic;
namespace CustomManageWindow
{
    public partial class CompanyCustomInfo_add_Dialog1 : Form
    {

        private int isShowOrInput;
        public int IsShowOrInput
        {
            get { return isShowOrInput; }
            set { isShowOrInput = value; }
        }
        private CustomBaseInfo customBaseInfo;

        public CustomBaseInfo CustomBaseInfo
        {
            get { return customBaseInfo; }
            set { customBaseInfo = value; }
        }
        ISet<CarBaseInfo> car = new HashedSet<CarBaseInfo>();
        public int IfSaved = 0;
        public CompanyCustomInfo_add_Dialog1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomService ss = new CustomService();
            CustomBaseInfo cb = new CustomBaseInfo();
            cb.Name = textBox2.Text;
            cb.ContactName = textBox19.Text;
            cb.IdentifyCardNo = textBox16.Text;
            cb.Address = textBox14.Text;
            cb.Phone = textBox13.Text;
            cb.ComanySize = comboBox5.Text;
            cb.ComanyProperty = comboBox2.Text;

            #region 判断客户级别
            if (radioButton1.Checked)
            {
                cb.CustomLevel = radioButton1.Text;

            }
            else if (radioButton2.Checked)
            {
                cb.CustomLevel = radioButton2.Text;
            }
            else if (radioButton5.Checked)
            {
                cb.CustomLevel = radioButton5.Text;
            }
            else if (radioButton6.Checked)
            {
                cb.CustomLevel = radioButton6.Text;
            }
            else if (radioButton7.Checked)
            {
                cb.CustomLevel = radioButton7.Text;
            }
            #endregion
            cb.Status = (int)CustomBaseInfo.PersonalOrCompany.Company;
            cb.CarInfo = car;
            ss.SaveOrUpdateEntity(cb);
            customBaseInfo = cb;
            if (IsShowOrInput == 1)
            {
                MessageBox.Show("添加成功");
            }
            else if (IsShowOrInput == 0)
            {
                this.Close();
            }
            this.DialogResult = DialogResult.OK;
            
        }

        private void CompanyCustomInfo_add_Dialog1_Load(object sender, EventArgs e)
        {
            if (IsShowOrInput == 0)
            {
                this.Text = "企业详细信息";
                if (customBaseInfo != null)
                {
                    this.textBox2.Enabled = false;
                    this.textBox19.Enabled = false;
                    this.textBox16.Enabled = false;
                    this.textBox14.Enabled = false;
                    this.textBox13.Enabled = false;
                    this.comboBox5.Enabled = false;
                    this.comboBox2.Enabled = false;
                    this.textBox2.Text = CustomBaseInfo.Name;
                    this.textBox19.Text = CustomBaseInfo.ContactName;
                    this.textBox16.Text = CustomBaseInfo.IdentifyCardNo;
                    this.textBox14.Text = CustomBaseInfo.Address;
                    this.textBox13.Text = CustomBaseInfo.Phone;
                    this.comboBox5.Text = CustomBaseInfo.ComanySize;
                    this.comboBox2.Text = CustomBaseInfo.ComanyProperty;
                    #region 判断用户级别
                    if (CustomBaseInfo.CustomLevel == "1颗星")
                    {
                        this.radioButton1.Checked = true;
                    }
                    else if (CustomBaseInfo.CustomLevel == "2颗星")
                    {
                        this.radioButton2.Checked = true;
                    }
                    else if (CustomBaseInfo.CustomLevel == "3颗星")
                    {
                        this.radioButton5.Checked = true;
                    }
                    else if (CustomBaseInfo.CustomLevel == "4颗星")
                    {
                        this.radioButton6.Checked = true;
                    }
                    else if (CustomBaseInfo.CustomLevel == "5颗星")
                    {
                        this.radioButton7.Checked = true;
                    }
                    #endregion


                }
            }
            if (IsShowOrInput == 1)
            {
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            }
        }
    }
}
