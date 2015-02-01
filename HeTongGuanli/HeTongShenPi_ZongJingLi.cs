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
    public partial class HeTongShenPi_ZongJingLi : CommonControl.CommonTabPage
    {
        IList currenthetongs;
        ContractService hs = new ContractService();
        private ModificationContract modificationContract;

        public ModificationContract ModificationContract
        {
            get { return modificationContract; }
            set { modificationContract = value; }
        }


        public HeTongShenPi_ZongJingLi()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.start_dateTimePicker.Value = DateTime.Now;
            this.end_dateTimePicker.Value = DateTime.Now;
            this.commonDataGridView1.Rows.Clear();
            #region 改装合同
                if (this.comboBox1.Text == "改装合同")
                {
                    currenthetongs = hs.GetManageContract();

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
                            i++;
                            #region 总经理审批
                            if (s.Process == (int)ModificationContract.guocheng.zjl && s.Pass == (int)ModificationContract.PassorNot.pass)
                            {

                                this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process] + "待审核", "审核", "查看");
                            }
                            #endregion

                            #region 总经理通过
                            else if (s.Process == (int)ModificationContract.guocheng.htbgy && s.Pass == (int)ModificationContract.PassorNot.pass)
                            {
                                this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process], "已审批", "查看");
                            }
                            #endregion
                            #region 总经理不通过
                            else if (s.Process == (int)ModificationContract.guocheng.kjs && s.Pass == (int)ModificationContract.PassorNot.unpass)
                            {
                                this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process] + "不通过", "已审批", "查看");
                            }
                            #endregion

                        }
                    }
                }
            #endregion
                #region 套件合同
                if (this.comboBox1.Text == "套件合同")
                {
                    currenthetongs = hs.GetManageSuiteContract();

                    int i = 1;
                    if (currenthetongs != null)
                    {
                        foreach (SuiteContract s in currenthetongs)
                        {

                            i++;
                            #region 总经理审批
                            if (s.Process == (int)SuiteContract.guocheng.zjl && s.Pass == (int)SuiteContract.PassorNot.pass)
                            {

                                this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CustomBaseID == null?"":s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, SuiteContract.ProcessArray[s.Process] + "待审核", "审核", "查看");
                            }
                            #endregion

                            #region 总经理通过
                            else if (s.Process == (int)SuiteContract.guocheng.htbgy && s.Pass == (int)SuiteContract.PassorNot.pass)
                            {
                                this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, SuiteContract.ProcessArray[s.Process], "已审批", "查看");
                            }
                            #endregion
                            #region 总经理不通过
                            else if (s.Process == (int)SuiteContract.guocheng.kjs && s.Pass == (int)SuiteContract.PassorNot.unpass)
                            {
                                this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, SuiteContract.ProcessArray[s.Process] + "不通过", "已审批", "查看");
                            }
                            #endregion

                        }
                    }
                }

                #endregion
           

        }

        private void ShowSelectContractGrid()
        {
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

                    #region 总经理审批
                    if (s.Process == (int)ModificationContract.guocheng.zjl && s.ApprovalState == (int)ModificationContract.Approval.yet)
                    {
                        if (s.Pass == (int)ModificationContract.PassorNot.unpass && s.ApprovalState == (int)ModificationContract.Approval.already)
                        {
                            this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process], "已审批未通过", "查看");
                        }
                        else
                        {
                            this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process], "审核", "查看");
                        }
                    }
                    #endregion

                    else if (s.Process == (int)ModificationContract.guocheng.htbgy)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process], "已通过", "查看");
                    }
                    i++;

                }
            }
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            #region 改装合同
            if(this.comboBox1.Text=="改装合同")
            {
            if (grid.CurrentCell.Value.ToString() == "审核")
            {
                HeTongPingShen_add_Dialog2 hp = new HeTongPingShen_add_Dialog2();
                hp.ModificationContract = (ModificationContract)currenthetongs[this.commonDataGridView1.CurrentCell.RowIndex];

                if (hp.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }


            }
            else if (grid.CurrentCell.Value.ToString() == "查看")
            {
                GaiZhuangContractView gz = new GaiZhuangContractView();
                gz.ModificationContract = (ModificationContract)currenthetongs[this.commonDataGridView1.CurrentCell.RowIndex];
                if (gz.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();


                }

            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                ModificationContract s = (ModificationContract)currenthetongs[this.commonDataGridView1.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    hs.Remove(s);
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }


              }
            }
          #endregion
            #region 套件合同
            else if (comboBox1.Text == "套件合同")
            {
                if (grid.CurrentCell.Value.ToString() == "审核")
                {
                    SuiteContractJudgeZJL hp = new SuiteContractJudgeZJL();
                    hp.SuiteContract = (SuiteContract)currenthetongs[this.commonDataGridView1.CurrentCell.RowIndex];

                    if (hp.ShowDialog() == DialogResult.OK)
                    {
                        this.commonDataGridView1.Rows.Clear();
                        reFreshAllControl();
                    }

                }
                else if (grid.CurrentCell.Value.ToString() == "查看")
                {
                    SuiteContractView gz = new SuiteContractView();
                    gz.SuiteContract = (SuiteContract)currenthetongs[this.commonDataGridView1.CurrentCell.RowIndex];
                    if (gz.ShowDialog() == DialogResult.OK)
                    {
                        this.commonDataGridView1.Rows.Clear();
                        reFreshAllControl();

                    }

                }
                else if (grid.CurrentCell.Value.ToString() == "删除")
                {

                    SuiteContract s = (SuiteContract)currenthetongs[this.commonDataGridView1.CurrentCell.RowIndex];
                    if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        hs.Remove(s);
                        this.commonDataGridView1.Rows.Clear();
                        reFreshAllControl();
                    }

                }

            }
            #endregion

        }


        private void HeTongShenPi_ZongJingLi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string cname = textBox2.Text;
            long dname = start_dateTimePicker.Value.Date.Ticks;
            long ename = end_dateTimePicker.Value.Ticks + new DateTime(1, 1, 2).Date.Ticks;
            this.commonDataGridView1.Rows.Clear();
            if (this.comboBox1.Text == "改装合同")
            {
                currenthetongs = hs.SelectHeTongManage(name, cname, dname, ename);
                ShowSelectModificationContractGrid();
            }
            else if (this.comboBox1.Text == "套件合同")
            {
                currenthetongs = hs.SelectSuiteHeTongManage(name, cname, dname, ename);
                ShowSelectSuiteContractGrid();
            }
            

            
        }
        private void ShowSelectModificationContractGrid()
        {
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
                    #region 总经理审批
                    if (s.Process == (int)ModificationContract.guocheng.zjl && s.Pass == (int)ModificationContract.PassorNot.pass)
                    {

                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process] + "待审核", "审核", "查看");
                    }
                    #endregion

                    #region 总经理通过
                    else if (s.Process == (int)ModificationContract.guocheng.htbgy && s.Pass == (int)ModificationContract.PassorNot.pass)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process], "已审批", "查看");
                    }
                    #endregion
                    #region 总经理不通过
                    else if (s.Process == (int)ModificationContract.guocheng.kjs && s.Pass == (int)ModificationContract.PassorNot.unpass)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, ModificationContract.ProcessArray[s.Process] + "不通过", "已审批", "查看");
                    }
                    #endregion
                    i++;

                }
            }
        }
        private void ShowSelectSuiteContractGrid()
        {
            int i = 1;
            if (currenthetongs != null)
            {
                foreach (SuiteContract s in currenthetongs)
                {


                    #region 总经理审批
                    if (s.Process == (int)SuiteContract.guocheng.zjl && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {

                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, SuiteContract.ProcessArray[s.Process] + "待审核", "审核", "查看");
                    }
                    #endregion

                    #region 总经理通过
                    else if (s.Process == (int)SuiteContract.guocheng.htbgy && s.Pass == (int)SuiteContract.PassorNot.pass)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, SuiteContract.ProcessArray[s.Process], "已审批", "查看");
                    }
                    #endregion
                    #region 总经理不通过
                    else if (s.Process == (int)SuiteContract.guocheng.kjs && s.Pass == (int)SuiteContract.PassorNot.unpass)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ContractNo, s.UserID.Name, s.CustomBaseID == null ? "" : s.CustomBaseID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, SuiteContract.ProcessArray[s.Process] + "不通过", "已审批", "查看");
                    }
                    #endregion
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
