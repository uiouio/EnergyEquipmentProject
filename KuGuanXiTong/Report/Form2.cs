using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using Microsoft.Reporting.WinForms;
using SQLProvider.Service;
namespace KuGuanXiTong.Report
{
    public partial class Form2 : CommonControl.BaseForm
    {
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
        StockOperation sendStocktoshow = new StockOperation();
        public StockOperation SendStocktoshow
        {
            get { return sendStocktoshow; }
            set { sendStocktoshow = value; }
        }
        BaseService bs = new BaseService();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“EnergyEquipmentProjectDataSet.GoodsBaseInfo”中。您可以根据需要移动或删除它。
            //this.GoodsBaseInfoTableAdapter.Fill(this.EnergyEquipmentProjectDataSet.GoodsBaseInfo);
            this.comboBox1.DataSource = List;
            // TODO: 这行代码将数据加载到表“EnergyEquipmentProjectDataSet.GoodsBaseInfo”中。您可以根据需要移动或删除它。
           // this.GoodsBaseInfoTableAdapter.Fill(this.EnergyEquipmentProjectDataSet.GoodsBaseInfo);
           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\TEMP\lib\Report\Report2.rdlc";
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Report2.rdlc";
            List<ReportParameter> pList = new List<ReportParameter>();
            pList.Add(new ReportParameter("p_Code", sendStocktoshow.RetrospectListNumber));
            pList.Add(new ReportParameter("p_SupplyName", sendStocktoshow.SupplierInfoId==null?"":sendStocktoshow.SupplierInfoId.SupplierName));
            pList.Add(new ReportParameter("p_Class", this.comboBox1.Text));
            pList.Add(new ReportParameter("p_Date", DateTime.Now.ToString("yyyy-MM-dd")));
            DateTime dt = new DateTime(sendStocktoshow.OperationTime);
            string str = dt.ToString("yyyy-MM-dd");
            pList.Add(new ReportParameter("p_OperationDate", str));
            pList.Add(new ReportParameter("p_Name", this.UserInfo.Name));
            this.reportViewer1.LocalReport.SetParameters(pList);
            this.reportViewer1.LocalReport.DataSources.Clear();
            DataSet ds = new DataSet();
            string sql = "SELECT g.GoodsClassCode,g.GoodsName,g.Specifications,g.Unit,sod.Quantity,sod.TheMoney,(sod.Quantity*sod.TheMoney) AS 金额,sod.Tax,(sod.TheMoney+sod.TheMoney*sod.Tax) AS 含税单价,(sod.Quantity*(sod.TheMoney+sod.TheMoney*sod.Tax)) AS 价税合计 FROM GoodsBaseInfo g,Stock s,StockOperation so,StockOperationDetail sod where so.RetrospectListNumber='" + sendStocktoshow.RetrospectListNumber + "' and sod.StockOperationId=so.Id and sod.StockId=s.Id and s.GoodsBaseInfoID=g.Id and g.GoodsClassCode  like '" + this.comboBox1.Text.Substring(0, 2) + "%'";
            ds = bs.ExecuteSQLReturnDataSet(sql);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("EnergyEquipmentProjectDataSet", ds.Tables[0]));
            this.reportViewer1.RefreshReport();
          
            //this.reportViewer1.RefreshReport();
            
           
        }
    }
}
