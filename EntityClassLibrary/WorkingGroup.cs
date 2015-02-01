using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace EntityClassLibrary
{
    public class WorkingGroup:BaseEntity
    {
        public WorkingGroup()
        {
            itself = this;
        }
        private UserInfo workingGroupLeader;
        public virtual UserInfo WorkingGroupLeader
        {
            get { return workingGroupLeader; }
            set { workingGroupLeader = value; }
        }
       

        private string workingGroupName;
        public virtual string WorkingGroupName
        {
            get { return workingGroupName; }
            set { workingGroupName = value; }
        }

        private IList<UserInfo> userInfo;
        public virtual IList<UserInfo> UserInfo
        {
            get { return userInfo; }
            set { userInfo = value; }
        }

        private WorkingGroup itself;
        public virtual WorkingGroup Itself
        {
            get { return itself; }
        }


    }
}
