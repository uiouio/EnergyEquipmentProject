using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonControl;
using System.Collections;
using HeTongGuanLi.Service;
using EntityClassLibrary;

namespace HeTongGuanLi
{
    public partial class PaymentManagement : CommonControl.CommonTabPage
    {
        ContractService hs = new ContractService();
        public PaymentManagement()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            comboBox1.SelectedIndex = 0;
            IList currentpayments = hs.GetPassedContract();
            Show_GaiZhuang_PaymentGrid(currentpayments);
        }

        private void PaymentManagement_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = commonDataGridView1.Rows[e.RowIndex];
            if (commonDataGridView1.CurrentCell.Value.ToString() == "付款")
            {
                if (r.Cells[2].Value.ToString().Equals("改装合同"))
                {
                    PaymentManagement_add_Dialog gz = new PaymentManagement_add_Dialog();
                    gz.Contract = (ModificationContract)r.Tag;
                    if (gz.ShowDialog() == DialogResult.OK)
                    {
                        r.Tag = gz.Contract;
                        r.Cells[8].Value = ModificationContract.PaymentStateArray[gz.Contract.PaymentState];
                    }
                }
                else if (r.Cells[2].Value.ToString().Equals("套件合同"))
                {
                    PaymentManagement_addSuit_Dialog gz = new PaymentManagement_addSuit_Dialog();
                    gz.Contract = (SuiteContract)r.Tag;
                    if (gz.ShowDialog() == DialogResult.OK)
                    {
                        r.Tag = gz.Contract;
                        r.Cells[8].Value = SuiteContract.PaymentStateArray[gz.Contract.PaymentState];
                    }
                }
            }
        }
        /// <summary>
        /// 初始化改装合同gridview
        /// </summary>
        /// <param name="currentpayments"></param>
        private void Show_GaiZhuang_PaymentGrid(IList currentpayments)
        {
            commonDataGridView1.Rows.Clear();
            if (currentpayments != null && currentpayments.Count>0)
            {
                int i = 1;
                if (currentpayments != null)
                {
                    foreach (ModificationContract m in currentpayments)
                    {
                        CarBaseInfo cbi = null;
                        foreach (CarBaseInfo c in m.CarBaseInfoID)
                        {
                            cbi = c;
                            break;
                        }
                        this.commonDataGridView1.Rows.Add(0, i.ToString(),"改装合同", m.ContractNo, cbi!=null?cbi.Cbi.Name:"", m.UserID.Name, m.ContractAmount, m.PaymentMethod,ModificationContract.PaymentStateArray[m.PaymentState] , "付款");
                        i++;
                        commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = m;
                    }
                }
            }
        }
        /// <summary>
        /// 初始化套件合同gridview
        /// </summary>
        /// <param name="currentpayments"></param>
        private void Show_TaoJian_PaymentGrid(IList currentpayments)
        {
            commonDataGridView1.Rows.Clear();
            if (currentpayments != null && currentpayments.Count > 0)
            {
                int i = 1;
                if (currentpayments != null)
                {
                    foreach (SuiteContract m in currentpayments)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), "改装合同", m.ContractNo, m.CustomBaseID.Name, m.UserID.Name, m.ContractAmount, m.PaymentMethod, ModificationContract.PaymentStateArray[m.PaymentState], "付款");
                        i++;
                        commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = m;
                    }
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
                IList currentpayments = hs.SelectPassedModificationContract(name, cname, time1, time2);
                Show_GaiZhuang_PaymentGrid(currentpayments);
            }
            else if (comboBox1.Text.Trim().Equals("套件合同"))
            {
                IList currentpayments = hs.SelectPassedSuitContract(name, cname, time1, time2);
                Show_TaoJian_PaymentGrid(currentpayments);
            }
        }
    }
}
