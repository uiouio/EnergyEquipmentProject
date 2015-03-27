using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CheRuKu.SQL;
using SQLProvider.Service;
using EntityClassLibrary;
using CommonMethod;

namespace CheRuKu
{
    public partial class CheRuKu : CommonControl.CommonTabPage
    {
        public CheRuKu()
        {
            InitializeComponent();
        }

        IList Currentss;
        OP_ChuRuKu OP_ChuRuKu = new OP_ChuRuKu();

        private void CheRuKu_Load(object sender, EventArgs e)
        {
            //CheRuKuDataGridView1.Rows.Add(0, "1", "小轿车", "冀B00002", "0000000001","0001", "已缴费", "2014.6.25","编辑");
            //CheRuKuDataGridView1.Rows.Add(1, "2", "小轿车", "冀B00012", "0000000002","0002", "已缴费", "2014.6.25", "编辑");
            //CheRuKuDataGridView1.Rows.Add(0, "3", "重卡", "冀B00022", "0000000003", "0003","已缴费", "2014.6.25", "编辑");
            //CheRuKuDataGridView1.Rows.Add(1, "4", "重卡", "冀B00052", "0000000004", "0004","未交全款", "2014.6.25", "编辑");
            reFreshAllControl();
        }

        public override void  reFreshAllControl()
        {
          
            CheRuKuDataGridView1.Rows.Clear();
            ShowGridView();
        }
       
        private void CheRuKuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==8)
            {
                CheRuKuDan tt = new CheRuKuDan();
                //Object [] i= (Object []);
                // (CheRuKuInfo)i[0];
                //CheRuKuInfo cc = new CheRuKuInfo();
                //cc = 
                tt.CheRuKuInfo = (this.CheRuKuDataGridView1.Rows[e.RowIndex].Tag as Object[])[0] as CheRuKuInfo;
                   
                tt.ShowDialog();
                if (tt.DialogResult == DialogResult.OK)
                {
                   
                    this.CheRuKuDataGridView1.CurrentRow.Tag = tt.CheRuKuInfo;
                    if (tt.CheRuKuInfo.Status == (int)EntityClassLibrary.CheRuKuInfo.savecheck.check)
                    {
                        this.CheRuKuDataGridView1.Rows[e.RowIndex].Cells[7].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        this.CheRuKuDataGridView1.Rows[e.RowIndex].Cells[8].Value = "查看";
                    }
                }
               
            }
        }

        public void ShowGridView()
        {
            Currentss = OP_ChuRuKu.GetAllRuKu();

            int i = 1;
            if (Currentss != null)
            {
                foreach (Object[] s in Currentss)
                {
                    CheRuKuInfo ci = (CheRuKuInfo)s[0];
                    ModificationContract mc = (ModificationContract)s[1];
                    if (mc.PaymentState == 0)
                    {
                        this.CheRuKuDataGridView1.Rows.Add(0, i.ToString(), ci.RefitWork.ContractNo, ci.RefitWork.DispatchOrder, ci.RefitWork.CarInfo.PlateNumber, ci.RefitWork.CarInfo.VehicleType, "未付款",
                            new DateTime(ci.ActualCompletionDate).ToString("yyyy-MM-dd HH:mm"), ci.Status == (int)CheRuKuInfo.savecheck.save ? "编辑" : "查看");
                    }
                    else if (mc.PaymentState == 1)
                    {
                        this.CheRuKuDataGridView1.Rows.Add(0, i.ToString(), ci.RefitWork.ContractNo, ci.RefitWork.DispatchOrder, ci.RefitWork.CarInfo.PlateNumber, ci.RefitWork.CarInfo.VehicleType, "已付部分",
                             new DateTime(ci.ActualCompletionDate).ToString("yyyy-MM-dd HH:mm"), ci.Status == (int)CheRuKuInfo.savecheck.save ? "编辑" : "查看");
                    }
                    else if (mc.PaymentState == 2)
                    {
                        this.CheRuKuDataGridView1.Rows.Add(0, i.ToString(), ci.RefitWork.ContractNo, ci.RefitWork.DispatchOrder, ci.RefitWork.CarInfo.PlateNumber, ci.RefitWork.CarInfo.VehicleType, "已付款",
                            new DateTime(ci.ActualCompletionDate).ToString("yyyy-MM-dd HH:mm"), ci.Status == (int)CheRuKuInfo.savecheck.save ? "编辑" : "查看");
                    }
                    this.CheRuKuDataGridView1.Rows[this.CheRuKuDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheRuKuDataGridView1.Rows.Clear();
            string number = this.textBox1.Text;
            string order = this.textBox2.Text;
            long time1 = dateTimePicker1.Value.Date.Ticks;
            long time2 = dateTimePicker2.Value.Date.AddDays(+1).Ticks;
            Currentss = OP_ChuRuKu.QueryCheRuKu(number,order,time1,time2);
            int i = 1;
            if (Currentss != null)
            {
                foreach (object[] s in Currentss)
                {
                    CheRuKuInfo ci = (CheRuKuInfo)s[0];
                    ModificationContract mc = (ModificationContract)s[1];
                    if (mc.PaymentState == 0)
                    {
                        this.CheRuKuDataGridView1.Rows.Add(0, i.ToString(), ci.RefitWork.ContractNo, ci.RefitWork.DispatchOrder, ci.RefitWork.CarInfo.PlateNumber, ci.RefitWork.CarInfo.VehicleType, "未付款",
                            new DateTime(ci.ActualCompletionDate).ToString("yyyy-MM-dd HH:mm"), ci.Status == (int)CheRuKuInfo.savecheck.save ? "编辑" : "查看");
                    }else if(mc.PaymentState==1)
                    {
                        this.CheRuKuDataGridView1.Rows.Add(0, i.ToString(), ci.RefitWork.ContractNo, ci.RefitWork.DispatchOrder, ci.RefitWork.CarInfo.PlateNumber, ci.RefitWork.CarInfo.VehicleType, "已付部分",
                             new DateTime(ci.ActualCompletionDate).ToString("yyyy-MM-dd HH:mm"), ci.Status == (int)CheRuKuInfo.savecheck.save ? "编辑" : "查看");
                    }else if(mc.PaymentState==2)
                    {
                        this.CheRuKuDataGridView1.Rows.Add(0, i.ToString(), ci.RefitWork.ContractNo, ci.RefitWork.DispatchOrder, ci.RefitWork.CarInfo.PlateNumber, ci.RefitWork.CarInfo.VehicleType, "已付款",
                            new DateTime(ci.ActualCompletionDate).ToString("yyyy-MM-dd HH:mm"), ci.Status == (int)CheRuKuInfo.savecheck.save ? "编辑" : "查看");
                    }
                    this.CheRuKuDataGridView1.Rows[this.CheRuKuDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DoExport.DoTheExport(this.CheRuKuDataGridView1);
        }

        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            PrintDataGridView.PrintTheDataGridView(this.CheRuKuDataGridView1);
        }
    }
}
