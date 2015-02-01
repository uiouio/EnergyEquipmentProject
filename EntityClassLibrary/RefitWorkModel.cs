using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace EntityClassLibrary
{
    public class RefitWorkModel : BaseEntity 
    {
        public RefitWorkModel()
        {
            itself = this;
        }
        private RefitWorkModel itself;
        public virtual RefitWorkModel Itself
        {
            get { return itself; }
           
        }
        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string remarks;
        public virtual string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        private UserInfo userId;
        /// <summary>
        /// 指定人
        /// </summary>
        public virtual UserInfo UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private UserInfo finalUserId;
        /// <summary>
        /// 最终修改人
        /// </summary>
        public virtual UserInfo FinalUserId
        {
            get { return finalUserId; }
            set { finalUserId = value; }
        }

        private ISet<RefitWorkModelGoods> refitWorkGoodss;

        public virtual ISet<RefitWorkModelGoods> RefitWorkGoodss
        {
            get { return refitWorkGoodss; }
            set { refitWorkGoodss = value; }
        }
    }
}
