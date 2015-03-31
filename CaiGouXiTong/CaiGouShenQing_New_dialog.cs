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
using CommonWindow;

namespace CaiGouXiTong
{
    public partial class CaiGouShenQing_New_dialog : Form
    {
        OpPurchase opp = new OpPurchase();
        public CaiGouShenQing_New_dialog()
        {
            InitializeComponent();
        }


        private void CaiGouShenQing_New_dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            ShowInGrid(opp.GetShengchenJihua());

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
                  
                    if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Bufenshengchengshenqing)
                    {
                        this.commonDataGridView2.Rows.Add(false, i + 1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.UserName, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       "部分货物通过",
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;
                      
                    }
                    if (p.PurchasePlanState == (long)PurchasePlan.purPlanState.Quanbushenchengshenqing)
                    {
                        this.commonDataGridView2.Rows.Add(false, i + 1,
                       p.UserId.Dept == null ? "" : p.UserId.Dept.DepartmentName,
                       p.UserId.UserName, p.PurchaseRemark,
                       new DateTime(p.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       new DateTime(p.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss"),
                       "全部货物通过",
                       "查看详情");
                        this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = p;
                        
                    }

                  

                    i++;
                }
            }



        }
        
        
        

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (commonDataGridView2.CurrentCell.Value.ToString() == "查看详情")
            {
                CaiGouJiHua_View_dialog_NoTuiHui NoTuiHui = new CaiGouJiHua_View_dialog_NoTuiHui();
                NoTuiHui.Receiveplan = this.commonDataGridView2.CurrentRow.Tag as PurchasePlan;
                NoTuiHui.ShowDialog();
            }

            //复选框选中的时候触发的事件
            if (e.ColumnIndex == 0&&Convert.ToBoolean(commonDataGridView2.CurrentRow.Cells[0].EditedFormattedValue) == true)
            {
                //MessageBox.Show("选中");
                IList pdet = opp.GetQuerenDet(this.commonDataGridView2.CurrentRow.Tag as PurchasePlan);

                foreach (PurchasePlanDetail p in pdet)
                {
                    int count = this.commonDataGridView1.Rows.Count;
                    int IsSur = 0;//是否存在
                    for (int i = 0; i < count; i++)
                    {
                        if (typeof(PurchasePlanDetail) == this.commonDataGridView1.Rows[i].Tag.GetType())
                        {
                            if (p.GoodsBaseInfoId.Id == (commonDataGridView1.Rows[i].Tag as PurchasePlanDetail).GoodsBaseInfoId.Id)
                            {
                                this.commonDataGridView1.Rows[i].Cells[5].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value) + p.PurchasePlanQuanlity;
                                this.commonDataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);

                                (commonDataGridView1.Rows[i].Tag as PurchasePlanDetail).PurchasePlanQuanlity = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);
                                IsSur = 1;//存在
                            }
                        }
                        else
                        {
                            if (p.GoodsBaseInfoId.Id == Convert.ToInt64((commonDataGridView1.Rows[i].Tag as Object[])[7]))
                            {
                                this.commonDataGridView1.Rows[i].Cells[5].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value) + p.PurchasePlanQuanlity;
                                this.commonDataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);

                                object[] obj = new Object[9];
                                obj = commonDataGridView1.Rows[i].Tag as Object[];
                                obj[9] = this.commonDataGridView1.Rows[i].Cells[5].Value;
                                commonDataGridView1.Rows[i].Tag = obj;//this.commonDataGridView1.Rows[i].Cells[5].Value;

