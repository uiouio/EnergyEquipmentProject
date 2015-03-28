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

namespace CustomManageWindow
{
    public partial class CarManage_add_Dialog : CommonControl.BaseForm
    {
        private CarBaseInfo carBaseInfo;

        /// <summary>
        /// 是用来展示数据还是输入数据，1用来输入数据，0用来展示数据
        /// </summary>
        private int isShowOrInput;
        public int IsShowOrInput
        {
            get { return isShowOrInput; }
            set { isShowOrInput = value; }
        }

        public CarBaseInfo CarBaseInfo
        {
            get { return carBaseInfo; }
            set { carBaseInfo = value; }
        }


        CustomService ss = new CustomService();

        CarBaseInfo cb = new CarBaseInfo();

        public CarManage_add_Dialog()
        {
            InitializeComponent();
        }
        public CarManage_add_Dialog(string headtextname)
        {
          
            this.Text = headtextname;
            InitializeComponent();
        }

        
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CarManage_add_Dialog_Load(object sender, EventArgs e)
        {
            if (IsShowOrInput == 0)
            {
                this.Text = "车辆详细信息";
                this.groupBox1.Text = "车辆详细信息";
                this.textBox1.Enabled = false;
                this.textBox1.Text = CarBaseInfo.PlateNumber;
                this.textBox4.Enabled = false;
                this.textBox4.Text = CarBaseInfo.EngineIdentificationNumber;
                this.textBox10.Enabled = false;
                this.textBox10.Text = CarBaseInfo.Mileage.ToString();
                this.textBox3.Enabled = false;
                this.textBox3.Text = CarBaseInfo.FuelConsumption.ToString();
               
                this.comboBox3.Enabled = false;
                this.comboBox3.Text = CarBaseInfo.VehicleType;
                this.textBox6.Enabled = false;
                this.textBox6.Text = CarBaseInfo.VehicleBrand;
                this.comboBox2.Enabled = false;
                this.comboBox2.Text = CarBaseInfo.SupplyMode;
                this.textBox9.Enabled = false;
                this.textBox9.Text = CarBaseInfo.VIN;
                this.comboBox1.Enabled = false;
                this.comboBox1.Text=CarBaseInfo.ModifyType[CarBaseInfo.ModidiedType];
                this.textBox8.Enabled = false;
                this.textBox8.Text = CarBaseInfo.KerbMass.ToString();
                this.textBox10.Enabled = false;
                this.textBox10.Text = CarBaseInfo.Mileage.ToString();
                this.textBox5.Enabled = false;
                this.textBox5.Text = CarBaseInfo.Remarks;


            }
            if (IsShowOrInput == 1)
            {
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            }
           
        }    
   

        private void button1_Click(object sender, EventArgs e)
        {
            

            cb.PlateNumber = textBox1.Text;

            cb.EngineIdentificationNumber =  textBox4.Text;
            if (textBox10.Text == "")
            {
                cb.Mileage = 0;
            }
            else
            {
                cb.Mileage = float.Parse(textBox3.Text);
            }
            if (textBox3.Text == "")
            {
                cb.FuelConsumption = 0;
            }
            else
            {
                cb.FuelConsumption = float.Parse(textBox3.Text);
            }
            cb.VehicleBrand = this.textBox6.Text;
            
            cb.VehicleType = this.comboBox3.Text;
           
            cb.SupplyMode = comboBox2.Text;

            cb.VIN = textBox9.Text;
            if (this.comboBox1.Text == "CNG汽油")
            {
                cb.ModidiedType=(int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGGas;
            }
            else if (this.comboBox1.Text == "CNG柴油")
            { 
                cb.ModidiedType=(int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGDiesel;
            }
            else if (this.comboBox1.Text == "LNG柴油")
            {
                cb.ModidiedType=(int)ModificationContract.CNGGasCNGDieselLNGDiesel.LNGDiesel;
            }
            if (textBox10.Text == "")
            {
                cb.KerbMass = 0;
            }
            else
            {
                cb.KerbMass = float.Parse(textBox10.Text);
            }
           

            cb.Remarks = textBox5.Text;
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("请输入车牌号");
            }
            else
            {
                ss.SaveOrUpdateEntity(cb);
                carBaseInfo = cb;
                if (this.isShowOrInput == 0)
                {
                    this.Close();
                }
                else if (this.isShowOrInput == 1 || this.isShowOrInput == 2)
                {
                    MessageBox.Show("添加成功");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            CustomService ss = new CustomService();
            IList cbList = ss.loadEntityList("from CarBaseInfo where PlateNumber='" + textBox1.Text + "'");


            if (cbList != null && cbList.Count == 1)
            {

                MessageBox.Show("客户已经存在，请添加新客户");
                textBox1.Text = "";
                textBox1.Focus();

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
