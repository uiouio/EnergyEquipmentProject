using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class WaitChooseSuppliers:BaseEntity
    {
        SupplierInfo supplierInfoId;

        public  virtual SupplierInfo SupplierInfoId
        {
            get { return supplierInfoId; }
            set { supplierInfoId = value; }
        }

        PurchaseApplyDetail purchaseApplyDetailId;
        public virtual PurchaseApplyDetail PurchaseApplyDetailId
        {
            get { return purchaseApplyDetailId; }
            set { purchaseApplyDetailId = value; }
        }

        long isAdvise;
        public virtual long IsAdvise
        {
            get { return isAdvise; }
            set { isAdvise = value; }
        }

        float money;

        public virtual float Money
        {
            get { return money; }
            set { money = value; }
        }
        
    }
}
