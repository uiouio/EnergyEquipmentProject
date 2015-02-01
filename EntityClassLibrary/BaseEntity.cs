using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class BaseEntity 
    {
        private long id;

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long timeStamp;

        public virtual long TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

        private int state;

        public virtual int State
        {
            get { return state; }
            set { state = value; }
        }

        private long historyId;

        public virtual long HistoryId
        {
            get { return historyId; }
            set { historyId = value; }
        }

        #region 枚举变量

        public enum stateEnum
        {
            Normal = 0,
            Deleted = 1 
        }
        public enum YesNo
        {
            No = 0,
            Yes = 1
        }

        public enum SexEnum
        {
            Man = '男',
            Woman = '女'
        }

        //public enum CNGGasCNGDieselLNGDiesel
        //{
        //    CNGGas=0,
        //    CNGDiesel=1,
        //    LNGDiesel=2             
        //}

        #endregion

        public static string[] YesOrNoArray = { "否", "是" };

        //public override bool Equals(object obj)
        //{
        //    BaseEntity baseEntity = (BaseEntity)obj;
        //    if (baseEntity.Id != this.Id)
        //        return false;
        //    if (baseEntity.HistoryId != this.HistoryId)
        //        return false;
        //    if (baseEntity.TimeStamp != this.TimeStamp)
        //        return false;
        //    if (baseEntity.State != this.State)
        //        return false;
        //    return true;
        //}

        public virtual BaseEntity Clone()
        {
            BaseEntity baseEntity = new BaseEntity();
            baseEntity.Id = this.Id;
            baseEntity.HistoryId = this.HistoryId;
            baseEntity.TimeStamp = this.TimeStamp;
            baseEntity.State = this.State;
            return baseEntity;
        }

        public virtual string SaveOldSQL()
        {
            return null;
            //BaseEntity baseEntity = new BaseEntity();
            //return baseEntity;
        }

        public virtual string CheckOldSQL()
        {
            return null;
        }
    }
}
