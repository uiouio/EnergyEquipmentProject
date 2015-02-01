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
    public partial class CaiGouJiHua_YuanGong : CommonControl.CommonTabPage
    {
       
        OpPurchase opp = new OpPurchase();
        public CaiGouJiHua_YuanGong()
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
       


        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            CaiGouJiHua_New_dialog caiGouShenQing = new CaiGouJiHua_New_dialog();
            caiGouShenQing.User = this.User;
            caiGouShenQing.ShowDialog();
            if (caiGouShenQing.DialogResult == DialogResult.OK)
            {
                ShowInGrid(opp.GetAllPlan());
            }
          
        }

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8&&commonDataGridView2.CurrentCell.Value.ToString() == "查看详情")
            {
                CaiGouJiHua_View_dialog_NoTuiHui NoTuiHui = new CaiGouJiHua_View_dialog_NoTuiHui();
                NoTuiHui.Receiveplan = this.commonDataGridView2.CurrentRow.Tag as PurchasePlan;
                NoTuiHui.ShowDialog();
                
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
                    //if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Daichuli)
                    //{
                    //    this.commonDataGridView2.Rows.Add(0, i + 1,
                    //        p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                    //   p.UserId.UserName, p.PurchaseRemark,
                    //   new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   "待处理",
                    //   "查看详情");
                    //    this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;

                    //}
                    //else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Bufenshengchengshenqing)
                    //{
                    //    this.commonDataGridView2.Rows.Add(0, i + 1,
                    //   p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                    //   p.UserId.UserName, p.PurchaseRemark,
                    //   new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   "计划货物部分通过",
                    //   "查看详情");
                    //    this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;
                    //    this.commonDataGridView2.Rows[i].Cells[0].ReadOnly = true;
                    //}
                    //else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Quanbushenchengshenqing)
                    //{
                    //    this.commonDataGridView2.Rows.Add(0, i + 1,
                    //   p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                    //   p.UserId.UserName, p.PurchaseRemark,
                    //   new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   "计划货物全部通过",
                    //   "查看详情");
                    //    this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;
                    //    this.commonDataGridView2.Rows[i].Cells[0].ReadOnly = true;
                    //}

                    //else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.quanbutuihui)
                    //{
                    //    this.commonDataGridView2.Rows.Add(0, i + 1,
                    //   p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                    //   p.UserId.UserName, p.PurchaseRemark,
                    //   new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   "计划货物全部退回",
                    //   "查看详情");
                    //    this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;
                    //    this.commonDataGridView2.Rows[i].Cells[0].ReadOnly = true;
                    //}
                    //else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.yijingshengchengpingshen)
                    //{
                    //    this.commonDataGridView2.Rows.Add(0, i + 1,
                    //   p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                    //   p.UserId.UserName, p.PurchaseRemark,
                    //   new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    //   "生成申请 单号" + p.PurchaseApplyId.Id.ToString(),
                    //   "查看详情");
                    //    this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;
                    //    this.commonDataGridView2.Rows[i].Cells[0].ReadOnly = true;
                    //}
                    //i++;

                    if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Daichuli)
                    {
                        this.commonDataGridView2.Rows.Add(0, i + 1,
                            p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
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
                        this.commonDataGridView2.Rows.Add(0, i + 1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.Name, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       PurchasePlan.StateName[(long)PurchasePlan.purPlanState.Bufenshengchengshenqing],
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;

                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Cells[7].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchasePlan.StateColor[(long)PurchasePlan.purPlanState.Bufenshengchengshenqing]);


                     
                    }

                    else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Quanbushenchengshenqing)
                    {
                        this.commonDataGridView2.Rows.Add(0, i + 1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.Name, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       PurchasePlan.StateName[(long)PurchasePlan.purPlanState.Quanbushenchengshenqing],
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;

                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Cells[7].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchasePlan.StateColor[(long)PurchasePlan.purPlanState.Quanbushenchengshenqing]);


                     
                    }

                    else if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.quanbutuihui)
                    {
                        this.commonDataGridView2.Rows.Add(0, i + 1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.Name, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        PurchasePlan.StateName[(long)PurchasePlan.purPlanState.quanbutuihui],
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;

                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Cells[7].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchasePlan.StateColor[(long)PurchasePlan.purPlanState.quanbutuihui]);

                     
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
            long t2 = this.dateTimePicker2.Value.Date.AddDays(1).Ticks;
            long t3 = this.dateTimePicker3.Value.Date.Ticks;
            long t4 = this.dateTimePicker4.Value.Date.AddDays(1).Ticks;
            string name = this.textBox2.Text;
            ShowInGrid(opp.Selectplans(name,t1,t2,t3,t4,this.comboBox1.SelectedIndex-1));
        }

    }
}
