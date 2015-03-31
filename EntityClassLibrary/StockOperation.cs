using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class StockOperation : BaseEntity
    {
        long operationTpye;
        public virtual long OperationTpye
        {
            get { return operationTpye; }
            set { operationTpye = value; }
        }

        long iOFlag;
        public virtual long IOFlag
        {
            get { return iOFlag; }
            set { iOFlag = value; }
        }

        long operationTime;
        public virtual long OperationTime
        {
            get { return operationTime; }
            set { operationTime = value; }
        }

        UserInfo userId;
        public virtual UserInfo UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        string retrospectListNumber;
        public virtual string RetrospectListNumber
        {
            get { return retrospectListNumber; }
            set { retrospectListNumber = value; }
        }
        
        string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private SupplierInfo supplierInfoId;
        public virtual SupplierInfo SupplierInfoId
        {
            get { return supplierInfoId; }
            set { supplierInfoId = value; }
        }

        private IList<StockOperationDetail> operationDetails;

        public virtual IList<StockOperationDetail> OperationDetails
        {
            get { return operationDetails; }
            set { operationDetails = value; }
        }

        private int isCanChange;
        /// <summary>
        /// 1=〉可以修改 0=〉不可以修改
        /// </summary>
        public virtual int IsCanChange
        {
            get { return isCanChange; }
            set { isCanChange = value; }
        }

        #region 枚举变量
        public enum InOrOutFlag
        {
            In = 0, Out = 1
        }
        #endregion

        #region
        public enum OpTypeFlag
        {
            InByStream = 0,
            OutByRefitWork=1,
            OutByServices = 2,
            OutByTaojian = 3,
            OutByBrokenParts = 4
        }
        #endregion

        public static string[] OpType = { "物流入库", "派工出库", "维修出库", "套件出库" ,"坏件出库"};
        

    }
}
