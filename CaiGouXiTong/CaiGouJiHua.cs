using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CaiGouXiTong.Service;
using System.Collections;
using EntityClassLibrary;

namespace CaiGouXiTong
{
    public partial class CaiGouJiHua : CommonControl.CommonTabPage
    {


        OpPurchase opp = new OpPurchase();

        public CaiGouJiHua()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            this.comboBox1.SelectedIndex = 0;
            ShowInGrid(opp.GetAllPlan());
            base.reFreshAllControl();
        }
        private void CaiGouQingDan_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        /// <summary>
        /// 批准按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 新增采购计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            CaiGouJiHua_New_dialog caiGouShenQing = new CaiGouJiHua_New_dialog();
            caiGouShenQing.User = this.User;
            caiGouShenQing.ShowDialog();
            ShowInGrid(opp.GetAllPlan());
        }

        /// <summary>
        ///点击查看详情 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8&&commonDataGridView2.CurrentCell.Value.ToString() == "查看详情")
            {
                CaiGouJiHua_View_dialog cd = new CaiGouJiHua_View_dialog();
                cd.Receiveplan = this.commonDataGridView2.CurrentRow.Tag as PurchasePlan;
                cd.ShowDialog();
                if (cd.DialogResult == DialogResult.OK)
                {

                    ShowInGrid(opp.GetAllPlan());
                }
            }
        }
        
        /// <summary>
        ///向表中增加数据 
        /// </summary>
        /// <param name="ii"></param>
        public void ShowInGrid(IList ii)
        {
            this.commonDataGridView2.Rows.Clear();
            IList plans;
            plans = ii; //opp.GetAllPlan();
            if (plans != null)
            {
                int i = 0;
                foreach (PurchasePlan p in plans)
                {
                    if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Daichuli)
                    {
                        this.commonDataGridView2.Rows.Add(0, i+1,
                            p.UserId.Dept == null ?"":p.UserId.Dept.DepartmentName ,
                       p.UserId.Name, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       PurchasePlan.StateName[(long)PurchasePlan.purPlanState.Daichuli],
                       "查看详情");
                        
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;
                        
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Cells[7].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchasePlan.StateColor[(long)PurchasePlan.purPlanState.Daichuli]); //(new Color());
                       
                    }
                    else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Bufenshengchengshenqing)
                    {
                        this.commonDataGridView2.Rows.Add(0, i+1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.Name, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       PurchasePlan.StateName[(long)PurchasePlan.purPlanState.Bufenshengchengshenqing],
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;

                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Cells[7].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchasePlan.StateColor[(long)PurchasePlan.purPlanState.Bufenshengchengshenqing]);

                        
                        this.commonDataGridView2.Rows[i].Cells[0].ReadOnly = true;
                    }

                    else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Quanbushenchengshenqing)
                    {
                        this.commonDataGridView2.Rows.Add(0, i+1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.Name, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       PurchasePlan.StateName[(long)PurchasePlan.purPlanState.Quanbushenchengshenqing],
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;

                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Cells[7].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchasePlan.StateColor[(long)PurchasePlan.purPlanState.Quanbushenchengshenqing]);


                        this.commonDataGridView2.Rows[i].Cells[0].ReadOnly = true;
                    }

                   else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.quanbutuihui)
                    {
                        this.commonDataGridView2.Rows.Add(0, i+1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.Name, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        PurchasePlan.StateName[(long)PurchasePlan.purPlanState.quanbutuihui],
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;

                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Cells[7].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchasePlan.StateColor[(long)PurchasePlan.purPlanState.quanbutuihui]);

                        this.commonDataGridView2.Rows[i].Cells[0].ReadOnly = true;
                    }
                   else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.yijingshengchengpingshen)
                    {
                        this.commonDataGridView2.Rows.Add(0, i + 1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.Name, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        PurchasePlan.StateName[(long)PurchasePlan.purPlanState.yijingshengchengpingshen] + p.PurchaseApplyId.Id.ToString(),
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;

                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Cells[7].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchasePlan.StateColor[(long)PurchasePlan.purPlanState.yijingshengchengpingshen]);

                        this.commonDataGridView2.Rows[i].Cells[0].ReadOnly = true;
                    }

                    i++;
                }
            }
            


        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            long t1 = this.dateTimePicker1.Value.Date.Ticks;
            long t2 = this.dateTimePicker4.Value.Date.AddDays(1).Ticks;
            long t3 = this.dateTimePicker2.Value.Date.Ticks;
            long t4 = this.dateTimePicker8.Value.Date.AddDays(1).Ticks;
            string name = this.textBox2.Text;
            ShowInGrid(opp.Selectplans(name, t1, t2, t3, t4,this.comboBox1.SelectedIndex -1));
        }

        /// <summary>
        /// 批准勾选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((MessageBox.Show("批准之后不能更改。确定要批准吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                int count = this.commonDataGridView2.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string iftrue = this.commonDataGridView2.Rows[i].Cells[0].Value.ToString();
                    if (iftrue == "True")
                    {
                        //更新PurchasePlan状态
                        PurchasePlan theplan  = new PurchasePlan ();
                        theplan = this.commonDataGridView2.Rows[i].Tag as PurchasePlan;
                        theplan.PurchasePlanState = (long)PurchasePlan.purPlanState.Quanbushenchengshenqing;
                        PurchasePlan chenged = new PurchasePlan();
                        chenged =  opp.SaveOrUpdateEntity(theplan) as PurchasePlan;
                        IList thelist = opp.Getpurdet(theplan);
                        if (thelist != null)
                        {
                            foreach (PurchasePlanDetail o in thelist)
                            {
                                //更新PurchasePlanDetail状态
                                o.PurchasePlanDetailState = (long)PurchasePlanDetail.PurplanDetSta.Queren;
                                o.PurchasePlanId = chenged;
                                this.opp.SaveOrUpdateEntity(o);
                            }

                        }
                    }
                }
                ShowInGrid(opp.GetAllPlan());
            }
        }

        /// <summary>
        /// 退回勾选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            if ((MessageBox.Show("退回之后不能更改。确定要退回吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                int count = this.commonDataGridView2.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string iftrue = this.commonDataGridView2.Rows[i].Cells[0].Value.ToString();
                    if (iftrue == "True")
                    {
                        //更新PurchasePlan状态
                        PurchasePlan theplan = new PurchasePlan();
                        theplan = this.commonDataGridView2.Rows[i].Tag as PurchasePlan;
                        theplan.PurchasePlanState = (long)PurchasePlan.purPlanState.quanbutuihui;
                        PurchasePlan chenged = new PurchasePlan();
                        chenged = opp.SaveOrUpdateEntity(theplan) as PurchasePlan;
                        IList thelist = opp.Getpurdet(theplan);
                        if (thelist != null)
                        {
                            foreach (PurchasePlanDetail o in thelist)
                            {
                                //更新PurchasePlanDetail状态
                                o.PurchasePlanDetailState = (long)PurchasePlanDetail.PurplanDetSta.TuiHui;
                                o.PurchasePlanId = chenged;
                                this.opp.SaveOrUpdateEntity(o);
                            }

                        }
                    }
                }
                ShowInGrid(opp.GetAllPlan());
            }
        }

    }
}
