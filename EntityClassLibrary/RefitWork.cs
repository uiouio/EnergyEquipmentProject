using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace EntityClassLibrary
{
    public class RefitWork:BaseEntity
    {
        public RefitWork()
        {
            itself = this;
        }
        private RefitWork itself;
        public virtual RefitWork Itself
        {
            get { return itself; }
           
        }
        private string dispatchOrder;
        /// <summary>
        /// 派工单号
        /// </summary>
        public virtual string DispatchOrder
        {
            get { return dispatchOrder; }
            set { dispatchOrder = value; }
        }
        private UserInfo userId;
        /// <summary>
        /// 谁派的工，系统操作人
        /// </summary>
        public virtual UserInfo UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private UserInfo finalUserId;
        /// <summary>
        /// 最终修改人
        /// </summary>
        public virtual UserInfo FinalUserId
        {
            get { return finalUserId; }
            set { finalUserId = value; }
        }
        private long formulateDate;
        /// <summary>
        /// 制定日期
        /// </summary>
        public virtual long FormulateDate
        {
            get { return formulateDate; }
            set { formulateDate = value; }
        }
        private int dispatchState;
        /// <summary>
        /// 派工状态（暂存，派工，已派工，已领取）
        /// </summary>
        public virtual int DispatchState
        {
            get { return dispatchState; }
            set { dispatchState = value; }
        }
        private long dispatchTime;
        /// <summary>
        /// 派工时间
        /// </summary>
        public virtual long DispatchTime
        {
            get { return dispatchTime; }
            set { dispatchTime = value; }
        }
        private long foremanTime;
        /// <summary>
        /// 领工时间
        /// </summary>
        public virtual long ForemanTime
        {
            get { return foremanTime; }
            set { foremanTime = value; }
        }
        private String contractNo;
        /// <summary>
        /// 合同编号
        /// </summary>
        public virtual String ContractNo
        {
            get { return contractNo; }
            set { contractNo = value; }
        }
        private WorkingGroup workingGroupId;
        /// <summary>
        /// 工作组外键
        /// </summary>
        public virtual WorkingGroup WorkingGroupId
        {
            get { return workingGroupId; }
            set { workingGroupId = value; }
        }
        private CarBaseInfo carInfo;
        /// <summary>
        /// 车辆信息外键
        /// </summary>
        public virtual CarBaseInfo CarInfo
        {
            get { return carInfo; }
            set { carInfo = value; }
        }

        private ISet<RefitWorkGoods> refitWorkGoodss;

        public virtual ISet<RefitWorkGoods> RefitWorkGoodss
        {
            get { return refitWorkGoodss; }
            set { refitWorkGoodss = value; }
        }


        public enum SaveDispatchingDispatchReceive
        {
            /// <summary>
            /// 待派工
            /// </summary>
            Save = 0,
            /// <summary>
            /// 已派工
            /// </summary>
            Dispacth = 1,
            /// <summary>
            /// 已领工
            /// </summary>
            Receive = 2
        }
        public static string[] DispatchStateArray = { "待派工", "已派工", "已领工" };
    }
}
