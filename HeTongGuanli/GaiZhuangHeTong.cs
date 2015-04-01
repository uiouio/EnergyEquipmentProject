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
    public partial class GaiZhuangHeTong : CommonControl.CommonTabPage
    {

        IList currenthetongs;
        ContractService hs = new ContractService();
        private ModificationContract modificationContract;

        public ModificationContract ModificationContract
        {
            get { return modificationContract; }
            set { modificationContract = value; }
        }
        public GaiZhuangHeTong()
        {
            InitializeComponent();
        }
        public override void reFreshAllControl()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.start_dateTimePicker.Value = DateTime.Now;
            this.end_dateTimePicker.Value = DateTime.Now;
            this.commonDataGridView.Rows.Clear();
            currenthetongs = hs.GetAllContract();

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
                        #region  销售负责人待审批
                        if (s.Process == (int)ModificationContract.guocheng.xsfzr && s.Pass == (int)ModificationContract.PassorNot.pass)
                        {
                            this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                        }
                        #endregion
                        #region  总会计师待审批
                     //   else if (s.Process == (int)ModificationContract.guocheng.kjs && s.Pass == (int)ModificationContract.PassorNot.pass)
                      //  {
                          //  this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                     //   }
                        #endregion
                        #region  总经理待审批
                        else if (s.Process == (int)ModificationContract.guocheng.zjl && s.Pass == (int)ModificationContract.PassorNot.pass)
                        {
                            this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                        }
                        #endregion
                        #region 销售负责人不通过
                        else if(s.Process==(int)ModificationContract.guocheng.xsfzr&&s.Pass==(int)ModificationContract.PassorNot.unpass)
                        {
                            this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                        }
                        #endregion 
                        #region 总会计师不通过
                       // else if(s.Process==(int)ModificationContract.guocheng.kjs&&s.Pass==(int)ModificationContract.PassorNot.unpass)
                       // {
                       //     this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                       // }
                        #endregion
                        #region 总经理不通过
                        else if(s.Process==(int)ModificationContract.guocheng.zjl&&s.Pass==(int)ModificationContract.PassorNot.unpass)
                        {
                            this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                        }
                        #endregion
                        #region 合同通过
                        else if (s.Process == (int)ModificationContract.guocheng.htbgy&&s.Pass==(int)ModificationContract.PassorNot.pass)
                        {
                            this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process], "查看", "删除");
                        }
                        #endregion
                        i++;
                    }  
                    
                }
            }
        
     
        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            MuBanSelect_Dialog gad = new MuBanSelect_Dialog();
            gad.IsModifyOrSuite = 0;
            gad.UserInfo = this.User;
            if (gad.ShowDialog() == DialogResult.OK)
            {
                this.commonDataGridView.Rows.Clear();
                reFreshAllControl();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            string cname = textBox2.Text;

            long time1 = start_dateTimePicker.Value.Date.Ticks;

            long time2 = end_dateTimePicker.Value.Date.Ticks + new DateTime(1, 1, 2).Date.Ticks;

            this.commonDataGridView.Rows.Clear();
           
            currenthetongs = hs.SelectHeTong(name, cname, time1, time2);
           
            ShowSelectContractGrid();
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
                   
                    #region  销售负责人待审批
                    if (s.Process == (int)ModificationContract.guocheng.xsfzr && s.Pass == (int)ModificationContract.PassorNot.pass)
                    {
                       
                            this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "待审批", "查看", "删除");
                             
                    }
                    #endregion
                    #region  总会计师待审批
                  //  else if (s.Process == (int)ModificationContract.guocheng.kjs && s.Pass == (int)ModificationContract.PassorNot.pass)
                   // {
                      
                    ///        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "待审批", "查看", "删除");
                            
                       
                  //  }
                    #endregion
                    #region  总经理待审批
                    else if (s.Process == (int)ModificationContract.guocheng.zjl && s.Pass == (int)ModificationContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name, s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "待审批", "查看", "删除");

                    }
                    #endregion
                    #region 销售负责人不通过
                    else if (s.Process == (int)ModificationContract.guocheng.xsfzr && s.Pass == (int)ModificationContract.PassorNot.unpass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                    }
                    #endregion
                    #region 总会计师不通过
                   // else if (s.Process == (int)ModificationContract.guocheng.kjs && s.Pass == (int)ModificationContract.PassorNot.unpass)
                    //{
                      //  this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "不通过", "查看", "删除");
                 //   }
                    #endregion
                    #region 总经理不通过
                    else if (s.Process == (int)ModificationContract.guocheng.zjl && s.Pass == (int)ModificationContract.PassorNot.unpass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "不通过", "编辑", "删除");
                    }
                    #endregion
                    #region 总经理通过
                    else if (s.Process == (int)ModificationContract.guocheng.htbgy && s.Pass == (int)ModificationContract.PassorNot.pass)
                    {
                        this.commonDataGridView.Rows.Add(0, i.ToString(), s.ContractNo, cbi == null || s.CarBaseInfoID.Count == 0 ? "" : cbi.Cbi.Name,  s.CarBaseInfoID == null || s.CarBaseInfoID.Count == 0 ? "" : ModificationContract.ModifyType[cbi.ModidiedType], s.UserID.Name, new DateTime(s.SignedDate).ToString(), s.ContractAmount, s.PaymentMethod, ModificationContract.ProcessArray[s.Process] + "已通过", "查看", "删除");
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
                GaiZhuangContractView gz = new GaiZhuangContractView();
                gz.ModificationContract = (ModificationContract)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];
                if (gz.ShowDialog() == DialogResult.OK) 
                {
                    this.commonDataGridView.Rows.Clear();
                    reFreshAllControl();
                
                
                }

            }
            else if (grid.CurrentCell.Value.ToString() == "编辑")
            {
                GaiZhuangContractView1 gz = new GaiZhuangContractView1();
                gz.ModificationContract = (ModificationContract)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];
                if (gz.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView.Rows.Clear();
                    reFreshAllControl();


                }

            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                ModificationContract s = (ModificationContract)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    hs.Remove(s);
                    this.commonDataGridView.Rows.Clear();
                    reFreshAllControl();
                }
            }
        }

        private void GaiZhuangHeTong_Load(object sender, EventArgs e)
        {
            this.commonDataGridView.Rows.Clear();
            reFreshAllControl();
        }

        private void commonDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GaiZhuangContractView gz = new GaiZhuangContractView();
            gz.ModificationContract = (ModificationContract)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];
            if (gz.ShowDialog() == DialogResult.OK)
            {
                this.commonDataGridView.Rows.Clear();
                reFreshAllControl();


            }
        }
    }
   }
