using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonControl
{
    public partial class DaiBanShiXiang_Main_Dialog : BaseForm
    {
        public DaiBanShiXiang_Main_Dialog()
        {
            InitializeComponent();
        }

        private void DaiBanShiXiang_Main_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
    }
}
