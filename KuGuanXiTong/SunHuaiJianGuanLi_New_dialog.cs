using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonWindow;
using System.Collections;
using EntityClassLibrary;
using CommonMethod;
using KuGuanXiTong.Service;

namespace KuGuanXiTong
{
    public partial class SunHuaiJianGuanLi_New_dialog : CommonControl.BaseForm
    {
        OpStock ops = new OpStock();
        Categtory cca = new Categtory();
        UserInfo user;
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }


        public SunHuaiJianGuanLi_New_dialog()
        {
            InitializeComponent();
            User = new UserInfo();
        }

        private void SunHuaiJianGuanLi_New_dialog_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width < 800)
                this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6);
            this.textBox1.Text = User.Name;
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.commonDataGridView1.Rows.Count > 0)
            {
                if (MessageBox.Show("操作之后不能更改，您确定这样做吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    for (int i = 0; i < this.commonDataGridView1.Rows.Count; i++)
                    {
                        if (this.commonDataGridView1.Rows[i].Cells[7].Value == null || this.commonDataGridView1.Rows[i].Cells[8].Value == null)
                        {
                            MessageBox.Show("您有未填写的项！");
                            break;
                        }
                        else
                        {
                            BrokenParts newbroke = new BrokenParts();
                            newbroke.GoodsBaseInfoId = this.commonDataGridView1.Rows[i].Tag as GoodsBaseInfo;
                            newbroke.Quantity = Convert.ToInt64(this.commonDataGridView1.Rows[i].Cells[7].Value);
                            if (this.commonDataGridView1.Rows[i].Cells[8].Value.ToString() == BrokenParts.BroketypeName[1])
                            {
                                newbroke.BrokenType = 1;
                            }
                            else if (this.commonDataGridView1.Rows[i].Cells[8].Value.ToString() == BrokenParts.BroketypeName[2])
                            {
                                newbroke.BrokenType = 2;
                            }
                            else if (this.commonDataGridView1.Rows[i].Cells[8].Value.ToString() == BrokenParts.BroketypeName[3])
                            {
                                newbroke.BrokenType = 3;
                            }

                            if (Convert.ToBoolean(this.commonDataGridView1.Rows[i].Cells[6].Value))
                            {
                                newbroke.IsBrokenInStock = 1;
                                Stock stos
                                 = ops.GetStockByGoodsCode(this.commonDataGridView1.Rows[i].Cells[1].Value.ToString());
                                if (stos != null && stos.Quantity >= Convert.ToInt64(this.commonDataGridView1.Rows[i].Cells[7].Value))
                                {


                                    newbroke.ReplyTime = DateTime.Now.Ticks;
                                    newbroke.ResponPerson = (this.commonDataGridView1.Rows[i].Cells[9].Value == null) ? "" : this.commonDataGridView1.Rows[i].Cells[9].Value.ToString();
                                    newbroke.Remark = (this.commonDataGridView1.Rows[i].Cells[10].Value == null) ? "" : this.commonDataGridView1.Rows[i].Cells[10].Value.ToString();

                                    newbroke.ReplyPersonId = this.User;

                                    newbroke = cca.SaveOrUpdateEntity(newbroke) as BrokenParts;


                                    //库存数量改变
                                    stos.Quantity = stos.Quantity - Convert.ToInt64(this.commonDataGridView1.Rows[i].Cells[7].Value);
                                    ops.SaveOrUpdateEntity(stos);

                                    //增加一条出库记录
                                    StockOperation Opstoc = new StockOperation();

                                    Opstoc.OperationTpye = (long)StockOperation.OpTypeFlag.OutByBrokenParts;
                                    Opstoc.IOFlag = (long)StockOperation.InOrOutFlag.Out;
                                    Opstoc.OperationTime = DateTime.Now.Ticks;
                                    Opstoc.Remark = this.commonDataGridView1.Rows[i].Cells[10].ToString();
                                    Opstoc.UserId = User;
                                    Opstoc.RetrospectListNumber = newbroke.Id.ToString();

                                    Opstoc = ops.SaveOrUpdateEntity(Opstoc) as StockOperation;


                                    //增加一条出库详情记录

                                    StockOperationDetail opdet = new StockOperationDetail();

                                    opdet.StockId = stos;
                                    opdet.StockOperationId = Opstoc;
                                    opdet.GoodsCode = this.commonDataGridView1.Rows[i].Cells[2].Value.ToString();
                                    opdet.Quantity = Convert.ToInt64(this.commonDataGridView1.Rows[i].Cells[7].Value);

                                    ops.SaveOrUpdateEntity(stos);

                                    this.commonDataGridView1.Rows.RemoveAt(i);
                                    i--;

                                }
                                else
                                {
                                    MessageBox.Show("您填写的数量有误！");

                                }

                            }
                            else if (!Convert.ToBoolean(this.commonDataGridView1.Rows[i].Cells[6].Value))
                            {
                                newbroke.IsBrokenInStock = 0;

                                newbroke.ReplyTime = DateTime.Now.Ticks;
                                newbroke.ResponPerson = (this.commonDataGridView1.Rows[i].Cells[9].Value == null) ? "" : this.commonDataGridView1.Rows[i].Cells[9].Value.ToString();
                                newbroke.Remark = (this.commonDataGridView1.Rows[i].Cells[10].Value == null) ? "" : this.commonDataGridView1.Rows[i].Cells[10].Value.ToString();

                                newbroke.ReplyPersonId = this.User;

                                cca.SaveOrUpdateEntity(newbroke);

                                this.commonDataGridView1.Rows.RemoveAt(i);
                                i--;

                            }


                        }
                    }

                    if (this.commonDataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("操作成功！");
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {
                MessageBox.Show("您未添加货物");
            }
           
            
           

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string str =  this.textBox2.Text;

            TestInput test = new TestInput();
            if (this.textBox2.Text.Length != 23)
            {
                MessageBox.Show("请输入正确条码！");
            }
            else
            {
                string goodsid = str.Substring(0, 8);


                GoodsBaseInfo newg = new GoodsBaseInfo();
                newg = cca.GetCategoryById(Convert.ToInt64(goodsid));

                this.commonDataGridView1.Rows.Add(newg.GoodsClassCode,
                    str,
                    newg.GoodsName, newg.Specifications, newg.Specifications,
                    newg.Unit,false,null,null,null,null,"删除");
                this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = newg;
                
            }


        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6 && Convert.ToBoolean(commonDataGridView1.CurrentRow.Cells[6].EditedFormattedValue) == true)
            {
                MessageBox.Show("选中之后会在库存中减去相应数量！");
            }

            if(e.ColumnIndex == 11&&this.commonDataGridView1.CurrentCell.Value.ToString() == "删除")
            {
                this.commonDataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            
        }
   
    }
}
