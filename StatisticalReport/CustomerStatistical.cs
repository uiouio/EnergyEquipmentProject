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
using EntityClassLibrary;

namespace StatisticalReport
{
    public partial class CustomerStatistical : CommonControl.CommonTabPage
    {

        BaseService baseService = new BaseService();
        DataTable currentTable = new DataTable();
        public CustomerStatistical()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long time1 = this.dateTimePicker1.Value.Date.Ticks;
            long time2 = this.dateTimePicker2.Value.Date.AddDays(+1).Ticks;
            if (radioButton4.Checked)//个人客户
            {
#region 全条件查询
                if (radioButton3.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号, c.Name as 姓名,c.IdentifyCardNo as 身份证,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Email,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户 ,Unit as 单位" +//选择列
                    " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=0"//选择数据表
                    + " and u.UserName ='" + textBox1.Text + "' and c.RegistrationTime>=" + time1 + "and c.RegistrationTime<=" + time2 + "and c.Category="+comboBox1.SelectedIndex + "and c.State=" + (int)BaseEntity.stateEnum.Normal);//查询条件
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
#endregion
#region 日期查询
                else if (radioButton2.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号,  c.Name as 姓名,c.IdentifyCardNo as 身份证,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Email,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户 ,Unit as 单位" +
                    " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=0"
                    + " and c.RegistrationTime>=" + time1 + "and c.RegistrationTime<=" + time2 + "and c.State=" + (int)BaseEntity.stateEnum.Normal);
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
#endregion
#region 经办人查询
                else if (radioButton1.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号,  c.Name as 姓名,c.IdentifyCardNo as 身份证,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Email,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户 ,Unit as 单位" +
                   " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=0"
                   + " and u.UserName ='" + textBox1.Text + "'and c.State=" + (int)BaseEntity.stateEnum.Normal);
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
#endregion
#region 客户状态查询
                else if (radioButton6.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号, c.Name as 姓名,c.IdentifyCardNo as 身份证,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Email,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户 ,Unit as 单位" +//选择列
                    " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=0"//选择数据表
                    +"and c.Category=" + comboBox1.SelectedIndex + "and c.State=" + (int)BaseEntity.stateEnum.Normal);//查询条件
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
#endregion
#region 无条件查询
                else if (radioButton7.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号, c.Name as 姓名,c.IdentifyCardNo as 身份证,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Email,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户 ,Unit as 单位" +//选择列
                    " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=0");//选择数据表
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
#endregion
                else
                    MessageBox.Show("请选择统计依据。");
            }


            else if(radioButton5.Checked)//企业客户
            {
                if (radioButton3.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号, c.Name as 企业名称,c.IdentifyCardNo as 机构代码,c.ContactName as 联系人姓名,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户" +//选择列
                    " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=1"//选择数据表
                    + " and u.UserName ='" + textBox1.Text + "' and c.RegistrationTime>=" + time1 + "and c.RegistrationTime<=" + time2 + "and c.Category="+comboBox1.SelectedIndex + "and c.State=" + (int)BaseEntity.stateEnum.Normal);//查询条件
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
                else if (radioButton2.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号, c.Name as 企业名称,c.IdentifyCardNo as 机构代码,c.ContactName as 联系人姓名,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户" +
                    " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=1"
                    + " and c.RegistrationTime>=" + time1 + "and c.RegistrationTime<=" + time2 + "and c.State=" + (int)BaseEntity.stateEnum.Normal);
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
                else if (radioButton1.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号, c.Name as 企业名称,c.IdentifyCardNo as 机构代码,c.ContactName as 联系人姓名,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户" +
                   " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=1"
                   + " and u.UserName ='" + textBox1.Text + "'and c.State=" + (int)BaseEntity.stateEnum.Normal);
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
                     else if (radioButton6.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号, c.Name as 企业名称,c.IdentifyCardNo as 机构代码,c.ContactName as 联系人姓名,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户" +//选择列
                    " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=1"//选择数据表
                    +"and c.Category=" + comboBox1.SelectedIndex + "and c.State=" + (int)BaseEntity.stateEnum.Normal);//查询条件
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
                else if (radioButton7.Checked)
                {
                    DataSet dataSet = baseService.ExecuteSQLReturnDataSet("select c.ID as 序号, c.Name as 企业名称,c.IdentifyCardNo as 机构代码,c.ContactName as 联系人姓名,c.phone as 固定电话 ,c.telephone as 移动电话 ,c.QQ,c.Address as 地址,c.Postcode as 邮编,u.UserName as 经办人,c.CustomLevel as 客户级别,Convert(varchar(100),DATEADD(s, RegistrationTime/ 10000000 - 630822816000000000 / 10000000, '2000-1-1'),111) as 注册日期 , (case Category when 0 then '是' when 1 then'否' end)as 是否正式客户" +//选择列
                    " from CustomBaseInfo c, UserInfo u where c.UserID=u.Id and c.Status=1");//选择数据表
                    currentTable = dataSet.Tables[0];
                    commonDataGridView1.DataSource = currentTable;
                }
                else
                    MessageBox.Show("请选择统计依据。");
            }
            else
                MessageBox.Show("请选择客户类型。");
            
        }

        private void CustomerStatistical_Load(object sender, EventArgs e)
        {
           dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-60);
           comboBox1.SelectedIndex = 0;
           commonDataGridView1.ReadOnly = true;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true ;
                comboBox1.Enabled = true ;
                dateTimePicker1.Enabled = true ;
                dateTimePicker2.Enabled = true ;
            }
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            ExportAndImport.ExportExcel(folderBrowserDialog1.SelectedPath, "客户统计", currentTable);
        }
    }
}
