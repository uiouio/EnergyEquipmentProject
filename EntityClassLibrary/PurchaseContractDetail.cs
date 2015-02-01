using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class PurchaseContractDetail:BaseEntity
    {
        PurchaseApplyDetail purchasePlanDetailId;
        public virtual PurchaseApplyDetail PurchasePlanDetailId
        {
            get { return purchasePlanDetailId; }
            set { purchasePlanDetailId = value; }
        }
        
        string remarks;
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        
        SupplierInfo supplierInfoId;
        public virtual SupplierInfo SupplierInfoId
        {
            get { return supplierInfoId; }
            set { supplierInfoId = value; }
        }
        
        long goodsQuanlity;
        public virtual long GoodsQuanlity
        {
            get { return goodsQuanlity; }
            set { goodsQuanlity = value; }
        }
        
        float goodsSingleAmount;
        public virtual float GoodsSingleAmount
        {
            get { return goodsSingleAmount; }
            set { goodsSingleAmount = value; }
        }


        PurchaseContract purchaseContractId;
        public virtual PurchaseContract PurchaseContractId
        {
            get { return purchaseContractId; }
            set { purchaseContractId = value; }
        }
    


    }
}
