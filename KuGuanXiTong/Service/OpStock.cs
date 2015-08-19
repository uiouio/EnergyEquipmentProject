using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using EntityClassLibrary;
using System.Collections;

namespace KuGuanXiTong.Service
{
    public class OpStock : BaseService
    {
        public IList GetAllStock()
        {
            IList i = null;

            string sql = "select GoodsBaseInfo.GoodsClassCode," +
            "GoodsBaseInfo.GoodsName,GoodsBaseInfo.Specifications,GoodsBaseInfo.Unit,GoodsBaseInfo.Material," +
            " t.* from (select GoodsBaseInfoID, " +
            " SUM(Quantity) as Quan, sum([Money])/COUNT(*) as MM, " +
            " sum(StorehouseplaceCode)/COUNT(*) as SS from Stock " +
            "where State = 0 group by GoodsBaseInfoID) t left join GoodsBaseInfo on " +
            "  t.GoodsBaseInfoID = GoodsBaseInfo.Id";

            i = this.ExecuteSQL(sql);
            return i;
        }

        public IList GetQuerryStock(string code,string name)
        {
            IList i = null;
            string sql = "select * from (select GoodsBaseInfo.GoodsClassCode,GoodsBaseInfo.GoodsName,"+
                "GoodsBaseInfo.Specifications,"+
           " GoodsBaseInfo.Unit,GoodsBaseInfo.Material,t.* from (select GoodsBaseInfoID," +
            " SUM(Quantity) as Quan, sum([Money])/COUNT(*) as MM, " +
            "sum(StorehouseplaceCode)/COUNT(*) as SS from Stock where State = 0 "+
            " group by GoodsBaseInfoID) t left join GoodsBaseInfo on t.GoodsBaseInfoID "+
           " = GoodsBaseInfo.Id) a where GoodsName like " + "'%" + name + "%'" + " and GoodsClassCode like "+"'%"+code+"%'";
            i = this.ExecuteSQL(sql);
            return i;
        }
        public IList GetQuerryStockBySpecifications(string code, string name)
        {
            IList i = null;
            string sql = "select * from (select GoodsBaseInfo.GoodsClassCode,GoodsBaseInfo.GoodsName," +
                "GoodsBaseInfo.Specifications," +
           " GoodsBaseInfo.Unit,GoodsBaseInfo.Material,t.* from (select GoodsBaseInfoID," +
            " SUM(Quantity) as Quan, sum([Money])/COUNT(*) as MM, " +
            "sum(StorehouseplaceCode)/COUNT(*) as SS from Stock where State = 0 " +
            " group by GoodsBaseInfoID) t left join GoodsBaseInfo on t.GoodsBaseInfoID " +
           " = GoodsBaseInfo.Id) a where Specifications like " + "'%" + name + "%'" + " and GoodsClassCode like " + "'%" + code + "%'";
            i = this.ExecuteSQL(sql);
            return i;
        }
        public IList GetCategtoryBranching(long id, string name ,string code)
        {
            IList i = null;

            string sql = "with cte as  " +
                        "(" +
                        " select a.* from GoodsBaseInfo a where id =  "+id+
                        "union all " +
                        "select k.* from GoodsBaseInfo k inner join cte c on c.Id = k.GoodsParentClassId" +
                        ") select * from (select g.* ,GoodsBaseInfo.GoodsName as gpname from  " +
                        "(select m.GoodsClassCode as gcode,m.GoodsName as gname ,m.Specifications as gsp,m.Material as gma ,m.Unit " +
                        " as gunit,m.GoodsParentClassId as gpid,t.Quan as gquan ,m.Id as gid from "+
                        " (select cte.* from cte where cte.State = 0 and cte.GoodsFlag <>1) m left join " +
                        "(select GoodsBaseInfoID, SUM(Quantity) as Quan, sum([Money])/COUNT(*) as MM, " + 
                        "sum(StorehouseplaceCode)/COUNT(*) as SS from Stock where State = 0 group by GoodsBaseInfoID) t on  t.GoodsBaseInfoID = m.Id ) g , " +
                        " GoodsBaseInfo where g.gpid = GoodsBaseInfo.Id) gg where gg.gname like '%" + name + "%' and gg.gcode like '%" + code + "%'";

            i = this.ExecuteSQL(sql);

            return i;
        
        }


