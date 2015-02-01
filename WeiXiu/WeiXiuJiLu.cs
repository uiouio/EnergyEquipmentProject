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

        private void button3_Click(object sender, EventArgs e)
        {
            CommonMethod.DocumentPrint print = new CommonMethod.DocumentPrint();
            print.DocPrint(panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityClassLibrary.WeiXiuJiLu wxjl = new EntityClassLibrary.WeiXiuJiLu();
            OP_WX oo = new OP_WX();

            wxjl.ModificationNumber = textBox1.Text;
            wxjl.License = textBox2.Text;
            wxjl.GasType = textBox3.Text;
            wxjl.Condition = textBox4.Text;
            wxjl.GearSpeed = textBox7.Text;
            wxjl.SpeedFactor = textBox6.Text;
            wxjl.StartGear = textBox5.Text;
            wxjl.StartSpeed = textBox10.Text;
            wxjl.BestGasRpm = textBox9.Text;
            wxjl.BestGasSpeed = textBox13.Text;
            wxjl.BestGasOil = textBox8.Text;
            wxjl.BestGasProportion = textBox12.Text;
            wxjl.SupplyPressure = textBox11.Text;
            wxjl.MinimumFuelConsumption = textBox16.Text;
            wxjl.ManyTemperatureProtect = textBox14.Text;
            wxjl.LessTemperatureProtect = textBox15.Text;

            wxjl.Rpm = textBox20.Text;
            wxjl.Speed = textBox19.Text;
            wxjl.OilSupply = textBox18.Text;
            wxjl.Oilback = textBox17.Text;
            wxjl.OilCosumption = textBox24.Text;
            wxjl.GasValue = textBox23.Text;
            wxjl.OilCosumptionHigh = textBox22.Text;
            wxjl.OilCosumptionShort = textBox21.Text;
            wxjl.GasCosumptionHigh = textBox28.Text;
            wxjl.GasCosumptionShort = textBox27.Text;
            wxjl.Edu = textBox26.Text;
            wxjl.ExhaustGasTemperature = textBox25.Text;

            wxjl.Rpm2 = textBox40.Text;
            wxjl.Speed2 = textBox39.Text;
            wxjl.OilSupply2 = textBox38.Text;
            wxjl.Oilback2 = textBox37.Text;
            wxjl.OilCosumption2 = textBox36.Text;
            wxjl.GasValue2 = textBox35.Text;
            wxjl.OilCosumptionHigh2 = textBox34.Text;
            wxjl.OilCosumptionShort2 = textBox33.Text;
            wxjl.GasCosumptionHigh2 = textBox32.Text;
            wxjl.GasCosumptionShort2 = textBox31.Text;
            wxjl.Edu2 = textBox30.Text;
            wxjl.ExhaustGasTemperature2 = textBox29.Text;

            wxjl.Rpm3 = textBox52.Text;
            wxjl.Speed3 = textBox51.Text;
            wxjl.OilSupply3 = textBox50.Text;
            wxjl.Oilback3 = textBox49.Text;
            wxjl.OilCosumption3 = textBox48.Text;
            wxjl.GasValue3 = textBox47.Text;
            wxjl.OilCosumptionHigh3 = textBox46.Text;
            wxjl.OilCosumptionShort3 = textBox45.Text;
            wxjl.GasCosumptionHigh3 = textBox44.Text;
            wxjl.GasCosumptionShort3 = textBox43.Text;
            wxjl.Edu3 = textBox41.Text;
            wxjl.ExhaustGasTemperature3 = textBox25.Text;

            wxjl.Rpm4 = textBox64.Text;
            wxjl.Speed4 = textBox63.Text;
            wxjl.OilSupply4 = textBox62.Text;
            wxjl.Oilback4 = textBox61.Text;
            wxjl.OilCosumption4 = textBox60.Text;
            wxjl.GasValue4 = textBox59.Text;
            wxjl.OilCosumptionHigh4 = textBox58.Text;
            wxjl.OilCosumptionShort4 = textBox57.Text;
            wxjl.GasCosumptionHigh4 = textBox56.Text;
            wxjl.GasCosumptionShort4 = textBox55.Text;
            wxjl.Edu4 = textBox54.Text;
            wxjl.ExhaustGasTemperature4 = textBox53.Text;

            if (textBox73.Text == "")
            {
                wxjl.DieselMiles = 0;
            }
            else
            {
                wxjl.DieselMiles = float.Parse(textBox73.Text);
            }

            if (textBox75.Text == "")
            {
                wxjl.OilCosts = 0;
            }
            else
            {
                wxjl.OilCosts = float.Parse(textBox75.Text);
            }

            if (textBox76.Text == "")
            {
                wxjl.TotalCosts = 0;
            }
            else
            {
                wxjl.TotalCosts = float.Parse(textBox76.Text);
            }

            if (textBox77.Text == "")
            {
                wxjl.AverageCosts = 0;
            }
            else
            {
                wxjl.AverageCosts = float.Parse(textBox77.Text);
            }

            if (textBox78.Text == "")
            {
                wxjl.OilPrice = 0;
            }
            else
            {
                wxjl.OilPrice = float.Parse(textBox78.Text);
            }

            if (textBox74.Text == "")
            {
                wxjl.OilAndGasMiles = 0;
            }
            else 
            {
                wxjl.OilAndGasMiles = float.Parse(textBox74.Text);
            }

            if (textBox79.Text == "")
            {
                wxjl.OilAndGasCosts = 0;
            }
            else {
                wxjl.OilAndGasCosts = float.Parse(textBox79.Text);
            }

            if (textBox80.Text == "")
            {
                wxjl.OilAndGasOilPrice = 0;
            }
            else {
                wxjl.OilAndGasOilPrice = float.Parse(textBox80.Text);
            }

            if (textBox81.Text == "")
            {
                wxjl.OilAndGasTotalCosts = 0;
            }
            else {
                wxjl.OilAndGasTotalCosts = float.Parse(textBox81.Text);
            }

            if (textBox82.Text == "")
            {
                wxjl.OilAndGasAverageCosts = 0;
            }
            else {
                wxjl.OilAndGasAverageCosts = float.Parse(textBox82.Text);            
            }

            if (textBox83.Text == "")
            {
                wxjl.OilAndGasOilPrice = 0;
            }
            else
            {
                wxjl.OilAndGasOilPrice = float.Parse(textBox83.Text);
            }

            if (textBox84.Text == "")
            {
                wxjl.OilAndGasGasPrice = 0;
            }
            else
            {
                wxjl.OilAndGasGasPrice = float.Parse(textBox84.Text);
            }

            wxjl.DebugTimes = textBox72.Text;
            wxjl.DebugGroup = textBox71.Text;
            wxjl.DebugStaff = textBox70.Text;
            wxjl.DebugTime = dateTimePicker1.Value.Ticks;
            wxjl.Dynamic = textBox66.Text;
            wxjl.Economy = textBox65.Text;
            wxjl.Name = textBox69.Text;
            wxjl.Phone = int.Parse(textBox67.Text);

            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                oo.saveWeiXiuJiLu(wxjl);
            }
        
        }

       
      
    }
}
