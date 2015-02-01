using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class Schedule : BaseEntity
    {
        private UserInfo scheduleUser;

        public virtual UserInfo ScheduleUser
        {
            get { return scheduleUser; }
            set { scheduleUser = value; }
        }
        private long scheduleTime;

        public virtual long ScheduleTime
        {
            get { return scheduleTime; }
            set { scheduleTime = value; }
        }
        private string scheduleContent;

        public virtual string ScheduleContent
        {
            get { return scheduleContent; }
            set { scheduleContent = value; }
        }
    }
}
