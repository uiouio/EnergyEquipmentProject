using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkProcedure
{
    public partial class UNDOZiLiaoShenChaLNG : CommonControl.CommonTabPage
    {
        public UNDOZiLiaoShenChaLNG()
        {
            InitializeComponent();
        }

        private void ZiLiaoShenChaLNG_Load(object sender, EventArgs e)
        {
            ZiLiaoShenChaLNGDataGridView1.Rows.Add(1,"1", "冀B2008", "123", "0000001", "2014.6.30", "正在验车", "编辑");
            ZiLiaoShenChaLNGDataGridView1.Rows.Add(1,"2", "冀B2028", "166", "0000002", "2014.6.30", "正在验车", "编辑");
            ZiLiaoShenChaLNGDataGridView1.Rows.Add(0,"3", "冀B2038", "130", "0000003", "2014.6.30", "正在验车", "编辑");
        }

        private void ZiLiaoShenChaLNGDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                UNDOZiLiaoShenCha_LNGEdit tt = new UNDOZiLiaoShenCha_LNGEdit();
                tt.ShowDialog();
            }
        }

       
    }
}
