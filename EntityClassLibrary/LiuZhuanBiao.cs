using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Iesi.Collections.Generic;

namespace EntityClassLibrary
{
    public class LiuZhuanBiao:BaseEntity
    {
        
        private long carBaseInfoID;
        public virtual long CarBaseInfoID
        {
            get { return carBaseInfoID; }
            set { carBaseInfoID = value; }
        }


        private string wiringInstaller;
        public virtual string WiringInstaller
        {
            get { return wiringInstaller; }
            set { wiringInstaller = value; }
        }


        private string wiringHead;
        public virtual string WiringHead
        {
            get { return wiringHead; }
            set { wiringHead = value; }
        }
        

        private string wiringRemark;
        public virtual string WiringRemark
        {
            get { return wiringRemark; }
            set { wiringRemark = value; }
        }

        private string electricECUInstaller;
        public virtual string ElectricECUInstaller
        {
            get { return electricECUInstaller; }
            set { electricECUInstaller = value; }
        }


        private string electricECUHead;
        public virtual string ElectricECUHead
        {
            get { return electricECUHead; }
            set { electricECUHead = value; }
        }
        
        

        private string electricECURemark;
        public virtual string ElectricECURemark
        {
            get { return electricECURemark; }
            set { electricECURemark = value; }
        }

        private string limitOilInstaller;
        public virtual string LimitOilInstaller
        {
            get { return limitOilInstaller; }
            set { limitOilInstaller = value; }
        }


        private string limitOilHead;
        public virtual string LimitOilHead
        {
            get { return limitOilHead; }
            set { limitOilHead = value; }
        }
        

        private string limitOilRemark;
        public virtual string LimitOilRemark
        {
            get { return limitOilRemark; }
            set { limitOilRemark = value; }
        }

        private string sensorInstaller;
        public virtual string SensorInstaller
        {
            get { return sensorInstaller; }
            set { sensorInstaller = value; }
        }


        private string sensorHead;
        public virtual string SensorHead
        {
            get { return sensorHead; }
            set { sensorHead = value; }
        }
      

        private string sensorRemark;
        public virtual string SensorRemark
        {
            get { return sensorRemark; }
            set { sensorRemark = value; }
        }

        private string switchInstaller;
        public virtual string SwitchInstaller
        {
            get { return switchInstaller; }
            set { switchInstaller = value; }
        }


        private string switchHead;
        public virtual string SwitchHead
        {
            get { return switchHead; }
            set { switchHead = value; }
        }
       
        

        private string switchRemark;
        public virtual string SwitchRemark
        {
            get { return switchRemark; }
            set { switchRemark = value; }
        }

        private string keySwitchInstaller;
        public virtual string KeySwitchInstaller
        {
            get { return keySwitchInstaller; }
            set { keySwitchInstaller = value; }
        }


        private string keySwitchHead;
        public virtual string KeySwitchHead
        {
            get { return keySwitchHead; }
            set { keySwitchHead = value; }
        }
       

        private string keySwitchReamrk;
        public virtual string KeySwitchReamrk
        {
            get { return keySwitchReamrk; }
            set { keySwitchReamrk = value; }
        }

        private string lNGConnectionInstaller;
        public virtual string LNGConnectionInstaller
        {
            get { return lNGConnectionInstaller; }
            set { lNGConnectionInstaller = value; }
        }



        private string lNGConnectionHead;
        public virtual string LNGConnectionHead
        {
            get { return lNGConnectionHead; }
            set { lNGConnectionHead = value; }
        }
       

        private string lNGConnectionHeadRemark;
        public virtual string LNGConnectionHeadRemark
        {
            get { return lNGConnectionHeadRemark; }
            set { lNGConnectionHeadRemark = value; }
        }

        private string cNGConnectionInstaller;
        public virtual string CNGConnectionInstaller
        {
            get { return cNGConnectionInstaller; }
            set { cNGConnectionInstaller = value; }
        }


        private string cNGConnectionHead;
        public virtual string CNGConnectionHead
        {
            get { return cNGConnectionHead; }
            set { cNGConnectionHead = value; }
        }
        
       

        private string cNGConnectionRemark;
        public virtual string CNGConnectionRemark
        {
            get { return cNGConnectionRemark; }
            set { cNGConnectionRemark = value; }
        }

        private string mixerConnectionInstaller;
        public virtual string MixerConnectionInstaller
        {
            get { return mixerConnectionInstaller; }
            set { mixerConnectionInstaller = value; }
        }


        private string mixerConnectionHead;
        public virtual string MixerConnectionHead
        {
            get { return mixerConnectionHead; }
            set { mixerConnectionHead = value; }
        }
       

        private string mixerConnectionRemark;
        public virtual string MixerConnectionRemark
        {
            get { return mixerConnectionRemark; }
            set { mixerConnectionRemark = value; }
        }

        private string speedAcquisitionInstaller;
        public virtual string SpeedAcquisitionInstaller
        {
            get { return speedAcquisitionInstaller; }
            set { speedAcquisitionInstaller = value; }
        }



        private string speedAcquisitionHead;
        public virtual string SpeedAcquisitionHead
        {
            get { return speedAcquisitionHead; }
            set { speedAcquisitionHead = value; }
        }
       

