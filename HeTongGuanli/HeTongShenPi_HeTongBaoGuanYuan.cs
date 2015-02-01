using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HeTongGuanLi.Service;
using System.Collections;
using EntityClassLibrary;
using CommonControl;

namespace HeTongGuanLi
{
    public partial class HeTongShenPi_HeTongBaoGuanYuan : CommonControl.CommonTabPage
    {
        IList currenthetongs;
        ContractService hs = new ContractService();
        public HeTongShenPi_HeTongBaoGuanYuan()
        {
            InitializeComponent();
        }

        private void HeTongShenPi_HeTongBaoGuanYuan_Load(object sender, EventArgs e)
        {
            reFreshAllControl();

        }
        public override void reFreshAllControl()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.start_dateTimePicker.Value = DateTime.Now;
            this.end_dateTimePicker.Value = DateTime.Now;
            this.commonDataGridView1.Rows.Clear();
            if (this.comboBox1.Text == "改装合同")
            {
                currenthetongs = hs.GetPassedContract();

                int i = 1;
                if (currenthetongs != null)
                {
                    foreach (ModificationContract s in currenthetongs)
                    {
                        CarBaseInfo cbi = null;
                        foreach (CarBaseInfo c in s.CarBaseInfoID)
                        {
                            cbi = c;
                            break;
                        }

                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount);
                        i++;
                    }

                }
            }
            else if (this.comboBox1.Text == "套件合同")
            {
                currenthetongs = hs.GetPassedSuiteContract();
                int i = 1;
                if (currenthetongs != null)
                {
                    foreach (SuiteContract s in currenthetongs)
                    {

                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID == null ? "" : s.UserID.Name, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount);
                        i++;

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            string cname = this.textBox2.Text;
            long time1 = start_dateTimePicker.Value.Date.Ticks;
            long time2 = end_dateTimePicker.Value.Ticks + new DateTime(1, 1, 2).Date.Ticks;
            this.commonDataGridView1.Rows.Clear();
            if (this.comboBox1.Text == "改装合同")
            {
                currenthetongs = hs.SelectPassedContract(name, cname, time1, time2);
                ShowSelectContractGrid();
            }
            else if (this.comboBox1.Text == "套件合同")
            {
                currenthetongs = hs.SelectPassedSuiteContract(name, cname, time1, time2);
                ShowSelectSuiteContractGrid();
            }


        }
        private void ShowSelectContractGrid()
        {
            this.commonDataGridView1.Rows.Clear();
            int i = 1;
            if (currenthetongs != null)
            {
                foreach (ModificationContract s in currenthetongs)
                {
                    CarBaseInfo cbi = null;
                    foreach (CarBaseInfo c in s.CarBaseInfoID)
                    {
                        cbi = c;
                        break;
                    }
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID == null ? "" : s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount);
                    i++;

                }
                //foreach (SuiteContract s in currenthetongs)
                //{

                //    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo,s.UserID == null ? "" : s.UserID.Name,s.CustomBaseID==null?"": s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount);
                //    i++;

                //}
            }
        }
        private void ShowSelectSuiteContractGrid()
        {
            this.commonDataGridView1.Rows.Clear();
            int i = 1;
            if (currenthetongs != null)
            {
                foreach (SuiteContract s in currenthetongs)
                {

                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID == null ? "" : s.UserID.Name, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount);
                    i++;

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            reFreshAllControl();
        }
    }
}
