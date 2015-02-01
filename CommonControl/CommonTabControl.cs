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
    public partial class CommonTabControl : UserControl
    {
        private static Bitmap selectImage = CommonControl.Properties.Resources.tabTitle_select4;
        private static Bitmap nonSelectImage = null;
        private List<CommonTabTitle> ExistPageList = new List<CommonTabTitle>();
        private CommonTabTitle firstTitle;
        private CommonTabPage firstPage;
        private CommonTabTitle selectedTitle;
        private CommonTabPage selectedPage;
        public CommonTabControl()
        {
            InitializeComponent();
        }
        public int SelectedIndex
        {
            get { return ExistPageList.IndexOf(selectedTitle); }
            set
            {
                if (ExistPageList.Count <= 0)
                {
                    return;
                }
                CommonTabTitle ctt = ExistPageList[value];
                CommonTabPage ctp = (CommonTabPage)ctt.Tag;
                if (ctt != selectedTitle && ctp != selectedPage)
                {
                    ctt.BackgroundImage = selectImage;
                    if (ctt.Visible == false)
                    {
                        ctp.reFreshAllControl();
                        //ctp.Refresh();
                    }
                    ctt.Visible = true;
                    ctp.Visible = true;
                    ctt.ForeColor = Color.Black;
                    selectedTitle.BackgroundImage = nonSelectImage;
                    selectedPage.Visible = false;
                    selectedTitle.ForeColor = Color.White;
                    selectedTitle = ctt;
                    selectedPage = ctp;
                }
            }
        }
        public void AddTabPage(CommonTabPage ctp)
        {
            panel6.Visible = true;
            for(int i=0;i<ExistPageList.Count;i++)
            {
                if (ctp == (CommonTabPage)ExistPageList[i].Tag)
                {
                    this.SelectedIndex = i;
                    panel6.Visible = false;
                    return;
                }
            }
            CommonTabTitle ctt = new CommonTabTitle();
            ctt.Visible = false;
            ctp.Visible = false;
            #region 创建page和title
            ctt.TitleName = " " + ctp.Name.Trim();
            ctt.Width = 32 + 12 * ctp.Name.Trim().Length;
            ctt.BackgroundImageLayout = ImageLayout.Stretch;
            //ctt.BackgroundImage = selectImage;
            ctt.Tag = ctp;
            if (!flowLayoutPanel.HasChildren)//如果是第一个，初始化为不可删除且宽度和margin不同
            {
                ctt.Margin = new Padding(5, 0, 0, 0);
                ctt.Width = 61;
            }
            ctt.ForeColor = Color.Black;
            ctt.Parent = flowLayoutPanel;
            ctt.tabSelect += new EventHandler(TabTitleClick);
            ctt.tabClose += new EventHandler(pictureBox1_Click);

            ctp.Parent = mainPanel;
            ctp.Dock = DockStyle.Fill;
            #endregion
            if (selectedTitle != null && selectedPage != null)
            {
                selectedTitle.BackgroundImage = nonSelectImage;
                selectedPage.Visible = false;
                selectedTitle.ForeColor = Color.White;
            }
            else
            {
                ctt.Closeable = false;
                ctt.Margin = new Padding(5, 0, 0, 0);
                firstTitle = ctt;
                firstPage = ctp;
            }
            ExistPageList.Add(ctt);
            selectedPage = ctp;
            selectedTitle = ctt;
            ctt.Visible = true;
            ctp.Visible = true;
            panel6.Visible = false;
        }
        private void TabTitleClick(object sender, EventArgs e)
        {
           
            Label label = (Label)sender;
            CommonTabTitle ctt = (CommonTabTitle)label.Parent;
            CommonTabPage ctp = (CommonTabPage)ctt.Tag;
            if (ctt != selectedTitle && ctp != selectedPage)
            {
                ctt.BackgroundImage = selectImage;
                ctp.Visible = true;
                ctt.ForeColor = Color.Black;
                selectedTitle.BackgroundImage = nonSelectImage;
                selectedPage.Visible = false;
                selectedTitle.ForeColor = Color.White;
                selectedTitle = ctt;
                selectedPage = ctp;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            CommonTabTitle ctt = (CommonTabTitle)pic.Parent;
            CommonTabPage ctp = (CommonTabPage)ctt.Tag;
            if (ctt == selectedTitle && ctp == selectedPage)
            {
                selectedPage = firstPage;
                selectedTitle = firstTitle;
                selectedTitle.BackgroundImage = selectImage;
                selectedPage.Visible = true;
                selectedTitle.ForeColor = Color.Black;
            }
            //ExistPageList.Remove(ctt);
            ctp.Visible = false;
            ctt.Visible = false;
            //ctp.Dispose();
            //ctt.Dispose();
        }
    }
}
