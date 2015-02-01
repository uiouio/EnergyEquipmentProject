using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class TiaoShiBaoGao : BaseEntity

    {
        private long carBaseInfoId;
        public virtual long CarBaseInfoId
        {
            get { return carBaseInfoId; }
            set { carBaseInfoId = value; }
        }


        private string debugPerson;
        public virtual string DebugPerson
        {
            get { return debugPerson; }
            set { debugPerson = value; }
        }


        private float singleFirewoodOilyFees;
        public virtual float SingleFirewoodOilyFees
        {
            get { return singleFirewoodOilyFees; }
            set { singleFirewoodOilyFees = value; }
        }



        private float singleFirewoodOilyTotalFees;
        public virtual float SingleFirewoodOilyTotalFees
        {
            get { return singleFirewoodOilyTotalFees; }
            set { singleFirewoodOilyTotalFees = value; }
        }




        private float singleFirewoodOilyAverageFees;
        public virtual float SingleFirewoodOilyAverageFees
        {
            get { return singleFirewoodOilyAverageFees; }
            set { singleFirewoodOilyAverageFees = value; }
        }




        private float oilAndGasGasFees;
        public virtual float OilAndGasGasFees
        {
            get { return oilAndGasGasFees; }
            set { oilAndGasGasFees = value; }
        }




        private float oilAndGasOilFees;
        public virtual float OilAndGasOilFees
        {
            get { return oilAndGasOilFees; }
            set { oilAndGasOilFees = value; }
        }


        private float oilAndGasTotalFees;
        public virtual float OilAndGasTotalFees
        {
            get { return oilAndGasTotalFees; }
            set { oilAndGasTotalFees = value; }
        }


        private float oilAndGasAverageFees;
        public virtual float OilAndGasAverageFees
        {
            get { return oilAndGasAverageFees; }
            set { oilAndGasAverageFees = value; }
        }



        private float oilAndGasSave;
        public virtual float OilAndGasSave
        {
            get { return oilAndGasSave; }
            set { oilAndGasSave = value; }
        }

        private float dieselfuel;
        public virtual float Dieselfuel
        {
            get { return dieselfuel; }
            set { dieselfuel = value; }
        }


        private float dieselPrices;
        public virtual float DieselPrices
        {
            get { return dieselPrices; }
            set { dieselPrices = value; }
        }



        private float cNGPrices;
        public virtual float CNGPrices
        {
            get { return cNGPrices; }
            set { cNGPrices = value; }
        }

       

        private string dynamic;

        public virtual string Dynamic
        {
            get { return dynamic; }
            set { dynamic = value; }
        }


        private string issue;

        public virtual string Issue
        {
            get { return issue; }
            set { issue = value; }
        }


        private int status;
        /// <summary>
        /// 状态，未调试，已调试
        /// </summary>
        public virtual int Status
        {
            get { return status; }
            set { status = value; }
        }

        public enum savecheck
        {
            save=0,
            check=1
        }


        private long debugDate;
        public virtual long DebugDate
        {
            get { return debugDate; }
            set { debugDate = value; }
        }



        private long time;
        public virtual long Time
        {
            get { return time; }
            set { time = value; }
        }

       
        private float mileage;

        public virtual float Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        private float singleDiesekm;

        public virtual float SingleDiesekm
        {
            get { return singleDiesekm; }
            set { singleDiesekm = value; }
        }

        private float oilAndGaskm;

        public virtual float OilAndGaskm
        {
            get { return oilAndGaskm; }
            set { oilAndGaskm = value; }
        }

        private string drivingDirections;

        public virtual string DrivingDirections
        {
            get { return drivingDirections; }
            set { drivingDirections = value; }
        }

        private LiuZhuanBiao liuZhuanBiao;
        public virtual LiuZhuanBiao LiuZhuanBiao
        {
            get { return liuZhuanBiao; }
            set { liuZhuanBiao = value; }
        }     


    }
}
