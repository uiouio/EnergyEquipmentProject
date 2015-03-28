using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianJian.SQL;
using System.Collections;
using EntityClassLibrary;
using CommonMethod;

namespace JianJian
{


    public partial class JianJian_Inform : CommonControl.CommonTabPage
    {
        public JianJian_Inform()
        {
            InitializeComponent();
        }

        OP_JianJian OP_JianJian = new OP_JianJian();
        IList Currentss;
        long gridview2BatchId;


        private void JianJian_Inform_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        public override void reFreshAllControl()
        {
            JianJian1DataGridView1.Rows.Clear();
            JianJian2DataGridView1.Rows.Clear();
            ShowGridViewJianJian();

        }


        public void ShowGridViewJianJian()
        {
            Currentss = OP_JianJian.GetAllBatch();

            this.JianJian1DataGridView1.Rows.Clear();
            int i = 1;
            if (Currentss != null)
            {
                foreach (Batch s in Currentss)
                {
                    this.JianJian1DataGridView1.Rows.Add(0, i, s.Number, new DateTime(s.Date).ToString("yyyy-MM-dd"), s.Supervisory.Name, "查看");
                    this.JianJian1DataGridView1.Rows[this.JianJian1DataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        public void ShowGridViewJianJian1()
        {
           
            this.JianJian1DataGridView1.Rows.Clear();
            int i = 1;
            if (Currentss != null)
            {
                foreach (Batch s in Currentss)
                {
                    this.JianJian1DataGridView1.Rows.Add(0, i, s.Number, new DateTime(s.Date).ToString("yyyy-MM-dd"), s.Supervisory.Name, "查看");
                    this.JianJian1DataGridView1.Rows[this.JianJian1DataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        public void ShowGridViewJianJianCheLiang()
        {

            int i = 1;
            if (Currentss != null)
            {
                foreach (JianJianInfo c in Currentss)
                {
                    EntityClassLibrary.Car car = (EntityClassLibrary.Car)OP_JianJian.GetFlag(c.CarTheLibrary.RefitWork.CarInfo.Id)[0];
                    this.JianJian2DataGridView1.Rows.Add(0, i.ToString(), c.CarTheLibrary.RefitWork.CarInfo.Cbi.Name, c.CarTheLibrary.RefitWork.CarInfo.ModidiedType, c.CarTheLibrary.RefitWork.CarInfo.PlateNumber,
                        c.CarTheLibrary.RefitWork.CarInfo.Cbi.Telephone, new DateTime(c.Batch.Date).ToString("yyyy-MM-dd"), c.Status == 0 ? "未监检" : "已经监检", "查看",car.Pass == 0? "填写":"查看", "删除");
                    
                }
            }
        }


        private void JianJian1DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (JianJian1DataGridView1.CurrentCell.Value.ToString() == "查看")
            {
                JianJian2DataGridView1.Rows.Clear();

                JianJian2DataGridView1.Visible = true;
                int i = 1;
                gridview2BatchId = (this.JianJian1DataGridView1.CurrentRow.Tag as Batch).Id;
                Currentss = OP_JianJian.GetAllCarInfo(gridview2BatchId);
                if (Currentss != null)
                {
                    foreach (EntityClassLibrary.JianJianInfo c in Currentss)
                    {
                        EntityClassLibrary.Car car = (EntityClassLibrary.Car)OP_JianJian.GetFlag(c.CarTheLibrary.RefitWork.CarInfo.Id)[0];
                        if (c.CarTheLibrary.RefitWork.CarInfo.ModidiedType == 0)
                        {
                            this.JianJian2DataGridView1.Rows.Add(0, i.ToString(), c.CarTheLibrary.RefitWork.CarInfo.Cbi.Name, "CNG汽油", c.CarTheLibrary.RefitWork.CarInfo.PlateNumber,
                                c.CarTheLibrary.RefitWork.CarInfo.Cbi.Telephone, new DateTime(c.Batch.Date).ToString("yyyy-MM-dd"), c.Status == 0 ? "未监检" : "已经监检", "查看", car.Pass == 0 ? "填写" : "查看", "删除");
                        }
                        else if (c.CarTheLibrary.RefitWork.CarInfo.ModidiedType == 1)
                        {
                            this.JianJian2DataGridView1.Rows.Add(0, i.ToString(), c.CarTheLibrary.RefitWork.CarInfo.Cbi.Name, "CNG柴油", c.CarTheLibrary.RefitWork.CarInfo.PlateNumber,
                                c.CarTheLibrary.RefitWork.CarInfo.Cbi.Telephone, new DateTime(c.Batch.Date).ToString("yyyy-MM-dd"), c.Status == 0 ? "未监检" : "已经监检", "查看", car.Pass == 0 ? "填写" : "查看", "删除");
                        }else if(c.CarTheLibrary.RefitWork.CarInfo.ModidiedType==2)
                        {
                            this.JianJian2DataGridView1.Rows.Add(0, i.ToString(), c.CarTheLibrary.RefitWork.CarInfo.Cbi.Name, "LcjzrtNG柴油", c.CarTheLibrary.RefitWork.CarInfo.PlateNumber,
                                c.CarTheLibrary.RefitWork.CarInfo.Cbi.Telephone, new DateTime(c.Batch.Date).ToString("yyyy-MM-dd"), c.Status == 0 ? "未监检" : "已经监检", "查看", car.Pass == 0 ? "填写" : "查看", "删除");
                        }
                    }
                    
                }
                //Currentss = null;
            }
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            JianJian_TongZhiDan tt = new JianJian_TongZhiDan();
            tt.User = this.User;
            tt.ShowDialog();
            if (tt.DialogResult == DialogResult.OK)
            {
                reFreshAllControl();
            }
            
        }

        private void JianJian2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Currentss = OP_JianJian.GetAllCarInfo(gridview2BatchId);
            JianJianInfo t = (JianJianInfo)Currentss[this.JianJian2DataGridView1.CurrentCell.RowIndex];
         
             if (e.ColumnIndex == 8)
            {
                //OP_JianJian OP_JianJian = new SQL.OP_JianJian();
                EntityClassLibrary.Car ca =(EntityClassLibrary.Car)( OP_JianJian.GetFlag(t.CarTheLibrary.RefitWork.CarInfo.Id)[0]);
                string flag = ca.Flag;
                int status = ca.Status;
                long carid = ca.Carid;

                if (t.CarTheLibrary.RefitWork.CarInfo.Cbi.Status == 0)
                {
                    switch (t.CarTheLibrary.RefitWork.CarInfo.ModidiedType)
                    {
                        case (int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGGas:
                            ZiLiao_XiaoJiaoChe tt = new ZiLiao_XiaoJiaoChe();
                            tt.Flag = flag;
                            tt.status = status;
                            tt.carId = carid;
                            tt.ShowDialog();
                            break;
                        case (int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGDiesel:
                            ZiLiao_ChaiYouCNG ss = new ZiLiao_ChaiYouCNG();
                            ss.Flag = flag;
                            ss.status = status;
                            ss.carId = carid;
                            ss.ShowDialog();
                            break;
                        case (int)ModificationContract.CNGGasCNGDieselLNGDiesel.LNGDiesel:
                            ZiLiao_ChaiYouLNG aa = new ZiLiao_ChaiYouLNG();
                            aa.Flag = flag;
                            aa.status = status;
                            aa.carId = carid;
                            aa.ShowDialog();
                            break;
                        default:
                            MessageBox.Show("改装类型为空");
                            break;
                    }
                }
                else if (t.CarTheLibrary.RefitWork.CarInfo.Cbi.Status == 1)
                {
                    switch (t.CarTheLibrary.RefitWork.CarInfo.ModidiedType)
                    {
                        case (int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGGas:
                            CNGGasUnit tt = new CNGGasUnit();
                            tt.Flag = flag;
                            tt.status = status;
                            tt.carId = carid;
                            tt.ShowDialog();
                            break;

                        case (int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGDiesel:
                            CNGDieselUnit ss = new CNGDieselUnit();
                            ss.Flag = flag;
                            ss.status = status;
                            ss.carId = carid;
                            ss.ShowDialog();
                            break;

                        default:
                            MessageBox.Show("改装类型为空");
                            break;

                    }
                }
            }
            if (e.ColumnIndex==9)
            {
                JianJian_JieGuo1 tt = new JianJian_JieGuo1();
                tt.carId = t.CarTheLibrary.RefitWork.CarInfo.Id;
                tt.ShowDialog();
                int r = tt.pass;
                if (r == 1)
                {
                    JianJian2DataGridView1.CurrentCell.Value = "查看";
                }
                else if(r==-1)
                {
                    OP_JianJian.RemoveJianJian(t);//删除操作
                    JianJian2DataGridView1.Rows.Remove(JianJian2DataGridView1.SelectedRows[0]);
                    EntityClassLibrary.CarTheLibrary cl = new CarTheLibrary();
                    cl = t.CarTheLibrary;
                    cl.State = 0;
                    cl.Status = 0;
                    OP_JianJian.SaveOrUpdateEntity(cl);


                    Car cc =(Car) OP_JianJian.GetFlag(cl.RefitWork.CarInfo.Id)[0];
                    cc.Pass = 0;
                    cc.Flag = "0000000000";
                    cc.Status = 0;
                    cc.State = 1;
                    OP_JianJian.SaveOrUpdateEntity(cc);

                   

                }

            }
            if (e.ColumnIndex == 10)
            {

                EntityClassLibrary.Car car = (EntityClassLibrary.Car)OP_JianJian.GetFlag(t.CarTheLibrary.RefitWork.CarInfo.Id)[0];
                int r =car.Pass;
                if (r == 1)
                {
                    MessageBox.Show("已通过监检，无法删除！");
                }
                else
                {
                    OP_JianJian.RemoveJianJian(t);//删除操作
                    JianJian2DataGridView1.Rows.Remove(JianJian2DataGridView1.SelectedRows[0]);
                    EntityClassLibrary.CarTheLibrary cl = new CarTheLibrary();
                    cl = t.CarTheLibrary;
                    cl.State = 0;
                    cl.Status = 0;
                    OP_JianJian.SaveOrUpdateEntity(cl);
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.button1.Cursor = Cursors.WaitCursor;
            this.JianJian1DataGridView1.Rows.Clear();
            string number = this.textBox4.Text;
            Currentss = OP_JianJian.QueryJianJian(number);
            ShowGridViewJianJian1();
            this.button1.Cursor = Cursors.Hand;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Cursor = Cursors.WaitCursor;
            this.JianJian2DataGridView1.Rows.Clear();
            string name = this.textBox1.Text;
            string number = this.textBox2.Text;
            Currentss = OP_JianJian.QueryJianJianCheLiang(name, number,gridview2BatchId);
            ShowGridViewJianJianCheLiang();
            this.button4.Cursor = Cursors.Hand;
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {

            this.commonPictureButton2.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(JianJian1DataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);
            d1.Columns.Remove(d1.Columns[0]);
            DoExport.DoTheExport(d1);
            this.commonPictureButton2.Cursor = Cursors.Hand;
       
        }

        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            this.commonPictureButton3.Cursor = Cursors.WaitCursor;
            DataGridView d1 = new DataGridView();
            d1 = CommonMethod.OperateDateGridView.CloneDataGridView(JianJian1DataGridView1);
            d1.Columns.Remove(d1.Columns[d1.Columns.Count - 1]);
            d1.Columns.Remove(d1.Columns[0]);
            PrintDataGridView.PrintTheDataGridView(d1);
            this.commonPictureButton3.Cursor = Cursors.Hand;
        }
    }
}
