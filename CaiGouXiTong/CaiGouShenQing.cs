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
    public partial class CaiGouShenQing : CommonControl.CommonTabPage
    {
        OpPurchase opp = new OpPurchase();
        public CaiGouShenQing()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            CaiGouShenQing_New_dialog caiGouShenQingXinJian = new CaiGouShenQing_New_dialog();
            caiGouShenQingXinJian.ShowDialog();
            if (caiGouShenQingXinJian.DialogResult == DialogResult.OK)
            {
                ShowInGrid(opp.GetAllPurapply());
            }
        }

        public override void reFreshAllControl()
        {
            this.comboBox1.SelectedIndex = 0;
            ShowInGrid(opp.GetAllPurapply());
            ShowInGrid2();
            base.reFreshAllControl();
        }

        public void ShowInGrid2()
        {
            string sql2 = " select GoodsBaseInfo.GoodsName as 物品数量 ,GoodsBaseInfo.GoodsClassCode as 物品编码 ,GoodsBaseInfo.WaringNum  as 预警数量 ,st.Quan as 库存数量 from  " +
" (select Stock.GoodsBaseInfoID as Gid , SUM(Stock.Quantity) as Quan from Stock where Stock.State = 0 " +
" group by Stock.GoodsBaseInfoID ) st left join GoodsBaseInfo on " +
" GoodsBaseInfo.Id = st.Gid " +
" where GoodsBaseInfo.IsWaring = 1 and GoodsBaseInfo.WaringNum > st.Quan; ";

          DataSet ds = opp.ExecuteSQLReturnDataSet(sql2);
          this.commonDataGridView2.DataSource = ds.Tables[0];

        }

        public void ShowInGrid(IList i)
        {
            this.commonDataGridView1.Rows.Clear();
            if (i != null)
            {
                foreach (PurchaseApply o in i)
                {
                    if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.weishenhe))
                    {
                        this.commonDataGridView1.Rows.Add(false,
                            o.Id,
                            (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                           PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.weishenhe)],
                            "查看物品详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchaseApply.StateColor[Convert.ToInt64(PurchaseApply.PurApplyState.weishenhe)]);
                    }

                    else if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenShenhe))
                    {
                        this.commonDataGridView1.Rows.Add(false,
                      o.Id,
                      (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                      PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenShenhe)],
                      "查看物品详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[0].ReadOnly = true;

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApply.StateColor[Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenShenhe)]);

                    }
                    else if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenTuihui))
                    {
                        this.commonDataGridView1.Rows.Add(false,
                       o.Id,
                       (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                      PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenTuihui)],
                       "查看物品详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[0].ReadOnly = true;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApply.StateColor[Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenTuihui)]);
                    }

                    else if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.zongjingliShenhe))
                    {
                        this.commonDataGridView1.Rows.Add(false,
                       o.Id,
                       (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                       PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.zongjingliShenhe)],
                       "查看物品详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[0].ReadOnly = true;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApply.StateColor[Convert.ToInt64(PurchaseApply.PurApplyState.zongjingliShenhe)]);
                    }
                    else if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.zongjingliTuihui))
                    {
                        this.commonDataGridView1.Rows.Add(false,
                      o.Id,
                      (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                      PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.zongjingliTuihui)],
                      "查看物品详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[0].ReadOnly = true;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApply.StateColor[Convert.ToInt64(PurchaseApply.PurApplyState.zongjingliTuihui)]);
                    }
                }
            }

        }

        private void CaiGouShenQing_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4&&commonDataGridView1.CurrentCell.Value.ToString() == "查看物品详情")
            {
                if ((this.commonDataGridView1.CurrentRow.Tag as PurchaseApply).PurchaseApplyState == (long)PurchaseApply.PurApplyState.weishenhe)
                {
                    CaiGouShenQing_View caiGouShenQing = new CaiGouShenQing_View();
                    caiGouShenQing.Receivepurapply = this.commonDataGridView1.CurrentRow.Tag as PurchaseApply;
                    caiGouShenQing.ShowDialog();
                    ShowInGrid(opp.GetAllPurapply());
                }
                else
                {
                    CaiGouShenQing_View_NoPiZhun caiGouShenQing = new CaiGouShenQing_View_NoPiZhun();
                    caiGouShenQing.Receivepurapply = this.commonDataGridView1.CurrentRow.Tag as PurchaseApply;
                    caiGouShenQing.ShowDialog();
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowInGrid(opp.GetSelectpurapply(
                this.dateTimePicker1.Value.Date.Ticks, 
                this.dateTimePicker3.Value.Date.AddDays(1).Ticks, 
                this.comboBox1.SelectedIndex-1));
        }

        /// <summary>
        /// 批准勾选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("批准之后不能更改。确定要批准吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                 int count = this.commonDataGridView1.Rows.Count;
                 for (int i = 0; i < count; i++)
                 {
                     if(Convert.ToBoolean(this.commonDataGridView1.Rows[i].Cells[0].FormattedValue))
                     {
                         PurchaseApply pur = new PurchaseApply();
                         pur = this.commonDataGridView1.Rows[i].Tag as PurchaseApply;
                         pur.PurchaseApplyState = (long)PurchaseApply.PurApplyState.caigoufuzerenShenhe;
                         opp.SaveOrUpdateEntity(pur);

                         IList detil = opp.GetpurapplydetByapply(pur);

                         if(detil != null)
                         {
                             foreach (PurchaseApplyDetail o in detil)
                             {
                                 PurchaseApplyDetail purr = new PurchaseApplyDetail();
                                 purr = o;
                                 purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingdengdaishenheForzongjingli;
                                 opp.SaveOrUpdateEntity(purr);
                             }
                         }
                     }
                 }

                ShowInGrid(opp.GetAllPurapply());

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("退回之后不能更改。确定要退回吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                int count = this.commonDataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToBoolean(this.commonDataGridView1.Rows[i].Cells[0].FormattedValue))
                    {
                        PurchaseApply pur = new PurchaseApply();
                        pur = this.commonDataGridView1.Rows[i].Tag as PurchaseApply;
                        pur.PurchaseApplyState = (long)PurchaseApply.PurApplyState.caigoufuzerenTuihui;
                        opp.SaveOrUpdateEntity(pur);


                        IList detil = opp.GetpurapplydetByapply(pur);

                        if (detil != null)
                        {
                            foreach (PurchaseApplyDetail o in detil)
                            {
                                PurchaseApplyDetail purr = new PurchaseApplyDetail();
                                purr = o;
                                purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingbeiTuihuiForcaigouFuzeRen;
                                opp.SaveOrUpdateEntity(purr);
                            }
                        }
                    }
                }

                ShowInGrid(opp.GetAllPurapply());

            }
        }

    }
}
