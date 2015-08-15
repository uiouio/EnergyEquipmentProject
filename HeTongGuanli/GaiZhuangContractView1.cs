using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CustomManageWindow.Service;
namespace HeTongGuanLi
{
    public partial class GaiZhuangContractView1 : CommonControl.BaseForm
    {
        private ModificationContract modificationContract;

        public ModificationContract ModificationContract
        {
            get { return modificationContract; }
            set { modificationContract = value; }
        }
        public GaiZhuangContractView1()
        {
            InitializeComponent();
        }

        private void GaiZhuangContractView1_Load(object sender, EventArgs e)
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
            this.textBox10.Text = new DateTime(ModificationContract.SignedDate).ToLongDateString();
            this.textBox3.Text = ModificationContract.ContractNo;
            this.textBox9.Text = ModificationContract.PaymentMethod;
            this.textBox2.Text = ModificationContract.ContractAmount.ToString();
            this.textBox8.Text = ModificationContract.UserID.Name;
            this.textBox6.Text = ModificationContract.Remarks +Environment.NewLine+ "审批意见:" + ModificationContract.SalesResponsiblePersonOpinion;
            //this.htmlEditor1.BodyInnerText = ModificationContract.ContractContents;
            this.htmlEditor1.BodyInnerHTML = ModificationContract.ContractContents;
            if (ModificationContract.ContractMethod == (int)ModificationContract.Type.duinei)
            {
                this.radioButton1.Checked = true;
            }
            else if (ModificationContract.ContractMethod == (int)ModificationContract.Type.duiwai)
            {
                this.radioButton2.Checked = true;
            }
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

                    foreach (CarBaseInfo s in ModificationContract.CarBaseInfoID)
                    {
                        this.commonDataGridView2.Rows.Add(0, i.ToString(), s.PlateNumber, CarBaseInfo.ModifyType[s.ModidiedType], s.Cylinder == null ? "" : s.Cylinder.CylinderType);
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
                        this.commonDataGridView2.Rows.Add(0, i.ToString(), s.PlateNumber, CarBaseInfo.ModifyType[s.ModidiedType], s.Cylinder == null ? "" : s.Cylinder.CylinderType);
                        i++;
                    }
                }
                this.textBox7.Text = CarBaseInfo.ModifyType[cbi.ModidiedType];
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomService ss = new CustomService();
            ModificationContract.ContractAmount =float.Parse( textBox2.Text);
            ModificationContract.Remarks = this.textBox6.Text;
            ModificationContract.ContractContents = this.htmlEditor1.BodyInnerHTML;
            ModificationContract.Process = (int)ModificationContract.guocheng.xsfzr;
            ModificationContract.ApprovalState = (int)ModificationContract.Approval.yet;

            ModificationContract.Pass = (int)ModificationContract.PassorNot.pass;
            ModificationContract.ApprovalTime = DateTime.Now.Ticks;
            ModificationContract.DeliveryStatus = (int)ModificationContract.DeliveryStatusEnum.None;
            ss.SaveOrUpdateEntity(ModificationContract);
            MessageBox.Show("提交给销售负责人审核");
            this.DialogResult = DialogResult.OK;
        }
    }
}
