using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CaiGouXiTong;
using CaiGouXiTong.Service;
using EntityClassLibrary;
using KuGuanXiTong.Service;
using CommonMethod;


namespace KuGuanXiTong
{
    public partial class RuKu_New_dialog : CommonControl.BaseForm
    {




        UserInfo userid;
        /// <summary>
        /// 获取当前正在操作的人的userid
        /// </summary>
        public UserInfo Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        /// <summary>
        /// 验证填写是否和要求的方法
        /// </summary>
        TestInput test = new TestInput();
        /// <summary>
        /// 操作供货商的类
        /// </summary>
        OpSupplierInfo opsuplier = new OpSupplierInfo();
        public RuKu_New_dialog()
        {
            InitializeComponent();

            NewGoods = new GoodsBaseInfo();
            sk = new Stock();
        }
        /// <summary>
        /// 新添加的库存的类
        /// </summary>
        Stock sk;

        /// <summary>
        ///操作库存的类
        /// </summary>
        OpStock opstck = new OpStock();

        GoodsBaseInfo newGoods = new GoodsBaseInfo();
        /// <summary>
        /// 获取新添加的物品
        /// </summary>
        public GoodsBaseInfo NewGoods
        {
            get { return newGoods; }
            set { newGoods = value; }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    RuKu_TianJiaHuoWu tianJiaHuoWu = new RuKu_TianJiaHuoWu();
        //    tianJiaHuoWu.ShowDialog();
        //    if (tianJiaHuoWu.NewGoods != null)
        //    {
        //        this.commonDataGridView1.Rows.Add(tianJiaHuoWu.NewGoods.GoodsClassCode,
        //            tianJiaHuoWu.NewGoods.GoodsName, tianJiaHuoWu.NewStock.GoodsCode,
        //            tianJiaHuoWu.NewGoods.Specifications, tianJiaHuoWu.NewGoods.Material,tianJiaHuoWu.NewGoods.Unit,
        //            tianJiaHuoWu.NewStock.Quantity, tianJiaHuoWu.NewStock.Money,
        //            tianJiaHuoWu.NewStock.StorehouseplaceCode, tianJiaHuoWu.NewRemark, "删除","打印条码");
        //    }

        //}


        private void RuKu_New_dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            if (Screen.PrimaryScreen.WorkingArea.Width < 800)
                this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6); 
            if (this.comboBox1.Items.Count == 0)
            {
                this.comboBox1.SelectedIndex = -1;
                IList suppliers = this.opsuplier.GetAllSupplier();
                this.comboBox1.DataSource = suppliers;
                this.comboBox1.DisplayMember = "SupplierName";
                this.comboBox1.ValueMember = "Itself";
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 下拉时加载供货商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_DropDown(object sender, EventArgs e)
        {

            

        }


        /// <summary>
        /// 删除条目打印条码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && this.commonDataGridView1.Rows.Count > 0)
            {
                if (this.commonDataGridView1.CurrentCell.Value.ToString() == "删除")
                    this.commonDataGridView1.Rows.Remove(this.commonDataGridView1.CurrentRow);

            }
            if (e.ColumnIndex == 11 && this.commonDataGridView1.Rows.Count > 0)
            {
                if (this.commonDataGridView1.CurrentCell.Value.ToString() == "打印条码")
                    CommonMethod.PrintCode.print(this.commonDataGridView1.CurrentRow.Cells[2].Value.ToString(), this.commonDataGridView1.CurrentRow.Cells[1].Value.ToString());
            }
        }


