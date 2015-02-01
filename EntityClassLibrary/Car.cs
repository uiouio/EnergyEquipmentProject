using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class Car:BaseEntity
    {
        private int modidiedType;
        public virtual int ModidiedType
        {
            get { return modidiedType; }
            set { modidiedType = value; }
        }

        private string flag;
        public virtual string Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private int carid;

        public virtual int Carid
        {
            get { return carid; }
            set { carid = value; }
        }
        private int status;

        public virtual int Status
        {
            get { return status; }
            set { status = value; }
        }

        private string remarks;
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        private int pass;
        public virtual int Pass
        {
            get { return pass; }
            set { pass = value; }
        }



        public enum CNGGas
        {
            ID = 0,
            License = 1,
            TestReport = 2,
            CNGCheck = 3,
            CylinderBracket = 4,
            CNGAssembly = 5,
            CylindersBatch=6,
            CylindersSupervision = 7
            
        }


        public enum CNGDiesel
        {
            ID=0,
            License = 1,
            TestReport = 2,
            CNGDataReview=3,
            CylinderBracket= 4,
            CNGAssembly = 5,
            CylindersBatch=6,
            CylindersSupervision=7
        }


        public enum LNGDiesel
        {
            License = 0,
            TestReport = 1,
            LNGAssembly = 2,
            QualityCertificate = 3,
            CylinderBracket = 4,
            LiquefiedNaturalGas = 5,
            CylindersSupervision = 6,
        }

        public enum CNGGasUnit
        {
            License = 0,
            BusinessLicense=1,
            OrganizationCode=2,
            ID=3,
            TestReport=4,
            CNGCheck = 5,
            CylinderBracket = 6,
            CNGAssembly = 7,
            CylindersBatch = 8,
            CylindersSupervision =9

        }

        public enum CNGDieselUnit
        {
            License = 0,
            BusinessLicense = 1,
            OrganizationCode = 2,
            ID = 3,
            TestReport = 4,
            CNGDieselCheck = 5,
            CylinderBracket = 6,
            CNGDieselAssembly = 7,
            CylindersBatch = 8,
            CylindersSupervision = 9
        }

        public enum savecheck
        {
            save=0,
            check=1
        }
    }
}
