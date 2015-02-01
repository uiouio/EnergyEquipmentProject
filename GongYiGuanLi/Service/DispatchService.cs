using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace GongYiGuanLi.Service
{
    class DispatchService : BaseService
    {
        public IList getAllContractAndCarInfo(string contractNum,long signDateStart,long signDateEnd)
        {
            string sql = "select m,c from ModificationContract m right join m.CarBaseInfoID c where m.ContractNo like '%" + contractNum + "%' and m.SignedDate>=" + signDateStart + " and m.SignedDate<" + signDateEnd + " and m.Process=" + (int)ModificationContract.guocheng.htbgy + " and c.Id not in (select r.CarInfo from RefitWork r where r.State=" + (int)BaseEntity.stateEnum.Normal + ") and m.State=" + (int)BaseEntity.stateEnum.Normal + " and c.State=" + (int)BaseEntity.stateEnum.Normal + " order by m.SignedDate desc";
            return this.loadEntityList(sql);
        }

        public IList getAllRefitWork(string contractNum, string refitWorkNum, string formulateUserName, long signDateStart, long signDateEnd)
        {
            string sql = "select r from RefitWork r left join r.UserId u where r.ContractNo like '%" + contractNum + "%' and r.DispatchOrder like '%" + refitWorkNum + "%' and u.Name like '%" + formulateUserName + "%' and r.FormulateDate>=" + signDateStart + " and r.FormulateDate<"+signDateEnd+" and r.State=" + (int)BaseEntity.stateEnum.Normal + " order by r.FormulateDate desc";
            return this.loadEntityList(sql);
        }
        /// <summary>
        /// 检查是否有次名称模板
        /// </summary>
        /// <param name="name">模板名称</param>
        /// <param name="name">不包括的模板Id</param>
        /// <returns>true为有，false为没有</returns>
        public bool checkIfHave(string name,long modelId)
        {
            string sql = "from RefitWorkModel where Name='" + name + "' and Id!=" + modelId + " and State=" + (int)BaseEntity.stateEnum.Normal;
            IList result = this.loadEntityList(sql);
            if (result != null && result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
 
        /// <summary>
        /// 查找所有可用的派工单模板
        /// </summary>
        /// <returns></returns>
        public IList getAllModel()
        {
            string sql = "from RefitWorkModel where State=" + (int)BaseEntity.stateEnum.Normal;
            IList result = this.loadEntityList(sql);
            return result;
        }


        /// <summary>
        /// 查找所有可用的派工单模板
        /// </summary>
        /// <returns></returns>
        public IList getAllModel(string name,string userName)
        {
            string sql = "select r from RefitWorkModel r left join r.UserId u where u.State="+(int)BaseEntity.stateEnum.Normal+" and u.Name like '%"+userName+"%' and r.Name like '%"+name+"%' and r.State=" + (int)BaseEntity.stateEnum.Normal;
            IList result = this.loadEntityList(sql);
            return result;
        }
    }
}
