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
    public partial class CaiGouHeTong_NoXinZeng : CommonControl.CommonTabPage
    {

        OpPurchase opp = new OpPurchase();

        public CaiGouHeTong_NoXinZeng()
        {
            InitializeComponent();
        }
        public override void reFreshAllControl()
        {
            ShowInGrid(opp.GetAllpurCont());
            base.reFreshAllControl();
        }

        public void ShowInGrid(IList i)
        {
            this.commonDataGridView1.Rows.Clear();
            if (i != null)
            {

                foreach (PurchaseContract o in i)
                {
                    if (o.PurchaseContractState == (long)PurchaseContract.PurConState.daishenhe)
                    {
                        this.commonDataGridView1.Rows.Add(
                            false,
                            o.PurchaseContractCode,
                            o.SupplierInfoId.SupplierName,
                            PurchaseContract.StateName[(long)PurchaseContract.PurConState.daishenhe],
                            "查看详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                            ColorTranslator.FromHtml(PurchaseContract.StateColor[(long)PurchaseContract.PurConState.daishenhe]);

                    }
                    else if (o.PurchaseContractState == (long)PurchaseContract.PurConState.tongguo)
                    {
                        this.commonDataGridView1.Rows.Add(
                            false,
                            o.PurchaseContractCode,
                            o.SupplierInfoId.SupplierName,
                                PurchaseContract.StateName[(long)PurchaseContract.PurConState.tongguo],
                            "查看详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[0].ReadOnly = true;

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseContract.StateColor[(long)PurchaseContract.PurConState.tongguo]);

                    }
                    else if (o.PurchaseContractState == (long)PurchaseContract.PurConState.tuihi)
                    {
                        this.commonDataGridView1.Rows.Add(
                            false,
                            o.PurchaseContractCode,
                            o.SupplierInfoId.SupplierName,
                             PurchaseContract.StateName[(long)PurchaseContract.PurConState.tuihi],
                            "查看详情");
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[0].ReadOnly = true;
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Cells[3].Style.ForeColor =
                           ColorTranslator.FromHtml(PurchaseContract.StateColor[(long)PurchaseContract.PurConState.tuihi]);

                    }
                }
            }
        }

        private void CaiGouHeTong_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4&&this.commonDataGridView1.CurrentCell.Value.ToString() == "查看详情")
            {
                CaiGouHeTong_View_dialog caiGouHeTongChaKan = new CaiGouHeTong_View_dialog();
                caiGouHeTongChaKan.Receivpurcon = this.commonDataGridView1.CurrentRow.Tag as PurchaseContract;
                caiGouHeTongChaKan.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowInGrid(opp.GetSelectCont(this.textBox1.Text, this.textBox3.Text,this.comboBox1.SelectedIndex-1));
        }
        /// <summary>
        /// 批准勾选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("批准之后不能更改。确定要批准吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                int count = this.commonDataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToBoolean(this.commonDataGridView1.Rows[i].Cells[0].FormattedValue))
                    {
                        PurchaseContract pur = new PurchaseContract();
                        pur = this.commonDataGridView1.Rows[i].Tag as PurchaseContract;
                        pur.PurchaseContractState = (long)PurchaseContract.PurConState.tongguo;
                        opp.SaveOrUpdateEntity(pur);

                        IList detil = opp.GetPurappByPurConID(pur.Id);

                        if (detil != null)
                        {
                            foreach (PurchaseApplyDetail o in detil)
                            {
                                PurchaseApplyDetail purr = new PurchaseApplyDetail();
                                purr = o;
                                purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.hetongweitongguo;
                                opp.SaveOrUpdateEntity(purr);
                            }
                        }
                    }
                }

                ShowInGrid(opp.GetAllpurCont());

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
                        PurchaseContract pur = new PurchaseContract();
                        pur = this.commonDataGridView1.Rows[i].Tag as PurchaseContract;
                        pur.PurchaseContractState = (long)PurchaseContract.PurConState.tuihi;
                        opp.SaveOrUpdateEntity(pur);

                        IList detil = opp.GetPurappByPurConID(pur.Id);

                        if (detil != null)
                        {
                            foreach (PurchaseApplyDetail o in detil)
                            {
                                PurchaseApplyDetail purr = new PurchaseApplyDetail();
                                purr = o;
                                purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.hetongshenhebeituihui;
                                opp.SaveOrUpdateEntity(purr);
                            }
                        }
                    }
                }

                ShowInGrid(opp.GetAllpurCont());

            }
        }

        
    }
}
