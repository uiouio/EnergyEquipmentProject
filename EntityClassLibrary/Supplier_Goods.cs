using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class Supplier_Goods:BaseEntity
    {
        GoodsBaseInfo goodsBaseInfoID;
        public virtual GoodsBaseInfo GoodsBaseInfoID
        {
            get { return goodsBaseInfoID; }
            set { goodsBaseInfoID = value; }
        }

        SupplierInfo supplierInfoId;
        public virtual SupplierInfo SupplierInfoId
        {
            get { return supplierInfoId; }
            set { supplierInfoId = value; }
        }


        float unit_Price;
        public virtual float Unit_Price
        {
            get { return unit_Price; }
            set { unit_Price = value; }
        }

        long date;
        public virtual long Date  
        {
            get { return date; }
            set { date = value; }
        }

    }
}
