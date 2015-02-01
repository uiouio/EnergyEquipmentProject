using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class GoodsBaseInfo : BaseEntity
    {
        private string goodsClassCode;
        public virtual string GoodsClassCode
        {
            get { return goodsClassCode; }
            set { goodsClassCode = value; }
        }
        private string goodsName;
        public virtual string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        private string specifications;
        public virtual string Specifications
        {
            get { return specifications; }
            set { specifications = value; }
        }

        private string unit;
        public virtual string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private float singleMoney;

        public virtual float SingleMoney
        {
            get { return singleMoney; }
            set { singleMoney = value; }
        }

        private string material;
        public virtual string Material
        {
            get { return material; }
            set { material = value; }
        }
        private long goodsParentClassId;
        public virtual long GoodsParentClassId
        {
            get { return goodsParentClassId; }
            set { goodsParentClassId = value; }
        }
        private long goodsClassOrder;
        public virtual long GoodsClassOrder
        {
            get { return goodsClassOrder; }
            set { goodsClassOrder = value; }
        }
        private long goodsClassLevel;
        public virtual long GoodsClassLevel
        {
            get { return goodsClassLevel; }
            set { goodsClassLevel = value; }
        }
        private string goodsClassDescribe;
        public virtual string GoodsClassDescribe
        {
            get { return goodsClassDescribe; }
            set { goodsClassDescribe = value; }
        }
        private int goodsFlag;
        public virtual int GoodsFlag
        {
            get { return goodsFlag; }
            set { goodsFlag = value; }
        }


        private int isUniqueCode;
        public virtual int IsUniqueCode
        {
            get { return isUniqueCode; }
            set { isUniqueCode = value; }
        }



        
         private long waringNum;
         public virtual long WaringNum
        {
            get { return waringNum; }
            set { waringNum = value; }
        }

         private int isWaring;
         public virtual int IsWaring
        {
            get { return isWaring; }
            set { isWaring = value; }
        }
        


        #region 枚举变量

        public enum TheGoodsFlag
        {
            categtory = 1, goods = 2, Taojian = 3

        }
        #endregion
    }
}
