using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider;
using EntityClassLibrary;
using System.Collections;
using SQLProvider.Service;
namespace HeTongGuanLi.Service
{
     public  class ContractService:BaseService
    {
         BaseService ss = new BaseService();
         /// <summary>
         /// 查询销售负责人审核过的合同
         /// </summary>
         /// <param name="name"></param>
         /// <param name="cname"></param>
         /// <param name="time1"></param>
         /// <param name="time2"></param>
         /// <returns></returns>
         public IList SelectHeTongPass(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u where u.Id in(select c.ModificationID from CarBaseInfo c left join  c.Cbi cbi where c.State=" + (int)BaseEntity.stateEnum.Normal + ") where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.SignedDate Desc";
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 得到所有模板
         /// </summary>
         /// <returns></returns>
         public IList GetAllMuBan()
         {
             IList i = null;
             string sql = "from TemplateManager u where u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);

             return i;
         }
         public IList GetAllGaiZhuangMuBan()
         {
             IList i = null;
             string sql = "from TemplateManager u where  u.TemplateType="+(int)TemplateManager.type.gz+" and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);

             return i;
         }
         public IList GetAllSuiteMuBan()
         {
             IList i = null;
             string sql = "from TemplateManager u where u.TemplateType=" + (int)TemplateManager.type.tj + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);

             return i;
         }
        /// <summary>
        /// 查询套件合同模板
        /// </summary>
        /// <param name="aname"></param>
        /// <param name="bname"></param>
        /// <param name="dname"></param>
        /// <param name="ename"></param>
        /// <returns></returns>

         public IList SelectTJMuBan(string aname, string bname, long dname, long ename)
         {
             IList i = null;

             string sql = "select u from TemplateManager u left join u.UserID c where u.TemplateName like " + "'%" + aname + "%' and c.Name like " + "'%" + bname + "%' and u.Time>=" + dname + " and u.Time<" + ename + "  and u.TemplateType=" + (int)TemplateManager.type.tj + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;

             i = this.loadEntityList(sql);

             return i;
         }



        /// <summary>
        /// 查询改装合同模板
        /// </summary>
        /// <param name="aname"></param>
        /// <param name="bname"></param>
        /// <param name="dname"></param>
        /// <param name="ename"></param>
        /// <returns></returns>

