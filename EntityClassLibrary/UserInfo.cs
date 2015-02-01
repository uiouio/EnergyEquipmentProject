using System;
using System.Collections;
using System.Collections.Generic;

namespace EntityClassLibrary
{
    public class UserInfo : BaseEntity
    {

        private string userName;
        /// <summary>
        /// 登录名，不是姓名！！！
        /// </summary>
        public virtual string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public virtual string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int accountState;

        public virtual int AccountState
        {
            get { return accountState; }
            set { accountState = value; }
        }
        private string name;
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string sex;

        public virtual string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string nation;

        public virtual string Nation
        {
            get { return nation; }
            set { nation = value; }
        }
        private int age;

        public virtual int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string qQ;

        public virtual string QQ
        {
            get { return qQ; }
            set { qQ = value; }
        }
        private string identifyCardNo;

        public virtual string IdentifyCardNo
        {
            get { return identifyCardNo; }
            set { identifyCardNo = value; }
        }
        private string phone;

        public virtual string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string email;

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
        private string empolyedDate;

        public virtual string EmpolyedDate
        {
            get { return empolyedDate; }
            set { empolyedDate = value; }
        }
        private string postcode;

        public virtual string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        private long userPictureId;

        public virtual long UserPictureId
        {
            get { return userPictureId; }
            set { userPictureId = value; }
        }

        private Department dept;
        public virtual Department Dept
        {
            get { return dept; }
            set { dept = value; }
        }
      
        private IList<UserRole> userRole;

        public virtual IList<UserRole> UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
    }
}
