using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonMethod;

namespace KuGuanXiTong
{
    public partial class UNDORuKu_TianJiaHuoWu : CommonControl.BaseForm
    {

        /// <summary>
        /// 获取新添加的货物数量金额
        /// </summary>
        Stock newstock;
        public Stock NewStock
        {
            get { return newstock; }
            set { newstock = value; }
        }


        /// <summary>
        /// 获取新添加的物品
        /// </summary>
        GoodsBaseInfo newGoods;
        public GoodsBaseInfo NewGoods
        {
            get { return newGoods; }
            set { newGoods = value; }
        }


        /// <summary>
        ///获取备注值 
        /// </summary>
        string newRemark;
        public string NewRemark
        {
            get { return newRemark; }
            set { newRemark = value; }
        }

        TestInput test = new TestInput();

        public UNDORuKu_TianJiaHuoWu()
        {
            InitializeComponent();
            NewStock = new Stock();
            NewGoods = new GoodsBaseInfo();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NewGoods = null;
            this.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategtoryTreeview goodstree = new CategtoryTreeview();
            goodstree.IsCatetoryOrGoods = 1;
            goodstree.ShowDialog();

            if (goodstree.Gg != null)
            {
                this.textBox1.Text = goodstree.Gg.GoodsClassCode;
                this.textBox3.Text = goodstree.Gg.GoodsName;
                this.textBox6.Text = goodstree.Gg.Specifications;
                this.textBox4.Text = goodstree.Gg.Unit;
                NewGoods = goodstree.Gg;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text != "")
            this.NewStock.Quantity = long.Parse(this.textBox2.Text);
            if (this.textBox7.Text != "")
            this.NewStock.Money = long.Parse(this.textBox7.Text);
            if (this.textBox9.Text != "")
            this.NewStock.StorehouseplaceCode = long.Parse(this.textBox9.Text);
            if (this.textBox10.Text != "")
            this.NewStock.GoodsCode = this.textBox10.Text;
            this.NewRemark = this.textBox5.Text;

            this.Close();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (test.TestNum(this.textBox2.Text))
            {
                this.textBox2.Text = "";
                this.textBox2.Focus();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (test.TestNum(this.textBox7.Text))
            {
                this.textBox7.Text = "";
                this.textBox7.Focus();
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (test.TestNum(this.textBox9.Text))
            {
                this.textBox9.Text = "";
                this.textBox9.Focus();
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (test.TestNum(this.textBox10.Text))
            {
                this.textBox10.Text = "";
                this.textBox10.Focus();
            }
        }
    }
}
