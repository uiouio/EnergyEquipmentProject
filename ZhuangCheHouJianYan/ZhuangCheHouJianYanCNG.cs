using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZhuangCheHouJianYan
{
    public partial class ZhuangCheHouJianYanCNG : CommonControl.CommonTabPage
    {
        public ZhuangCheHouJianYanCNG()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ZhuangCheHouJianYan_Load(object sender, EventArgs e)
        {
            ZhuangCheHouCNGDataGridView1.Rows.Add(0,"1", "000000001", "0000001", "冀B8654", "2014.6.20", "2014.6.22", "正在验车", "编辑");
            ZhuangCheHouCNGDataGridView1.Rows.Add(0,"2", "000000002", "0000002", "冀B8888", "2014.6.20", "2014.6.22", "正在改装", "编辑");
            ZhuangCheHouCNGDataGridView1.Rows.Add(0,"3", "000000003", "0000003", "冀B8364", "2014.6.20", "2014.6.22", "正在改装", "编辑");
            ZhuangCheHouCNGDataGridView1.Rows.Add(0,"4", "000000004", "0000004", "冀B8774", "2014.6.20", "2014.6.22", "正在验车", "编辑");
        }

        private void commonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ZhuangCheHouCNGDataGridView1.CurrentCell.Value.ToString() == "编辑")
            {
                ZhuangCheHouJianYan_CNG_1 tt = new ZhuangCheHouJianYan_CNG_1();
                tt.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
