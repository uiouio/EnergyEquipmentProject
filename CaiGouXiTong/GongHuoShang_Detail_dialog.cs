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
    public partial class GongHuoShang_Detail_dialog : CommonControl.BaseForm
    {


        int ischakan;

        public int Ischakan
        {
            get { return ischakan; }
            set { ischakan = value; }
        }
        OpSupplierInfo oo = new OpSupplierInfo();
        OpPurchase opp = new OpPurchase();
       
        UserInfo user;
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
        public int i = 0;
        private SupplierInfo currentsupp;
        public SupplierInfo Currentsupp
        {
            get { return currentsupp; }
            set { currentsupp = value; }
        }

        public GongHuoShang_Detail_dialog()
        {
            InitializeComponent();
            User = new UserInfo();
            Currentsupp = new SupplierInfo();
            ischakan = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GongHuoShangXinYongJiLu_New_dialog gongHuoShangXinYongXinJian = new GongHuoShangXinYongJiLu_New_dialog();
            gongHuoShangXinYongXinJian.ReceiveSupps = Currentsupp;
            gongHuoShangXinYongXinJian.ReceiveUserInfo = User;
            gongHuoShangXinYongXinJian.ShowDialog();
            if(gongHuoShangXinYongXinJian.DialogResult == DialogResult.OK)
            {
                ShowInGrid1(opp.GetcreditFromsuppcreBySuppid(Currentsupp.Id)); 
            }
        }

        private void GongHuoShang_Detail_dialog_Load(object sender, EventArgs e)
        {
            if(Ischakan == 1)
            {

                this.button1.Visible = false;
            }
            
            this.textBox1.Text = Currentsupp.SupplierName;
            this.textBox2.Text = Currentsupp.SupplierAddress;
            this.textBox7.Text = Currentsupp.SupplierZioCode;
            this.textBox10.Text = Currentsupp.SupplierContactMan;
            this.comboBox1.Text = Currentsupp.SupplierSex;
            this.textBox11.Text = Currentsupp.SupplierPhone;
            this.textBox8.Text = Currentsupp.SupplierContactManMail;
            this.textBox4.Text = Currentsupp.Remark;


            ShowInGrid2(opp.GetsgoodsBySuppsIdInSupps_goods(Currentsupp.Id));

            ShowInGrid1(opp.GetcreditFromsuppcreBySuppid(Currentsupp.Id));

        }

        public void SetTextActive()
        {
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.textBox7.Enabled = true;
            this.textBox8.Enabled = true;
            this.textBox10.Enabled = true;
            this.textBox11.Enabled = true;
            this.comboBox1.Enabled = true;
        }
        public void SetTextUnActive()
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox8.Enabled = false;
            this.textBox10.Enabled = false;
            this.textBox11.Enabled = false;
            this.comboBox1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.button4.Enabled = true;
            SetTextActive();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Currentsupp.SupplierName = this.textBox1.Text;
            Currentsupp.SupplierAddress = this.textBox2.Text;
            Currentsupp.SupplierZioCode = this.textBox7.Text;
            Currentsupp.SupplierContactMan = this.textBox10.Text;
            Currentsupp.SupplierSex = this.comboBox1.Text;
            Currentsupp.SupplierPhone = this.textBox11.Text;
            Currentsupp.SupplierContactManMail = this.textBox8.Text;
            oo.SaveOrUpdateEntity(Currentsupp);
            MessageBox.Show("保存成功！");
            this.button4.Enabled = false;
            SetTextUnActive();
            i = 1;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
          
         

        }

        public void ShowInGrid2(IList i)
        {
            this.commonDataGridView2.Rows.Clear();
            if(i!= null)
            {
                int ii = 0;
                foreach(Supplier_Goods o in i)
                {
                    this.commonDataGridView2.Rows.Add(ii, o.GoodsBaseInfoID.GoodsClassCode, o.GoodsBaseInfoID.GoodsName,
                        o.GoodsBaseInfoID.Specifications, o.GoodsBaseInfoID.Material, o.GoodsBaseInfoID.Unit, new DateTime(o.Date).ToString("yyyy年MM月dd日"));
                    ii++;
                }
                
            }

        }

        public void ShowInGrid1(IList i)
        {

            this.commonDataGridView1.Rows.Clear();
            if (i != null)
            {
                int ii = 0;

                foreach (SupplierCreditRecord o in i)
                {
                    this.commonDataGridView1.Rows.Add(ii,
                        new DateTime(o.SupplierCreditRecordTime).ToString("yyyy-MM-dd"),
                        o.UserId.Name, o.Remarks);
                    ii++;
                }

            }
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ShowInGrid2(opp.GetSelectsgoodsBySuppsIdInSupps_goods(Currentsupp.Id,
                this.textBox14.Text,
                this.textBox13.Text,
                this.dateTimePicker2.Value.Ticks,
                this.dateTimePicker3.Value.Ticks));

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }





    }
}
