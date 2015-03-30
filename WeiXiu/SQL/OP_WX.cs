using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using EntityClassLibrary;
using System.Collections;

namespace WeiXiu.SQL
{
    class OP_WX:BaseService
    {
        public void saveFanKuiDan(WeiXiuFanKuiDan tt)
        {
            this.SaveOrUpdateEntity(tt);
        }

        public IList GetAllWeiXiu()
        {
            IList ss = null;

            string sql = "from WeiXiuFanKuiDan u where u.State = " + (int)BaseEntity.stateEnum.Normal;
            ss = this.loadEntityList(sql);

            if (ss.Count > 0 && ss != null)
            {
                return ss;
            }
            else 
            { 
                return null; 
            }
         
        }

        public IList getAllTiaoShiJiLu() {
            IList ss = null;
            string sql = "from TiaoShiWeiXiuJiLu u where u.State = " + (int)BaseEntity.stateEnum.Normal;
            ss = this.loadEntityList(sql);
            if (ss.Count > 0 && ss != null)
            {
                return ss;
            }
            else
            {
                return null;
            }
        }

        public void saveWeiXiuJiLu(EntityClassLibrary.TiaoShiWeiXiuJiLu tt)
        {
            this.SaveOrUpdateEntity(tt);
        }

        public IList QueryWeiXiu(string name, string number, long time1,long time2)
        {
            IList i = null;
            string sql = "from WeiXiuFanKuiDan u where u.Name like" + "'%" + name + "%' and u.LicensePlateNumber like" + "'%" + number + "%' and u.FeedbackTime>=" + time1 + " and u.FeedbackTime<" + time2 + " and  u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.FeedbackTime Asc";
            i = this.loadEntityList(sql);
            return i;
        }

        public IList QueryWeiXiuName(string name)
        {
            IList i = null;
            string sql = "from WeiXiuFanKuiDan u where u.Name like " + "'%" + name + "%'and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.FeedbackTime Asc";
            i = this.loadEntityList(sql);
            return i;
        }

        public IList QueryWeiXiuNumber(string number)
        {
            IList i = null;
            string sql = "from WeiXiuFanKuiDan u where u.LicensePlateNumber like" + "'%" + number + "%'and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.FeedbackTime Asc";
            i = this.loadEntityList(sql);
            return i;
        }

        public IList QueryWeiXiuJiLu(string code, string number, long time1, long time2) { 
            IList i=null;
            string sql = "from TiaoShiWeiXiuJiLu u where u.ModificationNumber like " + "'%" + code + "%' and u.License like" + "'%" + number + "%' and u.DebugTime>=" + time1 + " and u.DebugTime<" + time2 + " and  u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.DebugTime Asc";
            i = this.loadEntityList(sql); 
            return i;
        }

        public IList QueryWeiXiuFGoods(long id)
        {
            IList i = null;
            string sql = "from ServiceGoods u where u.WeiXiuFanKuiDanId.Id = " + id +
                         " and u.State = " + (int)BaseEntity.stateEnum.Normal;
            
            i = this.loadEntityList(sql);
            
            return i;
        }

        public IList SelectCarBuyCarNum(string num)
        {
            IList i  = null ;
            string sql = "select u ,c from ModificationContract u left join u.CarBaseInfoID c where c.PlateNumber like '%"+num+"%'";
            i = loadEntityList(sql);
            return i;
        }

    }
}
