using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonWindow;
using System.Collections;
using CommonMethod;

namespace KuGuanXiTong
{
    public partial class ChuKu_addTaoJian_Dialog : CommonControl.BaseForm
    {
        Service.ChuKuService chuKuService = new Service.ChuKuService();
        private Object[] objectRefitWork;
        public Object[] ObjectRefitWork
        {
            get { return objectRefitWork; }
            set { objectRefitWork = value; }
        }
        public ChuKu_addTaoJian_Dialog()
        {
            InitializeComponent();
        }

        private void PaiGongDan_add_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            SuiteContract refitWork = (SuiteContract)objectRefitWork[0];
            StockOperation stockOperation = (StockOperation)objectRefitWork[1];
            label_name.Text = refitWork.ContractNo;

            IList suitGoodsList = chuKuService.GetDeliveryRecordBySuitContractId(refitWork.Id);
            addItemToDataGridViewEntity(suitGoodsList);
            
            if (stockOperation != null)
            {
                initChuKuInfo(stockOperation.OperationDetails);
            }
        }

        private void addItemToDataGridViewEntity(IList goodsList)
        {
            if (goodsList != null && goodsList.Count > 0)
            {
                int i = 0;
                foreach (DeliverySuiteRecords r in goodsList)
                {

                    if (commonDataGridView.Rows != null && commonDataGridView.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in commonDataGridView.Rows)
                        {
                            object[] obj = (object[])row.Tag;
                            DeliverySuiteRecords rwg = (DeliverySuiteRecords)obj[0];
                            if (rwg.GoodsInfoId.Id==r.GoodsInfoId.Id)
                            {
                                row.Cells[5].Value = rwg.Deliverycount + Convert.ToInt32(row.Cells[5].Value);
                                row.Cells[6].Value = rwg.Deliverycount + Convert.ToInt32(row.Cells[6].Value);
                                return;
                            }
                        }
                    }
                    i++;
                    commonDataGridView.Rows.Add(i.ToString(), r.GoodsInfoId.GoodsName, r.GoodsInfoId.Specifications, r.GoodsInfoId.Unit, r.GoodsInfoId.Material, r.Deliverycount, r.Deliverycount, "出库", r.GoodsInfoId.SingleMoney);
                    object[] o = { r, null };
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = o;
                }
            }
        }

        private void initChuKuInfo(IList<StockOperationDetail> operationList)
        {
            if (operationList != null && operationList.Count > 0)
            {
                foreach (StockOperationDetail s in operationList)
                {
                    if (commonDataGridView.Rows != null && commonDataGridView.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow r in commonDataGridView.Rows)
                        {
                            object[] o = (object[])r.Tag;
                            DeliverySuiteRecords rwg = (DeliverySuiteRecords)o[0];
                            if (rwg.GoodsInfoId.Id.ToString().Equals(Convert.ToInt32(s.GoodsCode.Substring(0, 8)).ToString()))
                            {
                                r.Cells[6].Value = Convert.ToInt32(r.Cells[6].Value) - Convert.ToDouble(s.Quantity);
                                IList<StockOperationDetail> stockList = null;
                                if (o[1] == null)
                                {
                                    stockList = new List<StockOperationDetail>();
                                    o[1] = stockList;
                                }
                                else
                                {
                                    stockList = (IList<StockOperationDetail>)o[1];
                                }
                                stockList.Add(s);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void commonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow r = commonDataGridView.Rows[e.RowIndex];
            object[] rwg = (object[])r.Tag;
            if (e.ColumnIndex == 7)
            {
                ChuKu_addDetailTaoJian_Dialog cadd = new ChuKu_addDetailTaoJian_Dialog();
                cadd.DifferenceCount = Convert.ToInt32(r.Cells[6].Value);
                cadd.ChuKuDetail = rwg;
                cadd.StockOp = (StockOperation)objectRefitWork[1];
                cadd.UserInfo = this.UserInfo;
                cadd.ShowDialog();
                r.Cells[6].Value = cadd.DifferenceCount;
                r.Tag = cadd.ChuKuDetail;
                objectRefitWork[1] = cadd.StockOp;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text.Trim().Length == 23)
                {
                    if (commonDataGridView.Rows != null && commonDataGridView.Rows.Count > 0)
                    {
                        //遍历此派工单所有材料
                        foreach (DataGridViewRow r in commonDataGridView.Rows)
                        {
                            if (Convert.ToInt32(r.Cells[6].Value) <= 0)
                            {
                                continue;
                            }
                            object[] o = (object[])r.Tag;
                            DeliverySuiteRecords rwg = (DeliverySuiteRecords)o[0];
                            if (o[1] == null)
                            {
                                o[1] = new List<StockOperationDetail>();
                            }
                            IList<StockOperationDetail> sodList = (IList<StockOperationDetail>)o[1];
                            //判断条码是否属于此派工单
                            if (rwg.GoodsInfoId.Id.ToString().Equals(Convert.ToInt32(textBox1.Text.Trim().Substring(0, 8)).ToString()))
                            {
                                #region 出库操作
                                Stock stock = chuKuService.getStockByGoodsCode(textBox1.Text.Trim());
                                if (stock != null && stock.Quantity >= 1)
                                {
                                    stock.Quantity -= 1;
                                    chuKuService.SaveOrUpdateEntity(stock);
                                    if (objectRefitWork[1] == null)
                                    {
                                        SuiteContract refitWork = (SuiteContract)objectRefitWork[0];
                                        StockOperation so = new StockOperation();
                                        so.OperationTime = DateTime.Now.Ticks;
                                        so.OperationTpye = (int)StockOperation.OpTypeFlag.OutByTaojian;
                                        so.RetrospectListNumber = refitWork.ContractNo;
                                        so.UserId = this.UserInfo;
                                        so.IOFlag = (int)StockOperation.InOrOutFlag.Out;
                                        chuKuService.SaveOrUpdateEntity(so);
                                        objectRefitWork[1] = so;
                                    }
                                    StockOperationDetail sod = new StockOperationDetail();
                                    sod.GoodsCode = textBox1.Text.Trim();
                                    sod.Quantity = 1;
                                    sod.StockOperationId = (StockOperation)objectRefitWork[1];
                                    sod.StockId = stock;
                                    sod.TheMoney = stock.GoodsBaseInfoID.SingleMoney;
                                    chuKuService.SaveOrUpdateEntity(sod);

                                    sodList.Add(sod);

                                    r.Cells[6].Value = Convert.ToInt32(r.Cells[6].Value) - 1;
                                    textBox1.Text = "";
                                    textBox1.Focus();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("库存数量不够出库数量！");
                                    textBox1.Text = "";
                                    textBox1.Focus();
                                    return;
                                }
                                #endregion
                            }
                        }
                    }
                    MessageBox.Show("此派工单没有此条货物出库记录,或已出够数量！");
                }
                else
                {
                    MessageBox.Show("输入条码格式不正确！");
                }
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDataGridView.PrintTheDataGridView(this.commonDataGridView);
        }
    }
}
