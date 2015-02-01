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
    public partial class ZiLiaoShenCha_LNGEdit : CommonControl.BaseForm
    {
        public string gaiZhuangBianHao;
        public string chePaiHao;
        
        public ZiLiaoShenCha_LNGEdit()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("修改成功！");
        }

        private void ZiLiaoShenCha_LNGEdit_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            textBox1.Text = gaiZhuangBianHao;
            textBox2.Text = chePaiHao;
        }
    }
}
