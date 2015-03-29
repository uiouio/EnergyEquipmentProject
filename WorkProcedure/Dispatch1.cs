using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WorkProcedure.SQL;
using SQLProvider.Service;
using EntityClassLibrary;
using CommonMethod;

namespace WorkProcedure
{
    public partial class Dispatch1 : CommonControl.CommonTabPage
    {

        
        OP_LZB OP_LZB = new OP_LZB();
        IList Currentss;
       

        
        public Dispatch1()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            commonDataGridView1.Rows.Clear();
            ShowPaiGongDan();
        }

        private void Dispatch1_Load(object sender, EventArgs e)
        {
            

            reFreshAllControl();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (commonDataGridView1.CurrentCell.Value.ToString() == "派工")
            {
                GongZuoZhuXuanZe gongZuoZhuXuanZe = new GongZuoZhuXuanZe();
                gongZuoZhuXuanZe.RefitWork = (RefitWork)this.commonDataGridView1.Rows[e.RowIndex].Tag;
                gongZuoZhuXuanZe.ShowDialog();

                if (gongZuoZhuXuanZe.DialogResult == DialogResult.OK)
                {
                    this.commonDataGridView1.CurrentRow.Tag = gongZuoZhuXuanZe.RefitWork;
                    if (gongZuoZhuXuanZe.RefitWork.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth)
                    {
                        this.commonDataGridView1.Rows[e.RowIndex].Cells[9].Value = DateTime.Now.ToString("yyyy-MM-dd");
                        this.commonDataGridView1.Rows[e.RowIndex].Cells[10].Value = "已派工";
                        this.commonDataGridView1.Rows[e.RowIndex].Cells[11].Value = "";
                    }
                }
            }

        }

        public void ShowPaiGongDan()  //方法
        {
            Currentss = OP_LZB.GetAllPaiGongDan();
            int i = 1;
            if (Currentss != null)
            {
                foreach (RefitWork s in Currentss)
                {
                    if (s.CarInfo.ModidiedType == 0)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder, "CNG汽油", s.CarInfo.VIN, s.CarInfo.PlateNumber, s.CarInfo.VehicleType, s.CarInfo.CylinderNo,
                          new DateTime(s.FormulateDate).ToString("yyyy-MM-dd"), new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"), s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "待派工" : "已派工", s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth ? "" : "派工");
                    }
                    else if (s.CarInfo.ModidiedType == 1)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder, "CNG柴油", s.CarInfo.VIN, s.CarInfo.PlateNumber, s.CarInfo.VehicleType, s.CarInfo.CylinderNo,
                          new DateTime(s.FormulateDate).ToString("yyyy-MM-dd"), new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"), s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "待派工" : "已派工", s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth ? "" : "派工");

                    }
                    else if (s.CarInfo.ModidiedType == 2)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder, "LNG柴油", s.CarInfo.VIN, s.CarInfo.PlateNumber, s.CarInfo.VehicleType, s.CarInfo.CylinderNo,
                          new DateTime(s.FormulateDate).ToString("yyyy-MM-dd"), new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"), s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "待派工" : "已派工", s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth ? "" : "派工");
                    }
                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Cursor = Cursors.WaitCursor;
            this.commonDataGridView1.Rows.Clear();
            string number=textBox1.Text;
            int Screening=comboBox1.SelectedIndex;
            long time1 = dateTimePicker1.Value.Date.Ticks;
            long time2 = dateTimePicker2.Value.Date.AddDays(+1).Ticks;
            Currentss = OP_LZB.QueryPaiGongDan(number,Screening,time1,time2);
            int i = 1;
            if (Currentss != null)
            {
                foreach (RefitWork s in Currentss)
                {
                    if (s.CarInfo.ModidiedType == 0)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder, "CNG汽油", s.CarInfo.VIN, s.CarInfo.PlateNumber, s.CarInfo.VehicleType, s.CarInfo.CylinderNo,
                          new DateTime(s.FormulateDate).ToString("yyyy-MM-dd"), new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"), s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "待派工" : "已派工", s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth ? "" : "派工");
                    }
                    else if (s.CarInfo.ModidiedType == 1)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder, "CNG柴油", s.CarInfo.VIN, s.CarInfo.PlateNumber, s.CarInfo.VehicleType, s.CarInfo.CylinderNo,
                          new DateTime(s.FormulateDate).ToString("yyyy-MM-dd"), new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"), s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "待派工" : "已派工", s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth ? "" : "派工");

                    }
                    else if (s.CarInfo.ModidiedType == 2)
                    {
                        this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder, "LNG柴油", s.CarInfo.VIN, s.CarInfo.PlateNumber, s.CarInfo.VehicleType, s.CarInfo.CylinderNo,
                          new DateTime(s.FormulateDate).ToString("yyyy-MM-dd"), new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"), s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "待派工" : "已派工", s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth ? "" : "派工");
                    }
                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
            this.button4.Cursor = Cursors.Hand;
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            this.commonPictureButton2.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(commonDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);
            d1.Columns.Remove(d1.Columns[0]);
            DoExport.DoTheExport(d1);
            this.commonPictureButton2.Cursor = Cursors.Hand;
        }

        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            this.commonPictureButton3.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(commonDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);
            d1.Columns.Remove(d1.Columns[0]);
            PrintDataGridView.PrintTheDataGridView(d1);
            this.commonPictureButton3.Cursor = Cursors.Hand;
        }

       
    }
}
