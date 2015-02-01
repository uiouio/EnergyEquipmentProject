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
using CommonMethod;

namespace CaiGouXiTong
{
    public partial class CaiGouHeTong_New_dialog : Form
    {
        OpPurchase opp = new OpPurchase();
        ToChineseNum tochinese = new ToChineseNum();
        float SunMoney  =0 ;
        IList<PurchaseApplyDetail> receivePurappdetList;
        public IList<PurchaseApplyDetail> ReceivePurappdetList
        {
            get { return receivePurappdetList; }
            set { receivePurappdetList = value; }
        }


        public CaiGouHeTong_New_dialog()
        {
            InitializeComponent();
            //ReceivePurappdetList
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.groupBox1.Enabled = false;
            }
            if (!checkBox1.Checked)
            {
                this.groupBox1.Enabled = true;
            }
        }

        private void CaiGouHeTong_New_dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.textBox1.Text = ReceivePurappdetList[0].SupplierInfoId.SupplierName;
            this.textBox2.Text = "新能装备股份有限公司";
             
            foreach(PurchaseApplyDetail o in ReceivePurappdetList)
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
                    o.Remarks
                    );
                this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                SunMoney = SunMoney + o.GoodsSingleAmount * o.ReportQuanlity;

            }
            this.textBox25.Text = SunMoney.ToString();
            this.textBox26.Text = tochinese.GetChineseNum(SunMoney);


        }
        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text != "")
            {

                if (MessageBox.Show("确定之后不能更改,您确实要这么做吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    PurchaseContract purcon = new PurchaseContract();

                    purcon.SupplierInfoId = ReceivePurappdetList[0].SupplierInfoId;

                    purcon.PurchaseContractCode = this.textBox3.Text;
                    purcon.PurchaseContractAddress = this.textBox4.Text;
                    purcon.PurchaseContractTime = this.dateTimePicker1.Value.Ticks;

                    purcon.SupName = this.textBox5.Text;
                    purcon.SupAddress = this.textBox6.Text;
                    purcon.SupPersonName = this.textBox7.Text;
                    purcon.SupEntrustPersonName = this.textBox8.Text;
                    purcon.SupPhone = this.textBox9.Text;
                    purcon.SupTaxCode = this.textBox10.Text;
                    purcon.SupBankName = this.textBox11.Text;
                    purcon.SupBankCode = this.textBox12.Text;
                    purcon.SupZioCode = this.textBox13.Text;


                    purcon.RecName = this.textBox14.Text;
                    purcon.RecAddress = this.textBox15.Text;
                    purcon.RecPersonName = this.textBox16.Text;
                    purcon.RecEntrustPersonName = this.textBox17.Text;
                    purcon.RecPhone = this.textBox18.Text;
                    purcon.RecTaxCode = this.textBox19.Text;
                    purcon.RecBankName = this.textBox20.Text;
                    purcon.RecBankCode = this.textBox21.Text;
                    purcon.RecZioCode = this.textBox22.Text;

                    purcon.HandlePerson = this.textBox23.Text;
                    purcon.HandleOffice = this.textBox24.Text;
                    purcon.HandleTime = this.dateTimePicker2.Value.Ticks;

                    purcon = opp.SaveOrUpdateEntity(purcon) as PurchaseContract;
                    purcon.PurchaseContractState = (long)PurchaseContract.PurConState.daishenhe;
                   
                    //生成合同


                    //修改purappdet的状态

                    foreach (PurchaseApplyDetail o in ReceivePurappdetList)
                    {
                        //修改purappdet的状态
                        o.PurchaseApplyDetailState = (long)PurchaseApplyDetail.purchasedeilstate.hetongyijingshengchengdengdaishenhe;

                        //注入合同Id
                        o.PurchaseContractId = purcon;

                        opp.SaveOrUpdateEntity(o);

                    }
                    this.DialogResult = DialogResult.OK;
                }


            }
            else
            {
                MessageBox.Show("请填写合同编号");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
