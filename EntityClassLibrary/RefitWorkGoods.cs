using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityClassLibrary
{
    public class RefitWorkGoods:BaseEntity
    {
        private int receiveType;
        public virtual int ReceiveType
        {
            get { return receiveType; }
            set { receiveType = value; }
        }
        private float count;
        public virtual float Count
        {
            get { return count; }
            set { count = value; }
        }
        private int addType;
        public virtual int AddType
        {
            get { return addType; }
            set { addType = value; }
        }

        private GoodsBaseInfo goodsBaseInfoId;
        public virtual GoodsBaseInfo GoodsBaseInfoId
        {
            get { return goodsBaseInfoId; }
            set { goodsBaseInfoId = value; }
        }

        private RefitWork refitWorkId;
        public virtual RefitWork RefitWorkId
        {
            get { return refitWorkId; }
            set { refitWorkId = value; }
        }

        private string remark;
        public virtual string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public enum IfAdd
        {
            NotAdd = 0,
            Add = 1
        }

        public enum ReceiveTypeEnum
        {
            NotReceive = 0,
            Receive = 1
        }

        public static string[] ReceiveTypeArray = { "未领料", "已领料" };

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            RefitWorkGoods rwg = (RefitWorkGoods)obj;
            if (rwg.AddType != this.AddType)
                return false;
            if (rwg.Count != this.Count)
                return false;
            if (rwg.GoodsBaseInfoId.Id != this.GoodsBaseInfoId.Id)
                return false;
            if (rwg.ReceiveType != this.ReceiveType)
                return false;
            if (rwg.RefitWorkId.Id != this.RefitWorkId.Id)
                return false;
            if (rwg.Remark != this.Remark)
                return false;
            return true;
        }
        public override string SaveOldSQL()
        {
            return "insert into RefitWorkGoods([RefitWorkId],[GoodsBaseInfoId] ,[Count],[ReceiveType],[AddType],[Remark],[HistoryId],[TimeStamp],[RefitWorkGoodsState]) select [RefitWorkId],[GoodsBaseInfoId] ,[Count],[ReceiveType],[AddType],[Remark],[HistoryId],[TimeStamp],[RefitWorkGoodsState] from RefitWorkGoods where "
            + "Id=" + this.Id
            + ";update RefitWorkGoods set RefitWorkGoodsState=1 where Id=@@IDENTITY;select @@identity";
        }
        public override string CheckOldSQL()
        {
            string sql = "SELECT [Id],[RefitWorkId],[GoodsBaseInfoId],[Count],[ReceiveType],[AddType],[Remark],[HistoryId],[TimeStamp],[RefitWorkGoodsState] FROM [EnergyEquipmentProject].[dbo].[RefitWorkGoods] where"
                + " Id=" + this.Id
                + " and [RefitWorkId]=" + this.RefitWorkId.Id
                + " and [GoodsBaseInfoId]=" + this.goodsBaseInfoId.Id
                + " and [Count]=" + this.Count
                + " and [ReceiveType]=" + this.ReceiveType
                + " and [AddType]=" + this.AddType
                + (this.Remark == null ? " and [Remark] is null" : (" and [Remark]='" + this.Remark + "'"))
                + " and [HistoryId]=" + this.HistoryId
                + " and [TimeStamp]=" + this.TimeStamp
                + " and [RefitWorkGoodsState]=" + this.State;
            return sql;
        }
    }
}
