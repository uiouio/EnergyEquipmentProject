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
using CommonMethod;
namespace CustomManageWindow
{
    public partial class CompanyCustomInfoManage : CommonControl.CommonTabPage
    {
        CustomService ss = new CustomService();
        IList currentcustoms;
        public CustomBaseInfo currentcustom;

        public CustomBaseInfo Currentcustom
        {
            get { return currentcustom; }
            set { currentcustom = value; }
        }
        public CompanyCustomInfoManage()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            CompanyCustomInfo_add_Dialog cad = new CompanyCustomInfo_add_Dialog();
            cad.UserInfo = this.User;
            cad.ShowDialog();
            if (cad.IfSaved == 1)
            {
                this.commonDataGridView2.Rows.Clear();
                reFreshAllControl();
            }
        }

        private void CompanyCustomInfoManage_Load(object sender, EventArgs e)
        {
            this.commonDataGridView2.Rows.Clear();
            reFreshAllControl();
        }
        public override void reFreshAllControl()
        {
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox11.Text = "";
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.commonDataGridView2.Rows.Clear();
            currentcustoms = ss.GetAllCompany();
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CustomBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView2.Rows.Add(i.ToString(), s.Name, s.ContactName, s.Phone, s.IdentifyCardNo, s.Address, s.ComanyProperty, s.CustomLevel, CustomBaseInfo.CategoryArry[s.Category], "查看", "删除");
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
                CompanyCustomInfo_add_Dialog2 newGhs = new CompanyCustomInfo_add_Dialog2();

                newGhs.Currentcustom = (CustomBaseInfo)this.commonDataGridView2.Rows[this.commonDataGridView2.CurrentRow.Index].Tag;


                if (newGhs.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView2.Rows.Clear();
                    reFreshAllControl();
                }



            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                CustomBaseInfo s = (CustomBaseInfo)currentcustoms[this.commonDataGridView2.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ss.RemoveCustom(s);
                    this.commonDataGridView2.Rows.Clear();
                    reFreshAllControl();
                }


            }

        }
        public void ShowSelectCustomGrid()
        {
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CustomBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView2.Rows.Add(i.ToString(), s.Name, s.ContactName, s.Phone, s.IdentifyCardNo, s.Address, s.ComanyProperty, s.CustomLevel, CustomBaseInfo.CategoryArry[s.Category], "查看", "删除");
                    i++;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ZhuanHuaTongJi zhtj = new ZhuanHuaTongJi();
            zhtj.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = textBox8.Text;

            string cname = textBox9.Text;

            string bname = textBox11.Text;

            this.commonDataGridView2.Rows.Clear();
            if (this.radioButton1.Checked == true)
            {
                currentcustoms = ss.SelectIntendCompany(name, cname, bname);
            }
            else if (this.radioButton2.Checked == true)
            {
                currentcustoms = ss.SelectFormalCompany(name, cname, bname);
            }
            else
            {
                currentcustoms = ss.SelectCompany(name, cname, bname);
            }
            ShowSelectCustomGrid();
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView2); 
            div.Columns.Remove(div.Columns[9]);
            div.Columns.Remove(div.Columns[9]);
            PrintDataGridView.PrintTheDataGridView(div);
        }

        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView2); 
            div.Columns.Remove(div.Columns[9]);
            div.Columns.Remove(div.Columns[9]);
            DoExport.DoTheExport(div);
        }

        private void commonDataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CompanyCustomInfo_add_Dialog2 newGhs = new CompanyCustomInfo_add_Dialog2();

            newGhs.Currentcustom = (CustomBaseInfo)this.commonDataGridView2.Rows[this.commonDataGridView2.CurrentRow.Index].Tag;


            if (newGhs.ShowDialog() == DialogResult.OK)
            {
                this.commonDataGridView2.Rows.Clear();
                reFreshAllControl();
            }
        }
    }
}
