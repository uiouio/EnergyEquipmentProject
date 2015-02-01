using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace SystemManageWindow.Service
{
    class ResourceService : BaseService
    {
        public IList getAllResources()
        {
            string sql = "from Resource r where State=" + (int)BaseEntity.stateEnum.Normal + " order by r.ResourceLevel,r.ResourceOrder";
            return this.loadEntityList(sql);
        }

        public IList<UserRole> getAllRolesByResourceId(long id)
        {
            string sql = "select r from UserRole r left join r.UserResource res where r.State=" + (int)BaseEntity.stateEnum.Normal + " and res.Id=" + id;
            IList<UserRole> result = new List<UserRole>();
            IList resultList = this.loadEntityList(sql);
            if (resultList != null && resultList.Count > 0)
            {
                foreach (UserRole r in resultList)
                {
                    result.Add(r);
                }
            }
            return result;
        }

        public bool checkResourceDelete(long resourceId)
        {
            string sql = "from Resource r where r.ParentId=" + resourceId + " and State=" + (int)BaseEntity.stateEnum.Normal;
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
