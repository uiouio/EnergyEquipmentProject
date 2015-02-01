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
    public partial class FaHuoGuanLi_newGaiZhuang_Dialog : CommonControl.BaseForm
    {
        Service.DeliveryService deliveryService = new Service.DeliveryService();
        private ISet<CarBaseInfo> carInfoList;
        private IList deliveryList;
        public IList DeliveryList
        {
            get { return deliveryList; }
            set { deliveryList = value; }
        }
        private ModificationContract contract;
        public ModificationContract Contract
        {
            get { return contract; }
            set { contract = value; }
        }
        public FaHuoGuanLi_newGaiZhuang_Dialog()
        {
            InitializeComponent();
        }
        private void FaHuoGuanLi_newGaiZhuang_Dialog_Load(object sender, EventArgs e)
        {
            carInfoList = Contract.CarBaseInfoID;
            initListview1();
            loadListview1();
        }

        /// <summary>
        /// 初始化所有车
        /// </summary>
        private void initListview1()
        {
            listView1.Items.Clear();
            if (carInfoList != null && carInfoList.Count > 0)
            {
                int i = 0;
                foreach (CarBaseInfo car in carInfoList)
                {
                    i++;
                    ListViewItem item = new ListViewItem();
                    item.Tag = car;
                    item.ForeColor = System.Drawing.Color.Red;
                    ListViewItem.ListViewSubItem num = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem carNum = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem vin = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem state = new ListViewItem.ListViewSubItem();
                    num.Text = i.ToString();
                    carNum.Text = car.PlateNumber;
                    vin.Text = car.VIN;
                    state.Text = "未发货";
                    item.Tag = car;
                    item.SubItems.Add(num);
                    item.SubItems.Add(carNum);
                    item.SubItems.Add(vin);
                    item.SubItems.Add(state);
                    listView1.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// 初始化是否发货
        /// </summary>
        private void loadListview1()
        {
            if (deliveryList != null && deliveryList.Count > 0)
            {
                foreach (DeliveryModificationRecords d in deliveryList)
                {
                    if (listView1.Items != null && listView1.Items.Count > 0)
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            CarBaseInfo c = (CarBaseInfo)item.Tag;
                            if (c.Id == d.CarInfoId.Id)
                            {
                                item.ForeColor = System.Drawing.Color.Black;
                                item.SubItems[4].Text = "已发货";
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (listView1.CheckedItems != null && listView1.CheckedItems.Count > 0)
            {
                ListViewItem item = listView1.CheckedItems[0];
                listView1.Items.Remove(item);
                listView2.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (listView2.CheckedItems != null && listView2.CheckedItems.Count > 0)
            {
                ListViewItem item = listView2.CheckedItems[0];
                listView2.Items.Remove(item);
                listView1.Items.Add(item);
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (listView1.Items[e.Index].SubItems[4].Text.Equals("已发货"))
                {
                    MessageBox.Show("此车已发货，不可再发！");
                    listView1.Items[e.Index].Checked = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView2.Items != null && listView2.Items.Count > 0)
            {
                foreach (ListViewItem item in listView2.Items)
                {
                    DeliveryModificationRecords dmr = new DeliveryModificationRecords();
                    dmr.CarInfoId = (CarBaseInfo)item.Tag;
                    dmr.ContractId = contract;
                    dmr.DeliveryDate = DateTime.Now.Ticks;
                    deliveryService.SaveOrUpdateEntity(dmr);

                    deliveryList.Add(dmr);
                }

                if (deliveryList != null && deliveryList.Count > 0)
                {
                    if (deliveryList.Count == carInfoList.Count)
                    {
                        contract.DeliveryStatus = (int)ModificationContract.DeliveryStatusEnum.All;
                    }
                    else
                    {
                        contract.DeliveryStatus = (int)ModificationContract.DeliveryStatusEnum.Partial;
                    }
                }
                else
                {
                    contract.DeliveryStatus = (int)ModificationContract.DeliveryStatusEnum.None;
                }
            }

            this.DialogResult = DialogResult.OK;
        }


    }
}
