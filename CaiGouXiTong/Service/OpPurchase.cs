using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using EntityClassLibrary;
using System.Collections;
using System.Data;

namespace CaiGouXiTong.Service
{
   public  class OpPurchase : BaseService
    { 
       /// <summary>
       /// 保存货物单
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
       public PurchasePlan SavePurchasePlan(PurchasePlan p)
       {
           
           BaseEntity returnpur; //= new PurchasePlan();
           
           if (p != null)
           {
               returnpur = this.SaveOrUpdateEntity(p);
               return returnpur as PurchasePlan;
           }
           else return null;
       }

       /// <summary>
       /// 保存货物条目
       /// </summary>
       /// <param name="pdet"></param>
       public void SavePurPlanDet(PurchasePlanDetail pdet)
       {
           if (pdet != null)
               this.SaveOrUpdateEntity(pdet);
       }

       /// <summary>
       /// 获取全部计划单
       /// </summary>
       /// <returns></returns>
       public IList GetAllPlan()
       {
           IList i;
           string sql = "from PurchasePlan u where u.State = " + (int)BaseEntity.stateEnum.Normal + 
               " and u.PurchasePlanState = 0 " +
               "  order by u.PurchasePlanState ASC ,u.PurchaseNeedTime DESC ";
           i = loadEntityList(sql);
           return i;
       }

       /// <summary>
       ///查询采购计划单 
       /// </summary>
       /// <param name="name"></param>
       /// <param name="t1"></param>
       /// <param name="t2"></param>
       /// <param name="t3"></param>
       /// <param name="t4"></param>
       /// <returns></returns>
       public IList Selectplans(string name,long t1,long t2,long t3,long t4, int state)
       {
           IList i = null;

           string sql = "from PurchasePlan u where u.State = " 
               + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchaseApplyTime>" + t1 + 
               " and u.PurchaseApplyTime < " + t2 + 
               " and u.PurchaseNeedTime>" + t3 + 
               " and u.PurchaseNeedTime < " + t4 +
               " and u.UserId.UserName like '%" + name + "%'"+
               " and u.PurchasePlanState = "+ state +
               " order by u.PurchasePlanState ASC ,u.PurchaseNeedTime DESC ";

           string sql2 = "from PurchasePlan u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.PurchaseApplyTime>" + t1 +
                " and u.PurchaseApplyTime < " + t2 +
                " and u.PurchaseNeedTime>" + t3 +
                " and u.PurchaseNeedTime < " + t4 +
                " and u.UserId.UserName like '%" + name + "%'" +
                
                " order by u.PurchasePlanState ASC ,u.PurchaseNeedTime DESC ";

           if(state == -1)
           {
               i = this.loadEntityList(sql2);
           }
           else
           {
               i = this.loadEntityList(sql);
           }

         
           return i;
       }

       /// <summary>
       /// 一张采购计划下的所有货物条目
       /// </summary>
       /// <param name="pp"></param>
       /// <returns></returns>
       public IList Getpurdet(PurchasePlan pp)
       {
           IList i = null;
           string sql = "from PurchasePlanDetail u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchasePlanId.Id = " + pp.Id +
               " order by u.PurchasePlanDetailState";

           i = loadEntityList(sql);
           
           return i;
       }
       /// <summary>
       /// 获取已经确认的货物
       /// </summary>
       /// <param name="pp"></param>
       /// <returns></returns>
       public IList GetQuerenDet(PurchasePlan pp)
       {
           IList i = null;
           string sql = "from PurchasePlanDetail u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchasePlanId.Id = " + pp.Id +
               " and u.PurchasePlanDetailState = "+(long)PurchasePlanDetail.PurplanDetSta.Queren+
               " order by u.PurchasePlanDetailState";
           i = loadEntityList(sql);

           return i;
       }


