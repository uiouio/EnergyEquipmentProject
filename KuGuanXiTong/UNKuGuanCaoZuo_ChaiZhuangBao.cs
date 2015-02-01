using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KuGuanXiTong
{
    public partial class UNKuGuanCaoZuo_ChaiZhuangBao : CommonControl.CommonTabPage
    {
        public UNKuGuanCaoZuo_ChaiZhuangBao()
        {
            InitializeComponent();
        }

        private void KuGuanCaoZuo_ChaiZhuangBao_Load(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Add("1123", "ECU", "20140201", "查看");
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            UNDOKuGuanCaoZuo_ChaiBao kgcz = new UNDOKuGuanCaoZuo_ChaiBao();
            kgcz.ShowDialog();
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            UNDOKuGuanXiTong_HeBao kgczhb = new UNDOKuGuanXiTong_HeBao();
            kgczhb.ShowDialog();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.commonDataGridView1.CurrentCell.Value.ToString() == "查看")
            {
                UNDOKuGuanCaoZuo_ChaiZhuangBao_XiangQing KGXQXQ = new UNDOKuGuanCaoZuo_ChaiZhuangBao_XiangQing();
                KGXQXQ.ShowDialog();

            }
        }

     
    }
}
