using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace EnergyEquipmentProject.Service
{
    class MainPageService : BaseService
    {
        public IList getMatterByUserId(UserInfo userId)
        {
            string sql = "from Matter where Number>0 and State=" + (int)BaseEntity.stateEnum.Normal+" and (";
            if (userId.UserRole == null || userId.UserRole.Count <= 0)
            {
                return null;
            }
            foreach (UserRole r in userId.UserRole)
            {
                sql += " UserId=" + r.Id + " or";
            }
            sql = sql.Substring(0, sql.Length - 2)+")";
            return this.loadEntityList(sql);
        }

        public IList getNews()
        {
            string sql = "from News where State=" + (int)BaseEntity.stateEnum.Normal + "order by PublishTime desc";
            return this.loadEntityList(sql);
        }

        public IList getScheduleByUserIdAndDate(long userId,long startDate,long endDate)
        {
            string sql = "from Schedule where ScheduleUser=" + userId + " and ScheduleTime>=" + startDate + " and ScheduleTime<" + endDate + " State=" + (int)BaseEntity.stateEnum.Normal + "order by ScheduleTime desc";
            return this.loadEntityList(sql);
        }

        public IList getLetterByPublishUser(long userId)
        {
            IList newsList = this.loadEntityList("select n from Letter n left join n.Users u where u.Id=" + userId + " and n.State=" + (int)EntityClassLibrary.BaseEntity.stateEnum.Normal + " and u.State="+(int)BaseEntity.stateEnum.Normal+" order by SenderTime desc");
            return newsList;
        }
    }
}
