using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace CheChuKu.SQL
{
    public class OP_CheChuKu:BaseService
    {
        IList Currentss;

        public IList GetAllChuKu()
        {
            IList ss = null;
            //string sql = "select u,m from CarTheLibrary u left join u.RefitWork r,ModificationContract m where r.ContractNo=m.ContractNo and m.State=" + (int)BaseEntity.stateEnum.Normal + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
            string sql = "select r from CheRuKuInfo cr left join cr.RefitWork r left join r.CarInfo c where c.Id in (select CarInfoId from DeliveryModificationRecords where State=0) and cr.Status=" + (int)CheRuKuInfo.savecheck.check + " and r.Id not in (select RefitWork from CarTheLibrary where State=0)";
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

        public IList GetAllChuKu1()
        {
            IList ss = null;
            //string sql = "select u,m from CarTheLibrary u left join u.RefitWork r,ModificationContract m where r.ContractNo=m.ContractNo and m.State=" + (int)BaseEntity.stateEnum.Normal + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
            string sql = " from CarTheLibrary u where u.State = " + (int)BaseEntity.stateEnum.Normal;
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


        public void saveChuKu(EntityClassLibrary.CarTheLibrary tt)
        {
            this.SaveOrUpdateEntity(tt);
        }

        public IList QueryDaiCheChuKu(string number, string order)
        {
            IList i = null;
            string sql = "select r from CheRuKuInfo cr left join cr.RefitWork r left join r.CarInfo c where cr.RefitWork.ContractNo like" + "'%" + number + "%' and cr.RefitWork.DispatchOrder like" + "'%" + order + "%' and cr.State = " + (int)BaseEntity.stateEnum.Normal + "and c.Id in (select CarInfoId from DeliveryModificationRecords where State=0) and cr.Status=" + (int)CheRuKuInfo.savecheck.check + " and r.Id not in (select RefitWork from CarTheLibrary where State=0)";
            i = this.loadEntityList(sql);
            return i;
        }


        public IList QueryCheChuKu(string number, string order, long time1, long time2)
        {
            IList i = null;
            string sql = "select cr, r from CarTheLibrary cr left join cr.RefitWork r left join r.CarInfo c where cr.RefitWork.ContractNo like" + "'%" + number + "%' and cr.RefitWork.DispatchOrder like" + "'%" + order + "%' and cr.FinishTime>=" + time1 + " and cr.FinishTime<" + time2 + " and  cr.State = " + (int)BaseEntity.stateEnum.Normal + "and c.Id in (select CarInfoId from DeliveryModificationRecords where State=0)";
            i = this.loadEntityList(sql);
            return i;
        }
    }

}
