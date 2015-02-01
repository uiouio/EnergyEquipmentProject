using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityClassLibrary;
using SQLProvider.Service;
using System.Collections;

namespace JianJian.SQL
{
    class OP_JianJian:BaseService
    {
        public void saveTongZhiDan(EntityClassLibrary.JianJianInfo tt)
        {
            this.SaveOrUpdateEntity(tt);
        }

        public IList GetAllYIchukued()
        {
            IList ss = null;
            string sql = "from CarTheLibrary u where u.State = " + (int)BaseEntity.stateEnum.Normal +
                " and u.Status = 0";
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

        public IList GetAllCarInfo(long id)
        {
            IList ss = null;
            string sql = "from JianJianInfo u where u.Batch.Id =" + id + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
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

        public IList GetAllBatch()
        {
            IList ss = null;
            string sql = "from Batch u where u.State = " + (int)BaseEntity.stateEnum.Normal;
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


       

        public IList QueryJianJian(string number)
        {
            IList i = null;
            string sql = "from Batch u where u.Number like" + "'%" + number + "%'and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;

        }

        public IList QueryJianJianCheLiang(string name,string number,long batchId)
        {
            IList i = null;
            string sql = "from JianJianInfo u where u.CarTheLibrary.RefitWork.CarInfo.Cbi.Name like" + "'%" + name + "%'and u.CarTheLibrary.RefitWork.CarInfo.PlateNumber like" + "'%" + number + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal + " and u.Batch.Id="+batchId;
            i = this.loadEntityList(sql);
            return i;
        }
        public IList QueryJianJianCheLiang1(string name, string number)
        {
            IList i = null;
            string sql = "from JianJianInfo u where u.CarTheLibrary.RefitWork.CarInfo.Cbi.Name like" + "'%" + name + "%'and u.CarTheLibrary.RefitWork.CarInfo.PlateNumber like" + "'%" + number + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }

        public void RemoveJianJian(JianJianInfo tt )
        {
            if (tt != null)
                this.deleteEntity(tt);
        }

        public IList GetFlag(long carId)
        {
            IList i = null;
            string sql = "from Car c where c.Carid= " + carId + "and c.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
    }
}
