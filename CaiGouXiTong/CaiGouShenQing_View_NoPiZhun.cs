using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CaiGouXiTong.Service;

namespace CaiGouXiTong
{
    public partial class CaiGouShenQing_View_NoPiZhun : Form
    {
        OpPurchase opp = new OpPurchase();
        PurchaseApply receivepurapply;
        public PurchaseApply Receivepurapply
        {
            get { return receivepurapply; }
            set { receivepurapply = value; }
        }


        public CaiGouShenQing_View_NoPiZhun()
        {
            InitializeComponent();
            Receivepurapply = new PurchaseApply();
        }

        private void CaiGouShenQing_View_NoPiZhun_Load(object sender, EventArgs e)
        {
            if(Receivepurapply.Id != 0)
            {
                this.textBox1.Text = Receivepurapply.Id.ToString();
                this.dateTimePicker1.Value = new DateTime(Receivepurapply.PurchaseApplyTime);
                ShowInGrid(opp.GetpurapplydetByapply(Receivepurapply));
                this.textBox2.Text = Receivepurapply.PurchaseRemark;
            }
        }


        public void ShowInGrid(IList purappder)
        {
            if(purappder != null)
            {
                foreach(PurchaseApplyDetail o in purappder)
                {
                    long num = opp.GetGoodsQUantityByGoodaId(o.GoodsBaseInfoId.Id);
                   
                    if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingdengdaishenheForcaigoufuzeren)
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
                           "采购负责人通过等待总经理审核"
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
                           "申请已批准等待比价评审"
                           );
                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.shengchengbijiapingshendengdaiquerenhetong)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "已经生成比价评审等待生成合同"
                           );
                    }
                    else if (o.PurchaseApplyDetailState == (long)PurchaseApplyDetail.purchasedeilstate.hetongyijingshengchengdengdaishenhe)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsClassCode,
                           o.GoodsBaseInfoId.GoodsName,
                           o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit,
                           ((num == -1) ? "库存无记录" : num.ToString()),
                           o.PlanQuanlity, o.ReportQuanlity,
                           "合同已经生成等待审核"
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
        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
