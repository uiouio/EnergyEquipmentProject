using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Text.RegularExpressions;

namespace KuGuanXiTong
{
    public partial class CanShuSheZhi_LeiBieGuanLi_NewClass : Form
    {

        private GoodsBaseInfo newGoods;

        public GoodsBaseInfo NewGoods
        {
            get { return newGoods; }
            set { newGoods = value; }
        }

        Service.Categtory categtory = new Service.Categtory();

        private string pCode;

        private int flag;
        

        public CanShuSheZhi_LeiBieGuanLi_NewClass()
        {
            InitializeComponent();
        }

        private GoodsBaseInfo Pgoods = new GoodsBaseInfo();
        /// <summary>
        /// 重载传值
        /// </summary>
        /// <param name="str"></param>
        public CanShuSheZhi_LeiBieGuanLi_NewClass(GoodsBaseInfo Pg)
        {
            InitializeComponent();
            Pgoods = Pg;
            //SetAllTextKong();
            flag = 1;
        }

        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SetAllTextKong();
        }

        public void SetAllTextKong()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox7.Text = "";
            this.textBox6.Text = "";
        }
        /// <summary>
        /// 货物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                this.groupBox1.Enabled = true;
                flag = 2;
                this.checkBox1.Enabled = true;

                this.checkBox2.Enabled = true;
            }
        }
        /// <summary>
        /// 分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                this.groupBox1.Enabled = false;
                flag = 1;
                this.checkBox1.Enabled = false;

                this.checkBox2.Enabled = false;
            }
        }

        /// <summary>
        /// 套件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked == true)
            {
                this.groupBox1.Enabled = true;
                flag = 3;
                this.checkBox1.Enabled = true;

                this.checkBox2.Enabled = true;

            }
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (CheckText())
            {
                //GoodsBaseInfo pclass = new GoodsBaseInfo();
                newGoods = new GoodsBaseInfo();
                //pclass = categtory.GetClassByPcode(pCode);
                NewGoods.GoodsName = textBox1.Text;
                NewGoods.GoodsClassCode = textBox2.Text;
                NewGoods.Specifications = textBox5.Text;
                NewGoods.Material = textBox7.Text;
                NewGoods.Unit = textBox6.Text;

                NewGoods.GoodsParentClassId = Pgoods.Id;
                NewGoods.GoodsClassOrder = long.Parse(textBox4.Text);
                NewGoods.GoodsClassLevel = Pgoods.GoodsClassLevel + 1;
                NewGoods.GoodsClassDescribe = textBox3.Text;
                NewGoods.GoodsFlag = flag;
                if(this.checkBox2.Checked == true)
                {
                    NewGoods.IsWaring = 1;
                    NewGoods.WaringNum = long.Parse(this.textBox8.Text);
                }

                if (this.checkBox1.Enabled == true)
                {
                    if (this.checkBox1.Checked)
                        NewGoods.IsUniqueCode = 1;
                    else if (!this.checkBox1.Checked)
                        NewGoods.IsUniqueCode = 0;
                }
                else if (this.checkBox1.Enabled == false)
                {
                    NewGoods.IsUniqueCode = 0;
                }
                categtory.SaveOrUpdateEntity(newGoods);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
 
            }

        }

        public bool CheckText()
        {
            Regex classCode = new Regex("^[0-9]*$");
            Match m = classCode.Match(this.textBox2.Text);
            if (!m.Success || this.textBox2.Text == "")
            {
                MessageBox.Show("类别编码请输入数字！");
                return false;
            }
            if(textBox1.Text == "")
            {
                MessageBox.Show("物品分类名称不能为空！");
                return false;
            }

            Match m2 = classCode.Match(textBox4.Text);
            if( !m2.Success || textBox4.Text == "")
            {
                MessageBox.Show("类别顺序请填写一个数字！");
                return false;
            }

            if(this.textBox8.Enabled == true)
            {
                Match m3 = classCode.Match(this.textBox8.Text);
                if (!m3.Success || textBox8.Text == "")
                {
                    MessageBox.Show("预警数量请填写数字");
                    return false;
                }
            }

            return true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "")
            {
                MessageBox.Show("物品分类名称不能为空！");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            Regex classCode = new Regex("^[0-9]*$");
            Match m = classCode.Match(this.textBox2.Text);
            if (!m.Success || this.textBox2.Text == "")
            {
                MessageBox.Show("类别编码请输入数字！");
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            Regex classCode = new Regex("^[0-9]*$");
            Match m = classCode.Match(this.textBox4.Text);
            if (!m.Success || this.textBox4.Text == "")
            {
                MessageBox.Show("请输入数字");
            }
        }

        private void CanShuSheZhi_LeiBieGuanLi_NewClass_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = Pgoods.GoodsClassCode;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                this.textBox8.Enabled = true;
            }

            if(checkBox2.Checked == false)
            {
                this.textBox8.Enabled =  false;
            }
        }

    }
}
