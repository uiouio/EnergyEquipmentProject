using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using Iesi.Collections.Generic;

namespace HeTongGuanLi
{
    public partial class FaHuoGuanLi_viewTaoJian_Dialog : CommonControl.BaseForm
    {
        private IList deliveryList;
        public IList DeliveryList
        {
            get { return deliveryList; }
            set { deliveryList = value; }
        }
        private ISet<SuiteContractGoods> goodsInfoList;
        public ISet<SuiteContractGoods> GoodsInfoList
        {
            get { return goodsInfoList; }
            set { goodsInfoList = value; }
        }
        public FaHuoGuanLi_viewTaoJian_Dialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FaHuoGuanLi_viewTaoJian_Dialog_Load(object sender, EventArgs e)
        {
            initListview();
            loadListview();
        }

        /// <summary>
        /// 初始化所有货物
        /// </summary>
        private void initListview()
        {
            listView1.Items.Clear();
            if (goodsInfoList != null && goodsInfoList.Count > 0)
            {
                int i = 0;
                foreach (SuiteContractGoods goods in goodsInfoList)
                {
                    i++;
                    ListViewItem item = new ListViewItem();
                    item.Tag = goods;
                    item.ForeColor = System.Drawing.Color.Red;
                    ListViewItem.ListViewSubItem num = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem goodsNum = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem goodsName = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem goodsCount = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem notDeliveryCount = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem state = new ListViewItem.ListViewSubItem();
                    num.Text = i.ToString();
                    goodsNum.Text = goods.GoodsBaseInfoId.GoodsClassCode;
                    goodsName.Text = goods.GoodsBaseInfoId.GoodsName;
                    goodsCount.Text = goods.Count.ToString();
                    notDeliveryCount.Text = goods.Count.ToString();
                    state.Text = "未发货";
                    item.SubItems.Add(num);
                    item.SubItems.Add(goodsNum);
                    item.SubItems.Add(goodsName);
                    item.SubItems.Add(goodsCount);
                    item.SubItems.Add(notDeliveryCount);
                    item.SubItems.Add(state);
                    listView1.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// 初始化是否发货
        /// </summary>
        private void loadListview()
        {
            if (deliveryList != null && deliveryList.Count > 0)
            {
                foreach (DeliverySuiteRecords d in deliveryList)
                {
                    if (listView1.Items != null && listView1.Items.Count > 0)
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            SuiteContractGoods c = (SuiteContractGoods)item.Tag;
                            if (c.GoodsBaseInfoId.Id == d.GoodsInfoId.Id)
                            {
                                item.SubItems[5].Text = (Convert.ToInt32(item.SubItems[5].Text.Trim()) - d.Deliverycount).ToString();
                                if (Convert.ToInt32(item.SubItems[5].Text.Trim()) <= 0)
                                {
                                    item.ForeColor = System.Drawing.Color.Black;
                                    item.SubItems[5].Text = "已发完";
                                }
                                else
                                {
                                    item.SubItems[5].Text = "已发部分";
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
