using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
   public class Stock :BaseEntity
    {
        private GoodsBaseInfo goodsBaseInfoID;
        public virtual GoodsBaseInfo GoodsBaseInfoID
        {
            get { return goodsBaseInfoID; }
            set { goodsBaseInfoID = value; }
        }

        private float money;
        public virtual float Money
        {
            get { return money; }
            set { money = value; }
        }
       
        private long quantity;
        public virtual long Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        
        private string goodsCode;
        public virtual string GoodsCode
        {
            get { return goodsCode; }
            set { goodsCode = value; }
        }
        
        private long storehouseplaceCode;
        public virtual long StorehouseplaceCode
        {
            get { return storehouseplaceCode; }
            set { storehouseplaceCode = value; }
        }

    }
}
