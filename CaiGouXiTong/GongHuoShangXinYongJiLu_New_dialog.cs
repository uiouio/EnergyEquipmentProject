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

namespace CaiGouXiTong
{
    public partial class GongHuoShangXinYongJiLu_New_dialog : Form
    {


        OpPurchase opp = new OpPurchase();
        UserInfo receiveUserInfo;
        public UserInfo ReceiveUserInfo
        {
            get { return receiveUserInfo; }
            set { receiveUserInfo = value; }
        }

        SupplierInfo receiveSupps;
        public SupplierInfo ReceiveSupps
        {
            get { return receiveSupps; }
            set { receiveSupps = value; }
        }

        public GongHuoShangXinYongJiLu_New_dialog()
        {
            InitializeComponent();
        }

        private void GongHuoShangXinYongJiLu_New_dialog_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = ReceiveUserInfo.Name;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text != "")
            {
                SupplierCreditRecord supp = new SupplierCreditRecord();
                supp.Remarks = this.textBox2.Text;
                supp.SupplierInfoId = ReceiveSupps;
                supp.UserId = ReceiveUserInfo;
                supp.SupplierCreditRecordTime = DateTime.Now.Ticks;
                opp.SaveOrUpdateEntity(supp);
                MessageBox.Show("添加成功！");
                this.DialogResult = DialogResult.OK;
            }
            else 
            {
                MessageBox.Show("请填写说明！");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
