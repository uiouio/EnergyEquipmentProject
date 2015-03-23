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
    public partial class GaiZhuangContractView : CommonControl.BaseForm
    {

        private ModificationContract modificationContract;

        public ModificationContract ModificationContract
        {
            get { return modificationContract; }
            set { modificationContract = value; }
        }

        public GaiZhuangContractView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void GaiZhuangContractView_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.textBox1.Enabled = false;
            this.textBox5.Enabled = false;
            this.commonDataGridView2.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox10.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox9.Enabled = false;
            this.textBox8.Enabled = false;
            this.textBox2.Enabled = false;
            this.radioButton1.Enabled = false;
            this.radioButton2.Enabled = false;
            int i = 1;
            if (ModificationContract.CarBaseInfoID != null && ModificationContract.CarBaseInfoID.Count > 0)
            {
                CarBaseInfo cbi = null;
                foreach (CarBaseInfo c in ModificationContract.CarBaseInfoID)
                {
                    cbi = c;
                    break;
                }
                if (cbi.Cbi.Status == (int)CustomBaseInfo.PersonalOrCompany.Personal)
                {
                    this.label12.Text = "姓名：";
                    this.label13.Text = "身份证号：";
                    this.textBox1.Enabled = false;
                    this.textBox1.Text = cbi.Cbi.Name;
                    this.textBox5.Enabled = false;
                    this.textBox5.Text = cbi.Cbi.IdentifyCardNo;
                    
                    foreach(CarBaseInfo s in ModificationContract.CarBaseInfoID)
                    {
                        this.commonDataGridView2.Rows.Add(0,i.ToString(),s.PlateNumber,s.ModidiedType,s.CylinderType);
                        i++;
                    }
                    

                }
                else if (cbi.Cbi.Status == (int)CustomBaseInfo.PersonalOrCompany.Company)
                {
                    this.label12.Text = "企业名称：";
                    this.label13.Text = "组织机构代码：";
                    this.textBox1.Enabled = false;
                    this.textBox5.Enabled = false;
                    this.textBox1.Text = cbi.Cbi.Name;
                    this.textBox5.Text = cbi.Cbi.IdentifyCardNo;
                    this.commonDataGridView2.Rows.Add();
                    foreach (CarBaseInfo s in ModificationContract.CarBaseInfoID)
                    {
                        this.commonDataGridView2.Rows.Add(0, i.ToString(), s.PlateNumber, s.ModidiedType, s.CylinderType);
                        i++;
                    }
                }
                this.textBox7.Text =CarBaseInfo.ModifyType[cbi.ModidiedType];
                this.textBox10.Text = new DateTime(ModificationContract.SignedDate).ToLongDateString();
                this.textBox3.Text = ModificationContract.ContractNo;
                this.textBox9.Text = ModificationContract.PaymentMethod;
                if(ModificationContract.ContractMethod==(int)ModificationContract.Type.duinei)
                {
                    this.radioButton1.Checked = true;
                }
                else if (ModificationContract.ContractMethod == (int)ModificationContract.Type.duiwai)
                {
                    this.radioButton2.Checked = true;
                }
                this.textBox2.Text = ModificationContract.ContractAmount.ToString();
                this.textBox8.Text = ModificationContract.UserID.Name;
                this.textBox6.Text = ModificationContract.Remarks;
                this.htmlEditor1.BodyInnerHTML = ModificationContract.ContractContents;


            }
        }

    }
}
