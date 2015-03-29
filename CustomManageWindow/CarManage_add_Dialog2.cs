using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CustomManageWindow.Service;
using CommonControl;

namespace CustomManageWindow
{
    public partial class CarManage_add_Dialog2 : CommonControl.BaseForm
    {
        public int IfSaved = 0;
        CustomService ss = new CustomService();
        CarBaseInfo cb = new CarBaseInfo();
        private CustomBaseInfo currentcustom;

        public CustomBaseInfo Currentcustom
        {
            get { return currentcustom; }
            set { currentcustom = value; }
        }
        private CarBaseInfo currentcar;

        public CarBaseInfo Currentcar
        {
            get { return currentcar; }
            set { currentcar = value; }
        }
        
        public CarManage_add_Dialog2()
        {
            InitializeComponent();
        }

        private void CarManage_add_Dialog2_Load(object sender, EventArgs e)
        {
          
            this.textBox1.Enabled = false;

            this.textBox1.Text = Currentcar.PlateNumber;

            this.textBox9.Enabled = false;
            this.textBox9.Text = Currentcar.EngineIdentificationNumber;

            this.textBox3.Text = Currentcar.Mileage.ToString();
            this.textBox12.Enabled = false;

            this.textBox12.Text = Currentcar.VehicleBrand;
            this.textBox4.Text = Currentcar.FuelConsumption.ToString();

            this.textBox2.Text = Currentcar.VehicleType;

            this.comboBox2.Text = Currentcar.SupplyMode;

            this.textBox8.Text = Currentcar.VIN;
            this.comboBox1.Enabled = false;
            this.comboBox1.Text=(ModificationContract.ModifyType[Currentcar.ModidiedType]).ToString();
            this.textBox10.Text = Currentcar.KerbMass.ToString();
            this.textBox5.Text = Currentcar.Remarks;
            
            currentcustom = Currentcar.Cbi;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox6.Text = currentcustom.Name;
            this.textBox7.Text = currentcustom.IdentifyCardNo;
            this.textBox11.Text = currentcustom.Telephone;

            //ShowCustomCarGrid();
        }
        //public void ShowCustomCarGrid()
        //{
            
        //    if (currentcustom!= null)
        //    {
               
        //          this.commonDataGridView1.Rows.Add(0, 1, currentcustom.Name,currentcustom.IdentifyCardNo,currentcustom.Telephone,currentcustom.Address,"查看","删除");
        //          commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = currentcustom;
        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            Currentcar.Mileage=float.Parse(textBox3.Text);
            Currentcar.FuelConsumption=float.Parse(textBox4.Text);
            Currentcar.VehicleType=textBox2.Text;
            Currentcar.SupplyMode=comboBox2.Text;
            Currentcar.VIN=textBox8.Text;
            Currentcar.FuelType=comboBox1.Text;
            Currentcar.KerbMass = float.Parse(textBox10.Text);
            Currentcar.Remarks = textBox5.Text;
            Currentcar.Cbi.Telephone = textBox11.Text;
            ss.Save(Currentcar);
            MessageBox.Show("保存成功！");
            this.DialogResult = DialogResult.OK;
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    PersonalCustomInfo_add_Dialog1 clxx = new PersonalCustomInfo_add_Dialog1();
            
        //    if (clxx.ShowDialog() == DialogResult.OK)
        //    {
        //        commonDataGridView1.Rows.Add(0, 1, cb.Cbi.Name, cb.Cbi.IdentifyCardNo, cb.Cbi.Telephone,cb.Cbi.Address, "查看");
        //        commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = cb.Cbi;
               
        //        // car.Add(pad.CustomBaseInfo);

        //    }

        //}

        //private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    CommonDataGridView grid = (CommonDataGridView)sender;
        //    if (grid.CurrentCell.Value.ToString() == "查看")
        //    {
        //        PersonalCustomInfo_add_Dialog1 newGhs = new PersonalCustomInfo_add_Dialog1("客户详细信息");

        //        newGhs.CustomBaseInfo = (CustomBaseInfo)this.commonDataGridView1.Rows[this.commonDataGridView1.CurrentRow.Index].Tag;
        //        newGhs.IsShowOrInput = 0;

        //        newGhs.ShowDialog();
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
