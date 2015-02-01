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
    public partial class CaiGouHeTong : CommonControl.CommonTabPage
    {
        OpPurchase opp = new OpPurchase();

        public CaiGouHeTong()
        {
            InitializeComponent();
        }


        public override void reFreshAllControl()
        {
            this.comboBox1.SelectedIndex = 0;
            ShowInGrid(opp.GetAllpurCont());
            base.reFreshAllControl();
        }

        public void ShowInGrid(IList i)
        {
            this.commonDataGridView1.Rows.Clear();
            if(i != null)
            { 
                
                foreach(PurchaseContract o in i)
                {
                    if(o.PurchaseContractState == (long)PurchaseContract.PurConState.daishenhe)
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

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            CaiGouHeTong_New_HeTong newHetong = new CaiGouHeTong_New_HeTong();
            newHetong.ShowDialog();
            ShowInGrid(opp.GetAllpurCont());

        }

        private void commonDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4&&this.commonDataGridView1.CurrentCell.Value.ToString() == "查看详情")
            {
                CaiGouHeTong_View_dialog caiht = new CaiGouHeTong_View_dialog();
                caiht.Receivpurcon = this.commonDataGridView1.CurrentRow.Tag as PurchaseContract;
                caiht.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowInGrid(opp.GetSelectCont(this.textBox1.Text,this.textBox3.Text,this.comboBox1.SelectedIndex -1));
        }
    }
}
