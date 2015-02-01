using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace EntityClassLibrary
{
    public class HuiYuanBaseInfo : BaseEntity
    {

        private string name;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string birthday;

        public virtual string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private int marriage;

        public virtual int Marriage
        {
            get { return marriage; }
            set { marriage = value; }
        }


        private int sex;

        public virtual int Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private string address;

        public virtual string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string phone1;

        public virtual string Phone1
        {
            get { return phone1; }
            set { phone1 = value; }
        }


        private string phone2;

        public virtual string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }

        private string licenseCategory;

        public virtual string LicenseCategory
        {
            get { return licenseCategory; }
            set { licenseCategory = value; }
        }

        private float drivingExperience;

        public virtual float DrivingExperience
        {
            get { return drivingExperience; }
            set { drivingExperience = value; }
        }

        private string companyName;

        public virtual string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }


        private string monthlySalary;

        public virtual string MonthlySalary
        {
            get { return monthlySalary; }
            set { monthlySalary = value; }
        }


        private string comanyIdentity;

        public virtual string ComanyIdentity
        {
            get { return comanyIdentity; }
            set { comanyIdentity = value; }
        }


        private string comanySize;

        public virtual string ComanySize
        {
            get { return comanySize; }
            set { comanySize = value; }
        }

        private string comanyProperty;

        public virtual string ComanyProperty
        {
            get { return comanyProperty; }
            set { comanyProperty = value; }
        }


        private int businessIntent;

        public virtual int BusinessIntent
        {
            get { return businessIntent; }
            set { businessIntent = value; }
        }



        private int dangerousGoodsCertificate;

        public virtual int DangerousGoodsCertificate
        {
            get { return dangerousGoodsCertificate; }
            set { dangerousGoodsCertificate = value; }
        }


        private int escortSyndrome;

        public virtual int EscortSyndrome
        {
            get { return escortSyndrome; }
            set { escortSyndrome = value; }
        }


        private string plateNumber;

        public virtual string PlateNumber
        {
            get { return plateNumber; }
            set { plateNumber = value; }
        }


        private float mileage;

        public virtual float Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }


        private string vehicleBrand;

        public virtual string VehicleBrand
        {
            get { return vehicleBrand; }
            set { vehicleBrand = value; }
        }

        private string vehicleType;

        public virtual string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }


        private string fuelType;

        public virtual string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }


        private string supplyMode;

        public virtual string SupplyMode
        {
            get { return supplyMode; }
            set { supplyMode = value; }
        }


        private float fuelConsumption;

        public virtual float FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }


        private float carCondition;

        public virtual float CarCondition
        {
            get { return carCondition; }
            set { carCondition = value; }
        }

        private string running;

        public virtual string Running
        {
            get { return running; }
            set { running = value; }
        }


        private string vehicleCompany;

        public virtual string VehicleCompany
        {
            get { return vehicleCompany; }
            set { vehicleCompany = value; }
        }


        private string location;

        public virtual string Location
        {
            get { return location; }
            set { location = value; }
        }


        private float vehicleNumber;

        public virtual float VehicleNumber
        {
            get { return vehicleNumber; }
            set { vehicleNumber = value; }
        }


        private long modificationTime;

        public virtual long ModificationTime
        {
            get { return modificationTime; }
            set { modificationTime = value; }
        }

        private string modifiedPlace;

        public virtual string ModifiedPlace
        {
            get { return modifiedPlace; }
            set { modifiedPlace = value; }
        }

        private string modifiedType;

        public virtual string ModifiedType
        {
            get { return modifiedType; }
            set { modifiedType = value; }
        }


        private float afterModificationFuelConsumption;

        public virtual float AfterModificationFuelConsumption
        {
            get { return afterModificationFuelConsumption; }
            set { afterModificationFuelConsumption = value; }
        }

        private float afterModificationGasConsumption;

        public virtual float AfterModificationGasConsumption
        {
            get { return afterModificationGasConsumption; }
            set { afterModificationGasConsumption = value; }
        }



        private string refitInformation;

        public virtual string RefitInformation
        {
            get { return refitInformation; }
            set { refitInformation = value; }
        }



        private string returnMode;

        public virtual string ReturnMode
        {
            get { return returnMode; }
            set { returnMode = value; }
        }

        private string  typesGoods;

        public virtual string  TypesGoods
        {
            get { return typesGoods; }
            set { typesGoods = value; }
        }


        private string mainLine;

        public virtual string MainLine
        {
            get { return mainLine; }
            set { mainLine = value; }
        }


        private float mainTime;

        public virtual float MainTime
        {
            get { return mainTime; }
            set { mainTime = value; }
        }


        private float fillingStation;

        public virtual float FillingStation
        {
            get { return fillingStation; }
            set { fillingStation = value; }
        }

        private string operatingUnit;

        public virtual string OperatingUnit
        {
            get { return operatingUnit; }
            set { operatingUnit = value; }
        }


        private string maintenanceSites;

        public virtual string MaintenanceSites
        {
            get { return maintenanceSites; }
            set { maintenanceSites = value; }
        }

        private string opinion;

        public virtual string Opinion
        {
            get { return opinion; }
            set { opinion = value; }
        }


        private string help;

        public virtual string Help
        {
            get { return help; }
            set { help = value; }
        }



        private int membershipType;

        public virtual int MembershipType
        {
            get { return membershipType; }
            set { membershipType = value; }
        }


        private long registrationTime;

        public virtual long RegistrationTime
        {
            get { return registrationTime; }
            set { registrationTime = value; }
        }
        /// <summary>
        /// 婚否
        /// </summary>
        public enum Marriage1
        {
            Marriaged = 0,
            unMarriaged = 1
        }

        public enum Sex1
        {
            Man = 0,
            Female = 1
        }
        /// <summary>
        /// 意向
        /// </summary>
        public enum insent
        {
            Changtu = 0,
            Duantu = 1,
            Junke = 2

        }
        /// <summary>
        /// 危险品资格证
        /// </summary>
        public enum weixian
        {
            YES = 0,
            NO = 1

        }
        /// <summary>
        /// 押运资格证
        /// </summary>
        public enum yayun
        {
            YES = 0,
            NO = 1

        }
        /// <summary>
        /// 会员类别
        /// </summary>
        public enum huiyuan
        {
            zhuti = 0,

            teyao = 1
        }
        /// <summary>
        /// 运输商品类别
        /// </summary>
        public enum GoodType
        {
            common=0,one=1,two=2,three=3
        }
        public static string[] SexArry = { "男", "女" };
    }

}
