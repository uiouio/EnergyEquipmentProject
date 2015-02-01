using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class ServiceGoods:BaseEntity
    {
        private string materialName;
        public virtual string MaterialName
        {
            get { return materialName; }
            set { materialName = value; }
        }

        private string material;
        public virtual string Material
        {
            get { return material; }
            set { material = value; }
        }

        private string unit;
        public virtual string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private int number;
        public virtual int Number
        {
            get { return number; }
            set { number = value; }
        }

        private GoodsBaseInfo goodsBaseInfoId;
        public virtual GoodsBaseInfo GoodsBaseInfoId
        {
            get { return goodsBaseInfoId; }
            set { goodsBaseInfoId = value; }
        }

        private WeiXiuFanKuiDan weiXiuFanKuiDanId;
        public virtual WeiXiuFanKuiDan WeiXiuFanKuiDanId
        {
            get { return weiXiuFanKuiDanId; }
            set { weiXiuFanKuiDanId = value; }
        }
       
        
    }
}
