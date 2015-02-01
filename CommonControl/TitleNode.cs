using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;

namespace CommonControl
{
    public partial class TitleNode : UserControl
    {
        private Resource pResource;

        public Resource PResource
        {
            get { return pResource; }
            set { pResource = value; }
        }
        public string NodeText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public Bitmap NodePic
        {
            get { return (Bitmap)pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public EventHandler OnControlClick
        {
            get { return null; }
            set { this.Click += value; label1.Click += value; pictureBox1.Click += value; }
        }

        public TitleNode()
        {
            InitializeComponent();
        }

        private void TitleNode_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = CommonControl.Properties.Resources._2;
        }

        private void TitleNode_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = CommonControl.Properties.Resources._1;
        }

    }
}
