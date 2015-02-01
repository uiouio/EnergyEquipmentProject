using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SQLProvider.Service;
using EntityClassLibrary;

namespace CheRuKu.SQL
{
    class OP_ChuRuKu:BaseService
    {
        public IList GetAllRuKu()
        {
            IList ss = null;
            string sql = "select u,m from CheRuKuInfo u left join u.RefitWork r,ModificationContract m where r.ContractNo=m.ContractNo and m.State=" + (int)BaseEntity.stateEnum.Normal + " and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.ActualCompletionDate Desc";
            //string sql =
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
        public void saveRuKuDan(EntityClassLibrary.CheRuKuInfo tt)
        {
            this.SaveOrUpdateEntity(tt);
        }

        public IList QueryCheRuKu(string number,string order, long time1,long time2)
        {
            IList i = null;
            string sql = "select u,m from CheRuKuInfo u left join u.RefitWork r,ModificationContract m where u.RefitWork.ContractNo like" + "'%" + number + "%' and u.RefitWork.DispatchOrder like" + "'%" + order + "%' and u.ActualCompletionDate>=" + time1 + " and u.ActualCompletionDate<" + time2 + " and  u.State = " + (int)BaseEntity.stateEnum.Normal + "and r.ContractNo=m.ContractNo and m.State=" + (int)BaseEntity.stateEnum.Normal + " order by u.ActualCompletionDate Desc";
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

    }
}
