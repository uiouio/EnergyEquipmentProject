using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace TiaoShi.SQL
{
    class OP_TS : BaseService
    {   
        public void SaveBao(TiaoShiBaoGao tt)
        {
            this.SaveOrUpdateEntity(tt);
        }

        public IList GetTiaoShiBaoGao()
        {
            IList ss = null;
            string sql = " from TiaoShiBaoGao u where u.LiuZhuanBiao.ScratchSaveState=" + (int)LiuZhuanBiao.ScratchSave.Save + " and u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.Status Asc, u.Time Desc";
            ss = loadEntityList(sql);
            if (ss.Count > 0 && ss != null)
            {
                return ss;
            }
            else
            {
                return null;
            }
        }

        public IList QueryTiaoShiBaoGao(string number, string platenumber, long time1, long time2)
        {
            IList i = null;
            string sql = "from TiaoShiBaoGao u where u.LiuZhuanBiao.PaiGongDan.DispatchOrder like" + "'%" + number + "%'and u.LiuZhuanBiao.PaiGongDan.CarInfo.PlateNumber like" + "'%" + platenumber + "%' and u.Time>=" + time1 + " and u.Time <=" + time2 + " and  u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.Status Asc, u.Time Desc";
            i = this.loadEntityList(sql);
            return i;
        }

        public IList GetTiaoShiBaoGaoChaKan()
        {
            IList ss = null;
            string sql = " from LiuZhuanBiao u where u.State = " + (int)BaseEntity.stateEnum.Normal;
            ss = loadEntityList(sql);
            if (ss.Count > 0 && ss != null)
            {
                return ss;
            }
            else
            {
                return null;
            }
        }
       
    }
}