        /// <summary>
        /// 确认入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.commonDataGridView1.Rows.Count > 0) //货物单中必须有货物
            {
                #region
                if (MessageBox.Show("确定之后不能更改，确定这样做吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK) //友情提示框
                {
                    
                    this.textBox1.Text =
                        "CR" + 
                        DateTime.Now.Year.ToString() +
                        DateTime.Now.Month.ToString() +
                        DateTime.Now.Day.ToString() +
                        DateTime.Now.Hour.ToString() + 
                        DateTime.Now.Minute.ToString();

                    //StockOperation表中数据变化
                    StockOperation stockop = new StockOperation();
                    stockop.OperationTpye = (long)StockOperation.OpTypeFlag.InByStream;
                    stockop.IOFlag = (long)StockOperation.InOrOutFlag.In;
                    stockop.OperationTime = this.dateTimePicker1.Value.Ticks;
                    stockop.RetrospectListNumber = this.textBox1.Text;
                    stockop.UserId = Userid;
                    stockop.IsCanChange = 0; //不可以修改
                    if (this.checkBox1.Checked == true)
                    {
                        stockop.IsCanChange = 1; //可以修改
                    }

                    SupplierInfo spp = this.comboBox1.SelectedValue as SupplierInfo;
                    if (spp != null)
                        stockop.SupplierInfoId = spp;
                    else stockop.SupplierInfoId = null;
                    stockop.Remark = this.textBox7.Text;

                    StockOperation opeaid = this.opstck.SaveStockOperation(stockop);

                    //Stock表中数据变化
                    int count = this.commonDataGridView1.Rows.Count;

                    #region
                    for (int i = 0; i < count; i++)
                    {
                        StockOperationDetail sod = new StockOperationDetail();
                        #region  Stock类型的数据
                        if (typeof(Stock) == this.commonDataGridView1.Rows[i].Tag.GetType())
                        {
                            Stock ss = (Stock)commonDataGridView1.Rows[i].Tag;
                            ss.Quantity = ss.Quantity + float.Parse(this.commonDataGridView1.Rows[i].Cells[6].Value.ToString());
                            ss.GoodsCode = this.commonDataGridView1.Rows[i].Cells[2].Value.ToString();
                            ss.Money = (ss.Money + float.Parse(this.commonDataGridView1.Rows[i].Cells[7].Value.ToString())) / 2;
                            sod.StockId = ss;
                            opstck.SaveOrUpdateEntity(ss);

                            GoodsBaseInfo goods = ss.GoodsBaseInfoID;
                            goods.SingleMoney = (goods.SingleMoney + float.Parse(this.commonDataGridView1.Rows[i].Cells[7].Value.ToString())) / 2;

                            opstck.SaveOrUpdateEntity(goods);

                            //填写Supplier_Goods表
                            if (this.comboBox1.SelectedValue != null)
                            {
                                Supplier_Goods newsg = new Supplier_Goods();
                                newsg.GoodsBaseInfoID = ss.GoodsBaseInfoID;
                                newsg.SupplierInfoId = this.comboBox1.SelectedValue as SupplierInfo;
                                newsg.Date = DateTime.Now.Ticks;
                                newsg.Unit_Price = float.Parse(this.commonDataGridView1.Rows[i].Cells[7].Value.ToString());
                                opsuplier.SaveOrUpdateEntity(newsg);
                            }

                        }
                        #endregion

                        #region

                        else if (typeof(GoodsBaseInfo) == this.commonDataGridView1.Rows[i].Tag.GetType())
                        {

                            GoodsBaseInfo goods = (GoodsBaseInfo)this.commonDataGridView1.Rows[i].Tag;
                            goods.SingleMoney = (goods.SingleMoney + float.Parse(this.commonDataGridView1.Rows[i].Cells[7].Value.ToString())) / 2;
                            opstck.SaveOrUpdateEntity(goods);

                            Stock ss = new Stock();
                            ss.GoodsBaseInfoID = goods;
                            ss.Money = float.Parse(this.commonDataGridView1.Rows[i].Cells[7].Value.ToString());
                            ss.GoodsCode = this.commonDataGridView1.Rows[i].Cells[2].Value.ToString();
                            ss.Quantity = float.Parse(this.commonDataGridView1.Rows[i].Cells[6].Value.ToString());
                            ss.StorehouseplaceCode = long.Parse(this.commonDataGridView1.Rows[i].Cells[10].Value.ToString() == "" ? "0" : this.commonDataGridView1.Rows[i].Cells[9].Value.ToString());
                            sod.StockId = opstck.SaveOrUpdateEntity(ss) as Stock;




                            //填写Supplier_Goods表
                            if (this.comboBox1.SelectedValue != null)
                            {
                                Supplier_Goods newsg = new Supplier_Goods();
                                newsg.GoodsBaseInfoID = (GoodsBaseInfo)this.commonDataGridView1.Rows[i].Tag;
                                newsg.SupplierInfoId = this.comboBox1.SelectedValue as SupplierInfo;
                                newsg.Date = DateTime.Now.Ticks;
                                newsg.Unit_Price = float.Parse(this.commonDataGridView1.Rows[i].Cells[7].Value.ToString());
                                opsuplier.SaveOrUpdateEntity(newsg);
                            }
                        }
                        #endregion

                        //StockOperationDetail表中数据变化
                        sod.StockOperationId = opeaid;
                        sod.Quantity = float.Parse(this.commonDataGridView1.Rows[i].Cells[6].Value.ToString());
                        sod.GoodsCode = this.commonDataGridView1.Rows[i].Cells[2].Value.ToString();
                        sod.TheMoney = float.Parse(this.commonDataGridView1.Rows[i].Cells[7].Value.ToString());
                        sod.Tax = float.Parse(this.commonDataGridView1.Rows[i].Cells[8].Value.ToString());
                        opstck.SaveOrUpdateEntity(sod);


                    }
                    #endregion

                    MessageBox.Show("添加成功 单据号为："+ this.textBox1.Text);

                    this.button3.Enabled = false;

                    this.DialogResult = DialogResult.OK;
                }
                #endregion
            }
            else
            {
                MessageBox.Show("请填写货物！");
            }

        }

        /// <summary>
        ///扫码入库 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            
            InputLanguageCollection MyInputs = InputLanguage.InstalledInputLanguages;

            foreach(InputLanguage myinout in MyInputs)
            {
                if(myinout.LayoutName == "中文(简体) - 美式键盘")
                {
                    InputLanguage.CurrentInputLanguage = myinout;
                }
            }

            this.textBox10.ReadOnly = false;
            //首先设定只有条码text是可用的，其他选项都由条码读出来，数量默认唯一
            SetTextAndButtonUnavailiable();

            //聚焦条码输入框
            this.textBox10.Focus();
            
            //}
            
        }

