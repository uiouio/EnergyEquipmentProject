using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class  TemplateManager:BaseEntity
    {

        public TemplateManager()
        {
            itself = this;
        }
        private TemplateManager itself;
        public virtual TemplateManager Itself
        {
            get { return itself; }
           
        }
        /// <summary>
        /// 模板名称
        /// </summary>
        
        private    string     templateName ;

   public virtual string TemplateName
          {  
                     get { return templateName; }
                       set { templateName = value; }
  }


        /// <summary>
        /// 模板类型
        /// </summary>

   private int templateType;

   public virtual int TemplateType
   {
       get { return templateType; }
       set { templateType = value; }
   }

        /// <summary>
        /// 制作人
        /// </summary>
   

   private UserInfo userID;

   public virtual UserInfo UserID
   {
       get { return userID; }
       set { userID = value; }
   }
  


       

        /// <summary>
        /// 最近修改时间
        /// </summary>

   private long time;

   public virtual  long Time
   {
       get { return time; }
       set { time = value; }
   }
        /// <summary>
        /// 备注
        /// </summary>


   private string remark;

   public virtual string Remark
   {
       get { return remark; }
       set { remark = value; }
   }





        /// <summary>
        /// 合同内容
        /// </summary>

   private string contents;

   public virtual string Contents
   {
       get { return contents; }
       set { contents = value; }
   }

        /// <summary>
        /// 合同类型  枚举
        /// </summary>


   public enum type
   { 

       gz = 0,
       tj = 1



   }
     public static string[] MuBanType = { "改装类合同", "套件类合同"};


    }
}
