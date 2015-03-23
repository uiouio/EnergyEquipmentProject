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


namespace WeiXiu
{
    public partial class TiaoShiWeiXiuJiLu : CommonControl.CommonTabPage
    {
        OP_WX OP_WX = new OP_WX();
        IList Currentss;
        

        public TiaoShiWeiXiuJiLu()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            commonDataGridView1.Rows.Clear();
            showTable();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            WeiXiuJiLu wxjl = new WeiXiuJiLu();
            wxjl.ShowDialog();
            if (wxjl.IfSaved == 1)
            {
                this.commonDataGridView1.Rows.Clear();
                reFreshAllControl();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            string code = textBox1.Text;
            string number = textBox2.Text;
            long time1 = dateTimePicker1.Value.Date.Ticks;
            long time2 = dateTimePicker2.Value.Date.AddDays(+1).Ticks;
            Currentss = OP_WX.QueryWeiXiuJiLu(code, number, time1, time2);
             int i = 1;
             if (Currentss != null) {
                 foreach (EntityClassLibrary.TiaoShiWeiXiuJiLu s in Currentss) {
                     this.commonDataGridView1.Rows.Add(0, i.ToString(),s.ModificationNumber,s.License,s.GasType,s.Condition,new DateTime(s.DebugTime).ToString("yyyy-MM-dd HH:mm"),"查看");
                     this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = s;
                     i++;
                 }
             }

        }

        public void showTable() {
            this.commonDataGridView1.Rows.Clear();
            Currentss = OP_WX.getAllTiaoShiJiLu();
            int i = 1;
            if (Currentss != null)
            {
                foreach (EntityClassLibrary.TiaoShiWeiXiuJiLu s in Currentss)
                {
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.ModificationNumber, s.License, s.GasType, s.Condition, new DateTime(s.DebugTime).ToString("yyyy-MM-dd HH:mm"), "查看");
                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }

        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (commonDataGridView1.CurrentCell.Value.ToString() == "查看") {
                WeiXiuJiLu tt = new WeiXiuJiLu();
                tt.Tw = (EntityClassLibrary.TiaoShiWeiXiuJiLu)this.commonDataGridView1.CurrentRow.Tag;
                tt.unEnableShow();
                tt.ShowDialog();
            }
        }

        private void TiaoShiWeiXiuJiLu_Load(object sender, EventArgs e)
        {
            
            reFreshAllControl();
        }
    }
}
