using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;

namespace XinXiGuanLi.Service
{
    class NewsService : BaseService
    {
        public IList getNewsByPublishUserAndTime(string userName, long startTime, long endTime)
        {
            IList newsList = this.loadEntityList("select n from News n left join n.PublishUser u where u.Name like '%" + userName + "%' and PublishTime>='" + startTime + "' and PublishTime<='" + endTime + "' and n.State=" + (int)EntityClassLibrary.BaseEntity.stateEnum.Normal + " order by PublishTime desc");
            return newsList;
        }
    }
}
