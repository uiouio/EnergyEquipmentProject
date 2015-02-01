using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControl;

namespace HeTongGuanLi
{
    public partial class MuBanGuanLi_add_Dialog : CommonControl.BaseForm
    {
        public MuBanGuanLi_add_Dialog()
        {
            InitializeComponent();
        }

        private void MuBanGuanLi_add_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            if (Screen.PrimaryScreen.WorkingArea.Width < 800)
                this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6); ;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            addDataGridViewRow("乙方", "合同的乙方名称");
            addDataGridViewRow("车牌号", "合同要改装车的车牌号");
            addDataGridViewRow("车型", "合同要改装车的车型");
            addDataGridViewRow("气瓶类型", "CNG/LNG/...");
            addDataGridViewRow("气瓶型号", "气瓶具体型号");
            addDataGridViewRow("气瓶压力", "气瓶的压力");
            addDataGridViewRow("气瓶容积", "气瓶的容积");
            addDataGridViewRow("气瓶重量", "气瓶的重量");
        }

        private void addDataGridViewRow(string value1, string value2)
        {
            DataGridViewRow r = new DataGridViewRow();
            DataGridViewCell c1 = new DataGridViewTextBoxCell();
            c1.Value = value1;
            DataGridViewCell c2 = new DataGridViewTextBoxCell();
            c2.Value = value2;
            DataGridViewCell c3 = new DataGridViewLinkCell();
            c3.Value = "添加为文本框";
            DataGridViewCell c4 = new DataGridViewLinkCell();
            c4.Value = "添加为选择框";
            r.Cells.Add(c1);
            r.Cells.Add(c2);
            r.Cells.Add(c3);
            r.Cells.Add(c4);
            commonDataGridView1.Rows.Add(r);
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView c = (CommonDataGridView)sender;
            if (e.ColumnIndex == 2)
            {
                htmlEditor1.BodyInnerHTML += "<input value=\""+c[0,e.RowIndex].Value+"\"/>";
            }
            else if (e.ColumnIndex == 3)
            {
                htmlEditor1.BodyInnerHTML += "<SELECT style=\"WIDTH: 122px\"><OPTION selected>请选择</OPTION></SELECT>";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            htmlEditor1.BodyInnerHTML += "<input/>";
        }
    }
}
