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
using System.Collections;
namespace CustomManageWindow
{
    public partial class CompanyCustomInfo_add_Dialog2 : CommonControl.BaseForm
    {
        public int i = 0;

        IList<CarBaseInfo> currentcars;

        public CustomBaseInfo currentcustom;

        public CustomBaseInfo Currentcustom
        {
            get { return currentcustom; }
            set { currentcustom = value; }
        }

        CustomService ss = new CustomService();

        public CompanyCustomInfo_add_Dialog2()
        {
            InitializeComponent();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Currentcustom.Address = textBox14.Text;

            Currentcustom.ComanySize = comboBox5.Text;

            Currentcustom.Phone = textBox13.Text;

            Currentcustom.ComanyProperty = comboBox2.Text;

           
            #region 判断客户级别
            if (radioButton1.Checked)
            {
                Currentcustom.CustomLevel = "1颗星";
            }
            else if (radioButton2.Checked)
            {
                Currentcustom.CustomLevel = "2颗星";
            }
            else if (radioButton5.Checked)
            {
                Currentcustom.CustomLevel = "3颗星";
            }
            else if (radioButton6.Checked)
            {
                Currentcustom.CustomLevel = "4颗星";
            }
            else if (radioButton7.Checked)
            {
                Currentcustom.CustomLevel = "5颗星";
            }
            #endregion

            Currentcustom.Remarks = this.textBox18.Text;

            ss.Save(Currentcustom);
            MessageBox.Show("保存成功");
            this.DialogResult = DialogResult.OK;
            this.Close();
 
        }

        private void CompanyCustomInfo_add_Dialog2_Load_1(object sender, EventArgs e)
        {
                                 
            this.textBox2.Enabled = false;

            this.textBox2.Text = Currentcustom.Name;

            this.textBox19.Enabled = false;

            this.textBox19.Text = Currentcustom.ContactName;

            this.textBox16.Enabled = false;

            this.textBox16.Text = Currentcustom.IdentifyCardNo;

            this.textBox14.Text = Currentcustom.Address;

            this.comboBox5.Text = Currentcustom.ComanySize;

            this.textBox13.Text = Currentcustom.Phone;

            this.comboBox2.Text = Currentcustom.ComanyProperty;

            this.textBox18.Text = Currentcustom.Remarks;

            #region 判断客户级别
            if (Currentcustom.CustomLevel == "1颗星")
            {
                this.radioButton1.Checked = true;
            }
            else if (Currentcustom.CustomLevel == "2颗星")
            {
                this.radioButton2.Checked = true;
            }
            else if (Currentcustom.CustomLevel == "3颗星")
            {
                this.radioButton5.Checked = true;
            }
            else if (Currentcustom.CustomLevel == "4颗星")
            {
                this.radioButton6.Checked = true;
            }
            else if (Currentcustom.CustomLevel == "5颗星")
            {
                this.radioButton7.Checked = true;
            }
            #endregion
            
        }

       
    }
}
