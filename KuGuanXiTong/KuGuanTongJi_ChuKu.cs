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
using KuGuanXiTong.Service;
using CommonMethod;

namespace KuGuanXiTong
{
    public partial class KuGuanTongJi_ChuKu : CommonControl.CommonTabPage
    {

        OpStock ops = new OpStock();

        public KuGuanTongJi_ChuKu()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            ShowInGrid(ops.GetChuKuDetailForTongJi());
            base.reFreshAllControl();
        }
        private void KuGuanTongJi_ChuKu_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }
        public void ShowInGrid(IList i)
        {
            this.commonDataGridView1.Rows.Clear();
            if( i!= null)
            {
                int num = 1;
                foreach (StockOperationDetail o in i)
                {
                    if(o.StockOperationId.OperationTpye == (long)StockOperation.OpTypeFlag.OutByRefitWork)
                    {
                        this.commonDataGridView1.Rows.Add(
                            num,
                          o.StockId.GoodsBaseInfoID.GoodsClassCode,
                          o.StockId.GoodsBaseInfoID.GoodsName,
                          o.StockId.GoodsBaseInfoID.Specifications,
                          o.StockId.GoodsBaseInfoID.Material,
                          o.StockId.GoodsBaseInfoID.Unit,
                          o.Quantity,
                          new DateTime(o.StockOperationId.OperationTime).ToString("yyyy-MM-dd HH:mm:ss"),
                          StockOperation.OpType[1]);
                        num++;
                    }
                    else if(o.StockOperationId.OperationTpye == (long)StockOperation.OpTypeFlag.OutByServices)
                    {
                        this.commonDataGridView1.Rows.Add(num,
                         o.StockId.GoodsBaseInfoID.GoodsClassCode,
                         o.StockId.GoodsBaseInfoID.GoodsName,
                         o.StockId.GoodsBaseInfoID.Specifications,
                         o.StockId.GoodsBaseInfoID.Material,
                         o.StockId.GoodsBaseInfoID.Unit,
                         o.Quantity,
                         new DateTime(o.StockOperationId.OperationTime).ToString("yyyy-MM-dd HH:mm:ss"),
                         StockOperation.OpType[2]);
                        num++;
                    
                    }
                    else if (o.StockOperationId.OperationTpye == (long)StockOperation.OpTypeFlag.OutByTaojian)
                    {

                        this.commonDataGridView1.Rows.Add(num,
                            o.StockId.GoodsBaseInfoID.GoodsClassCode,
                            o.StockId.GoodsBaseInfoID.GoodsName,
                            o.StockId.GoodsBaseInfoID.Specifications,
                            o.StockId.GoodsBaseInfoID.Material,
                            o.StockId.GoodsBaseInfoID.Unit,
                            o.Quantity,
                            new DateTime(o.StockOperationId.OperationTime).ToString("yyyy-MM-dd HH:mm:ss"),
                            StockOperation.OpType[3],
                            o.StockOperationId.Remark
                            );
                        num++;
                    }
                    else if (o.StockOperationId.OperationTpye == (long)StockOperation.OpTypeFlag.OutByBrokenParts)
                    {

                        this.commonDataGridView1.Rows.Add(num,
                            o.StockId.GoodsBaseInfoID.GoodsClassCode,
                            o.StockId.GoodsBaseInfoID.GoodsName,
                            o.StockId.GoodsBaseInfoID.Specifications,
                            o.StockId.GoodsBaseInfoID.Material,
                            o.StockId.GoodsBaseInfoID.Unit,
                            o.Quantity,
                            new DateTime(o.StockOperationId.OperationTime).ToString("yyyy-MM-dd HH:mm:ss"),
                            StockOperation.OpType[4],
                            o.StockOperationId.Remark
                            );
                        num++;
                    }
                    
                }
            }
        }


        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ShowInGrid(ops.SelectChukuDetailForTongJi(
                this.dateTimePicker1.Value.Date.Ticks, 
                this.dateTimePicker2.Value.Date.AddDays(1).Ticks, 
                this.textBox2.Text,
                this.textBox1.Text,
                this.comboBox1.SelectedIndex));
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DoExport.DoTheExport(this.commonDataGridView1);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton4_Click(object sender, EventArgs e)
        {
            PrintDataGridView.PrintTheDataGridView(this.commonDataGridView1);
        }


        /// <summary>
        ///依据条码查询改装单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string code = this.textBox3.Text;

            IList ii = 
            ops.GetGaiZhuangDanByCode(code);

            foreach(StockOperationDetail o in ii)
            {
                if (o.StockOperationId.IOFlag == 1)
                {
                    this.commonDataGridView2.Rows.Add(o.StockId.GoodsBaseInfoID.GoodsName, o.GoodsCode, o.StockOperationId.RetrospectListNumber.ToString());
                }
            }

        }

    }
}
