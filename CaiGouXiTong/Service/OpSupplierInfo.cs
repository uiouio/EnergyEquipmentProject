using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;

namespace CaiGouXiTong.Service
{
   public class OpSupplierInfo : BaseService
    {
        SupplierInfo ss = new SupplierInfo();

        public void SaveNewSupplier(SupplierInfo ss)
        {
            this.SaveOrUpdateEntity(ss);
        }

        public IList GetAllSupplier()
        {
            IList suppliers = null;

            string sql = "from SupplierInfo u where u.State = " + (int)BaseEntity.stateEnum.Normal;
            suppliers = this.loadEntityList(sql);

            if (suppliers.Count > 0 && suppliers != null)
            {
                return suppliers;
            }
            else { return null;}
        }

        public void RemoveSupplier(SupplierInfo ss)
        {
            if(ss!=null)
            this.deleteEntity(ss);
        }

        public IList FuzzySelectByName(string str)
        {
            IList i = null;
            string sql = "from SupplierInfo u where u.SupplierName like " + "'%" + str + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
        public IList FuzzySelectByNameAndCname(string name,string cname)
        {
            IList i = null;
            string sql = "from SupplierInfo u where u.SupplierName like " + "'%" + name + "%' and u.SupplierContactMan like "+ "'%"+cname+"%'"+" and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
        public IList FuzzySelectBycName(string str)
        {
            IList i = null;
            string sql = "from SupplierInfo u where u.SupplierContactMan like " + "'%" + str + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }

    }
}
