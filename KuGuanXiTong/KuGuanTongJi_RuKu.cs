using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KuGuanXiTong.Service;
using System.Collections;
using CaiGouXiTong.Service;
using EntityClassLibrary;
using CommonMethod;

namespace KuGuanXiTong
{
    public partial class KuGuanTongJi_RuKu : CommonControl.CommonTabPage
    {
        OpStock opp = new OpStock();
        OpSupplierInfo opsupp = new OpSupplierInfo();
        public KuGuanTongJi_RuKu()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            
            ShowInGrid(opp.GetRukuDetailForTongJi());
            base.reFreshAllControl();
        }

        private void KuGuanTongJi_RuKu_Load(object sender, EventArgs e)
        {
            LoadComboBox1();
            reFreshAllControl();
        }



        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IList sop;
            SupplierInfo spp = new SupplierInfo();
            spp = this.comboBox1.SelectedValue as SupplierInfo;
            if (this.comboBox1.SelectedValue != null)
                sop = opp.SelectRukuDetailForTongJi(
                    this.dateTimePicker1.Value.Date.Ticks, 
                    this.dateTimePicker2.Value.Date.AddDays(1).Ticks, 
                    this.textBox1.Text, this.textBox2.Text, spp.Id);
            else
                sop = opp.SelectRukuDetailForTongJi(
                    this.dateTimePicker1.Value.Date.Ticks, 
                    this.dateTimePicker2.Value.Date.AddDays(1).Ticks,
                    this.textBox1.Text, this.textBox2.Text, 0);

            ShowInGrid(sop);

            this.comboBox1.DataSource = null;
            this.comboBox1.Text = "";
        }

        public void ShowInGrid(IList sop)
        {
            this.commonDataGridView1.Rows.Clear();

            if (sop != null)
            {
                int num = 1;
                foreach (StockOperationDetail i in sop)
                {
                    this.commonDataGridView1.Rows.Add(num,
                        i.StockOperationId.RetrospectListNumber,
                        i.StockId.GoodsBaseInfoID.GoodsClassCode,
                        i.StockId.GoodsBaseInfoID.GoodsName,
                        i.StockId.GoodsBaseInfoID.Specifications,
                        i.StockId.GoodsBaseInfoID.Unit,
                        i.Quantity,

                        (i.StockOperationId.SupplierInfoId == null) ? "" : i.StockOperationId.SupplierInfoId.SupplierName,

                        new DateTime(i.StockOperationId.OperationTime).ToString("yyyy-MM-dd hh:mm:ss"),
                        i.StockOperationId.Remark);
                    num++;
                }
            }
           
        }

        private void LoadComboBox1()
        {
            if (this.comboBox1.Items.Count == 0)
            {
                IList suppliers = this.opsupp.GetAllSupplier();
                this.comboBox1.DataSource = suppliers;
                this.comboBox1.DisplayMember = "SupplierName";
                this.comboBox1.ValueMember = "Itself";
            }
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            this.commonPictureButton2.Cursor = Cursors.WaitCursor;
            DoExport.DoTheExport(this.commonDataGridView1);
            this.commonPictureButton2.Cursor = Cursors.Hand;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton4_Click(object sender, EventArgs e)
        {
            this.commonPictureButton4.Cursor = Cursors.WaitCursor;
            PrintDataGridView.PrintTheDataGridView(this.commonDataGridView1);
            this.commonPictureButton4.Cursor = Cursors.Hand;
        }
    }
}
