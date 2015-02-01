using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
   public class PurchasePlanDetail:BaseEntity
    {
        PurchasePlan purchasePlanId;
        public virtual PurchasePlan PurchasePlanId
        {
            get { return purchasePlanId; }
            set { purchasePlanId = value; }
        }
        
        GoodsBaseInfo goodsBaseInfoId;
        public virtual GoodsBaseInfo GoodsBaseInfoId
        {
            get { return goodsBaseInfoId; }
            set { goodsBaseInfoId = value; }
        }
        
        long purchasePlanQuanlity;
        public virtual long PurchasePlanQuanlity
        {
            get { return purchasePlanQuanlity; }
            set { purchasePlanQuanlity = value; }
        }
        
        long purchasePlanDetailState;
        public virtual long PurchasePlanDetailState
        {
            get { return purchasePlanDetailState; }
            set { purchasePlanDetailState = value; }
        }

        public enum PurplanDetSta
        {
           Weichuli = 2,  Queren = 0, TuiHui = 1
        }

        public static string[] stateName =
        {
         "",
         "",
         ""
        };
    }
}
