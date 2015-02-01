using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CaiGouXiTong.Service;
using CommonMethod;
using EntityClassLibrary;
using System.Collections;

namespace CaiGouXiTong
{
    public partial class CaiGouHeTong_View_dialog : Form
    {


        OpPurchase opp = new OpPurchase();
        ToChineseNum tochinese = new ToChineseNum();
        float SunMoney = 0;

        PurchaseContract receivpurcon;
        public PurchaseContract Receivpurcon
        {
            get { return receivpurcon; }
            set { receivpurcon = value; }
        }
        

        public CaiGouHeTong_View_dialog()
        {
            InitializeComponent();
            Receivpurcon = new PurchaseContract();
        }
        public CaiGouHeTong_View_dialog(string str)
        {
            this.Text = str;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CaiGouHeTong_View_dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            IList ReceivePurappdetList = opp.GetPurappByPurConID(Receivpurcon.Id);


            this.textBox1.Text = (ReceivePurappdetList[0] as PurchaseApplyDetail).SupplierInfoId.SupplierName;
            this.textBox2.Text = "新能装备股份有限公司";

            foreach (PurchaseApplyDetail o in ReceivePurappdetList)
            {
                this.commonDataGridView1.Rows.Add(
                    o.GoodsBaseInfoId.GoodsClassCode, 
                    o.GoodsBaseInfoId.GoodsName,
                    o.GoodsBaseInfoId.Specifications,
                    o.GoodsBaseInfoId.Material,
                    o.GoodsBaseInfoId.Unit,
                    o.ReportQuanlity.ToString(),
                    o.GoodsSingleAmount.ToString() + "元",
                    (o.GoodsSingleAmount * o.ReportQuanlity).ToString() + "元",
                    o.Remarks);
                this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                SunMoney = SunMoney + o.GoodsSingleAmount * o.ReportQuanlity;

            }

            this.textBox25.Text = SunMoney.ToString();
            this.textBox26.Text = tochinese.GetChineseNum(SunMoney);

              this.textBox3.Text=Receivpurcon.PurchaseContractCode;
              this.textBox4.Text=Receivpurcon.PurchaseContractAddress;
             this.dateTimePicker1.Value = new DateTime(Receivpurcon.PurchaseContractTime);//.ToString("yyyy年MM月dd日");

             this.textBox5.Text = Receivpurcon.SupName ;
            this.textBox6.Text=Receivpurcon.SupAddress ;
            this.textBox7.Text=Receivpurcon.SupPersonName ;
             this.textBox8.Text= Receivpurcon.SupEntrustPersonName ;
             this.textBox9.Text= Receivpurcon.SupPhone ;
            this.textBox10.Text= Receivpurcon.SupTaxCode  ;
            this.textBox11.Text= Receivpurcon.SupBankName ;
             this.textBox12.Text= Receivpurcon.SupBankCode ;
             this.textBox13.Text= Receivpurcon.SupZioCode ;


             this.textBox14.Text= Receivpurcon.RecName ;
             this.textBox15.Text= Receivpurcon.RecAddress ;
            this.textBox16.Text= Receivpurcon.RecPersonName ;
             this.textBox17.Text= Receivpurcon.RecEntrustPersonName ;
             this.textBox18.Text = Receivpurcon.RecPhone ;
            this.textBox19.Text = Receivpurcon.RecTaxCode ;
             this.textBox20.Text= Receivpurcon.RecBankName ;
            this.textBox21.Text= Receivpurcon.RecBankCode; 
             this.textBox22.Text= Receivpurcon.RecZioCode ;

             this.textBox23.Text = Receivpurcon.HandlePerson ;
             this.textBox24.Text = Receivpurcon.HandleOffice ;
             this.dateTimePicker2.Value = new DateTime(Receivpurcon.HandleTime);

        }
    }
}
