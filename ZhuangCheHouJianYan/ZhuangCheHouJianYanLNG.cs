using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZhuangCheHouJianYan
{
    public partial class ZhuangCheHouJianYanLNG : CommonControl.CommonTabPage
    {
        public ZhuangCheHouJianYanLNG()
        {
            InitializeComponent();
        }

        private void ZhuangCheHouJianYanLNG_Load(object sender, EventArgs e)
        {
            ZhuangCheHouLNGDataGridView1.Rows.Add(0,"1", "000000001", "0000001", "冀B8654", "2014.6.20", "2014.6.22", "正在验车", "编辑");
            ZhuangCheHouLNGDataGridView1.Rows.Add(0,"2", "000000002", "0000002", "冀B8888", "2014.6.20", "2014.6.22", "正在改装","编辑");
            ZhuangCheHouLNGDataGridView1.Rows.Add(0,"3", "000000003", "0000003", "冀B8364", "2014.6.20", "2014.6.22", "正在改装","编辑");
            ZhuangCheHouLNGDataGridView1.Rows.Add(0,"4", "000000004", "0000004", "冀B8774", "2014.6.20", "2014.6.22", "正在验车","编辑");
        }

        private void ZhuangCheHouLNGDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ZhuangCheHouLNGDataGridView1.CurrentCell.Value.ToString() == "编辑")
            {
                ZhuangCheHouJianYan_LNG tt = new ZhuangCheHouJianYan_LNG();
                tt.ShowDialog();
            }
        }

       
    }
}
