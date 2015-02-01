using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonControl
{
    public partial class CommonTabTitle : UserControl
    {
        public String TitleName
        {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        public EventHandler tabSelect
        {
            get { return null; }
            set { label.Click += value; }
        }

        public EventHandler tabClose
        {
            get { return null; }
            set { pictureBox1.Click += value; }
        }

        public bool Closeable
        {
            get { return pictureBox1.Visible; }
            set { pictureBox1.Visible = value; }
        }

        public CommonTabTitle()
        {
            InitializeComponent();
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            if (this.ForeColor == Color.Black)
            {
                return;
            }
            this.BackgroundImage = CommonControl.Properties.Resources.tabTitle_hover3;
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            if (this.ForeColor == Color.Black)
            {
                return;
            }
            this.BackgroundImage = null;
        }
    }
}
