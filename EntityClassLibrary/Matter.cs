using System;
using System.Collections.Generic;

namespace EntityClassLibrary
{
    public class Matter : BaseEntity
    {
        private string typeFullName;
        private string matterContent;
        private string number;
        private long userId;
        public virtual string TypeFullName
        {
            get { return typeFullName;}
            set { typeFullName=value ;}
        }
        public virtual string MatterContent
        {
            get { return matterContent;}
            set { matterContent=value ;}
        }
        public virtual string Number
        {
            get { return number;}
            set { number=value ;}
        }
        /// <summary>
        /// 能看到的角色id
        /// </summary>
        public virtual long UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
