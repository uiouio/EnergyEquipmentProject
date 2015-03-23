using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using KuGuanXiTong.Service;
using System.Collections;
using DLLFullPrint;
using CommonMethod;
using System.Linq;

namespace KuGuanXiTong
{
    public partial class Ruku_ShowStockDetail : Form
    {
        List<StockOperationDetail> detaillist = new List<StockOperationDetail>();
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
                    detaillist.Add(spd);

                    this.commonDataGridView1.Rows.Add(num,spd.StockId.GoodsBaseInfoID.GoodsClassCode,
                        spd.StockId.GoodsBaseInfoID.GoodsName,
                        spd.GoodsCode,
                        spd.StockId.GoodsBaseInfoID.Specifications,
                        spd.StockId.GoodsBaseInfoID.Material,
                        spd.StockId.GoodsBaseInfoID.Unit,
                        spd.Quantity,
                        spd.TheMoney,
                        spd.Tax,
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
            PrintDataGridView.PrintTheDataGridView(commonDataGridView1);
        }

        /// <summary>
        /// 按编号查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            string likeed = this.textBox1.Text.Trim()+"%";
            var resultList = from item in detaillist
                             where item.StockId.GoodsBaseInfoID.GoodsClassCode.StartsWith(this.textBox1.Text.Trim())
                             select item;
            
            var escortList = resultList.ToList();
            
            int num = 1;
            foreach (StockOperationDetail spd in escortList)
            {
                this.commonDataGridView1.Rows.Add(num, spd.StockId.GoodsBaseInfoID.GoodsClassCode,
                    spd.StockId.GoodsBaseInfoID.GoodsName,
                    spd.GoodsCode,
                    spd.StockId.GoodsBaseInfoID.Specifications,
                    spd.StockId.GoodsBaseInfoID.Material,
                    spd.StockId.GoodsBaseInfoID.Unit,
                    spd.Quantity,
                    spd.TheMoney,
                    spd.Tax,
                    spd.StockId.StorehouseplaceCode,
                    spd.StockId.Quantity);
                num++;
            }
        }

        /// <summary>
        /// 显示全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            int num = 1;
            foreach (StockOperationDetail spd in detaillist)
            {
                this.commonDataGridView1.Rows.Add(num, spd.StockId.GoodsBaseInfoID.GoodsClassCode,
                    spd.StockId.GoodsBaseInfoID.GoodsName,
                    spd.GoodsCode,
                    spd.StockId.GoodsBaseInfoID.Specifications,
                    spd.StockId.GoodsBaseInfoID.Material,
                    spd.StockId.GoodsBaseInfoID.Unit,
                    spd.Quantity,
                    spd.TheMoney,
                    spd.Tax,
                    spd.StockId.StorehouseplaceCode,
                    spd.StockId.Quantity);
                num++;
            }
        }
    }
}
