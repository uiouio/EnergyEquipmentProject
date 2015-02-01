using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow.Service;
namespace CustomManageWindow
{
    public partial class PersonalCustomInfo_add_Dialog1 : Form
    {
        /// <summary>
        /// 是用来展示数据还是输入数据，1用来输入数据，0用来展示数据
        /// </summary>
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
        IList<CarBaseInfo> car = new List<CarBaseInfo>();
        public int IfSaved = 0;
        public PersonalCustomInfo_add_Dialog1()
        {
            InitializeComponent();
        }
        public PersonalCustomInfo_add_Dialog1(string headtextname)
        {
          
            this.Text = headtextname;
            InitializeComponent();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            CustomService ss = new CustomService();

            CustomBaseInfo cb = new CustomBaseInfo();

            cb.Name = textBox1.Text;

            cb.Sex = comboBox1.Text;

            cb.IdentifyCardNo = textBox3.Text;

            cb.Phone = textBox6.Text;

            cb.Telephone = textBox5.Text;

            cb.QQ = textBox8.Text;

            cb.Email = textBox7.Text;

            cb.Address = textBox9.Text;

            cb.Remarks = textBox17.Text;

            cb.Status = (int)CustomBaseInfo.PersonalOrCompany.Personal;

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
        private void textBox3_Leave(object sender, EventArgs e)
        {

            CustomService ss = new CustomService();
            IList cbList = ss.loadEntityList("from CustomBaseInfo where IdentifyCardNo='" + textBox3.Text + "'");


            if (cbList != null && cbList.Count == 1)
            {

                MessageBox.Show("客户已经存在，请添加新客户");
                textBox3.Text = "";
                textBox3.Focus();

            }
        }

        private void PersonalCustomInfo_add_Dialog1_Load(object sender, EventArgs e)
        {
            if (IsShowOrInput == 0)
            {
                this.Text = "个人详细信息";
                if (customBaseInfo != null)
                {
                    this.textBox1.Enabled = false;
                    this.comboBox1.Enabled = false;
                    this.textBox3.Enabled = false;
                    this.textBox6.Enabled = false;
                    this.textBox5.Enabled = false;
                    this.textBox8.Enabled = false;
                    this.textBox7.Enabled = false;
                    this.textBox9.Enabled = false;
                    this.textBox17.Enabled = false;
                    this.textBox1.Text = CustomBaseInfo.Name;
                    this.comboBox1.SelectedText = CustomBaseInfo.Sex;
                    this.textBox3.Text = CustomBaseInfo.IdentifyCardNo;
                    this.textBox6.Text = CustomBaseInfo.Phone;
                    this.textBox5.Text = CustomBaseInfo.Telephone;
                    this.textBox8.Text = CustomBaseInfo.QQ;
                    this.textBox7.Text = CustomBaseInfo.Email;
                    this.textBox9.Text = CustomBaseInfo.Address;
                    this.textBox17.Text = CustomBaseInfo.Remarks;
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
                    this.panel1.Enabled = false;

                }
            }
            if (IsShowOrInput == 1)
            {
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            }
        }
    }
}
