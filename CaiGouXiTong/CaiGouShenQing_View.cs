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
    public partial class CaiGouShenQing_View : Form
    {
        OpPurchase opp = new OpPurchase();
        PurchaseApply receivepurapply;

        IList purdets;
        public PurchaseApply Receivepurapply
        {
            get { return receivepurapply; }
            set { receivepurapply = value; }
        }

        public CaiGouShenQing_View()
        {
            InitializeComponent();
            Receivepurapply = new PurchaseApply();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CaiGouShenQing_View_Load(object sender, EventArgs e)
        {
            if (Receivepurapply.Id != 0 )
            {
                this.textBox1.Text = Receivepurapply.Id.ToString();
                this.dateTimePicker1.Value = new DateTime(Receivepurapply.PurchaseApplyTime);
                purdets = opp.GetpurapplydetByapply(Receivepurapply);
                ShowInGrid(purdets);
                this.textBox2.Text = Receivepurapply.PurchaseRemark;
            }
        }

        public void ShowInGrid(IList purappder)
        {
            if (purappder != null)
            {
                foreach (PurchaseApplyDetail o in purappder)
                {
                    long num = opp.GetGoodsQUantityByGoodaId(o.GoodsBaseInfoId.Id);
                    
                    if(o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingdengdaishenheForcaigoufuzeren)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "等待采购负责人审核"
                           );
                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingbeiTuihuiForcaigouFuzeRen)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "采购负责人退回"
                           );
                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingdengdaishenheForzongjingli)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "采购负责人通过，等待总经理审核"
                           );
                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingbeiTuihuiForZongJingLi)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "总经理退回"
                           );
                    }

                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.shenqingyitonggudengdaibijiapingshen)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "申请已批准，等待比价评审"
                           );
                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.shengchengbijiapingshendengdaiquerenhetong)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "已经生成比价评审，等待生成合同"
                           );
                    }

                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.hetongyijingshengchengdengdaishenhe)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "合同已经生成，等待审核"
                           );
                    }

                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.hetongweitongguo)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "合同已经通过"
                           );
                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.hetongshenhebeituihui)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "合同被退回"
                           );
                    }



                   
                

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 批准按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("批准之后不能更改。确定要批准吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                if (Receivepurapply.PurchaseApplyState == (long)PurchaseApply.PurApplyState.weishenhe)
                {
                    Receivepurapply.PurchaseApplyState = (long)PurchaseApply.PurApplyState.caigoufuzerenShenhe;
                    opp.SaveOrUpdateEntity(Receivepurapply);

                    if (purdets != null)
                    {
                        foreach (PurchaseApplyDetail o in purdets)
                        {
                            PurchaseApplyDetail purr = new PurchaseApplyDetail();
                            purr = o;
                            purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingdengdaishenheForzongjingli;
                            opp.SaveOrUpdateEntity(purr);
                        }
                    }


                }
                else if (Receivepurapply.PurchaseApplyState == (long)PurchaseApply.PurApplyState.caigoufuzerenShenhe)
                {
                    Receivepurapply.PurchaseApplyState = (long)PurchaseApply.PurApplyState.zongjingliShenhe;
                    opp.SaveOrUpdateEntity(Receivepurapply);
                    
                    if (purdets != null)
                    {
                        foreach (PurchaseApplyDetail o in purdets)
                        {
                            PurchaseApplyDetail purr = new PurchaseApplyDetail();
                            purr = o;
                            purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.shenqingyitonggudengdaibijiapingshen;
                            opp.SaveOrUpdateEntity(purr);
                        }
                    }


                }
                this.DialogResult = DialogResult.OK;
            }
        }


        /// <summary>
        ///退回按钮 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("退回之后不能更改。确定要退回吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                if (Receivepurapply.PurchaseApplyState == (long)PurchaseApply.PurApplyState.weishenhe)
                {
                    Receivepurapply.PurchaseApplyState = (long)PurchaseApply.PurApplyState.caigoufuzerenTuihui;
                    opp.SaveOrUpdateEntity(Receivepurapply);
                    
                    if (purdets != null)
                    {
                        foreach (PurchaseApplyDetail o in purdets)
                        {
                            PurchaseApplyDetail purr = new PurchaseApplyDetail();
                            purr = o;
                            purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingbeiTuihuiForcaigouFuzeRen;
                            opp.SaveOrUpdateEntity(purr);
                        }
                    }

                }
                else if (Receivepurapply.PurchaseApplyState == (long)PurchaseApply.PurApplyState.caigoufuzerenShenhe)
                {
                    Receivepurapply.PurchaseApplyState = (long)PurchaseApply.PurApplyState.zongjingliTuihui;
                    opp.SaveOrUpdateEntity(Receivepurapply);
                    if (purdets != null)
                    {
                        foreach (PurchaseApplyDetail o in purdets)
                        {
                            PurchaseApplyDetail purr = new PurchaseApplyDetail();
                            purr = o;
                            purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingbeiTuihuiForZongJingLi;
                            opp.SaveOrUpdateEntity(purr);
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
            }

        }
    }
}
