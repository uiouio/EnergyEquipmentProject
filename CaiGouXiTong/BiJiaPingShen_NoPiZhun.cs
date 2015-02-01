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
    public partial class BiJiaPingShen_NoPiZhun : CommonControl.CommonTabPage
    {

        OpPurchase opp = new OpPurchase();
       
        public BiJiaPingShen_NoPiZhun()
        {
            InitializeComponent();
        }


        public override void reFreshAllControl()
        {
            ShowInGrid(opp.GetAllPurapplyDet());
            base.reFreshAllControl();
        }

        public void ShowInGrid(IList purdeil)
        {
            this.commonDataGridView1.Rows.Clear();
            if(purdeil != null)
            {
                foreach(PurchaseApplyDetail o in purdeil)
                {

                    if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.shenqingyitonggudengdaibijiapingshen)
                    {
                        this.commonDataGridView1.Rows.Add(
                            false,
                            o.Id,
                            o.GoodsBaseInfoId.GoodsClassCode,
                            o.GoodsBaseInfoId.GoodsName,
                            o.GoodsBaseInfoId.Specifications,
                            o.GoodsBaseInfoId.Material,
                            o.GoodsBaseInfoId.Unit,
                            o.ReportQuanlity,
                            "",//供应商
                            "",//单价
                            "",//金额
                            "",//合同编号
                           PurchaseApplyDetail.StateName[(long)PurchaseApplyDetail.purchasedeilstate.shenqingyitonggudengdaibijiapingshen],
                            "生成比价评审");

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Red;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[12].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchaseApplyDetail.StateColor[(long)PurchaseApplyDetail.purchasedeilstate.shenqingyitonggudengdaibijiapingshen]);
                    }

                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.shengchengbijiapingshendengdaiquerenhetong)
                    {
                        this.commonDataGridView1.Rows.Add(false, o.Id, o.GoodsBaseInfoId.GoodsClassCode,
                                o.GoodsBaseInfoId.GoodsName, o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material,
                                o.GoodsBaseInfoId.Unit,
                                o.ReportQuanlity,
                                o.SupplierInfoId.SupplierName,//供应商
                                o.GoodsSingleAmount,//单价
                                (o.GoodsSingleAmount * o.ReportQuanlity),//金额
                                "",//合同编号
                              PurchaseApplyDetail.StateName[(long)PurchaseApplyDetail.purchasedeilstate.shengchengbijiapingshendengdaiquerenhetong],
                                "查看比价评审");

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[12].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApplyDetail.StateColor[(long)PurchaseApplyDetail.purchasedeilstate.shengchengbijiapingshendengdaiquerenhetong]);


                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.pingshenTuihui)
                    {
                        this.commonDataGridView1.Rows.Add(false, o.Id, o.GoodsBaseInfoId.GoodsClassCode,
                                  o.GoodsBaseInfoId.GoodsName, o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material,
                                  o.GoodsBaseInfoId.Unit,
                                  o.ReportQuanlity,
                                  o.SupplierInfoId.SupplierName,//供应商
                                  o.GoodsSingleAmount,//单价
                                  (o.GoodsSingleAmount * o.ReportQuanlity),//金额
                                  "",//合同编号
                                  PurchaseApplyDetail.StateName[(long)PurchaseApplyDetail.purchasedeilstate.pingshenTuihui],
                                  "查看比价评审");
                        //this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Gray;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[12].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApplyDetail.StateColor[(long)PurchaseApplyDetail.purchasedeilstate.pingshenTuihui]);

                    }

                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.pingshenshenheTongguoDengdaiShengchenghetong)
                    {
                        this.commonDataGridView1.Rows.Add(false, o.Id, o.GoodsBaseInfoId.GoodsClassCode,
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

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[12].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApplyDetail.StateColor[(long)PurchaseApplyDetail.purchasedeilstate.pingshenshenheTongguoDengdaiShengchenghetong]);

                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.hetongyijingshengchengdengdaishenhe)
                    {
                        this.commonDataGridView1.Rows.Add(false, o.Id, o.GoodsBaseInfoId.GoodsClassCode,
                                o.GoodsBaseInfoId.GoodsName, o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material,
                                o.GoodsBaseInfoId.Unit,
                                o.ReportQuanlity,
                                o.SupplierInfoId.SupplierName,//供应商
                                o.GoodsSingleAmount,//单价
                                (o.GoodsSingleAmount * o.ReportQuanlity),//金额
                                o.PurchaseContractId.PurchaseContractCode,//合同编号
                               PurchaseApplyDetail.StateName[(long)PurchaseApplyDetail.purchasedeilstate.hetongyijingshengchengdengdaishenhe],
                                "查看比价评审");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[12].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApplyDetail.StateColor[(long)PurchaseApplyDetail.purchasedeilstate.hetongyijingshengchengdengdaishenhe]);


                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.hetongweitongguo)
                    {

                        this.commonDataGridView1.Rows.Add(false, o.Id, o.GoodsBaseInfoId.GoodsClassCode,
                                o.GoodsBaseInfoId.GoodsName, o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material,
                                o.GoodsBaseInfoId.Unit,
                                o.ReportQuanlity,
                                o.SupplierInfoId.SupplierName,//供应商
                                o.GoodsSingleAmount,//单价
                                (o.GoodsSingleAmount * o.ReportQuanlity),//金额
                                o.PurchaseContractId.PurchaseContractCode,//合同编号
                                PurchaseApplyDetail.StateName[(long)PurchaseApplyDetail.purchasedeilstate.hetongweitongguo],
                                "查看比价评审");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[12].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApplyDetail.StateColor[(long)PurchaseApplyDetail.purchasedeilstate.hetongweitongguo]);


                    }

                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.hetongshenhebeituihui)
                    {
                        this.commonDataGridView1.Rows.Add(false, o.Id, o.GoodsBaseInfoId.GoodsClassCode,
                                o.GoodsBaseInfoId.GoodsName, o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material,
                                o.GoodsBaseInfoId.Unit,
                                o.ReportQuanlity,
                                o.SupplierInfoId.SupplierName,//供应商
                                o.GoodsSingleAmount,//单价
                                (o.GoodsSingleAmount * o.ReportQuanlity),//金额
                                o.PurchaseContractId.PurchaseContractCode,//合同编号
                                PurchaseApplyDetail.StateName[(long)PurchaseApplyDetail.purchasedeilstate.hetongshenhebeituihui],
                                "查看比价评审");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[12].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApplyDetail.StateColor[(long)PurchaseApplyDetail.purchasedeilstate.hetongshenhebeituihui]);

                    }


                   
                    
                }
            }
        }

        private void BiJiaPingShen_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == 13&&this.commonDataGridView1.CurrentCell.Value.ToString() == "生成比价评审")
            {
                BiJiaPingShen_New_dialog biJiaPingShenChuLi = new BiJiaPingShen_New_dialog();
                biJiaPingShenChuLi.ReceivePurdet = (this.commonDataGridView1.CurrentRow.Tag) as PurchaseApplyDetail;
                biJiaPingShenChuLi.User = this.User;
                biJiaPingShenChuLi.ShowDialog();
                if (biJiaPingShenChuLi.DialogResult == DialogResult.OK)
                {
                    ShowInGrid(opp.GetAllPurapplyDet());
                }
            }
          
            else if (e.ColumnIndex == 13&&this.commonDataGridView1.CurrentCell.Value.ToString() == "查看比价评审")
            {
                BiJiaPingShen_BiJiaView biJiaView = new BiJiaPingShen_BiJiaView();
                biJiaView.ReceivePurdet = this.commonDataGridView1.CurrentRow.Tag as PurchaseApplyDetail;
                biJiaView.TheUser = this.User;
                biJiaView.ShowDialog();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            ShowInGrid(opp.GetselectPurappDet(this.textBox1.Text,this.textBox3.Text,this.textBox2.Text,this.textBox4.Text,this.comboBox1.SelectedIndex+4));
        }

       
    }
}
