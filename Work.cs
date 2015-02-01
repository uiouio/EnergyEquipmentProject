using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonMethod;
using SQLProvider.Service;


namespace WorkStatisticalReport
{
    public partial class Work : CommonControl.CommonTabPage
    {
        BaseService baseService = new BaseService();
        DataTable currentTable = new DataTable();
        public Work()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            ExportAndImport.ExportExcel(folderBrowserDialog1.SelectedPath, "生产统计", currentTable);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select ID as 序号");
            currentTable = dataSet.Tables[0];
        }
    }
}
