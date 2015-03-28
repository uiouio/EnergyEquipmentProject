using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CustomManageWindow.Service;
using EntityClassLibrary;
using CommonControl;
using CommonMethod;
using CommonControl;
namespace CustomManageWindow
{
    public partial class CustomServiceQuery : CommonControl.CommonTabPage
    {
        IList currentrecords,currentrecords1;
        CustomerRecordService ss = new CustomerRecordService();
        public CustomServiceQuery()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomReport_Add_Dialog customReport = new CustomReport_Add_Dialog();
            customReport.dialogFlag = 1;
            customReport.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CustomServiceQuery_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }
        public override void reFreshAllControl()
        {
           // this.textBox7.Text = "";
            //this.textBox20.Text = "";
            //this.textBox21.Text = "";
            //this.textBox22.Text = "";
            this.commonDataGridView1.Rows.Clear();
            this.commonDataGridView2.Rows.Clear();
            //currentrecords = ss.GetAllCustomServiceRecord();
            //int i = 1;
            //if (currentrecords != null)
            //{ 
            //    foreach(CustomerServiceRecord s in currentrecords )
            //    {
            //        this.commonDataGridView2.Rows.Add(i.ToString(),s.CarInfo.PlateNumber , s.PhoneTime, s.PhoneWorker, s.Question, s.HandleOpinion, s.Remark,"查看");
            //        i++;
            //    }  
            //}

            //currentrecords = ss.GetAllCarsInfo();
            //i = 1;
            //if (currentrecords != null)
            //{
            //    foreach (CarTheLibrary s in currentrecords)
            //    {
            //        this.commonDataGridView1.Rows.Add(i.ToString(), s.RefitWork.CarInfo.PlateNumber, s.RefitWork.CarInfo.VehicleType, s.RefitWork.CarInfo.Cbi == null ? "" : s.RefitWork.CarInfo.Cbi.Name, s.RefitWork.CarInfo.Cbi == null ? "" : s.RefitWork.CarInfo.Cbi.Telephone, new DateTime( s.FinishTime), "n", "查看", "增加");
            //        i++;
            //    }
            //}
            currentrecords = ss.GetAllCarsInfo();
            ShowSelectedCarGrid();

            currentrecords1 = ss.GetAllCustomServiceRecord();
            ShowCustomServiceRecordGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            string s1 = this.textBox1.Text;
            string s2 = this.textBox2.Text;
            string s3 = this.textBox3.Text;
            long dname = this.dateTimePicker1.Value.Date.Ticks;
            long ename = this.dateTimePicker2.Value.Ticks + new DateTime(1, 1, 2).Date.Ticks;
            currentrecords=ss.SelectCarsRecord(s1,s2,s3,dname,ename);
            ShowSelectedCarGrid();

        }
        
        public void ShowSelectedCarGrid()
        {
            commonDataGridView1.Rows.Clear();
            int i = 1;
            if (currentrecords != null)
            {
                foreach (CarTheLibrary s in currentrecords)
                {
                    string counts= ss.SelectCustomServiceRecordByPlateNo(s.RefitWork.CarInfo.PlateNumber).Count.ToString();
                    this.commonDataGridView1.Rows.Add(i.ToString(), 
                        s.RefitWork.CarInfo.PlateNumber, 
                        s.RefitWork.CarInfo.VehicleType, 
                        s.RefitWork.CarInfo.Cbi == null ? "" : s.RefitWork.CarInfo.Cbi.Name, 
                        s.RefitWork.CarInfo.Cbi == null ? "" : s.RefitWork.CarInfo.Cbi.Telephone,
                        new DateTime( s.FinishTime).ToString(), 
                        counts, 
                        "查看", "新建回访记录");
                    i++;
                }
            }
        }
        public void ShowCustomServiceRecordGrid()
        {
            commonDataGridView2.Rows.Clear();
            int i = 1;
            if (currentrecords1 != null)
            {
                foreach(CustomerServiceRecord s in currentrecords1 )
                {
                    this.commonDataGridView2.Rows.Add(i.ToString(), s.CarInfo.PlateNumber, s.PhoneTime, s.PhoneWorker, s.Question, s.HandleOpinion, s.Remark, "查看");
                    i++;
                } 
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            commonDataGridView1.Rows.Clear();
            currentrecords = ss.GetAllCarsInfo();
            ShowSelectedCarGrid();
            
        }

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                CustomReport_Add_Dialog newGhs = new CustomReport_Add_Dialog();
                //newGhs.Currentrecords.CarInfo.Cbi.Name=currentrecords;
                newGhs.Currentrecords = (CustomerServiceRecord)currentrecords1[this.commonDataGridView2.CurrentCell.RowIndex];
                newGhs.dialogFlag=0;//查看
                if (newGhs.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView2.Rows.Clear();
                    reFreshAllControl();
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            dateTimePicker1.Value =DateTime.Today.AddDays(-1);

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddDays(-7);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddMonths(-1);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddYears(-1);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("helloword");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddDays(-1);
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string str;
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                str = commonDataGridView1["车牌号", commonDataGridView1.CurrentCell.RowIndex].Value.ToString();
                currentrecords1 = ss.SelectCustomServiceRecordByPlateNo(str);
                ShowCustomServiceRecordGrid();
            }
            if (grid.CurrentCell.Value.ToString() == "新建回访记录")
            {
                str = commonDataGridView1["车牌号", commonDataGridView1.CurrentCell.RowIndex].Value.ToString();
                
                CustomReport_Add_Dialog newGhs = new CustomReport_Add_Dialog();
                newGhs.UserInfo = this.User;
                newGhs.plateNo = str;//车牌号
                newGhs.dialogFlag = 1;//新建
                if (newGhs.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView2.Rows.Clear();
                    reFreshAllControl();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            currentrecords1 = ss.SelectCustomServiceRecordByPhoneWorker(textBox4.Text);
            ShowCustomServiceRecordGrid();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                pictureBox2_Click(this, e);
            }
        }
    }
}
