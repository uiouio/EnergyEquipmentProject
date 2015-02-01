using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SQLProvider.Service;
using CommonMethod;

namespace StatisticalReport
{
    public partial class ModifyContractStatistical : CommonControl.CommonTabPage
    {
        BaseService baseService = new BaseService();
        DataTable currentTable = new DataTable();
        public ModifyContractStatistical()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long t1;

            long t2;

            if (this.radioButton1.Checked == true)
            {
                t1 = this.dateTimePicker1.Value.Date.Ticks;
                t2 = this.dateTimePicker2.Value.Date.AddDays(1).Ticks;
            }
            else if (this.radioButton2.Checked == true)
            {
                t1 = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month, 1).Ticks;
                t2 = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value.AddMonths(1).Month, 1).Ticks;

            }
            else
            {
                t1 = new DateTime(this.dateTimePicker1.Value.Year, 1, 1).Ticks;
                t2 = new DateTime(this.dateTimePicker2.Value.AddYears(1).Year, 1, 1).Ticks;
            }
            DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select m.ContractNo as 合同编号,u.Name as 销售人员,cbi.Name as 乙方,car.PlateNumber as 车牌号,m.ContractAmount as 合同金额,Convert(varchar(100),DATEADD(s, SignedDate/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 签订日期 from ModificationContract m,UserInfo u,CarBaseInfo car,CustomBaseInfo cbi where m.UserId=u.Id and m.Id=car.ModificationContractId and car.CustomBaseID=cbi.Id");
            currentTable = dataSet.Tables[0];
            DataTable ndt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "序号";
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            ndt.Columns.Add(dc);
            ndt.Merge(currentTable);
            this.commonDataGridView1.DataSource = ndt;


        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            ExportAndImport.ExportExcel(folderBrowserDialog1.SelectedPath, "合同统计", currentTable);
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = "yyyy年MM月dd日";

                this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker2.CustomFormat = "yyyy年MM月dd日";


            }
            else if (this.radioButton2.Checked == true)
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = "yyyy年MM月";

                this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker2.CustomFormat = "yyyy年MM月";

            }
            else if (this.radioButton3.Checked == true)
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = "yyyy年";

                this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker2.CustomFormat = "yyyy年";
            }
        }

    }
}
