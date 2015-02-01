using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class RefitWorkModelGoods : BaseEntity 
    {
        private int count;
        public virtual int Count
        {
            get { return count; }
            set { count = value; }
        }
        private GoodsBaseInfo goodsBaseInfoId;
        public virtual GoodsBaseInfo GoodsBaseInfoId
        {
            get { return goodsBaseInfoId; }
            set { goodsBaseInfoId = value; }
        }
        private RefitWorkModel refitWorkId;
        public virtual RefitWorkModel RefitWorkId
        {
            get { return refitWorkId; }
            set { refitWorkId = value; }
        }
        private string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
