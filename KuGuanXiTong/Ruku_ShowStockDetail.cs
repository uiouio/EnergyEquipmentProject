using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using KuGuanXiTong.Service;
using System.Collections;
using DLLFullPrint;
using CommonMethod;


namespace KuGuanXiTong
{
    public partial class Ruku_ShowStockDetail : Form
    {
        OpStock opp = new OpStock();
        StockOperation sendStocktoshow = new StockOperation();
        /// <summary>
        /// 传入先择的Stock
        /// </summary>
        public StockOperation SendStocktoshow
        {
            get { return sendStocktoshow; }
            set { sendStocktoshow = value; }
        }
        public Ruku_ShowStockDetail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ruku_ShowStockDetail_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width < 800)
                this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6);
            if (SendStocktoshow != null)
            {
                IList details = opp.GetOpdetail(SendStocktoshow.Id);
                int num = 1;
                foreach(StockOperationDetail spd in details)
                {
                    this.commonDataGridView1.Rows.Add(num,spd.StockId.GoodsBaseInfoID.GoodsClassCode,
                        spd.StockId.GoodsBaseInfoID.GoodsName,
                        spd.GoodsCode,
                        spd.StockId.GoodsBaseInfoID.Specifications,
                        spd.StockId.GoodsBaseInfoID.Material,
                        spd.StockId.GoodsBaseInfoID.Unit,
                        spd.Quantity,
                        spd.TheMoney,
                        spd.StockId.StorehouseplaceCode,
                        spd.StockId.Quantity);
                    num++;
                }
            
            }
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //DataRow dr;
            //设置列表头 

            //foreach (DataGridViewColumn headerCell in commonDataGridView1.Columns)
            //{
            //    dt.Columns.Add(headerCell.HeaderText);
            //}
            //foreach (DataGridViewRow item in commonDataGridView1.Rows)
            //{
            //    dr = dt.NewRow();
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        dr[i] = item.Cells[i].Value.ToString();
            //    }
            //    dt.Rows.Add(dr);
            //}
            //DataSet dy = new DataSet();
            //dy.Tables.Add(dt);
            //MyDLL.TakeOver(dy);
            PrintDataGridView.PrintTheDataGridView(commonDataGridView1);
            
        }
    }
}
