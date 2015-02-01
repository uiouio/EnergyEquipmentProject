using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HeTongGuanLi
{
    public partial class WeiXiuHeTong_add_Dialog : CommonControl.BaseForm
    {
        public WeiXiuHeTong_add_Dialog()
        {
            InitializeComponent();
        }

        private void WeiXiuHeTong_add_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
        }
    }
}
