using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;

namespace GongYiGuanLi
{
    public partial class PaiGongDan_view_Dialog : CommonControl.BaseForm
    {
        private CarBaseInfo carInfo;

        public CarBaseInfo CarInfo
        {
            get { return carInfo; }
            set { carInfo = value; }
        }
        public PaiGongDan_view_Dialog()
        {
            InitializeComponent();
        }

        private void PaiGongDan_view_Dialog_Load(object sender, EventArgs e)
        {
            label_11.Text = carInfo.PlateNumber;
            label12.Text = carInfo.VIN;
            label13.Text = carInfo.EngineIdentificationNumber;
            label21.Text = carInfo.VehicleType;
            label22.Text = carInfo.FuelConsumption+"L";
            label34.Text = carInfo.Mileage+"Km";
            label31.Text = carInfo.FuelType;
            label32.Text = carInfo.SupplyMode;
            label33.Text = carInfo.KerbMass+"Kg";
            label41.Text = carInfo.TotalMass+"Kg";
            label42.Text = carInfo.CylinderType;
            label43.Text = carInfo.CylinderVolume+"L";
            label51.Text = carInfo.CylinderWeight+"Kg";
            label52.Text = carInfo.CylinderPressure+"Pa";
            label66.Text = carInfo.Remarks;
        }
    }
}
