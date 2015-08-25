using System;
using System.Drawing;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonControl;
using CommonWindow;
using CustomManageWindow.Service;
using Iesi.Collections.Generic;
using CustomManageWindow;
namespace HeTongGuanLi
{
    public partial class GaiZhuangHeTong_add_Dialog1 : CommonControl.BaseForm
    {

        ISet<CarBaseInfo> carList = new HashedSet<CarBaseInfo>();
        CustomService ss = new CustomService();
        ModificationContract mc = new ModificationContract();
        CarBaseInfo c = new CarBaseInfo();
        ISet<CarBaseInfo> selectCarList = new HashedSet<CarBaseInfo>();
        bool ifcheck = false;
        private ModificationContract modificationContract;

        public ModificationContract ModificationContract
        {
            get { return modificationContract; }
            set { modificationContract = value; }
        }
        private TemplateManager templateManager;

        public TemplateManager TemplateManager
        {
            get { return templateManager; }
            set { templateManager = value; }
        }
        public GaiZhuangHeTong_add_Dialog1()
        {
            InitializeComponent();
        }

        private void GaiZhuangHeTong_add_Dialog1_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            this.textBox3.Enabled = false;
            this.textBox8.Enabled = false;
            DateTime now = DateTime.Now;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("请输入合同金额");
                return;
            }
            foreach (DataGridViewRow r in commonDataGridView2.Rows)
            {
                //if (r.Cells[0].Value.ToString() == "0")
                //{
                //    MessageBox.Show("请勾选车辆！");
                //}
                if (r.Cells[0].Value.ToString() == "1")
                {
                    c = (CarBaseInfo)r.Tag;
                    #region 判断气瓶型号是否为空
                    if (c.Cylinder == null)
                    {
                        DialogResult result = MessageBox.Show("请选择气瓶型号，数量", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            YanChe_add_Dialog ydd = new YanChe_add_Dialog();
                            ydd.CarBaseInfo = c;
                            ydd.IsShowOrInput = 1;
                            if (ydd.ShowDialog() == DialogResult.OK)
                            {
                                r.Cells[this.commonDataGridView2.ColumnCount-2].Value=c.Cylinder.CylinderType;
                                selectCarList.Add((CarBaseInfo)r.Tag);
                                return;
                            }
                            else
                            {
                                return;
                            }

                        }
                        else
                        {
                            return;
                        }
                    }
                    #endregion
                    else
                    {
                        selectCarList.Add((CarBaseInfo)r.Tag);
                    }
                    mc.CarBaseInfoID = selectCarList;
                    CarBaseInfo cbi = null;
                    foreach (CarBaseInfo s in mc.CarBaseInfoID)
                    {
                        cbi = s;
                        break;
                    }
                    this.textBox5.Text = cbi.VIN;
                    cbi.Cbi.Category = (int)CustomBaseInfo.kehuleibie.zhenshikehu;
                    ss.SaveOrUpdateEntity(cbi.Cbi);
                    DateTime now = DateTime.Now;
                    if (cbi.ModidiedType == (int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGDiesel || cbi.ModidiedType == (int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGGas)
                    {

                        textBox3.Text = "CAZHT" + now.Year + (now.Month.ToString().Length == 1 ? ("0" + now.Month) : now.Month.ToString()) + (now.Day.ToString().Length == 1 ? ("0" + now.Day) : now.Day.ToString()) + DateTime.Now.ToLongTimeString().Replace(":", "");
                    }
                    else if (cbi.ModidiedType == (int)ModificationContract.CNGGasCNGDieselLNGDiesel.LNGDiesel)
                    {
                        textBox3.Text = "LAZHT" + now.Year + (now.Month.ToString().Length == 1 ? ("0" + now.Month) : now.Month.ToString()) + (now.Day.ToString().Length == 1 ? ("0" + now.Day) : now.Day.ToString()) + DateTime.Now.ToLongTimeString().Replace(":", "");
                    }
                    mc.ContractNo = textBox3.Text;
                    mc.SignedDate = dateTimePicker1.Value.Ticks;
                    if (this.radioButton1.Checked)
                    {
                        mc.ContractMethod = (int)ModificationContract.Type.duinei;
                    }
                    else if (this.radioButton2.Checked)
                    {
                        mc.ContractMethod = (int)ModificationContract.Type.duiwai;
                    }
                    mc.PaymentMethod = this.comboBox3.Text;
                    mc.Remarks = textBox6.Text;
                    mc.UserID = this.UserInfo;
                    mc.Process = (int)ModificationContract.guocheng.xsfzr;
                    mc.ApprovalState = (int)ModificationContract.Approval.yet;
                    mc.Pass = (int)ModificationContract.PassorNot.pass;
                    mc.ApprovalTime = DateTime.Now.Ticks;
                    mc.DeliveryStatus = (int)ModificationContract.DeliveryStatusEnum.None;
                    mc.ContractContents = htmlEditor1.BodyInnerHTML;
                    mc.ContractAmount = float.Parse(textBox2.Text);
                    ss.SaveOrUpdateEntity(mc);
                    MessageBox.Show("提交给销售负责人审核");
                    this.DialogResult = DialogResult.OK;
                    ifcheck = true;
                    
                }

            }
            if (!ifcheck)
            MessageBox.Show("请选择车辆");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.commonDataGridView2.Rows.Clear();
            SelectPersonalCustomInfo xzgr = new SelectPersonalCustomInfo();
            if (xzgr.ShowDialog() == DialogResult.OK)
            {

                this.textBox1.Text = xzgr.CustomBaseInfo.Name;
                carList = xzgr.CustomBaseInfo.CarInfo;
                int i = 1;
                if (carList != null)
                {
                    foreach (CarBaseInfo s in carList)
                    {
                        if (s.ModificationID == null||(s.ModificationID!=null&&s.ModificationID.State==1))
                        {
                            commonDataGridView2.Rows.Add(0, i.ToString(), s.PlateNumber, s.VehicleType, ModificationContract.ModifyType[s.ModidiedType], s.Cylinder == null ? "" : s.Cylinder.CylinderType, "删除");
                            commonDataGridView2.Rows[commonDataGridView2.Rows.Count - 1].Tag = s;
                            this.textBox5.Text = s.VIN;
                            i++;
                        }
                        else
                        {
                            MessageBox.Show("该客户车牌号为"+s.PlateNumber+"车辆已有合同");
                        }
                    }
                }

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                this.label11.Text = "姓名：";
                this.label13.Text = "车辆识别码：";
                this.button3.Visible = false;
                this.button6.Visible = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                this.label11.Text = "公司名称：";
                this.label13.Text = "车辆识别码：";
                this.button3.Visible = true;
                this.button6.Visible = false;
            }

        }

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;

            if (grid.CurrentCell.Value.ToString() == "删除")
            {

                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    grid.Rows.Remove(grid.CurrentRow);
                }

            }

        
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.commonDataGridView2.Rows.Clear();
            SelectCompanyCustomInfo xzqy = new SelectCompanyCustomInfo();

            if (xzqy.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = xzqy.CustomBaseInfo.Name;
                carList = xzqy.CustomBaseInfo.CarInfo;
                int i = 1;
                if (carList != null)
                {
                    foreach (CarBaseInfo s in carList)
                    {
                        if (s.ModificationID == null)
                        {
                            commonDataGridView2.Rows.Add(0, i.ToString(), s.PlateNumber, s.VehicleType, ModificationContract.ModifyType[s.ModidiedType], s.Cylinder == null ? "" : s.Cylinder.CylinderType, "删除");
                            commonDataGridView2.Rows[commonDataGridView2.Rows.Count - 1].Tag = s;
                            this.textBox5.Text = s.VIN;
                            i++;
                        }
                        else
                        {
                            MessageBox.Show("该客户车牌号为" + s.PlateNumber + "车辆已有合同");
                        }
                    }
                }
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            //this.htmlEditor1. = "";
            this.htmlEditor1.Print();

        }

      
    }
}

