using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class SuitContractGoods : BaseEntity
    {
        private int receiveType;
        public virtual int ReceiveType
        {
            get { return receiveType; }
            set { receiveType = value; }
        }
        private int count;
        public virtual int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int addType;
        public virtual int AddType
        {
            get { return addType; }
            set { addType = value; }
        }

        private GoodsBaseInfo goodsBaseInfoId;
        public virtual GoodsBaseInfo GoodsBaseInfoId
        {
            get { return goodsBaseInfoId; }
            set { goodsBaseInfoId = value; }
        }

        private SuiteContract suiteContractId;

        public virtual SuiteContract SuiteContractId
        {
            get { return suiteContractId; }
            set { suiteContractId = value; }
        }

        private string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
