using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public  class BrokenParts :BaseEntity
    {
        GoodsBaseInfo goodsBaseInfoId;
        public virtual GoodsBaseInfo GoodsBaseInfoId
        {
            get { return goodsBaseInfoId; }
            set { goodsBaseInfoId = value; }
        }

        long quantity;
        public virtual long Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// 库内损坏为1 库外损坏为 0
        /// </summary>
        long isBrokenInStock;
        public virtual long IsBrokenInStock
        {
            get { return isBrokenInStock; }
            set { isBrokenInStock = value; }
        }

        long brokenType;
        public virtual long BrokenType
        {
            get { return brokenType; }
            set { brokenType = value; }
        }

        string responPerson;
        public virtual string ResponPerson
        {
            get { return responPerson; }
            set { responPerson = value; }
        }

        UserInfo replyPersonId;
        public virtual UserInfo ReplyPersonId
        {
            get { return replyPersonId; }
            set { replyPersonId = value; }
        }

        long replyTime;
        public virtual long ReplyTime
        {
            get { return replyTime; }
            set { replyTime = value; }
        }

        string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public enum Broketype
        { 
            /// <summary>
            /// 日常损耗
            /// </summary>
            richangsunhuai = 1,
            /// <summary>
            /// 责任损坏
            /// </summary>
            zerensunhuai = 2,
            /// <summary>
            /// 质量损坏
            /// </summary>
            zhiliangsunhuai = 3
        }

        public static string[] BroketypeName = { "","日常损耗","责任损坏","质量损坏"};

    }
}
