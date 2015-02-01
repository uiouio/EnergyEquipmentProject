using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EntityClassLibrary
{
    public class DeliveryModificationRecords : BaseEntity
    {
        /// <summary>
        /// 发货日期
        /// </summary>
        private long deliveryDate;

        public virtual long DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        private string deliveryRemarks;

        public virtual string DeliveryRemarks
        {
            get { return deliveryRemarks; }
            set { deliveryRemarks = value; }
        }
        private ModificationContract contractId;

        public virtual  ModificationContract ContractId
        {
            get { return contractId; }
            set { contractId = value; }
        }
        private CarBaseInfo carInfoId;

        public virtual CarBaseInfo CarInfoId
        {
            get { return carInfoId; }
            set { carInfoId = value; }
        }
    }

}
