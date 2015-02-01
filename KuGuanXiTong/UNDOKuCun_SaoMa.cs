using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KuGuanXiTong
{
    public partial class UNDOKuCun_SaoMa : Form
    {
        private string theText;

        public string TheText
        {
            get { return theText; }
            set { theText = value; }
        }

        public UNDOKuCun_SaoMa()
        {
            InitializeComponent();
            TheText = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.TheText = this.textBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TheText = "";
            this.Close();
        }
    }
}
