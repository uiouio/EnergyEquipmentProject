using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;

namespace HeTongGuanLi
{
    public partial class PaymentManagement_add_Dialog : CommonControl.BaseForm
    {
        Service.ContractService contractServive = new Service.ContractService();
        private ModificationContract contract;

        public ModificationContract Contract
        {
            get { return contract; }
            set { contract = value; }
        }
        public PaymentManagement_add_Dialog()
        {
            InitializeComponent();
        }

        private void PaymentManagement_add_Dialog_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = contract.ContractNo;
            if (contract.CarBaseInfoID != null && contract.CarBaseInfoID.Count > 0)
            {
                CarBaseInfo cbi = null;
                foreach (CarBaseInfo c in contract.CarBaseInfoID)
                {
                    cbi = c;
                    break;
                }
                this.textBox4.Text = cbi.Cbi.Name;
            }
            this.textBox1.Text = contract.UserID.Name;
            this.textBox3.Text = contract.PaymentMethod;
            IList paymentList = contractServive.GetModificationContractPayment(contract.Id);
            initListViewAndAmount(paymentList);
            if (int.Parse(textBox9.Text.Trim()) == 0)
            {
                button2.Enabled = false;
            }
        }

        private void initListViewAndAmount(IList paymentList)
        {
            if (paymentList != null && paymentList.Count > 0)
            {
                int i = 0;
                float totalAmount = 0;
                foreach (PaymentRecords p in paymentList)
                {
                    i++;
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    ListViewItem.ListViewSubItem time = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem amount = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem remark = new ListViewItem.ListViewSubItem();
                    time.Text = new DateTime(p.PayMentDate).ToShortDateString();
                    amount.Text = p.PayedAmount.ToString();
                    remark.Text = p.PayMentRemarks;
                    item.SubItems.Add(time);
                    item.SubItems.Add(amount);
                    item.SubItems.Add(remark);
                    listView1.Items.Add(item);
                    totalAmount += p.PayedAmount;
                }
                textBox8.Text = totalAmount.ToString();
                textBox9.Text = (contract.ContractAmount - totalAmount).ToString();
            }
            else
            {
                textBox8.Text = "0";
                textBox9.Text = contract.ContractAmount.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaymentRecords pp = new PaymentRecords();
            pp.PayedAmount = float.Parse(textBox7.Text.Trim());
            pp.ContractId = contract;
            pp.PayMentDate = DateTime.Now.Ticks;
            pp.PayMentRemarks = textBox5.Text.Trim();
            contractServive.SaveOrUpdateEntity(pp);
            MessageBox.Show("保存成功");
            if (pp.PayedAmount >= float.Parse(textBox9.Text.Trim()))
            {
                contract.PaymentState = (int)ModificationContract.PaymentStateEnum.All;
            }
            else
            {
                contract.PaymentState = (int)ModificationContract.PaymentStateEnum.Partial;
            }
            contractServive.SaveOrUpdateEntity(contract);
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
