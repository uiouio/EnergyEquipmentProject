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
    public partial class FaHuoGuanLi_newTaoJian_Dialog : CommonControl.BaseForm
    {
        Service.DeliveryService deliveryService = new Service.DeliveryService();
        private ISet<SuiteContractGoods> goodsInfoList;
        private IList deliveryList;
        public IList DeliveryList
        {
            get { return deliveryList; }
            set { deliveryList = value; }
        }
        private SuiteContract contract;
        public SuiteContract Contract
        {
            get { return contract; }
            set { contract = value; }
        }
        public FaHuoGuanLi_newTaoJian_Dialog()
        {
            InitializeComponent();
        }
        private void FaHuoGuanLi_newTaoJian_Dialog_Load(object sender, EventArgs e)
        {
            goodsInfoList = Contract.SuiteContractGoods;
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

        private void button1_Click(object sender, EventArgs e)
        {
            #region 判断异常
            if (listView1.Items == null || listView1.Items.Count == 0)
            {
                return;
            }
            ListViewItem currentItem = listView1.CheckedItems[0];
            SuiteContractGoods currentSCG = (SuiteContractGoods)currentItem.Tag;

            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("请填写发货数量！");
                return;
            }

            if (Convert.ToInt32(currentItem.SubItems[5].Text.Trim()) < numericUpDown1.Value)
            {
                MessageBox.Show("发货数量超出待发货数量！");
                return;
            }
            #endregion

            #region 移除左边Listview记录
            currentItem.SubItems[5].Text = (Convert.ToInt32(currentItem.SubItems[5].Text.Trim()) - numericUpDown1.Value).ToString();
            if (Convert.ToInt32(currentItem.SubItems[5].Text.Trim()) <= 0)
            {
                currentItem.SubItems[6].Text = "已发完";
                currentItem.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                currentItem.SubItems[6].Text = "已发部分";
            }
            #endregion

            #region 添加右边Listview记录
            if (listView2.Items != null && listView2.Items.Count > 0)
            {
                foreach (ListViewItem item in listView2.Items)
                {
                    SuiteContractGoods scg = (SuiteContractGoods)item.Tag;
                    if (scg.GoodsBaseInfoId.Id == currentSCG.GoodsBaseInfoId.Id)
                    {
                        item.SubItems[3].Text = (Convert.ToInt32(item.SubItems[3].Text.Trim()) + numericUpDown1.Value).ToString();
                        return;
                    }
                }
            }
            ListViewItem newItem = new ListViewItem();
            newItem.Tag = currentSCG;
            ListViewItem.ListViewSubItem goodsNum = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem goodsName = new ListViewItem.ListViewSubItem();
            ListViewItem.ListViewSubItem count = new ListViewItem.ListViewSubItem();

            goodsNum.Text = currentSCG.GoodsBaseInfoId.GoodsClassCode;
            goodsName.Text = currentSCG.GoodsBaseInfoId.GoodsName;
            count.Text = numericUpDown1.Value.ToString();

            newItem.SubItems.Add(goodsNum);
            newItem.SubItems.Add(goodsName);
            newItem.SubItems.Add(count);

            listView2.Items.Add(newItem);
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region 判断异常
            if (listView2.Items == null || listView2.Items.Count == 0)
            {
                return;
            }
            ListViewItem currentItem = listView2.CheckedItems[0];
            SuiteContractGoods currentSCG = (SuiteContractGoods)currentItem.Tag;

            if (numericUpDown2.Value == 0)
            {
                MessageBox.Show("请填写删除数量！");
                return;
            }

            if (Convert.ToInt32(currentItem.SubItems[3].Text.Trim()) < numericUpDown2.Value)
            {
                MessageBox.Show("删除数量超出已发数量！");
                return;
            }
            #endregion

            #region 移除左边Listview记录
            currentItem.SubItems[3].Text = (Convert.ToInt32(currentItem.SubItems[3].Text.Trim()) - numericUpDown2.Value).ToString();
            if (Convert.ToInt32(currentItem.SubItems[3].Text.Trim()) <= 0)
            {
                listView2.Items.Remove(currentItem);
            }
            #endregion

            #region 添加左边Listview记录
            if (listView2.Items != null && listView2.Items.Count > 0)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    SuiteContractGoods scg = (SuiteContractGoods)item.Tag;
                    if (scg.GoodsBaseInfoId.Id == currentSCG.GoodsBaseInfoId.Id)
                    {
                        item.SubItems[5].Text = (Convert.ToInt32(item.SubItems[5].Text.Trim()) + numericUpDown2.Value).ToString();
                        if (item.SubItems[5].Text == item.SubItems[4].Text)
                        {
                            item.SubItems[6].Text = "未发货";
                        }
                        else
                        {
                            item.SubItems[6].Text = "已发部分";
                        }
                        item.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView2.Items != null && listView2.Items.Count > 0)
            {
                foreach (ListViewItem item in listView2.Items)
                {
                    DeliverySuiteRecords dmr = new DeliverySuiteRecords();
                    SuiteContractGoods scg = (SuiteContractGoods)item.Tag;
                    dmr.GoodsInfoId = scg.GoodsBaseInfoId;
                    dmr.ContractId = contract;
                    dmr.DeliveryDate = DateTime.Now.Ticks;
                    dmr.Deliverycount = Convert.ToInt32(listView2.Items[3].Text.Trim());
                    deliveryService.SaveOrUpdateEntity(dmr);

                    deliveryList.Add(dmr);
                }
                if (deliveryList == null || deliveryList.Count == 0)
                {
                    contract.DeliveryStatus = (int)ModificationContract.DeliveryStatusEnum.None;
                    this.DialogResult = DialogResult.OK;
                }
                int state = (int)ModificationContract.DeliveryStatusEnum.All;
                foreach (ListViewItem item in listView1.Items)
                {
                    if (Convert.ToInt32(item.SubItems[5].Text.Trim()) > 0)
                    {
                        state = (int)ModificationContract.DeliveryStatusEnum.Partial;
                        break;
                    }
                }
                contract.DeliveryStatus = state;
            }
            this.DialogResult = DialogResult.OK;
        }
        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView2.CheckedItems.Count > 1)
            {
                MessageBox.Show("只可选择一项！");
                e.Item.Checked = false;
                return;
            }
        }
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView1.CheckedItems.Count > 1)
            {
                MessageBox.Show("只可选择一项！");
                e.Item.Checked = false;
                return;
            }
            if (e.Item.Checked == true)
            {
                if (e.Item.SubItems[6].Text.Equals("已发完"))
                {
                    MessageBox.Show("此车已发完，不可再发！");
                    e.Item.Checked = false;
                }
            }
        }

        
    }
}
