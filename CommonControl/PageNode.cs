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
    public partial class PageNode : UserControl
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
        public EventHandler OnControlClick
        {
            get { return null; }
            set { pictureBox1.Click += value; }
        }
        private Bitmap selectBackGroundImage;

        public Bitmap SelectBackGroundImage
        {
            get { return selectBackGroundImage; }
            set { selectBackGroundImage = value; }
        }
        private Bitmap nonSelectBackGroundImage;

        public Bitmap NonSelectBackGroundImage
        {
            get { return nonSelectBackGroundImage; }
            set { pictureBox1.BackgroundImage = value; nonSelectBackGroundImage = value; }
        }
        private bool allowClick;

        public bool AllowClick
        {
            get { return allowClick; }
            set { pictureBox1.Enabled = value; allowClick = value; }
        }
        public PageNode()
        {
            InitializeComponent();
        }

        private void TitleNode_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = CommonControl.Properties.Resources.kuang;
        }

        private void TitleNode_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
