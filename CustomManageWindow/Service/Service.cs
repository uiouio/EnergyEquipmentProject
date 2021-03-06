﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider;
using EntityClassLibrary;
using System.Collections;
using SQLProvider.Service;
using System.Windows.Forms;
namespace CustomManageWindow.Service
{
    public class CustomService : BaseService
    {
        public void Save(BaseEntity enty)
        {
            this.SaveOrUpdateEntity(enty);
        }
        public IList GetAllCar()
        {
            IList custom = null;
            string sql = "from CarBaseInfo u where u.State = " + (int)BaseEntity.stateEnum.Normal;
            custom = this.loadEntityList(sql);

            if (custom.Count > 0 && custom != null)
            {
                return custom;
            }
            else { return null; }
        }
        public IList GetAllPersonal()
        {
            IList custom = null;
            string sql = "from CustomBaseInfo u where u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Personal + "  and  u.State = " + (int)BaseEntity.stateEnum.Normal+ " order by u.RegistrationTime DESC";
            custom = this.loadEntityList(sql);

            if (custom.Count > 0 && custom != null)
            {
                return custom;
            }
            else { return null; }
        }
        public IList GetAllAgent()
        {
            IList custom = null;
            string sql = "from Agent u where  u.State = " + (int)BaseEntity.stateEnum.Normal;
            custom = this.loadEntityList(sql);

            if (custom.Count > 0 && custom != null)
            {
                return custom;
            }
            else { return null; }
        }
        public IList GetAllAgentPlan()
        {
            IList custom = null;
            string sql = "from Agent u where u.PlanFlag="+(int)Agent.chehaveplan.Yes+" and u.State = " + (int)BaseEntity.stateEnum.Normal;
            custom = this.loadEntityList(sql);

            if (custom.Count > 0 && custom != null)
            {
                return custom;
            }
            else { return null; }
        }
        public IList GetAllHuiYuan()
        {
            IList custom = null;
            string sql = "from HuiYuanBaseInfo u where  u.State = " + (int)BaseEntity.stateEnum.Normal;
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
            string sql = "from CustomBaseInfo u where  u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company +" and u.State = " + (int)BaseEntity.stateEnum.Normal;
            custom = this.loadEntityList(sql);

            if (custom.Count > 0 && custom != null)
            {
                return custom;
            }
            else { return null; }
        }
        
        public IList GetCustomCar()
        {
            IList custom = null;
            string sql = "from CustomBaseInfo u where u.State=" + (int)BaseEntity.stateEnum.Normal;
            custom = this.loadEntityList(sql);

            if (custom.Count > 0 && custom != null)
            {
                return custom;
            }
            else { return null; }
        }
        public IList GetPersonalCar()
        {
            IList custom = null;
            string sql = "select u from CarBaseInfo u left join u.Cbi c where c.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Personal + " and  u.State=" + (int)BaseEntity.stateEnum.Normal + "order by c.RegistrationTime DESC";
            custom = this.loadEntityList(sql);

            if (custom.Count > 0 && custom != null)
            {
                return custom;
            }
            else { return null; }
        }
        public IList GetCompanyCar()
        {
            IList custom = null;
            string sql = "select u from CarBaseInfo u left join u.Cbi c where c.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company + " and  u.State=" + (int)BaseEntity.stateEnum.Normal;
            custom = this.loadEntityList(sql);

            if (custom.Count > 0 && custom != null)
            {
                return custom;
            }
            else { return null; }
        }
        public void RemoveCustom(CustomBaseInfo cb)
        {
            if (cb != null)
                this.deleteEntity(cb);
        }
        public void RemoveCar(CarBaseInfo cb)
        {
            if (cb != null)
                this.deleteEntity(cb);
        }
        public void RemoveAgent(Agent cb)
        {
            if (cb != null)
                this.deleteEntity(cb);
        }
        public void RemoveHuiYuan(HuiYuanBaseInfo cb)
        {
            if (cb != null)
                this.deleteEntity(cb);
        }

