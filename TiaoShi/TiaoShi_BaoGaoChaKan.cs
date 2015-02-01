using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TiaoShi
{
    public partial class TiaoShi_BaoGaoChaKan : Form
    {
        public TiaoShi_BaoGaoChaKan()
        {
            InitializeComponent();
        }

        private void TiaoShi_BaoGaoChaKan_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width < 800)
                this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6);
        }

       
    }
}
