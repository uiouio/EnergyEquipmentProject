using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace SystemManageWindow.Service
{
    class WorkGroupService : BaseService
    {
        public IList getAllWorkGroup()
        {
            string sql = "from WorkingGroup w where State=" + (int)BaseEntity.stateEnum.Normal + " order by w.WorkingGroupName";
            return this.loadEntityList(sql);
        }

        public IList getWorkGroupByName(string workgroupName)
        {
            string sql = "from WorkingGroup w where State=" + (int)BaseEntity.stateEnum.Normal + "and w.WorkingGroupName= "+workgroupName;
            return this.loadEntityList(sql);
        }
        public IList getWorkGroupById(long workgroupId)
        {
            string sql = "from WorkingGroup w where State=" + (int)BaseEntity.stateEnum.Normal + "and w.Id= " + workgroupId;
            return this.loadEntityList(sql);
        }

        public IList getUserInfoByWorkGroupId(long wkpID)
        {
            string sql = "select u from WorkingGroup w left join w.UserInfo u where w.Id="+wkpID+" and w.State = "
                + (int)BaseEntity.stateEnum.Normal + " order by u.Id";
            
            return this.loadEntityList(sql);
        }

        public IList getUserInfoWithWorkGroup()
        {
            string sql = "select u from UserInfo u where u.Id not in (select a from WorkingGroup w left join w.UserInfo a where a.Id!=0 and w.State = "
                + (int)BaseEntity.stateEnum.Normal + ") order by u.Id";

            return this.loadEntityList(sql);
        }
    }
}