        public Stock GetStockByGoodsInfoId(long id)
        { 
            IList i ;
            string sql = "from Stock u where u.GoodsBaseInfoID = " + id + 
                " and u.State = " + (int)BaseEntity.stateEnum.Normal + 
                " order by u.GoodsCode DESC";
            
            i = this.loadEntityList(sql);

            if (i.Count > 0 && i != null)
            {
                return (Stock)i[0];
            }
            else return null;
        }

        public StockOperation SaveStockOperation(StockOperation sop)
        {
            StockOperation bas = new StockOperation();
            if (sop != null)
            {
                bas = this.SaveOrUpdateEntity(sop) as StockOperation;
                return bas;
            }
            else return null;
        }

        public IList GetAllOpsIn()
        {
            IList i;
            string sql = "from StockOperation u  where u.IOFlag = 0 and u.State = " + (int)BaseEntity.stateEnum.Normal +
                " and u.OperationTime >" +DateTime.Now.Date.AddDays(-1).Ticks + 
                " order by u.Id DESC";
            i = this.loadEntityList(sql);
            return i;
        }

        public IList GetOpdetail(long id)
        {
            IList i = null;
            string sql = "from StockOperationDetail u where u.StockOperationId = " + id + 
                "and u.State =" + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            
            return i;
        }

        public IList SelectOpdetail(string num, long id, long t1,long t2 )
        {

            IList i = null;
            string sql;
            if (id != 0)
            {
                 sql = "from StockOperation u where u.SupplierInfoId = " + id + 
                     " and u.RetrospectListNumber like '%" + num + "%'" + 
                     " and u.OperationTime>=" + t1 + " and u.OperationTime<" + t2 + 
                     " and u.State =" + (int)BaseEntity.stateEnum.Normal +
                      " order by u.OperationTime DESC";
            }
            else 
            {
                sql = "from StockOperation u where u.RetrospectListNumber like '%" + num + "%'" + 
                    " and u.OperationTime>=" + t1 + 
                    " and u.OperationTime<" + t2 + 
                    " and u.State =" + (int)BaseEntity.stateEnum.Normal+
                    "  order by u.OperationTime DESC";
            }

            i = this.loadEntityList(sql);

            return i;
        }

        public IList SelectChukuDetailForTongJi(long t1 ,long t2,string name, string code,long optype)
        {
            IList i = null;
            string sql = "from StockOperationDetail u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.StockOperationId.OperationTime>" + t1 +
                " and u.StockOperationId.OperationTime<" + t2 +
                " and u.StockId.GoodsBaseInfoID.GoodsClassCode like '%" + code + "%'"+
                " and u.StockOperationId.OperationTpye = " + optype +
                " and u.StockId.GoodsBaseInfoID.GoodsName like '%" + name + "%'"+
                " order by  u.StockOperationId.OperationTime DESC , u.StockOperationId.Id ASC "; 

            string sql2 = "from StockOperationDetail u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.StockOperationId.OperationTime>" + t1 +
                " and u.StockOperationId.OperationTime<" + t2 +
                " and u.StockId.GoodsBaseInfoID.GoodsClassCode like '%" + code + "%'" +
                " and u.StockOperationId.OperationTpye <> 0" +
                " and u.StockId.GoodsBaseInfoID.GoodsName like '%" + name + "%' "+
                " order by u.StockOperationId.OperationTime DESC,u.StockOperationId.Id ASC";

            if (optype > 0)
                i = this.loadEntityList(sql);
            else
                i = this.loadEntityList(sql2);
            return i;
        }

        public IList SelectChukuDetailForTongJiBySpecifition(long t1, long t2, string name, string code, long optype)
        {
            IList i = null;
            string sql = "from StockOperationDetail u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.StockOperationId.OperationTime>" + t1 +
                " and u.StockOperationId.OperationTime<" + t2 +
                " and u.StockId.GoodsBaseInfoID.GoodsClassCode like '%" + code + "%'" +
                " and u.StockOperationId.OperationTpye = " + optype +
                " and u.StockId.GoodsBaseInfoID.Specifications like '%" + name + "%'" +
                " order by  u.StockOperationId.OperationTime DESC , u.StockOperationId.Id ASC ";

            string sql2 = "from StockOperationDetail u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.StockOperationId.OperationTime>" + t1 +
                " and u.StockOperationId.OperationTime<" + t2 +
                " and u.StockId.GoodsBaseInfoID.GoodsClassCode like '%" + code + "%'" +
                " and u.StockOperationId.OperationTpye <> 0" +
                " and u.StockId.GoodsBaseInfoID.Specifications like '%" + name + "%' " +
                " order by u.StockOperationId.OperationTime DESC,u.StockOperationId.Id ASC";

            if (optype > 0)
                i = this.loadEntityList(sql);
            else
                i = this.loadEntityList(sql2);
            return i;
        }


