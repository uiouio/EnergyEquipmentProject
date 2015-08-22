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
using KuGuanXiTong.Service;
using CommonMethod;
using SQLProvider.Service;
namespace KuGuanXiTong
{
     
    public partial class ChuKu_addPaiGong_Dialog : CommonControl.BaseForm
    {
        OpStock opstock = new OpStock();
        Service.ChuKuService chuKuService = new Service.ChuKuService();
        BaseService bs = new BaseService();
        IList<StockOperationDetail> stockList = null;
        private Object[] objectRefitWork;
        public Object[] ObjectRefitWork
        {
            get { return objectRefitWork; }
            set { objectRefitWork = value; }
        }

        private string ChukuNumString;
        public string ChukuNumString1
        {
            get { return ChukuNumString; }
            set { ChukuNumString = value; }
        }
        public ChuKu_addPaiGong_Dialog()
        {
            InitializeComponent();
        }

        private void PaiGongDan_add_Dialog_Load(object sender, EventArgs e)
        {

            ChukuNumString = "CK" + DateTime.Now.Year + 
                DateTime.Now.Month + DateTime.Now.Day + 
                DateTime.Now.Hour + DateTime.Now.Minute + 
                DateTime.Now.Second;

            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            if (Screen.PrimaryScreen.WorkingArea.Width < 800)
                this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6); 
            RefitWork refitWork = (RefitWork)objectRefitWork[0];
            StockOperation stockOperation = (StockOperation)objectRefitWork[1];
            label_name.Text = refitWork.DispatchOrder;
            label_WorkGroup.Text = refitWork.WorkingGroupId.WorkingGroupName;
            label_UserName.Text = refitWork.WorkingGroupId.WorkingGroupLeader.Name;
            this.label_PlateNumber.Text = refitWork.CarInfo.PlateNumber;
            this.label_ModifyType.Text =CarBaseInfo.ModifyType[refitWork.CarInfo.ModidiedType];
            this.label_PersonName.Text = refitWork.CarInfo.Cbi.Name;
            addItemToDataGridViewEntity(refitWork.RefitWorkGoodss);
            if (stockOperation != null)
            {
                IList ilist = opstock.GetOpdetail(stockOperation.Id);
                
                //foreach (StockOperationDetail sp in ilist)
                //{
                //    stockOperation.OperationDetails.Add(sp);
                    
                //}

                //initChuKuInfo(stockOperation.OperationDetails);
                initChuKuInfo(ilist);
            }
        }

        private void addItemToDataGridViewEntity(Iesi.Collections.Generic.ISet<RefitWorkGoods> goodsList)
        {
            string s1 = "select g.GoodsClassCode,g.GoodsName from GoodsBaseInfo g  where g.GoodsParentClassId=1  order by g.GoodsClassCode";
            IList goods = bs.ExecuteSQL(s1);
            if (goodsList != null && goodsList.Count > 0)
            {
                int i = 0;
                foreach (RefitWorkGoods r in goodsList)
                {
                    i++;
                    RefitWork refitWork = (RefitWork)objectRefitWork[0];
                    foreach (Object[] g in goods)
                    {
                      
                        if (r.GoodsBaseInfoId.GoodsClassCode.Substring(0, 2) == g[0].ToString())
                        {
                            commonDataGridView.Rows.Add(i.ToString(),
                                                         r.GoodsBaseInfoId.GoodsClassCode.Substring(0, 2) + g[1],
                                                         r.GoodsBaseInfoId.GoodsClassCode,
                                                         r.GoodsBaseInfoId.GoodsName,
                                                         r.GoodsBaseInfoId.Specifications,
                                                         r.GoodsBaseInfoId.Unit,
                                                         r.GoodsBaseInfoId.Material,
                                                         r.Count,
                                                         r.Count,
                                                         r.Remark,
                                                         RefitWorkGoods.ReceiveTypeArray[r.ReceiveType],
                                                         BaseEntity.YesOrNoArray[r.AddType],
                                                         "出库",
                                                         r.GoodsBaseInfoId.SingleMoney);
                            object[] o = { r, null };
                            commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = o;
                        }
                       
                    }
                }
            }
        }

