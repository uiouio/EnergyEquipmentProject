using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using JianJian.SQL;
using EntityClassLibrary;

namespace JianJian
{
    public partial class JianJian_JieGuocs : CommonControl.CommonTabPage
    {
        IList Currentss;
        OP_JianJian OP_JianJian = new OP_JianJian();
        JianJianInfo JianJianInfo;


        public JianJian_JieGuocs()
        {
            InitializeComponent();
        }

        private void JianJian_JieGuocs_Load(object sender, EventArgs e)
        {
            //commonDataGridView1.Rows.Add(0, "1", "0001", "2014.6.30", "张凯丽", "查看" );
        }

        

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (commonDataGridView2.CurrentCell.Value.ToString() == "编辑")
            {
                JianJian_JieGuo1 tt = new JianJian_JieGuo1();
                tt.JianJian_JieGuo11 =(JianJian_JieGuo1)this.commonDataGridView2.CurrentRow.Tag;
                if (tt.DialogResult == DialogResult.OK)
                {
                    this.commonDataGridView2.CurrentRow.Tag = tt.JianJian_JieGuo11;
                    //if(tt.JianJian_JieGuo11)
                }
                tt.ShowDialog();
            }
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            commonDataGridView2.Rows.Clear();
            if (commonDataGridView1.CurrentCell.Value.ToString() == "查看")
            {
                commonDataGridView2.Visible = true;
                commonDataGridView2.Rows.Add(0, "1", "00001", "张三", "小轿车", "135644895641", "2014.7.14", "编辑");
            }
        }

        public void ShowGridViewJianJian()
        {
            Currentss = OP_JianJian.GetAllYIchukued();
            int i = 1;
            if (Currentss != null)
            {
                foreach (JianJianInfo s in Currentss)
                {
                    //this.commonDataGridView1.Rows.Add(0, i.ToString(), s.LotNumbert, s.Date, s.Supervisory, "查看", "删除");
                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        public void ShowGridViewJianJianCheLiang()
        {
            Currentss = OP_JianJian.GetAllYIchukued();
            int i = 1;
            if (Currentss != null)
            {
                foreach (JianJianInfo s in Currentss)
                {
                    //this.commonDataGridView2.Rows.Add(0, i.ToString(), s.RefitWork.CarInfo.Cbi.Name, s.RefitWork.CarInfo.VehicleType, s.RefitWork.CarInfo.PlateNumber,
                       // s.RefitWork.CarInfo.Cbi.Phone, s.Date, s.Supervisory, "查看");
                    this.commonDataGridView2.Rows[this.commonDataGridView2.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            string number = this.textBox4.Text;
            Currentss = OP_JianJian.QueryJianJian(number);
            ShowGridViewJianJian();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.commonDataGridView2.Rows.Clear();
            string name = this.textBox1.Text;
            string number = this.textBox2.Text;
            Currentss = OP_JianJian.QueryJianJianCheLiang1(name, number);
            ShowGridViewJianJianCheLiang();
        }

       
    }
}
