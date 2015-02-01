using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace CommonWindow.Service
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
            string sql = "from Resource r where r.ParentId=" + pid + " and r.State=" + (int)BaseEntity.stateEnum.Normal + " order by r.ResourceOrder";
            return this.loadEntityList(sql);
        }

        public IList getChildResourceByRoleIdAndPID(long pid, IList<UserRole> userRole)
        {
            string sql = "select r.Id from Resource r left join r.UserRoles role where r.ParentId=" + pid + " and role.State=" + (int)BaseEntity.stateEnum.Normal + " and r.State=" + (int)BaseEntity.stateEnum.Normal;
            if (userRole != null && userRole.Count > 0)
            {
                sql += " and (role.Id=" + userRole[0].Id;
                for (int i = 1; i < userRole.Count; i++)
                {
                    sql += " or role.Id=" + userRole[i].Id;
                }
                sql += ")";
            }
            else
            {
                return null;
            }
            sql += " order by r.ResourceOrder";
            return this.loadEntityList(sql);
        }

        public IList getUserByUserNameAndUserNumAndDept(string userName, string userNum, string dept,IList selectedUser)
        {
            string sql = "select u from UserInfo u left join u.Dept dept where u.Name like '%" + userName + "%' and u.UserName like '%" + userNum + "%' and dept.DepartmentName like '%" + dept + "%' and u.State=" + (int)BaseEntity.stateEnum.Normal;
            if (selectedUser != null && selectedUser.Count > 0)
            {
                foreach (UserInfo u in selectedUser)
                {
                    sql += " and u.Id!=" + u.Id;
                }
            }
            return this.loadEntityList(sql);
        }
    }
}
