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
    public partial class UNDOKuGuanCaoZuo_ChaiBao : Form
    {
        public UNDOKuGuanCaoZuo_ChaiBao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void KuGuanCaoZuo_ChaiBao_Load(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Add("101205", "ECU", "查看");
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.commonDataGridView1.CurrentCell.Value.ToString() == "查看")
            {
                UNDOKuGuanCaoZuo_ChaiZhuangBao_XiangQing kgcz = new UNDOKuGuanCaoZuo_ChaiZhuangBao_XiangQing();
                kgcz.ShowDialog();
            }
        }
    }
}
