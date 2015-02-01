using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class CarTheLibrary:BaseEntity
    {
        private long modificationOfContractId;
        public virtual long ModificationOfContractId
        {
            get { return modificationOfContractId; }
            set { modificationOfContractId = value; }
        }

       

        private int status;
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

        private long finishTime;
        public virtual long FinishTime
        {
            get { return finishTime; }
            set { finishTime = value; }
        }


        private RefitWork refitWork;
        public virtual RefitWork RefitWork
        {
            get { return refitWork; }
            set { refitWork = value; }
        }

        private CheRuKuInfo cheRuKuInfo;
        public virtual CheRuKuInfo CheRuKuInfo
        {
            get { return cheRuKuInfo; }
            set { cheRuKuInfo = value; }
        }

    }
}
