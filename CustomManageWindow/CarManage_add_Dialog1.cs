using System;
using System.Windows.Forms;
using EntityClassLibrary;
using CustomManageWindow.Service;
using CommonControl;
using Iesi.Collections.Generic;
using Iesi.Collections;

namespace CustomManageWindow
{
    public partial class CarManage_add_Dialog1 : Form
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

        public CarManage_add_Dialog1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonalCustomInfo_add_Dialog1 pad = new PersonalCustomInfo_add_Dialog1();
            pad.IsShowOrInput = 1;
            pad.ShowDialog();
            if (pad.CustomBaseInfo != null)
            {
                commonDataGridView1.Rows.Add(0, 1, pad.CustomBaseInfo.Name, pad.CustomBaseInfo.IdentifyCardNo, pad.CustomBaseInfo.Telephone,pad.CustomBaseInfo.Address, "查看");
                commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = pad.CustomBaseInfo;
                Currentcustom = pad.CustomBaseInfo;
            }
            
        }    
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            cb.PlateNumber = textBox1.Text;
            cb.EngineIdentificationNumber = textBox9.Text;
            if (textBox3.Text == "")
            {
                cb.Mileage = 0;
            }
            else
            {
                cb.Mileage = float.Parse(textBox3.Text);
            }
            if (textBox4.Text == "")
            {
                cb.FuelConsumption = 0;
            }
            else
            {
                cb.FuelConsumption = float.Parse(textBox4.Text);
            }
            cb.VehicleType = textBox2.Text;
            
            cb.SupplyMode = comboBox2.SelectedText;
            cb.VIN = textBox8.Text;
            cb.FuelType = comboBox1.SelectedText;
            if (textBox10.Text == "")
            {
                cb.KerbMass = 0;
            }
            else
            {
                cb.KerbMass = float.Parse(textBox10.Text);
            }
            cb.Remarks = textBox5.Text;
            cb.Cbi = currentcustom;
            if (currentcustom.CarInfo == null)
            {
                ISet<CarBaseInfo> carList = new HashedSet<CarBaseInfo>();
                carList.Add(cb);
                currentcustom.CarInfo = carList;
            }
            else
            {
                currentcustom.CarInfo.Add(cb);
            }
            ss.SaveOrUpdateEntity(cb);
            IfSaved = 1;
            MessageBox.Show("添加成功");
           
            this.Close();
           

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {

            CustomService ss = new CustomService();
            System.Collections.IList cbList = ss.loadEntityList("from CarBaseInfo where PlateNumber='" + textBox1.Text + "'");


            if (cbList != null && cbList.Count == 1)
            {

                MessageBox.Show("客户已经存在，请添加新客户");
                textBox3.Text = "";
                textBox3.Focus();

            }
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                PersonalCustomInfo_add_Dialog1 newGhs = new PersonalCustomInfo_add_Dialog1();
                newGhs.CustomBaseInfo = (CustomBaseInfo)this.commonDataGridView1.Rows[this.commonDataGridView1.CurrentCell.RowIndex].Tag;
                newGhs.IsShowOrInput = 0;
                newGhs.ShowDialog();

            }
        }

        private void CarManage_add_Dialog1_Load(object sender, EventArgs e)
        {

        }

     
       

    }
}
