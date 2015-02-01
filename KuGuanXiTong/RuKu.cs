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
using KuGuanXiTong.Service;
using CommonMethod;

namespace KuGuanXiTong
{
    public partial class RuKu : CommonControl.CommonTabPage
    {

        OpSupplierInfo opsuplier = new OpSupplierInfo();
        OpStock opp = new OpStock();
        public RuKu()
        {
            InitializeComponent();
        }
        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            RuKu_New_dialog ruKuXinJian = new RuKu_New_dialog();
            ruKuXinJian.Userid = this.User;
            ruKuXinJian.ShowDialog();
            if (ruKuXinJian.DialogResult == DialogResult.OK)
            {
                RefreshGrid(opp.GetAllOpsIn());
            }
          
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5&&this.commonDataGridView1.CurrentCell.Value.ToString() == "查看")
            {
                Ruku_ShowStockDetail opde = new Ruku_ShowStockDetail();
                opde.SendStocktoshow = (StockOperation)this.commonDataGridView1.CurrentRow.Tag;
                opde.ShowDialog();
            }
        }

     
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (this.comboBox1.Items.Count == 0)
            {

                IList suppliers = this.opsuplier.GetAllSupplier();
                

                this.comboBox1.DataSource = suppliers;
                this.comboBox1.DisplayMember = "SupplierName";
                this.comboBox1.ValueMember = "Itself";

            }
        }

        public override void reFreshAllControl()
        {
            this.comboBox1.SelectedIndex = -1;
            RefreshGrid(opp.GetAllOpsIn());
        }
     

        private void RuKu_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        public void RefreshGrid(IList i)
        {
            this.commonDataGridView1.Rows.Clear();
            if (i != null)
            {
                int num = 1;
                foreach (StockOperation o in i)
                {
                    DateTime dt = new DateTime(o.OperationTime);
                    string str = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    if (o.SupplierInfoId != null)
                        this.commonDataGridView1.Rows.Add(num,o.RetrospectListNumber, o.SupplierInfoId.SupplierName, str, o.Remark, "查看");
                    else
                        this.commonDataGridView1.Rows.Add(num,o.RetrospectListNumber, "", str, o.Remark, "查看");

                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                    num++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            string num = this.textBox1.Text;
            SupplierInfo spp = this.comboBox1.SelectedValue as SupplierInfo;
            IList i;
            if (spp != null)
            {
                i = opp.SelectOpdetail(
                    num, spp.Id,
                    this.dateTimePicker1.Value.Date.Ticks, 
                    this.dateTimePicker2.Value.Date.AddDays(1).Ticks);
            }
            else
            {
                i = opp.SelectOpdetail(
                    num, 0, 
                    this.dateTimePicker1.Value.Date.Ticks, 
                    this.dateTimePicker2.Value.Date.AddDays(1).Ticks);
            }

            RefreshGrid(i);
            this.comboBox1.SelectedIndex = -1;
        }

        //public void ShowSelectGrid()
        //{

        //    IList i;
        //    if (i != null)
        //    {
        //        foreach (StockOperation o in i)
        //        {
        //            DateTime dt = new DateTime(o.OperationTime);
        //            string str = dt.ToString("yyyy-MM-dd HH:mm:ss");
        //            if (o.SupplierInfoId != null)
        //                this.commonDataGridView1.Rows.Add(o.RetrospectListNumber, o.SupplierInfoId.SupplierName, str, o.Remark, "查看");
        //            else
        //                this.commonDataGridView1.Rows.Add(o.RetrospectListNumber, "", str, o.Remark, "查看");
        //            this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
        //        }
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton2_Click(object sender, EventArgs e)
        {

            DoExport.DoTheExport(this.commonDataGridView1);
        }

        private void commonPictureButton5_Click(object sender, EventArgs e)
        {
            PrintDataGridView.PrintTheDataGridView(this.commonDataGridView1);
        }

    }
}
