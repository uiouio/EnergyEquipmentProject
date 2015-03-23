using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLProvider.Service;
using System.Collections;
using EntityClassLibrary;
using System.Windows.Forms;
using System.Data;


namespace CustomManageWindow.Service    
{
    class CustomerRecordService: BaseService
    {
        DataBase_wp dataBase_wp = new DataBase_wp();
        
        /// <summary>
        /// 获得所有回访记录
        /// </summary>
        /// <returns></returns>
        public IList GetAllCustomServiceRecord()
        {
            IList records = null;
            string sql = "from CustomerServiceRecord u where u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.PhoneTime DESC";
            records = this.loadEntityList(sql);

            if (records.Count > 0 && records != null)
            {
                return records;
            }
            else { return null; }
        }

        public IList GetAllCarsInfo()
        {
            IList records = null;
            //string sql = "from CarBaseInfo u where u.State = " + (int)BaseEntity.stateEnum.Normal;
            string sql = "select u from CarTheLibrary u left join u.RefitWork c left join c.CarInfo v left join v.Cbi w where u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.FinishTime DESC"; 
            records = this.loadEntityList(sql);

            if (records.Count > 0 && records != null)
            {
                return records;
            }
            else { return null; }
        }

        /// <summary>
        /// 根据条件搜索车辆
        /// </summary>
        /// <param name="name">牌照</param>
        /// <param name="cname">车主</param>
        /// <param name="dname">电话</param>
        /// <param name="time1">开始时间</param>
        /// <param name="time2">结束时间</param>
        /// <returns>List</returns>
        public IList SelectCarsRecord(string name, string cname,string dname,long time1,long time2)
        {
            IList i = null;
            string sql = "select u from CarTheLibrary u left join u.RefitWork c left join c.CarInfo v left join v.Cbi w where v.PlateNumber  like " + "'%" + name + "%' and w.Name like " + "'%" + cname + "%' and w.Telephone like " + "'%" + dname + "%' and u.FinishTime>=" + time1 + " and u.FinishTime<=" + time2 + "  and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.FinishTime DESC"; 
            i = this.loadEntityList(sql);
            return i;
        }

        /// <summary>
        /// 通过回访人查询回访记录
        /// </summary>
        /// <param name="phoneWorker">回访人</param>
        /// <returns>List</returns>
        public IList SelectCustomServiceRecordByPhoneWorker(string phoneWorker)
        {
            IList i = null;
            string sql = "select u from CustomerServiceRecord u left join u.CarInfo c where u.PhoneWorker like " + "'%" + phoneWorker + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.PhoneTime DESC";
            i = this.loadEntityList(sql);
            return i;
        }

        /// <summary>
        /// 通过车牌照查询回访记录
        /// </summary>
        /// <param name="plateNumber">牌照</param>
        /// <returns>List CustomerServiceRecord</returns>
        public IList SelectCustomServiceRecordByPlateNo(string plateNumber)
        {
            IList i = null;
            string sql = "select u from CustomerServiceRecord u left join u.CarInfo c where c.PlateNumber like " + "'%" + plateNumber + "%' and u.State = " + (int)BaseEntity.stateEnum.Normal + " order by u.PhoneTime DESC";
            i = this.loadEntityList(sql);
            return i;
        }

        
        /// <summary>
        /// 在CustomerServiceRecord表中新建一条记录
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="phoneTime"></param>
        /// <param name="phoneWorker"></param>
        /// <param name="Question"></param>
        /// <param name="HandleOpinion"></param>
        /// <param name="Remark"></param>
        public void addCustomServiceRecord(string carId, DateTime phoneTime, string phoneWorker, string Question, string HandleOpinion, string Remark)
        {
            
            string sql = "Insert into CustomerServiceRecord(carBaseInfoID,phoneTime,phoneWorker,Question,HandleOpinion,Remark,State) "
                    + " values( '" + carId + "','" + phoneTime + "','" + phoneWorker + "','" + Question + "','" + HandleOpinion + "','" + Remark + "',0)";
            dataBase_wp.RunProc(sql);

        }

        /// <summary>
        /// 通过车牌号获得车辆Id
        /// </summary>
        /// <param name="plateNum">车牌号</param>
        /// <returns>CarBaseInfo.Id</returns>
        public string getCarIdByPlateNum(string plateNum)
        {
            DataSet ds= dataBase_wp.RunProcReturn("select * from CarBaseInfo WHERE PlateNumber='" + plateNum + "'","table");
            if (ds == null)
                return "";
            else return ds.Tables["table"].Rows[0]["Id"].ToString();
        }

        public void updateCustomServiceRecord(string remark, string carBaseInfoId)
        {
            string sql = "UPDATE CustomerServiceRecord SET Remark = '" + remark + "' WHERE carBaseInfoId = '" + carBaseInfoId + "' ";
            try
            { dataBase_wp.RunProc(sql); }
            catch (Exception e)
            { MessageBox.Show("输入格式不正确"); }
            
        }
    }
      
}
