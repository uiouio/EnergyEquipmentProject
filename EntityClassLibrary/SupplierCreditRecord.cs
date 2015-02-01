using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class SupplierCreditRecord:BaseEntity
    {
        
        string remarks;
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        
        long supplierCreditRecordTime;
        public virtual long SupplierCreditRecordTime
        {
            get { return supplierCreditRecordTime; }
            set { supplierCreditRecordTime = value; }
        }
        
        UserInfo userId;
        public virtual UserInfo UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        
        SupplierInfo supplierInfoId;
        public virtual SupplierInfo SupplierInfoId
        {
            get { return supplierInfoId; }
            set { supplierInfoId = value; }
        }

    }
}
