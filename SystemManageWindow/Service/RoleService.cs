using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace SystemManageWindow.Service
{
    class RoleService : BaseService
    {
        public IList getAllRoles()
        {
            string sql = "from UserRole r where State=" + (int)BaseEntity.stateEnum.Normal + " order by r.RoleLevel,r.RoleOrder";
            return this.loadEntityList(sql);
        }

        public bool checkRoleDelete(long resourceId)
        {
            string sql = "from UserRole r where r.ParentId=" + resourceId + " and State=" + (int)BaseEntity.stateEnum.Normal;
            IList childResource = this.loadEntityList(sql);
            if (childResource != null && childResource.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IList getUsersByRoleId(long id)
        {
            string sql = "select u from UserInfo u left join u.UserRole r where r.Id=" + id + " and u.State=" + (int)BaseEntity.stateEnum.Normal + " and r.State=" + (int)BaseEntity.stateEnum.Normal;
            return this.loadEntityList(sql);
        }

        public IList getSelectUserBySelectedId(IList selectedUser)
        {
            string sql = "from UserInfo u where State=" + (int)BaseEntity.stateEnum.Normal;
            if (selectedUser != null && selectedUser.Count > 0)
            {
                for (int i = 0; i < selectedUser.Count; i++)
                {
                    UserInfo userInfo = (UserInfo)selectedUser[i];
                    sql += " and u.Id!=" + userInfo.Id;
                }
            }
            return this.loadEntityList(sql);
        }

    }
}
