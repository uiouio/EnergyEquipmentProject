using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow.Service;
using CommonControl;

namespace HeTongGuanLi
{
    public partial class HuiYuanDengJi_add_Dialog : Form
    { /// <summary>
        /// 是用来展示数据还是输入数据，1用来输入数据，0用来展示数据
        /// </summary>
        private int isShowOrInput;
        public int IsShowOrInput
        {
            get { return isShowOrInput; }
            set { isShowOrInput = value; }
        }
        public int IfSaved = 0;
        private HuiYuanBaseInfo huiYuanBaseInfo;

        public HuiYuanBaseInfo HuiYuanBaseInfo
        {
            get { return huiYuanBaseInfo; }
            set { huiYuanBaseInfo = value; }
        }
        public HuiYuanDengJi_add_Dialog()
        {
            InitializeComponent();
        }
        public HuiYuanDengJi_add_Dialog(string headtextname)
        {
          
            this.Text = headtextname;
            InitializeComponent();
        }
        /// <summary>
        /// 输入会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            CustomService ss = new CustomService();
            #region 录入信息
            if (this.IsShowOrInput == 1)
            {
                HuiYuanBaseInfo hy = new HuiYuanBaseInfo();

                hy.Name = textBox1.Text;

                hy.Birthday = textBox2.Text;
                #region 判断婚否
                if (radioButton1.Checked)
                {
                    hy.Marriage = (int)HuiYuanBaseInfo.Marriage1.Marriaged;
                }

                else
                    if (radioButton2.Checked)
                    {

                        hy.Marriage = (int)HuiYuanBaseInfo.Marriage1.unMarriaged;
                    }
                #endregion

                #region 判断性别
                if (radioButton9.Checked)
                {
                    hy.Sex = (int)HuiYuanBaseInfo.Sex1.Man;
                }

                else if (radioButton8.Checked)
                {

                    hy.Sex = (int)HuiYuanBaseInfo.Sex1.Female;
                }
                #endregion

                hy.Address = textBox3.Text;

                hy.Phone1 = textBox4.Text;

                hy.Phone2 = textBox9.Text;

                hy.LicenseCategory = textBox5.Text;
                if (textBox6.Text == "")
                {
                    hy.DrivingExperience = 0;
                }
                else
                {
                    hy.DrivingExperience = float.Parse(textBox6.Text);
                }

                hy.CompanyName = textBox8.Text;

                hy.MonthlySalary = comboBox5.SelectedText;

                hy.ComanyIdentity = comboBox7.SelectedText;

                hy.ComanySize = comboBox6.SelectedText;

                #region 判断业务意向
                if (radioButton3.Checked)
                {
                    hy.BusinessIntent = (int)HuiYuanBaseInfo.insent.Changtu;
                }

                else if (radioButton4.Checked)
                {

                    hy.BusinessIntent = (int)HuiYuanBaseInfo.insent.Duantu;
                }

                else if (radioButton5.Checked)
                {

                    hy.BusinessIntent = (int)HuiYuanBaseInfo.insent.Junke;
                }

                #endregion

                #region 判断运输合格证
                if (radioButton11.Checked)
                {
                    hy.DangerousGoodsCertificate = (int)HuiYuanBaseInfo.weixian.YES;

                }
                else if (radioButton10.Checked)
                {

                    hy.DangerousGoodsCertificate = (int)HuiYuanBaseInfo.weixian.NO;

                }

                #endregion
                #region 判断押运资格证
                if (radioButton13.Checked)
                {
                    hy.EscortSyndrome = (int)HuiYuanBaseInfo.yayun.YES;
                }
                else
                    if (radioButton12.Checked)
                    {
                        hy.EscortSyndrome = (int)HuiYuanBaseInfo.yayun.NO;

                    }
                #endregion

                hy.PlateNumber = textBox7.Text;
                if (textBox10.Text == "")
                {
                    hy.Mileage = 0;
                }
                else
                {
                    hy.Mileage = float.Parse(textBox10.Text);
                }
                hy.VehicleBrand = textBox33.Text;

                hy.VehicleType = comboBox9.SelectedText;

                hy.FuelType = comboBox10.SelectedText;

                hy.SupplyMode = comboBox11.SelectedText;

                if (textBox11.Text == "")
                {
                    hy.FuelConsumption = 0;
                }
                else
                {
                    hy.FuelConsumption = float.Parse(textBox11.Text);
                }

                if (textBox12.Text == "")
                {
                    hy.CarCondition = 0;
                }
                else
                {
                    hy.CarCondition = float.Parse(textBox12.Text);
                }

                hy.Running = textBox13.Text;

                hy.VehicleCompany = textBox14.Text;

                hy.Location = textBox15.Text;

                if (textBox16.Text == "")
                {
                    hy.VehicleNumber = 0;
                }
                else
                {
                    hy.VehicleNumber = float.Parse(textBox16.Text);
                }

                hy.ModificationTime = dateTimePicker1.Value.Ticks;

                hy.ModifiedPlace = textBox17.Text;

                hy.ModifiedType = comboBox12.SelectedText;

                if (textBox18.Text == "")
                {
                    hy.AfterModificationFuelConsumption = 0;
                }
                else
                {
                    hy.AfterModificationFuelConsumption = float.Parse(textBox18.Text);
                }

                if (textBox19.Text == "")
                {
                    hy.AfterModificationGasConsumption = 0;
                }
                else
                {
                    hy.AfterModificationGasConsumption = float.Parse(textBox19.Text);

                }

                hy.RefitInformation = comboBox13.SelectedText;

                hy.ReturnMode = comboBox14.SelectedText;
                #region 运输类型
                // 运输货物类型
                string s1 = null, s2 = null, s3 = null, s4 = null, s = null;
                if (checkBox1.Checked == true)
                {
                    s1 = ((int)HuiYuanBaseInfo.GoodType.one).ToString();
                }
                if (checkBox2.Checked == true)
                {
                    s2 = ((int)HuiYuanBaseInfo.GoodType.two).ToString();
                }
                if (checkBox3.Checked == true)
                {
                    s3 = ((int)HuiYuanBaseInfo.GoodType.three).ToString();
                }
                if (checkBox4.Checked == true)
                {
                    s4 = ((int)HuiYuanBaseInfo.GoodType.common).ToString();
                }
                s = s1 + s2 + s3 + s4;
                hy.TypesGoods = s;
                #endregion
                hy.MainLine = textBox20.Text + textBox21.Text + textBox22.Text;

                //hy.MainTime = textBox25.Text + textBox26.Text + textBox27.Text;
                if (this.textBox25.Text == "")
                {
                    hy.MainTime = 0;
                }
                else
                {
                    hy.MainTime = float.Parse(this.textBox25.Text);
                }


                if (textBox23.Text == "")
                {
                    hy.FillingStation = 0;
                }
                else
                {
                    hy.FillingStation = float.Parse(textBox23.Text);
                }

                hy.OperatingUnit = textBox24.Text + textBox28.Text + textBox30.Text;

                hy.MaintenanceSites = textBox30.Text;

                hy.Opinion = textBox32.Text;

                hy.Help = textBox31.Text;


                if (radioButton6.Checked)
                {
                    hy.MembershipType = (int)HuiYuanBaseInfo.huiyuan.zhuti;
                }
                else if (radioButton7.Checked)
                {
                    hy.MembershipType = (int)HuiYuanBaseInfo.huiyuan.teyao;

                }
                hy.RegistrationTime = dateTimePicker2.Value.Ticks;

                ss.SaveOrUpdateEntity(hy);
                IfSaved = 1;
                MessageBox.Show("添加成功");
              this.Close();
            }
            #endregion
            #region 修改信息
            else if (IsShowOrInput == 0)
            {
                HuiYuanBaseInfo.Birthday = this.textBox2.Text;
                if (radioButton1.Checked)
                {
                    HuiYuanBaseInfo.Marriage = (int)HuiYuanBaseInfo.Marriage1.Marriaged;
                }

                else if (radioButton2.Checked)
                {

                    HuiYuanBaseInfo.Marriage = (int)HuiYuanBaseInfo.Marriage1.unMarriaged;
                }
                #region 判断性别
                if (radioButton9.Checked)
                {
                    HuiYuanBaseInfo.Sex = (int)HuiYuanBaseInfo.Sex1.Man;
                }

                else if (radioButton8.Checked)
                {

                    HuiYuanBaseInfo.Sex = (int)HuiYuanBaseInfo.Sex1.Female;
                }
                #endregion

                HuiYuanBaseInfo.Address = textBox3.Text;

                HuiYuanBaseInfo.Phone1 = textBox4.Text;

                HuiYuanBaseInfo.Phone2 = textBox9.Text;

                HuiYuanBaseInfo.LicenseCategory = textBox5.Text;
                if (textBox6.Text == "")
                {
                    HuiYuanBaseInfo.DrivingExperience = 0;
                }
                else
                {
                    HuiYuanBaseInfo.DrivingExperience = float.Parse(textBox6.Text);
                }

                HuiYuanBaseInfo.CompanyName = textBox8.Text;

                HuiYuanBaseInfo.MonthlySalary = comboBox5.SelectedText;

                HuiYuanBaseInfo.ComanyIdentity = comboBox7.SelectedText;

                HuiYuanBaseInfo.ComanySize = comboBox6.SelectedText;
                #region 判断业务意向
                if (radioButton3.Checked)
                {
                    HuiYuanBaseInfo.BusinessIntent = (int)HuiYuanBaseInfo.insent.Changtu;
                }

                else if (radioButton4.Checked)
                {

                    HuiYuanBaseInfo.BusinessIntent = (int)HuiYuanBaseInfo.insent.Duantu;
                }

                else if (radioButton5.Checked)
                {

                    HuiYuanBaseInfo.BusinessIntent = (int)HuiYuanBaseInfo.insent.Junke;
                }

                #endregion

                #region 判断运输合格证
                if (radioButton11.Checked)
                {
                    HuiYuanBaseInfo.DangerousGoodsCertificate = (int)HuiYuanBaseInfo.weixian.YES;

                }
                else if (radioButton10.Checked)
                {

                    HuiYuanBaseInfo.DangerousGoodsCertificate = (int)HuiYuanBaseInfo.weixian.NO;

                }

                #endregion
                #region 判断押运资格证
                if (radioButton13.Checked)
                {
                    HuiYuanBaseInfo.EscortSyndrome = (int)HuiYuanBaseInfo.yayun.YES;
                }
                else if (radioButton12.Checked)
                {
                    HuiYuanBaseInfo.EscortSyndrome = (int)HuiYuanBaseInfo.yayun.NO;

                }
                #endregion
                HuiYuanBaseInfo.PlateNumber = textBox7.Text;
                if (textBox10.Text == "")
                {
                    HuiYuanBaseInfo.Mileage = 0;
                }
                else
                {
                    HuiYuanBaseInfo.Mileage = float.Parse(textBox10.Text);
                }
                HuiYuanBaseInfo.VehicleBrand = textBox33.Text;

                HuiYuanBaseInfo.VehicleType = comboBox9.SelectedText;

                HuiYuanBaseInfo.FuelType = comboBox10.SelectedText;

                HuiYuanBaseInfo.SupplyMode = comboBox11.SelectedText;

                if (textBox11.Text == "")
                {
                    HuiYuanBaseInfo.FuelConsumption = 0;
                }
                else
                {
                    HuiYuanBaseInfo.FuelConsumption = float.Parse(textBox11.Text);
                }

                if (textBox12.Text == "")
                {
                    HuiYuanBaseInfo.CarCondition = 0;
                }
                else
                {
                    HuiYuanBaseInfo.CarCondition = float.Parse(textBox12.Text);
                }

                HuiYuanBaseInfo.Running = textBox13.Text;

                HuiYuanBaseInfo.VehicleCompany = textBox14.Text;

                HuiYuanBaseInfo.Location = textBox15.Text;

                if (textBox16.Text == "")
                {
                    HuiYuanBaseInfo.VehicleNumber = 0;
                }
                else
                {
                    HuiYuanBaseInfo.VehicleNumber = float.Parse(textBox16.Text);
                }

                HuiYuanBaseInfo.ModificationTime = dateTimePicker1.Value.Ticks;

                HuiYuanBaseInfo.ModifiedPlace = textBox17.Text;

                HuiYuanBaseInfo.ModifiedType = comboBox12.SelectedText;

                if (textBox18.Text == "")
                {
                    HuiYuanBaseInfo.AfterModificationFuelConsumption = 0;
                }
                else
                {
                    HuiYuanBaseInfo.AfterModificationFuelConsumption = float.Parse(textBox18.Text);
                }

                if (textBox19.Text == "")
                {
                    HuiYuanBaseInfo.AfterModificationGasConsumption = 0;
                }
                else
                {
                    HuiYuanBaseInfo.AfterModificationGasConsumption = float.Parse(textBox19.Text);

                }

                HuiYuanBaseInfo.RefitInformation = comboBox13.SelectedText;

                HuiYuanBaseInfo.ReturnMode = comboBox14.SelectedText;
                #region 运输类型
                // 运输货物类型
                string s1 = null, s2 = null, s3 = null, s4 = null, s = null;
                if (checkBox1.Checked == true)
                {
                    s1 = ((int)HuiYuanBaseInfo.GoodType.one).ToString();
                }
                if (checkBox2.Checked == true)
                {
                    s2 = ((int)HuiYuanBaseInfo.GoodType.two).ToString();
                }
                if (checkBox3.Checked == true)
                {
                    s3 = ((int)HuiYuanBaseInfo.GoodType.three).ToString();
                }
                if (checkBox4.Checked == true)
                {
                    s4 = ((int)HuiYuanBaseInfo.GoodType.common).ToString();
                }
                s = s1 + s2 + s3 + s4;
                HuiYuanBaseInfo.TypesGoods = s;
                #endregion
                HuiYuanBaseInfo.MainLine = textBox20.Text + textBox21.Text + textBox22.Text;

                //hy.MainTime = textBox25.Text + textBox26.Text + textBox27.Text;
                if (this.textBox25.Text == "")
                {
                    HuiYuanBaseInfo.MainTime = 0;
                }
                else
                {
                    HuiYuanBaseInfo.MainTime = float.Parse(this.textBox25.Text);
                }


                if (textBox23.Text == "")
                {
                    HuiYuanBaseInfo.FillingStation = 0;
                }
                else
                {
                    HuiYuanBaseInfo.FillingStation = float.Parse(textBox23.Text);
                }

                HuiYuanBaseInfo.OperatingUnit = textBox24.Text + textBox28.Text + textBox30.Text;

                HuiYuanBaseInfo.MaintenanceSites = textBox30.Text;

                HuiYuanBaseInfo.Opinion = textBox32.Text;

                HuiYuanBaseInfo.Help = textBox31.Text;


                if (radioButton6.Checked)
                {
                    HuiYuanBaseInfo.MembershipType = (int)HuiYuanBaseInfo.huiyuan.zhuti;
                }
                else if (radioButton7.Checked)
                {
                    HuiYuanBaseInfo.MembershipType = (int)HuiYuanBaseInfo.huiyuan.teyao;

                }
                HuiYuanBaseInfo.RegistrationTime = dateTimePicker2.Value.Ticks;
            #endregion
                ss.SaveOrUpdateEntity(HuiYuanBaseInfo);
                IfSaved = 1;
                MessageBox.Show("修改成功");
                this.Close();
            }
          
        }
        /// <summary>
        /// 查看会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HuiYuanDengJi_add_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            if (IsShowOrInput == 0)
            {
                this.Text = "会员详细信息";
                this.textBox1.Enabled = false;
                this.textBox1.Text = HuiYuanBaseInfo.Name;
                this.textBox2.Text = HuiYuanBaseInfo.Birthday;
                if(HuiYuanBaseInfo.Marriage==(int)HuiYuanBaseInfo.Marriage1.Marriaged)
                {
                    this.radioButton1.Checked = true;

                }
                else if (HuiYuanBaseInfo.Marriage == (int)HuiYuanBaseInfo.Marriage1.unMarriaged)
                {
                    this.radioButton2.Checked = true;

                }
                if(HuiYuanBaseInfo.Sex==(int)HuiYuanBaseInfo.Sex1.Man)
                {
                    this.radioButton9.Checked = true;
                }
                else if (HuiYuanBaseInfo.Sex == (int)HuiYuanBaseInfo.Sex1.Female)
                {
                    this.radioButton8.Checked = true;
                }
                this.textBox3.Text = HuiYuanBaseInfo.Address;
                this.textBox4.Text = HuiYuanBaseInfo.Phone1;
                this.textBox9.Text = HuiYuanBaseInfo.Phone2;
                this.textBox5.Text = HuiYuanBaseInfo.LicenseCategory;
                this.textBox6.Text = HuiYuanBaseInfo.DrivingExperience.ToString();
                this.textBox8.Text = HuiYuanBaseInfo.CompanyName;
                this.comboBox5.Text = HuiYuanBaseInfo.MonthlySalary;
                this.comboBox7.Text = HuiYuanBaseInfo.ComanyIdentity;
                this.comboBox6.Text = HuiYuanBaseInfo.ComanySize;
                this.comboBox4.Text = HuiYuanBaseInfo.ComanyProperty;
                if(HuiYuanBaseInfo.BusinessIntent==(int)HuiYuanBaseInfo.insent.Changtu)
                {
                    this.radioButton3.Checked = true;
                }
                else if (HuiYuanBaseInfo.BusinessIntent == (int)HuiYuanBaseInfo.insent.Duantu)
                {
                    this.radioButton4.Checked = true;
                }
                else if (HuiYuanBaseInfo.BusinessIntent == (int)HuiYuanBaseInfo.insent.Junke)
                {
                    this.radioButton5.Checked = true;
                }
                if(HuiYuanBaseInfo.DangerousGoodsCertificate==(int)HuiYuanBaseInfo.weixian.YES)
                {
                    this.radioButton11.Checked = true;
                }
                else if (HuiYuanBaseInfo.DangerousGoodsCertificate == (int)HuiYuanBaseInfo.weixian.NO)
                {
                    this.radioButton10.Checked = true;
                }
                if(HuiYuanBaseInfo.EscortSyndrome==(int)HuiYuanBaseInfo.yayun.YES)
                {
                    this.radioButton13.Checked = true;
                }
                else  if (HuiYuanBaseInfo.EscortSyndrome == (int)HuiYuanBaseInfo.yayun.NO)
                {
                    this.radioButton12.Checked = true;
                }
                this.textBox7.Text = HuiYuanBaseInfo.PlateNumber;
                this.textBox10.Text = HuiYuanBaseInfo.Mileage.ToString();
                this.textBox33.Text = HuiYuanBaseInfo.VehicleBrand;
                this.comboBox9.Text = HuiYuanBaseInfo.VehicleType;
                this.comboBox10.Text = HuiYuanBaseInfo.FuelType;
                this.comboBox11.Text = HuiYuanBaseInfo.SupplyMode;
                this.textBox11.Text = HuiYuanBaseInfo.FuelConsumption.ToString();
                this.textBox12.Text = HuiYuanBaseInfo.CarCondition.ToString();
                this.textBox13.Text = HuiYuanBaseInfo.Running;
                this.textBox14.Text = HuiYuanBaseInfo.VehicleCompany;
                this.textBox15.Text = HuiYuanBaseInfo.Location;
                this.textBox16.Text = HuiYuanBaseInfo.VehicleNumber.ToString();
                long ticks = HuiYuanBaseInfo.ModificationTime;
                DateTime dt = new DateTime(ticks);
                this.dateTimePicker1.Value = dt;
                this.textBox17.Text = HuiYuanBaseInfo.ModifiedPlace;
                this.comboBox12.Text = HuiYuanBaseInfo.ModifiedType;
                this.textBox18.Text = HuiYuanBaseInfo.AfterModificationGasConsumption.ToString();
                this.textBox19.Text = HuiYuanBaseInfo.AfterModificationFuelConsumption.ToString();
                this.comboBox13.Text = HuiYuanBaseInfo.RefitInformation;
                this.comboBox14.Text = HuiYuanBaseInfo.ReturnMode;
                ///运输货物类型
                #region 运输类型
                if(HuiYuanBaseInfo.TypesGoods=="1   ")
                {
                    this.checkBox1.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == " 2  ")
                {
                    this.checkBox2.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == "  3 ")
                {
                    this.checkBox3.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == "   0")
                {
                    this.checkBox4.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == "12  ")
                {
                    this.checkBox1.Checked = true;
                    this.checkBox2.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == "1 3 ")
                {
                    this.checkBox1.Checked = true;
                    this.checkBox3.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == "1  0")
                {
                    this.checkBox1.Checked = true;
                    this.checkBox4.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == " 23 ")
                {
                    this.checkBox2.Checked = true;
                    this.checkBox3.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == " 2 0")
                {
                    this.checkBox2.Checked = true;
                    this.checkBox4.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == "  30")
                {
                    this.checkBox3.Checked = true;
                    this.checkBox4.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == "123 ")
                {
                    this.checkBox2.Checked = true;
                    this.checkBox3.Checked = true;
                    this.checkBox1.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == " 230")
                {
                    this.checkBox2.Checked = true;
                    this.checkBox3.Checked = true;
                    this.checkBox4.Checked = true;
                }
                else if (HuiYuanBaseInfo.TypesGoods == "1230")
                {
                    this.checkBox1.Checked = true;
                    this.checkBox2.Checked = true;
                    this.checkBox3.Checked = true;
                    this.checkBox4.Checked = true;
                }
                #endregion
                this.textBox20.Text = HuiYuanBaseInfo.MainLine;
                this.textBox25.Text = huiYuanBaseInfo.MainTime.ToString();
                this.textBox23.Text = HuiYuanBaseInfo.FillingStation.ToString();
                this.textBox24.Text = HuiYuanBaseInfo.OperatingUnit;
                this.textBox30.Text = HuiYuanBaseInfo.MaintenanceSites;
                this.textBox32.Text = HuiYuanBaseInfo.Opinion;
                this.textBox31.Text = HuiYuanBaseInfo.Help;
                if(HuiYuanBaseInfo.MembershipType== (int)HuiYuanBaseInfo.huiyuan.zhuti)
                {
                    this.radioButton6.Checked = true;
                }
                else if (HuiYuanBaseInfo.MembershipType == (int)HuiYuanBaseInfo.huiyuan.teyao)
                {
                    this.radioButton7.Checked = true;
                }
                long ticks1 = HuiYuanBaseInfo.RegistrationTime;
                DateTime dt1= new DateTime(ticks1);
                this.dateTimePicker2.Value = dt1;
            }
            if (IsShowOrInput == 1)
            {
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            }

        }
    }
}
