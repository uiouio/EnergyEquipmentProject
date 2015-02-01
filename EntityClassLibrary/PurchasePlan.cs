using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
   public class PurchasePlan:BaseEntity
    {

       
        UserInfo userId;
        public virtual UserInfo UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        string purchaseRemark;
        public virtual string PurchaseRemark
        {
            get { return purchaseRemark; }
            set { purchaseRemark = value; }
        }

        string purchaseReplayRemark;
        public virtual string PurchaseReplayRemark
        {
            get { return purchaseReplayRemark; }
            set { purchaseReplayRemark = value; }
        }

        long purchaseApplyTime;
        public virtual long PurchaseApplyTime
        {
            get { return purchaseApplyTime; }
            set { purchaseApplyTime = value; }
        }

        long purchaseNeedTime;
        public virtual long PurchaseNeedTime
        {
            get { return purchaseNeedTime; }
            set { purchaseNeedTime = value; }
        }

        long purchasePlanState;
        public virtual long PurchasePlanState
        {
            get { return purchasePlanState; }
            set { purchasePlanState = value; }
        }


        PurchaseApply purchaseApplyId;
        public virtual PurchaseApply PurchaseApplyId
        {
            get { return purchaseApplyId; }
            set { purchaseApplyId = value; }
        }

        public enum purPlanState
        {
            Daichuli = 0, Bufenshengchengshenqing = 1, Quanbushenchengshenqing = 2, quanbutuihui = 3, yijingshengchengpingshen = 4
        }

        public static string[] StateName = 
        { 
            "待处理",
            "计划货物部分通过",
            "计划货物全部通过", 
            "计划货物全部退回",
            "生成申请 单号"
        };

        public static String[] StateColor = 
        {
            "#e2655f",//红色
            "#54badc",//蓝色
            "#74c6a9", //绿色
            "#828081",//灰色
            "#74c6a9" //黑色
        };
    }
}
