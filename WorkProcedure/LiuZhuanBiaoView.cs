using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WorkProcedure.SQL;
using EntityClassLibrary;


namespace WorkProcedure
{
    public partial class LiuZhuanBiaoView : CommonControl.CommonTabPage
    {
        OP_LZB OP_LZB = new OP_LZB();
        IList Currentss;
        
        public LiuZhuanBiaoView()
        {
            InitializeComponent();
        }
        public override void reFreshAllControl()
        {
            this.LiuZhuanBiaoDataGridView1.Rows.Clear();
            ShowGridView();
        }


        private void LiuZhuanBiaoView_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex==8)
            {
                LiuZhuanBiaoView_Detail tt=new LiuZhuanBiaoView_Detail();
                tt.ReceiveLiuZhuanDate = (LiuZhuanBiao)this.LiuZhuanBiaoDataGridView1.CurrentRow.Tag;              
                tt.ShowDialog();
                if (tt.DialogResult == DialogResult.OK)
                {

                    this.LiuZhuanBiaoDataGridView1.CurrentRow.Tag = tt.ReceiveLiuZhuanDate;
                    if (tt.ReceiveLiuZhuanDate.ScratchSaveState == (int)LiuZhuanBiao.ScratchSave.Save)
                    {
                        this.LiuZhuanBiaoDataGridView1.Rows[e.RowIndex].Cells[8].Value = "查看";
                        this.LiuZhuanBiaoDataGridView1.Rows[e.RowIndex].Cells[7].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                
                }
                //if (tt.IsLiuZhuanBiao == 1)
                //{
                //    this.LiuZhuanBiaoDataGridView1.Rows[e.RowIndex].Cells[7].Value = "查看";
                //    tt.LiuZhuanBiaoView_Detail1 =(LiuZhuanBiaoView_Detail)LiuZhuanBiaoDataGridView1.CurrentRow.Tag;
                //    LiuZhuanBiaoView_Detail ss = new LiuZhuanBiaoView_Detail();
                //    ss.ShowDialog();
                //}
            }

           
           /* if (LiuZhuanBiaoDataGridView1.CurrentCell.Value.ToString() == "编辑")
            {
                LiuZhuanBiaoEdit_Edit tt = new LiuZhuanBiaoEdit_Edit();
                tt.chePaiHao = LiuZhuanBiaoDataGridView1[2, LiuZhuanBiaoDataGridView1.CurrentRow.Index].Value.ToString();
                tt.ShowDialog();
            }*/
        }


        public void ShowGridView()
        {
            Currentss = OP_LZB.GetAllLiuZhuanBiaoInfo();
            int i = 1;
            if (Currentss != null)
            {
                foreach (LiuZhuanBiao s in Currentss)
                {

                    this.LiuZhuanBiaoDataGridView1.Rows.Add(0, i.ToString(),
                        s.PaiGongDan.DispatchOrder, s.PaiGongDan.CarInfo.PlateNumber,
                        s.PaiGongDan.CarInfo.VehicleType, s.PaiGongDan.WorkingGroupId.WorkingGroupName, new DateTime(s.PaiGongDan.DispatchTime).ToString("yyyy-MM-dd"), 
                        new DateTime(s.Time).ToString("yyyy-MM-dd"), s.ScratchSaveState == (int)LiuZhuanBiao.ScratchSave.Save ? "查看" : "编辑");
                    this.LiuZhuanBiaoDataGridView1.Rows[this.LiuZhuanBiaoDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            this.LiuZhuanBiaoDataGridView1.Rows.Clear();
            string number = this.textBox1.Text;
            string platenumber = this.textBox2.Text;
            long time1 = this.dateTimePicker1.Value.Date.Ticks;
            long time2 = this.dateTimePicker2.Value.Date.AddDays(+1).Ticks;
            Currentss = OP_LZB.QueryLiuZhuanBiao(number,platenumber,time1,time2);
            int i = 1;
            if (Currentss != null)
            {
                foreach (LiuZhuanBiao s in Currentss)
                {
                    this.LiuZhuanBiaoDataGridView1.Rows.Add(0,i.ToString(),s.PaiGongDan.DispatchOrder, s.PaiGongDan.CarInfo.PlateNumber, 
                        s.PaiGongDan.CarInfo.VehicleType, s.PaiGongDan.WorkingGroupId.WorkingGroupName,
                        new DateTime(s.PaiGongDan.DispatchTime).ToString("yyyy-MM-dd"), new DateTime(s.Time).ToString("yyyy-MM-dd"), s.ScratchSaveState == (int)LiuZhuanBiao.ScratchSave.Save ? "查看" : "编辑");
                    this.LiuZhuanBiaoDataGridView1.Rows[this.LiuZhuanBiaoDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        //private void comboBox1_DropDown(object sender, EventArgs e)
        //{
        //    if (this.comboBox1.Items.Count == 0)
        //    {
        //        IList group = OP_LZB.GetAllGroups();
        //        if (group != null)
        //        {
        //            this.comboBox1.DataSource = group;
        //            this.comboBox1.DisplayMember = "WorkingGroupName";
        //            this.comboBox1.ValueMember = "Itself";
        //        }
        //    }
        //}

             
    }
}
