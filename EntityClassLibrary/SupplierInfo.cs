using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class SupplierInfo:BaseEntity
    {
        public SupplierInfo()
        {
            this.itself = this;
        }
        private string supplierName;
        public virtual string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }

        private string supplierAddress;
        public virtual string SupplierAddress
        {
            get { return supplierAddress; }
            set { supplierAddress = value; }
        }

        private string supplierContactMan;
        public virtual  string SupplierContactMan
        {
            get { return supplierContactMan; }
            set { supplierContactMan = value; }
        }

        private string supplierPhone;
        public virtual string SupplierPhone
        {
            get { return supplierPhone; }
            set { supplierPhone = value; }
        }

        private string supplierSex;
        public virtual string SupplierSex
        {
            get { return supplierSex; }
            set { supplierSex = value; }
        }

        private string supplierZioCode;
        public virtual string SupplierZioCode
        {
            get { return supplierZioCode; }
            set { supplierZioCode = value; }
        }

        private string supplierContactManMail;
        public virtual string SupplierContactManMail
        {
            get { return supplierContactManMail; }
            set { supplierContactManMail = value; }
        }

        private SupplierInfo itself;
        public virtual SupplierInfo Itself
        {
            get { return itself; }
        }
        private string remark;

        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

       
    }
}