       /// <summary>
       /// 获取通过的计划
       /// </summary>
       /// <returns></returns>
       public IList GetShengchenJihua()
       {
           IList i;
           string sql = "from PurchasePlan u where u.State = "
               + (int)BaseEntity.stateEnum.Normal + 
               " and u.PurchasePlanState <> 0 "+
               " and u.PurchasePlanState <> 3" +
               "  order by u.PurchasePlanState ASC ,u.PurchaseNeedTime DESC ";

           i = loadEntityList(sql);
           return i;
       }


       /// <summary>
       /// 保存一张申请单并且返回生成的Id
       /// </summary>
       /// <param name="papp"></param>
       /// <returns></returns>
       public PurchaseApply SavePurchaseApply(PurchaseApply papp)
       {
           if (papp != null)
           {
               PurchaseApply retur = this.SaveOrUpdateEntity(papp) as PurchaseApply;
               return retur;
           }
           else return null;
       }
       public long GetGoodsQUantityByGoodaId(long id)
       {
           long num = -1;
           string sql = "select SUM(Stock.Quantity) from Stock where Stock.GoodsBaseInfoID = "+id+
               "  and Stock.State = 0 group by Stock.GoodsBaseInfoID";
          
           IList i = this.ExecuteSQL(sql);
           if (i != null && i.Count > 0)
           {
               Object[] obj = (object[])i[0];
               string a = obj[0].ToString();
               num = Convert.ToInt64(a);
               return num;
           }
           return num;
       }

       public IList GetAllPurapply()
       {
           IList i = null;
           string sql = "from PurchaseApply u where u.State = " + (int)BaseEntity.stateEnum.Normal + 
               " and u.PurchaseApplyState  <=1 " +
               " order by u.PurchaseApplyState ASC , u.PurchaseApplyTime DESC";
           i = this.loadEntityList(sql);
           return i;
       }

       public IList GetSelectpurapply(long t1, long t2,int state)
       {
           IList i = null;
           string sql = "from PurchaseApply u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchaseApplyTime >=" + t1 +
               " and u.PurchaseApplyTime < " + t2 +
               " order by u.PurchaseApplyState ASC , u.PurchaseApplyTime DESC";

           string sql2  = "from PurchaseApply u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchaseApplyTime >=" + t1 +
               " and u.PurchaseApplyTime < " + t2 +
               " and u.PurchaseApplyState = " + state +
               " order by u.PurchaseApplyState ASC , u.PurchaseApplyTime DESC";

           if (state == -1)
           {
               i = this.loadEntityList(sql);
               return i;
           }
           else
           {
               i = this.loadEntityList(sql2);
               return i;
           }
       }

       public IList GetpurapplydetByapply(PurchaseApply p)
       {
           IList i = null;
           string sql = "from PurchaseApplyDetail u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchaseApplyId.Id = " + p.Id +
               " order by u.PurchaseApplyDetailState";
           i = this.loadEntityList(sql);
           return i;
       }

       public IList GetAllPurapplyDet()
       {
           IList i = null;
           string sql = "from PurchaseApplyDetail u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchaseApplyDetailState >= 4 "+
               " and u.PurchaseApplyDetailState <= 5 " +
               " order by u.PurchaseApplyDetailState";

           i = this.loadEntityList(sql);
           return i;
       
       }

