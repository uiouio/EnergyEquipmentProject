using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using CaiGouXiTong.Service;

namespace CaiGouXiTong
{
    public partial class YunShuHeTong : CommonControl.CommonTabPage
    {
        public YunShuHeTong()
        {
            InitializeComponent();
        }

        OpPurchase opp = new OpPurchase();
        public override void reFreshAllControl()
        {
            ShowInGrid(opp.GetAllTransportCon());
             base.reFreshAllControl();
        }


        public void ShowInGrid(IList i)
        {
            this.commonDataGridView1.Rows.Clear();
            if( i !=  null)
            {
                
                foreach(TransportContract o in i)
                {
                    this.commonDataGridView1.Rows.Add(o.TransportContractNum, o.SendCategory, o.TransportMoney, "查看详情");
                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                }
            }

        }


        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            YunShuHeTong_New xinzeng = new YunShuHeTong_New();
            xinzeng.ShowDialog();
            if (xinzeng.DialogResult == DialogResult.OK)
            {
                ShowInGrid(opp.GetAllTransportCon());
            }

        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.commonDataGridView1.CurrentCell.Value.ToString() == "查看详情" )
            {
                YunShuHeTong_New chakan = new YunShuHeTong_New();
                chakan.IsChakan = 1;
                chakan.ReceiveTranCon = this.commonDataGridView1.CurrentRow.Tag as TransportContract;
                chakan.ShowDialog();
            }
        }

        /// <summary>
        ///查询按钮 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ShowInGrid(opp.GetSelecttranssport(
                this.textBox2.Text,
                this.textBox1.Text,
                this.dateTimePicker1.Value.Date.Ticks,
                this.dateTimePicker2.Value.Date.AddDays(1).Ticks));
        }

        private void YunShuHeTong_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }
    }
}
