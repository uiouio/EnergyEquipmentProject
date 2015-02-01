using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using SQLProvider;
using WorkProcedure.SQL;

namespace WorkProcedure
{
    public partial class InstallRecord : Form
    {
        public InstallRecord()
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
            OP_LZB oo = new OP_LZB();

            EntityClassLibrary.InstallRecord azjl = new EntityClassLibrary.InstallRecord();
            azjl.ModificationNumber = textBox1.Text;
            azjl.Unit = textBox2.Text;
            azjl.Name = textBox4.Text;
            azjl.Phone = textBox3.Text;
            azjl.License = textBox5.Text;
            azjl.Type = textBox6.Text;
            azjl.Model = textBox7.Text;
            azjl.Vin = textBox8.Text;
            azjl.AgeLimit = textBox9.Text;
            azjl.Condition = textBox10.Text;
            azjl.NoLoadConsumption = textBox13.Text;
            azjl.LoadConsumption = textBox12.Text;
            azjl.IdlingConsumption = textBox11.Text;
            azjl.TestRpm = textBox14.Text;
            azjl.TestSpeed = textBox15.Text;
            azjl.Oil = textBox16.Text;
            azjl.OilReturn = textBox17.Text;
            azjl.OilConsumption = textBox18.Text;
            azjl.GearSpeed = textBox22.Text;
            azjl.SpeedFactor = textBox21.Text;
            azjl.StartGear = textBox20.Text;
            azjl.BestGasOil = textBox26.Text;
            azjl.BestGasRpm = textBox19.Text;
            azjl.BestGasSpeed = textBox25.Text;
            azjl.BestGasProportion = textBox24.Text;
            azjl.SupplyPressure = textBox23.Text;
            azjl.MinimumFuelConsumption = textBox30.Text;
            azjl.LessTemperatureProtect = textBox29.Text;
            azjl.ManyTemperatureProtect = textBox28.Text;

            azjl.Rpm = textBox33.Text;
            azjl.Speed = textBox32.Text;
            azjl.OilSupply = textBox21.Text;
            azjl.Oilback = textBox27.Text;
            azjl.OilCosumption = textBox34.Text;
            azjl.GasValue = textBox39.Text;
            azjl.OilCosumptionHigh = textBox38.Text;
            azjl.OilCosumptionShort = textBox37.Text;
            azjl.GasCosumptionHigh = textBox36.Text;
            azjl.GasCosumptionShort = textBox35.Text;
            azjl.Edu = textBox41.Text;
            azjl.ExhaustGasTemperature = textBox40.Text;

            azjl.Rpm2 = textBox53.Text;
            azjl.Speed2 = textBox52.Text;
            azjl.OilSupply2 = textBox51.Text;
            azjl.Oilback2 = textBox50.Text;
            azjl.OilCosumption2 = textBox49.Text;
            azjl.GasValue2 = textBox48.Text;
            azjl.OilCosumptionHigh2 = textBox47.Text;
            azjl.OilCosumptionShort2 = textBox46.Text;
            azjl.GasCosumptionHigh2 = textBox45.Text;
            azjl.GasCosumptionShort2 = textBox44.Text;
            azjl.Edu2 = textBox43.Text;
            azjl.ExhaustGasTemperature2 = textBox42.Text;

            azjl.Rpm3 = textBox65.Text;
            azjl.Speed3 = textBox64.Text;
            azjl.OilSupply3 = textBox63.Text;
            azjl.Oilback3 = textBox62.Text;
            azjl.OilCosumption3 = textBox61.Text;
            azjl.GasValue3 = textBox60.Text;
            azjl.OilCosumptionHigh3 = textBox59.Text;
            azjl.OilCosumptionShort3 = textBox58.Text;
            azjl.GasCosumptionHigh3 = textBox57.Text;
            azjl.GasCosumptionShort3 = textBox56.Text;
            azjl.Edu3 = textBox55.Text;
            azjl.ExhaustGasTemperature3 = textBox54.Text;

            azjl.Rpm4 = textBox77.Text;
            azjl.Speed4 = textBox76.Text;
            azjl.OilSupply4 = textBox75.Text;
            azjl.Oilback4 = textBox74.Text;
            azjl.OilCosumption4 = textBox73.Text;
            azjl.GasValue4 = textBox72.Text;
            azjl.OilCosumptionHigh4 = textBox71.Text;
            azjl.OilCosumptionShort4 = textBox70.Text;
            azjl.GasCosumptionHigh4 = textBox69.Text;
            azjl.GasCosumptionShort4 = textBox68.Text;
            azjl.Edu4 = textBox67.Text;
            azjl.ExhaustGasTemperature4 = textBox66.Text;

            azjl.InstallGroup = textBox80.Text;
            azjl.Staff = textBox78.Text;
            azjl.InstallTime = dateTimePicker1.Value.Ticks;

            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                oo.saveInstallRecord(azjl);
            }

        }
    }
}
