using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CustomManageWindow.Service;
namespace CustomManageWindow
{
    public partial class JingXiaoShangGuanLi_Add_dialog : CommonControl.BaseForm
    {
        public int isSaved = 0;
        public JingXiaoShangGuanLi_Add_dialog()
        {
            InitializeComponent();
        }

        private void JingXiaoShangGuanLi_Add_dialog_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agent aa = new Agent();
            CustomService ss = new CustomService();
            if (textBox2.Text == "")
                textBox2.Text = "0";
            aa.AgentName = textBox1.Text;
            aa.Category = comboBox1.Text;
            aa.AcceptTime =dateTimePicker1.Value.Ticks;
            aa.AgentAera = comboBox2.Text;
            aa.AgentMoney = textBox6.Text;
            aa.AgentContent = textBox9.Text;
            aa.AgentDeadline = dateTimePicker3.Value.Ticks;
            aa.ContactName = textBox10.Text;
            aa.PersonSex = comboBox3.Text;
            aa.ContactPhone = textBox3.Text;
            aa.ContactEmail = textBox8.Text;
            aa.ContactPostCode = textBox7.Text;
            aa.ContactAddress = textBox4.Text;
            aa.DeliveryAddress = textBox5.Text;
            aa.MinimumSale =int.Parse(textBox2.Text);

            #region 判断客户级别
            if (radioButton1.Checked)
            {
                aa.AgentLevel = radioButton1.Text;

            }
            else if (radioButton2.Checked)
            {
                aa.AgentLevel = radioButton2.Text;
            }
            else if (radioButton5.Checked)
            {
                aa.AgentLevel = radioButton5.Text;
            }
            else if (radioButton6.Checked)
            {
                aa.AgentLevel = radioButton6.Text;
            }
            else if (radioButton7.Checked)
            {
                aa.AgentLevel = radioButton7.Text;
            }
            #endregion

            if(this.textBox1.Text=="")
            {
                MessageBox.Show("请输入必填信息");
            }
            ss.SaveOrUpdateEntity(aa);
            isSaved = 1;
            MessageBox.Show("保存成功");
            this.Close();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