         public IList SelectGZMuBan(string aname, string bname, long dname, long ename)
         {
             IList i = null;

             string sql = "select u from TemplateManager u left join u.UserID c where u.TemplateName like " + "'%" + aname + "%' and c.Name like " + "'%" + bname + "%' and u.Time>=" + dname + " and u.Time<" + ename + "  and u.TemplateType=" + (int)TemplateManager.type.gz + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;

             i = this.loadEntityList(sql);

             return i;
         }
         public IList SelectMuBan(string aname, string bname, long dname, long ename)
         {
             IList i = null;

             string sql = "select u from TemplateManager u left join u.UserID c where u.TemplateName like " + "'%" + aname + "%' and c.Name like " + "'%" + bname + "%' and u.Time>=" + dname + " and u.Time<" + ename + "  and  u.State = " + (int)BaseEntity.stateEnum.Normal;

             i = this.loadEntityList(sql);

             return i;
         }
         /// <summary>
         /// 查询销售负责人未审核的合同
         /// </summary>
         /// <param name="name"></param>
         /// <param name="cname"></param>
         /// <param name="time1"></param>
         /// <param name="time2"></param>
         /// <returns></returns>
         public IList SelectHeTongUnPass(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.ApprovalState=" + (int)ModificationContract.Approval.yet + " and u.Process>=" + (int)ModificationContract.guocheng.xsfzr + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;
            
             i = this.loadEntityList(sql);
             return i;
         }
        /// <summary>
        /// 查询审核过的改装合同
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cname"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
         public IList SelectHeTongAlready(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.ApprovalState=" +(int)ModificationContract.Approval.already+" and u.State = "+(int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询未审核的改装合同
         /// </summary>
         /// <param name="name"></param>
         /// <param name="cname"></param>
         /// <param name="time1"></param>
         /// <param name="time2"></param>
         /// <returns></returns>
         public IList SelectHeTongYet(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.ApprovalState=" +(int)ModificationContract.Approval.yet + " and u.State = "+(int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询所有改装合同
         /// </summary>
         /// <param name="name"></param>
         /// <param name="cname"></param>
         /// <param name="time1"></param>
         /// <param name="time2"></param>
         /// <returns></returns>
         public IList SelectHeTong(string name, string cname,string dname,string ename, long time1, long time2)
         {
             IList i = null;
             //string sql = "select u from ModificationContract u  where u in(select c.ModificationID from CarBaseInfo c  where c.State=" + (int)BaseEntity.stateEnum.Normal + ") and   u.ContractNo like " + "'%" + name + "%' and  cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + "  and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.Process ASC,u.SignedDate Desc";
             string sql = " from ModificationContract u  where u.Id in(select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi left join cbi.UserID w  where  u.ContractNo like " + "'%" + name + "%' and  cbi.Name like " + "'%" + cname + "%' and c.PlateNumber like " + "'%" + dname + "%' and w.Name like " + "'%" + ename + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + "  and u.State = " + (int)BaseEntity.stateEnum.Normal + ") order by u.Process ASC,u.SignedDate Desc";
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询所有套件合同
         /// </summary>
         /// <param name="name"></param>
         /// <param name="cname"></param>
         /// <param name="bname"></param>
         /// <param name="time1"></param>
         /// <param name="time2"></param>
         /// <returns></returns>
         
         public IList SelectTaoJianHeTong(string name, string cname,long time1, long time2)
         {
             IList i = null;
             string sql = "select u from  SuiteContract u left join u.CustomBaseID c  where u.ContractNo like " + "'%" + name + "%' and c.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询销售负责所有合同
         /// </summary>
         /// <param name="name"></param>
         /// <param name="cname"></param>
         /// <param name="time1"></param>
         /// <param name="time2"></param>
         /// <returns></returns>
         public IList SelectContract(string name, string cname,long time1, long time2)
         {
             IList i = null;
             string sql = " from ModificationContract u  where u.Id in(select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi  where  u.ContractNo like " + "'%" + name + "%' and  cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + "  and u.State = " + (int)BaseEntity.stateEnum.Normal + ") order by u.Process ASC,u.SignedDate Desc";
             i = this.loadEntityList(sql);
             return i;
         }
        
         public IList SelectSuiteContract(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from SuiteContract u  left join u.CustomBaseID c where u.ContractNo like " + "'%" + name + "%' and c.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.Process>=" + (int)SuiteContract.guocheng.xsfzr + " and u.State = " + (int)BaseEntity.stateEnum.Normal + "order by u.Process ASC,u.SignedDate Desc";
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 得到销售负责人所有合同
         /// </summary>
         /// <returns></returns>
         public IList GetAllContract()
         {
             IList custom = null;
             string sql = " from ModificationContract u where u.Process>=" + (int)ModificationContract.guocheng.xsfzr + " and   u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.Process ASC,u.SignedDate Desc";
             custom = this.loadEntityList(sql);

             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         public IList GetAllSuiteContract()
         {
             IList custom = null;
             string sql = " from SuiteContract u where u.Process>=" + (int)ModificationContract.guocheng.xsfzr + " and   u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.Process ASC,u.SignedDate Desc";
             custom = this.loadEntityList(sql);

             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         /// <summary>
         /// 得到总经理所有合同
         /// </summary>
         /// <param name="entity"></param>
         public IList GetManageContract()
         {
             IList custom = null;
             string sql = " from ModificationContract u where u.Process>=" + (int)ModificationContract.guocheng.zjl + " and   u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.Process ASC,u.SignedDate Desc";
             custom = this.loadEntityList(sql);
             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         public IList GetManageSuiteContract()
         {
             IList custom = null;
             string sql = " from SuiteContract u where u.Process>=" + (int)SuiteContract.guocheng.zjl + " and   u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.Process ASC,u.SignedDate Desc";
             custom = this.loadEntityList(sql);
             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         /// <summary>
         /// 得到所有套件合同
         /// </summary>
         /// <returns></returns>
         public IList GetAllSuitContract()
         {
             IList custom = null;
             string sql = " from SuiteContract u where u.State = " + (int)BaseEntity.stateEnum.Normal ;
             custom = this.loadEntityList(sql);

             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }


         /// <summary>
         /// 查询总经理所有审核过的合同
         /// </summary>
         /// <param name="entity"></param>
         public IList SelectHeTongManagePass(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.ApprovalState=" + (int)ModificationContract.Approval.already + " and u.Process>=" + (int)ModificationContract.guocheng.zjl + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询总经理未审核的合同
         /// </summary>
         /// <param name="entity"></param>
         public IList SelectHeTongManageUnPass(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.ApprovalState=" + (int)ModificationContract.Approval.yet + " and u.Process>=" + (int)ModificationContract.guocheng.zjl + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询总经理所有合同
         /// </summary>
         /// <param name="entity"></param>
         public IList SelectHeTongManage(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = " from ModificationContract u  where u.Id in(select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi  where  u.ContractNo like " + "'%" + name + "%' and  cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + "  and u.State = " + (int)BaseEntity.stateEnum.Normal + ") order by u.Process ASC,u.SignedDate Desc";
             i = this.loadEntityList(sql);
             return i;
         }
         public IList SelectSuiteHeTongManage(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = " from SuiteContract u left join u.CustomBaseID c  where u.ContractNo like " + "'%" + name + "%' and c.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.Process>=" + (int)ModificationContract.guocheng.zjl + "   and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 得到会计师所有合同
         /// </summary>
         /// <param name="entity"></param>
         public IList GetAccountantContract()
         {
             IList custom = null;
             string sql = " from ModificationContract u where u.Process>=" + (int)ModificationContract.guocheng.kjs + " and   u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.Process ASC,u.Pass ASC ";
             custom = this.loadEntityList(sql);
             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         /// <summary>
         /// 得到会计师套间合同
         /// </summary>
         /// <returns></returns>
         public IList GetAccountantSuiteContract()
         {
             IList custom = null;
             string sql = " from SuiteContract u where u.Process>=" + (int)ModificationContract.guocheng.kjs + " and   u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.Process ASC";
             custom = this.loadEntityList(sql);
             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         /// <summary>
         /// 查询会计师所有审核过的合同
         /// </summary>
         /// <param name="entity"></param>
         public IList SelectHeTongAccountantPass(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.ApprovalState=" + (int)ModificationContract.Approval.already + " and u.Process>=" + (int)ModificationContract.guocheng.kjs + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询会计师所有未审核的合同
         /// </summary>
         /// <param name="entity"></param>
         public IList SelectHeTongAccountantUnPass(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.ApprovalState=" + (int)ModificationContract.Approval.yet + " and u.Process>=" + (int)ModificationContract.guocheng.kjs + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询会计师所有合同
         /// </summary>
         /// <param name="entity"></param>
         public IList SelectHeTongAccountant(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = " from ModificationContract u  where u.Id in(select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi  where  u.ContractNo like " + "'%" + name + "%' and  cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + "  and u.State = " + (int)BaseEntity.stateEnum.Normal + ") order by u.Process ASC,u.SignedDate Desc";
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询会计师所有套件合同
         /// </summary>
         /// <param name="name"></param>
         /// <param name="cname"></param>
         /// <param name="time1"></param>
         /// <param name="time2"></param>
         /// <returns></returns>
         public IList SelectSuiteHeTongAccountant(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from SuiteContract u left join u.CustomBaseID c  where u.ContractNo like " + "'%" + name + "%' and c.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.Process>=" + (int)ModificationContract.guocheng.kjs + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 查询所有通过的合同
         /// </summary>
         /// <param name="entity"></param>
         public IList SelectPassedContract(string name,string cname,long time1,long time2)
         {
             IList i = null;
             string sql = " from ModificationContract u  where u.Id in(select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi  where  u.ContractNo like " + "'%" + name + "%' and  cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + "  and u.State = " + (int)BaseEntity.stateEnum.Normal + ") order by u.Process ASC,u.SignedDate Desc";
             i = this.loadEntityList(sql);
             return i;
         }
         public IList SelectPassedSuiteContract(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from SuiteContract u left join u.CustomBaseID c  where u.ContractNo like " + "'%" + name + "%' and c.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.Process>=" + (int)ModificationContract.guocheng.htbgy + " and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 得到所有通过的改装合同
         /// </summary>
         /// <param name="entity"></param>
         public IList GetPassedContract()
         {
             IList custom = null;
             string sql = " from ModificationContract u where u.Process=" + (int)ModificationContract.guocheng.htbgy + "  and u.State = " + (int)BaseEntity.stateEnum.Normal;
             custom = this.loadEntityList(sql);
             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         public IList GetPassedSuiteContract()
         {
             IList custom = null;
             string sql = " from SuiteContract u where u.Process=" + (int)ModificationContract.guocheng.htbgy + "  and u.State = " + (int)BaseEntity.stateEnum.Normal;
             custom = this.loadEntityList(sql);
             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         /// <summary>
         /// 通过改装合同Id得到操作记录
         /// </summary>
         /// <param name="entity"></param>
         public IList GetModificationContractPayment(long contractId)
         {
             string sql = " from PaymentRecords u where u.ContractId=" + contractId + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
             return this.loadEntityList(sql);
         }

         /// <summary>
         /// 通过套件合同Id得到操作记录
         /// </summary>
         /// <param name="entity"></param>
         public IList GetSuitContractPayment(long contractId)
         {
             string sql = " from PaymentRecordsSuit u where u.ContractId=" + contractId + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
             return this.loadEntityList(sql);
         }

         /// <summary>
         /// 得到所有满足条件的改装合同
         /// </summary>
         /// <param name="name">合同编号</param>
         /// <param name="cname">乙方</param>
         /// <param name="time1">签订开始时间</param>
         /// <param name="time2">签订结束时间</param>
         /// <returns></returns>
         public IList SelectPassedModificationContract(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from ModificationContract u left join u.CarBaseInfoID c left join c.Cbi cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.Process>=" + (int)ModificationContract.guocheng.htbgy + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }

         /// <summary>
         /// 得到所有满足条件的套件合同
         /// </summary>
         /// <param name="name">合同编号</param>
         /// <param name="cname">乙方</param>
         /// <param name="time1">签订开始时间</param>
         /// <param name="time2">签订结束时间</param>
         /// <returns></returns>
         public IList SelectPassedSuitContract(string name, string cname, long time1, long time2)
         {
             IList i = null;
             string sql = "select u from SuiteContract u left join u.CustomBaseID cbi where u.ContractNo like " + "'%" + name + "%' and cbi.Name like " + "'%" + cname + "%' and u.SignedDate>=" + time1 + " and u.SignedDate<" + time2 + " and u.Process>=" + (int)ModificationContract.guocheng.htbgy + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }

         public void Remove(BaseEntity entity)
         {
             if (entity != null)
                 this.deleteEntity(entity);
         }
         public void Save(BaseEntity enty)
         {
             this.SaveOrUpdateEntity(enty);
         }
         /// <summary>
         /// 检查是否存在模板
         /// </summary>
         /// <param name="name"></param>
         /// <param name="modelId"></param>
         /// <returns></returns>
         public bool checkIfExist(string name, long modelId)
         {
             string sql = "from TemplateManager where TemplateName='" + name + "' and Id!=" + modelId + " and State=" + (int)BaseEntity.stateEnum.Normal;
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
         /// 更新气瓶价格
         /// </summary>
         /// <param name="name"></param>
         /// <param name="cname"></param>
         /// <returns></returns>
         public void UpdateModifyValue(string name,string cname)
         {
             
             string sql = "update CarBaseInfo set CylinderValue=" + name+ "  where  CylinderType = '" + cname + " ' ";
             ss.ExecuteSQL(sql);
         }
         /// <summary>
         /// 根据气瓶型号选择车辆
         /// </summary>
         /// <param name="name"></param>
         /// <returns></returns>
         public IList SelectCarsByType(string name)
         {
             IList i = null;
             string sql = "from CarBaseInfo where  CylinderType='" + name + "'";
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 选择CNG气瓶车辆
         /// </summary>
         /// <param name="name"></param>
         /// <returns></returns>
         public IList SelectCNGCars(string name)
         {
             IList i = null;
             string sql = "select distinct CylinderType from CarBaseInfo where  CylinderType is not null and VehicleType='" + name + "'and (ModidiedType=0 or ModidiedType=1) and CarBaseInfoState=" + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         public IList SelectLNGCars(string name)
         {
             IList i = null;
             string sql = "select distinct CylinderType from CarBaseInfo where CylinderType is not null and VehicleType='" + name + "'and ModidiedType=2 and CarBaseInfoState=" + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 选择已有车辆的气瓶型号
         /// </summary>
         /// <returns></returns>
         public IList SelectCarsCylinderType()
         {
             IList i = null;
             string sql = "from CarBaseInfo";
             i = this.loadEntityList(sql);
             return i;
         }
         /// <summary>
         /// 得到所有气瓶型号
         /// </summary>
         /// <returns></returns>
         public IList GetAllCylinderType()
         {
             IList i = null;
             string sql = "from CylinderInfo u where u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         
    }
}
