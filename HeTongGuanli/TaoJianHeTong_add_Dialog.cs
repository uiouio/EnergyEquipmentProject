using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow;
using CommonControl;
using CommonWindow;
using CustomManageWindow.Service;
using Iesi.Collections.Generic;
using Iesi.Collections;
namespace HeTongGuanLi
{
    public partial class TaoJianHeTong_add_Dialog : CommonControl.BaseForm
    {
        IList goods;
        CustomManageWindow.Service.CustomService ss = new CustomManageWindow.Service.CustomService();
        SuiteContract mc = new SuiteContract();
        private ISet currentGoods = new HashedSet<SuiteContractGoods>();
        private TemplateManager templateManager;
        public TemplateManager TemplateManager
        {
            get { return templateManager; }
            set { templateManager = value; }
        }
        public TaoJianHeTong_add_Dialog()
        {
            InitializeComponent();
        }

        private void TaoJianHeTong_add_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.textBox3.Enabled = false;
            this.textBox8.Enabled = false;
            this.textBox8.Text = this.UserInfo.Name;
            if (TemplateManager == null)
            {
                this.htmlEditor1.BodyInnerHTML = "";
            }
            else
            {
                this.htmlEditor1.BodyInnerHTML = TemplateManager.Contents;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                this.label11.Text = "姓    名：";
                this.label13.Text = "身份证号：";
                this.button3.Visible = false;
                this.button6.Visible = true;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                this.label11.Text = "公司名称：";
                this.label13.Text = "组织代码：";
                this.button3.Visible = true;
                this.button6.Visible = false;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SelectPersonalCustomInfo xzgr = new SelectPersonalCustomInfo();
            if (xzgr.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = xzgr.CustomBaseInfo.Name;
                this.textBox5.Text = xzgr.CustomBaseInfo.IdentifyCardNo;
                mc.CustomBaseID = xzgr.CustomBaseInfo;

            }
        } 
        private void button3_Click(object sender, EventArgs e)
        {
            SelectCompanyCustomInfo xzqy = new SelectCompanyCustomInfo();
            if (xzqy.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = xzqy.CustomBaseInfo.Name;
                this.textBox5.Text = xzqy.CustomBaseInfo.IdentifyCardNo;
                mc.CustomBaseID = xzqy.CustomBaseInfo;
            }
        }

      

        private void button8_Click(object sender, EventArgs e)
        {
            SelectGoods sg = new SelectGoods();
            if(sg.ShowDialog()==DialogResult.OK)
            {
                goods = sg.ReturnIlist;
                int i = 1;
                if (goods != null && goods.Count > 0)
                {
                    foreach (Object[] g in goods)
                    {
                        SuiteContractGoods scg = new SuiteContractGoods();
                        scg.Count = float.Parse(g[9].ToString());
                        GoodsBaseInfo gbi = new GoodsBaseInfo();
                        gbi.Id = Convert.ToInt64(g[7]);
                        scg.GoodsBaseInfoId = gbi;
                        currentGoods.Add(scg);
                        commonDataGridView2.Rows.Add(i.ToString(),g[1],g[9],g[3],g[4]);
                        i++;
                    }
                }
             
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mc.ContractNo = textBox3.Text;
            mc.SignedDate = dateTimePicker1.Value.Ticks;
            DateTime now = DateTime.Now;
            if (this.radioButton6.Checked)
            {
                mc.ContractMode = (int)ModificationContract.Type.duinei;
                textBox3.Text = "WLYHT" + now.Year + (now.Month.ToString().Length == 1 ? ("0" + now.Month) : now.Month.ToString()) + (now.Day.ToString().Length == 1 ? ("0" + now.Day) : now.Day.ToString()) + DateTime.Now.ToLongTimeString().Replace(":", "");
            }
            else if (this.radioButton5.Checked)
            {
                mc.ContractMode = (int)ModificationContract.Type.duiwai;
                textBox3.Text = "JMHT" + now.Year + (now.Month.ToString().Length == 1 ? ("0" + now.Month) : now.Month.ToString()) + (now.Day.ToString().Length == 1 ? ("0" + now.Day) : now.Day.ToString()) + DateTime.Now.ToLongTimeString().Replace(":", "");
            }
            mc.ContractNo = this.textBox3.Text;
            mc.PaymentMethod = this.textBox4.Text;
            mc.SuiteContractGoods = (Iesi.Collections.Generic.ISet<SuiteContractGoods>)currentGoods;
            foreach(SuiteContractGoods rwg in currentGoods)
            {
                rwg.SuiteContractId = null;
                ss.SaveOrUpdateEntity(rwg);
            }
            if (this.textBox6.Text == "")
            {
                MessageBox.Show("请输入合同金额");
            }
            else
            {
                mc.ContractAmount = float.Parse(textBox6.Text);
            }
            mc.Remarks = textBox1.Text;
            mc.UserID = this.UserInfo;
            mc.ContractContents = htmlEditor1.BodyInnerHTML;
            mc.CustomBaseID.Category=(int)CustomBaseInfo.kehuleibie.zhenshikehu;
            ss.SaveOrUpdateEntity(mc.CustomBaseID);
            mc.Process = (int)SuiteContract.guocheng.xsfzr;
            mc.ApprovalState = (int)SuiteContract.Approval.yet;

            mc.Pass = (int)SuiteContract.PassorNot.pass;
           
            mc.DeliveryStatus = (int)SuiteContract.DeliveryStatusEnum.None;
           
            ss.SaveOrUpdateEntity(mc);
            MessageBox.Show("提交给销售负责人审批");
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MuBanInfo_Input mid = new MuBanInfo_Input();
            if (mid.ShowDialog() == DialogResult.OK)
            {
                TemplateManager tt = new TemplateManager();
                tt.UserID = this.UserInfo;
                tt.TemplateType = (int)TemplateManager.type.gz;
                tt.Remark = mid.ModelRemark;
                tt.TemplateName = mid.ModelName;
                tt.Contents = this.htmlEditor1.BodyInnerHTML;
                tt.Time = DateTime.Now.Ticks;
                ss.SaveOrUpdateEntity(tt);

            }
        }
 
    }
}