using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class WeiXiuJiLu: BaseEntity
    {
        private string modificationNumber;
        /// <summary>
        /// 改装编号
        /// </summary>

        public virtual string ModificationNumber
        {
            get { return modificationNumber; }
            set { modificationNumber = value; }
        }

        private string license;
        /// <summary>
        /// 车辆牌照
        /// </summary>

        public virtual string License
        {
            get { return license; }
            set { license = value; }
        }

        private string gasType;
        /// <summary>
        /// 燃气类型
        /// </summary>
        public virtual string GasType
        {
            get { return gasType; }
            set { gasType = value; }
        }

        private string condition;
        /// <summary>
        /// 跟车发现的问题
        /// </summary>

        public virtual string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        private string gearSpeed;
        /// <summary>
        /// 齿轮转速
        /// </summary>

        public virtual string GearSpeed
        {
            get { return gearSpeed; }
            set { gearSpeed = value; }
        }

        private string speedFactor;
        /// <summary>
        /// 车速系数
        /// </summary>

        public virtual string SpeedFactor
        {
            get { return speedFactor; }
            set { speedFactor = value; }
        }

        private string startGear;
        /// <summary>
        /// 启动转速
        /// </summary>

        public virtual string StartGear
        {
            get { return startGear; }
            set { startGear = value; }
        }

        private string startSpeed;
        /// <summary>
        /// 启动车速
        /// </summary>
        public virtual string StartSpeed
        {
            get { return startSpeed; }
            set { startSpeed = value; }
        }


        private string bestGasRpm;
        /// <summary>
        /// 最佳供气转速
        /// </summary>

        public virtual string BestGasRpm
        {
            get { return bestGasRpm; }
            set { bestGasRpm = value; }
        }

        private string bestGasOil;
        /// <summary>
        /// 最佳供油油耗
        /// </summary>

        public virtual string BestGasOil
        {
            get { return bestGasOil; }
            set { bestGasOil = value; }
        }

        private string bestGasSpeed;
        /// <summary>
        /// 最佳供气车速
        /// </summary>

        public virtual string BestGasSpeed
        {
            get { return bestGasSpeed; }
            set { bestGasSpeed = value; }
        }

        private string bestGasProportion;
        /// <summary>
        /// 最佳汽油比例
        /// </summary>

        public virtual string BestGasProportion
        {
            get { return bestGasProportion; }
            set { bestGasProportion = value; }
        }

        private string supplyPressure;
        /// <summary>
        /// 供气压力
        /// </summary>

        public virtual string SupplyPressure
        {
            get { return supplyPressure; }
            set { supplyPressure = value; }
        }

        private string minimumFuelConsumption;
        /// <summary>
        /// 最小油耗
        /// </summary>

        public virtual string MinimumFuelConsumption
        {
            get { return minimumFuelConsumption; }
            set { minimumFuelConsumption = value; }
        }

        private string lessTemperatureProtect;
        /// <summary>
        /// 欠温保护
        /// </summary>

        public virtual string LessTemperatureProtect
        {
            get { return lessTemperatureProtect; }
            set { lessTemperatureProtect = value; }
        }

        private string manyTemperatureProtect;
        /// <summary>
        /// 过温保护
        /// </summary>

        public virtual string ManyTemperatureProtect
        {
            get { return manyTemperatureProtect; }
            set { manyTemperatureProtect = value; }
        }

        private string rpm;
        /// <summary>
        /// 转速
        /// </summary>

        public virtual string Rpm
        {
            get { return rpm; }
            set { rpm = value; }
        }

        private string speed;
        /// <summary>
        /// 车速
        /// </summary>

        public virtual string Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private string oilSupply;
        /// <summary>
        /// 供油
        /// </summary>

        public virtual string OilSupply
        {
            get { return oilSupply; }
            set { oilSupply = value; }
        }


        private string oilback;
        /// <summary>
        /// 回油
        /// </summary>

        public virtual string Oilback
        {
            get { return oilback; }
            set { oilback = value; }
        }

        private string oilCosumption;
        /// <summary>
        /// 油耗
        /// </summary>

        public virtual string OilCosumption
        {
            get { return oilCosumption; }
            set { oilCosumption = value; }
        }

        private string gasValue;
        /// <summary>
        /// 气值
        /// </summary>

        public virtual string GasValue
        {
            get { return gasValue; }
            set { gasValue = value; }
        }

        private string oilCosumptionHigh;
        /// <summary>
        /// 油耗高位
        /// </summary>

        public virtual string OilCosumptionHigh
        {
            get { return oilCosumptionHigh; }
            set { oilCosumptionHigh = value; }
        }

        private string oilCosumptionShort;
        /// <summary>
        /// 油耗底位
        /// </summary>

        public virtual string OilCosumptionShort
        {
            get { return oilCosumptionShort; }
            set { oilCosumptionShort = value; }
        }

        private string gasCosumptionShort;
        /// <summary>
        /// 气耗地位
        /// </summary>
        public virtual string GasCosumptionShort
        {
            get { return gasCosumptionShort; }
            set { gasCosumptionShort = value; }
        }

        private string gasCosumptionHigh;
        /// <summary>
        /// 气耗高位
        /// </summary>
        public virtual string GasCosumptionHigh
        {
            get { return gasCosumptionHigh; }
            set { gasCosumptionHigh = value; }
        }


        private string edu;
        /// <summary>
        /// EDU温度
        /// </summary>

        public virtual string Edu
        {
            get { return edu; }
            set { edu = value; }
        }

        private string exhaustGasTemperature;
        /// <summary>
        /// 排气温度
        /// </summary>

        public virtual string ExhaustGasTemperature
        {
            get { return exhaustGasTemperature; }
            set { exhaustGasTemperature = value; }
        }

        private string rpm2;
        /// <summary>
        /// 转速
        /// </summary>

        public virtual string Rpm2
        {
            get { return rpm2; }
            set { rpm2 = value; }
        }

        private string speed2;
        /// <summary>
        /// 车速
        /// </summary>

        public virtual string Speed2
        {
            get { return speed2; }
            set { speed2 = value; }
        }

        private string oilSupply2;
        /// <summary>
        /// 供油
        /// </summary>

        public virtual string OilSupply2
        {
            get { return oilSupply2; }
            set { oilSupply2 = value; }
        }


        private string oilback2;
        /// <summary>
        /// 回油
        /// </summary>

        public virtual string Oilback2
        {
            get { return oilback2; }
            set { oilback2 = value; }
        }

        private string oilCosumption2;
        /// <summary>
        /// 油耗
        /// </summary>

        public virtual string OilCosumption2
        {
            get { return oilCosumption2; }
            set { oilCosumption2 = value; }
        }

        private string gasValue2;
        /// <summary>
        /// 气值
        /// </summary>

        public virtual string GasValue2
        {
            get { return gasValue2; }
            set { gasValue2 = value; }
        }

        private string oilCosumptionHigh2;
        /// <summary>
        /// 油耗高位
        /// </summary>

        public virtual string OilCosumptionHigh2
        {
            get { return oilCosumptionHigh2; }
            set { oilCosumptionHigh2 = value; }
        }

        private string oilCosumptionShort2;
        /// <summary>
        /// 油耗底位
        /// </summary>

        public virtual string OilCosumptionShort2
        {
            get { return oilCosumptionShort2; }
            set { oilCosumptionShort2 = value; }
        }

        private string gasCosumptionShort2;
        /// <summary>
        /// 气耗地位
        /// </summary>
        public virtual string GasCosumptionShort2
        {
            get { return gasCosumptionShort2; }
            set { gasCosumptionShort2 = value; }
        }

        private string gasCosumptionHigh2;
        /// <summary>
        /// 气耗高位
        /// </summary>
        public virtual string GasCosumptionHigh2
        {
            get { return gasCosumptionHigh2; }
            set { gasCosumptionHigh2 = value; }
        }
        private string edu2;
        /// <summary>
        /// EDU温度
        /// </summary>

        public virtual string Edu2
        {
            get { return edu2; }
            set { edu2 = value; }
        }

        private string exhaustGasTemperature2;
        /// <summary>
        /// 排气温度
        /// </summary>

        public virtual string ExhaustGasTemperature2
        {
            get { return exhaustGasTemperature2; }
            set { exhaustGasTemperature2 = value; }
        }


        private string rpm3;
        /// <summary>
        /// 转速
        /// </summary>

        public virtual string Rpm3
        {
            get { return rpm3; }
            set { rpm3 = value; }
        }

        private string speed3;
        /// <summary>
        /// 车速
        /// </summary>

        public virtual string Speed3
        {
            get { return speed3; }
            set { speed3 = value; }
        }

        private string oilSupply3;
        /// <summary>
        /// 供油
        /// </summary>

        public virtual string OilSupply3
        {
            get { return oilSupply3; }
            set { oilSupply3 = value; }
        }


        private string oilback3;
        /// <summary>
        /// 回油
        /// </summary>

        public virtual string Oilback3
        {
            get { return oilback3; }
            set { oilback3 = value; }
        }

        private string oilCosumption3;
        /// <summary>
        /// 油耗
        /// </summary>

        public virtual string OilCosumption3
        {
            get { return oilCosumption3; }
            set { oilCosumption3 = value; }
        }

        private string gasValue3;
        /// <summary>
        /// 气值
        /// </summary>

        public virtual string GasValue3
        {
            get { return gasValue3; }
            set { gasValue3 = value; }
        }

        private string oilCosumptionHigh3;
        /// <summary>
        /// 油耗高位
        /// </summary>

        public virtual string OilCosumptionHigh3
        {
            get { return oilCosumptionHigh3; }
            set { oilCosumptionHigh3 = value; }
        }

        private string oilCosumptionShort3;
        /// <summary>
        /// 油耗底位
        /// </summary>

        public virtual string OilCosumptionShort3
        {
            get { return oilCosumptionShort3; }
            set { oilCosumptionShort3 = value; }
        }

        private string gasCosumptionShort3;
        /// <summary>
        /// 气耗地位
        /// </summary>
        public virtual string GasCosumptionShort3
        {
            get { return gasCosumptionShort3; }
            set { gasCosumptionShort3 = value; }
        }

        private string gasCosumptionHigh3;
        /// <summary>
        /// 气耗高位
        /// </summary>
        public virtual string GasCosumptionHigh3
        {
            get { return gasCosumptionHigh3; }
            set { gasCosumptionHigh3 = value; }
        }

        private string edu3;
        /// <summary>
        /// EDU温度
        /// </summary>

        public virtual string Edu3
        {
            get { return edu3; }
            set { edu3 = value; }
        }

        private string exhaustGasTemperature3;
        /// <summary>
        /// 排气温度
        /// </summary>

        public virtual string ExhaustGasTemperature3
        {
            get { return exhaustGasTemperature3; }
            set { exhaustGasTemperature3 = value; }
        }


        private string rpm4;
        /// <summary>
        /// 转速
        /// </summary>

        public virtual string Rpm4
        {
            get { return rpm4; }
            set { rpm4 = value; }
        }

        private string speed4;
        /// <summary>
        /// 车速
        /// </summary>

        public virtual string Speed4
        {
            get { return speed4; }
            set { speed4 = value; }
        }

        private string oilSupply4;
        /// <summary>
        /// 供油
        /// </summary>

        public virtual string OilSupply4
        {
            get { return oilSupply4; }
            set { oilSupply4 = value; }
        }


        private string oilback4;
        /// <summary>
        /// 回油
        /// </summary>

        public virtual string Oilback4
        {
            get { return oilback4; }
            set { oilback4 = value; }
        }

        private string oilCosumption4;
        /// <summary>
        /// 油耗
        /// </summary>

        public virtual string OilCosumption4
        {
            get { return oilCosumption4; }
            set { oilCosumption4 = value; }
        }

        private string gasValue4;
        /// <summary>
        /// 气值
        /// </summary>

        public virtual string GasValue4
        {
            get { return gasValue4; }
            set { gasValue4 = value; }
        }

        private string oilCosumptionHigh4;
        /// <summary>
        /// 油耗高位
        /// </summary>

        public virtual string OilCosumptionHigh4
        {
            get { return oilCosumptionHigh4; }
            set { oilCosumptionHigh4 = value; }
        }

        private string oilCosumptionShort4;
        /// <summary>
        /// 油耗底位
        /// </summary>

        public virtual string OilCosumptionShort4
        {
            get { return oilCosumptionShort4; }
            set { oilCosumptionShort4 = value; }
        }

        private string gasCosumptionShort4;
        /// <summary>
        /// 气耗地位
        /// </summary>
        public virtual string GasCosumptionShort4
        {
            get { return gasCosumptionShort4; }
            set { gasCosumptionShort4 = value; }
        }

        private string gasCosumptionHigh4;
        /// <summary>
        /// 气耗高位
        /// </summary>
        public virtual string GasCosumptionHigh4
        {
            get { return gasCosumptionHigh4; }
            set { gasCosumptionHigh4 = value; }
        }
        private string edu4;
        /// <summary>
        /// EDU温度
        /// </summary>

        public virtual string Edu4
        {
            get { return edu4; }
            set { edu4 = value; }
        }

        private string exhaustGasTemperature4;
        /// <summary>
        /// 排气温度
        /// </summary>

        public virtual string ExhaustGasTemperature4
        {
            get { return exhaustGasTemperature4; }
            set { exhaustGasTemperature4 = value; }
        }


        private float dieselMiles;
        /// <summary>
        /// 单烧柴油里程
        /// </summary>
        public virtual float DieselMiles
        {
            get { return dieselMiles; }
            set { dieselMiles = value; }
        }

        private float oilCosts;
        /// <summary>
        /// 单烧柴油油费
        /// </summary>
        public virtual float OilCosts
        {
            get { return oilCosts; }
            set { oilCosts = value; }
        }


        private float totalCosts;
        /// <summary>
        /// 单烧柴油总费
        /// </summary>
        public virtual float TotalCosts
        {
            get { return totalCosts; }
            set { totalCosts = value; }
        }

        private float averageCosts;
        /// <summary>
        /// 单烧柴油均费
        /// </summary>
        public virtual float AverageCosts
        {
            get { return averageCosts; }
            set { averageCosts = value; }
        }

        private float oilPrice;
        /// <summary>
        /// 单烧柴油油价
        /// </summary>
        public virtual float OilPrice
        {
            get { return oilPrice; }
            set { oilPrice = value; }
        }

        private float oilAndGasMiles;
        /// <summary>
        /// 油气混烧里程
        /// </summary>
        public virtual float OilAndGasMiles
        {
            get { return oilAndGasMiles; }
            set { oilAndGasMiles = value; }
        }

        private float oilAndGasCosts;
        /// <summary>
        /// 油气混烧气费
        /// </summary>
        public virtual float OilAndGasCosts
        {
            get { return oilAndGasCosts; }
            set { oilAndGasCosts = value; }
        }

        private float oilAndGasOilCosts;
        /// <summary>
        /// 油气混烧油费
        /// </summary>
        public virtual float OilAndGasOilCosts
        {
            get { return oilAndGasOilCosts; }
            set { oilAndGasOilCosts = value; }
        }

        private float oilAndGasTotalCosts;
        /// <summary>
        /// 油气混烧总费
        /// </summary>
        public virtual float OilAndGasTotalCosts
        {
            get { return oilAndGasTotalCosts; }
            set { oilAndGasTotalCosts = value; }
        }

        private float oilAndGasAverageCosts;
        /// <summary>
        /// 油气混烧均费
        /// </summary>
        public virtual float OilAndGasAverageCosts
        {
            get { return oilAndGasAverageCosts; }
            set { oilAndGasAverageCosts = value; }
        }

        private float oilAndGasOilPrice;
        /// <summary>
        /// 油气混烧油价
        /// </summary>
        public virtual float OilAndGasOilPrice
        {
            get { return oilAndGasOilPrice; }
            set { oilAndGasOilPrice = value; }
        }

        private float oilAndGasGasPrice;
        /// <summary>
        /// 油气混烧气价
        /// </summary>
        public virtual float OilAndGasGasPrice
        {
            get { return oilAndGasGasPrice; }
            set { oilAndGasGasPrice = value; }
        }

        private string debugTimes;
        /// <summary>
        /// 调试次数
        /// </summary>
        public virtual string DebugTimes
        {
            get { return debugTimes; }
            set { debugTimes = value; }
        }

        private string debugGroup;
        /// <summary>
        /// 调试班组
        /// </summary>
        public virtual string DebugGroup
        {
            get { return debugGroup; }
            set { debugGroup = value; }
        }

        private string debugStaff;
        /// <summary>
        /// 调试人员
        /// </summary>
        public virtual string DebugStaff
        {
            get { return debugStaff; }
            set { debugStaff = value; }
        }

        private long debugTime;
        /// <summary>
        /// 调试时间
        /// </summary>
        public virtual long DebugTime
        {
            get { return debugTime; }
            set { debugTime = value; }
        }

        private string dynamic;
        /// <summary>
        /// 动力性
        /// </summary>
        public virtual string Dynamic
        {
            get { return dynamic; }
            set { dynamic = value; }
        }

        private string economy;
        /// <summary>
        /// 经济性
        /// </summary>
        public virtual string Economy
        {
            get { return economy; }
            set { economy = value; }
        }

        private int phone;
        /// <summary>
        /// 用户电话
        /// </summary>
        public virtual int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string name;
        /// <summary>
        /// 用户签字
        /// </summary>
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