       public IList GetsuppsByGoodsIdInSupps_goods(long id)
       {
           IList i = null;
           string sql = "from Supplier_Goods u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.GoodsBaseInfoID.Id =  " + id +
               " order by u.Unit_Price";
           i = this.loadEntityList(sql);
           return i;
       }
       public IList GetselectPurappDet(string HetongBianhao, string goodsname, string goodscode, string suppname, int state)
       {

           IList i = null;

           string sql1 = 
               " select u from PurchaseApplyDetail u "+
               " left join u.GoodsBaseInfoId gb " + 
               " left join u.SupplierInfoId sup "+
               " left join u.PurchaseContractId pc"+
               " where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and gb.GoodsClassCode like '%" + goodscode + "%' " +
               " and gb.GoodsName like '%" + goodsname + "%'" +
               " and (sup.SupplierName like '%" + suppname + "%'" +
               " or u.SupplierInfoId is null)" + 
               " and (pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +
               " or u.PurchaseContractId  is  null) " +
               " and u.PurchaseApplyDetailState  = " + state +
               " order by u.PurchaseApplyDetailState";


           string sql2 =
               " select u from PurchaseApplyDetail u " +
               " left join u.GoodsBaseInfoId gb " +
               " left join u.SupplierInfoId sup " +
               " left join u.PurchaseContractId pc" +
               " where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and gb.GoodsClassCode like '%" + goodscode + "%' " +
               " and gb.GoodsName like '%" + goodsname + "%'" +
               " and (sup.SupplierName like '%" + suppname + "%'" +
               " or u.SupplierInfoId is null)" +
               " and (pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +
               " or u.PurchaseContractId  is  null) " +
               
               " order by u.PurchaseApplyDetailState";

           string sql3 =
             " select u from PurchaseApplyDetail u " +
             " left join u.GoodsBaseInfoId gb " +
             " left join u.SupplierInfoId sup " +
             " left join u.PurchaseContractId pc" +
             " where u.State = " + (int)BaseEntity.stateEnum.Normal +
             " and gb.GoodsClassCode like '%" + goodscode + "%' " +
             " and gb.GoodsName like '%" + goodsname + "%'" +
             " and sup.SupplierName like '%" + suppname + "%'" +
             
             " and (pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +
             " or u.PurchaseContractId  is  null) " +

             " order by u.PurchaseApplyDetailState";


           string sql4 =
              " select u from PurchaseApplyDetail u " +
              " left join u.GoodsBaseInfoId gb " +
              " left join u.SupplierInfoId sup " +
              " left join u.PurchaseContractId pc" +
              " where u.State = " + (int)BaseEntity.stateEnum.Normal +
              " and gb.GoodsClassCode like '%" + goodscode + "%' " +
              " and gb.GoodsName like '%" + goodsname + "%'" +
              " and (sup.SupplierName like '%" + suppname + "%'" +
              " or u.SupplierInfoId is null)" +
              " and pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +
              

              " order by u.PurchaseApplyDetailState";



           string sql5 =
              " select u from PurchaseApplyDetail u " +
              " left join u.GoodsBaseInfoId gb " +
              " left join u.SupplierInfoId sup " +
              " left join u.PurchaseContractId pc" +
              " where u.State = " + (int)BaseEntity.stateEnum.Normal +
              " and gb.GoodsClassCode like '%" + goodscode + "%' " +
              " and gb.GoodsName like '%" + goodsname + "%'" +
              " and sup.SupplierName like '%" + suppname + "%'" +
              
              " and pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +


              " order by u.PurchaseApplyDetailState";

           string sql6 =
               " select u from PurchaseApplyDetail u " +
               " left join u.GoodsBaseInfoId gb " +
               " left join u.SupplierInfoId sup " +
               " left join u.PurchaseContractId pc" +
               " where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and gb.GoodsClassCode like '%" + goodscode + "%' " +
               " and gb.GoodsName like '%" + goodsname + "%'" +
               " and (sup.SupplierName like '%" + suppname + "%'" +
               " or u.SupplierInfoId is null)" +
               " and (pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +
               " or u.PurchaseContractId  is  null) " +
               " and u.PurchaseApplyDetailState  = " + state + 
               " order by u.PurchaseApplyDetailState";

           string sql7 =
               " select u from PurchaseApplyDetail u " +
               " left join u.GoodsBaseInfoId gb " +
               " left join u.SupplierInfoId sup " +
               " left join u.PurchaseContractId pc" +
               " where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and gb.GoodsClassCode like '%" + goodscode + "%' " +
               " and gb.GoodsName like '%" + goodsname + "%'" +
               " and sup.SupplierName like '%" + suppname + "%'" +
          
               " and pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +
              
               " and u.PurchaseApplyDetailState  = " + state +
               " order by u.PurchaseApplyDetailState";

           string sql8 =
               " select u from PurchaseApplyDetail u " +
               " left join u.GoodsBaseInfoId gb " +
               " left join u.SupplierInfoId sup " +
               " left join u.PurchaseContractId pc" +
               " where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and gb.GoodsClassCode like '%" + goodscode + "%' " +
               " and gb.GoodsName like '%" + goodsname + "%'" +
               " and sup.SupplierName like '%" + suppname + "%'" +
               
               " and (pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +
               " or u.PurchaseContractId  is  null) " +
               " and u.PurchaseApplyDetailState  = " + state +
               " order by u.PurchaseApplyDetailState";

           string sql9 =
               " select u from PurchaseApplyDetail u " +
               " left join u.GoodsBaseInfoId gb " +
               " left join u.SupplierInfoId sup " +
               " left join u.PurchaseContractId pc" +
               " where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and gb.GoodsClassCode like '%" + goodscode + "%' " +
               " and gb.GoodsName like '%" + goodsname + "%'" +
               " and (sup.SupplierName like '%" + suppname + "%'" +
               " or u.SupplierInfoId is null)" +
               " and pc.PurchaseContractCode like '%" + HetongBianhao + "%'" +
               
               " and u.PurchaseApplyDetailState  = " + state +
               " order by u.PurchaseApplyDetailState";


           if ((state == 3 || state == 11) && HetongBianhao == "" && suppname == "") // 按照状态选择全部
           {
               i = this.loadEntityList(sql2);
           }

           else if ((state == 3 || state == 11) && HetongBianhao == "" && suppname != "")//
           {
               i = this.loadEntityList(sql3);
           }
           else if ((state == 3 || state == 11) && HetongBianhao != "" && suppname == "")
           {
               i = this.loadEntityList(sql4);
           }
           else if ((state == 3 || state == 11) && HetongBianhao != "" && suppname != "")
           {
               i = this.loadEntityList(sql5);
           }


           else if(state != 3&&state != 11&& HetongBianhao == "" && suppname != "")
           {

               i = this.loadEntityList(sql8);
           
           }
           else if (state != 3 && state != 11 && HetongBianhao != "" && suppname != "")
           {
               i = this.loadEntityList(sql7);
           }
           else if (state != 3 && state != 11 && HetongBianhao != "" && suppname == "")
           {
               i = this.loadEntityList(sql9);
           }


           else if (state != 3 && state != 11 && HetongBianhao == "" && suppname == "")
           {
               i = this.loadEntityList(sql6);
           }

           return i;
       }

