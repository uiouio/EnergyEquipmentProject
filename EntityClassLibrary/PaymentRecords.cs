using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EntityClassLibrary
{
    public class PaymentRecords:BaseEntity
    {
        /// <summary>
        /// 付款日期
        /// </summary>
        private long payMentDate;

        public virtual long PayMentDate
        {
            get { return payMentDate; }
            set { payMentDate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        private string payMentRemarks;

        public virtual string PayMentRemarks
        {
            get { return payMentRemarks; }
            set { payMentRemarks = value; }
        }
        /// <summary>
        /// 付款金额
        /// </summary>
        private float payedAmount;

        public virtual float PayedAmount
        {
            get { return payedAmount; }
            set { payedAmount = value; }
        }
        private ModificationContract contractId;

        public virtual  ModificationContract ContractId
        {
            get { return contractId; }
            set { contractId = value; }
        }

    }

}
