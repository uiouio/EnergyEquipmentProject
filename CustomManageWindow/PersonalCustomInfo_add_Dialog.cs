using System;
using System.Drawing;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow.Service;
using CommonControl;
using CommonWindow;
using Iesi.Collections.Generic;
using System.Text.RegularExpressions;
namespace CustomManageWindow
{
    public partial class PersonalCustomInfo_add_Dialog : CommonControl.BaseForm
    {
       
     
        ISet<CarBaseInfo> car = new HashedSet<CarBaseInfo>();
        public int IfSaved = 0;
        CustomService ss = new CustomService();
        public PersonalCustomInfo_add_Dialog()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.textBox2.Enabled = false;
            this.textBox2.Text = this.UserInfo.Name;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarManage_add_Dialog clxx = new CarManage_add_Dialog("车辆信息录入") ;
            clxx.IsShowOrInput = 1;
            if (clxx.ShowDialog() == DialogResult.OK)
            {
                commonDataGridView1.Rows.Add(0,1,clxx.CarBaseInfo .PlateNumber,clxx .CarBaseInfo .VehicleType,clxx .CarBaseInfo .EngineIdentificationNumber,"编辑");
                commonDataGridView1.Rows[commonDataGridView1.Rows.Count-1].Tag = clxx.CarBaseInfo;
                car.Add(clxx.CarBaseInfo);
              
            }
        }
      
        

        private void button2_Click(object sender, EventArgs e)
        {

            CustomService ss = new CustomService();

            CustomBaseInfo cb = new CustomBaseInfo();

            cb.Name = textBox1.Text;

            cb.Sex = comboBox1.Text;
            cb.IdentifyCardNo = textBox3.Text;

            cb.Phone = textBox6.Text;

            cb.Telephone = textBox5.Text;

            cb.QQ = textBox8.Text;

            cb.Email = textBox7.Text;

            cb.Address = textBox9.Text;

            cb.Remarks = textBox17.Text;
            cb.Unit = textBox4.Text;
            cb.Category=(int)CustomBaseInfo.kehuleibie.yixiangkehu;
            cb.Status = (int)CustomBaseInfo.PersonalOrCompany.Personal;
            cb.Postcode = textBox11.Text;
            cb.RegistrationTime = DateTime.Now.Ticks;
            cb.CarInfo = car;
            cb.UserID = this.UserInfo;
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
            if (this.textBox1.Text == "" || this.textBox3.Text == ""||this.textBox5.Text=="")
            {
                MessageBox.Show("请输入必要的信息");

            }
            else
            {
                ss.SaveOrUpdateEntity(cb);
                MessageBox.Show("添加成功");
                IfSaved = 1;
                this.Close();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            CustomService ss = new CustomService();
            IList cbList = ss.loadEntityList("from CustomBaseInfo where IdentifyCardNo='" + textBox3.Text + "'");
            if (cbList != null && cbList.Count == 1)
            {
                MessageBox.Show("客户已经存在，请添加新客户");
                textBox3.Text = "";
                textBox3.Focus();
            }
            if ((!Regex.IsMatch(textBox3.Text, @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)))
            {
                MessageBox.Show("请输入正确的身份证号码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

       

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

       
        
    }
}
