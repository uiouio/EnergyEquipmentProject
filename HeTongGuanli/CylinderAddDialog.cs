using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using HeTongGuanLi.Service;
using Iesi.Collections.Generic;
using System.Collections;
namespace HeTongGuanLi
{
    public partial class CylinderAddDialog : CommonControl.BaseForm
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
        CylinderInfo c = new CylinderInfo();
        ContractService cs = new ContractService();
        private CylinderInfo cylinderInfo;

        public CylinderInfo CylinderInfo
        {
            get { return cylinderInfo; }
            set { cylinderInfo = value; }
        }
        public CylinderAddDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.isShowOrInput==1)
            {
               c.CylinderType = this.comboBox1.Text;
               c.CylinderNumber =Convert.ToInt16( this.textBox2.Text);
               c.CylinderValue = Convert.ToInt32(this.textBox1.Text);
               cs.SaveOrUpdateEntity(c);
               MessageBox.Show("保存成功!");
               this.DialogResult = DialogResult.OK;
            }
            else if(this.isShowOrInput==0)
            {
                CylinderInfo.CylinderValue =Convert.ToInt16(this.textBox1.Text);
                cs.SaveOrUpdateEntity(CylinderInfo);
                MessageBox.Show("修改成功!");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CylinderAddDialog_Load(object sender, EventArgs e)
        {
            if(IsShowOrInput==1)
            {
                
                this.comboBox1.Enabled = true;
                this.textBox2.Enabled = true;
                this.textBox1.Enabled = true;
            }
            else if (IsShowOrInput == 0)
            {
                this.Text = "编辑气瓶价格";
                this.comboBox1.Enabled = false;
                this.textBox2.Enabled = false;
                this.comboBox1.Text = CylinderInfo.CylinderType;
                this.textBox2.Text = CylinderInfo.CylinderNumber.ToString();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            IList cbList = cs.loadEntityList("from CylinderInfo where CylinderType='" + this.comboBox1.Text + "'and CylinderNumber='" + this.textBox2.Text + "'");
            if (cbList != null && cbList.Count == 1)
            {
                MessageBox.Show("已经存在相同型号 相等数量气瓶信息，请重新输入");
                this.comboBox1.Text = "";
                this.textBox2.Text = "";
                this.comboBox1.Focus();
            }
        }
    }
}
