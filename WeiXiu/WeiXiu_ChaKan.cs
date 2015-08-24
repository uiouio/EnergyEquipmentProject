using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using WeiXiu.SQL;
using System.Collections;
using CommonMethod;

namespace WeiXiu
{
    public partial class WeiXiu_ChaKan : CommonControl.CommonTabPage
    {
        private WeiXiuFanKuiDan wx = new WeiXiuFanKuiDan();
        public WeiXiuFanKuiDan Wx
        {
            get { return wx; }
            set { wx = value; }
        }
        OP_WX OP_WX = new OP_WX();
        IList Currentss;

        public WeiXiu_ChaKan()
        {
            InitializeComponent();
        }

        private void WeiXiu_ChaKan_Load(object sender, EventArgs e)
        {
            //假数据
            //WeiXiuDataGridView1.Rows.Add(0, "1", "张伟", "小轿车", "冀A8383", "13681512354", "正在维修", "2014.6.22",  "查看");
            //WeiXiuDataGridView1.Rows.Add(0, "2", "王凯", "小轿车", "冀A8223", "15632489553", "维修完成", "2014.6.22",  "查看");
            //WeiXiuDataGridView1.Rows.Add(0, "3", "李毅", "重卡", "冀A8213", "13652148555", "正在维修", "2014.6.22",  "查看");
            //WeiXiuDataGridView1.Rows.Add(0, "4", "刘珊珊", "小轿车", "冀A0223", "15246324967", "正在维修", "2014.6.22", "查看");

            ShowGridViewWeiXiu();
           

        }

        public void ShowGridViewWeiXiu()
        {
            Currentss = OP_WX.GetAllWeiXiu();
            int i = 1;
            if (Currentss != null)
            {
                foreach (WeiXiuFanKuiDan s in Currentss)
                {
                    this.WeiXiuDataGridView1.Rows.Add(0, i.ToString(), s.Name, s.Models, s.LicensePlateNumber, s.TelephoneNumber, s.ServicePerson, s.QualityProblems, new DateTime(s.FeedbackTime).ToString("yyyy-MM-dd HH:mm"), "查看");
                    this.WeiXiuDataGridView1.Rows[this.WeiXiuDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }

        }

        private void WeiXiuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.WeiXiuDataGridView1.Rows.Count > 0)
            {
                if (WeiXiuDataGridView1.CurrentCell.Value.ToString() == "查看")
                {
                    this.WeiXiuDataGridView1.Cursor = Cursors.WaitCursor;
                    WeiXiu_FanKuiDan tt = new WeiXiu_FanKuiDan();
                    tt.Wx = (WeiXiuFanKuiDan)this.WeiXiuDataGridView1.CurrentRow.Tag;
                    tt.SetAllTextEnableUnActive();
                    tt.ShowDialog();
                    this.WeiXiuDataGridView1.Cursor = Cursors.Default;
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
                    this.WeiXiuDataGridView1.Rows.Add(0, i.ToString(), s.Name, s.Models, s.LicensePlateNumber, s.TelephoneNumber, s.ServicePerson, s.QualityProblems, new DateTime(s.FeedbackTime).ToString("yyyy-MM-dd HH:mm"), "查看");
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
            tt.SetAllTextEnableUnActive();
            tt.ShowDialog();
            this.WeiXiuDataGridView1.Cursor = Cursors.Default;
        }
    }
}
