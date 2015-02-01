using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using JianJian.SQL;
using System.Windows.Forms;

namespace JianJian
{
    public partial class JianJian_JieGuo1 : Form
    {
        public long carId;
        EntityClassLibrary.Car cc;
        OP_JianJian OP_JianJian = new OP_JianJian();
        public int pass;
        public JianJian_JieGuo1()
        {
            InitializeComponent();
        }

        JianJian_JieGuo1 jianJian_JieGuo1;
        /// <summary>
        /// 监检结果数据传输
        /// </summary>
        public JianJian_JieGuo1 JianJian_JieGuo11
        {
            get { return jianJian_JieGuo1; }
            set { jianJian_JieGuo1 = value; }
        }
        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cc.Pass = 1;
                OP_JianJian.SaveOrUpdateEntity(cc);
            }
            else if (radioButton2.Checked == true)
            {
                cc.Pass = -1;
                cc.Remarks = this.textBox1.Text;
                OP_JianJian.SaveOrUpdateEntity(cc);
            }
            else
            {
                MessageBox.Show("请填写结果"); 
            }
            pass = cc.Pass;
            this.Close();

        }

        private void JianJian_JieGuo1_Load(object sender, EventArgs e)
        {
            cc = (EntityClassLibrary.Car)(OP_JianJian.GetFlag(carId)[0]);
            if (cc.Pass == 1)
            {
                button1.Enabled = false;
                this.panel1.Enabled = false;
            }
        }
    }
}
