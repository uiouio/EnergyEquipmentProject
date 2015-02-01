using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace HeTongGuanLi.Service
{
    class DeliveryService : BaseService
    {
        /// <summary>
        /// 根据改装合同id得到发货记录
        /// </summary>
        /// <param name="entity"></param>
        public IList GetDeliveryRecordByModuficationContractId(long contractId)
        {
            string sql = " from DeliveryModificationRecords u where u.ContractId=" + contractId + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
            return this.loadEntityList(sql);
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
