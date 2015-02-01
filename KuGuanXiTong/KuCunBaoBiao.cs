using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KuGuanXiTong.Service;
using EntityClassLibrary;
using CommonMethod;
using SQLProvider.Service;

namespace KuGuanXiTong
{
    public partial class KuCunBaoBiao : CommonControl.CommonTabPage
    {
        public KuCunBaoBiao()
        {
            InitializeComponent();
        }


        DataTable CurrentTable = new DataTable();
        BaseService baseService = new BaseService();
        GoodsBaseInfo parentGoods;


        /// <summary>
        /// 导出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            if (this.commonDataGridView1.Rows.Count > 0)
            {

                folderBrowserDialog1.ShowDialog();
                ExportAndImport.ExportExcel(folderBrowserDialog1.SelectedPath, "库存统计", CurrentTable);

            }
        }
        private void KuCunBaoBiao_Load(object sender, EventArgs e)
        {

        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if(this.radioButton1.Checked == true)
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = "yyyy年MM月dd日";

                this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker2.CustomFormat = "yyyy年MM月dd日";


            }
            else if(this.radioButton2.Checked == true)
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = "yyyy年MM月";

                this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker2.CustomFormat = "yyyy年MM月";
            
            }
            else if(this.radioButton3.Checked == true)
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = "yyyy年";

                this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker2.CustomFormat = "yyyy年";
            }
        }



        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            long t1;

            long t2;

            if(this.radioButton1.Checked == true)
            {
                t1 = this.dateTimePicker1.Value.Date.Ticks;
                t2 = this.dateTimePicker2.Value.Date.AddDays(1).Ticks;
            }
            else if(this.radioButton2.Checked == true)
            {
                t1 = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month, 1).Ticks;
                t2 = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value.AddMonths(1).Month, 1).Ticks;
            
            }
            else 
            {
                t1 = new DateTime(this.dateTimePicker1.Value.Year, 1, 1).Ticks;
                t2 = new DateTime(this.dateTimePicker2.Value.AddYears(1).Year, 1, 1).Ticks;
            }

            long IOflog;
            if (this.radioButton4.Checked == true)
            {
                IOflog = 0;
            }
            else
            {

                IOflog = 1;
            }

            string id;
            if (this.textBox1.Text == "")
            {
                id = "1";
            }
            else
            {
                id = parentGoods.Id.ToString();
            
            }

             
            //String

            #region SQL 语句

            string sql = 
                " with cte as  " +
                " ( " +
                " select a.* from GoodsBaseInfo a where id =   " + id +
                " union all  "+
                " select k.* from GoodsBaseInfo k inner join cte c on c.Id = k.GoodsParentClassId " +
                " ) " +
                " select  IDENTITY(int,1,1) as 序号 , QUANBU.* into NewtableNUm from  " +
                " ( " + 
                " select  Goods.gcode as 编码 ,  Goods.gname  as 名称 ,SUM(StockOperationDetail.Quantity) 操作数量, Goods.gquan as 库存数量 from "  +

                " (select * from ( " + 
                "		select g.* ,GoodsBaseInfo.GoodsName as gpname from  " +
                " (select m.GoodsClassCode as gcode,m.GoodsName as gname ,m.Specifications as gsp,m.Material as gma ,m.Unit " +
                " as gunit,m.GoodsParentClassId as gpid,t.Quan as gquan ,m.Id as gid from " +
                "	(select cte.* from cte where cte.State = 0 and cte.GoodsFlag <>1) m left join  " +
                "		(select GoodsBaseInfoID, SUM(Quantity) as Quan, sum([Money])/COUNT(*) as MM, " +
                "		sum(StorehouseplaceCode)/COUNT(*) as SS from Stock where State = 0 "   +
                "		group by GoodsBaseInfoID) t on  t.GoodsBaseInfoID = m.Id ) g , " +
                " GoodsBaseInfo where g.gpid = GoodsBaseInfo.Id) gg ) Goods left join StockOperationDetail on  " +
                " Goods.gid =  convert(int,substring(StockOperationDetail.GoodsCode,1,8)) left join "  +
                " StockOperation on StockOperation.Id = StockOperationDetail.StockOperationId " +
                " where StockOperation.OperationTime between " +t1.ToString()+ " and " +t2.ToString()+
                " and StockOperation.IOFlag =  "+IOflog.ToString() +
                " group by Goods.gid , Goods.gcode ,Goods.gname , Goods.gquan" +
                " ) QUANBU where 操作数量 is not null and 库存数量 is not null " +
                " select * from NewtableNUm " + 
                " DROP TABLE NewtableNUm ";

            #endregion

            DataSet dataSet = baseService.ExecuteSQLReturnDataSet(sql);

            CurrentTable = dataSet.Tables[0];

            this.commonDataGridView1.DataSource = CurrentTable;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CategtoryTreeview tree = new CategtoryTreeview();
            tree.IsCatetoryOrGoods = 0;
            tree.ShowDialog();
            if (tree.DialogResult == DialogResult.OK)
            {
                parentGoods = tree.Gg;
                this.textBox1.Text = parentGoods.GoodsName;
            }

        }

        private void IOCheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton4_Click(object sender, EventArgs e)
        {
            PrintDataGridView.PrintTheDataGridView(this.commonDataGridView1);
        }
    }
}
