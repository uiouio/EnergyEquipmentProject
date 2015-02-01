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
    public partial class CaiGouJiHua_View_dialog : Form
    {

       
        int Ischanged = 0;

        OpPurchase opp = new OpPurchase();
        private PurchasePlan receiveplan;
        public PurchasePlan Receiveplan
        {
            get { return receiveplan; }
            set { receiveplan = value; }
        }


        public CaiGouJiHua_View_dialog()
        {
            InitializeComponent();
            Receiveplan = new PurchasePlan();
        }

        private void CaiGouQingDan_View_dialog_Load(object sender, EventArgs e)
        {
            if (Receiveplan.PurchaseApplyTime != 0)
            {
                this.textBox1.Text = Receiveplan.UserId.Name;
                this.textBox2.Text = Receiveplan.UserId.Dept == null ? "" : Receiveplan.UserId.Dept.DepartmentName;
                this.textBox3.Text = new DateTime(Receiveplan.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss");
                this.textBox5.Text = Receiveplan.PurchaseReplayRemark;
                this.textBox6.Text = Receiveplan.PurchaseRemark;
                this.textBox4.Text = new DateTime(Receiveplan.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss");
                ShoeInGrid(opp.Getpurdet(Receiveplan));
            }
        }

        public void ShoeInGrid(IList list)
        {
            if (list != null)
            {
                int i = 0;
                foreach (PurchasePlanDetail p in list)
                {
                    if (p.PurchasePlanDetailState == (long)PurchasePlanDetail.PurplanDetSta.Weichuli)
                    {
                        this.commonDataGridView1.Rows.Add(i + 1, p.GoodsBaseInfoId.GoodsClassCode, p.GoodsBaseInfoId.GoodsName,
                              p.GoodsBaseInfoId.Specifications,
                              p.GoodsBaseInfoId.Material, p.GoodsBaseInfoId.Unit, p.PurchasePlanQuanlity,
                              "未处理", "退回");
                        p.PurchasePlanDetailState = (long)PurchasePlanDetail.PurplanDetSta.Queren;
                        this.commonDataGridView1.Rows[i].Tag = p;

                    }
                    else if (p.PurchasePlanDetailState == (long)PurchasePlanDetail.PurplanDetSta.TuiHui)
                    {
                        this.commonDataGridView1.Rows.Add(i + 1, p.GoodsBaseInfoId.GoodsClassCode, p.GoodsBaseInfoId.GoodsName,
                            p.GoodsBaseInfoId.Specifications,
                            p.GoodsBaseInfoId.Material, p.GoodsBaseInfoId.Unit, p.PurchasePlanQuanlity,
                            "已退回", "");
                        this.commonDataGridView1.Rows[i].Tag = p;

                    }
                    else if (p.PurchasePlanDetailState == (long)PurchasePlanDetail.PurplanDetSta.Queren)
                    {
                        this.commonDataGridView1.Rows.Add(i + 1, p.GoodsBaseInfoId.GoodsClassCode, p.GoodsBaseInfoId.GoodsName,
                         p.GoodsBaseInfoId.Specifications,
                         p.GoodsBaseInfoId.Material, p.GoodsBaseInfoId.Unit, p.PurchasePlanQuanlity,
                         "已确认", "");
                        this.commonDataGridView1.Rows[i].Tag = p;

                    }
                    i++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Receiveplan.PurchasePlanState == (long)PurchasePlan.purPlanState.Daichuli)
            {
                if (Ischanged < this.commonDataGridView1.Rows.Count && Ischanged != 0)
                {
                    if ((MessageBox.Show("确定之后不能更改。", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
                    {
                        PurchasePlan theplan = new PurchasePlan();
                        theplan = Receiveplan;
                        theplan.PurchasePlanState = (long)PurchasePlan.purPlanState.Bufenshengchengshenqing;
                        theplan.PurchaseReplayRemark = this.textBox5.Text;
                        theplan = opp.SaveOrUpdateEntity(theplan) as PurchasePlan;

                        int count = this.commonDataGridView1.Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            PurchasePlanDetail pur = this.commonDataGridView1.Rows[i].Tag as PurchasePlanDetail;
                            pur.PurchasePlanId = theplan;
                            opp.SaveOrUpdateEntity(pur);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (Ischanged == 0)
                {

                    if ((MessageBox.Show("确定之后不能更改。", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
                    {
                        PurchasePlan theplan = new PurchasePlan();
                        theplan = Receiveplan;
                        theplan.PurchasePlanState = (long)PurchasePlan.purPlanState.Quanbushenchengshenqing;
                        theplan.PurchaseReplayRemark = this.textBox5.Text;
                        theplan = opp.SaveOrUpdateEntity(theplan) as PurchasePlan;

                        int count = this.commonDataGridView1.Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            PurchasePlanDetail pur = this.commonDataGridView1.Rows[i].Tag as PurchasePlanDetail;
                            pur.PurchasePlanDetailState = (long)PurchasePlanDetail.PurplanDetSta.Queren;
                            pur.PurchasePlanId = theplan;
                            opp.SaveOrUpdateEntity(pur);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (Ischanged == this.commonDataGridView1.Rows.Count)
                {


                    if ((MessageBox.Show("确定之后不能更改。", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
                    {
                        PurchasePlan theplan = new PurchasePlan();
                        theplan = Receiveplan;
                        theplan.PurchasePlanState = (long)PurchasePlan.purPlanState.quanbutuihui;
                        theplan.PurchaseReplayRemark = this.textBox5.Text;
                        theplan = opp.SaveOrUpdateEntity(theplan) as PurchasePlan;

                        int count = this.commonDataGridView1.Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            PurchasePlanDetail pur = this.commonDataGridView1.Rows[i].Tag as PurchasePlanDetail;
                            pur.PurchasePlanId = theplan;
                            opp.SaveOrUpdateEntity(pur);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                
                }
            }

            this.Close();
        }
        

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8&&this.commonDataGridView1.CurrentCell.Value.ToString() == "退回")
            {
                Ischanged++;
                PurchasePlanDetail p = new PurchasePlanDetail(); 
                p = this.commonDataGridView1.CurrentRow.Tag as PurchasePlanDetail;
                p.PurchasePlanDetailState = (long)PurchasePlanDetail.PurplanDetSta.TuiHui;
                this.commonDataGridView1.CurrentRow.Tag = p;
                this.commonDataGridView1.CurrentRow.Cells[7].Value = "已退回";
                this.commonDataGridView1.CurrentRow.Cells[8].Value = "";
            
            }
        }
    }
}
