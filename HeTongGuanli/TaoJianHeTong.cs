using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using HeTongGuanLi.Service;
using EntityClassLibrary;
using CommonControl;

namespace HeTongGuanLi
{
    public partial class TaoJianHeTong : CommonControl.CommonTabPage
    {
        IList currenthetongs;
        ContractService hs = new ContractService();
      
        public TaoJianHeTong()
        {
            InitializeComponent();
        }

        private void TaoJianHeTong_Load(object sender, EventArgs e)
        {
            this.commonDataGridView.Rows.Clear();
            reFreshAllControl();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            MuBanSelect_Dialog gad = new MuBanSelect_Dialog();
            gad.UserInfo = this.User;
            gad.IsModifyOrSuite = 1;
            if (gad.ShowDialog() == DialogResult.OK)
            {
                this.commonDataGridView.Rows.Clear();
                reFreshAllControl();
            }
        }

        public override void reFreshAllControl()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.start_dateTimePicker.Value = DateTime.Now;
            this.end_dateTimePicker.Value = DateTime.Now;
            this.commonDataGridView.Rows.Clear();
            currenthetongs = hs.GetAllSuitContract();
            int i = 1;
            if (currenthetongs != null)
            {
                foreach (SuiteContract s in currenthetongs)
                {
                    #region  销售负责人待审批
                    if (s.Process == (int)SuiteContract.guocheng.xsfzr && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                    }
                    #endregion
                    #region  总会计师待审批
                    else if (s.Process == (int)SuiteContract.guocheng.kjs && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null  ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                    }
                    #endregion
                    #region  总经理待审批
                    else if (s.Process == (int)SuiteContract.guocheng.zjl && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                    }
                    #endregion
                    #region 销售负责人不通过
                    else if (s.Process == (int)SuiteContract.guocheng.xsfzr && s.Pass == (int)SuiteContract.PassorNot.unpass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                    }
                    #endregion
                    #region 总会计师不通过
                    else if (s.Process == (int)SuiteContract.guocheng.kjs && s.Pass == (int)SuiteContract.PassorNot.unpass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                    }
                    #endregion
                    #region 总经理不通过
                    else if (s.Process == (int)SuiteContract.guocheng.zjl && s.Pass == (int)SuiteContract.PassorNot.unpass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                    }
                    #endregion
                    #region 总经理通过
                    else if (s.Process == (int)SuiteContract.guocheng.htbgy && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "已通过", "查看", "删除");
                    }
                    #endregion

                    i++;
                }
            }
       
        }

        private void commonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                SuiteContractView gz = new SuiteContractView();
                gz.SuiteContract = (SuiteContract)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];
                if (gz.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView.Rows.Clear();
                    reFreshAllControl();

                }  

            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                SuiteContract s = (SuiteContract)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    hs.Remove(s);
                    this.commonDataGridView.Rows.Clear();
                    reFreshAllControl();
                }
            }
            else if (grid.CurrentCell.Value.ToString() == "编辑")
            {
                SuiteContractView1 gz = new SuiteContractView1();
                gz.SuiteContract = (SuiteContract)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];
                if (gz.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView.Rows.Clear();
                    reFreshAllControl();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            string cname = textBox2.Text;

            long time1 = start_dateTimePicker.Value.Date.Ticks;

            long time2 = end_dateTimePicker.Value.AddDays(1).Ticks;

            this.commonDataGridView.Rows.Clear();

            currenthetongs = hs.SelectTaoJianHeTong(name,cname,time1,time2);

            ShowSelectContractGrid();
        }
        private void ShowSelectContractGrid()
        {
            int i = 1;
            if (currenthetongs != null)
            {
                foreach (SuiteContract s in currenthetongs)
                {
                    #region  销售负责人待审批
                    if (s.Process == (int)SuiteContract.guocheng.xsfzr && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                    }
                    #endregion
                    #region  总会计师待审批
                    else if (s.Process == (int)SuiteContract.guocheng.kjs && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                    }
                    #endregion
                    #region  总经理待审批
                    else if (s.Process == (int)SuiteContract.guocheng.zjl && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                    }
                    #endregion
                    #region 销售负责人不通过
                    else if (s.Process == (int)SuiteContract.guocheng.xsfzr && s.Pass == (int)SuiteContract.PassorNot.unpass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                    }
                    #endregion
                    #region 总会计师不通过
                    else if (s.Process == (int)SuiteContract.guocheng.kjs && s.Pass == (int)SuiteContract.PassorNot.unpass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                    }
                    #endregion
                    #region 总经理不通过
                    else if (s.Process == (int)SuiteContract.guocheng.zjl && s.Pass == (int)SuiteContract.PassorNot.unpass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                    }
                    #endregion
                    #region 总经理通过
                    else if (s.Process == (int)SuiteContract.guocheng.htbgy && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, SuiteContract.ProcessArray[s.Process] + "已通过", "查看", "删除");
                    }
                    #endregion
                    i++;

                }
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                button1_Click(sender, e);
            }
        }
    

    }
}
