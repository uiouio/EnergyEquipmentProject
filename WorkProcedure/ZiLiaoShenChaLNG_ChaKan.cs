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
    public partial class ZiLiaoShenChaLNG_ChaKan : Form
    {
        public ZiLiaoShenChaLNG_ChaKan()
        {
            InitializeComponent();
        }

        private void ZiLiaoShenChaLNG_ChaKan_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
    }
}
