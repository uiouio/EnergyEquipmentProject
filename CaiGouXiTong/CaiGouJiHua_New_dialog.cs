using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonWindow;
using System.Collections;
using EntityClassLibrary;
using CaiGouXiTong.Service;

namespace CaiGouXiTong
{
    public partial class CaiGouJiHua_New_dialog :CommonControl.BaseForm
    {
        OpPurchase opp = new OpPurchase();
        UserInfo user;
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
        IList goodslist;
        public CaiGouJiHua_New_dialog()
        {
            InitializeComponent();
            User = new UserInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //在选择窗口中选择物品
            SelectGoods selectgoods = new SelectGoods();
            selectgoods.IsChooseAll = 1;
            selectgoods.ShowDialog();
            goodslist = selectgoods.ReturnIlist;

            //插入表格中
            InsertIntoGrid();

        }

        private void CaiGouShenQing_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = user.Name;
            if(user.Dept != null)
            this.textBox3.Text = user.Dept.DepartmentName;
        }

        /// <summary>
        /// 提取从list中提取数据展示在grid表中
        /// </summary>
        public void InsertIntoGrid()
        {
            
            if (goodslist != null)
            {   
                
                foreach(object[] o in goodslist)
                {

                    this.commonDataGridView1.Rows.Add(
                         (this.commonDataGridView1.Rows.Count+1).ToString(),
                        o[0].ToString(),
                        o[1].ToString(),
                        o[2].ToString(), 
                        o[3].ToString(), 
                        o[4].ToString(),
                        o[9].ToString(),
                        "删除");

                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                    
                }
            
            }
        }

        
        /// <summary>
        /// 点击删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //点击删除时候做的操作
           if( e.ColumnIndex == 7&&this.commonDataGridView1.CurrentCell.Value.ToString() == "删除")
            {
               this.commonDataGridView1.Rows.Remove(this.commonDataGridView1.CurrentRow);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.commonDataGridView1.Rows.Count > 0)
            {
                //把整个单号添加到PurchasePlan表中
                SaveInPurchasePlan();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("您未选择货物！");
            }

            
        }

        public void SaveInPurchasePlan()
        {
            PurchasePlan p = new PurchasePlan();
            p.UserId = User;
            p.PurchaseApplyTime = DateTime.Now.Ticks;
            p.PurchaseNeedTime = this.dateTimePicker2.Value.Ticks;
            p.PurchaseRemark = this.textBox2.Text;
            p.PurchasePlanState = (long)PurchasePlan.purPlanState.Daichuli;

            PurchasePlan pl = opp.SavePurchasePlan(p);
            //把每一条数据添加到PurchasePlanDetail
            SaveInPurchasePlanDetail(pl);

        }

        public void SaveInPurchasePlanDetail(PurchasePlan pp)
        {
            int count  = this.commonDataGridView1.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                PurchasePlanDetail purpdet = new PurchasePlanDetail();
                purpdet.PurchasePlanId = pp;
                Object[] obj = this.commonDataGridView1.Rows[i].Tag as object[];
                    GoodsBaseInfo gg = new GoodsBaseInfo();
                    gg.Id = long.Parse(obj[7].ToString());
                purpdet.GoodsBaseInfoId = gg;
                purpdet.PurchasePlanQuanlity = long.Parse(this.commonDataGridView1.Rows[i].Cells[6].Value.ToString());
                purpdet.PurchasePlanDetailState = (long)PurchasePlanDetail.PurplanDetSta.Weichuli;
                opp.SavePurPlanDet(purpdet);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
