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
    public partial class BiJiaPingShen_New_dialog : Form
    {

        UserInfo user;

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }

        Supplier_Goods newsupg = new Supplier_Goods();
        OpPurchase opp = new OpPurchase();

        PurchaseApplyDetail receivePurdet;

        
       // SupplierInfo receiveNewSupps = new SupplierInfo();
        public PurchaseApplyDetail ReceivePurdet
        {
            get { return receivePurdet; }
            set { receivePurdet = value; }
        }

        SupplierInfo suportsupps = new SupplierInfo();
        public BiJiaPingShen_New_dialog()
        {
            InitializeComponent();
            ReceivePurdet = new PurchaseApplyDetail();
            User = new UserInfo();
        }

    
        private void button3_Click(object sender, EventArgs e)
        {
            BiJiaPingShen_New_GongHuoShang newBiJia = new BiJiaPingShen_New_GongHuoShang();
            newBiJia.ShowDialog();
            if(newBiJia.DialogResult == DialogResult.OK&&newBiJia.SendSupps.SupplierInfoId != null)
            {
                
                newsupg = newBiJia.SendSupps;
                this.commonDataGridView1.Rows.Add(false, newsupg.SupplierInfoId.SupplierName, newsupg.Unit_Price,
                        newsupg.Unit_Price * ReceivePurdet.ReportQuanlity, "选为建议供货商", "查看");
                newsupg.GoodsBaseInfoID = ReceivePurdet.GoodsBaseInfoId;
                this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = newsupg;
            }
        }

        private void BiJiaPingShen_New_dialog_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = ReceivePurdet.GoodsBaseInfoId.GoodsClassCode;
            this.textBox3.Text = ReceivePurdet.GoodsBaseInfoId.GoodsName;
            this.textBox4.Text = ReceivePurdet.GoodsBaseInfoId.Specifications;
            this.textBox5.Text = ReceivePurdet.GoodsBaseInfoId.Unit;
            ShowInGrid(opp.GetsuppsByGoodsIdInSupps_goods(ReceivePurdet.GoodsBaseInfoId.Id));
        }
        public void ShowInGrid(IList supps)
        {
            if(supps != null&&supps.Count>0)
            {
                suportsupps = (supps[0] as Supplier_Goods).SupplierInfoId;
       
                foreach(Supplier_Goods o in supps)
                {
                    this.commonDataGridView1.Rows.Add(false, o.SupplierInfoId.SupplierName, o.Unit_Price,
                       o.Unit_Price*ReceivePurdet.ReportQuanlity, "选为建议供货商", "查看");
                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o; 
                }
            }
 
        
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex==4&&this.commonDataGridView1.CurrentCell.Value.ToString() == "选为建议供货商")
            {
                 newsupg = this.commonDataGridView1.CurrentRow.Tag as Supplier_Goods;
                 suportsupps = (this.commonDataGridView1.CurrentRow.Tag as Supplier_Goods).SupplierInfoId;
                 this.textBox1.Text = suportsupps.SupplierName;
                 this.commonDataGridView1.CurrentRow.Cells[0].Value = true;
                 
            }
            if (e.ColumnIndex == 5&&this.commonDataGridView1.CurrentCell.Value.ToString() == "查看")
            {
                GongHuoShang_Detail_dialog ghsNew = new GongHuoShang_Detail_dialog();
                ghsNew.Currentsupp = (this.commonDataGridView1.CurrentRow.Tag as Supplier_Goods).SupplierInfoId;
                ghsNew.User = User;
                ghsNew.Ischakan = 1;
                ghsNew.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.commonDataGridView1.Rows.Count == 0 || this.textBox1.Text == "")
            {
                MessageBox.Show("请添加供货商并且选择建议供货商。");
            }
            else
            {
                if (MessageBox.Show("确定之后不能更改，您确定之后要这么做吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //是否之前有值
                    IList ii = opp.GetPurdetinWaitsuppsBypurdet(ReceivePurdet);
                    if (ii != null && ii.Count>0 )
                    {
                        foreach(WaitChooseSuppliers o in ii)
                        {
                            o.State = 1;
                            opp.SaveOrUpdateEntity(o);
                        }
                    
                    }



                    int count = this.commonDataGridView1.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (Convert.ToBoolean(this.commonDataGridView1.Rows[i].Cells[0].Value))
                        {
                            if ((this.commonDataGridView1.Rows[i].Tag as Supplier_Goods).SupplierInfoId == suportsupps)
                            {
                                WaitChooseSuppliers wupp = new WaitChooseSuppliers();
                                wupp.PurchaseApplyDetailId = ReceivePurdet;
                                wupp.SupplierInfoId = (this.commonDataGridView1.Rows[i].Tag as Supplier_Goods).SupplierInfoId;
                                wupp.Money = (this.commonDataGridView1.Rows[i].Tag as Supplier_Goods).Unit_Price;
                                wupp.IsAdvise = 1;
                                opp.SaveOrUpdateEntity(wupp);
                            }
                            else 
                            {
                                WaitChooseSuppliers wupp = new WaitChooseSuppliers();
                                wupp.PurchaseApplyDetailId = ReceivePurdet;
                                wupp.SupplierInfoId = (this.commonDataGridView1.Rows[i].Tag as Supplier_Goods).SupplierInfoId;
                                wupp.Money = (this.commonDataGridView1.Rows[i].Tag as Supplier_Goods).Unit_Price;
                                opp.SaveOrUpdateEntity(wupp);

                            }
                           
                        }
                    }


                    PurchaseApplyDetail purr = new PurchaseApplyDetail();
                    purr = ReceivePurdet;
                    purr.SupplierInfoId = suportsupps;
                    purr.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.shengchengbijiapingshendengdaiquerenhetong;
                    purr.GoodsSingleAmount = newsupg.Unit_Price;
                    purr.Remarks = this.textBox6.Text;
                    opp.SaveOrUpdateEntity(purr);
                    this.DialogResult = DialogResult.OK;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
