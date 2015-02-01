using System;
using System.Collections;
using System.Collections.Generic;

namespace EntityClassLibrary
{
    public class UserRole : BaseEntity
    {

        private string roleName;

        public virtual string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        private int roleOrder;

        public virtual int RoleOrder
        {
            get { return roleOrder; }
            set { roleOrder = value; }
        }
        private int roleLevel;

        public virtual int RoleLevel
        {
            get { return roleLevel; }
            set { roleLevel = value; }
        }
        private string description;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }
        private long parentId;

        public virtual long ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }
        private IList<Resource> userResource;

        public virtual IList<Resource> UserResource
        {
            get { return userResource; }
            set { userResource = value; }
        }
    }
}
