using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CaiGouXiTong.Service;
using System.Collections;

namespace CaiGouXiTong
{
    public partial class CaiGouJiHua_View_dialog_NoTuiHui : Form
    {
        OpPurchase opp = new OpPurchase();

        private PurchasePlan receiveplan;

        public PurchasePlan Receiveplan
        {
            get { return receiveplan; }
            set { receiveplan = value; }
        }

        public CaiGouJiHua_View_dialog_NoTuiHui()
        {
            InitializeComponent();
            Receiveplan = new PurchasePlan();
        }

        private void CaiGouJiHua_View_dialog_NoTuiHui_Load(object sender, EventArgs e)
        {
            if (Receiveplan != null)
            {
                this.textBox1.Text = Receiveplan.UserId.Name;
                this.textBox2.Text = Receiveplan.UserId.Dept == null ? "" : Receiveplan.UserId.Dept.DepartmentName;
                this.textBox3.Text = new DateTime(Receiveplan.PurchaseNeedTime).ToString("yyyy-MM-dd HH:mm:ss");
                this.textBox4.Text = Receiveplan.PurchaseReplayRemark;
                this.textBox5.Text = Receiveplan.PurchaseRemark;
                this.textBox6.Text = new DateTime(Receiveplan.PurchaseApplyTime).ToString("yyyy-MM-dd HH:mm:ss");
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
                        this.commonDataGridView1.Rows.Add(i, p.GoodsBaseInfoId.GoodsClassCode, p.GoodsBaseInfoId.GoodsName,
                            p.GoodsBaseInfoId.Specifications,
                            p.GoodsBaseInfoId.Material, p.GoodsBaseInfoId.Unit, p.PurchasePlanQuanlity,
                            "未处理");

                   else if (p.PurchasePlanDetailState == (long)PurchasePlanDetail.PurplanDetSta.TuiHui)
                        this.commonDataGridView1.Rows.Add(i, p.GoodsBaseInfoId.GoodsClassCode, p.GoodsBaseInfoId.GoodsName,
                            p.GoodsBaseInfoId.Specifications,
                            p.GoodsBaseInfoId.Material, p.GoodsBaseInfoId.Unit, p.PurchasePlanQuanlity,
                            "已退回");

                    else if (p.PurchasePlanDetailState == (long)PurchasePlanDetail.PurplanDetSta.Queren)
                        this.commonDataGridView1.Rows.Add(i, p.GoodsBaseInfoId.GoodsClassCode, p.GoodsBaseInfoId.GoodsName,
                        p.GoodsBaseInfoId.Specifications,
                        p.GoodsBaseInfoId.Material, p.GoodsBaseInfoId.Unit, p.PurchasePlanQuanlity,
                        "已确认");

                    i++;
                }
            }
        }

      

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (commonDataGridView1.CurrentCell.Value.ToString() == "退回")
            {
                CaiGouJiHua_TuiHuiYuanYin cgjhThyy = new CaiGouJiHua_TuiHuiYuanYin();
                cgjhThyy.ShowDialog();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
