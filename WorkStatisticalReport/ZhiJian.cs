using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLProvider.Service;
using CommonMethod;

namespace WorkStatisticalReport
{
    public partial class ZhiJian : CommonControl.CommonTabPage
    {
        BaseService baseService = new BaseService();
        DataTable currentTable = new DataTable();

        public ZhiJian()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            ExportAndImport.ExportExcel(folderBrowserDialog1.SelectedPath, "监检统计", currentTable);
        }

        private void ZhiJian_Load(object sender, EventArgs e)
        {
            DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select ID as 序号");
            currentTable = dataSet.Tables[0];
        }
    }
}
