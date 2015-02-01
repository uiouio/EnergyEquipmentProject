using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace EntityClassLibrary
{
   public class WeiXiuFanKuiDan:BaseEntity
    {
        private long modificationOfContractId;
        public virtual long ModificationOfContractId
        {
             get { return modificationOfContractId; }
             set { modificationOfContractId = value; }
        }

        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string licensePlateNumber;
        public virtual string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            set { licensePlateNumber = value; }
        }

        private string models;
        public virtual string Models
        {
            get { return models; }
            set { models = value; }
        }

        private long feedbackTime;
        public virtual long FeedbackTime
        {
            get { return feedbackTime; }
            set { feedbackTime = value; }
        }
       

        private string feedbackForm;
        public virtual string FeedbackForm
        {
            get { return feedbackForm; }
            set { feedbackForm = value; }
        }

        private string telephoneNumber;
        public virtual string TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }

        private string serviceNumber;
        public virtual string ServiceNumber
        {
            get { return serviceNumber; }
            set { serviceNumber = value; }
        }


        private int payment;
        public virtual int Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        private float money;
        public virtual float Money
        {
            get { return money; }
            set { money = value; }
        }

        private string qualityProblems;
        public virtual string QualityProblems
        {
            get { return qualityProblems; }
            set { qualityProblems = value; }
        }

        private string servicePerson;
        public virtual string ServicePerson
        {
            get { return servicePerson; }
            set { servicePerson = value; }
        }

        private string remarks;
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        private string repairNumber;
        public virtual string RepairNumber
        {
            get { return repairNumber; }
            set { repairNumber = value; }
        }


        private ISet<ServiceGoods> serviceGoods;
        public virtual ISet<ServiceGoods> ServiceGoods
        {
            get { return serviceGoods; }
            set { serviceGoods = value; }
        }


    }
}
