using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CaiGouXiTong.Service;
using EntityClassLibrary;
using System.Text.RegularExpressions;
using CommonMethod;

namespace CaiGouXiTong
{
    public partial class GongHuoShang_New_dialog : Form
    {
        TestInput tt = new TestInput();
        OpSupplierInfo opsupp = new OpSupplierInfo();
        public int IfSaved = 0;
        public GongHuoShang_New_dialog()
        {
            InitializeComponent();
            SetKong();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplierInfo ss = new SupplierInfo();
            ss.SupplierName = this.textBox1.Text;
            ss.SupplierZioCode = this.textBox7.Text;
            ss.SupplierSex = this.comboBox3.Text;
            ss.SupplierAddress = this.textBox2.Text;
            ss.SupplierContactMan = this.textBox10.Text;
            ss.SupplierContactManMail = this.textBox8.Text;
            ss.SupplierPhone = this.textBox3.Text;
            ss.Remark = this.textBox4.Text;
            opsupp.SaveNewSupplier(ss);
            MessageBox.Show("添加成功！");
            this.Close();
            IfSaved = 1;
        }
        public void SetKong()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox8.Text = "";
            this.textBox10.Text = "";
            this.textBox7.Text = "";
            this.textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetKong();
        }

        /// <summary>
        /// 邮编失焦事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox7_Leave(object sender, EventArgs e)
        {
           

            if (!tt.TestZioCode(this.textBox7.Text) || this.textBox7.Text == "")
            {
                MessageBox.Show("请输入正确的邮政编码！");
                this.textBox7.Text = "";
                this.textBox7.Focus();
            }
        }
        /// <summary>
        /// 邮箱验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox8_Leave(object sender, EventArgs e)
        {
            if(!tt.TestEmail(this.textBox8.Text))
            {
                MessageBox.Show("请输入正确的邮箱！");
                this.textBox8.Text = "";
                this.textBox8.Focus();
            }
        }
       /// <summary>
       ///验证手机号码
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!tt.TestPhoneNum(this.textBox3.Text))
            {
                MessageBox.Show("请输入正确的手机号码！");
                this.textBox3.Text = "";
                this.textBox3.Focus();
            }

        }

        private void GongHuoShang_New_dialog_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
