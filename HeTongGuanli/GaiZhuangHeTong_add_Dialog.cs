using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HeTongGuanLi
{
    public partial class GaiZhuangHeTong_add_Dialog : CommonControl.BaseForm
    {
        public GaiZhuangHeTong_add_Dialog()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Opacity = 0;
                this.Visible = false;
                HeTongPingShen_add_Dialog had = new HeTongPingShen_add_Dialog();
                had.ShowDialog();
                this.Close();
            }
        }

        private void GaiZhuangHeTong_add_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
        }
    }
}
