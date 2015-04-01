using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using HeTongGuanLi.Service;
using EntityClassLibrary;
using CommonControl;

namespace HeTongGuanLi
{
    public partial class MuBanGuanLi : CommonControl.CommonTabPage
    {

        IList currenthetongs;

        ContractService hs = new ContractService();

        public MuBanGuanLi()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            MuBanGuanLi_add_Dialog1 mad = new MuBanGuanLi_add_Dialog1();
            mad.IsShowOrInput = 1;
            mad.UserInfo = this.User;
            if (mad.ShowDialog() == DialogResult.OK)
            {
                this.commonDataGridView.Rows.Clear();
                reFreshAllControl();
            }

        }

        private void MuBanGuanLi_Load(object sender, EventArgs e)
        {
            this.commonDataGridView.Rows.Clear();
            reFreshAllControl();
        }
        public override void reFreshAllControl()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.start_dateTimePicker.Value = DateTime.Now;
            this.end_dateTimePicker.Value = DateTime.Now;
            this.comboBox1.Text = "";
            this.commonDataGridView.Rows.Clear();
            currenthetongs = hs.GetAllMuBan();
            int i = 1;
            if (currenthetongs != null)
            {
                foreach (TemplateManager s in currenthetongs)
                {
                    this.commonDataGridView.Rows.Add(0, i.ToString(), s.TemplateName, TemplateManager.MuBanType[s.TemplateType],s.UserID==null?"": s.UserID.Name, new DateTime(s.Time).ToString(), "查看", "删除");
                    i++;
                }
               
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string aname = textBox1.Text;

            string bname = textBox2.Text;

            long dname = start_dateTimePicker.Value.Ticks;

            long ename = end_dateTimePicker.Value.AddDays(1).Ticks;

            this.commonDataGridView.Rows.Clear();

            if (comboBox1.Text == "套件类合同")
            {
                currenthetongs = hs.SelectTJMuBan(aname, bname, dname, ename);
            }
            else if (comboBox1.Text == "改装类合同")
            {
                currenthetongs = hs.SelectGZMuBan(aname, bname, dname, ename);
            }
            else
            {
                currenthetongs = hs.SelectMuBan(aname, bname, dname, ename);
            }
            ShowSelectContractGrid();


        }

        private void ShowSelectContractGrid()
        {
            int i = 1;
            if (currenthetongs != null)
            {
                foreach (TemplateManager s in currenthetongs)
                {

                    this.commonDataGridView.Rows.Add(0, i.ToString(), s.TemplateName, TemplateManager.MuBanType[s.TemplateType], s.UserID.Name, new DateTime(s.Time).ToString(), "查看", "删除");
                    i++;

                }
            }
        }

        private void commonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            CommonDataGridView grid = (CommonDataGridView)sender;

            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                MuBanGuanLi_add_Dialog1 mb = new MuBanGuanLi_add_Dialog1();

                mb.TemplateManager = (TemplateManager)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];

                mb.IsShowOrInput = 0;
                mb.UserInfo = this.User;

                if (mb.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView.Rows.Clear();

                    reFreshAllControl();


                }

            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                TemplateManager s = (TemplateManager)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];

                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    hs.Remove(s);
                    this.commonDataGridView.Rows.Clear();
                    reFreshAllControl();
                }

            }


        }

        private void commonDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MuBanGuanLi_add_Dialog1 mb = new MuBanGuanLi_add_Dialog1();

            mb.TemplateManager = (TemplateManager)currenthetongs[this.commonDataGridView.CurrentCell.RowIndex];

            mb.IsShowOrInput = 0;
            mb.UserInfo = this.User;

            if (mb.ShowDialog() == DialogResult.OK)
            {
                this.commonDataGridView.Rows.Clear();

                reFreshAllControl();


            }
        }
    }
}
