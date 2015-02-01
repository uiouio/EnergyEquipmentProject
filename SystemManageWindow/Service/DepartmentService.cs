using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace SystemManageWindow.Service
{
    public class DepartmentService : BaseService 
    {
        public IList getAllDepts()
        {
            string sql = "from Department d where State=" + (int)BaseEntity.stateEnum.Normal + " order by d.DeptLevel,d.DeptOrder";
            return this.loadEntityList(sql);
        }

        public IList getUsersByDeptId(long id)
        {
            string sql = "select u from UserInfo u left join u.Dept r where r.Id=" + id + " and u.State=" + (int)BaseEntity.stateEnum.Normal + " and r.State=" + (int)BaseEntity.stateEnum.Normal;
            return this.loadEntityList(sql);
        }

        public bool checkDeptDelete(long deptId)
        {
            string sql = "from Department d where d.ParentId=" + deptId + " and State=" + (int)BaseEntity.stateEnum.Normal;
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
    }
}
