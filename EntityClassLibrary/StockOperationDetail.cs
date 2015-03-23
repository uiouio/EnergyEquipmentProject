using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class StockOperationDetail : BaseEntity
    {

        StockOperation stockOperationId;
        /// <summary>
        /// 操作单号
        /// </summary>
        public virtual StockOperation StockOperationId
        {
            get { return stockOperationId; }
            set { stockOperationId = value; }
        }


        float quantity;
        /// <summary>
        /// 操作数量
        /// </summary>
        public virtual float Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        string goodsCode;
        public virtual string GoodsCode
        {
            get { return goodsCode; }
            set { goodsCode = value; }
        }

        Stock stockId;
        public virtual Stock StockId
        {
            get { return stockId; }
            set { stockId = value; }
        }

        float theMoney;
        /// <summary>
        /// 税前的单价
        /// </summary>
        public virtual float TheMoney
        {
            get { return theMoney; }
            set { theMoney = value; }
        }

        float tax;
        /// <summary>
        /// 稅
        /// </summary>
        public virtual float Tax
        {
            get { return tax; }
            set { tax = value; }
        }

    }
}