        public void SetTextAndButtonUnavailiable()
        {
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox5.Enabled = false;
           
            this.textBox4.Enabled = false;
            this.textBox11.Enabled = false;
            this.textBox8.Enabled = false;
            this.textBox9.Enabled = false;
            this.button4.Enabled = false;
            this.button6.Enabled = false;
        }

        /// <summary>
        /// 循环扫码机制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //扫描#则结束入库
                if (this.textBox10.Text != "#")
                {
                    //截取条码前8位
                    string code = this.textBox10.Text.Substring(0, 8);

                    if (test.TestNum(code))
                    {
                        long goodsid = long.Parse(code);

                        //查出数据

                        sk = opstck.GetStockByGoodsInfoId(goodsid);

                        //在列表中添加一条数据

                        if (sk != null)
                        {
                            if (sk.GoodsBaseInfoID.IsUniqueCode != 1)
                            {
                                this.commonDataGridView1.Rows.Add(sk.GoodsBaseInfoID.GoodsClassCode, sk.GoodsBaseInfoID.GoodsName,
                                this.textBox10.Text, sk.GoodsBaseInfoID.Specifications, sk.GoodsBaseInfoID.Material,
                                sk.GoodsBaseInfoID.Unit, "1", this.textBox8.Text, this.textBox13.Text, sk.StorehouseplaceCode, "删除", "打印条码");
                                this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = sk;
                                CommonMethod.PrintCode.print(this.textBox10.Text, sk.GoodsBaseInfoID.GoodsName);
                            }
                            else
                            {
                                //string str = GetMaxCodeFromGridForNniGoods(sk.GoodsCode);
                                //this.commonDataGridView1.Rows.Add(sk.GoodsBaseInfoID.GoodsClassCode, sk.GoodsBaseInfoID.GoodsName,
                                //   str, sk.GoodsBaseInfoID.Specifications, sk.GoodsBaseInfoID.Material,
                                //    sk.GoodsBaseInfoID.Unit, "1", sk.Money, sk.StorehouseplaceCode, "删除", "打印条码");
                                //this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = sk;

                                //CommonMethod.PrintCode.print(str, sk.GoodsBaseInfoID.GoodsName);
                                //MessageBox.Show("条码机已经生成条码，请为货物粘贴。");
                            }
                        }
                        else
                        {
                            //this.commonDataGridView1.Rows.Add("", "",
                            //                       this.textBox10.Text, "",
                            //                       "", "", "", "", "", "删除", "");
                            //this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = null;
                        }

                        //把条码栏重新置空并且聚焦
                        this.textBox10.Text = "";
                        textBox10.Focus();
                    }

                }
            }
        }

        /// <summary>
        /// 获取grid中最大的code
        /// </summary>
        /// <returns>
        /// 返回最大的编码+1
        /// </returns>
        public string GetMaxCodeFromGridForNniGoods(string code)
        {
            string maxcode = code;

            int count = this.commonDataGridView1.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                if (typeof(Stock) == this.commonDataGridView1.Rows[i].Tag.GetType())
                {
                    if (((Stock)this.commonDataGridView1.Rows[i].Tag).GoodsBaseInfoID.Id == long.Parse(code.Substring(0, 8)))
                    {
                        if (test.TestNum(this.commonDataGridView1.Rows[i].Cells[2].Value.ToString()))
                        {
                            if (long.Parse(this.commonDataGridView1.Rows[i].Cells[2].Value.ToString()) > long.Parse(code))
                            {
                                maxcode = this.commonDataGridView1.Rows[i].Cells[2].Value.ToString();
                            }
                        }
                        
                    }
                }
                else if (typeof(GoodsBaseInfo) == this.commonDataGridView1.Rows[i].Tag.GetType())
                {
                    if (((GoodsBaseInfo)this.commonDataGridView1.Rows[i].Tag).Id == long.Parse(code.Substring(0, 8)))
                    {
                        if (test.TestNum(this.commonDataGridView1.Rows[i].Cells[2].Value.ToString()))
                        {
                            if (long.Parse(this.commonDataGridView1.Rows[i].Cells[2].Value.ToString()) > long.Parse(code))
                            {
                                maxcode = this.commonDataGridView1.Rows[i].Cells[2].Value.ToString();
                            }
                        }

                      
                    }
                }

            }
            maxcode = (long.Parse(maxcode) + 1).ToString().PadLeft(23, '0');
            return maxcode;
        }



        /// <summary>
        ///手动添加入库 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //锁定扫码入库的按钮
            this.button7.Enabled = false;

            //解锁选择按钮
            this.button4.Enabled = true;

            //解锁输入框
            this.textBox11.Enabled = true;
            this.textBox8.Enabled = true;
            this.textBox9.Enabled = true;
            this.textBox10.Enabled = true;
            this.textBox10.ReadOnly = true;

        }


        /// <summary>
        /// 从类别树中选择货物（选择按钮）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            CategtoryTreeview goodstree = new CategtoryTreeview();
            goodstree.IsCatetoryOrGoods = 1;

            #region
            if (goodstree.ShowDialog() == DialogResult.OK)
            {
                if (goodstree.Gg != null)
                {
                    this.textBox2.Text = goodstree.Gg.GoodsClassCode;
                    this.textBox3.Text = goodstree.Gg.GoodsName;
                    this.textBox6.Text = goodstree.Gg.Specifications;
                    this.textBox5.Text = goodstree.Gg.Material;
                    this.textBox4.Text = goodstree.Gg.Unit;
                    this.textBox13.Text = "25";

                    NewGoods = goodstree.Gg;
                }

                sk = opstck.GetStockByGoodsInfoId(NewGoods.Id);

                //如果查处为空说明库存没有统计

                #region 库中无记录
                if (sk == null)
                {
                    //条码机生成条码
                    //唯一条码
                    if (NewGoods.IsUniqueCode == 1)
                    {
                        RuKu_New_dialog_IsHasUniCode Ishave = new RuKu_New_dialog_IsHasUniCode();
                        Ishave.ShowDialog();
                        //货物有自己的产品编码
                        if (Ishave.DialogResult == DialogResult.OK)
                        {
                            //解锁产品编号输入框
                            this.textBox12.Enabled = true;
                            this.textBox12.Focus();
                          
                        }
                        //货物没有自己的产品编码
                        else
                        {
                            this.textBox12.Enabled = false;
                            
                            this.textBox10.Text = GetMaxCodeFromGridForNniGoods( NewGoods.Id.ToString().PadLeft(8, '0') + "000000000000000");
                            
                           
                        }
                        //数量为1
                        this.textBox11.Text = "1";
                        this.textBox11.ReadOnly = true;

                    }
                    if (NewGoods.IsUniqueCode != 1)
                    {
                        this.textBox10.Text = NewGoods.Id.ToString().PadLeft(8, '0') + "000000000000000";
                        this.textBox11.Text = "1"; this.textBox11.ReadOnly = false;
                    }
                }
                #endregion

                #region 库中有记录
                else 
                {

                    #region 需要唯一编码
                    //如果是需要唯一编码的物品则需要新生成条码
                    if (NewGoods.IsUniqueCode == 1)
                    {
                        RuKu_New_dialog_IsHasUniCode Ishave = new RuKu_New_dialog_IsHasUniCode();
                        Ishave.ShowDialog();
                        //货物有自己的产品编码
                        if (Ishave.DialogResult == DialogResult.OK)
                        {
                            //解锁产品编号输入框
                            this.textBox12.Enabled = true;
                            this.textBox12.Focus();
                        }
                        else
                        {
                            this.textBox8.Text = sk.Money.ToString("f3");
                            
                            this.textBox9.Text = sk.StorehouseplaceCode.ToString();

                            this.textBox10.Text = GetMaxCodeFromGridForNniGoods(NewGoods.Id.ToString().PadLeft(8, '0') + DateTime.Now.Ticks.ToString().Substring(0, 15));

                            this.textBox11.Text = "1"; this.textBox11.ReadOnly = false;
                        }
                        string goodssk = sk.GoodsBaseInfoID.GoodsName;
                        this.textBox11.Text = "1"; this.textBox11.ReadOnly = true;
                    }
                    #endregion

                    #region 不需要唯一编码
                    else //显示数据数据
                    {
                        this.textBox8.Text = sk.Money.ToString("f3");
                        this.textBox9.Text = sk.StorehouseplaceCode.ToString();
                        this.textBox10.Text = sk.GoodsCode;
                    }
                    #endregion
                }
                #endregion

                this.button6.Enabled = true;
            }

            #endregion

        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //数量框
            if (this.textBox11.Text == "")
            {
                MessageBox.Show("请输入数量");
                this.textBox11.Focus();
            }
            else
            {
                //金钱输入框
                if (this.textBox8.Text == "" || !test.TestDecimal(this.textBox8.Text)||!test.TestDecimal(this.textBox13.Text))
                {
                    MessageBox.Show("请输入金额，且为数字,最多保留三位小数!");
                    this.textBox8.Focus();
                }
                else
                {
                    if (sk != null)
                    {
                        this.commonDataGridView1.Rows.Add(sk.GoodsBaseInfoID.GoodsClassCode, sk.GoodsBaseInfoID.GoodsName,
                            this.textBox10.Text, sk.GoodsBaseInfoID.Specifications, sk.GoodsBaseInfoID.Material,
                            sk.GoodsBaseInfoID.Unit, this.textBox11.Text, this.textBox8.Text,this.textBox13.Text, sk.StorehouseplaceCode, "删除", "打印条码");

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = sk;
                    }
                    if (sk == null)
                    {
                        this.commonDataGridView1.Rows.Add(newGoods.GoodsClassCode, newGoods.GoodsName,
                           this.textBox10.Text, newGoods.Specifications, newGoods.Material,
                           newGoods.Unit, this.textBox11.Text, this.textBox8.Text, this.textBox13.Text, this.textBox9.Text, "删除", "打印条码");

                        this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = newGoods;
                    }

                    CommonMethod.PrintCode.print(this.textBox10.Text, NewGoods.GoodsName);
                    MessageBox.Show("条码机已经生成条码，请为货物粘贴。");

                    //解锁扫码输入按钮
                    this.button7.Enabled = true;
                    this.button4.Enabled = false;
                    this.button6.Enabled = false;
                    this.textBox11.ReadOnly = false;
                    this.textBox12.Enabled = false;
                    //所用文本框置空
                    SetAlltextNull();

                    //封锁选择添加按钮
                   
                }
            }
        }

        public void SetAlltextNull()
        {
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox6.Text = "";
            this.textBox5.Text = "";
            this.textBox4.Text = "";
            this.textBox11.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.textBox12.Text = "";
        }

        /// <summary>
        /// 产品编号框失焦的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (this.textBox12.Text != ""&&this.textBox12.Enabled == true)
            {
                this.textBox10.Text = NewGoods.Id.ToString().PadLeft(8, '0') + this.textBox12.Text.PadLeft(15, '0');
                if (opstck.GetStockByGoodsCode(this.textBox10.Text) != null || !IsGoodscodeInGrid(this.textBox10.Text))
                {
                    MessageBox.Show("请确认信息，改条码库中已存在或者刚才已经添加");
                    this.textBox10.Text = "";
                    this.textBox12.Focus();
                }

            }
            else if (this.textBox12.Text == "" && this.textBox12.Enabled == true)
            {
                MessageBox.Show("您未填写产品编号。");
                this.textBox12.Focus();
            }
        }

        /// <summary>
        /// 判断条码是否已经加入表格中
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsGoodscodeInGrid(String str)
        {
            bool bol = true; ;
            int count = this.commonDataGridView1.Rows.Count;
            for (int i = 0;i<count;i++)
            {
                if(this.commonDataGridView1.Rows[i].Cells[2].Value.ToString() == str)
                {
                    bol = false;
                    return bol;
                }

            }
            return bol;
        }



    }


}

