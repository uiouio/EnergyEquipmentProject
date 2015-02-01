using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControl;
using CaiGouXiTong.Service;
using System.Collections;
using EntityClassLibrary;

namespace CaiGouXiTong
{
    public partial class GongHuoShangGuanLi : CommonControl.CommonTabPage
    {
        OpSupplierInfo OpSupplierInfo = new OpSupplierInfo();
        IList currentsuppliers;
        public GongHuoShangGuanLi()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            ShowAllSuppliersinGrid();
        }

        private void GongHuoShangGuanLi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void add_Click(object sender, EventArgs e)
        {
            GongHuoShang_New_dialog newGhs = new GongHuoShang_New_dialog();
            newGhs.ShowDialog();
            if (newGhs.IfSaved == 1)
            {
                this.commonDataGridView1.Rows.Clear();
                ShowAllSuppliersinGrid();
            }
        }

       

        public void ShowAllSuppliersinGrid()
        {
            currentsuppliers = OpSupplierInfo.GetAllSupplier();
            int i = 1;
            if (currentsuppliers != null)
            {
                foreach (SupplierInfo s in currentsuppliers)
                {
                    this.commonDataGridView1.Rows.Add(i.ToString(), s.SupplierName, s.SupplierAddress, s.SupplierContactMan, s.SupplierPhone, "查看");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

        public void ShowSelectSuppliersinGrid()
        {
            int i = 1;


            if (currentsuppliers != null)
            {
                foreach (SupplierInfo s in currentsuppliers)
                {
                    this.commonDataGridView1.Rows.Add(
                        i.ToString(),
                        s.SupplierName,
                        s.SupplierAddress,
                        s.SupplierContactMan,
                        s.SupplierPhone,
                        "查看"
                        );
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
           
        }

        private void gongHuoShangButton_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text != "" && this.textBox1.Text != "")
            {
                string name = this.textBox1.Text;
                string cname = this.textBox2.Text;
                this.commonDataGridView1.Rows.Clear();
                currentsuppliers = OpSupplierInfo.FuzzySelectByNameAndCname(name,cname);
                ShowSelectSuppliersinGrid();
            }
            else if (this.textBox2.Text == "" && this.textBox1.Text != "")
            {
                string str = this.textBox1.Text;
                this.commonDataGridView1.Rows.Clear();
                currentsuppliers = OpSupplierInfo.FuzzySelectByName(str);
                ShowSelectSuppliersinGrid();
            }
            else if (this.textBox2.Text != "" && this.textBox1.Text == "")
            {
                string str = this.textBox2.Text;
                this.commonDataGridView1.Rows.Clear();
                currentsuppliers = OpSupplierInfo.FuzzySelectBycName(str);
                ShowSelectSuppliersinGrid();
            }
            else if (this.textBox2.Text == "" && this.textBox1.Text == "")
            { 
            
            
            }
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (e.ColumnIndex == 5&&grid.CurrentCell.Value.ToString() == "查看")
            {
                GongHuoShang_Detail_dialog newGhs = new GongHuoShang_Detail_dialog();
                newGhs.Currentsupp = (SupplierInfo)this.commonDataGridView1.CurrentRow.Tag;
                //newGhs.Currentsupp = (SupplierInfo)currentsuppliers[this.commonDataGridView1.CurrentCell.RowIndex];
                newGhs.User = this.User;
                newGhs.ShowDialog();
                if (newGhs.i == 1)
                {
                    this.commonDataGridView1.Rows.Clear();
                    ShowAllSuppliersinGrid();
                }
            }
           
        }
    }
}
