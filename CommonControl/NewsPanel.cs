using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Reflection;
using System.Collections;

namespace CommonControl
{
    public partial class NewsPanel : UserControl
    {
        public NewsPanel()
        {
            InitializeComponent();
        }

        public void refresh(IList newsList)
        {
            flowLayoutPanel1.Controls.Clear();
            if (newsList != null && newsList.Count > 0)
            {
                for (int i = 0; i < newsList.Count && i < 6;i++ )
                {
                   addItem((News)newsList[i]);
                }
            }
        }

        public void addItem(News news)
        {
            Panel panel = new Panel();
            panel.Height = 35;
            panel.Width = 400;
            panel.Margin = new Padding(3, 3, 3, 1);
            panel.BackColor = System.Drawing.Color.Transparent;
            panel.Parent = flowLayoutPanel1;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(19, 17);
            pictureBox.BackColor = System.Drawing.Color.Transparent;
            pictureBox.Location = new Point(17, 10);
            pictureBox.BackgroundImage = CommonControl.Properties.Resources.dot;
            pictureBox.Parent = panel;

            LinkLabel linkLabel = new LinkLabel();
            linkLabel.AutoSize = true;
            linkLabel.Location = new Point(36,10);
            linkLabel.BackColor = System.Drawing.Color.Transparent;
            linkLabel.Font = new Font("宋体", (float)10.5);
            linkLabel.Text = news.NewsTitle;
            linkLabel.Tag = news;
            linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);
            linkLabel.Parent = panel;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            if (ll.Tag != null)
            {
                BaseForm ctp = (BaseForm)getAssemblyByReflection("XinXiGuanLi", "XinWenGuanLi_view_Dialog", (News)ll.Tag);
                ctp.ShowDialog();
            }
        }

        private Object getAssemblyByReflection(string assemblyName, string objectName,News news)
        {
            try
            {
                Assembly ass = Assembly.LoadFrom(CommonMethod.CommonStaticParameter.BASE_PATH + assemblyName + ".dll");
                Type type = ass.GetType(assemblyName + "." + objectName);
                Object obj = Activator.CreateInstance(type);
                PropertyInfo propertyInfo_User = type.GetProperty("News");
                propertyInfo_User.SetValue(obj, news, null);
                return obj;
            }
            catch (Exception e)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(e);
                return null;
            }

        }
    }
}
