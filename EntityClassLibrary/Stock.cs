using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
   public class Stock :BaseEntity
    {
        private GoodsBaseInfo goodsBaseInfoID;
        /// <summary>
        /// 货物类别ID
        /// </summary>
        public virtual GoodsBaseInfo GoodsBaseInfoID
        {
            get { return goodsBaseInfoID; }
            set { goodsBaseInfoID = value; }
        }

        private float money;
        /// <summary>
        /// 金钱
        /// </summary>
        public virtual float Money
        {
            get { return money; }
            set { money = value; }
        }
       
        private float quantity;
        /// <summary>
        /// 数量
        /// </summary>
        public virtual float Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        
        private string goodsCode;
        /// <summary>
        /// 物品条码
        /// </summary>
        public virtual string GoodsCode
        {
            get { return goodsCode; }
            set { goodsCode = value; }
        }
        
        private long storehouseplaceCode;
        /// <summary>
        /// 库位号
        /// </summary>
        public virtual long StorehouseplaceCode
        {
            get { return storehouseplaceCode; }
            set { storehouseplaceCode = value; }
        }

    }
}
