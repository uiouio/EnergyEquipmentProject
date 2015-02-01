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
    public partial class CaiGouShenQing_NoPiZhun : CommonControl.CommonTabPage
    {

        OpPurchase opp = new OpPurchase();
        public CaiGouShenQing_NoPiZhun()
        {
            InitializeComponent();
        }
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


        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            CaiGouShenQing_New_dialog caiGouShenQingXinJian = new CaiGouShenQing_New_dialog();
            caiGouShenQingXinJian.ShowDialog();
            if(caiGouShenQingXinJian.DialogResult == DialogResult.OK)
            {
                ShowInGrid(opp.GetAllPurapply());
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
                CaiGouShenQing_View_NoPiZhun cgsqnopizhun = new CaiGouShenQing_View_NoPiZhun();
                cgsqnopizhun.Receivepurapply = this.commonDataGridView1.CurrentRow.Tag as PurchaseApply;
                cgsqnopizhun.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowInGrid(
                opp.GetSelectpurapply(
                this.dateTimePicker1.Value.Date.Ticks, 
                this.dateTimePicker3.Value.Date.AddDays(1).Ticks, 
                this.comboBox1.SelectedIndex-1));
        }
    }
}
