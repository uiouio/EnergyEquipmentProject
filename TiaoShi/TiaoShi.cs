using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using TiaoShi.SQL;
using CommonMethod;

namespace TiaoShi
{
    public partial class TiaoShi : CommonControl.CommonTabPage
    {
        OP_TS OP_TS = new OP_TS();
        IList Currentss;

        public TiaoShi()
        {
            InitializeComponent();
        }

       
        private void TiaoShi_Load(object sender, EventArgs e)
        {
            
            reFreshAllControl();

        }

        public override void reFreshAllControl()
        {
            TiaoShiDataGridView1.Rows.Clear();
            ShowTiaoShiBaoGao();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                TiaoShi_BaoGao tt = new TiaoShi_BaoGao();
                tt.TiaoShiBaoGao = (TiaoShiBaoGao)this.TiaoShiDataGridView1.CurrentRow.Tag;
                tt.ShowDialog();
                if (tt.DialogResult == DialogResult.OK)
                {
                    //ShowTiaoShiBaoGao();
                    this.TiaoShiDataGridView1.CurrentCell.Tag = tt.TiaoShiBaoGao;
                    if (tt.TiaoShiBaoGao.Status == (int)TiaoShiBaoGao.savecheck.check)
                    {
                        this.TiaoShiDataGridView1.Rows[e.RowIndex].Cells[7].Value = DateTime.Now.ToString("yyyy-MM-dd");
                        this.TiaoShiDataGridView1.Rows[e.RowIndex].Cells[8].Value = "已调试";
                        this.TiaoShiDataGridView1.Rows[e.RowIndex].Cells[9].Value = "查看";
                    }
                }
            }

        }


        public void ShowTiaoShiBaoGao()
        {
            Currentss = OP_TS.GetTiaoShiBaoGao();
            int i = 1;
            if (Currentss != null)
            {
                foreach (TiaoShiBaoGao s in Currentss)
                {
                    TiaoShiDataGridView1.Rows.Add(0,i.ToString(),s.LiuZhuanBiao.PaiGongDan.CarInfo.EngineIdentificationNumber,s.LiuZhuanBiao.PaiGongDan.DispatchOrder,
                                                     s.LiuZhuanBiao.PaiGongDan.CarInfo.VehicleType, s.LiuZhuanBiao.PaiGongDan.CarInfo.PlateNumber, new DateTime(s.LiuZhuanBiao.Time).ToString("yyyy-MM-dd"),
                                                     new DateTime(s.Time).ToString("yyyy-MM-dd"), s.Status == (int)TiaoShiBaoGao.savecheck.save ? "未调试" : "已调试", s.Status == (int)TiaoShiBaoGao.savecheck.save ? "编辑" : "查看");
                    this.TiaoShiDataGridView1.Rows[this.TiaoShiDataGridView1.Rows.Count-1].Tag=s;
                    i++;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.TiaoShiDataGridView1.Rows.Clear();
            string number = this.textBox1.Text;
            string platenumber = this.textBox2.Text;
            long time1 = this.dateTimePicker1.Value.Date.Ticks;
            long time2 = this.dateTimePicker2.Value.Date.AddDays(+1).Ticks;
            Currentss = OP_TS.QueryTiaoShiBaoGao(number,platenumber,time1,time2);
            int i = 1;
            if (Currentss != null)
            {
                foreach (TiaoShiBaoGao s in Currentss)
                {
                    TiaoShiDataGridView1.Rows.Add(0, i.ToString(), s.LiuZhuanBiao.PaiGongDan.CarInfo.EngineIdentificationNumber, s.LiuZhuanBiao.PaiGongDan.DispatchOrder,
                                                    s.LiuZhuanBiao.PaiGongDan.CarInfo.VehicleType, s.LiuZhuanBiao.PaiGongDan.CarInfo.PlateNumber, new DateTime(s.LiuZhuanBiao.Time).ToString("yyyy-MM-dd"),
                                                    new DateTime(s.Time).ToString("yyyy-MM-dd"), s.Status == (int)TiaoShiBaoGao.savecheck.save ? "未调试" : "已调试", s.Status == (int)TiaoShiBaoGao.savecheck.save ? "编辑" : "查看");
                    i++;
                }
            }

        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            this.commonPictureButton2.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(TiaoShiDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);

            DoExport.DoTheExport(d1);

            this.commonPictureButton2.Cursor = Cursors.Hand;

        }

        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            this.commonPictureButton3.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(TiaoShiDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);

            PrintDataGridView.PrintTheDataGridView(d1);
            this.commonPictureButton3.Cursor = Cursors.Hand;
        }

        private void TiaoShiDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.TiaoShiDataGridView1.Cursor = Cursors.WaitCursor;
            if (e.RowIndex > 0)
            {
                TiaoShi_BaoGao tt = new TiaoShi_BaoGao();
                tt.TiaoShiBaoGao = (TiaoShiBaoGao)this.TiaoShiDataGridView1.CurrentRow.Tag;
                tt.ShowDialog();
                if (tt.DialogResult == DialogResult.OK)
                {
                    //ShowTiaoShiBaoGao();
                    this.TiaoShiDataGridView1.CurrentCell.Tag = tt.TiaoShiBaoGao;
                    if (tt.TiaoShiBaoGao.Status == (int)TiaoShiBaoGao.savecheck.check)
                    {
                        this.TiaoShiDataGridView1.Rows[e.RowIndex].Cells[7].Value = DateTime.Now.ToString("yyyy-MM-dd");
                        this.TiaoShiDataGridView1.Rows[e.RowIndex].Cells[8].Value = "已调试";
                        this.TiaoShiDataGridView1.Rows[e.RowIndex].Cells[9].Value = "查看";
                    }
                }
            }
            this.TiaoShiDataGridView1.Cursor = Cursors.Default;
            
        }

       
    }
}
