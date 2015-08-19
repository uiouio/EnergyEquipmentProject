﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonMethod;

namespace KuGuanXiTong
{
    public partial class ChuKu_addDetailPaiGong_Dialog : CommonControl.BaseForm
    {
        Service.ChuKuService chuKuService = new Service.ChuKuService();
        private RefitWorkGoods refitGoods;
        private int save;

        public int Save
        {
            get { return save; }
            set { save = value; }
        }

        private StockOperation stockOp;
        public StockOperation StockOp
        {
            get { return stockOp; }
            set { stockOp = value; }
        }
        private Double differenceCount;
        public Double DifferenceCount
        {
            get { return differenceCount; }
            set { differenceCount = value; }
        }
        private object[] chuKuDetail;
        public object[] ChuKuDetail
        {
            get { return chuKuDetail; }
            set { chuKuDetail = value; }
        }
        public ChuKu_addDetailPaiGong_Dialog()
        {
            InitializeComponent();
        }

        private String chukuNumString;

        public String ChukuNumString
        {
            get { return chukuNumString; }
            set { chukuNumString = value; }
        }

        private void ChuKu_addDetail_Dialog_Load(object sender, EventArgs e)
        {
            if (differenceCount <= 0)
            {
                textBox_Count.Enabled = false;
                textBox_goodsCode.Enabled = false;
                button1.Enabled = false;
            }
            refitGoods = (RefitWorkGoods)chuKuDetail[0];
            if (chuKuDetail != null&&chuKuDetail[1]!=null)
            {
                IList<StockOperationDetail> detailList = (IList<StockOperationDetail>)chuKuDetail[1];
                addItemToListView(detailList);
            }
            label_typeCode.Text = refitGoods.GoodsBaseInfoId.Id.ToString().PadLeft(8,'0');

            if (refitGoods.GoodsBaseInfoId != null && refitGoods.GoodsBaseInfoId.IsUniqueCode == (int)BaseEntity.YesNo.No)
            {
                textBox_goodsCode.Enabled = false;
                textBox_goodsCode.Text = "000000000000000";
            }
            else
            {
                textBox_Count.Enabled = false;
                textBox_Count.Text = "1";
            }
        }

        private void addItemToListView(IList<StockOperationDetail> detailList)
        {
            if (detailList != null && detailList.Count > 0)
            {
                int i = 0;
                foreach (StockOperationDetail s in detailList)
                {
                    i++;
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    ListViewItem.ListViewSubItem goodsName = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem count = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem code = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem money = new ListViewItem.ListViewSubItem();
                    goodsName.Text = refitGoods.GoodsBaseInfoId.GoodsName;
                    count.Text = s.Quantity.ToString();
                    code.Text = s.GoodsCode;
                    money.Text = s.TheMoney != 0 ? s.TheMoney.ToString() : "";
                    item.SubItems.Add(goodsName);
                    item.SubItems.Add(count);
                    item.SubItems.Add(code);
                    item.SubItems.Add(money);
                    listView1.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestInput testInput = new TestInput();
            if (textBox_Count.Text.Trim() == "" || !testInput.TestDecimal(textBox_Count.Text.Trim()))
            {
                MessageBox.Show("输入数量格式不正确！");
                textBox_Count.Text = "";
                textBox_Count.Focus();
                return;
            }
            if (textBox_goodsCode.Text.Length != 15)
            {
                MessageBox.Show("输入的条码格式不正确！");
                textBox_goodsCode.Text = "";
                textBox_goodsCode.Focus();
                return;
            }
            if ((differenceCount - Convert.ToDouble(textBox_Count.Text.Trim())) < 0)
            {
                MessageBox.Show("所出数量超出待出数量！");
                textBox_Count.Text = "";
                textBox_Count.Focus();
                return;
            }
            Stock stock = chuKuService.getStockByGoodsCode(label_typeCode.Text + textBox_goodsCode.Text.Trim());
            if (stock != null && stock.Quantity >= Convert.ToDouble(textBox_Count.Text.Trim()))
            {
                if (chuKuDetail != null && chuKuDetail[1] == null)
                {
                    chuKuDetail[1] = new List<StockOperationDetail>();
                }
                IList<StockOperationDetail> detailList = (IList<StockOperationDetail>)chuKuDetail[1];

                stock.Quantity -= (float)Convert.ToDouble(textBox_Count.Text.Trim());
                chuKuService.SaveOrUpdateEntity(stock);
                if (stockOp == null)
                {
                    StockOperation so = new StockOperation();
                    so.OperationTime = DateTime.Now.Ticks;
                    so.OperationTpye = (int)StockOperation.OpTypeFlag.OutByRefitWork;
                    so.RetrospectListNumber = refitGoods.RefitWorkId.DispatchOrder;
                    so.UserId = this.UserInfo;
                    so.IOFlag = (int)StockOperation.InOrOutFlag.Out;
                    chuKuService.SaveOrUpdateEntity(so);
                    stockOp = so;
                }


                refitGoods.ReceiveType = (int)RefitWorkGoods.ReceiveTypeEnum.Receive;
                chuKuService.SaveOrUpdateEntity(refitGoods);


                StockOperationDetail sod = new StockOperationDetail();
                sod.GoodsCode = label_typeCode.Text + textBox_goodsCode.Text.Trim();
                sod.Quantity = (float)Convert.ToDouble(textBox_Count.Text.Trim());
                sod.StockOperationId = stockOp;
                sod.StockId = stock;
                sod.TheMoney = stock.GoodsBaseInfoID.SingleMoney;
                sod.ChuKuNum = ChukuNumString;
                //sod =  chuKuService.SaveOrUpdateEntity(sod) as StockOperationDetail;
                chuKuService.SaveOrUpdateEntity(sod);
                detailList.Add(sod);
                //stockOp.OperationDetails = detailList;
                //chuKuService.SaveOrUpdateEntity(stockOp);
                
                differenceCount -= Convert.ToDouble(textBox_Count.Text.Trim());
                IList<StockOperationDetail> sodList = new List<StockOperationDetail>();
                sodList.Add(sod);
                addItemToListView(sodList);
                this.save = 1;
                //this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("库存数量不够出库数量！");
            }

            if (textBox_goodsCode.Enabled)
            {
                textBox_goodsCode.Text = "";
            }
            if (textBox_Count.Enabled)
            {
                textBox_Count.Text = "";
            }
        }

        private void textBox_goodsCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox_goodsCode.Text.Length == 23)
                {
                    if (!label_typeCode.Text.Equals(textBox_goodsCode.Text.Substring(0, 8)))
                    {
                        MessageBox.Show("输入的条码不输入此货物类型！");
                        textBox_goodsCode.Text = "";
                        textBox_goodsCode.Focus();
                    }
                    else
                    {
                        textBox_goodsCode.Text = textBox_goodsCode.Text.Substring(8, textBox_goodsCode.Text.Length - 8);
                    }

                    button1_Click(button1,new EventArgs());
                }
            }
        }
    }
}
