using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EntityClassLibrary
{
    public class JianJianInfo:BaseEntity
    {
        //private string lotNumbert;
        //public virtual string LotNumbert
        //{
        //    get { return lotNumbert; }
        //    set { lotNumbert = value; }
        //}

        //private string supervisory;
        //public virtual string Supervisory
        //{
        //    get { return supervisory; }
        //    set { supervisory = value; }
        //}

        //private long date;
        //public virtual long Date
        //{
        //    get { return date; }
        //    set { date = value; }
        //}

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

        public enum NoinspectionInspection
        {
            /// <summary>
            /// 未监检
            /// </summary>
            Noinspection=0,
            /// <summary>
            /// 已监检
            /// </summary>
            Inspection=1
        }

        private RefitWork refitWork;
        public virtual RefitWork RefitWork
        {
            get { return refitWork; }
            set { refitWork = value; }
        }

        private CarTheLibrary carTheLibrary;
        public virtual CarTheLibrary CarTheLibrary
        {
            get { return carTheLibrary; }
            set { carTheLibrary = value; }
        }

        private Batch batch;
        public virtual Batch Batch
        {
            get { return batch; }
            set { batch = value; }
        }

        //private IList<CarBaseInfo> carBaseInfo;
        //public virtual IList<CarBaseInfo> CarBaseInfo
        //{
        //    get { return carBaseInfo; }
        //    set { carBaseInfo = value; }
        //}
    }
}
