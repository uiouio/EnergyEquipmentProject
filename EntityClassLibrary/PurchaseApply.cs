using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
   public class PurchaseApply:BaseEntity
    {
       
       long purchaseApplyTime;
        public virtual long PurchaseApplyTime
        {
            get { return purchaseApplyTime; }
            set { purchaseApplyTime = value; }
        }
       
        long purchaseApplyState;
        public virtual long PurchaseApplyState
        {
            get { return purchaseApplyState; }
            set { purchaseApplyState = value; }
        }

        string purchaseRemark;
        public virtual string PurchaseRemark
        {
            get { return purchaseRemark; }
            set { purchaseRemark = value; }
        }


        public enum PurApplyState
        {
            weishenhe = 0, caigoufuzerenShenhe = 1, caigoufuzerenTuihui = 2, zongjingliShenhe = 3, zongjingliTuihui = 4
        }
        public static string[] StateName = 
        {
            "等待采购负责人审核",
            "等待总经理审核",
            "采购负责人退回",
            "总经理审核通过",
            "总经理退回"
        };

       public static string[] StateColor = 
       {
           "#dd6262",
           "#df5e3f",
           "#828081",
           "#74c6a9",
           "#62767d"
       };


    }
}
