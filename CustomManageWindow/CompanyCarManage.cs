using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow.Service;
using CommonControl;
using CommonMethod;
namespace CustomManageWindow
{
    public partial class CompanyCarManage : CommonControl.CommonTabPage
    {
        CustomService ss = new CustomService();
        IList currentcustoms;
        public CompanyCarManage()
        {
            InitializeComponent();
        }

        private void commonPictureButton4_Click(object sender, EventArgs e)
        {
            CompanyCarManage_add_Dialog XinJian = new CompanyCarManage_add_Dialog();
            XinJian.ShowDialog();
            if (XinJian.IfSaved == 1)
            {
                this.commonDataGridView2.Rows.Clear();
                reFreshAllControl();
            }
        }

        private void CompanyCarManage_Load(object sender, EventArgs e)
        {
            this.commonDataGridView2.Rows.Clear();
            reFreshAllControl();

        }

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                CompanyCarView newGhs = new CompanyCarView();
                newGhs.Currentcar = (CarBaseInfo)currentcustoms[this.commonDataGridView2.CurrentCell.RowIndex];

                if (newGhs.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView2.Rows.Clear();
                    reFreshAllControl();
                }

            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                CarBaseInfo s = (CarBaseInfo)currentcustoms[this.commonDataGridView2.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ss.RemoveCar(s);
                    this.commonDataGridView2.Rows.Clear();
                    reFreshAllControl();
                }


            }
            else if (grid.CurrentCell.Value.ToString() == "编辑")
            {
                YanChe_add_Dialog yy = new YanChe_add_Dialog();
                yy.CarBaseInfo = (CarBaseInfo)currentcustoms[this.commonDataGridView2.CurrentCell.RowIndex];
                yy.IsShowOrInput = 1;
                if (yy.ShowDialog() == DialogResult.OK)
                {
                    //grid.Rows[e.RowIndex].Cells[11].Value = "";
                    this.commonDataGridView2.Rows.Clear();

                    reFreshAllControl();
                }
            }

        }
        public override void reFreshAllControl()
        {
            this.textBox18.Text = "";
            this.textBox23.Text = "";
            this.textBox27.Text = "";
            this.textBox28.Text = "";
            this.commonDataGridView2.Rows.Clear();
            currentcustoms = ss.GetCompanyCar();
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CarBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView2.Rows.Add(i.ToString(), s.Cbi == null ? "" : s.Cbi.Name, s.Cbi == null ? "" : s.Cbi.IdentifyCardNo, s.Cbi == null ? "" : s.Cbi.Phone, s.PlateNumber, s.VehicleType, s.Mileage, s.FuelConsumption, s.VIN, s.CylinderNo, s.CylinderVolume, "编辑", "查看", "删除");
                    i++;
                }
            }
        }


        public void ShowSelectCompanyCarGrid()
        {
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CarBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView2.Rows.Add(i.ToString(), s.Cbi == null ? "" : s.Cbi.Name, s.Cbi == null ? "" : s.Cbi.IdentifyCardNo, s.Cbi == null ? "" : s.Cbi.Phone, s.PlateNumber, s.VehicleType, s.Mileage, s.FuelConsumption, s.VIN, s.CylinderNo, s.CylinderVolume, "编辑", "查看", "删除");
                    i++;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string name = textBox23.Text;

            string cname = textBox18.Text;

            string dname = textBox27.Text;

            string ename = textBox28.Text;

            this.commonDataGridView2.Rows.Clear();
            currentcustoms = ss.SelectCompanyCar(name, cname, dname, ename);

            ShowSelectCompanyCarGrid();


        }

        private void commonPictureButton5_Click(object sender, EventArgs e)
        {
            this.commonDataGridView2.Columns.Remove(Column1);
            this.commonDataGridView2.Columns.Remove(Column3);
            PrintDataGridView.PrintTheDataGridView(this.commonDataGridView2);
            this.commonDataGridView2.Columns.Add(Column1);
            this.commonDataGridView2.Columns.Add(Column3);
        }

        private void commonPictureButton6_Click(object sender, EventArgs e)
        {
            this.commonDataGridView2.Columns.Remove(Column1);
            this.commonDataGridView2.Columns.Remove(Column3);
            DoExport.DoTheExport(this.commonDataGridView2);
            this.commonDataGridView2.Columns.Remove(Column1);
            this.commonDataGridView2.Columns.Remove(Column3);
        }

    }
}