       public IList GetWaitSuppsByPurappDetId(long id)
       {

           IList i = null;
           string sql = "from WaitChooseSuppliers u where u.State = " + (int)BaseEntity.stateEnum.Normal +
                        " and u.PurchaseApplyDetailId.Id = " + id +
                        " order by u.Money";

           i = this.loadEntityList(sql);
           return i;
       }

       public DataSet GetpurSupps()
       {
           
           DataSet i = null;
           string sql = "select sup.supid as Id, SupplierInfo.SupplierName as Name from SupplierInfo , " +
                        "(select PurchaseApplyDetail.SupplierInfoId as supid from PurchaseApplyDetail where PurchaseApplyDetail.State = 0 and  " +
                        "PurchaseApplyDetail.PurchaseApplyDetailState = 6 group by PurchaseApplyDetail.SupplierInfoId) sup where sup.supid = SupplierInfo.Id;";
           i = this.ExecuteSQLReturnDataSet(sql);
           return i;
       }

       public IList GetselectPurappBySuppID(long id)
       {
           IList i = null;
           string sql = "from PurchaseApplyDetail u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.SupplierInfoId.Id = " + id +
               " and u.PurchaseApplyDetailState  = 6 ";
              
           i = this.loadEntityList(sql);
           return i;
       }


       public IList GetAllpurCont()
       {
           IList i = null;
           string sql = "from PurchaseContract u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchaseContractState = 0" +
               " order by u.PurchaseContractState ASC ,u.PurchaseContractTime DESC";
           i = this.loadEntityList(sql);
           return i;
       }

