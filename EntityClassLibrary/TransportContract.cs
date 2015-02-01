using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class TransportContract : BaseEntity
    {
        private string transportContractNum;
        public virtual string TransportContractNum
        {
            get { return transportContractNum; }
            set { transportContractNum = value; }
        }

        private string sendCategory;
        public virtual string SendCategory
        {
            get { return sendCategory; }
            set { sendCategory = value; }
        }
        
        private string receiveCategory;
        public virtual string ReceiveCategory
        {
            get { return receiveCategory; }
            set { receiveCategory = value; }
        }
        
        private string sendPlace;
        public virtual string SendPlace
        {
            get { return sendPlace; }
            set { sendPlace = value; }
        }
        
        private string receivePlace;
        public virtual string ReceivePlace
        {
            get { return receivePlace; }
            set { receivePlace = value; }
        }
        
        private string receiverName;
        public virtual string ReceiverName
        {
            get { return receiverName; }
            set { receiverName = value; }
        }
        
        private string receiverPhone;
        public virtual string ReceiverPhone
        {
            get { return receiverPhone; }
            set { receiverPhone = value; }
        }

        private string goodsNameAndNum;
        public virtual string GoodsNameAndNum
        {
            get { return goodsNameAndNum; }
            set { goodsNameAndNum = value; }
        }
        
        private string goodsWeight;
        public virtual string GoodsWeight
        {
            get { return goodsWeight; }
            set { goodsWeight = value; }
        }
        
        private string goodsVolme;
        public virtual string GoodsVolme
        {
            get { return goodsVolme; }
            set { goodsVolme = value; }
        }
        
        private long sendTime;
        public virtual long SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }
        
        private string transportMoney;
        public virtual string TransportMoney
        {
            get { return transportMoney; }
            set { transportMoney = value; }
        }
        
        private string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private long receivedTime;
        public virtual long ReceivedTime
        {
            get { return receivedTime; }
            set { receivedTime = value; }
        }
    }
}
