using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HeTongGuanLi
{
    public partial class WeiXiuHeTong : CommonControl.CommonTabPage
    {
        public WeiXiuHeTong()
        {
            InitializeComponent();
        }

        private void WeiXiuHeTong_Load(object sender, EventArgs e)
        {
            
            DataGridViewRow r = new DataGridViewRow();
            DataGridViewCheckBoxCell c1112 = new DataGridViewCheckBoxCell();
            c1112.Value = true;
            DataGridViewCell c1 = new DataGridViewTextBoxCell();
            c1.Value = "CAZHT2014060000";
            DataGridViewCell c2 = new DataGridViewTextBoxCell();
            c2.Value = "重卡";
            DataGridViewCell c3 = new DataGridViewTextBoxCell();
            c3.Value = "徐玉龙";
            DataGridViewCell c4 = new DataGridViewTextBoxCell();
            c4.Value = "杜少萌";
            DataGridViewCell c5 = new DataGridViewTextBoxCell();
            c5.Value = "123456789";
            DataGridViewCell c6 = new DataGridViewTextBoxCell();
            c6.Value = "2013-06-06";
            DataGridViewCell c7 = new DataGridViewTextBoxCell();
            c7.Value = "待审核";
            DataGridViewCell c8 = new DataGridViewTextBoxCell();
            c8.Value = "分期付款";
            DataGridViewCell c9 = new DataGridViewTextBoxCell();
            c9.Value = "已付三期";
            DataGridViewCell c10 = new DataGridViewLinkCell();
            c10.Value = "查看";
            DataGridViewCell c11 = new DataGridViewLinkCell();
            c11.Value = "删除";
            DataGridViewCell c12 = new DataGridViewTextBoxCell();
            c12.Value = "1";
           
            r.Cells.Add(c1112);
            r.Cells.Add(c12);
            r.Cells.Add(c1);
            r.Cells.Add(c2);
            r.Cells.Add(c3);
            r.Cells.Add(c4);
            r.Cells.Add(c5);
            r.Cells.Add(c6);
            r.Cells.Add(c7);
            r.Cells.Add(c8);
            r.Cells.Add(c9);
            r.Cells.Add(c10);
            r.Cells.Add(c11);
            commonDataGridView.Rows.Add(r);
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            GaiZhuangHeTong_add_Dialog gad = new GaiZhuangHeTong_add_Dialog();
            gad.ShowDialog();
        }
    }
}