        private string speedAcquisitionRemark;
        public virtual string SpeedAcquisitionRemark
        {
            get { return speedAcquisitionRemark; }
            set { speedAcquisitionRemark = value; }
        }

        private string speedSignalInstaller;
        public virtual string SpeedSignalInstaller
        {
            get { return speedSignalInstaller; }
            set { speedSignalInstaller = value; }
        }


        private string speedSignalHead;
        public virtual string SpeedSignalHead
        {
            get { return speedSignalHead; }
            set { speedSignalHead = value; }
        }
        

        private string speedSignalRemark;
        public virtual string SpeedSignalRemark
        {
            get { return speedSignalRemark; }
            set { speedSignalRemark = value; }
        }

        private string temperatureSignalInstaller;
        public virtual string TemperatureSignalInstaller
        {
            get { return temperatureSignalInstaller; }
            set { temperatureSignalInstaller = value; }
        }


        private string temperatureSignalHead;
        public virtual string TemperatureSignalHead
        {
            get { return temperatureSignalHead; }
            set { temperatureSignalHead = value; }
        }
       

        private string temperatureSignalRemark;
        public virtual string TemperatureSignalRemark
        {
            get { return temperatureSignalRemark; }
            set { temperatureSignalRemark = value; }
        }

        private string fuelSignalInstaller;
        public virtual string FuelSignalInstaller
        {
            get { return fuelSignalInstaller; }
            set { fuelSignalInstaller = value; }
        }


        private string fuelSignalHead;
        public virtual string FuelSignalHead
        {
            get { return fuelSignalHead; }
            set { fuelSignalHead = value; }
        }
       

        private string fuelSignalRemark;
        public virtual string FuelSignalRemark
        {
            get { return fuelSignalRemark; }
            set { fuelSignalRemark = value; }
        }

        private string systemDebugInstaller;
        public virtual string SystemDebugInstaller
        {
            get { return systemDebugInstaller; }
            set { systemDebugInstaller = value; }
        }
       

        private string systemDebugHead;
        public virtual string SystemDebugHead
        {
            get { return systemDebugHead; }
            set { systemDebugHead = value; }
        }
       

        private string systemDebugRemark;
        public virtual string SystemDebugRemark
        {
            get { return systemDebugRemark; }
            set { systemDebugRemark = value; }
        }

        private string trainingLocation;
        public virtual string TrainingLocation
        {
            get { return trainingLocation; }
            set { trainingLocation = value; }
        }

        private string training;
        public virtual string Training
        {
            get { return training; }
            set { training = value; }
        }

        private string driverGuideCollect;
        public virtual string DriverGuideCollect
        {
            get { return driverGuideCollect; }
            set { driverGuideCollect = value; }
        }
       

        private string trainersSign;
        public virtual string TrainersSign
        {
            get { return trainersSign; }
            set { trainersSign = value; }
        }
        

        private string trainerDriverSign;
        public virtual string TrainerDriverSign
        {
            get { return trainerDriverSign; }
            set { trainerDriverSign = value; }
        }
       


        private long trainingDates;
        public virtual long TrainingDates
        {
            get { return trainingDates; }
            set { trainingDates = value; }
        }


        private int affectOriginalCar;
        public virtual int AffectOriginalCar
        {
            get { return affectOriginalCar; }
            set { affectOriginalCar = value; }
        }


        private int affectOriginalGasPedal;
        public virtual int AffectOriginalGasPedal
        {
            get { return affectOriginalGasPedal; }
            set { affectOriginalGasPedal = value; }
        }
        

        private int affectOriginalSpeed;
        public virtual int AffectOriginalSpeed
        {
            get { return affectOriginalSpeed; }
            set { affectOriginalSpeed = value; }
        }



        private int affectOriginalPower;
        public virtual int AffectOriginalPower
        {
            get { return affectOriginalPower; }
            set { affectOriginalPower = value; }
        }

        private string factory;
        public virtual string Factory
        {
            get { return factory; }
            set { factory = value; }
        }

        private float engingPower;
        public virtual float EngingPower
        {
            get { return engingPower; }
            set { engingPower = value; }
        }

        private int scratchSaveState;
        public virtual int ScratchSaveState
        {
            get { return scratchSaveState; }
            set { scratchSaveState = value; }
        }
       
        public enum ScratchSave
        {
            Scratch=0,
            Save=1
        }

        private long time;
        public virtual long Time
        {
            get { return time; }
            set { time = value; }
        }




        //private string producer;
        //public virtual string Producer
        //{
        //    get { return producer; }
        //    set { producer = value; }
        //}

        //private long dateOfManufacture;
        //public virtual long DateOfManufacture
        //{
        //    get { return dateOfManufacture; }
        //    set { dateOfManufacture = value; }
        //}

        //private long status;
        //public virtual long Status
        //{
        //    get { return status; }
        //    set { status = value; }
        //}

        private RefitWork paiGongDan;
        public virtual RefitWork PaiGongDan
        {
            get { return paiGongDan; }
            set { paiGongDan = value; }
        }

    }
}
