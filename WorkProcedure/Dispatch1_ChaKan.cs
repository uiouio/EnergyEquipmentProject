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
using EntityClassLibrary;
using GongYiGuanLi;
using CommonMethod;

namespace WorkProcedure
{
    public partial class Dispatch1_ChaKan : CommonControl.CommonTabPage
    {
        OP_LZB OP_LZB = new OP_LZB();
        IList Currentss;
        IList group;
        public Dispatch1_ChaKan()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            commonDataGridView1.Rows.Clear();
            ShowPaiGongDanChaKan();
        }
        private void Dispatch1_ChaKan_Load(object sender, EventArgs e)
        {
            //commonDataGridView1.Rows.Add(0, "1", "000001", "LNG+柴油(机械泵)", "冀B27173", "小轿车", "2014.7.14", "未派工", "第一组");
            reFreshAllControl();
            group = OP_LZB.GetAllGroups();
            LoadCombobox2();
        }

        public void ShowPaiGongDanChaKan()
        {
            Currentss = OP_LZB.GetAllPaiGongDan();
            int i=1;
            if (Currentss != null)
            {
                foreach (RefitWork s in Currentss)
                {
                    if (s.WorkingGroupId != null)
                    {
                        if (s.CarInfo.ModidiedType == 0)
                        {
                            this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder,
                              "CNG汽油", s.CarInfo.VIN, s.CarInfo.PlateNumber,
                               s.CarInfo.VehicleType, new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"),
                                s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "未派工" : "已派工", s.WorkingGroupId.WorkingGroupName, "查看");
                        }
                        else if (s.CarInfo.ModidiedType == 1)
                        {
                            this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder,
                              "CNG柴油", s.CarInfo.VIN, s.CarInfo.PlateNumber,
                               s.CarInfo.VehicleType, new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"),
                                s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "未派工" : "已派工", s.WorkingGroupId.WorkingGroupName, "查看");
                        }else if(s.CarInfo.ModidiedType == 2)
                        {
                            this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder,
                              "LNG柴油", s.CarInfo.VIN, s.CarInfo.PlateNumber,
                               s.CarInfo.VehicleType, new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"),
                                s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "未派工" : "已派工", s.WorkingGroupId.WorkingGroupName, "查看");
                        }
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = s;
                        i++;
                    }
                   
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Cursor = Cursors.WaitCursor;
            commonDataGridView1.Rows.Clear();
            string number = this.textBox1.Text;
            int dispatch = this.comboBox1.SelectedIndex;
            string platenumber = this.textBox2.Text;
            string workgroup = this.comboBox2.Text;
            //WorkingGroup workgroup = this.comboBox2.SelectedValue as WorkingGroup;
            Currentss = OP_LZB.QueryPaiGongDanChaKan(number,dispatch,platenumber,workgroup);
            int i = 1;
            if (Currentss != null)
            {
                foreach (RefitWork s in Currentss)
                {
                    if (s.WorkingGroupId != null)
                    {
                        if (s.CarInfo.ModidiedType == 0)
                        {
                            this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder,
                              "CNG汽油", s.CarInfo.VIN, s.CarInfo.PlateNumber,
                               s.CarInfo.VehicleType, new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"),
                                s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "未派工" : "已派工", s.WorkingGroupId.WorkingGroupName, "查看");
                        }
                        else if (s.CarInfo.ModidiedType == 1)
                        {
                            this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder,
                              "CNG柴油", s.CarInfo.VIN, s.CarInfo.PlateNumber,
                               s.CarInfo.VehicleType, new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"),
                                s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "未派工" : "已派工", s.WorkingGroupId.WorkingGroupName, "查看");
                        }
                        else if (s.CarInfo.ModidiedType == 2)
                        {
                            this.commonDataGridView1.Rows.Add(0, i.ToString(), s.DispatchOrder,
                              "LNG柴油", s.CarInfo.VIN, s.CarInfo.PlateNumber,
                               s.CarInfo.VehicleType, new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"),
                                s.DispatchState == (int)RefitWork.SaveDispatchingDispatchReceive.Save ? "未派工" : "已派工", s.WorkingGroupId.WorkingGroupName, "查看");
                        }
                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = s;
                        i++;
                    }
                   
                }
            }
            this.button4.Cursor = Cursors.Hand;

        }

        //private void comboBox2_DropDown(object sender, EventArgs e)
        //{
        //    if (this.comboBox2.Items.Count == 0)
        //    {
        //        IList group = OP_LZB.GetAllGroups();
        //        if (group != null)
        //        {
        //            this.comboBox2.DataSource = group;
        //            this.comboBox2.DisplayMember = "WorkingGroupName";
        //            this.comboBox2.ValueMember = "Itself";
        //        }
        //    }
        //}

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
        //    if (this.comboBox1.Items.Count == 0)
        //    {
        //        IList group = OP_LZB.GetAllPaiGongDanShaiXuan();
        //        if (group != null)
        //        {
        //            //this.comboBox1.DataSource = group;
        //            //this.comboBox1.DisplayMember = "RefitWork";
        //            //this.comboBox1.ValueMember = "Itself";
        //            int i = 0;
        //            foreach (RefitWork o in group)
        //            {
        //                if (o.CarInfo.ModidiedType == 0)
        //                {
        //                    this.comboBox1.Items.Insert(i, "CNG汽油");
        //                    this.comboBox1.ValueMember = o.CarInfo.ModidiedType.ToString(); 
        //                }
        //                else if (o.CarInfo.ModidiedType == 1)
        //                {
        //                    this.comboBox1.Items.Insert(i, "CNG柴油");
        //                    this.comboBox1.ValueMember = o.CarInfo.ModidiedType.ToString(); 

        //                }
        //                else if (o.CarInfo.ModidiedType == 2)
        //                {
        //                    this.comboBox1.Items.Insert(i, "LNG柴油");
        //                    this.comboBox1.ValueMember = o.CarInfo.ModidiedType.ToString(); 

        //                }

        //                i++;
        //            }
                //}
           // }

        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefitWork s = (RefitWork)this.commonDataGridView1.Rows[e.RowIndex].Tag;
            if (e.ColumnIndex == 10)
            {
                CopyPaiGongDan_add_Dialog tt = new CopyPaiGongDan_add_Dialog();               
                tt.RefitWork = s;
                tt.ShowDialog();
            }
            
        }

        private void LoadCombobox2()
        {
            if (this.comboBox2.Items.Count == 0)
            {
                if (group != null)
                {
                    this.comboBox2.DataSource = group;
                    this.comboBox2.DisplayMember = "WorkingGroupName";
                    //this.comboBox2.ValueMember = "Itself";
                }
            }
        
        }



        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(commonDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);

            PrintDataGridView.PrintTheDataGridView(d1);
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(commonDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);

            DoExport.DoTheExport(d1);
        }

      /*  private void comboBox2_DropDown(object sender, EventArgs e)
        {
            if (this.comboBox2.Items.Count == 0)
            {
                IList group = OP_LZB.GetAllGroups();
                if (group != null)
                {
                    this.comboBox2.DataSource = group;
                    this.comboBox2.DisplayMember = "WorkingGroupName";
                    //this.comboBox2.ValueMember = "Itself";
                }
            }
        }*/


      

        }
    }

