using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
     public class CustomerServiceRecord:BaseEntity
     {

         

         private DateTime phoneTime;
        /// <summary>
        /// 电话回访时间
        /// </summary>
        public virtual DateTime PhoneTime
        {
            get { return phoneTime; }
            set { phoneTime = value; }
        }
        private string phoneWorker;
        /// <summary>
        /// 接线员
        /// </summary>
        public virtual string PhoneWorker
        {
            get { return phoneWorker; }
            set { phoneWorker = value; }
        }

        private string question;
        /// <summary>
        /// 问题
        /// </summary>
        public virtual string Question
        {
            get { return question; }
            set { question = value; }
        }

        private string handleOpinion;
        /// <summary>
        /// 处理意见
        /// </summary>
        public virtual string HandleOpinion
        {
            get { return handleOpinion; }
            set { handleOpinion = value; }
        }

        private string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private CarBaseInfo carInfo;

        public virtual CarBaseInfo CarInfo
        {
            get { return carInfo; }
            set { carInfo = value; }
        }
       
        
    }
}