        private void initChuKuInfo(IList operationList)
        {
            if (commonDataGridView.Rows != null && commonDataGridView.Rows.Count > 0)
            {
                foreach (StockOperationDetail s in operationList)
                {
                    if (operationList != null && operationList.Count > 0)
                    {
                        foreach (DataGridViewRow r in commonDataGridView.Rows)
                        {
                            object[] o = (object[])r.Tag;
                            RefitWorkGoods rwg = (RefitWorkGoods)o[0];
                            double sum = 0;
                            if (rwg.GoodsBaseInfoId.Id.ToString().Equals(Convert.ToInt32(s.GoodsCode.Substring(0, 8)).ToString()))
                            {
                                //list.Add(s.Quantity);
                                //for (int i = 0; i < list.Count; i++)
                                //{
                                //    sum += Convert.ToDouble(list[i].ToString());
                                //}
                                r.Cells[8].Value =Convert.ToDouble(r.Cells[8].Value)- Convert.ToDouble(s.Quantity);
                               // r.Cells[8].Value = rwg.Count - sum;
                                
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
                
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow r = commonDataGridView.Rows[e.RowIndex];
                    object[] rwg = (object[])r.Tag;
                    if (e.ColumnIndex == 12)
                    {
                        ChuKu_addDetailPaiGong_Dialog cadd = new ChuKu_addDetailPaiGong_Dialog();
                        cadd.DifferenceCount = Convert.ToInt32(r.Cells[8].Value);
                        cadd.ChuKuDetail = rwg;
                        cadd.StockOp = (StockOperation)objectRefitWork[1];
                        cadd.UserInfo = this.UserInfo;
                        cadd.ChukuNumString = ChukuNumString;
                        cadd.ShowDialog();
                        if(cadd.Save==1)
                        {
                            this.button2.Enabled = true;
                            r.Cells[8].Value = cadd.DifferenceCount;
                            r.Tag = cadd.ChuKuDetail;
                            objectRefitWork[1] = cadd.StockOp;
                            r.Cells[10].Value = RefitWorkGoods.ReceiveTypeArray[(int)RefitWorkGoods.ReceiveTypeEnum.Receive];
                            r.DefaultCellStyle.ForeColor = Color.Red;
                            this.ChukuNumString1 = cadd.ChukuNumString;
                        }
                      
                    }
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
                            if (Convert.ToInt32(r.Cells[8].Value) <= 0)
                            {
                                continue;
                            }
                            object[] o = (object[])r.Tag;
                            RefitWorkGoods rwg = (RefitWorkGoods)o[0];
                            if (o[1] == null)
                            {
                                o[1] = new List<StockOperationDetail>();
                            }
                            IList<StockOperationDetail> sodList = (IList<StockOperationDetail>)o[1];
                            //判断条码是否属于此派工单
                            if (rwg.GoodsBaseInfoId.Id.ToString().Equals(Convert.ToInt32(textBox1.Text.Trim().Substring(0, 8)).ToString()))
                            {
                                #region 出库操作
                                Stock stock = chuKuService.getStockByGoodsCode(textBox1.Text.Trim());
                                if (stock != null && stock.Quantity >= 1)
                                {
                                    stock.Quantity -= 1;
                                    chuKuService.SaveOrUpdateEntity(stock);
                                    StockOperation so = objectRefitWork[1] as StockOperation;
                                    if (objectRefitWork[1] == null)
                                    {
                                        RefitWork refitWork = (RefitWork)objectRefitWork[0];
                                        so = new StockOperation();
                                        so.OperationTime = DateTime.Now.Ticks;
                                        so.OperationTpye = (int)StockOperation.OpTypeFlag.OutByRefitWork;
                                        so.RetrospectListNumber = refitWork.DispatchOrder;
                                        so.UserId = this.UserInfo;
                                        so.IOFlag = (int)StockOperation.InOrOutFlag.Out;
                                        chuKuService.SaveOrUpdateEntity(so);
                                        objectRefitWork[1] = so;
                                    }
                                    rwg.ReceiveType = (int)RefitWorkGoods.ReceiveTypeEnum.Receive;
                                    chuKuService.SaveOrUpdateEntity(rwg);
                                    StockOperationDetail sod = new StockOperationDetail();
                                    sod.GoodsCode = textBox1.Text.Trim();
                                    sod.Quantity = 1;
                                    sod.StockOperationId = (StockOperation)objectRefitWork[1];
                                    sod.StockId = stock;
                                    sod.TheMoney = stock.GoodsBaseInfoID.SingleMoney;
                                    
                                    
                                    sod =  chuKuService.SaveOrUpdateEntity(sod) as StockOperationDetail;
                                    so.OperationDetails.Add(sod);
                                    //chuKuService.SaveOrUpdateEntity(so);
                                    objectRefitWork[1] = so;

                                    sodList.Add(sod);


                                    r.Cells[8].Value = Convert.ToInt32(r.Cells[8].Value) - 1;
                                    r.Cells[10].Value = RefitWorkGoods.ReceiveTypeArray[(int)RefitWorkGoods.ReceiveTypeEnum.Receive];
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
           // PrintDataGridView.PrintTheDataGridView(this.commonDataGridView);
            //object[,] ob=new object[this.commonDataGridView.Rows.Count,this.commonDataGridView.Columns.Count];
            KuGuanXiTong.Report.Form1 f1 = new KuGuanXiTong.Report.Form1();
            List<string> lsName=new List<string>();
            List<string> goodcode = new List<string>();
            List<string> goodname = new List<string>();
            List<string> goodspecifition = new List<string>();           
            for(int i=0;i<this.commonDataGridView.Rows.Count;i++)
           {
              string name=this.commonDataGridView.Rows[i].Cells[1].Value.ToString();
              string gcode = this.commonDataGridView.Rows[i].Cells[2].Value.ToString();
              string gname = this.commonDataGridView.Rows[i].Cells[3].Value.ToString();
              string gspecifition = this.commonDataGridView.Rows[i].Cells[4].Value.ToString();
              goodcode.Add(gcode);
              goodname.Add(gname);
              goodspecifition.Add(gspecifition);
              if(lsName.Contains(name))
              {
                 continue;
               }
              else
              {
                lsName.Add(name);
              }
              f1.List = lsName;
              f1.Listcode = goodcode;
              f1.Listname = goodname;
              f1.Listspecifition = goodspecifition;
            }
            f1.ObjectRefitWork = this.ObjectRefitWork;
            f1.UserInfo = this.UserInfo;
            f1.IsNeworOld = 0;
            f1.ChukuNum = this.ChukuNumString1;
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridView dr = new DataGridView();
            dr = OperateDateGridView.CloneDataGridView(this.commonDataGridView);
            this.commonDataGridView.Rows.Clear();
            object[] value = new object[dr.Columns.Count];

            
            foreach(DataGridViewRow r in dr.Rows)
            {
                 if (r.DefaultCellStyle.ForeColor == Color.Red)                
                {

                    //object[] objchuku = (object[])r.Tag;

                    for (int j = 0; j < dr.Columns.Count; j++)
                    {
                        value[j] = r.Cells[j].Value;
                    }
                    //dr.Columns[12].DefaultCellStyle.ForeColor = Color.Black;
                    DataGridViewTextBoxCell dgvb = new DataGridViewTextBoxCell();
                    r.Cells[12] = dgvb;
                    value[12] = "已出库";
                    this.commonDataGridView.Rows.Add(value);
                    this.button2.Enabled = false;
                }


            }
         
           this.button1.Enabled = true;
        }
    }
}
