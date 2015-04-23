using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using CommonMethod;
namespace HeTongGuanLi
{
    public partial class FaHuoGuanLi : CommonControl.CommonTabPage
    {
        Service.ContractService contractService = new Service.ContractService();
        Service.DeliveryService deliveryService = new Service.DeliveryService();
        public FaHuoGuanLi()
        {
            InitializeComponent();
        }
        private void FaHuoGuanLi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        public override void reFreshAllControl()
        {
            comboBox1.SelectedIndex = 0;
            IList contractList = contractService.GetPassedContract();
            initToDoModificationContractGridView(contractList);
        }
        private void initToDoModificationContractGridView(IList contractList)
        {
            commonDataGridView1.Rows.Clear();
            if (contractList != null && contractList.Count > 0)
            {
                int i = 0;
                foreach (ModificationContract m in contractList)
                {
                    i++;
                    foreach(CarBaseInfo s in m.CarBaseInfoID)
                    {
                       commonDataGridView1.Rows.Add(0, i.ToString(), m.ContractNo, s.PlateNumber,s.Cbi.Name,"改装合同", ModificationContract.PaymentStateArray[m.PaymentState], ModificationContract.DeliveryStatusArray[m.DeliveryStatus], "查看", "发货");
                       commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = m;
                    }
                }
            }
        }
        private void initToDoSuitContractGridView(IList contractList)
        {
            commonDataGridView1.Rows.Clear();
            if (contractList != null && contractList.Count > 0)
            {
                int i = 0;
                foreach (SuiteContract m in contractList)
                {
                    i++;
                    commonDataGridView1.Rows.Add(0, i.ToString(), m.ContractNo,"",m.CustomBaseID.Name, "套件合同", SuiteContract.PaymentStateArray[m.PaymentState], SuiteContract.DeliveryStatusArray[m.DeliveryStatus], "查看", "发货");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = m;
                   
                }
            }
        }
        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                if (commonDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Equals("改装合同"))
                {
                    ModificationContract m = (ModificationContract)commonDataGridView1.Rows[e.RowIndex].Tag;
                    IList deliveryList = deliveryService.GetDeliveryRecordByModuficationContractId(m.Id);
                    FaHuoGuanLi_newGaiZhuang_Dialog fnd = new FaHuoGuanLi_newGaiZhuang_Dialog();
                    fnd.DeliveryList = deliveryList;
                    fnd.Contract = m;
                    if (fnd.ShowDialog() == DialogResult.OK)
                    {
                        contractService.SaveOrUpdateEntity(m);
                        commonDataGridView1.Rows[e.RowIndex].Cells[7].Value = ModificationContract.DeliveryStatusArray[m.DeliveryStatus];
                    }
                }
                else if (commonDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Equals("套件合同"))
                {
                    SuiteContract m = (SuiteContract)commonDataGridView1.Rows[e.RowIndex].Tag;
                    IList deliveryList = deliveryService.GetDeliveryRecordBySuitContractId(m.Id);
                    FaHuoGuanLi_newTaoJian_Dialog fnd = new FaHuoGuanLi_newTaoJian_Dialog();
                    fnd.DeliveryList = deliveryList;
                    fnd.Contract = m;
                    fnd.ShowDialog();
                    if (fnd.ShowDialog() == DialogResult.OK)
                    {
                        contractService.SaveOrUpdateEntity(m);
                        commonDataGridView1.Rows[e.RowIndex].Cells[7].Value = SuiteContract.DeliveryStatusArray[m.DeliveryStatus];
                    }
                }
            }
            else if (e.ColumnIndex == 8)
            {
                if (commonDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Equals("改装合同"))
                {
                    ModificationContract m = (ModificationContract)commonDataGridView1.Rows[e.RowIndex].Tag;
                    IList deliveryList = deliveryService.GetDeliveryRecordByModuficationContractId(m.Id);
                    FaHuoGuanLi_viewGaiZhuang_Dialog fvd = new FaHuoGuanLi_viewGaiZhuang_Dialog();
                    fvd.DeliveryList = deliveryList;
                    fvd.CarInfoList = m.CarBaseInfoID;
                    fvd.ShowDialog();
                }
                else if (commonDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Equals("套件合同"))
                {
                    SuiteContract m = (SuiteContract)commonDataGridView1.Rows[e.RowIndex].Tag;
                    IList deliveryList = deliveryService.GetDeliveryRecordBySuitContractId(m.Id);
                    FaHuoGuanLi_viewTaoJian_Dialog fvd = new FaHuoGuanLi_viewTaoJian_Dialog();
                    fvd.DeliveryList = deliveryList;
                    fvd.GoodsInfoList = m.SuiteContractGoods;
                    fvd.ShowDialog();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string cname = textBox2.Text;
            long time1 = start_dateTimePicker.Value.Ticks;
            long time2 = end_dateTimePicker.Value.Ticks + new DateTime(1, 1, 2).Date.Ticks;
            if (comboBox1.Text.Trim().Equals("改装合同"))
            {
                IList currentpayments = contractService.SelectPassedModificationContract(name, cname, time1, time2);
                initToDoModificationContractGridView(currentpayments);
            }
            else if (comboBox1.Text.Trim().Equals("套件合同"))
            {
                IList currentpayments = contractService.SelectPassedSuitContract(name, cname, time1, time2);
                initToDoSuitContractGridView(currentpayments);
            }
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView1);
            div.Columns.Remove(div.Columns[div.ColumnCount - 1]);
            PrintDataGridView.PrintTheDataGridView(div);
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView1);
            div.Columns.Remove(div.Columns[div.ColumnCount - 1]);
            DoExport.DoTheExport(div);
        }
    }
}
