using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonMethod;
using SQLProvider.Service;

namespace XinXiGuanLi
{
    public partial class XinWenGuanLi_add_Dialog : CommonControl.BaseForm
    {
        BaseService baseService = new BaseService();
        private News newNews;

        public News NewNews
        {
            get { return newNews; }
            set { newNews = value; }
        }
        public XinWenGuanLi_add_Dialog()
        {
            InitializeComponent();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_filepath.Text = openFileDialog1.SafeFileName.Substring(0, openFileDialog1.SafeFileName.LastIndexOf('.')) ;
                textBox_filepath.Tag = openFileDialog1.FileName;
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_title.Text.Length > 25)
                {
                    MessageBox.Show("标题字数过多！");
                    textBox_title.Focus();
                }
                News news = new News();
                news.NewsTitle = textBox_title.Text.Trim();
                news.NewsContent = htmlEditor1.BodyInnerHTML;
                news.PublishTime = DateTime.Now.Ticks;
                news.PublishUser = this.UserInfo;
                if (textBox_filepath.Tag != null)
                {
                    news.FileName = textBox_filepath.Text.Trim();
                    CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                    String s = fileUpDown.Upload(textBox_filepath.Tag.ToString(), CommonStaticParameter.NEWS_RSOURCE);
                    news.FilePath = s.Substring(s.LastIndexOf('/') + 1);
                }
                baseService.SaveOrUpdateEntity(news);
                MessageBox.Show("保存成功！");
                newNews = news;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception exc)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(exc);
            }
        }

        private void XinWenGuanLi_add_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
    }
}
