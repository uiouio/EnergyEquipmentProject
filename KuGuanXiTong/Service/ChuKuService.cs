using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace KuGuanXiTong.Service
{
    class ChuKuService : BaseService
    {
        public object[] getRefitWorkByStateAndRefitNum(string workNum)
        {
            string sql = "select r from RefitWork r where r.DispatchOrder like '%" + workNum + "%' and r.DispatchOrder not in(select RetrospectListNumber from StockOperation where OperationTpye=" + (int)StockOperation.OpTypeFlag.OutByRefitWork + " and State=" + (int)BaseEntity.stateEnum.Normal + ") and r.State=" + (int)BaseEntity.stateEnum.Normal + " and r.DispatchState>=" + (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth + " order by r.DispatchState asc,r.DispatchTime DESC";
            IList refitList = this.loadEntityList(sql);
            string sql1 = "select r,s from RefitWork r,StockOperation s where r.DispatchOrder=s.RetrospectListNumber and s.OperationTpye=" + (int)StockOperation.OpTypeFlag.OutByRefitWork + " and s.State=" + (int)BaseEntity.stateEnum.Normal + " and r.DispatchOrder like '%" + workNum + "%' and r.State=" + (int)BaseEntity.stateEnum.Normal + " and r.DispatchState>=" + (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth + " order by DispatchState asc,DispatchTime DESC,OperationTime Desc";
            IList refitAndStockList = this.loadEntityList(sql1);
            object[] o = { refitList, refitAndStockList };
            return o;
        }

        public object[] getServicesByStateAndServiceNum(string serviceNum)
        {
            string sql = "select r from WeiXiuFanKuiDan r where r.RepairNumber like '%" + serviceNum + "%' and r.RepairNumber not in(select RetrospectListNumber from StockOperation where OperationTpye=" + (int)StockOperation.OpTypeFlag.OutByServices + " and State=" + (int)BaseEntity.stateEnum.Normal + ") and r.State=" + (int)BaseEntity.stateEnum.Normal + " order by r.FeedbackTime DESC";
            IList refitList = this.loadEntityList(sql);
            string sql1 = "select r,s from WeiXiuFanKuiDan r,StockOperation s where r.RepairNumber=s.RetrospectListNumber and s.OperationTpye=" + (int)StockOperation.OpTypeFlag.OutByServices + " and s.State=" + (int)BaseEntity.stateEnum.Normal + " and r.RepairNumber like '%" + serviceNum + "%' and r.State=" + (int)BaseEntity.stateEnum.Normal + " order by FeedbackTime DESC,OperationTime Desc";
            IList refitAndStockList = this.loadEntityList(sql1);
            object[] o = { refitList, refitAndStockList };
            return o;
        }

        public object[] getSuitByStateAndSuitNum(string serviceNum)
        {
            string sql = "select r from SuiteContract r where r.ContractNo like '%" + serviceNum + "%' and r.ContractNo not in(select RetrospectListNumber from StockOperation where OperationTpye=" + (int)StockOperation.OpTypeFlag.OutByTaojian + " and State=" + (int)BaseEntity.stateEnum.Normal + ") and r.State=" + (int)BaseEntity.stateEnum.Normal + " order by r.SignedDate DESC";
            IList refitList = this.loadEntityList(sql);
            string sql1 = "select r,s from SuiteContract r,StockOperation s where r.ContractNo=s.RetrospectListNumber and s.OperationTpye=" + (int)StockOperation.OpTypeFlag.OutByTaojian + " and s.State=" + (int)BaseEntity.stateEnum.Normal + " and r.ContractNo like '%" + serviceNum + "%' and r.State=" + (int)BaseEntity.stateEnum.Normal + " order by SignedDate DESC,OperationTime Desc";
            IList refitAndStockList = this.loadEntityList(sql1);
            object[] o = { refitList, refitAndStockList };
            return o;
        }

        public Stock getStockByGoodsCode(string goodsCode)
        {
            IList resultList = this.loadEntityList("from Stock where State=" + (int)BaseEntity.stateEnum.Normal + " and GoodsCode='" + goodsCode + "'");
            //if (resultList != null && resultList.Count == 1)
            //{
            //    return (Stock)resultList[0];
            //}
            if (resultList != null&&resultList.Count!=0)
            {
                return (Stock)resultList[0];
            }
            return null;
        }

        /// <summary>
        /// 根据套件合同id得到发货记录
        /// </summary>
        /// <param name="entity"></param>
        public IList GetDeliveryRecordBySuitContractId(long contractId)
        {
            string sql = " from DeliverySuiteRecords u where u.ContractId=" + contractId + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
            return this.loadEntityList(sql);
        }
        
    }
}
