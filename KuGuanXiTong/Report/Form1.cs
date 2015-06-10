using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using SQLProvider.Service;
using EntityClassLibrary;
using System.Collections;
using KuGuanXiTong.Service;
namespace KuGuanXiTong.Report
{
    public partial class Form1 : CommonControl.BaseForm
    {
        private Object[] objectRefitWork;
        public Object[] ObjectRefitWork
        {
            get { return objectRefitWork; }
            set { objectRefitWork = value; }
        }
        private List<string> list;

        public List<string> List
        {
            get { return list; }
            set { list = value; }
        }
        private List<string> listcode;

        public List<string> Listcode
        {
            get { return listcode; }
            set { listcode = value; }
        }
        private List<string> listname;

        public List<string> Listname
        {
            get { return listname; }
            set { listname = value; }
        }
        private List<string> listspecifition;

        public List<string> Listspecifition
        {
            get { return listspecifition; }
            set { listspecifition = value; }
        }
        BaseService bs = new BaseService();
        Service.ChuKuService chuKuService = new Service.ChuKuService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“EnergyEquipmentProjectDataSet.GoodsBaseInfo”中。您可以根据需要移动或删除它。
            //this.GoodsBaseInfoTableAdapter.Fill(this.EnergyEquipmentProjectDataSet.GoodsBaseInfo);
            // TODO: 这行代码将数据加载到表“EnergyEquipmentProjectDataSet.GoodsBaseInfo”中。您可以根据需要移动或删除它。
            RefitWork refitWork = (RefitWork)objectRefitWork[0];
            this.comboBox1.DataSource = list;
            #region 不用的
            // string s1 = "select g.GoodsClassCode,g.GoodsName from GoodsBaseInfo g  where g.GoodsParentClassId=1  order by g.GoodsClassCode";
           // IList goodlist = bs.ExecuteSQL(s1);

           // foreach (RefitWorkGoods r in refitWork.RefitWorkGoodss)
           // {
           //     foreach (Object[] g in goodlist)
            //    {

            //        if (r.GoodsBaseInfoId.GoodsClassCode.Substring(0, 2) == g[0].ToString())
              //      {
              //          this.comboBox1.Items.Add(r.GoodsBaseInfoId.GoodsClassCode.Substring(0, 2) + g[1]);
                    //}
              //  }

         //   }
           // int count = comboBox1.Items.Count;
           // int i;
        //    for (i = 0; i < count; i++)
        //    {
        //        string str = comboBox1.Items[i].ToString();
        //        for (int j = i + 1; j < count; j++)
        //        {
        //            string str1 = comboBox1.Items[j].ToString();
        //            if (str1 == str)
        //            {
        //                comboBox1.Items.RemoveAt(j);
        //                count--;
        //                j--;
        //            }
        //        }
            //    }
            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;//reportViewer1是你报表控件的name
            RefitWork refitWork = (RefitWork)objectRefitWork[0];
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\lib\Report\Report1.rdlc";
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc";
            List<ReportParameter> pList = new List<ReportParameter>();
            pList.Add(new ReportParameter("p_DispatchOrder", refitWork.DispatchOrder));
            pList.Add(new ReportParameter("p_PlateNumber", refitWork.CarInfo.PlateNumber));
            pList.Add(new ReportParameter("p_ModifyType", CarBaseInfo.ModifyType[refitWork.CarInfo.ModidiedType]));
            pList.Add(new ReportParameter("p_CustomName", refitWork.CarInfo.Cbi.Name));
            pList.Add(new ReportParameter("p_VehicleType", refitWork.CarInfo.VehicleType));
            pList.Add(new ReportParameter("p_ClassCode", this.comboBox1.Text));
            //pList.Add(new ReportParameter("p_Remark", refitWork.CarInfo.Cbi.Name +""+ refitWork.CarInfo.PlateNumber + CarBaseInfo.ModifyType[refitWork.CarInfo.ModidiedType] + refitWork.CarInfo.VehicleType));
            pList.Add(new ReportParameter("p_Name", this.UserInfo.Name));
            pList.Add(new ReportParameter("p_Date", DateTime.Now.ToLongDateString()));
            this.reportViewer1.LocalReport.SetParameters(pList);
            this.reportViewer1.LocalReport.DataSources.Clear();
            DataSet ds = new DataSet();
            for (int i = 0; i < Listcode.Count; i++)
            {
                string sql = "SELECT top 1 g.GoodsClassCode,g.GoodsName,g.Specifications,g.Unit,g.SingleMoney,sod.Quantity,(sod.Quantity*g.SingleMoney) AS 总价 FROM GoodsBaseInfo g,RefitWork r,RefitWorkGoods rg,Stock s,StockOperationDetail sod where r.DispatchOrder='" + refitWork.DispatchOrder + "' and rg.RefitWorkId=r.Id and rg.GoodsBaseInfoId=g.Id and sod.StockId=s.Id and s.GoodsBaseInfoID=g.Id and g.GoodsClassCode=" + Listcode[i] + " and g.GoodsClassCode  like '" + this.comboBox1.Text.Substring(0, 2) + "%'  and g.GoodsName='" + Listname[i] + "'and g.Specifications='" + Listspecifition[i] + "' order by sod.TimeStamp DESC";
                DataSet dt = new DataSet();
                dt = bs.ExecuteSQLReturnDataSet(sql);
                ds.Merge(dt);
            }
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("EnergyEquipmentProjectDataSet",ds.Tables[0]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables[0]));
            this.reportViewer1.RefreshReport();
           
            
        }
    }
}
