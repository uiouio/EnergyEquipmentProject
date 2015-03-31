using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SQLProvider.Service;
using CheChuKu.SQL;
using EntityClassLibrary;
using CommonMethod;

namespace CheChuKu
{
    public partial class CheChuKu : CommonControl.CommonTabPage
    {
        public CheChuKu()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            commonDataGridView1.Rows.Clear();
            CheChuKuDataGridView1.Rows.Clear();
            showCheChuKu();
            showCheChuKu1();

        }

        IList Currentss;
        OP_CheChuKu OP_CheChuKu = new OP_CheChuKu();

        private void CheChuKu_Load(object sender, EventArgs e)
        {
            //CheChuKuDataGridView1.Rows.Add(0, "1", "小轿车", "冀A0213", "0000001", "0001","已缴费", "2014.6.25", "编辑");
            //CheChuKuDataGridView1.Rows.Add(0, "2", "重卡", "冀A0564", "0000002", "0002","已缴费", "2014.6.25","编辑");
            //CheChuKuDataGridView1.Rows.Add(1, "3", "小轿车", "冀A2251", "0000003","0003", "已缴费", "2014.6.25", "编辑");
            //CheChuKuDataGridView1.Rows.Add(1, "4", "重卡", "冀A6810", "0000004", "0004","未交全款", "2014.6.25", "编辑");
            reFreshAllControl();
        }

        //private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //        CheChuKuDan tt = new CheChuKuDan();               
        //        tt.SendCarTheLibrary = (this.commonDataGridView1.Rows[e.RowIndex].Tag as Object[])[0] as CarTheLibrary;
        //        tt.ShowDialog();
        //        if (tt.DialogResult == DialogResult.OK)
        //        {
        //            this.commonDataGridView1.CurrentCell.Tag = tt.SendCarTheLibrary;

        //        }

        //}

        public void showCheChuKu()
        {
            Currentss = OP_CheChuKu.GetAllChuKu();
            int i = 1;
            if (Currentss != null)
            {
                foreach (RefitWork s in Currentss)
                {
                    // CarTheLibrary ci = (CarTheLibrary)s[0];
                    //ModificationContract mc = (ModificationContract)s[1];

                    //0, i,// ci.RefitWork.CarInfo.VehicleType, ci.RefitWork.CarInfo.PlateNumber
                    //, ci.RefitWork.ContractNo, ci.RefitWork.DispatchOrder, mc.PaymentState,
                    //new DateTime(ci.FinishTime).ToString("yyyy-MM-dd HH:mm"), ci.Status == (int)CarTheLibrary.savecheck.save ? "出库" : "查看");

                    this.commonDataGridView1.Rows.Add(false, i, s.DispatchOrder, s.ContractNo, s.CarInfo.PlateNumber, s.CarInfo.VehicleType, "出库");

                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        public void showCheChuKu1()
        {
            Currentss = OP_CheChuKu.GetAllChuKu1();
            int i = 1;
            if (Currentss != null)
            {
                foreach (CarTheLibrary s in Currentss)
                {
                    this.CheChuKuDataGridView1.Rows.Add(0, i, s.RefitWork.ContractNo, s.RefitWork.DispatchOrder, s.RefitWork.CarInfo.PlateNumber, s.RefitWork.CarInfo.VehicleType, 
                       new DateTime(s.FinishTime).ToString("yyyy-MM-dd"));
                    this.CheChuKuDataGridView1.Rows[this.CheChuKuDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.CheChuKuDataGridView1.Rows.Clear();
            string number = this.textBox1.Text;
            string order = this.textBox2.Text;
            long time1 = dateTimePicker1.Value.Date.Ticks;
            long time2 = dateTimePicker2.Value.AddDays(+1).Date.Ticks;
            Currentss = OP_CheChuKu.QueryCheChuKu(number,order,time1,time2);
            int i = 1;
            if (Currentss != null)
            {
                //foreach ( s in Currentss)
                //{

                foreach (Object[] ci in Currentss)
                    {
                        CarTheLibrary car = (CarTheLibrary)ci[0];
                        //ModificationContract mc = (ModificationContract)s[1];
                        this.CheChuKuDataGridView1.Rows.Add(0, i.ToString(), car.RefitWork.ContractNo, car.RefitWork.DispatchOrder,
                       car.RefitWork.CarInfo.PlateNumber, car.RefitWork.CarInfo.VehicleType,new DateTime(car.FinishTime).ToString("yyyy-MM-dd"));
                        this.CheChuKuDataGridView1.Rows[this.CheChuKuDataGridView1.Rows.Count - 1].Tag = ci[0];
                        i++;
                    }
                              
                        
                    }
                    //this.CheChuKuDataGridView1.Rows.Add(0,i.ToString(),s.ContractNo,s.DispatchOrder,s.CarInfo.PlateNumber,s.CarInfo.ModidiedType);
                    //this.CheChuKuDataGridView1.Rows[this.CheChuKuDataGridView1.Rows.Count - 1].Tag = s;
                    //i++;
                //}
            }


        private void commonDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (this.commonDataGridView1.Rows.Count > 0)
            {
                //出库操作
                if (e.ColumnIndex == 6)
                {
                    CheChuKuDan chk = new CheChuKuDan();
                    chk.RefitWork = this.commonDataGridView1.CurrentRow.Tag as RefitWork;
                    chk.ShowDialog();

                    if (chk.DialogResult == DialogResult.OK)
                    {
                        this.commonDataGridView1.Rows.Remove(this.commonDataGridView1.CurrentRow);
                        this.CheChuKuDataGridView1.Rows.Add(0, this.CheChuKuDataGridView1.Rows.Count + 1, chk.SendCarTheLibrary.RefitWork.ContractNo, chk.SendCarTheLibrary.RefitWork.DispatchOrder,
                           chk.SendCarTheLibrary.RefitWork.CarInfo.PlateNumber, chk.SendCarTheLibrary.RefitWork.CarInfo.VehicleType,
                             new DateTime(chk.SendCarTheLibrary.FinishTime).ToString("yyyy-MM-dd"));

                    }

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Cursor = Cursors.WaitCursor;
            this.commonDataGridView1.Rows.Clear();
            string number = this.textBox1.Text;
            string order = this.textBox2.Text;
            Currentss = OP_CheChuKu.QueryDaiCheChuKu(number, order);
            int i = 1;
            if (Currentss != null)
            {
                foreach (object[] s in Currentss)
                {
                    CheRuKuInfo ci = (CheRuKuInfo)s[0];
                    ModificationContract mc = (ModificationContract)s[1];
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), ci.RefitWork.CarInfo.VehicleType, ci.RefitWork.CarInfo.PlateNumber
                        , ci.RefitWork.ContractNo, ci.RefitWork.DispatchOrder, "出库");
                    this.CheChuKuDataGridView1.Rows[this.CheChuKuDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
            this.button1.Cursor = Cursors.Hand;

        }

        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            this.commonPictureButton3.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(commonDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);

            PrintDataGridView.PrintTheDataGridView(d1);

            DoExport.DoTheExport(d1);

            this.commonPictureButton3.Cursor = Cursors.Hand;

        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            this.commonPictureButton2.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(commonDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);

            DoExport.DoTheExport(d1);

            this.commonPictureButton2.Cursor = Cursors.Hand;
        }

    }
}

