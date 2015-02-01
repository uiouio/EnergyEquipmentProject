using System;
using System.Windows.Forms;
using EntityClassLibrary;
using CustomManageWindow.Service;
using CommonControl;
using Iesi.Collections.Generic;

namespace CustomManageWindow
{
    public partial class PersonalCustomInfo_add_Dialog2 : CommonControl.BaseForm
    {
        public int i = 0;
       
        ISet<CarBaseInfo> currentcars;
        public  CustomBaseInfo currentcustom;

        public CustomBaseInfo Currentcustom
        {
            get { return currentcustom; }
            set { currentcustom = value; }
        }
        
        CustomService ss = new CustomService();
         
        public PersonalCustomInfo_add_Dialog2()
        {
            InitializeComponent();
        }

        private void PersonalCustomInfo_add_Dialog2_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox1.Text = Currentcustom.Name;
            
            this.comboBox1.Text = Currentcustom.Sex;
            this.textBox3.Enabled = false;
            this.textBox3.Text = Currentcustom.IdentifyCardNo;
           
            this.textBox5.Text = Currentcustom.Telephone;
            
            this.textBox7.Text = Currentcustom.Email;
            
            this.textBox6.Text = Currentcustom.Phone;
            
            this.textBox8.Text = Currentcustom.QQ;
           
  
           
            this.textBox9.Text = Currentcustom.Address;
            
            this.textBox17.Text = Currentcustom.Remarks;
           
            #region 判断客户级别
            if (Currentcustom.CustomLevel == "1颗星")
            {
                this.radioButton1.Checked = true;
            }
            else if (Currentcustom.CustomLevel == "2颗星")
            {
                this.radioButton2.Checked = true;
            }
            else if (Currentcustom.CustomLevel == "3颗星")
            {
                this.radioButton5.Checked = true;
            }
            else if (Currentcustom.CustomLevel == "4颗星")
            {
                this.radioButton6.Checked = true;
            }
            else if (Currentcustom.CustomLevel == "5颗星")
            {
                this.radioButton7.Checked = true;
            }
            #endregion
            currentcars = Currentcustom.CarInfo;
            ShowCustomCarGrid();
        }
        public void ShowCustomCarGrid()
        {
            int i = 1;
            if (currentcars != null)
            {
                foreach (CarBaseInfo  s in currentcars)
                {
                    this.commonDataGridView2.Rows.Add(0, i.ToString(), s.PlateNumber, s.VehicleType, s.EngineIdentificationNumber, "查看");
                    commonDataGridView2.Rows[commonDataGridView2.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }
        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                CarManage_add_Dialog newGhs = new CarManage_add_Dialog("车辆详细信息");

                newGhs.CarBaseInfo = (CarBaseInfo)this.commonDataGridView2.Rows[this.commonDataGridView2.CurrentRow.Index].Tag;
                newGhs.IsShowOrInput = 0;

                newGhs.ShowDialog();
            }
          
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Currentcustom.Sex = comboBox1.Text;
            Currentcustom.Telephone = textBox5.Text;
            Currentcustom.Email = textBox7.Text;
            Currentcustom.Phone = this.textBox6.Text;
            Currentcustom.QQ = this.textBox8.Text;
        
            Currentcustom.Address = this.textBox9.Text;
            Currentcustom.Remarks = this.textBox17.Text;
            #region 判断客户级别
            if (radioButton1.Checked)
            {
                Currentcustom.CustomLevel = "1颗星";
            }
            else if (radioButton2.Checked)
            {
                Currentcustom.CustomLevel = "2颗星";
            }
            else if (radioButton5.Checked)
            {
                Currentcustom.CustomLevel = "3颗星";
            }
            else if (radioButton6.Checked)
            {
                Currentcustom.CustomLevel = "4颗星";
            }
            else if (radioButton7.Checked)
            {
                Currentcustom.CustomLevel = "5颗星";
            }
            #endregion
            ss.Save(Currentcustom);
            MessageBox.Show("保存成功！");
            this.DialogResult = DialogResult.OK;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            CarManage_add_Dialog clxx = new CarManage_add_Dialog("车辆信息录入");

            clxx.IsShowOrInput = 1;

            if (clxx.ShowDialog() == DialogResult.OK)
            {
                commonDataGridView2.Rows.Add(0, 1, clxx.CarBaseInfo.PlateNumber, clxx.CarBaseInfo.VehicleType, clxx.CarBaseInfo.EngineIdentificationNumber, "编辑");
                commonDataGridView2.Rows[commonDataGridView2.Rows.Count - 1].Tag = clxx.CarBaseInfo;
                currentcars.Add(clxx.CarBaseInfo);
            }
          
        }
    }
}
