using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace EntityClassLibrary
{
    public class Agent : BaseEntity
    {
        private string agentName;

        public virtual string AgentName
        {
            get { return agentName; }
            set { agentName = value; }
        }
        /// <summary>
        /// 加盟商类型
        /// </summary>
        private string category;

        public virtual string Category
        {
            get { return category; }
            set { category = value; }
        }
        /// <summary>
        /// 受理时间
        /// </summary>
        private long acceptTime;

        public virtual long AcceptTime
        {
            get { return acceptTime; }
            set { acceptTime = value; }
        }
        /// <summary>
        /// 代理区域
        /// </summary>
        private   string agentAera;

        public virtual string AgentAera
        {
            get { return agentAera; }
            set { agentAera = value; }
        }
        /// <summary>
        /// 代理金额
        /// </summary>
        private string agentMoney;

        public virtual  string AgentMoney
        {
            get { return agentMoney; }
            set { agentMoney = value; }
        }
        /// <summary>
        /// 代理内容
        /// </summary>
        private string agentContent;

        public virtual string AgentContent
        {
            get { return agentContent; }
            set { agentContent = value; }
        }
        /// <summary>
        /// 代理期限
        /// </summary>
        private long agentDeadline;

        public virtual long AgentDeadline
        {
            get { return agentDeadline; }
            set { agentDeadline = value; }
        }
        private long agentStartline;

        public virtual long AgentStartline
        {
            get { return agentStartline; }
            set { agentStartline = value; }
        }
        private int minimumSale;

        public virtual int MinimumSale
        {
            get { return minimumSale; }
            set { minimumSale = value; }
        }
        /// <summary>
        /// 计划标志
        /// </summary>
        private int planFlag;

        public virtual int PlanFlag
        {
            get { return planFlag; }
            set { planFlag = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        private string contactName;

        public virtual string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }
        /// <summary>
        /// 代理人性别
        /// </summary>
        private string personSex;

        public virtual string PersonSex
        {
            get { return personSex; }
            set { personSex = value; }
        }
       /// <summary>
       /// 联系电话
       /// </summary>
        private string contactPhone;

        public virtual  string ContactPhone
        {
            get { return contactPhone; }
            set { contactPhone = value; }
        }
        /// <summary>
        /// 联系Email
        /// </summary>
        private string contactEmail;

        public virtual string ContactEmail
        {
            get { return contactEmail; }
            set { contactEmail = value; }
        }
        /// <summary>
        /// 联系邮编
        /// </summary>
        private string contactPostCode;

        public virtual string ContactPostCode
        {
            get { return contactPostCode; }
            set { contactPostCode = value; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        private string contactAddress;

        public virtual string ContactAddress
        {
            get { return contactAddress; }
            set { contactAddress = value; }
        }
        /// <summary>
        /// 发货地址
        /// </summary>
        private string deliveryAddress;

        public virtual string DeliveryAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }
        /// <summary>
        /// 发货时间
        /// </summary>
        private long  deliveryTime;

        public virtual long  DeliveryTime
        {
            get { return deliveryTime; }
            set { deliveryTime = value; }
        }
        /// <summary>
        /// 发货形式
        /// </summary>
        private string deliveryForm;

        public virtual string DeliveryForm
        {
            get { return deliveryForm; }
            set { deliveryForm = value; }
        }
        private string deliveryAera;

        public virtual string DeliveryAera
        {
            get { return deliveryAera; }
            set { deliveryAera = value; }
        }
        /// <summary>
        /// 进度
        /// </summary>
        private string progess;

        public virtual string Progess
        {
            get { return progess; }
            set { progess = value; }
        }
        private ISet<AgentGood> agentGoodBaseInfo;
        public virtual ISet<AgentGood> AgentGoodBaseInfo
        {
            get { return agentGoodBaseInfo; }
            set { agentGoodBaseInfo = value; }
        }
        public enum chehaveplan
        {
            No=0,Yes=1
        }


    }
}
