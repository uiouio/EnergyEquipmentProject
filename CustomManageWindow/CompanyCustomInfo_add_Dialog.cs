using System;
using System.Drawing;
using System.Windows.Forms;
using EntityClassLibrary;
using CustomManageWindow.Service;
using CommonControl;
using Iesi.Collections.Generic;

namespace CustomManageWindow
{
    public partial class CompanyCustomInfo_add_Dialog : CommonControl.BaseForm
    {
       
        ISet<CarBaseInfo> car = new HashedSet<CarBaseInfo>();
        public int IfSaved = 0;
        public CompanyCustomInfo_add_Dialog()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CarManage_add_Dialog clxx = new CarManage_add_Dialog("车辆信息录入");
            clxx.IsShowOrInput = 1;
            if (clxx.ShowDialog() == DialogResult.OK)
            {
                commonDataGridView1.Rows.Add(0, 1, clxx.CarBaseInfo.PlateNumber, clxx.CarBaseInfo.VehicleType, clxx.CarBaseInfo.EngineIdentificationNumber, "编辑");
                commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = clxx.CarBaseInfo;
                car.Add(clxx.CarBaseInfo);
              
            }
        }

        private void CompanyCustomInfo_add_Dialog_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox1.Text = this.UserInfo.Name;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomService ss = new CustomService();

            CustomBaseInfo cb = new CustomBaseInfo();

           cb.Name = textBox2.Text;

           cb.ContactName = textBox19.Text;

           cb.IdentifyCardNo = textBox16.Text;

           cb.Address = textBox14.Text;

           cb.ComanySize = comboBox5.Text;

           cb.Phone = textBox13.Text;

           cb.ComanyProperty = comboBox2.Text;
           cb.Status = (int)CustomBaseInfo.PersonalOrCompany.Company;
           cb.Category=(int)CustomBaseInfo.kehuleibie.yixiangkehu;
           #region 判断客户级别
           if (radioButton1.Checked)
           {
               cb.CustomLevel = radioButton1.Text;

           }
           else if (radioButton2.Checked)
           {
               cb.CustomLevel = radioButton2.Text;
           }
           else if (radioButton5.Checked)
           {
               cb.CustomLevel = radioButton5.Text;
           }
           else if (radioButton6.Checked)
           {
               cb.CustomLevel = radioButton6.Text;
           }
           else if (radioButton7.Checked)
           {
               cb.CustomLevel = radioButton7.Text;
           }
           #endregion
           cb.Remarks = textBox18.Text;
           cb.UserID = this.UserInfo;
           cb.CarInfo = car;
           if (this.textBox2.Text == "" || this.textBox19.Text == "" || this.textBox16.Text == "")
           {
               MessageBox.Show("请输入必填信息");
           }
           else
           {

               ss.SaveOrUpdateEntity(cb);
               MessageBox.Show("添加成功");
               IfSaved = 1;
               this.Close();
           }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void commonDataGridView1_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "编辑")
            {
                CarManage_add_Dialog newGhs = new CarManage_add_Dialog("车辆详细信息");
                newGhs.CarBaseInfo = (CarBaseInfo)this.commonDataGridView1.Rows[this.commonDataGridView1.CurrentRow.Index].Tag;
                newGhs.IsShowOrInput = 0;
                newGhs.ShowDialog();
            }
        }
  
    }
}