        /// <summary>
        /// 查询入库统计信息
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="suppid"></param>
        /// <returns></returns>
        public IList SelectRukuDetailForTongJi(long t1, long t2, string name, string code, long suppid)
        {
            IList i = null;
            string sql = "from StockOperationDetail u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.StockOperationId.OperationTime>" + t1 +
                " and u.StockOperationId.OperationTime<" + t2 +
                " and u.StockId.GoodsBaseInfoID.GoodsClassCode like '%" + code + "%'" +
                " and u.StockOperationId.SupplierInfoId.Id = " + suppid +
                " and u.StockId.GoodsBaseInfoID.GoodsName like '%" + name + "%' order by u.StockOperationId.Id ASC ,  u.StockOperationId.OperationTime DESC ";

            string sql2 = "from StockOperationDetail u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.StockOperationId.OperationTime>" + t1 +
                " and u.StockOperationId.OperationTime<" + t2 +
                " and u.StockId.GoodsBaseInfoID.GoodsClassCode like '%" + code + "%'" +
                " and u.StockId.GoodsBaseInfoID.GoodsName like '%" + name + "%' order by u.StockOperationId.Id , u.StockOperationId.OperationTime DESC  ";

            if (suppid != 0)
                i = this.loadEntityList(sql);
            else
                i = this.loadEntityList(sql2);
            return i;
        }

        /// <summary>
        /// 进入界面时候获取前一天入库的信息
        /// </summary>
        /// <returns></returns>
        public IList GetRukuDetailForTongJi()
        {
            IList i = null;
            string sql = "from StockOperationDetail u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.StockOperationId.OperationTime >" + DateTime.Now.Date.AddDays(-1).Ticks +
                " and u.StockOperationId.OperationTpye = 0" +
                " order by  u.StockOperationId.OperationTime DESC , u.StockOperationId.Id ASC  ";
                i = this.loadEntityList(sql);
            return i;
        }

        /// <summary>
        /// 进入界面时候获取前一天的出库信息
        /// </summary>
        /// <returns></returns>
        public IList GetChuKuDetailForTongJi()
        {
            IList i = null;
            string sql = "from StockOperationDetail u where u.State = "
                + (int)BaseEntity.stateEnum.Normal +
                " and u.StockOperationId.OperationTime >" + DateTime.Now.Date.AddDays(-1).Ticks +
                " and u.StockOperationId.OperationTpye <> 0" +
                " order by  u.StockOperationId.OperationTime DESC , u.StockOperationId.Id ASC  ";
            i = this.loadEntityList(sql);
            return i;
        }



        /// <summary>
        /// 通过条码获取库存信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Stock GetStockByGoodsCode(string code )
        {

            IList i;
            string sql = "from Stock u where u.GoodsCode  = "
                + "'"+code+"' " + " and u.State = " + (int)BaseEntity.stateEnum.Normal;

            i = this.loadEntityList(sql);
            
            if (i.Count > 0 && i != null)
            {
                return (Stock)i[0];
            }
            else return null;
        }

        /// <summary>
        /// 模糊条码信息获取条码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IList GetStockByMoHuGoodsCode(string code)
        {

            IList i = null;;
            string sql = "from Stock u where u.GoodsCode  like "
                + "'%" + code + "%' "
                + " and u.State = " + (int)BaseEntity.stateEnum.Normal;

            i = this.loadEntityList(sql);

            return i;
         
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList GetGaiZhuangDanByCode(string code)
        {

            IList i = null; ;
            string sql = "from StockOperationDetail u where u.GoodsCode  like "
                + "'%" + code + "%' "
                + " and u.State = " + (int)BaseEntity.stateEnum.Normal;

            i = this.loadEntityList(sql);

            return i;
        
        }

        
    }
}
