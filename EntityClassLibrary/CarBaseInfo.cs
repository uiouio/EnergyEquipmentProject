using System;
using Iesi.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EntityClassLibrary
{
    public class CarBaseInfo : BaseEntity
    { 
        
        private string plateNumber;
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string PlateNumber
        {
            get { return plateNumber; }
            set { plateNumber = value; }
        }
       
        private float mileage;
        /// <summary>
        /// 行驶里程
        /// </summary>
        public virtual  float Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        

        private float fuelConsumption;
        /// <summary>
        /// 百公里耗油
        /// </summary>
        public  virtual float FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        
        private string vehicleBrand;
        /// <summary>
        /// 车辆品牌
        /// </summary>
        public virtual string VehicleBrand
        {
            get { return vehicleBrand; }
            set { vehicleBrand = value; }
        }
        

        private string vehicleType;
        /// <summary>
        /// 汽车种类
        /// </summary>
        public virtual string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }
        
        private string fuelType;
        /// <summary>
        /// [否决的,待定]燃料类型
        /// </summary>
        public virtual string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }
        
        private string supplyMode;
        /// <summary>
        /// 发动机供油方式（机械泵、电喷式）
        /// </summary>
        public virtual string SupplyMode
        {
            get { return supplyMode; }
            set { supplyMode = value; }
        }
        
        private float totalMileage;
        /// <summary>
        /// 总里程
        /// </summary>
        public virtual float TotalMileage
        {
            get { return totalMileage; }
            set { totalMileage = value; }
        }
        
        private int modidiedType;
        /// <summary>
        /// 改装类型
        /// </summary>
        public virtual int ModidiedType
        {
            get { return modidiedType; }
            set { modidiedType = value; }
        }
      
        private string vIN;
        /// <summary>
        /// 车辆识别代码（VIN）
        /// </summary>
        public virtual string VIN
        {
            get { return vIN; }
            set { vIN = value; }
        }
      
        private string engineIdentificationNumber;
        /// <summary>
        /// 发动机编号
        /// </summary>
        public virtual string EngineIdentificationNumber
        {
            get { return engineIdentificationNumber; }
            set { engineIdentificationNumber = value; }
        }
       
        private float kerbMass;
        /// <summary>
        /// 整备质量
        /// </summary>
        public virtual float KerbMass
        {
            get { return kerbMass; }
            set { kerbMass = value; }
        }
        
        private float totalMass;
        /// <summary>
        /// 总质量
        /// </summary>
        public virtual float TotalMass
        {
            get { return totalMass; }
            set { totalMass = value; }
        }
      
        private string supportNumber;
        /// <summary>
        ///【否决的,待定】 支架编号
        /// </summary>
        public virtual string SupportNumber
        {
            get { return supportNumber; }
            set { supportNumber = value; }
        }
       
        private string supperNumber;
        /// <summary>
        /// 改装编号
        /// </summary>
        public virtual string SupperNumber
        {
            get { return supperNumber; }
            set { supperNumber = value; }
        }
       
        private long  supperTime;
        /// <summary>
        /// 改装时间
        /// </summary>
        public virtual long  SupperTime
        {
            get { return supperTime; }
            set { supperTime = value; }
        }
       
        private long modificationTime;
        /// <summary>
        /// 【否决的】改装时间
        /// </summary>
        public virtual long ModificationTime
        {
            get { return modificationTime; }
            set { modificationTime = value; }
        }
        

        private long supperPlace;
        /// <summary>
        ///改装地点
        /// </summary>
        public virtual long SupperPlace
        {
            get { return supperPlace; }
            set { supperPlace = value; }
        }
       
        private float afterFuelConsumption;
        /// <summary>
        ///改装后百公里耗油 
        /// </summary>
        public  virtual float AfterFuelConsumption
        {
            get { return afterFuelConsumption; }
            set { afterFuelConsumption = value; }
        }
       
        private float afterGasConsumption;
        /// <summary>
        /// 改装后百公里耗气
        /// </summary>
        public  virtual float AfterGasConsumption
        {
            get { return afterGasConsumption; }
            set { afterGasConsumption = value; }
        }
        
        private string cylinderType;
        /// <summary>
        /// 气瓶型号
        /// </summary>
        public virtual string CylinderType
        {
            get { return cylinderType; }
            set { cylinderType = value; }
        }
        private int cylinderValue;
        /// <summary>
        /// 气瓶价格
        /// </summary>
        public virtual int CylinderValue
        {
            get { return cylinderValue; }
            set { cylinderValue = value; }
        }
        private int cylinderNumber;
        /// <summary>
        /// 气瓶数量
        /// </summary>
        public virtual int CylinderNumber
        {
            get { return cylinderNumber; }
            set { cylinderNumber = value; }
        }
        private string cylinderNo;
        /// <summary>
        /// 气瓶编号
        /// </summary>
        public virtual string CylinderNo
        {
            get { return cylinderNo; }
            set { cylinderNo = value; }
        }
      

        private float cylinderWeight;
        /// <summary>
        /// 气瓶重量
        /// </summary>
        public virtual float CylinderWeight
        {
            get { return cylinderWeight; }
            set { cylinderWeight = value; }
        }
      
        private float waterVolume;
        /// <summary>
        /// 【否决的】水容积!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        public virtual float WaterVolume
        {
            get { return waterVolume; }
            set { waterVolume = value; }
        }
       
        private float thinckness;
        /// <summary>
        ///【否决的】 设计壁厚!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        public virtual float Thinckness
        {
            get { return thinckness; }
            set { thinckness = value; }
        }
       
        private string inFactoryTime;
        /// <summary>
        /// 【否决的】入厂时间
        /// </summary>
        public virtual string InFactoryTime
        {
            get { return inFactoryTime; }
            set { inFactoryTime = value; }
        }
        
        private string outFactoryTime;
        /// <summary>
        /// 【否决的】出厂时间
        /// </summary>
        public virtual string OutFactoryTime
        {
            get { return outFactoryTime; }
            set { outFactoryTime = value; }
        }
       
        private long bottlingMan;
        /// <summary>
        ///【否决的】 装瓶人
        /// </summary>
        public virtual long BottlingMan
        {
            get { return bottlingMan; }
            set { bottlingMan = value; }
        }
       
        private long eCUOperator;
        /// <summary>
        ///【否决的】 ECU安装人
        /// </summary>
        public virtual long ECUOperator
        {
            get { return eCUOperator; }
            set { eCUOperator = value; }
        }
      
        private float cylinderPressure;
        /// <summary>
        /// 气瓶压力
        /// </summary>
        public virtual float CylinderPressure
        {
            get { return cylinderPressure; }
            set { cylinderPressure = value; }
        }
       
        private float cylinderVolume;
        /// <summary>
        /// 气瓶体积
        /// </summary>
        public virtual float CylinderVolume
        {
            get { return cylinderVolume; }
            set { cylinderVolume = value; }
        }
       
        private float chargeWeight;
        /// <summary>
        ///[否决的] 充气重量!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        public virtual float ChargeWeight
        {
            get { return chargeWeight; }
            set { chargeWeight = value; }
        }
        
        private string functionalValidation;
        /// <summary>
        ///[否决的] 油量确认
        /// </summary>
        public  virtual string FunctionalValidation
        {
            get { return functionalValidation; }
            set { functionalValidation = value; }
        }
      
        private string goodsValidation;
        /// <summary>
        /// 功能确认
        /// </summary>
        public virtual string GoodsValidation
        {
            get { return goodsValidation; }
            set { goodsValidation = value; }
        }
       

        private string bodyImage;
        /// <summary>
        /// 车身图片
        /// </summary>
        public virtual  string BodyImage
        {
            get { return bodyImage; }
            set { bodyImage = value; }

        }
        
        private string remarks;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private string qJRemarks;

        public virtual string QJRemarks
        {
            get { return qJRemarks; }
            set { qJRemarks = value; }
        }
        private CustomBaseInfo cbi;

        public virtual CustomBaseInfo Cbi
        {
            get { return cbi; }
            set { cbi = value; }
        }
        private ModificationContract modificationID;

        public virtual ModificationContract ModificationID
        {
            get { return modificationID; }
            set { modificationID = value; }
        }
        private ISet<CustomerServiceRecord> customRecordInfo;

        public virtual ISet<CustomerServiceRecord> CustomRecordInfo
        {
            get { return customRecordInfo; }
            set { customRecordInfo = value; }
        }

        public static string[] ModifyType = { "CNG汽油", "CNG柴油", "LNG柴油" };
     }
}
