using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using HeTongGuanLi.Service;

namespace HeTongGuanLi
{
    public partial class SuiteContractJudgeZKJ : CommonControl.BaseForm
    {
        ContractService ss = new ContractService();
        private SuiteContract suiteContract;

        public SuiteContract SuiteContract
        {
            get { return suiteContract; }
            set { suiteContract = value; }
        }
        public SuiteContractJudgeZKJ()
        {
            InitializeComponent();
        }

        private void SuiteContractJudgeZKJ_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox11.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox15.Enabled = false;
            this.textBox18.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox10.Enabled = false;
            this.textBox6.Enabled = false;
            this.panel1.Enabled = false;
            this.textBox5.Text = SuiteContract.ContractNo;

            this.textBox11.Text = SuiteContract.ContractAmount.ToString();
            this.textBox7.Text = new DateTime(SuiteContract.SignedDate).ToLongDateString();
            this.textBox6.Text = SuiteContract.PaymentMethod;
            this.textBox4.Text = SuiteContract.Remarks;
            this.textBox10.Text = SuiteContract.SalesResponsiblePersonOpinion;
            if (SuiteContract.CustomBaseID != null)
            {

                this.textBox1.Text = SuiteContract.CustomBaseID.Name;
                this.textBox2.Text = SuiteContract.CustomBaseID.ContactName;
                this.textBox3.Text = SuiteContract.CustomBaseID.Phone;
                

            }


            if (SuiteContract.ContractMode == (int)SuiteContract.Type.duinei)
            {
                this.radioButton1.Checked = true;

            }
            else if (SuiteContract.ContractMode == (int)SuiteContract.Type.duiwai)
            {
                this.radioButton2.Checked = true;
            }
            this.textBox15.Text = SuiteContract.UserID.Name;
            this.textBox18.Text = SuiteContract.UserID.Phone;


            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuiteContract.DeliveryStatus = (int)ModificationContract.DeliveryStatusEnum.None;

            SuiteContract.ChiefAccountantOpinion = this.textBox15.Text;
            SuiteContract.Pass = (int)ModificationContract.PassorNot.pass;
            SuiteContract.Process = (int)ModificationContract.guocheng.zjl;

            ss.SaveOrUpdateEntity(SuiteContract);
            MessageBox.Show("合同通过 提交给总经理");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SuiteContract.ChiefAccountantOpinion = this.textBox15.Text;
            SuiteContract.Pass = (int)SuiteContract.PassorNot.unpass;
            SuiteContract.ApprovalState = (int)SuiteContract.Approval.already;
            ss.SaveOrUpdateEntity(SuiteContract);
            MessageBox.Show("合同评审完成 未通过");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
