using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;

namespace XinXiGuanLi.Service
{
    class ScheduleService : BaseService
    {
        public IList getScheduleByUserIdAndTime(long userId, long startTime, long endTime)
        {
            IList newsList = this.loadEntityList("from Schedule where ScheduleUser like '%" + userId + "%' and ScheduleTime>='" + startTime + "' and ScheduleTime<='" + endTime + "' and State=" + (int)EntityClassLibrary.BaseEntity.stateEnum.Normal + " order by ScheduleTime desc");
            return newsList;
        }
    }
}
