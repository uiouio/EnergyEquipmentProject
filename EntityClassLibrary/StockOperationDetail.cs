using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class StockOperationDetail : BaseEntity
    {

        StockOperation stockOperationId;
        public virtual StockOperation StockOperationId
        {
            get { return stockOperationId; }
            set { stockOperationId = value; }
        }


        long quantity;
        public virtual long Quantity
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

        public virtual float TheMoney
        {
            get { return theMoney; }
            set { theMoney = value; }
        }

    }
}
