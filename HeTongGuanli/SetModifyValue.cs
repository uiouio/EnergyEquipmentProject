using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using HeTongGuanLi.Service;
using System.Collections;
namespace HeTongGuanLi
{
    public partial class SetModifyValue : CommonControl.CommonTabPage
    {
        ContractService ss = new ContractService();

        IList currentcars;

        public SetModifyValue()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定修改气瓶金额设置么", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.textBox3.Enabled = true;
                this.comboBox3.Enabled = true;
                currentcars = ss.SelectCarsCylinderType();
                if (currentcars != null)
                {
                    foreach(CarBaseInfo a in currentcars)
                    {
                         this.comboBox2.Items.Add(a.CylinderType);
                    }
                }
                else
                {
                    MessageBox.Show("请添加新的气瓶型号");
                    this.comboBox2.Text = "";
                }
            }
        }

        private void SetModifyValue_Load(object sender, EventArgs e)
        {

            this.radioButton1.Checked = true;
            this.comboBox2.Text = "φ325*50";
            this.comboBox3.Text = "1";
            this.textBox3.Text = "3700";
            this.comboBox4.Text = "小轿车";
            this.comboBox3.Enabled = false;
            this.textBox3.Enabled = false;
            this.comboBox2.Enabled = true;
            this.comboBox4.Items.Add("小轿车");
            this.comboBox4.Items.Add("出租车");
            this.comboBox4.Items.Add("重卡");
            this.comboBox4.Items.Add("水泥搅拌车");
            this.comboBox4.Items.Add("装载车");
            this.comboBox4.Items.Add("推土机");
            this.comboBox4.Items.Add("公交车");
            this.comboBox4.Items.Add("洒水车");
            this.comboBox4.Items.Add("垃圾车");
            this.comboBox4.Items.Add("船");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            currentcars = ss.SelectCarsCylinderType();
            foreach (CarBaseInfo a in currentcars)
            {
                #region φ325*50型号
                if (this.comboBox2.Text == "φ325*50")
                {
                    if (a.CylinderType == "φ325*50" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "3700";
                    }
                    else if (a.CylinderType == "φ325*50" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ325*55型号
                else if (this.comboBox2.Text == "φ325*55")
                {
                    if (a.CylinderType == "φ325*55" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "3800";
                    }
                    else if(a.CylinderType == "φ325*55" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ325*60型号
                else if (this.comboBox2.Text == "φ325*60")
                {
                    if (a.CylinderType == "φ325*60" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "3850";
                    }
                    else if (a.CylinderType == "φ325*60" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ325*65型号
                else   if (this.comboBox2.Text == "φ325*65")
                {
                    if (a.CylinderType == "φ325*65" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "3900";
                    }
                    else if (a.CylinderType == "φ325*65" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ356*65型号
                else  if (this.comboBox2.Text == "φ356*65")
                {
                    if (a.CylinderType == "φ356*65" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "3950";
                    }
                    else if (a.CylinderType == "φ325*65" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ325*70型号
                else  if (this.comboBox2.Text == "φ325*70")
                {
                    if (a.CylinderType == "φ325*70" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "4000";
                    }
                    else if (a.CylinderType == "φ325*70" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ356*70型号
                else  if (this.comboBox2.Text == "φ356*70")
                {
                    if (a.CylinderType == "φ356*70" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "4050";
                    }
                    else if (a.CylinderType == "φ356*70" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ356*75型号
                else   if (this.comboBox2.Text == "φ356*75")
                {
                    if (a.CylinderType == "φ356*75" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "4100";
                    }
                    else if (a.CylinderType == "φ356*75" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ325*80型号
                else if (this.comboBox2.Text == "φ325*80")
                {
                    if (a.CylinderType == "φ325*80" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "4100";
                    }
                    else if (a.CylinderType == "φ325*80" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ356*80型号
                else if (this.comboBox2.Text == "φ356*80")
                {
                    if (a.CylinderType == "φ356*80" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "4150";
                    }
                    else if (a.CylinderType == "φ356*80" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ406*87型号
                else if (this.comboBox2.Text == "φ406*87")
                {
                    if (a.CylinderType == "φ406*87" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "4300";
                    }
                    else if (a.CylinderType == "φ406*87" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ356*100型号
                else if (this.comboBox2.Text == "φ356*100")
                {
                    if (a.CylinderType == "φ356*100" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "4350";
                    }
                    else if (a.CylinderType == "φ356*100" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region φ406*100型号
                else  if (this.comboBox2.Text == "φ406*100")
                {
                    if (a.CylinderType == "φ406*100" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = "4400";
                    }
                    else if (a.CylinderType == "φ356*100" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region 140L-150L型号
                else if (this.comboBox2.Text == "140L-150L")
                {
                    this.comboBox3.Enabled = true;
                    if (a.CylinderType == "140L-150L" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = (50000 - Convert.ToInt16(this.comboBox3.Text) * 2500).ToString();
                    }
                    else if (a.CylinderType == "140L-150L" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region 100L-120L型号
                else if (this.comboBox2.Text == "100L-120L")
                {
                    this.comboBox3.Enabled = true;
                    if (a.CylinderType=="100L-120L"&& a.CylinderValue == 0)
                    {
                        this.textBox3.Text = (48000 - Convert.ToInt16(this.comboBox3.Text) * 2000).ToString();
                    }
                    else if (a.CylinderType == "100L-120L" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region 100L以下型号
                else if (this.comboBox2.Text == "100L以下")
                {
                    this.comboBox3.Enabled = true;
                    if (a.CylinderType == "100L以下" && a.CylinderValue == 0)
                    {
                        this.textBox3.Text = (46000 - Convert.ToInt16(this.comboBox3.Text) * 1500).ToString();
                    }
                    else if (a.CylinderType == "100L以下" && a.CylinderValue != 0)
                    {
                        this.textBox3.Text = a.CylinderValue.ToString();
                    }
                }
                #endregion
                #region LNG气瓶
                else
                {
                    this.comboBox3.Enabled=true;
                    this.comboBox2.Items.Add("1");
                    this.comboBox2.Items.Add("2");
                    if(this.comboBox3.Text=="2")
                    {
                        if (a.CylinderType == "200L" || a.CylinderType == "275L" || a.CylinderType == "375L" || a.CylinderType == "450L" || a.CylinderType == "500L" && a.CylinderValue == 0)
                        {
                            this.textBox3.Text = "90000";
                        }
                        else if (a.CylinderType == "200L" || a.CylinderType == "275L" || a.CylinderType == "375L" || a.CylinderType == "450L" || a.CylinderType == "500L" && a.CylinderValue != 0)
                        {
                            this.textBox3.Text = a.CylinderValue.ToString();
                        }
                    }
                    else 
                    {
                        if (a.CylinderType == "200L" || a.CylinderType == "275L" || a.CylinderType == "375L" || a.CylinderType == "450L" || a.CylinderType == "500L" && a.CylinderValue == 0)
                        {
                            this.textBox3.Text = "60000";
                        }
                        else if (a.CylinderType == "200L" || a.CylinderType == "275L" || a.CylinderType == "375L" || a.CylinderType == "450L" || a.CylinderType == "500L" && a.CylinderValue != 0)
                        {
                            this.textBox3.Text = a.CylinderValue.ToString();
                        }
                    }
                }
                #endregion
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true )
            {
                this.comboBox2.Items.Clear();
                this.comboBox2.Text = "";
                string s1=this.comboBox4.Text;
                currentcars = ss.SelectCNGCars(s1);
                for (int i = 0; i < currentcars.Count;i++ )
                {
                    this.comboBox2.Items.Add(currentcars[i]);
                }
                /*this.comboBox2.Items.Add("φ325*50");
                this.comboBox2.Items.Add("φ325*55");
                this.comboBox2.Items.Add("φ325*60");
                this.comboBox2.Items.Add("φ325*65");
                this.comboBox2.Items.Add("φ356*65");
                this.comboBox2.Items.Add("φ325*70");
                this.comboBox2.Items.Add("φ356*70");
                this.comboBox2.Items.Add("φ356*75");
                this.comboBox2.Items.Add("φ325*80");
                this.comboBox2.Items.Add("φ356*80");
                this.comboBox2.Items.Add("φ406*87");
                this.comboBox2.Items.Add("φ356*100");
                this.comboBox2.Items.Add("φ406*100");*/

            }
           
            else if (this.radioButton2.Checked == true && (comboBox4.Text != "小轿车" && comboBox4.Text != "出租车"))
            {
                this.comboBox2.Items.Clear();
                this.comboBox2.Text = "";
                string s1 = this.comboBox4.Text;
                currentcars = ss.SelectLNGCars(s1);
                foreach (CarBaseInfo a in currentcars)
                {
                    if(a.CylinderType!=null)
                    {
                        this.comboBox2.Items.Add(a.CylinderType);
                    }
                    
                }
               /* this.comboBox2.Items.Add("200L");
                this.comboBox2.Items.Add("275L");
                this.comboBox2.Items.Add("375L");
                this.comboBox2.Items.Add("450L");
                this.comboBox2.Items.Add("500L");*/

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = this.textBox3.Text.Trim();
            string s2 = this.comboBox2.Text.Trim();
            ss.UpdateModifyValue(s1, s2);

            //string sql = "update CarBaseInfo set CylinderValue=" + s1 + "  where  CylinderType = '" + s2 + " 'and ModificationContractId is null and State = " + (int)BaseEntity.stateEnum.Normal;
            // ss.ExecuteSQL(sql);
            MessageBox.Show("修改成功！");

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked == true)
            {
                this.comboBox4.Items.Clear();
                this.comboBox4.Items.Add("重卡");
                this.comboBox4.Items.Add("水泥搅拌车");
                this.comboBox4.Items.Add("装载车");
                this.comboBox4.Items.Add("推土机");
                this.comboBox4.Items.Add("公交车");
                this.comboBox4.Items.Add("洒水车");
                this.comboBox4.Items.Add("垃圾车");
                this.comboBox4.Items.Add("船");

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

    }
}
