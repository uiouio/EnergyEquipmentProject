using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using KuGuanXiTong.Service;
using EntityClassLibrary;
using CommonMethod;
using SQLProvider.Service;

namespace KuGuanXiTong
{
    public partial class KuGuanTongJi : CommonControl.CommonTabPage
    {
        IList currentStock;
        OpStock opstack = new OpStock();
        Categtory opgoods = new Categtory();

        public KuGuanTongJi()
        {
            InitializeComponent();
        }
        private void KuGuanTongJi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        public void ShowGridView()
        {
            if(this.commonDataGridView1.Rows.Count>0)
            this.commonDataGridView1.Rows.Clear();

            if (currentStock != null && currentStock.Count >= 0)
            {
                int num = 1;
                foreach (object[] s in currentStock)
                {
                    this.commonDataGridView1.Rows.Add(num,s[0], s[1], s[2], s[4], s[3], s[6], s[7], Convert.ToInt32(s[8]));
                    num++;
                }
            }
        }

        public override void reFreshAllControl()
        {
            //currentStock = opstack.GetAllStock();
            //ShowGridView();
            base.reFreshAllControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Cursor = Cursors.WaitCursor;
            currentStock = opstack.GetQuerryStock(this.textBox1.Text,this.textBox2.Text);
            ShowGridView();
            this.button1.Cursor = Cursors.Hand;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Cursor = Cursors.WaitCursor;
            this.commonDataGridView2.Rows.Clear();

            string goodscode = this.textBox3.Text;
            IList sk = opstack.GetStockByMoHuGoodsCode(goodscode);

            if (sk == null || sk.Count == 0)
            {
                MessageBox.Show("库中无记录！");
            }
            else
            {
                int num = 1; // = this.commonDataGridView2.Rows.Count;

              foreach(Stock o in sk)
              {
                  this.commonDataGridView2.Rows.Add(num,o.GoodsBaseInfoID.GoodsClassCode, o.GoodsBaseInfoID.GoodsName,
                              o.GoodsCode, o.GoodsBaseInfoID.Specifications, o.GoodsBaseInfoID.Material,
                              o.GoodsBaseInfoID.Unit, o.Quantity, o.Money, o.StorehouseplaceCode, "打印条码");
                  num++;
              }

            }
            this.button2.Cursor = Cursors.Hand;
           
        }

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 10&&this.commonDataGridView2.CurrentCell.Value.ToString() == "打印条码")
            {
                CommonMethod.PrintCode.print(this.commonDataGridView2.CurrentRow.Cells[3].Value.ToString(), this.commonDataGridView2.CurrentRow.Cells[2].Value.ToString());
            }
        }

        /// <summary>
        /// 导出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            this.commonPictureButton2.Cursor = Cursors.WaitCursor;
            DoExport.DoTheExport(this.commonDataGridView1);
            this.commonPictureButton2.Cursor = Cursors.Hand;
        }

        private void commonPictureButton4_Click(object sender, EventArgs e)
        {
            this.commonPictureButton4.Cursor = Cursors.WaitCursor;
            PrintDataGridView.PrintTheDataGridView(this.commonDataGridView1);
            this.commonPictureButton4.Cursor = Cursors.Hand;
        }

    }
}
