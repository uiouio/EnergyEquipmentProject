using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using System.Text.RegularExpressions;

namespace XinXiGuanLi
{
    public partial class XinWenGuanLi : CommonControl.CommonTabPage
    {
        Service.NewsService newsService = new Service.NewsService();
        public XinWenGuanLi()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            commonDataGridView1.Rows.Clear();
            IList newsList = newsService.getNewsByPublishUserAndTime(textBox1.Text.Trim(),0,999999999999999999);
            initDataGridView(newsList);
        }

        private void initDataGridView(IList newsList)
        {
            if (newsList != null && newsList.Count > 0)
            {
                for (int i = 0; i < newsList.Count; i++)
                {
                    News news = (News)newsList[i];
                    Regex r = new Regex("<[^<]*>");
                    MatchCollection mc = r.Matches(news.NewsContent.ToString());
                    String contentText = news.NewsContent.ToString().Replace("&nbsp;", " ");
                    for (int j = 0; j < mc.Count; j++)
                    {
                        contentText = contentText.Replace(mc[j].Value, "");
                    }
                    DateTime publishTime = new DateTime(news.PublishTime);
                    commonDataGridView1.Rows.Add(i+1, contentText, publishTime.ToShortDateString(), news.PublishUser.Name, "查看","删除");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = newsList[i];
                }
            }
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            XinWenGuanLi_add_Dialog xad = new XinWenGuanLi_add_Dialog();
            xad.UserInfo = this.User;
            if (xad.ShowDialog() == DialogResult.OK)
            {
                Regex r = new Regex("<[^<]*>");
                MatchCollection mc = r.Matches(xad.NewNews.NewsContent.ToString());
                String contentText = xad.NewNews.NewsContent.ToString().Replace("&nbsp;", " ");
                for (int j = 0; j < mc.Count; j++)
                {
                    contentText = contentText.Replace(mc[j].Value, "");
                }
                DateTime publishTime = new DateTime(xad.NewNews.PublishTime);
                commonDataGridView1.Rows.Add(commonDataGridView1.Rows.Count + 1, contentText, publishTime.ToShortDateString(), xad.NewNews.PublishUser.Name, "查看","删除");
                commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = xad.NewNews;
            }
        }

        private void XinWenGuanLi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            commonDataGridView1.Rows.Clear();
            IList newsList = newsService.getNewsByPublishUserAndTime(textBox1.Text.Trim(), dateTimePicker1.Value.Date.Ticks, dateTimePicker2.Value.Date.Ticks+new DateTime(1,1,2).Date.Ticks);
            initDataGridView(newsList);
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                XinWenGuanLi_view_Dialog xvd = new XinWenGuanLi_view_Dialog();
                xvd.News = (News)commonDataGridView1.Rows[e.RowIndex].Tag;
                xvd.ShowDialog();
            }
            else if (e.ColumnIndex == 5)
            {
                try
                {
                    News currentNews = (News)commonDataGridView1.Rows[e.RowIndex].Tag;
                    newsService.deleteEntity(currentNews);
                    MessageBox.Show("删除成功！");
                    reFreshAllControl();
                }
                catch (Exception exc)
                {
                    SQLProvider.Service.CommonService.saveExceptionEntity(exc);
                    return;
                }
            }
        }
    }
}
