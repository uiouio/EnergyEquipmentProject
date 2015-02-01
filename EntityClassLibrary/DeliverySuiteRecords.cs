using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EntityClassLibrary
{
    public class DeliverySuiteRecords : BaseEntity
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
        /// 发货数量
        /// </summary>
        private int deliverycount;

        public virtual int Deliverycount
        {
            get { return deliverycount; }
            set { deliverycount = value; }
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
        private SuiteContract contractId;

        public virtual  SuiteContract ContractId
        {
            get { return contractId; }
            set { contractId = value; }
        }
        private GoodsBaseInfo goodsInfoId;

        public virtual GoodsBaseInfo GoodsInfoId
        {
            get { return goodsInfoId; }
            set { goodsInfoId = value; }
        }
    }

}
