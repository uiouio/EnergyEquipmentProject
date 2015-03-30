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
    public partial class WeiXiuJiLu : Form
    {
        public WeiXiuJiLu()
        {
            InitializeComponent();
        }

        EntityClassLibrary.TiaoShiWeiXiuJiLu tw;

        public EntityClassLibrary.TiaoShiWeiXiuJiLu Tw
        {
            get { return tw; }
            set { tw = value; }
        }

        public int IfSaved = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            CommonMethod.DocumentPrint print = new CommonMethod.DocumentPrint();
            print.DocPrint(panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void unEnableShow()
        {

            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox7.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox10.Enabled = false;
            textBox9.Enabled = false;
            textBox13.Enabled = false;
            textBox8.Enabled = false;
            textBox12.Enabled = false;
            textBox11.Enabled = false;
            textBox16.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            textBox20.Enabled = false;
            textBox19.Enabled = false;
            textBox18.Enabled = false;
            textBox17.Enabled = false;
            textBox24.Enabled = false;
            textBox23.Enabled = false;
            textBox22.Enabled = false;
            textBox21.Enabled = false;
            textBox28.Enabled = false;
            textBox27.Enabled = false;
            textBox26.Enabled = false;
            textBox25.Enabled = false;
            textBox40.Enabled = false;
            textBox39.Enabled = false;
            textBox38.Enabled = false;
            textBox37.Enabled = false;
            textBox36.Enabled = false;
            textBox35.Enabled = false;
            textBox34.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox31.Enabled = false;
            textBox30.Enabled = false;
            textBox29.Enabled = false;
            textBox73.Enabled = false;
            textBox73.Enabled = false;
            textBox75.Enabled = false;
            textBox76.Enabled = false;
            textBox77.Enabled = false;
            textBox78.Enabled = false;
            textBox74.Enabled = false;
            textBox79.Enabled = false;
            textBox80.Enabled = false;
            textBox81.Enabled = false;
            textBox82.Enabled = false;
            textBox83.Enabled = false;
            textBox84.Enabled = false;
            textBox67.Enabled = false;
            textBox72.Enabled = false;
            textBox71.Enabled = false;
            textBox70.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            textBox66.Enabled = false;
            textBox65.Enabled = false;
            textBox69.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tw = new EntityClassLibrary.TiaoShiWeiXiuJiLu();
            OP_WX oo = new OP_WX();

            tw.ModificationNumber = textBox1.Text;
            tw.License = textBox2.Text;
            tw.GasType = textBox3.Text;
            tw.Condition = textBox4.Text;
            tw.GearSpeed = textBox7.Text;
            tw.SpeedFactor = textBox6.Text;
            tw.StartGear = textBox5.Text;
            tw.StartSpeed = textBox10.Text;
            tw.BestGasRpm = textBox9.Text;
            tw.BestGasSpeed = textBox13.Text;
            tw.BestGasOil = textBox8.Text;
            tw.BestGasProportion = textBox12.Text;
            tw.SupplyPressure = textBox11.Text;
            tw.MinimumFuelConsumption = textBox16.Text;
            tw.ManyTemperatureProtect = textBox14.Text;
            tw.LessTemperatureProtect = textBox15.Text;

            tw.Rpm = textBox20.Text;
            tw.Speed = textBox19.Text;
            tw.OilSupply = textBox18.Text;
            tw.Oilback = textBox17.Text;
            tw.OilCosumption = textBox24.Text;
            tw.GasValue = textBox23.Text;
            tw.OilCosumptionHigh = textBox22.Text;
            tw.OilCosumptionShort = textBox21.Text;
            tw.GasCosumptionHigh = textBox28.Text;
            tw.GasCosumptionShort = textBox27.Text;
            tw.Edu = textBox26.Text;
            tw.ExhaustGasTemperature = textBox25.Text;

            tw.Rpm2 = textBox40.Text;
            tw.Speed2 = textBox39.Text;
            tw.OilSupply2 = textBox38.Text;
            tw.Oilback2 = textBox37.Text;
            tw.OilCosumption2 = textBox36.Text;
            tw.GasValue2 = textBox35.Text;
            tw.OilCosumptionHigh2 = textBox34.Text;
            tw.OilCosumptionShort2 = textBox33.Text;
            tw.GasCosumptionHigh2 = textBox32.Text;
            tw.GasCosumptionShort2 = textBox31.Text;
            tw.Edu2 = textBox30.Text;
            tw.ExhaustGasTemperature2 = textBox29.Text;

            if (textBox73.Text == "")
            {
                tw.DieselMiles = 0;
            }
            else
            {
                tw.DieselMiles = float.Parse(textBox73.Text);
            }

            if (textBox75.Text == "")
            {
                tw.OilCosts = 0;
            }
            else
            {
                tw.OilCosts = float.Parse(textBox75.Text);
            }

            if (textBox76.Text == "")
            {
                tw.TotalCosts = 0;
            }
            else
            {
                tw.TotalCosts = float.Parse(textBox76.Text);
            }

            if (textBox77.Text == "")
            {
                tw.AverageCosts = 0;
            }
            else
            {
                tw.AverageCosts = float.Parse(textBox77.Text);
            }

            if (textBox78.Text == "")
            {
                tw.OilPrice = 0;
            }
            else
            {
                tw.OilPrice = float.Parse(textBox78.Text);
            }

            if (textBox74.Text == "")
            {
                tw.OilAndGasMiles = 0;
            }
            else
            {
                tw.OilAndGasMiles = float.Parse(textBox74.Text);
            }

            if (textBox79.Text == "")
            {
                tw.OilAndGasCosts = 0;
            }
            else
            {
                tw.OilAndGasCosts = float.Parse(textBox79.Text);
            }

            if (textBox80.Text == "")
            {
                tw.OilAndGasOilPrice = 0;
            }
            else
            {
                tw.OilAndGasOilPrice = float.Parse(textBox80.Text);
            }

            if (textBox81.Text == "")
            {
                tw.OilAndGasTotalCosts = 0;
            }
            else
            {
                tw.OilAndGasTotalCosts = float.Parse(textBox81.Text);
            }

            if (textBox82.Text == "")
            {
                tw.OilAndGasAverageCosts = 0;
            }
            else
            {
                tw.OilAndGasAverageCosts = float.Parse(textBox82.Text);
            }

            if (textBox83.Text == "")
            {
                tw.OilAndGasOilPrice = 0;
            }
            else
            {
                tw.OilAndGasOilPrice = float.Parse(textBox83.Text);
            }

            if (textBox84.Text == "")
            {
                tw.OilAndGasGasPrice = 0;
            }
            else
            {
                tw.OilAndGasGasPrice = float.Parse(textBox84.Text);
            }

            tw.Phone = textBox67.Text;
            tw.DebugTimes = textBox72.Text;
            tw.DebugGroup = textBox71.Text;
            tw.DebugStaff = textBox70.Text;
            tw.DebugTime = dateTimePicker1.Value.Ticks;
            tw.Dynamic = textBox66.Text;
            tw.Economy = textBox65.Text;
            tw.Name = textBox69.Text;


            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                oo.saveWeiXiuJiLu(tw);
                IfSaved = 1;
                this.DialogResult = DialogResult.OK;

            }

        }

        private void WeiXiuJiLu_Load(object sender, EventArgs e)
        {
            if (tw != null)
            {
                textBox1.Text = tw.ModificationNumber;
                textBox2.Text = tw.License;
                textBox3.Text = tw.GasType;
                textBox4.Text = tw.Condition;
                textBox7.Text = tw.GearSpeed;
                textBox6.Text = tw.SpeedFactor;
                textBox5.Text = tw.StartGear;
                textBox10.Text = tw.StartSpeed;
                textBox9.Text = tw.BestGasRpm;
                textBox13.Text = tw.BestGasSpeed;
                textBox8.Text = tw.BestGasOil;
                textBox12.Text = tw.BestGasProportion;
                textBox11.Text = tw.SupplyPressure;
                textBox16.Text = tw.MinimumFuelConsumption;
                textBox14.Text = tw.ManyTemperatureProtect;
                textBox15.Text = tw.LessTemperatureProtect;

                textBox20.Text = tw.Rpm;
                textBox19.Text = tw.Speed;
                textBox18.Text = tw.OilSupply;
                textBox17.Text = tw.Oilback;
                textBox24.Text = tw.OilCosumption;
                textBox23.Text = tw.GasValue;
                textBox22.Text = tw.OilCosumptionHigh;
                textBox21.Text = tw.OilCosumptionShort;
                textBox28.Text = tw.GasCosumptionHigh;
                textBox27.Text = tw.GasCosumptionShort;
                textBox26.Text = tw.Edu;
                textBox25.Text = tw.ExhaustGasTemperature;

                textBox40.Text = tw.Rpm2;
                textBox39.Text = tw.Speed2;
                textBox38.Text = tw.OilSupply2;
                textBox37.Text = tw.Oilback2;
                textBox36.Text = tw.OilCosumption2;
                textBox35.Text = tw.GasValue2;
                textBox34.Text = tw.OilCosumptionHigh2;
                textBox33.Text = tw.OilCosumptionShort2;
                textBox32.Text = tw.GasCosumptionHigh2;
                textBox31.Text = tw.GasCosumptionShort2;
                textBox30.Text = tw.Edu2;
                textBox29.Text = tw.ExhaustGasTemperature2;
                textBox73.Text = tw.DieselMiles.ToString();
                textBox73.Text = tw.DieselMiles.ToString();
                textBox75.Text = tw.OilCosts.ToString();
                textBox76.Text = tw.TotalCosts.ToString();
                textBox77.Text = tw.AverageCosts.ToString();
                textBox78.Text = tw.OilPrice.ToString();
                textBox74.Text = tw.OilAndGasMiles.ToString();
                textBox79.Text = tw.OilAndGasCosts.ToString();
                textBox80.Text = tw.OilAndGasOilPrice.ToString();
                textBox81.Text = tw.OilAndGasTotalCosts.ToString();
                textBox82.Text = tw.OilAndGasAverageCosts.ToString();
                textBox83.Text = tw.OilAndGasOilPrice.ToString();
                textBox84.Text = tw.OilAndGasGasPrice.ToString();

                textBox67.Text = tw.Phone;
                textBox72.Text = tw.DebugTimes;
                textBox71.Text = tw.DebugGroup;
                textBox70.Text = tw.DebugStaff;
                this.dateTimePicker1.Value = new DateTime(tw.DebugTime);
                textBox66.Text = tw.Dynamic;
                textBox65.Text = tw.Economy;
                textBox69.Text = tw.Name;
            }
        }

        /// <summary>
        /// 选择车辆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SelectCar selectcar = new SelectCar();
            selectcar.ShowDialog();
            if(selectcar.DialogResult == DialogResult.OK)
            {
                if (selectcar.SelectedCar != null)
                {
                    Object[] car = selectcar.SelectedCar;
                    this.textBox1.Text = ((ModificationContract)car[0]).ContractNo.ToString();
                    this.textBox2.Text = ((CarBaseInfo)car[1]).PlateNumber.ToString();
                    this.textBox3.Text = CarBaseInfo.ModifyType[((CarBaseInfo)car[1]).ModidiedType];
                    this.button4.Visible = false;
                }
            }
        }

    }
}
