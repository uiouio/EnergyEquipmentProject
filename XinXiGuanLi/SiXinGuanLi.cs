using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using EntityClassLibrary;

namespace XinXiGuanLi
{
    public partial class SiXinGuanLi : CommonControl.CommonTabPage
    {
        Service.LetterService letterService = new Service.LetterService();
        public SiXinGuanLi()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            SiXinGuanLi_add_Dialog sad = new SiXinGuanLi_add_Dialog();
            sad.UserInfo = this.User;
            if (sad.ShowDialog() == DialogResult.OK)
            {
                Regex r = new Regex("<[^<]*>");
                MatchCollection mc = r.Matches(sad.Letter.LetterContent.ToString());
                String contentText = sad.Letter.LetterContent.ToString().Replace("&nbsp;", " ");
                for (int j = 0; j < mc.Count; j++)
                {
                    contentText = contentText.Replace(mc[j].Value, "");
                }
                DateTime publishTime = new DateTime(sad.Letter.SenderTime);
                commonDataGridView1.Rows.Add(commonDataGridView1.Rows.Count + 1, sad.Letter.LetterTitle, contentText, publishTime.ToShortDateString(),"查看", "查看内容", "删除");
                commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = sad.Letter;
            }
        }

        public override void reFreshAllControl()
        {
            commonDataGridView1.Rows.Clear();
            IList newsList = letterService.getLetterByPublishUserAndTime(this.User.Id, 0, 999999999999999999);
            initDataGridView(newsList);
        }

        private void initDataGridView(IList newsList)
        {
            if (newsList != null && newsList.Count > 0)
            {
                for (int i = 0; i < newsList.Count; i++)
                {
                    Letter letter = (Letter)newsList[i];
                    Regex r = new Regex("<[^<]*>");
                    MatchCollection mc = r.Matches(letter.LetterContent.ToString());
                    String contentText = letter.LetterContent.ToString().Replace("&nbsp;", " ");
                    for (int j = 0; j < mc.Count; j++)
                    {
                        contentText = contentText.Replace(mc[j].Value, "");
                    }
                    DateTime publishTime = new DateTime(letter.SenderTime);
                    commonDataGridView1.Rows.Add(commonDataGridView1.Rows.Count + 1, letter.LetterTitle, contentText, publishTime.ToShortDateString(), "查看", "查看内容", "删除");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = letter;
                }
            }
        }

        private void SiXinGuanLi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            commonDataGridView1.Rows.Clear();
            IList newsList = letterService.getLetterByPublishUserAndTime(this.User.Id, dateTimePicker1.Value.Date.Ticks, dateTimePicker2.Value.Date.Ticks + new DateTime(1, 1, 2).Date.Ticks);
            initDataGridView(newsList);
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Letter currentLetter = (Letter)commonDataGridView1.Rows[e.RowIndex].Tag;
            if (e.ColumnIndex == 5)
            {
                SiXinGuanLi_view_Dialog svd = new SiXinGuanLi_view_Dialog();
                svd.Letter = currentLetter;
                svd.ShowDialog();
            }
            else if (e.ColumnIndex == 6)
            {
                try
                {
                    letterService.deleteEntity(currentLetter);
                    MessageBox.Show("删除成功！");
                    reFreshAllControl();
                }
                catch (Exception exc)
                {
                    SQLProvider.Service.CommonService.saveExceptionEntity(exc);
                    return;
                }
            }
            else if (e.ColumnIndex == 4)
            {
                SiXinGuanLi_viewUser_Dialog svd = new SiXinGuanLi_viewUser_Dialog();
                svd.SelectedUser = (IList)currentLetter.Users;
                svd.ShowDialog();
            }
        }
    }
}
