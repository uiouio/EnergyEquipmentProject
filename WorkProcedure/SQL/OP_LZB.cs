using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityClassLibrary;
using SQLProvider.Service;
using System.Collections;

namespace WorkProcedure.SQL
{
    class OP_LZB : BaseService
    {
        public void saveLiuZhuanBiao(LiuZhuanBiao tt)
        {
            this.SaveOrUpdateEntity(tt);
        }

        public void saveInstallRecord(EntityClassLibrary.InstallRecord tt)
        {
            this.SaveOrUpdateEntity(tt);
        }

        public void savePaiGongDan(RefitWork tt)
        {
            this.SaveOrUpdateEntity(tt);
        }


        public IList GetAllLiuZhuanBiao()
        {
            IList ss = null;
            string sql = "from RefitWork u where u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.DispatchState Asc";
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

        public IList GetAllLiuZhuanBiaoInfo()
        {
            IList ss = null;
            string sql = "from LiuZhuanBiao u where u.PaiGongDan.DispatchState>=" + (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth + " and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.ScratchSaveState Asc, u.PaiGongDan.DispatchTime Desc";
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

        public IList GetCarBaseInfo()
        {
            IList ss = null;
            string sql = "from LiuZhuanBiao u where u.State = " + (int)BaseEntity.stateEnum.Normal;
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

        public IList GetAllPaiGongDan()
        {
            IList ss = null;
            string sql = "from RefitWork u where u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.DispatchState Asc, u.DispatchTime Desc";
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

        public IList GetAllPaiGongDanChaKan()
        {
            IList ss = null;
            string sql = "from RefitWork u where u.DispatchState>=" + (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
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

        public IList QueryPaiGongDan(string number, int Screening,long time1, long time2)
        {
            IList i = null;
             string sql;
             if (Screening != -1)
             {
                 sql = "from RefitWork u where u.DispatchOrder like" + "'%" + number + "%' and u.CarInfo.ModidiedType =" + Screening + " and u.DispatchTime>=" + time1 + " and u.DispatchTime<" + time2 + " and  u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.DispatchState Asc, u.DispatchTime Desc";
             }
             else
             {
                 sql = "from RefitWork u where u.DispatchOrder like" + "'%" + number + "%' and u.DispatchTime>=" + time1 + " and u.DispatchTime<" + time2 + " and  u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.DispatchState Asc, u.DispatchTime Desc";
             }
            i = this.loadEntityList(sql);
            return i;
        }

        public IList QueryPaiGongDanChaKan(string number, int dispatch, string platenumber,string workgroup)
        {
            IList i = null;
            string sql;
            if (dispatch != -1)
            {
                sql = "from RefitWork u where u.DispatchOrder like" + "'%" + number + "%' and u.CarInfo.ModidiedType =" + dispatch + " and u.WorkingGroupId.WorkingGroupName='" + workgroup + "' and u.CarInfo.PlateNumber like" + "'%" + platenumber + " %'and u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.DispatchState Asc, u.DispatchTime Desc";
            }
            else
            {
                sql = "from RefitWork u where u.DispatchOrder like" + "'%" + number + "%' and u.WorkingGroupId.WorkingGroupName='" + workgroup + "' and u.CarInfo.PlateNumber like" + "'%" + platenumber + "%' and  u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.DispatchState Asc, u.DispatchTime Desc";
            }
           
            i = this.loadEntityList(sql);
            return i;
        }

        public IList QueryLiuZhuanBiao(string number, string platenumber, long time1, long time2)
        {
            IList i = null;
            string sql;
            //if (workgroup != -1)
            //{
            sql = "from LiuZhuanBiao u where u.PaiGongDan.DispatchOrder like" + "'%" + number + "%' and u.PaiGongDan.CarInfo.PlateNumber like" + "'%" + platenumber + "%' and u.PaiGongDan.DispatchTime>=" + time1 + " and u.PaiGongDan.DispatchTime<" + time2 + " and  u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.ScratchSaveState Asc, u.PaiGongDan.DispatchTime Desc";
            //else
            //{
            //    sql = "from LiuZhuanBiao u where u.PaiGongDan.DispatchOrder like" + "'%" + number + "%' and u.PaiGongDan.DispatchTime>=" + time1 + " and u.PaiGongDan.DispatchTime<" + time2 + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
            //}
            i = this.loadEntityList(sql);
            return i;
        }

        public IList GetAllGroups()
        {
            IList i = null;
            string sql = "from WorkingGroup u where u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }

        public IList GetAllPaiGongDanShaiXuan()
        {
            IList i = null;
            string sql = "from RefitWork u where u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
    }
}

