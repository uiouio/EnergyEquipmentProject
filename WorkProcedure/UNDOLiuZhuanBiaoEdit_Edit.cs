using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkProcedure
{
    public partial class UNDOLiuZhuanBiaoEdit_Edit : CommonControl.BaseForm
    {
        public string chePaiHao;
        
        public UNDOLiuZhuanBiaoEdit_Edit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("流转表修改成功！");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LiuZhuanBiaoEdit_Edit_Load(object sender, EventArgs e)
        {
            this.textBox车牌号.Text = chePaiHao;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
