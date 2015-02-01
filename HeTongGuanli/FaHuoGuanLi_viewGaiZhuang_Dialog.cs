using System;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using Iesi.Collections.Generic;

namespace HeTongGuanLi
{
    public partial class FaHuoGuanLi_viewGaiZhuang_Dialog : CommonControl.BaseForm
    {
        private IList deliveryList;
        public IList DeliveryList
        {
            get { return deliveryList; }
            set { deliveryList = value; }
        }
        private ISet<CarBaseInfo> carInfoList;
        public ISet<CarBaseInfo> CarInfoList
        {
            get { return carInfoList; }
            set { carInfoList = value; }
        }
        public FaHuoGuanLi_viewGaiZhuang_Dialog()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FaHuoGuanLi_viewGaiZhuang_Dialog_Load(object sender, EventArgs e)
        {
            initListview();
            loadListview();
        }
        /// <summary>
        /// 初始化所有车
        /// </summary>
        private void initListview()
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
                    ListViewItem.ListViewSubItem time = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem state = new ListViewItem.ListViewSubItem();
                    num.Text = i.ToString();
                    carNum.Text = car.PlateNumber;
                    vin.Text = car.VIN;
                    time.Text = "";
                    state.Text = "未发货";
                    item.SubItems.Add(num);
                    item.SubItems.Add(carNum);
                    item.SubItems.Add(vin);
                    item.SubItems.Add(time);
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
                                item.SubItems[4].Text = new DateTime(d.DeliveryDate).ToShortDateString();
                                item.SubItems[5].Text = "已发货";
                            }
                        }
                    }
                }
            }
        }


    }
}
