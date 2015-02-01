using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CheRuKu.SQL;
using System.Collections;
using EntityClassLibrary;
using System.Runtime.InteropServices;
using SQLProvider.Service;


namespace CheRuKu
{
    public partial class CheRuKuDan : CommonControl.BaseForm
    {
        IList Currentss;
        OP_ChuRuKu OP_ChuRuKu = new OP_ChuRuKu();
        CheRuKuInfo cheRuKuInfo;
        public CheRuKuInfo CheRuKuInfo
        {
            get { return cheRuKuInfo; }
            set { cheRuKuInfo = value; }
        }

        private UserInfo user;
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }



        public CheRuKuDan()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cheRuKuInfo.WorkingGroup.WorkingGroupName = this.textBox7.Text;
            //UserInfo u = new UserInfo();
            //u.Id = long.Parse(this.textBox1.Text);
            //cheRuKuInfo.WorkingGroup.WorkingGroupLeader = u;
            cheRuKuInfo.RefitWork.CarInfo.Cbi.Unit = this.textBox2.Text;
            cheRuKuInfo.WorkContent = this.textBox3.Text;
            cheRuKuInfo.Specification = this.textBox4.Text;
            cheRuKuInfo.RefitWork.ForemanTime = this.dateTimePicker1.Value.Ticks;
            cheRuKuInfo.ActualCompletionDate = this.dateTimePicker2.Value.Ticks;
            cheRuKuInfo.Remark = this.textBox5.Text;
            //cheRuKuInfo.Confirmor = this.textBox6.Text;
            //cheRuKuInfo.Confirmor = user.Name;

            cheRuKuInfo.Status = (int)EntityClassLibrary.CheRuKuInfo.savecheck.check;

            CarTheLibrary CarTheLibrary = new CarTheLibrary();
            RefitWork rf = new RefitWork();
            if (cheRuKuInfo.TiaoShiBaoGao != null)
            {
                rf = cheRuKuInfo.TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan;
            }
            CarTheLibrary.CheRuKuInfo = cheRuKuInfo;
            CarTheLibrary.RefitWork = rf;
            OP_ChuRuKu.SaveOrUpdateEntity(cheRuKuInfo);

            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;

            }

        }

        private void CheRuKuDan_Load(object sender, EventArgs e)
        {
            if (cheRuKuInfo != null)
            {
                if (cheRuKuInfo.Status == (int)EntityClassLibrary.CheRuKuInfo.savecheck.check)
                {
                    this.groupBox1.Enabled = false;
                    this.button1.Enabled = false;
                }
            }
            OP_ChuRuKu.GetAllRuKu();
            load();
            //this.textBox6.Text = user.Name;
            this.textBox1.Text = cheRuKuInfo.WorkingGroup.WorkingGroupLeader.Name;
            this.textBox2.Text = cheRuKuInfo.RefitWork.CarInfo.Cbi.Unit;
            this.textBox7.Text = cheRuKuInfo.WorkingGroup.WorkingGroupName;
            //this.dateTimePicker1.Value = (cheRuKuInfo.RefitWork.ForemanTime == 0) ? DateTime.Now : new DateTime(cheRuKuInfo.RefitWork.ForemanTime);

        }

        //private void comboBox1_DropDown(object sender, EventArgs e)
        //{
        //    if (this.comboBox1.Items.Count == 0)
        //    {
        //        IList group = OP_ChuRuKu.GetAllGroups();
        //        if (group != null)
        //        {
        //            this.comboBox1.DataSource = group;
        //            this.comboBox1.DisplayMember = "WorkingGroupName";
        //            this.comboBox1.ValueMember = "Itself";
        //        }
        //    }
        //}

        public void load()
        {
            this.textBox7.Text = cheRuKuInfo.WorkingGroup.WorkingGroupName;
            this.textBox1.Text = cheRuKuInfo.WorkingGroup.WorkingGroupLeader.ToString();
            this.textBox2.Text = cheRuKuInfo.RefitWork.CarInfo.Cbi.Unit;
            this.textBox3.Text = cheRuKuInfo.WorkContent;
            this.textBox4.Text = cheRuKuInfo.Specification;
            this.dateTimePicker1.Value = (cheRuKuInfo.RefitWork.ForemanTime == 0) ? DateTime.Now : new DateTime(cheRuKuInfo.RefitWork.ForemanTime);
            this.dateTimePicker2.Value = (cheRuKuInfo.RefitWork.ForemanTime == 0) ? DateTime.Now : new DateTime(cheRuKuInfo.ActualCompletionDate);
            this.textBox5.Text = cheRuKuInfo.Remark;
            //this.textBox6.Text = cheRuKuInfo.Confirmor;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CommonMethod.DocumentPrint print = new CommonMethod.DocumentPrint();
            print.DocPrint(panel1);

        }

    }
}

