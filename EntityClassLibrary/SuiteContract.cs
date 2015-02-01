using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace EntityClassLibrary
{
   public class SuiteContract:BaseEntity
    {
       /// <summary>
       /// 合同金额
       /// </summary>
        private float contractAmount;
        public virtual float ContractAmount
        {
            get { return contractAmount; }
            set { contractAmount = value; }
        }
       /// <summary>
       /// 付款方式
       /// </summary>
        private string paymentMethod;
        public virtual string  PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }
       /// <summary>
       /// 付款状态
       /// </summary>
        private int paymentState;

        public virtual int PaymentState
        {
            get { return paymentState; }
            set { paymentState = value; }
        }
       /// <summary>
       /// 合同内容
       /// </summary>
        private string contractContents;
        public virtual string ContractContents
        {
            get { return contractContents; }
            set { contractContents = value; }
        }
       /// <summary>
       /// 备注
       /// </summary>
        private string remarks;
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
       /// <summary>
       /// 签订日期
       /// </summary>
        private long signedDate;
        public virtual long SignedDate
        {
            get { return signedDate; }
            set { signedDate = value; }
        }
       /// <summary>
       ///合同方式
       /// </summary>
        private long contractMode;
        public virtual long ContractMode
        {
            get { return contractMode; }
            set { contractMode = value; }
        }
       /// <summary>
       /// 合同编号
       /// </summary>
        private string contractNo;
        public virtual string ContractNo
        {
            get { return contractNo; }
            set { contractNo = value; }
        }
       /// <summary>
       /// 经办人
       /// </summary>
        private UserInfo userID;
        public virtual UserInfo UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private int deliveryStatus;

        public virtual int DeliveryStatus
        {
            get { return deliveryStatus; }
            set { deliveryStatus = value; }
        }
        private int pass;

        public virtual int Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        private int process;

        public virtual int Process
        {
            get { return process; }
            set { process = value; }
        }
        private int approvalState;

        public virtual int ApprovalState
        {
            get { return approvalState; }
            set { approvalState = value; }
        }
        private string salesResponsiblePersonOpinion;

        public virtual string SalesResponsiblePersonOpinion
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
       /// <summary>
       /// 乙方
       /// </summary>
        private CustomBaseInfo customBaseID;

        public virtual CustomBaseInfo CustomBaseID
        {
            get { return customBaseID; }
            set { customBaseID = value; }
        }
        private ISet<SuiteContractGoods> suiteContractGoods;

        public virtual ISet<SuiteContractGoods> SuiteContractGoods
        {
            get { return suiteContractGoods; }
            set { suiteContractGoods = value; }
        }
       /// <summary>
       /// 合同方式
       /// </summary>
        public enum Type
        {
            duinei = 0, duiwai = 1
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
            pass = 0, unpass = 1

        }
        /// <summary>
        /// 审批状态
        /// </summary>
        public enum Approval
        {
            already = 0, yet = 1
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
        public static string[] PayMethodArray = { "全款", "分期" };
        public static string[] PaymentStateArray = { "未付款", "已付部分", "已付清" };
        public static string[] DeliveryStatusArray = { "未发货", "已发部分", "已发完" };
        public static string[] ApprovalStateArray = { "已审批", "未审批" };
        public static string[] PassStateArray = { "通过", "未通过" };
        public static string[] ProcessArray = { "销售负责人", "总会计师", "总经理", "合同保管员" };
    }
}
