using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;


namespace CommonWindow.Service
{
   
    class Categtory : BaseService
    {

      

        /// <summary>
        /// 插入一天条数据
        /// </summary>
        /// <param name="state"></param>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="specifications"></param>
        /// <param name="unit"></param>
        /// <param name="goodsParentClassName"></param>
        /// <param name="goodsClassOrder"></param>
        /// <param name="goodsClassLevel"></param>
        /// <param name="goodsClassDescribe"></param>
       /*
        public void InsertCategory(int state, string name, string code, string specifications, string unit,string goodsParentClassName, int goodsClassOrder, string goodsClassLevel, string goodsClassDescribe)
        {
           
            try
            {
                EntityClassLibrary.GoodsBaseInfo g = new GoodsBaseInfo();

                if (specifications != "" && unit != "")
                {
                    g.GoodsName = name;
                    g.GoodsClassCode = code;

                    g.Unit = unit;
                    g.Specifications = specifications;

                    g.GoodsClassDescribe = goodsClassDescribe;
                    g.GoodsClassLevel = long.Parse(goodsClassLevel);
                    g.GoodsClassOrder = goodsClassOrder;
                    g.GoodsParentClassId = GetparentByPName(goodsParentClassName).Id;
                    g.GoodsFlag = state;
                }
                else 
                {
                    g.GoodsName = name;
                    g.GoodsClassCode = code;

                    g.Unit = null;
                    g.Specifications = null;

                    g.GoodsClassDescribe = goodsClassDescribe;
                    g.GoodsClassLevel = long.Parse(goodsClassLevel);
                    g.GoodsClassOrder = goodsClassOrder;
                    g.GoodsParentClassId = GetparentByPName(goodsParentClassName).Id;
                    g.GoodsFlag = state;
                }
                this.SaveOrUpdateEntity(g);
               
            }
            catch (Exception e)
            {   
                throw e;
            }
        }
        */

        /// <summary>
        /// 有货物名称获取Id号
        /// </summary>
        /// <param name="goodsParentClassName"></param>
        /// <returns></returns>
        public GoodsBaseInfo GetClassByPcode(string goodsParentCode)
        {
            GoodsBaseInfo gg = null;
            string sql = "from GoodsBaseInfo u where u.GoodsClassCode=" + "'" + goodsParentCode + "'" + " and u.State=" + (int)BaseEntity.stateEnum.Normal;
            IList parent = this.loadEntityList(sql);
            if (parent != null && parent.Count > 0)
            {
                gg = (GoodsBaseInfo)parent[0];
                return gg;
            }
            else
            {
                return gg;
            }
        }

        public IList GetAllCategtory()
        {
            string sql = "from GoodsBaseInfo u where u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.GoodsClassLevel,u.GoodsClassOrder";
            return this.loadEntityList(sql); 
        }
        public GoodsBaseInfo GetParent(long pId)
        {
            string sql = "from GoodsBaseInfo u where u.Id = " + pId + "and u.State = " + (int)BaseEntity.stateEnum.Normal;
            IList parent = this.loadEntityList(sql);
            if (parent != null && parent.Count > 0)
            {
                return (GoodsBaseInfo)parent[0];
            }
            else
            {
                return null;
            }
        }

        public long GetClassLenelByParId(long pId )
        {
            long level = -1;
            string sql = "from GoodsBaseInfo u where u.Id = " + pId + "and u.State = " + (int)BaseEntity.stateEnum.Normal;
            IList parent = this.loadEntityList(sql);
            if (parent != null && parent.Count > 0)
            {
                GoodsBaseInfo pn = (GoodsBaseInfo)parent[0];
                level = pn.GoodsClassLevel;
                return level;
            }
            else
            {
                return level;
            }
        
        }
        public IList GetTheLevelGoods(long Level)
        {
            IList TheLevellist = null;
            string sql = "from GoodsBaseInfo u  where u.GoodsClassLevel = " + Level + "and u.State = " + (int)BaseEntity.stateEnum.Normal;
            TheLevellist = this.loadEntityList(sql);
            if (TheLevellist != null && TheLevellist.Count > 0)
            {
                return TheLevellist;

            }
            else 
            {
                return TheLevellist;
            }
         
        }

        public IList GetAllCategtoryCalss()
        {
            string sql = "from GoodsBaseInfo u where u.GoodsFlag <> "+2+"and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.GoodsClassLevel,u.GoodsClassOrder";
            IList AllLevel = this.loadEntityList(sql);
            if (AllLevel != null && AllLevel.Count > 0)
            {
                return AllLevel;
            }
            else
            {
                AllLevel = null;
                return AllLevel;
            }
        }

        public string GetGnameByCode(string code)
        {
            string sql = "from GoodsBaseInfo u where u.GoodsClassCode = " + "'" + code + "'" + " and u.State = " + (int)BaseEntity.stateEnum.Normal; ;
            IList goods = this.loadEntityList(sql);
            if (goods != null && goods.Count > 0)
            {
                string str = ((GoodsBaseInfo)goods[0]).GoodsName;
                return str;
            }
            else
            {
                return "";
            }
        
        }
        public IList GetTheSamePidGoodsByPid(long pid)
        {
            string sql = "from GoodsBaseInfo u where u.GoodsParentClassId = " + pid + " and u.State = " + (int)BaseEntity.stateEnum.Normal; ;

            IList goods = this.loadEntityList(sql);

            if (goods != null && goods.Count > 0)
                return goods;
            else 
                return null;
        }

        public void RemoveGoods(GoodsBaseInfo gg)
        {
           if(gg!= null)
            this.deleteEntity(gg);
        }
        public void RemoveGoods(long id)
        {
            this.deleteEntity(this.GetParent(id));
        }

        public GoodsBaseInfo GetCategoryById(long id)
        {
            GoodsBaseInfo gg = new GoodsBaseInfo();
            string sql = "from GoodsBaseInfo u where u.Id = " + id + "and u.State = " + (int)BaseEntity.stateEnum.Normal;
            gg = this.loadEntityList(sql)[0] as GoodsBaseInfo;
            return gg;
        }
      

    }
}
