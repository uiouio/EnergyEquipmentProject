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
    public partial class UNDOZiLiaoShenCha_ChaiYouCNGChaKan : Form
    {
        public UNDOZiLiaoShenCha_ChaiYouCNGChaKan()
        {
            InitializeComponent();
        }

        private void ZiLiaoShenCha_ChaiYouCNGChaKan_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            if (Screen.PrimaryScreen.WorkingArea.Width < 800)
                this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6); 
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
