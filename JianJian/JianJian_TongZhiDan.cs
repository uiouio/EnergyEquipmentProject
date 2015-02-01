using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using JianJian.SQL;
using System.Collections;
using SQLProvider.Service;

namespace JianJian
{
    public partial class JianJian_TongZhiDan : Form
    {


        UserInfo user;//= new UserInfo();

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }

        OP_JianJian OP_JianJian = new OP_JianJian();
        IList Currentss;
        
        JianJianInfo JianJianInfo;

        public JianJian_TongZhiDan()
        {
            InitializeComponent();
            User = new UserInfo();
        }

        private void JianJian_TongZhiDan_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = User.Name;
            ShowGridViewJianJian(OP_JianJian.GetAllYIchukued());
            
        }



        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow s = new DataGridViewRow(); ;
            for (int i = 0; i < JianJianTongZhi1DataGridView1.SelectedRows.Count; i++)
            {
                
                s = this.JianJianTongZhi1DataGridView1.SelectedRows[i];
                this.JianJianTongZhi1DataGridView1.Rows.Remove(s);
                this.JianJianTongZhi2DataGridView2.Rows.Add(s);
               
//                this.JianJianTongZhi2DataGridView2.Rows[this.JianJianTongZhi2DataGridView2.RowCount - 1].Tag = s.Tag;
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow s = null;
            for (int i=0; i < JianJianTongZhi2DataGridView2.SelectedRows.Count; i++)
            {
                s=this.JianJianTongZhi2DataGridView2.SelectedRows[i];
                JianJianTongZhi2DataGridView2.Rows.Remove(s);
                JianJianTongZhi1DataGridView1.Rows.Add(s);

            }
                
        }

        public void ShowGridViewJianJian(IList Currentss)
        {
           // Currentss = OP_JianJian.GetAllJianJian();
            JianJianTongZhi1DataGridView1.Rows.Clear();
            int i = 1;
            if (Currentss != null)
            {
                foreach ( CarTheLibrary ss in Currentss)
                {
                    this.JianJianTongZhi1DataGridView1.Rows.Add(
                        false,
                        ss.RefitWork.CarInfo.PlateNumber,
                        ss.RefitWork.CarInfo.VehicleType);
                    this.JianJianTongZhi1DataGridView1.Rows[this.JianJianTongZhi1DataGridView1.Rows.Count - 1].Tag = ss;
                    i++;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {           
        
            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Batch bb = new Batch();
                bb.Date = this.dateTimePicker1.Value.Ticks;
                bb.Number = this.textBox4.Text;
                bb.Supervisory = User;
                bb =  OP_JianJian.SaveOrUpdateEntity(bb) as Batch;
                
                int i;

                for (i = 0; i < this.JianJianTongZhi2DataGridView2.RowCount; i++)
                {
                    JianJianInfo sj = new JianJianInfo();
                    sj.CarTheLibrary = this.JianJianTongZhi2DataGridView2.Rows[i].Tag as CarTheLibrary;

                    CarTheLibrary cc = new CarTheLibrary();
                    cc = this.JianJianTongZhi2DataGridView2.Rows[i].Tag as CarTheLibrary;
                    cc.Status = 1;
                    OP_JianJian.SaveOrUpdateEntity(cc);

                    sj.Batch = bb;
                    sj.Status = (int)JianJianInfo.NoinspectionInspection.Noinspection;

                    OP_JianJian.SaveOrUpdateEntity(sj);

                    Car car = new Car();
                    car.Pass = 0;
                    car.State = 0;
                    car.Status = 0;
                    car.Flag = "0000000000";
                    car.Carid =(int) cc.RefitWork.CarInfo.Id;
                    OP_JianJian.SaveOrUpdateEntity(car);
                }

                this.DialogResult = DialogResult.OK;    
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
