using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider;
using EntityClassLibrary;
using System.Collections;

namespace CommonWindow.Service
{
     public  class CustomInfoService:SQLProvider.Service.BaseService
    {
         public IList SelectByNameAndCname(string name, string cname)
         {
             IList i = null;
             string sql = "from CustomBaseInfo u where u.Status="+(int)CustomBaseInfo.PersonalOrCompany.Personal+" and u.Name like " + "'%" + name + "%' and u.IdentifyCardNo like " + "'%" + cname + "%'" + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         public IList SelectCompanyCustom(string name, string cname)
         {
             IList i = null;
             string sql = "from CustomBaseInfo u where u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company + " and u.Name like " + "'%" + name + "%' and u.IdentifyCardNo like " + "'%" + cname + "%'" + " and u.State = " + (int)BaseEntity.stateEnum.Normal;
             i = this.loadEntityList(sql);
             return i;
         }
         public IList GetAllPersonal()
         {
             IList custom = null;
             string sql = "from CustomBaseInfo u where u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Personal + "  and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             custom = this.loadEntityList(sql);

             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }
         public IList GetAllCompany()
         {
             IList custom = null;
             string sql = "from CustomBaseInfo u where u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company + "  and  u.State = " + (int)BaseEntity.stateEnum.Normal;
             custom = this.loadEntityList(sql);

             if (custom.Count > 0 && custom != null)
             {
                 return custom;
             }
             else { return null; }
         }

    }
}
