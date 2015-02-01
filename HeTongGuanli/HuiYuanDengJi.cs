using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow.Service;
using CommonControl;


namespace HeTongGuanLi
{
    public partial class HuiYuanDengJi : CommonControl.CommonTabPage
    {
        IList currentcustoms;
        CustomService ss = new CustomService();
        public HuiYuanDengJi()
        {
            InitializeComponent();
        }

      
        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            HuiYuanDengJi_add_Dialog hydj = new HuiYuanDengJi_add_Dialog();
            hydj.IsShowOrInput = 1;
            hydj.ShowDialog();
            if (hydj.IfSaved == 1)
            {
                this.commonDataGridView1.Rows.Clear();
                reFreshAllControl();
            }
            

        }
        public override void reFreshAllControl()
        {
            this.textBox1.Text = "";
            this.textBox3.Text = "";
            this.dateTimePicker1.Value = DateTime.Now;
            this.dateTimePicker2.Value = DateTime.Now;
            this.dateTimePicker3.Value = DateTime.Now;
            this.dateTimePicker4.Value = DateTime.Now;
            this.commonDataGridView1.Rows.Clear();
            currentcustoms = ss.GetAllHuiYuan();
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (HuiYuanBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.Name, HuiYuanBaseInfo.SexArry[s.Sex], s.Birthday, s.Address, s.CompanyName, s.PlateNumber, new DateTime(s.ModificationTime).ToString(), s.ModifiedPlace, s.ModifiedType, "查看", "删除");
                    i++;
                }
            }
        }

        private void HuiYuanDengJi_Load(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            reFreshAllControl();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                HuiYuanDengJi_add_Dialog newGhs = new HuiYuanDengJi_add_Dialog("会员详细信息");
                newGhs.HuiYuanBaseInfo = (HuiYuanBaseInfo)currentcustoms[this.commonDataGridView1.CurrentCell.RowIndex];
                newGhs.IsShowOrInput = 0;
                if (newGhs.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }

            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                HuiYuanBaseInfo s = (HuiYuanBaseInfo)currentcustoms[this.commonDataGridView1.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ss.RemoveHuiYuan(s);
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;
            string cname = this.textBox3.Text;
            long time1 = dateTimePicker1.Value.Date.Ticks;
            long time2 = dateTimePicker2.Value.AddDays(1).Ticks;
            long time3 = dateTimePicker3.Value.Date.Ticks;
            long time4 = dateTimePicker4.Value.AddDays(1).Ticks;
            this.commonDataGridView1.Rows.Clear();
            currentcustoms = ss.SelectMember(name,cname,time1,time2,time3,time4);
            ShowSelectContractGrid();
        }
        private void ShowSelectContractGrid()
        {
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (HuiYuanBaseInfo s in currentcustoms)
                {

                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.Name, HuiYuanBaseInfo.SexArry[s.Sex], s.Birthday, s.Address, s.CompanyName, s.PlateNumber, new DateTime(s.ModificationTime).ToString(), s.ModifiedPlace, s.ModifiedType, "查看", "删除");
                    i++;

                }
            }
        }
       
    }
}
