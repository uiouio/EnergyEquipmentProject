using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class GoodsBaseInfo : BaseEntity
    {
        private string goodsClassCode;
        /// <summary>
        /// 物品编码
        /// </summary>
        public virtual string GoodsClassCode
        {
            get { return goodsClassCode; }
            set { goodsClassCode = value; }
        }
        private string goodsName;
        /// <summary>
        /// 物品名称
        /// </summary>
        public virtual string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        private string specifications;
        /// <summary>
        /// 规格型号
        /// </summary>
        public virtual string Specifications
        {
            get { return specifications; }
            set { specifications = value; }
        }

        private string unit;
        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private float singleMoney;
        /// <summary>
        /// 单价
        /// </summary>
        public virtual float SingleMoney
        {
            get { return singleMoney; }
            set { singleMoney = value; }
        }

        private string material;
        /// <summary>
        /// 材质
        /// </summary>
        public virtual string Material
        {
            get { return material; }
            set { material = value; }
        }
        private long goodsParentClassId;
        /// <summary>
        /// 父节点id
        /// </summary>
        public virtual long GoodsParentClassId
        {
            get { return goodsParentClassId; }
            set { goodsParentClassId = value; }
        }
        private long goodsClassOrder;
        /// <summary>
        /// 排序
        /// </summary>
        public virtual long GoodsClassOrder
        {
            get { return goodsClassOrder; }
            set { goodsClassOrder = value; }
        }
        private long goodsClassLevel;
        /// <summary>
        /// 在树种排第几层
        /// </summary>
        public virtual long GoodsClassLevel
        {
            get { return goodsClassLevel; }
            set { goodsClassLevel = value; }
        }
        private string goodsClassDescribe;
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string GoodsClassDescribe
        {
            get { return goodsClassDescribe; }
            set { goodsClassDescribe = value; }
        }
        private int goodsFlag;
        /// <summary>
        /// 货物标识
        /// </summary>
        public virtual int GoodsFlag
        {
            get { return goodsFlag; }
            set { goodsFlag = value; }
        }


        private int isUniqueCode;
        /// <summary>
        /// 是否需要唯一编码
        /// </summary>
        public virtual int IsUniqueCode
        {
            get { return isUniqueCode; }
            set { isUniqueCode = value; }
        }



        
         private long waringNum;
        /// <summary>
        /// 预警数量
        /// </summary>
         public virtual long WaringNum
        {
            get { return waringNum; }
            set { waringNum = value; }
        }

         private int isWaring;
        /// <summary>
        /// 是否需要预警
        /// </summary>
         public virtual int IsWaring
        {
            get { return isWaring; }
            set { isWaring = value; }
        }
        


        #region 枚举变量

        public enum TheGoodsFlag
        {
            /// <summary>
            /// 类别
            /// </summary>
            categtory = 1, 
            /// <summary>
            /// 货物
            /// </summary>
            goods = 2,
            /// <summary>
            /// 套件
            /// </summary>
            Taojian = 3

        }
        #endregion
    }
}