                                IsSur = 1;//存在
                            }
                        }
                    }

                    if (IsSur == 0)//不存在 插入一条
                    {
                        long stocknum = opp.GetGoodsQUantityByGoodaId(p.GoodsBaseInfoId.Id);

                        this.commonDataGridView1.Rows.Add(p.GoodsBaseInfoId.GoodsClassCode,
                            p.GoodsBaseInfoId.GoodsName,
                            p.GoodsBaseInfoId.Specifications, p.GoodsBaseInfoId.Material,
                            p.GoodsBaseInfoId.Unit, p.PurchasePlanQuanlity,
                           (stocknum == -1 ? "库存无记录" : stocknum.ToString()),
                        p.PurchasePlanQuanlity, "删除");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = p;
                    }
                }
            }

            //复选框取消选中的时候触发的状态    
            else if (e.ColumnIndex == 0&& Convert.ToBoolean(commonDataGridView2.CurrentRow.Cells[0].EditedFormattedValue) == false)
            {
                //MessageBox.Show("取消");
                IList pdet = opp.GetQuerenDet(this.commonDataGridView2.CurrentRow.Tag as PurchasePlan);

                foreach (PurchasePlanDetail p in pdet)
                {
                    
                    
                    for (int i = 0; i < this.commonDataGridView1.Rows.Count; i++)
                    {
                        if (typeof(PurchasePlanDetail) == this.commonDataGridView1.Rows[i].Tag.GetType())
                        {
                            if (p.GoodsBaseInfoId.Id == (this.commonDataGridView1.Rows[i].Tag as PurchasePlanDetail).GoodsBaseInfoId.Id)
                            {
                                //存在,减去一条数量
                                this.commonDataGridView1.Rows[i].Cells[5].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value) - p.PurchasePlanQuanlity;
                                this.commonDataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);

                                if (Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value) <= 0)
                                    this.commonDataGridView1.Rows.RemoveAt(i);
                                else
                                    (commonDataGridView1.Rows[i].Tag as PurchasePlanDetail).PurchasePlanQuanlity = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);
                               
                            }
                        }
                        else
                        {
                            if (p.GoodsBaseInfoId.Id == Convert.ToInt64((this.commonDataGridView1.Rows[i].Tag as object[])[7]))
                            {
                                this.commonDataGridView1.Rows[i].Cells[5].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value) - p.PurchasePlanQuanlity;
                                this.commonDataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);

                                if (Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value) <= 0)
                                    this.commonDataGridView1.Rows.RemoveAt(i);
                                else
                                {
                                    object[] obj = new Object[9];
                                    obj = commonDataGridView1.Rows[i].Tag as Object[];
                                    obj[9] = this.commonDataGridView1.Rows[i].Cells[5].Value;
                                    commonDataGridView1.Rows[i].Tag = obj;//this.commonDataGridView1.Rows[i].Cells[5].Value;
                                }
                            }
                        
                        }
                    }

                }
            }
           
        }

        
        /// <summary>
        /// 新增货物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SelectGoods selectgoods = new SelectGoods();
            selectgoods.IsChooseAll = 1;
            selectgoods.ShowDialog();
            IList goodslist = selectgoods.ReturnIlist;

            if (goodslist != null && goodslist.Count > 0)
            {
                foreach (Object[] p in goodslist)
                {
                    int count = this.commonDataGridView1.Rows.Count;
                    int IsSur = 0;//是否存在
                    for (int i = 0; i < count; i++)
                    {
                        #region
                        if (typeof(PurchasePlanDetail) == this.commonDataGridView1.Rows[i].Tag.GetType())
                        {
                            if (Convert.ToInt64(p[7]) == (commonDataGridView1.Rows[i].Tag as PurchasePlanDetail).GoodsBaseInfoId.Id)
                            {
                                this.commonDataGridView1.Rows[i].Cells[5].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value) + Convert.ToInt32(p[9]);

                                this.commonDataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);

                                (commonDataGridView1.Rows[i].Tag as PurchasePlanDetail).PurchasePlanQuanlity = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);

                                IsSur = 1;//存在
                            }
                        }
                        else
                        {
                            if (Convert.ToInt64(p[7]) == Convert.ToInt64((commonDataGridView1.Rows[i].Tag as Object[])[7]))
                            {
                                this.commonDataGridView1.Rows[i].Cells[5].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value) + Convert.ToInt32(p[9]);

                                this.commonDataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[5].Value);

                                object[] obj = new Object[9];
                                obj = commonDataGridView1.Rows[i].Tag as Object[];
                                obj[9] = this.commonDataGridView1.Rows[i].Cells[5].Value;
                                commonDataGridView1.Rows[i].Tag = obj;//this.commonDataGridView1.Rows[i].Cells[5].Value;

                                IsSur = 1;//存在
                            }


                        }
                        #endregion
                    }

                    if (IsSur == 0)//不存在 插入一条
                    {
                        long stocknum = opp.GetGoodsQUantityByGoodaId(Convert.ToInt64(p[7]));

                        this.commonDataGridView1.Rows.Add(p[0].ToString(),
                            p[1].ToString(),
                            p[2].ToString(), p[3].ToString(),
                            p[4].ToString(), Convert.ToDouble(p[9]),
                           (stocknum == -1 ? "库存无记录" : stocknum.ToString()),
                        Convert.ToInt64(p[9]), "删除");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = p;
                    }
                }
            }
        }  
            
        

        private void button1_Click(object sender, EventArgs e)
        {


            if ((MessageBox.Show("生成之后不能更改。确定要生成吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                if (IsGoodsNoNum())
                {
                    //PurchaseApply生成一张采购申请单
                    PurchaseApply newpapp = new PurchaseApply();
                    newpapp.PurchaseApplyTime = DateTime.Now.Ticks;
                    newpapp.PurchaseApplyState = (long)PurchaseApply.PurApplyState.weishenhe;
                    newpapp.PurchaseRemark = this.textBox1.Text;
                    newpapp = opp.SavePurchaseApply(newpapp);

                    //PurchaseApplyDetail 一张采购申请单下级联货物数据
                    int count2 = this.commonDataGridView1.Rows.Count;
                    for (int i = 0; i < count2; i++)
                    {
                        if (typeof(PurchasePlanDetail) == this.commonDataGridView1.Rows[i].Tag.GetType())
                        {

                            PurchaseApplyDetail pappd = new PurchaseApplyDetail();
                            GoodsBaseInfo gg = new GoodsBaseInfo();
                            gg.Id = (this.commonDataGridView1.Rows[i].Tag as PurchasePlanDetail).GoodsBaseInfoId.Id;
                            pappd.GoodsBaseInfoId = gg;
                            pappd.PurchaseApplyId = newpapp;
                            pappd.PlanQuanlity = (this.commonDataGridView1.Rows[i].Tag as PurchasePlanDetail).PurchasePlanQuanlity;
                            pappd.ReportQuanlity = Convert.ToInt32(this.commonDataGridView1.Rows[i].Cells[7].Value);
                            pappd.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingdengdaishenheForcaigoufuzeren;
                            opp.SaveOrUpdateEntity(pappd);

                        }
                        else 
                        {
                            PurchaseApplyDetail pappd = new PurchaseApplyDetail();
                            GoodsBaseInfo gg = new GoodsBaseInfo();
                            gg.Id = Convert.ToInt64((this.commonDataGridView1.Rows[i].Tag as Object[])[7]);
                            pappd.GoodsBaseInfoId = gg;
                            pappd.PurchaseApplyId = newpapp;
                            pappd.PlanQuanlity = Convert.ToInt64((this.commonDataGridView1.Rows[i].Tag as Object[])[9]);
                            pappd.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingdengdaishenheForcaigoufuzeren;

                            pappd.ReportQuanlity = Convert.ToInt64(this.commonDataGridView1.Rows[i].Cells[7].Value);
                            opp.SaveOrUpdateEntity(pappd);
                        }
                       
                    }

                    //PurchasePlan 选择的plan更改状态并且插入级联的 PurchaseApplyId
                    int count = this.commonDataGridView2.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        string iftrue = this.commonDataGridView2.Rows[i].Cells[0].Value.ToString();
                        if (iftrue == "True")
                        {
                            //更新PurchasePlan状态
                            PurchasePlan theplan = new PurchasePlan();
                            theplan = this.commonDataGridView2.Rows[i].Tag as PurchasePlan;
                            theplan.PurchasePlanState = (long)PurchasePlan.purPlanState.yijingshengchengpingshen;
                            theplan.PurchaseApplyId = newpapp;
                            opp.SaveOrUpdateEntity(theplan);
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else { MessageBox.Show("有上报数量您为填写。"); }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  

        public bool IsGoodsNoNum()
        {
            //bool bol = true;
            int count = this.commonDataGridView1.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                if (
                    !(
                    (this.commonDataGridView1.Rows[i].Cells[7].Value == null ? 0 : long.Parse(this.commonDataGridView1.Rows[i].Cells[7].Value.ToString())) > 0))
                    return false;
                i++;
            }
            return true;
        }
    }
}
