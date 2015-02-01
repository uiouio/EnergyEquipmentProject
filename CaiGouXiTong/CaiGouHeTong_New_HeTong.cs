using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CaiGouXiTong.Service;
using EntityClassLibrary;
using System.Collections;

namespace CaiGouXiTong
{
    public partial class CaiGouHeTong_New_HeTong : Form
    {
        OpPurchase opp = new OpPurchase();

        DataSet supps;
        public CaiGouHeTong_New_HeTong()
        {
            InitializeComponent();
        }

        private void CaiGouHeTong_New_HeTong_Load(object sender, EventArgs e)
        {
            supps = opp.GetpurSupps();
            DataTable dt = supps.Tables[0];
            this.comboBox1.DisplayMember = dt.Columns[1].ColumnName;
            this.comboBox1.ValueMember = dt.Columns[0].ColumnName;
            this.comboBox1.DataSource = dt;
            //this.comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1)
            {
                return;
            }
            long id = Convert.ToInt64(this.comboBox1.SelectedValue);
            
            ShowInGrid(opp.GetselectPurappBySuppID(Convert.ToInt64(id)));

        }

        //private void comboBox1_DropDown(object sender, EventArgs e)
        //{
            
        //}


        public void ShowInGrid(IList purdeil)
        {
            this.commonDataGridView1.Rows.Clear();
            if (purdeil != null)
            {

                foreach (PurchaseApplyDetail o in purdeil)
                {

                    if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.pingshenshenheTongguoDengdaiShengchenghetong)
                    {
                        this.commonDataGridView1.Rows.Add(true, o.Id, o.GoodsBaseInfoId.GoodsClassCode,
                                  o.GoodsBaseInfoId.GoodsName, o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material,
                                  o.GoodsBaseInfoId.Unit,
                                  o.ReportQuanlity,
                                  o.SupplierInfoId.SupplierName,//供应商
                                  o.GoodsSingleAmount,//单价
                                  (o.GoodsSingleAmount * o.ReportQuanlity),//金额
                                  "",//合同编号
                                  PurchaseApplyDetail.StateName[(long)PurchaseApplyDetail.purchasedeilstate.pingshenshenheTongguoDengdaiShengchenghetong],
                                  "查看比价评审");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                    }
                }

            }
        }


        /// <summary>
        /// 合并比价评审生成采购合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;

            if (this.commonDataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("请选择供货商");
            }
            else
            {
                CaiGouHeTong_New_dialog NewHetong = new CaiGouHeTong_New_dialog();

                int count2 = this.commonDataGridView1.Rows.Count;
                for (int i = 0; i < count2; i++)
                {
                    string iftrue = this.commonDataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (iftrue == "True")
                    {
                        num++;
                    }
                }

                if (num > 0)
                {

                    int count = this.commonDataGridView1.Rows.Count;
                    NewHetong.ReceivePurappdetList = new List<PurchaseApplyDetail>();
                    int num1 = 0;
                    for (int i = 0; i < count; i++)
                    {
                        string iftrue = this.commonDataGridView1.Rows[i].Cells[0].Value.ToString();
                        if (iftrue == "True")
                        {
                            
                            PurchaseApplyDetail purapp = new PurchaseApplyDetail();
                            purapp = this.commonDataGridView1.Rows[i].Tag as PurchaseApplyDetail;
                            NewHetong.ReceivePurappdetList.Insert(num1, purapp);
                            num1++;
                        }
                    }
                    NewHetong.ShowDialog();

                    if (NewHetong.DialogResult == DialogResult.OK)
                    {
                        this.commonDataGridView1.Rows.Clear();
                    }
                }

                else
                {
                    MessageBox.Show("无勾选货物");
                }
                


                
               
            
            }
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13 && this.commonDataGridView1.CurrentCell.Value.ToString() == "查看比价评审")
            {
                BiJiaPingShen_BiJiaView biJiaView = new BiJiaPingShen_BiJiaView();
                biJiaView.ReceivePurdet = this.commonDataGridView1.CurrentRow.Tag as PurchaseApplyDetail;
                biJiaView.ShowDialog();
            }
        }


    }
}
