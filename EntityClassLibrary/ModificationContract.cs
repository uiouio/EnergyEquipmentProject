using System;
using Iesi.Collections.Generic;

namespace EntityClassLibrary
{
    public  class ModificationContract:BaseEntity
    {
        public ModificationContract()
        {
            itself = this;
        }
        private ModificationContract itself;
        public virtual ModificationContract Itself
        {
            get { return itself; }

        }
        private float contractAmount;

        public  virtual  float ContractAmount
        {
            get { return contractAmount; }
            set { contractAmount = value; }
        }
        private string paymentMethod;

        public virtual string PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }
        private string contractContents;

        public virtual string ContractContents
        {
            get { return contractContents; }
            set { contractContents = value; }
        }
        private string remarks;

        public virtual  string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private long signedDate;

        public virtual  long SignedDate
        {
            get { return signedDate; }
            set { signedDate = value; }
        }
        private int signedState;

        public virtual int SignedState
        {
            get { return signedState; }
            set { signedState = value; }
        }
        private int paymentState;

        public virtual  int PaymentState
        {
            get { return paymentState; }
            set { paymentState = value; }
        }
        private string contractNo;

        public virtual  string ContractNo
        {
            get { return contractNo; }
            set { contractNo = value; }
        }
        private int contractMethod;

        public virtual int ContractMethod
        {
            get { return contractMethod; }
            set { contractMethod = value; }
        }
        private int approvalState;

        public virtual int ApprovalState
        {
            get { return approvalState; }
            set { approvalState = value; }
        }
       
        private long approvalTime;

        public virtual long ApprovalTime
        {
            get { return approvalTime; }
            set { approvalTime = value; }
        }

        private int pass;

        public virtual int Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        private int process;

        public virtual  int Process
        {
            get { return process; }
            set { process = value; }
        }
        private int deliveryStatus;

        public virtual int DeliveryStatus
        {
            get { return deliveryStatus; }
            set { deliveryStatus = value; }
        }
        private string salesResponsiblePersonOpinion;

        public virtual  string SalesResponsiblePersonOpinion
        {
            get { return salesResponsiblePersonOpinion; }
            set { salesResponsiblePersonOpinion = value; }
        }

        private string chiefAccountantOpinion;

        public virtual string ChiefAccountantOpinion
        {
            get { return chiefAccountantOpinion; }
            set { chiefAccountantOpinion = value; }
        }


        private string generalManagerOpinion;

        public virtual string GeneralManagerOpinion
        {
            get { return generalManagerOpinion; }
            set { generalManagerOpinion = value; }
        }
        private UserInfo userID;

        public virtual UserInfo UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private ISet<CarBaseInfo> carBaseInfoID;

        public virtual ISet<CarBaseInfo> CarBaseInfoID
        {
            get { return carBaseInfoID; }
            set { carBaseInfoID = value; }
        }
        #region 枚举变量
        public enum Type
        {
            duinei = 0,
            
            duiwai = 1
        }
        public enum guocheng
        {
            
            /// <summary>
            /// 销售负责人
            /// </summary>
            xsfzr = 0, 
            /// <summary>
            /// 会计师
            /// </summary>
            kjs = 1,
            /// <summary>
            /// 总经理
            /// </summary>
            zjl = 2,
            /// <summary>
            /// 合同保管员
            /// </summary>
            htbgy = 3
        }
        public enum PassorNot
        {
            pass=0,unpass=1

        }
        /// <summary>
        /// 审批状态
        /// </summary>
        public enum Approval  
        {
            already=0,yet=1
        }
        public enum CNGGasCNGDieselLNGDiesel
        {
            CNGGas = 0,
            CNGDiesel = 1,
            LNGDiesel = 2
        }
        

         public enum PaymentStateEnum
         {
             /// <summary>
             /// 未付款
             /// </summary>
             None = 0,
             /// <summary>
             /// 已付部分
             /// </summary>
             Partial = 1,
             /// <summary>
             /// 已付清
             /// </summary>
             All = 2
         }
         public enum DeliveryStatusEnum
         {
             /// <summary>
             /// 未发货
             /// </summary>
             None = 0,
             /// <summary>
             /// 已发部分
             /// </summary>
             Partial = 1,
             /// <summary>
             /// 已发货
             /// </summary>
             All = 2
         }
        #endregion
         public static string[] PaymentStateArray = { "未付款", "已付部分", "已付清" };
         public static string[] DeliveryStatusArray = { "未发货", "已发部分", "已发完" };
         public static string[] ApprovalStateArray = { "已审批", "未审批" };
         public static string[] ModifyType = { "CNG汽油", "CNG柴油", "LNG柴油" };
         public static string[] PassStateArray = { "通过", "未通过" };
         public static string[] ProcessArray = { "销售负责人", "总会计师","总经理","合同保管员" };
    }
}
