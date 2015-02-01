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
    public partial class HeTongPingShen_add_Dialog1 : Form
    {

        ContractService ss = new ContractService();
        private ModificationContract modificationContract;

        public ModificationContract ModificationContract
        {
            get { return modificationContract; }
            set { modificationContract = value; }
        }
        public HeTongPingShen_add_Dialog1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ModificationContract.DeliveryStatus=(int)ModificationContract.DeliveryStatusEnum.None;

            ModificationContract.ChiefAccountantOpinion = this.textBox9.Text;
            ModificationContract.Pass = (int)ModificationContract.PassorNot.pass;
            ModificationContract.Process = (int)ModificationContract.guocheng.zjl;
            ModificationContract.ApprovalState = (int)ModificationContract.Approval.already;
            ss.SaveOrUpdateEntity(ModificationContract);
            MessageBox.Show("合同通过 提交给总经理");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void HeTongPingShen_add_Dialog1_Load(object sender, EventArgs e)
        {
            this.textBox8.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox11.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox15.Enabled = false;
            this.textBox18.Enabled = false;
            this.textBox1.Enabled = false;
            this.textBox10.Enabled = false;
            this.textBox12.Enabled = false;
            this.panel1.Enabled = false;
            if(ModificationContract.CarBaseInfoID !=null&&ModificationContract.CarBaseInfoID.Count>0)
            {
                CarBaseInfo cbi = null;
                foreach (CarBaseInfo c in ModificationContract.CarBaseInfoID)
                {
                    cbi = c;
                    break;
                }
                this.textBox8.Text = cbi.Cbi.Name;
                this.textBox2.Text = cbi.Cbi.ContactName;
                this.textBox3.Text = cbi.Cbi.Phone;
                this.textBox4.Text = cbi.CylinderNo;
                this.textBox5.Text = ModificationContract.ContractNo;
                this.textBox6.Text = cbi.CylinderType;
                this.textBox11.Text =ModificationContract.ContractAmount.ToString();
                this.textBox7.Text =new DateTime(ModificationContract.SignedDate).ToLongDateString();
                this.textBox12.Text = ModificationContract.PaymentMethod;
            }
           
           
            if(ModificationContract.ContractMethod==(int)ModificationContract.Type.duinei)
            {
                this.radioButton1.Checked = true;

            }
            else if (ModificationContract.ContractMethod == (int)ModificationContract.Type.duiwai)
            {
                this.radioButton2.Checked = true;
            }
            this.textBox15.Text = ModificationContract.UserID.Name;
            this.textBox18.Text = ModificationContract.UserID.Phone;
            this.textBox10.Text = ModificationContract.SalesResponsiblePersonOpinion;
            this.textBox1.Text = ModificationContract.Remarks;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificationContract.Pass = (int)ModificationContract.PassorNot.unpass;
            ModificationContract.ApprovalState = (int)ModificationContract.Approval.already;
            ModificationContract.ChiefAccountantOpinion = this.textBox9.Text;
          
            ss.SaveOrUpdateEntity(ModificationContract);
            MessageBox.Show("合同评审完成 未通过");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }
}
