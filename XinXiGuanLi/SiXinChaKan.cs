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
    public partial class SiXinChaKan : CommonControl.CommonTabPage
    {
        Service.LetterService letterService = new Service.LetterService();
        public SiXinChaKan()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            commonDataGridView1.Rows.Clear();
            IList newsList = letterService.getLetterByPublishUserNameAndTime(textBox1.Text.Trim(), 0, 999999999999999999);
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
                    if(letter.LetterContent == null)
                    {
                        letter.LetterContent = " ";
                    }
                    MatchCollection mc = r.Matches(letter.LetterContent.ToString());
                    String contentText = letter.LetterContent.ToString().Replace("&nbsp;", " ");
                    for (int j = 0; j < mc.Count; j++)
                    {
                        contentText = contentText.Replace(mc[j].Value, "");
                    }
                    DateTime publishTime = new DateTime(letter.SenderTime);
                    commonDataGridView1.Rows.Add(commonDataGridView1.Rows.Count + 1, letter.LetterTitle, contentText, publishTime.ToShortDateString(), letter.SenderUser.Name, "查看");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = letter;
                }
            }
        }

        private void SiXinChaKan_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            commonDataGridView1.Rows.Clear();
            IList newsList = letterService.getLetterByPublishUserNameAndTime(textBox1.Text.Trim(), dateTimePicker1.Value.Date.Ticks, dateTimePicker2.Value.Date.Ticks + new DateTime(1, 1, 2).Date.Ticks);
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
        }
    }
}