       public IList GetSelectCont(string code,string supps,int state)
       {

           IList i = null;
           string sql = "from PurchaseContract u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.SupplierInfoId.SupplierName like '%" +supps+"%'"+
               " and u.PurchaseContractCode like '%"+code+"%'"+
               " order by u.PurchaseContractState ASC ,u.PurchaseContractTime DESC";


           string sql2 = "from PurchaseContract u where u.State = " + (int)BaseEntity.stateEnum.Normal +
              " and u.SupplierInfoId.SupplierName like '%" + supps + "%'" +
              " and u.PurchaseContractCode like '%" + code + "%'" +
              " and u.PurchaseContractState = "+state+
              " order by u.PurchaseContractState ASC ,u.PurchaseContractTime DESC";


           if (state == -1)
           {
               i = this.loadEntityList(sql);
           }
           else
           {
               i = this.loadEntityList(sql2);
           }

           
           return i;
       
       }


       public IList GetPurappByPurConID(long id)
       {


           //IList i = null;
           //string sql = "from PurchaseApplyDetail u where u.State = " + (int)BaseEntity.stateEnum.Normal +
           //    " and u.PurchaseContractId.PurchaseContractCode like '%" + code + "%' " +
           //    " and u.GoodsBaseInfoId.GoodsName like '%" + goodsname + "%'" +
           //    " and u.SupplierInfoId.SupplierName like '%" + suppname + "%'" +
           //    " and u.PurchaseContractId.PurchaseContractCode like '%" + HetongBianhao + "%'" +
           //    " order by u.Unit_Price";
           //i = this.loadEntityList(sql);
           //return i;

           IList i = null;

           string sql = "from PurchaseApplyDetail u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchaseContractId.Id = " + id +
               " and u.PurchaseApplyDetailState  >= 6 ";
           i = this.loadEntityList(sql);

           return i;
       }

       public IList GetsgoodsBySuppsIdInSupps_goods(long id)
       {
           IList i = null;
           string sql = "from Supplier_Goods u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.SupplierInfoId.Id =  " + id +
               " order by u.Unit_Price";
           i = this.loadEntityList(sql);
           return i;
       }

       public IList GetSelectsgoodsBySuppsIdInSupps_goods(long id , string name ,string code,long t1,long t2)
       {
           IList i = null;
           string sql = "from Supplier_Goods u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.SupplierInfoId.Id =  " + id +
               " and u.GoodsBaseInfoID.GoodsClassCode like '%"+code+"%'"+
               " and u.GoodsBaseInfoID.GoodsName like '%"+name+"%'"+ 
               " and u.Date > "+t1+
               " and u.Date < "+t2+
               " order by u.Date DESC";

           i = this.loadEntityList(sql);
           return i;
       }


       public IList GetcreditFromsuppcreBySuppid(long id)
       {
           IList i = null;
           string sql = "from SupplierCreditRecord u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.SupplierInfoId.Id =  " + id;
           i = this.loadEntityList(sql);
           return i;
       }

       public IList GetAllTransportCon()
       {
           IList i = null;

           string sql = "from TransportContract u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " order by u.ReceivedTime DESC";
               
           i = this.loadEntityList(sql);
           return i;
       
       }

       public IList GetSelecttranssport(string send,string code , long t1,long t2)
       {
           IList i = null;

           string sql = "from TransportContract u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.TransportContractNum like '%" + code + "%'" +
               " and u.SendCategory like '%" + send + "%'" +
               " and u.ReceivedTime >=" +t1+
               " and u.ReceivedTime <=" + t2 +
               " order by u.ReceivedTime DESC";
           i = this.loadEntityList(sql);
           return i;
       }

       public IList GetPurdetinWaitsuppsBypurdet(PurchaseApplyDetail purder)
       {
           IList i = null;

           string sql = "from WaitChooseSuppliers u where u.State = " + (int)BaseEntity.stateEnum.Normal +
               " and u.PurchaseApplyDetailId.Id = " + purder.Id;
               
           i = this.loadEntityList(sql);
           return i;
       
       }

    }
}
