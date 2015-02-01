using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YanChe
{
    public partial class YanChe : CommonControl.CommonTabPage
    {
        public YanChe()
        {
            InitializeComponent();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void commonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YanChe_GaiZhuangDan tt = new YanChe_GaiZhuangDan();
            tt.ShowDialog();
        }

        private void YanChe_Load(object sender, EventArgs e)
        {
            commonDataGridView1.Rows.Add(0,"1", "小轿车", "0000000001", "000000001","冀F3423", "2014.6.22", "未验车", "编辑","删除");
            commonDataGridView1.Rows.Add(0,"2", "小轿车", "0000000002", "000000002", "冀F3563", "2014.6.22", "验车完成", "编辑", "删除");
            commonDataGridView1.Rows.Add(0,"3", "重卡", "0000000003", "000000003", "冀F2223", "2014.6.22", "未验车", "编辑", "删除");
            commonDataGridView1.Rows.Add(0,"4", "重卡", "0000000004", "000000004", "冀F8866", "2014.6.22", "正在验车", "编辑", "删除");

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            YanChe_GaiZhuangDan tt = new YanChe_GaiZhuangDan();
            tt.ShowDialog();
        }
    }
}