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
    public partial class PersonalCustomInfoManage : CommonControl.CommonTabPage
    {

        CustomService ss = new CustomService();
        IList currentcustoms;
        public PersonalCustomInfoManage()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            PersonalCustomInfo_add_Dialog pad = new PersonalCustomInfo_add_Dialog();
            pad.UserInfo = this.User;
            pad.ShowDialog();
            if (pad.IfSaved==1)
            {
                this.commonDataGridView1.Rows.Clear();
                reFreshAllControl();
            }
        }

        private void PersonalCustomInfoManage_Load(object sender, EventArgs e)
        {
                this.commonDataGridView1.Rows.Clear();
                reFreshAllControl();
               
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                PersonalCustomInfo_add_Dialog2 newGhs = new PersonalCustomInfo_add_Dialog2();
                newGhs.Currentcustom = (CustomBaseInfo)currentcustoms[this.commonDataGridView1.CurrentCell.RowIndex];
                    
               if(newGhs.ShowDialog()==DialogResult.OK)
                {
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }

            }
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZhuanHuaTongJi zhtj = new ZhuanHuaTongJi();
            zhtj.ShowDialog();
        }
        public void ShowSelectCustomGrid()
        {
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CustomBaseInfo s in currentcustoms )
                {
                    this.commonDataGridView1.Rows.Add(i.ToString(), s.Name,s.Sex,s.IdentifyCardNo, s.Telephone,s.Address,s.CustomLevel,CustomBaseInfo.CategoryArry[s.Category],"查看","删除");
                    i++;
                    
                }
            }
        }
        public  override void reFreshAllControl()
        {
            this.textBox1.Text="";
            this.textBox2.Text="";
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.commonDataGridView1.Rows.Clear();
            currentcustoms = ss.GetAllPersonal();
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CustomBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView1.Rows.Add(i.ToString(), s.Name, s.Sex, s.IdentifyCardNo, s.Telephone, s.Address,s.CustomLevel,CustomBaseInfo.CategoryArry[s.Category], "查看", "删除");
                    i++;
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            string cname = textBox2.Text;

            this.commonDataGridView1.Rows.Clear();
            if(this.radioButton1.Checked==true)
            {
                currentcustoms = ss.SelectIntendCustom(name,cname);
            }
            else if (this.radioButton2.Checked == true)
            {
                currentcustoms = ss.SelectFormalCustom(name, cname);
            }
            else
            {
                currentcustoms = ss.SelectByNameAndCname(name, cname);
            }
            ShowSelectCustomGrid();
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = ss.CloneDataGridView(this.commonDataGridView1);
            div.Columns.Remove(div.Columns[8]);
            PrintDataGridView.PrintTheDataGridView(div);
           
            
        }

        private void commonPictureButton3_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = ss.CloneDataGridView(this.commonDataGridView1);
            div.Columns.Remove(div.Columns[8]);
            DoExport.DoTheExport(div);
    
        }

        private void PersonalCustomInfoManage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                button1_Click(sender,e);
            }
        }

    }
}
