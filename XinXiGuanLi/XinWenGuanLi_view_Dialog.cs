using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonMethod;

namespace XinXiGuanLi
{
    public partial class XinWenGuanLi_view_Dialog : CommonControl.BaseForm
    {
        private News news;

        public News News
        {
            get { return news; }
            set { news = value; }
        }
        public XinWenGuanLi_view_Dialog()
        {
            InitializeComponent();
        }

        private void XinWenGuanLi_view_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Text = "查看新闻-" + news.NewsTitle;
            this.htmlEditor1.BodyInnerHTML = news.NewsContent;
            this.linkLabel1.Text = news.FileName;
            this.label_name.Text = news.PublishUser.UserName;
            this.label_time.Text = new DateTime(news.PublishTime).ToShortDateString();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                fileUpDown.Download(folderBrowserDialog1.SelectedPath, news.FilePath, CommonStaticParameter.NEWS_RSOURCE);
            }
        }
    }
}
