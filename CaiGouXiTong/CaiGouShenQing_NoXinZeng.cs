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
    public partial class CaiGouShenQing_NoXinZeng : CommonControl.CommonTabPage
    {

        OpPurchase opp = new OpPurchase();

        public CaiGouShenQing_NoXinZeng()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            CaiGouShenQing_New_dialog caiGouShenQingXinJian = new CaiGouShenQing_New_dialog();
            caiGouShenQingXinJian.ShowDialog();
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        public override void reFreshAllControl()
        {
            this.comboBox1.SelectedIndex = 0;
            ShowInGrid(opp.GetAllPurapply());
            base.reFreshAllControl();
        }
        public void ShowInGrid(IList i)
        {
            this.commonDataGridView1.Rows.Clear();
            if (i != null)
            {
                foreach (PurchaseApply o in i)
                {
                    //if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.weishenhe))
                    //{
                    //    this.commonDataGridView1.Rows.Add(false,
                    //        o.Id,
                    //        (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                    //       PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.weishenhe)],
                    //        "查看物品详情");
                    //    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                    //    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                    //        ColorTranslator.FromHtml(PurchaseApply.StateColor[Convert.ToInt64(PurchaseApply.PurApplyState.weishenhe)]);
                    //}

                     if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenShenhe))
                    {
                        this.commonDataGridView1.Rows.Add(false,
                      o.Id,
                      (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                      PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenShenhe)],
                      "查看物品详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                       

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseApply.StateColor[Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenShenhe)]);

                    }

                    //else if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenTuihui))
                    //{
                    //    this.commonDataGridView1.Rows.Add(false,
                    //   o.Id,
                    //   (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                    //  PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenTuihui)],
                    //   "查看物品详情");
                    //    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                    //    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[0].ReadOnly = true;
                    //    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                    //       ColorTranslator.FromHtml(PurchaseApply.StateColor[Convert.ToInt64(PurchaseApply.PurApplyState.caigoufuzerenTuihui)]);
                    //}

                    else if (o.PurchaseApplyState == Convert.ToInt64(PurchaseApply.PurApplyState.zongjingliShenhe))
                    {
                        this.commonDataGridView1.Rows.Add(false,
                       o.Id,
                       (new DateTime(o.PurchaseApplyTime)).ToString("yyy-MM-dd HH:mm:ss"),
                       PurchaseApply.StateName[Convert.ToInt64(PurchaseApply.PurApplyState.zongjingliShenhe)],
                       "查看物品详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
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
            if (e.ColumnIndex == 4 && commonDataGridView1.CurrentCell.Value.ToString() == "查看物品详情")
            {
                if ((this.commonDataGridView1.CurrentRow.Tag as PurchaseApply).PurchaseApplyState == (long)PurchaseApply.PurApplyState.caigoufuzerenShenhe)
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
            ShowInGrid(
                opp.GetSelectpurapply
                (this.dateTimePicker1.Value.Date.Ticks, 
                this.dateTimePicker2.Value.Date.AddDays(1).Ticks,
                 this.comboBox1.SelectedIndex-1));
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
                int count = this.commonDataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToBoolean(this.commonDataGridView1.Rows[i].Cells[0].FormattedValue))
                    {
                        PurchaseApply pur = new PurchaseApply();
                        pur = this.commonDataGridView1.Rows[i].Tag as PurchaseApply;
                        pur.PurchaseApplyState = (long)PurchaseApply.PurApplyState.zongjingliShenhe;
                        opp.SaveOrUpdateEntity(pur);

                        IList detil = opp.GetpurapplydetByapply(pur);

                        if (detil != null)
                        {
                            foreach (PurchaseApplyDetail o in detil)
                            {
                                PurchaseApplyDetail purr = new PurchaseApplyDetail();
                                purr = o;
                                purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.caigoushenqingbeiTuihuiForZongJingLi;
                                opp.SaveOrUpdateEntity(purr); 
                            }
                        }
                    }
                }

                ShowInGrid(opp.GetAllPurapply());

            }
        }


        /// <summary>
        /// 新增按钮
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
                    if (Convert.ToBoolean(this.commonDataGridView1.Rows[i].Cells[0].FormattedValue))
                    {
                        PurchaseApply pur = new PurchaseApply();
                        pur = this.commonDataGridView1.Rows[i].Tag as PurchaseApply;
                        pur.PurchaseApplyState = (long)PurchaseApply.PurApplyState.zongjingliShenhe;
                        opp.SaveOrUpdateEntity(pur);

                        IList detil = opp.GetpurapplydetByapply(pur);

                        if (detil != null)
                        {
                            foreach (PurchaseApplyDetail o in detil)
                            {
                                PurchaseApplyDetail purr = new PurchaseApplyDetail();
                                purr = o;
                                purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.shenqingyitonggudengdaibijiapingshen;
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
