using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
namespace HeTongGuanLi
{
    public partial class SuiteContractView : CommonControl.BaseForm
    {
        private SuiteContract suiteContract;

        public SuiteContract SuiteContract
        {
            get { return suiteContract; }
            set { suiteContract = value; }
        }

        public SuiteContractView()
        {
            InitializeComponent();
        }

        private void SuiteContractView_Load(object sender, EventArgs e)
        {
                this.textBox1.Enabled = false;
                this.textBox10.Enabled = false;
                this.textBox5.Enabled = false;
                this.textBox3.Enabled = false;
                this.textBox8.Enabled = false;
                this.textBox9.Enabled = false;
                this.textBox2.Enabled = false;
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;
                if (SuiteContract.CustomBaseID.Status == (int)CustomBaseInfo.PersonalOrCompany.Personal)
                {
                    this.label12.Text = "姓名：";
                    this.label13.Text = "身份证号：";
                    this.textBox1.Enabled = false;
                    this.textBox1.Text = SuiteContract.CustomBaseID.Name;
                    this.textBox5.Enabled = false;
                    this.textBox5.Text = SuiteContract.CustomBaseID.IdentifyCardNo;

                }
                else if (SuiteContract.CustomBaseID.Status == (int)CustomBaseInfo.PersonalOrCompany.Company)
                {
                    this.label12.Text = "企业名称：";
                    this.label13.Text = "组织机构代码：";
                    this.textBox1.Enabled = false;
                    this.textBox5.Enabled = false;
                    this.textBox1.Text = SuiteContract.CustomBaseID.Name;
                    this.textBox5.Text = SuiteContract.CustomBaseID.Name;
                    
                }

                this.textBox10.Text = new DateTime(SuiteContract.SignedDate).ToLongDateString();
                this.textBox3.Text = SuiteContract.ContractNo;

                this.textBox9.Text = SuiteContract.PaymentMethod;
               
                if (SuiteContract.ContractMode == (int)SuiteContract.Type.duinei)
                {
                    this.radioButton1.Checked = true;
                }
                else if (SuiteContract.ContractMode == (int)SuiteContract.Type.duiwai)
                {
                    this.radioButton2.Checked = true;
                }
                this.textBox2.Text = SuiteContract.ContractAmount.ToString();
                this.textBox8.Text = SuiteContract.UserID.Name;
                this.textBox6.Text = SuiteContract.Remarks;
                this.htmlEditor1.BodyInnerHTML = SuiteContract.ContractContents;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
    
}
