using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using WeiXiu.SQL;
using System.Collections;
using EntityClassLibrary;
using CommonMethod;

namespace WeiXiu
{
    public partial class WeiXiu : CommonControl.CommonTabPage
    {
        OP_WX OP_WX = new OP_WX();
        IList Currentss;

        public WeiXiu()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            WeiXiuDataGridView1.Rows.Clear();
            ShowGridView();

        }
        private void WeiXiu_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }



        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            WeiXiu_FanKuiDan tt = new WeiXiu_FanKuiDan();
            tt.ShowDialog();
            this.WeiXiuDataGridView1.Rows.Clear();
            ShowGridView();
        }

        private void WeiXiuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9&&this.WeiXiuDataGridView1.Rows.Count>0)
            {
                this.WeiXiuDataGridView1.Cursor = Cursors.WaitCursor;

                WeiXiu_FanKuiDan tt = new WeiXiu_FanKuiDan();
                tt.Wx = (WeiXiuFanKuiDan)this.WeiXiuDataGridView1.CurrentRow.Tag;
                tt.ShowDialog();
                if (tt.DialogResult == DialogResult.OK)
                {
                    this.WeiXiuDataGridView1.CurrentRow.Tag = tt.Wx;
                    if (tt.Wx.ServiceState == (int)WeiXiuFanKuiDan.ScratchSave.Save)
                    {
                        this.WeiXiuDataGridView1.Rows[e.RowIndex].Cells[9].Value = "查看";
                    }
                }
                this.WeiXiuDataGridView1.Cursor = Cursors.Default;
            }


        }

        public void ShowGridView()
        {
            Currentss = OP_WX.GetAllWeiXiu();
            int i = 1;
            if (Currentss != null)
            {
                foreach (WeiXiuFanKuiDan s in Currentss)
                {
                    this.WeiXiuDataGridView1.Rows.Add(0, i.ToString(), s.Name, s.Models, s.LicensePlateNumber, s.TelephoneNumber, s.ServicePerson, s.QualityProblems, new DateTime(s.FeedbackTime).ToString("yyyy-MM-dd HH:mm"), s.ServiceState == (int)WeiXiuFanKuiDan.ScratchSave.Save ? "查看" : "编辑");
                    this.WeiXiuDataGridView1.Rows[this.WeiXiuDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Cursor = Cursors.WaitCursor;
            this.WeiXiuDataGridView1.Rows.Clear();
            string name = textBox1.Text;
            string number = textBox2.Text;
            long time1 = dateTimePicker1.Value.Date.Ticks;
            long time2 = dateTimePicker2.Value.Date.AddDays(+1).Ticks;
            Currentss = OP_WX.QueryWeiXiu(name, number, time1, time2);
            int i = 1;
            if (Currentss != null)
            {
                foreach (WeiXiuFanKuiDan s in Currentss)
                {
                    this.WeiXiuDataGridView1.Rows.Add(0, i.ToString(), s.Name, s.Models, s.LicensePlateNumber, s.TelephoneNumber, s.ServicePerson, s.QualityProblems, new DateTime(s.FeedbackTime).ToString("yyyy-MM-dd HH:mm"), s.ServiceState == (int)WeiXiuFanKuiDan.ScratchSave.Save ? "查看" : "编辑");
                    this.WeiXiuDataGridView1.Rows[this.WeiXiuDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
            this.button4.Cursor = Cursors.Hand;

        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {

            this.commonPictureButton2.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(WeiXiuDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);
            d1.Columns.Remove(d1.Columns[0]);

            DoExport.DoTheExport(this.WeiXiuDataGridView1);
            this.commonPictureButton2.Cursor = Cursors.Hand;

        }

        private void commonPictureButton3_Click(object sender, EventArgs e)
        {

            this.commonPictureButton3.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(WeiXiuDataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);
            d1.Columns.Remove(d1.Columns[0]);

            PrintDataGridView.PrintTheDataGridView(d1);
            this.commonPictureButton3.Cursor = Cursors.Hand;

        }

        private void WeiXiuDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.WeiXiuDataGridView1.Cursor = Cursors.WaitCursor;
            WeiXiu_FanKuiDan tt = new WeiXiu_FanKuiDan();
            tt.Wx = (WeiXiuFanKuiDan)this.WeiXiuDataGridView1.CurrentRow.Tag;
            tt.ShowDialog();
            if (tt.DialogResult == DialogResult.OK)
            {
                this.WeiXiuDataGridView1.CurrentRow.Tag = tt.Wx;
                if (tt.Wx.ServiceState == (int)WeiXiuFanKuiDan.ScratchSave.Save)
                {
                    this.WeiXiuDataGridView1.Rows[e.RowIndex].Cells[9].Value = "查看";
                }
            }
            this.WeiXiuDataGridView1.Cursor = Cursors.Default;
        }


    }

}

