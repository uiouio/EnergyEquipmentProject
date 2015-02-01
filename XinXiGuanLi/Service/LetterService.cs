using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;

namespace XinXiGuanLi.Service
{
    class LetterService : BaseService 
    {
        public IList getLetterByPublishUserAndTime(long userId, long startTime, long endTime)
        {
            IList newsList = this.loadEntityList("from Letter n where n.SenderUser=" + userId + " and SenderTime>='" + startTime + "' and SenderTime<='" + endTime + "' and n.State=" + (int)EntityClassLibrary.BaseEntity.stateEnum.Normal + " order by SenderTime desc");
            return newsList;
        }

        public IList getLetterByPublishUserNameAndTime(string userName, long startTime, long endTime)
        {
            IList newsList = this.loadEntityList("select n from Letter n left join n.SenderUser u where u.Name like '%" + userName + "%' and SenderTime>='" + startTime + "' and SenderTime<='" + endTime + "' and n.State=" + (int)EntityClassLibrary.BaseEntity.stateEnum.Normal + " order by SenderTime desc");
            return newsList;
        }
    }
}
