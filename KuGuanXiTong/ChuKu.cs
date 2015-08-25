using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using CommonMethod;

namespace KuGuanXiTong
{
    public partial class ChuKu : CommonControl.CommonTabPage
    {
        Service.ChuKuService chuKuService = new Service.ChuKuService();
        public ChuKu()
        {
            InitializeComponent();
        }
        public override void reFreshAllControl()
        {
            comboBox_FormType.SelectedIndex = 0;
            button1_Click_1(button1, new EventArgs());
        }
        private void ChuKu_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = commonDataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex == 7&&this.commonDataGridView1.Rows.Count>0)
            {
                if (r.Cells[2].Value.ToString().Equals("改装派工单"))
                {
                    ChuKu_addPaiGong_Dialog cad = new ChuKu_addPaiGong_Dialog();
                    cad.ObjectRefitWork = (object[])r.Tag;
                    cad.UserInfo = this.User;
                    cad.ShowDialog();
                    r.Tag = cad.ObjectRefitWork;
                    StockOperation s = (StockOperation)cad.ObjectRefitWork[1];
                    if (s != null)
                    {
                        r.Cells[4].Value = s.UserId.Name;
                        r.Cells[5].Value = new DateTime(s.OperationTime).ToShortDateString();
                        r.Cells[6].Value = "已出库";
                    }
                }
                else if (r.Cells[2].Value.ToString().Equals("维修派工单"))
                {
                    ChuKu_addWeiXiu_Dialog cad = new ChuKu_addWeiXiu_Dialog();
                    cad.ObjectRefitWork = (object[])r.Tag;
                    cad.UserInfo = this.User;
                    cad.ShowDialog();
                    r.Tag = cad.ObjectRefitWork;
                    StockOperation s = (StockOperation)cad.ObjectRefitWork[1];
                    if (s != null)
                    {
                        r.Cells[4].Value = s.UserId.Name;
                        r.Cells[5].Value = new DateTime(s.OperationTime).ToShortDateString();
                        r.Cells[6].Value = "已出库";
                    }
                }
                else if (r.Cells[2].Value.ToString().Equals("套件发货单"))/////////////////////////////////////////////////////////////////////
                {
                    ChuKu_addTaoJian_Dialog cad = new ChuKu_addTaoJian_Dialog();
                    cad.ObjectRefitWork = (object[])r.Tag;
                    cad.UserInfo = this.User;
                    cad.ShowDialog();
                    r.Tag = cad.ObjectRefitWork;
                    StockOperation s = (StockOperation)cad.ObjectRefitWork[1];
                    if (s != null)
                    {
                        r.Cells[4].Value = s.UserId.Name;
                        r.Cells[5].Value = new DateTime(s.OperationTime).ToShortDateString();
                        r.Cells[6].Value = "已出库";
                    }
                }
            }
        }

        /// <summary>
        /// 派工GridView初始化
        /// </summary>
        /// <param name="allRefitWork">{派工表,操作记录主表}</param>
        private void initDataGridViewRefit(Object[] allRefitWork)
        {
            commonDataGridView1.Rows.Clear();
            IList refitLsit = (IList)allRefitWork[0];
            IList refitAndStockList = (IList)allRefitWork[1];
            int i = 0;
            if (refitLsit != null && refitLsit.Count > 0)
            {
                foreach (RefitWork r in refitLsit)
                {
                    i++;
                    commonDataGridView1.Rows.Add(false, i.ToString(), comboBox_FormType.Text, r.DispatchOrder, "", "", "未出库", "出库");
                    object[] o = { r, null  };
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = o;
                }
            }
            if (refitAndStockList != null && refitAndStockList.Count > 0)
            {
                foreach (Object[] o in refitAndStockList)
                {
                    i++;
                    RefitWork r = (RefitWork)o[0];
                    StockOperation s = (StockOperation)o[1];
                    commonDataGridView1.Rows.Add(false,i.ToString(), comboBox_FormType.Text, r.DispatchOrder, s.UserId.Name, new DateTime(s.OperationTime).ToShortDateString(), "已出库", "出库");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = o;
                }
            }
        }

        /// <summary>
        /// 维修GridView初始化
        /// </summary>
        /// <param name="allRefitWork">{维修表,操作记录主表}</param>
        private void initDataGridViewService(Object[] allRefitWork)
        {
            commonDataGridView1.Rows.Clear();
            IList refitLsit = (IList)allRefitWork[0];
            IList refitAndStockList = (IList)allRefitWork[1];
            int i = 0;
            if (refitLsit != null && refitLsit.Count > 0)
            {
                foreach (WeiXiuFanKuiDan r in refitLsit)
                {
                    i++;
                    commonDataGridView1.Rows.Add(false, i.ToString(), comboBox_FormType.Text, r.RepairNumber, "", "", "未出库", "出库");
                    object[] o = { r, null };
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = o;
                }
            }
            if (refitAndStockList != null && refitAndStockList.Count > 0)
            {
                foreach (Object[] o in refitAndStockList)
                {
                    i++;
                    WeiXiuFanKuiDan r = (WeiXiuFanKuiDan)o[0];
                    StockOperation s = (StockOperation)o[1];
                    commonDataGridView1.Rows.Add(false, i.ToString(), comboBox_FormType.Text, r.RepairNumber, s.UserId.Name, new DateTime(s.OperationTime).ToShortDateString(), "已出库", "出库");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = o;
                }
            }
        }

        /// <summary>
        /// 套件GridView初始化
        /// </summary>
        /// <param name="allRefitWork">{套件合同,操作记录主表}</param>
        private void initDataGridViewSuit(Object[] allRefitWork)
        {
            commonDataGridView1.Rows.Clear();
            IList refitLsit = (IList)allRefitWork[0];
            IList refitAndStockList = (IList)allRefitWork[1];
            int i = 0;
            if (refitLsit != null && refitLsit.Count > 0)
            {
                foreach (SuiteContract r in refitLsit)
                {
                    i++;
                    commonDataGridView1.Rows.Add(false, i.ToString(), comboBox_FormType.Text, r.ContractNo, "", "", "未出库", "出库");
                    object[] o = { r, null };
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = o;
                }
            }
            if (refitAndStockList != null && refitAndStockList.Count > 0)
            {
                foreach (Object[] o in refitAndStockList)
                {
                    i++;
                    SuiteContract r = (SuiteContract)o[0];
                    StockOperation s = (StockOperation)o[1];
                    commonDataGridView1.Rows.Add(false, i.ToString(), comboBox_FormType.Text, r.ContractNo, s.UserId.Name, new DateTime(s.OperationTime).ToShortDateString(), "已出库", "出库");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = o;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.button1.Cursor = Cursors.WaitCursor;
            if (comboBox_FormType.SelectedIndex == 0)
            {
                Object[] formList = chuKuService.getRefitWorkByStateAndRefitNum(textBox1.Text.Trim());
                initDataGridViewRefit(formList);
            }
            else if (comboBox_FormType.SelectedIndex == 1)
            {
                Object[] formList = chuKuService.getServicesByStateAndServiceNum(textBox1.Text.Trim());
                initDataGridViewService(formList);
            }
            else if (comboBox_FormType.SelectedIndex == 2)
            {
                Object[] formList = chuKuService.getSuitByStateAndSuitNum(textBox1.Text.Trim());
                initDataGridViewSuit(formList);
            }
            this.button1.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DoExport.DoTheExport(this.commonDataGridView1);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton4_Click(object sender, EventArgs e)
        {
            PrintDataGridView.PrintTheDataGridView(this.commonDataGridView1);
        }

        private void commonDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = commonDataGridView1.Rows[e.RowIndex];
            if (this.commonDataGridView1.Rows.Count > 0)
            {
                if (r.Cells[2].Value.ToString().Equals("改装派工单"))
                {
                    ChuKu_addPaiGong_Dialog cad = new ChuKu_addPaiGong_Dialog();
                    cad.ObjectRefitWork = (object[])r.Tag;
                    cad.UserInfo = this.User;
                    cad.ShowDialog();
                    r.Tag = cad.ObjectRefitWork;
                    StockOperation s = (StockOperation)cad.ObjectRefitWork[1];
                    if (s != null)
                    {
                        r.Cells[4].Value = s.UserId.Name;
                        r.Cells[5].Value = new DateTime(s.OperationTime).ToShortDateString();
                        r.Cells[6].Value = "已出库";
                    }
                }
                else if (r.Cells[2].Value.ToString().Equals("维修派工单"))
                {
                    ChuKu_addWeiXiu_Dialog cad = new ChuKu_addWeiXiu_Dialog();
                    cad.ObjectRefitWork = (object[])r.Tag;
                    cad.UserInfo = this.User;
                    cad.ShowDialog();
                    r.Tag = cad.ObjectRefitWork;
                    StockOperation s = (StockOperation)cad.ObjectRefitWork[1];
                    if (s != null)
                    {
                        r.Cells[4].Value = s.UserId.Name;
                        r.Cells[5].Value = new DateTime(s.OperationTime).ToShortDateString();
                        r.Cells[6].Value = "已出库";
                    }
                }
                else if (r.Cells[2].Value.ToString().Equals("套件发货单"))/////////////////////////////////////////////////////////////////////
                {
                    ChuKu_addTaoJian_Dialog cad = new ChuKu_addTaoJian_Dialog();
                    cad.ObjectRefitWork = (object[])r.Tag;
                    cad.UserInfo = this.User;
                    cad.ShowDialog();
                    r.Tag = cad.ObjectRefitWork;
                    StockOperation s = (StockOperation)cad.ObjectRefitWork[1];
                    if (s != null)
                    {
                        r.Cells[4].Value = s.UserId.Name;
                        r.Cells[5].Value = new DateTime(s.OperationTime).ToShortDateString();
                        r.Cells[6].Value = "已出库";
                    }
                }
            }
        }

    }
}
