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


namespace CustomManageWindow
{
    public partial class CarSelect : Form
    {
        CustomService ss = new CustomService();
        private IList currentcars;

        public IList Currentcars
        {
            get { return currentcars; }
            set { currentcars = value; }
        }
        private CarBaseInfo carBaseInfo;

        public CarBaseInfo CarBaseInfo
        {
            get { return carBaseInfo; }
            set { carBaseInfo = value; }
        }
        public CarSelect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox3.Text;
            string cname = this.textBox1.Text;
            
        }

        private void CarSelect_Load(object sender, EventArgs e)
        {
             
            ShowAllCarGrid();
          
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
             this.DialogResult = DialogResult.OK;
             this.Close();
         
        }

        private void carselectDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                YanChe_add_Dialog yd = new YanChe_add_Dialog();
                yd.ShowDialog();
            }
        }
        public void ShowAllCarGrid()
        {
            currentcars = ss.GetAllCar();
            int i = 1;
            if (currentcars != null)
            {
                foreach (CarBaseInfo s in currentcars)
                {
                    this.carselectDataGridView1.Rows.Add(0, i.ToString(), s.Cbi == null ? "" : s.Cbi.Name, s.PlateNumber, s.VehicleType, s.VIN, s.EngineIdentificationNumber, s.SupperPlace, s.SupperTime, "查看");
                    i++;
                }
            }
        }
        public void ShowSelectCarGrid()
        {
           
            int i = 1;
            if (currentcars != null)
            {
                foreach (CarBaseInfo s in currentcars)
                {
                    this.carselectDataGridView1.Rows.Add(0, i.ToString(), s.Cbi == null ? "" : s.Cbi.Name, s.PlateNumber, s.VehicleType,  s.VIN, s.EngineIdentificationNumber, s.SupperPlace, s.SupperTime,"查看");
                    i++;
                }
            }
        }
        
    }
}