        public IList SelectByNameAndCname(string name, string cname)
        {
            IList i = null;
            string sql = "from CustomBaseInfo u where u.Name like " + "'%" + name + "%' and u.IdentifyCardNo like " + "'%" + cname + "%' and u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Personal + "  and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.RegistrationTime DESC";
            i = this.loadEntityList(sql);
            return i;
        }
        /// <summary>
        /// 查询意向客户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cname"></param>
        /// <returns></returns>
        public IList SelectIntendCustom(string name, string cname)
        {
            IList i = null;
            string sql = "from CustomBaseInfo u where u.Name like " + "'%" + name + "%' and u.IdentifyCardNo like " + "'%" + cname + "%' and u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Personal + " and u.Category=" + (int)CustomBaseInfo.kehuleibie.yixiangkehu + " and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.RegistrationTime DESC";
            i = this.loadEntityList(sql);
            return i;
        }
        /// <summary>
        /// 查询正式客户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cname"></param>
        /// <returns></returns>
        public IList SelectFormalCustom(string name, string cname)
        {
            IList i = null;
            string sql = "from CustomBaseInfo u where u.Name like " + "'%" + name + "%' and u.IdentifyCardNo like " + "'%" + cname + "%' and u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Personal + " and u.Category=" + (int)CustomBaseInfo.kehuleibie.zhenshikehu + " and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.RegistrationTime DESC";
            i = this.loadEntityList(sql);
            return i;
        }
        public IList SelectAgents(string name, string cname)
        {
            IList i = null;
            string sql = "from Agent u where u.AgentName like " + "'%" + name + "%' and u.ContactName like " + "'%" + cname + "%'  and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
        public IList SelectAgentsByName(string name)
        {
            IList i = null;
            string sql = "from Agent u where u.AgentName like " + "'%" + name + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
        public IList SelectCompany(string name, string cname,string bname)
        {
            IList i = null;
            string sql = "from CustomBaseInfo u where u.Name like " + "'%" + name + "%'and u.ContactName like " + "'%" + cname + "%' and u.IdentifyCardNo like " + "'%" + bname + "%'  and  u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company + "and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
        /// <summary>
        /// 查询意向公司客户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cname"></param>
        /// <param name="bname"></param>
        /// <returns></returns>
        public IList SelectIntendCompany(string name, string cname, string bname)
        {
            IList i = null;
            string sql = "from CustomBaseInfo u where u.Name like " + "'%" + name + "%'and u.ContactName like " + "'%" + cname + "%' and u.IdentifyCardNo like " + "'%" + bname + "%'  and  u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company + "and u.State = " + (int)BaseEntity.stateEnum.Normal+" and u.Category="+(int)CustomBaseInfo.kehuleibie.yixiangkehu;
            i = this.loadEntityList(sql);
            return i;
        }
        /// <summary>
        /// 查询正式公司客户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cname"></param>
        /// <param name="dname"></param>
        /// <param name="ename"></param>
        /// <returns></returns>
        public IList SelectFormalCompany(string name, string cname, string bname)
        {
            IList i = null;
            string sql = "from CustomBaseInfo u where u.Name like " + "'%" + name + "%'and u.ContactName like " + "'%" + cname + "%' and u.IdentifyCardNo like " + "'%" + bname + "%'  and  u.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company + "and u.State = " + (int)BaseEntity.stateEnum.Normal + " and u.Category=" + (int)CustomBaseInfo.kehuleibie.zhenshikehu;
            i = this.loadEntityList(sql);
            return i;
        }
        public IList SelectCompanyCar(string name, string cname, string dname, string ename)
        {
            IList i = null;

            string sql = "select u from CarBaseInfo u left join u.Cbi c where c.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company + " and c.Name like " + "'%" + name + "%' and u.PlateNumber like " + "'%" + cname + "%' and u.VIN like " + "'%" + dname + "%' and u.EngineIdentificationNumber like " + "'%" + ename + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal;

            i = this.loadEntityList(sql);

            return i;
        }
        public IList SelectPersonalCar(string name, string cname, string dname, string ename)
        {
            IList i = null;

            string sql = "select u from CarBaseInfo u left join u.Cbi c where c.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Personal + " and c.Name like " + "'%" + name + "%' and u.PlateNumber like " + "'%" + cname + "%' and u.VehicleType like " + "'%" + dname + "%' and u.VIN like " + "'%" + ename + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by c.RegistrationTime DESC";
          

            i = this.loadEntityList(sql);

            return i;
        }
        public IList SelectPersonalCar(string name, string cname)
        {
            IList i = null;
            string sql = "select u from CarBaseInfo u left join u.Cbi c where c.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Personal + " and u.EngineIdentificationNumber like " + "'%" + name + "%' and u.PlateNumber like " + "'%" + cname + "%'  and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
        public IList SelectedCompanyCar(string name, string cname)
        {
            IList i = null;
            string sql = "select u from CarBaseInfo u left join u.Cbi c where c.Status=" + (int)CustomBaseInfo.PersonalOrCompany.Company + " and u.EngineIdentificationNumber like " + "'%" + name + "%' and u.PlateNumber like " + "'%" + cname + "%'  and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
        public IList SelecAllCar(string name, string cname)
        {
            IList i = null;
            string sql = "from CarBaseInfo u where u.EngineIdentificationNumber like " + "'%" + name + "%' and u.PlateNumber like " + "'%" + cname + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;

        }
        public IList SelectMember(string name,string cname,long time1,long time2,long time3,long time4)
        {
            IList i = null;
            string sql = "from HuiYuanBaseInfo u where u.Name like " + "'%" + name + "%' and u.PlateNumber like " + "'%" + cname + "%' and u.ModificationTime>=" + time1 + " and u.ModificationTime<=" + time2 + " and u.RegistrationTime>=" + time3 + " and u.RegistrationTime<=" + time4 + " and u.State = " + (int)BaseEntity.stateEnum.Normal; 
            i = this.loadEntityList(sql);
            return i;
        }
        /// <summary>
        /// DataGridView克隆
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public DataGridView CloneDataGridView(DataGridView dgv)
        {
            try
            {
                DataGridView ResultDGV = new DataGridView();
                ResultDGV.ColumnHeadersDefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle.Clone();
                DataGridViewCellStyle dtgvdcs = dgv.RowsDefaultCellStyle.Clone();
                dtgvdcs.BackColor = dgv.DefaultCellStyle.BackColor;
                dtgvdcs.ForeColor = dgv.DefaultCellStyle.ForeColor;
                dtgvdcs.Font = dgv.DefaultCellStyle.Font;
                ResultDGV.RowsDefaultCellStyle = dtgvdcs;
                ResultDGV.AlternatingRowsDefaultCellStyle = dgv.AlternatingRowsDefaultCellStyle.Clone();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    DataGridViewColumn DTGVC = dgv.Columns[i].Clone() as DataGridViewColumn;
                    DTGVC.DisplayIndex = dgv.Columns[i].DisplayIndex;
                    if (DTGVC.CellType == null)
                    {
                        DTGVC.CellTemplate = new DataGridViewTextBoxCell();
                        ResultDGV.Columns.Add(DTGVC);
                    }
                    else
                    {
                        ResultDGV.Columns.Add(DTGVC);
                    }
                }
                foreach (DataGridViewRow var in dgv.Rows)
                {
                    DataGridViewRow Dtgvr = var.Clone() as DataGridViewRow;
                    Dtgvr.DefaultCellStyle = var.DefaultCellStyle.Clone();
                    for (int i = 0; i < var.Cells.Count; i++)
                    {
                        Dtgvr.Cells[i].Value = var.Cells[i].Value;
                    }
                    if (var.Index % 2 == 0)
                        Dtgvr.DefaultCellStyle.BackColor = ResultDGV.RowsDefaultCellStyle.BackColor;
                    ResultDGV.Rows.Add(Dtgvr);
                }
                return ResultDGV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// 选择气瓶型号
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IList SelectCylinderType(string name)
        {
            IList i = null;
            string sql = "select distinct CylinderType from CylinderInfo where CylinderType like " + "'%" + name + "%' and State=" + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
        /// <summary>
        /// 得到气瓶ID
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public IList SelectCylinderID(string s1,int s2)
        {
            IList i = null;
            string sql = "from CylinderInfo where CylinderType='" + s1 + "'and CylinderNumber='"+s2+"' and State=" + (int)BaseEntity.stateEnum.Normal;
            i = this.loadEntityList(sql);
            return i;
        }
    }
}