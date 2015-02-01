using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace EnergyEquipmentProject.Service
{
    class UserInfoService : BaseService
    {
        public IList getUserInfoByNameAndPwd(string userName, string pwd)
        {
            string sql = "from UserInfo where UserName='" + userName + "' and Password='" + pwd + "' and State="+(int)BaseEntity.stateEnum.Normal;
            return this.loadEntityList(sql);
        }

        public IList getResourceByRoleId(long roleId)
        {
            string sql = "select r from UserRole role left join role.UserResource r where role.State="+(int)BaseEntity.stateEnum.Normal+" and r.State="+(int)BaseEntity.stateEnum.Normal+" and role.Id=" + roleId + " order by r.ResourceLevel,r.ResourceOrder";
            return this.loadEntityList(sql);
        }

        public IList getAllOneLevelResource()
        {
            string sql = "from Resource r where r.State=" + (int)BaseEntity.stateEnum.Normal + " and r.ResourceLevel=0 order by r.ResourceOrder";
            return this.loadEntityList(sql);
        }

        public IList getAllChildResourcePID(long pid)
        {
            string sql = "from Resource r where r.ParentId=" + pid + " and r.State=" + (int)BaseEntity.stateEnum.Normal + " and r.ResourceLevel=0 order by r.ResourceOrder";
            return this.loadEntityList(sql);
        }

        public IList getChildResourceByRoleIdAndPID(long pid, IList<UserRole> userRole)
        {
            string sql = "select distinct r.Id from UserRole role left join role.UserResource r where r.ParentId=" + pid + " and role.State=" + (int)BaseEntity.stateEnum.Normal + " and r.State=" + (int)BaseEntity.stateEnum.Normal;
            if (userRole != null && userRole.Count > 0)
            {
                foreach (UserRole r in userRole)
                {
                    sql += " and role.Id=" + r.Id;
                }
            }
            sql += " order by r.ResourceOrder";
            return this.loadEntityList(sql);
        }
    }
}
