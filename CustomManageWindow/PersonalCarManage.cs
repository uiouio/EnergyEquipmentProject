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
    public partial class PersonalCarManage : CommonControl.CommonTabPage
    {
        CustomService ss = new CustomService();
        IList currentcustoms;
        public PersonalCarManage()
        {
            InitializeComponent();
        }
        private void PersonalCarManage_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                CarManage_add_Dialog2 newGhs = new CarManage_add_Dialog2();
                newGhs.Currentcar = (CarBaseInfo)currentcustoms[this.commonDataGridView1.CurrentCell.RowIndex];
                if (newGhs.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }

            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                CarBaseInfo s = (CarBaseInfo)currentcustoms[this.commonDataGridView1.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ss.RemoveCar(s);
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }

            }
            else if (grid.CurrentCell.Value.ToString() == "编辑")
            {
                YanChe_add_Dialog ydd = new YanChe_add_Dialog();
                ydd.CarBaseInfo = (CarBaseInfo)currentcustoms[this.commonDataGridView1.CurrentCell.RowIndex];
                ydd.IsShowOrInput = 1;
                if (ydd.ShowDialog() == DialogResult.OK)
                {
                    //grid.Rows[e.RowIndex].Cells[11].Value = "";
                    this.commonDataGridView1.Rows.Clear();
                  
                    reFreshAllControl();
                }
            }
         
        }
        public override void reFreshAllControl()
        {
            this.textBox7.Text = "";
            this.textBox20.Text = "";
            this.textBox21.Text = "";
            this.textBox22.Text = "";
            this.commonDataGridView1.Rows.Clear();
            currentcustoms = ss.GetPersonalCar();
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CarBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.PlateNumber, s.Cbi == null ? "" : s.Cbi.Name, s.VehicleType,s.VIN,  s.EngineIdentificationNumber,s.Mileage,s.FuelConsumption, new DateTime(s.Cbi.RegistrationTime).ToString(), s.CylinderNo, s.CylinderType, s.CylinderVolume, "编辑", "查看");
                    i++;
                }
            }

        }

        public void ShowSelectedPersonalCarGrid()
        {
            
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CarBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.PlateNumber, s.Cbi == null ? "" : s.Cbi.Name, s.VehicleType, s.VIN, s.EngineIdentificationNumber, s.Mileage, s.FuelConsumption, new DateTime(s.Cbi.RegistrationTime).ToString(), s.CylinderNo, s.CylinderType, s.CylinderVolume, "编辑", "查看");
                    i++;
                }
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {
           
            string name = textBox7.Text;
            string cname = textBox20.Text;
            string dname = textBox21.Text;
            string ename = textBox22.Text;
            this.commonDataGridView1.Rows.Clear();
            currentcustoms = ss.SelectPersonalCar(name,cname,dname,ename);
            ShowSelectedPersonalCarGrid();
        }
        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView1); 
            div.Columns.Remove(div.Columns[13]);
            div.Columns.Remove(div.Columns[13]);
            PrintDataGridView.PrintTheDataGridView(div);

        }
        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView1); 
            div.Columns.Remove(div.Columns[13]);
            div.Columns.Remove(div.Columns[13]);
            DoExport.DoTheExport(div);
        }

       
        
    }
}
