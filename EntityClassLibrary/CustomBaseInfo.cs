using System;
using Iesi.Collections.Generic;

namespace EntityClassLibrary
{
    public class CustomBaseInfo : BaseEntity
    {
        private string name;
        /// <summary>
        /// 个人时是姓名，企业时是企业名称
        /// </summary>
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string sex;
        /// <summary>
        /// 数据库中存储的为：男、女
        /// </summary>
        public virtual string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string identifyCardNo;
        /// <summary>
        /// 个人是身份证，企业是组织机构代码
        /// </summary>
        public virtual string IdentifyCardNo
        {
            get { return identifyCardNo; }
            set { identifyCardNo = value; }
        }
        private string phone;
        /// <summary>
        /// 个人是固话，企业是公司电话固话
        /// </summary>
        public virtual string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string telephone;
        /// <summary>
        /// 个人时是手机号，企业时是联系人电话
        /// </summary>
        public virtual string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        private string qQ;
        public virtual string QQ
        {
            get { return qQ; }
            set { qQ = value; }
        }
        private string unit;
        /// <summary>
        /// 个人时是单位,企业时没有
        /// </summary>
        public virtual  string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private string email;
        /// <summary>
        /// 企业是没有
        /// </summary>
        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string address;
        public virtual string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string postcode;
        /// <summary>
        /// 邮编
        /// </summary>
        public virtual string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        private long registrationTime;
        /// <summary>
        /// 注册时间
        /// </summary>
        public virtual long RegistrationTime
        {
            get { return registrationTime; }
            set { registrationTime = value; }
        }
        private string addressCode;
        /// <summary>
        /// 地址代码
        /// </summary>
        public virtual string AddressCode
        {
            get { return addressCode; }
            set { addressCode = value; }
        }
        private string remarks;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private string photoPath;
        /// <summary>
        /// 照片路径
        /// </summary>
        public virtual string PhotoPath
        {
            get { return photoPath; }
            set { photoPath = value; }
        }
        private string customlevel;
        /// <summary>
        /// 客户级别
        /// </summary>
        public virtual string CustomLevel
        {
            get { return customlevel; }
            set { customlevel = value; }
        }
        private string contactName;
        /// <summary>
        /// 企业时是联系人姓名，个人时没有
        /// </summary>
        public virtual string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }
        private string comanySize;
        /// <summary>
        /// 企业时是企业规模，个人时没有
        /// </summary>
        public virtual string ComanySize
        {
            get { return comanySize; }
            set { comanySize = value; }
        }
        private string  comanyProperty;
        /// <summary>
        /// 企业时是企业性质，个人时没有
        /// </summary>
        public virtual string  ComanyProperty
        {
            get { return comanyProperty; }
            set { comanyProperty = value; }
        }
        private int status;
        /// <summary>
        /// 标志是企业还是个人客户
        /// </summary>
        public virtual int Status
        {
            get { return status; }
            set { status = value; }
        }
        private int category;
        /// <summary>
        /// 意向客户还是正式客户，0是正式客户，1是意向客户
        /// </summary>
        public virtual int Category
        {
            get { return category; }
            set { category = value; }
        }
        private UserInfo userID;

        public virtual UserInfo UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// 客户状态
        /// </summary>
        public enum kehuleibie

        {
            /// <summary>
            /// 正式客户
            /// </summary>
            zhenshikehu = 1,
            /// <summary>
            /// 意向客户
            /// </summary>
            yixiangkehu = 0
        }
        public enum PersonalOrCompany
        {
            /// <summary>
            /// 个人客户
            /// </summary>
            Personal= 0,
            /// <summary>
            /// 企业客户
            /// </summary>
            Company = 1
        }
        /// <summary>
        /// 车内物品确认
        /// </summary>
        public  enum FunctionAndGoods
        {
            /// <summary>
            /// 天窗
            /// </summary>
            TianChuang,
            /// <summary>
            /// 点烟器
            /// </summary>
            DianYan,
            /// <summary>
            /// 座椅
            /// </summary>
            ZuoYi,
            /// <summary>
            /// 防盗装置
            /// </summary>
            FangDao,
            /// <summary>
            /// 音响
            /// </summary>
            YinXiang,
            /// <summary>
            /// 玻璃升降
            /// </summary>
            BoliShengJiang,
            /// <summary>
            /// 空调
            /// </summary>
            KongTiao,
            /// <summary>
            /// CD
            /// </summary>
            CD,
            /// <summary>
            /// 铝合金钢圈
            /// </summary>
            GangQuan,
            /// <summary>
            /// 轮圈盖
            /// </summary>
            LunQuan,
            /// <summary>
            /// 备胎
            /// </summary>
            BeiTai,
            /// <summary>
            /// 备胎摇杆
            /// </summary>
            YaoGan,
            /// <summary>
            /// 千斤顶
            /// </summary>
            QianJinDing,
            /// <summary>
            /// 故障标签
            /// </summary>
            GuZhangBiaoQian,
            /// <summary>
            /// 脚踏
            /// </summary>
            JiaoTa,
            /// <summary>
            /// 遥控器
            /// </summary>
            YaoGanQi
        }
        private ISet<CarBaseInfo> carInfo;
        public virtual ISet<CarBaseInfo> CarInfo
        {
            get { return carInfo; }
            set { carInfo = value; }
        }
        public static  string []CategoryArry={"意向客户","正式客户"};
    }
}