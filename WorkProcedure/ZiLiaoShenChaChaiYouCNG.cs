﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkProcedure
{
    public partial class ZiLiaoShenChaChaiYouCNG : CommonControl.CommonTabPage
    {
        public ZiLiaoShenChaChaiYouCNG()
        {
            InitializeComponent();
        }

        private void ZiLiaoShenChaChaiYouCNG_Load(object sender, EventArgs e)
        {
            ZiLiaoShenChaChaiYouCNGDataGridView1.Rows.Add(0,"1", "冀B2008", "123", "0000001", "2014.6.30", "正在验车", "编辑" );
            ZiLiaoShenChaChaiYouCNGDataGridView1.Rows.Add(1,"2", "冀B2028", "166", "0000002", "2014.6.30", "正在验车", "编辑");
            ZiLiaoShenChaChaiYouCNGDataGridView1.Rows.Add(0,"3", "冀B2038", "130", "0000003", "2014.6.30", "正在验车", "编辑");
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void ZiLiaoShenChaChaiYouCNGDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ZiLiaoShenChaChaiYouCNGDataGridView1.CurrentCell.Value.ToString() == "编辑")
            {
                ZiLiaoShenCha_ChaiYouCNGEdit tt = new ZiLiaoShenCha_ChaiYouCNGEdit();
                tt.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZiLiaoShenCha_ChaiYouCNGChaKan tt = new ZiLiaoShenCha_ChaiYouCNGChaKan();
            tt.ShowDialog();
        }
    }
}
