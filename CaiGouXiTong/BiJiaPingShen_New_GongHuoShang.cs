using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CaiGouXiTong.Service;
using CommonMethod;

namespace CaiGouXiTong
{
    public partial class BiJiaPingShen_New_GongHuoShang : Form
    {
        
        OpSupplierInfo oppsupps = new OpSupplierInfo();

        TestInput test = new TestInput();
        Supplier_Goods sendSupps;
        public Supplier_Goods SendSupps
        {
            get { return sendSupps; }
            set { sendSupps = value; }
        } 

        public BiJiaPingShen_New_GongHuoShang()
        {
            SendSupps = new Supplier_Goods();
            InitializeComponent();
        }

        private void BiJiaPingShen_New_GongHuoShang_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (this.comboBox1.Items.Count == 0)
            {
                IList suppliers = this.oppsupps.GetAllSupplier();
                this.comboBox1.DataSource = suppliers;
                this.comboBox1.DisplayMember = "SupplierName";
                this.comboBox1.ValueMember = "Itself";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" && !test.TestNum(this.textBox1.Text))
            {
                MessageBox.Show("请填写单价！");
            }
            else
            {

                if (this.comboBox1.SelectedValue != null)
                {
                    SendSupps.SupplierInfoId = this.comboBox1.SelectedValue as SupplierInfo;
                    SendSupps.Unit_Price = float.Parse(this.textBox1.Text);
                    this.DialogResult =  DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("请选择供货商");
                }
            }
        }
    }
}
