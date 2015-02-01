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
    public partial class YunShuHeTong_New : Form
    {


        TransportContract receiveTranCon;

        public TransportContract ReceiveTranCon
        {
            get { return receiveTranCon; }
            set { receiveTranCon = value; }
        }

        int isChakan;

        public int IsChakan
        {
            get { return isChakan; }
            set { isChakan = value; }
        }

        OpPurchase opp = new OpPurchase();

        public YunShuHeTong_New()
        {
            InitializeComponent();
            IsChakan = 0;
            ReceiveTranCon = new TransportContract();
        }

        private void YunShuHeTong_New_Load(object sender, EventArgs e)
        {
            if (IsChakan == 1)
            {


                this.textBox1.Text = ReceiveTranCon.SendCategory;
                this.textBox3.Text = ReceiveTranCon.ReceiveCategory;
                this.textBox2.Text = ReceiveTranCon.SendPlace;
                this.textBox4.Text = ReceiveTranCon.ReceivePlace;
                this.textBox5.Text = ReceiveTranCon.ReceiverName;
                this.textBox6.Text = ReceiveTranCon.ReceiverPhone;
                this.textBox8.Text = ReceiveTranCon.GoodsNameAndNum;
                this.textBox7.Text = ReceiveTranCon.GoodsWeight;
                this.textBox9.Text = ReceiveTranCon.GoodsVolme;
                this.dateTimePicker1.Value = new DateTime(ReceiveTranCon.SendTime);
                this.dateTimePicker2.Value = new DateTime(ReceiveTranCon.ReceivedTime);

                this.textBox10.Text = ReceiveTranCon.TransportMoney;
                this.textBox12.Text = ReceiveTranCon.TransportContractNum;

                this.textBox11.Text = ReceiveTranCon.Remark;
                ReadonlyAll();

            }
            
        }

        public void ReadonlyAll()
        {
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox8.ReadOnly = true;
            this.textBox9.ReadOnly = true;
            this.textBox10.ReadOnly = true;
            this.textBox11.ReadOnly = true;
            this.textBox12.ReadOnly = true;
            this.dateTimePicker1.Enabled = true;
            this.dateTimePicker2.Enabled = true;

            this.button1.Visible = false;
            this.button2.Visible = false;
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox12.Text != "")
            {
                TransportContract tc = new TransportContract();
                tc.SendCategory = this.textBox1.Text;
                tc.ReceiveCategory = this.textBox3.Text;
                tc.SendPlace = this.textBox2.Text;
                tc.ReceivePlace = this.textBox4.Text;
                tc.ReceiverName = this.textBox5.Text;
                tc.ReceiverPhone = this.textBox6.Text;
                tc.GoodsNameAndNum = this.textBox8.Text;
                tc.GoodsWeight = textBox7.Text;
                tc.GoodsVolme = this.textBox9.Text;
                tc.SendTime = this.dateTimePicker1.Value.Ticks;
                tc.ReceivedTime = this.dateTimePicker2.Value.Ticks;

                tc.TransportMoney = this.textBox10.Text;
                tc.TransportContractNum = this.textBox12.Text;

                tc.Remark = this.textBox11.Text;

                opp.SaveOrUpdateEntity(tc);
                MessageBox.Show("添加成功！");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请填写合同单号！");
            }
        }
    }
}
