using System;
using Iesi.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace EntityClassLibrary
{
     public  class CylinderInfo: BaseEntity
     {
         private string cylinderType;
         /// <summary>
         /// 气瓶型号
         /// </summary>
         public virtual string CylinderType
         {
             get { return cylinderType; }
             set { cylinderType = value; }
         }
         private int cylinderValue;
         /// <summary>
         /// 气瓶金额
         /// </summary>
         public virtual int CylinderValue
         {
             get { return cylinderValue; }
             set { cylinderValue = value; }
         }
         private int cylinderNumber;
         /// <summary>
         /// 气瓶数量
         /// </summary>
         public virtual int CylinderNumber
         {
             get { return cylinderNumber; }
             set { cylinderNumber = value; }
         }
         private ISet<CarBaseInfo> carBaseInfo;
         public virtual ISet<CarBaseInfo> CarBaseInfo
         {
             get { return carBaseInfo; }
             set { carBaseInfo = value; }
         }
    }
}
