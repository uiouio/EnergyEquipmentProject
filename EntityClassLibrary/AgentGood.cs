using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;
namespace EntityClassLibrary
{
   public  class AgentGood:BaseEntity
    {
        private int count;

        public virtual int Count
        {
            get { return count; }
            set { count = value; }
        }
        private string remarks;

        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private GoodsBaseInfo goodsBaseInfoId;
        public virtual GoodsBaseInfo GoodsBaseInfoId
        {
            get { return goodsBaseInfoId; }
            set { goodsBaseInfoId = value; }
        }
        private Agent agentId;

        public virtual Agent AgentId
        {
            get { return agentId; }
            set { agentId = value; }
        }
    }
}
