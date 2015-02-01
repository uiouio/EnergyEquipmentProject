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
    public partial class BiJiaPingShen_BiJiaView : Form
    {
        PurchaseApplyDetail receivePurdet;

        OpPurchase opp = new OpPurchase();
     
        public PurchaseApplyDetail ReceivePurdet
        {
            get { return receivePurdet; }
            set { receivePurdet = value; }
        }
        

        public BiJiaPingShen_BiJiaView()
        {
            InitializeComponent();
            ReceivePurdet = new PurchaseApplyDetail();
        }


        UserInfo theUser;

        public UserInfo TheUser
        {
            get { return theUser; }
            set { theUser = value; }
        }

        private void BiJiaPingShen_BiJiaView_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        public void loadForm()
        {
            this.textBox7.Text = ReceivePurdet.GoodsBaseInfoId.GoodsName;
            this.textBox14.Text = ReceivePurdet.GoodsBaseInfoId.GoodsClassCode;
            this.textBox8.Text = ReceivePurdet.ReportQuanlity.ToString();
            this.textBox16.Text = ReceivePurdet.Remarks;

            IList i = opp.GetWaitSuppsByPurappDetId(ReceivePurdet.Id);
            if (i != null)
            {

                foreach (WaitChooseSuppliers o in i)
                {
                    if (o.IsAdvise == 1)
                    {
                        this.textBox9.Text = o.SupplierInfoId.SupplierName;
                    }

                    this.commonDataGridView1.Rows.Add(o.SupplierInfoId.SupplierName, o.Money * ReceivePurdet.ReportQuanlity);
                }
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            BiJiaPingShen_New_dialog chenge = new BiJiaPingShen_New_dialog();

            chenge.ReceivePurdet = ReceivePurdet;
            chenge.User = TheUser;
            chenge.ShowDialog();

            if(chenge.DialogResult  == DialogResult.OK)
            {
                loadForm();
            }
            

        }

       

      
    }
}
