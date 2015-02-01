using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CommonControl
{
    public partial class CommonPictureButton : PictureBox
    {
        public CommonPictureButton()
        {
            InitializeComponent();
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(66, 61);
            
        }

        public CommonPictureButton(IContainer container)
        {
            InitializeComponent();
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
            set { nonSelectBackGroundImage = value; this.BackgroundImage = value; }
        }

        private string toolTipString;

        public string ToolTipString
        {
            get { return toolTipString; }
            set { toolTip1.SetToolTip(this, value); toolTipString = value; }
        }

        private void CommonPictureButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = SelectBackGroundImage;
        }

        private void CommonPictureButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = NonSelectBackGroundImage;
        }
    }
}
