using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonWindow.Service;
using System.Collections;
using CommonMethod;
namespace CommonWindow
{
    public partial class SelectGoods : CommonControl.BaseForm
    {

        IList returnIlist;


        int isChooseAll;

        /// <summary>
        /// 库存没有的是否能够选择
        /// 0=>不可以选择
        /// 1=>可以选择
        /// </summary>
        public int IsChooseAll
        {
            get { return isChooseAll; }
            set { isChooseAll = value; }
        }
        /// <summary>
        /// 向外返回的货物列表
        /// 0=>货物编号
        /// 1=>货物名称
        /// 2=>规格
        /// 3=>材质
        /// 4=>单位
        /// 5=>父Id
        /// 6=>库存数量
        /// 7=>货物Id
        /// 8=>父级名称
        /// 9=>需求数量
        /// </summary>
        public IList ReturnIlist
        {
            get { return returnIlist; }
            set { returnIlist = value; }
        }
        OpStock opp = new OpStock();
        GoodsBaseInfo selectCate;
        /// <summary>
        /// 选择的类别
        /// </summary>
        public GoodsBaseInfo SelectCate
        {
            get { return selectCate; }
            set { selectCate = value; }
        }
        
        public SelectGoods()
        {
            InitializeComponent();
            
            ReturnIlist = null;
            IsChooseAll = 0;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //this.button3.Enabled = false;
            IList showGoods;
            if(this.textBox2.Text != "")
            {
               showGoods =  opp.GetCategtoryBranching(SelectCate.Id,this.textBox1.Text,this.textBox3.Text);
            }
            else
            {
               showGoods =  opp.GetCategtoryBranching(1, this.textBox1.Text, this.textBox3.Text);
            }
            ShowSelectInGrid1(showGoods);
            

        }

        public void ShowSelectInGrid1(IList showg)
        {
            this.commonDataGridView1.Rows.Clear();
            IList showgrid1 = showg;
            if (showgrid1.Count > 0)
            {
                int rownum = 0;
               foreach(object[] i in showgrid1)
               {
                   if (i[6].ToString() != "")
                   {

                       this.commonDataGridView1.Rows.Add
                           (0,
                           i[0].ToString(),
                           i[1].ToString(),
                           i[2].ToString(),
                           i[3].ToString(),
                           i[4].ToString(),
                           i[8].ToString(),
                           i[6].ToString());
                       this.commonDataGridView1.Rows[rownum].Tag = i;

                   }
                   else
                   {
                       this.commonDataGridView1.Rows.Add
                               (0,
                                i[0].ToString(),
                                i[1].ToString(),
                                i[2].ToString(),
                                i[3].ToString(),
                                i[4].ToString(),
                                i[8].ToString(),
                               "库存无货");
                       if (this.IsChooseAll == 0)
                           this.commonDataGridView1.Rows[rownum].ReadOnly = true;

                       this.commonDataGridView1.Rows[rownum].Tag = i;
                   }

                   rownum++;
               }
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        public void SelectGoodsToGrid2()
        {
           int count  = this.commonDataGridView1.Rows.Count;
            for(int i = 0 ; i<count ;i++)
            {
                string iftrue = this.commonDataGridView1.Rows[i].Cells[0].Value.ToString();
                if ( iftrue ==  "True")
                {
                    string a =(this.commonDataGridView1.Rows[i].Tag as object[])[7].ToString();
                    if (!IsChoosed(a))
                    {
                        DataGridViewRow selectrow = new DataGridViewRow();
                        selectrow = this.commonDataGridView1.Rows[i];
                        DataGridViewCell d = new DataGridViewTextBoxCell();
                        //selectrow.Cells.Add(d);
                        this.commonDataGridView1.Rows[i].Cells[0].Value = 0;
                        this.commonDataGridView1.Rows.Remove(this.commonDataGridView1.Rows[i]);
                        count = this.commonDataGridView1.Rows.Count;
                        i--;
                        this.commonDataGridView2.Rows.Add(selectrow);
                    }
                }
            }
        }

        /// <summary>
        /// 判断是否已经选中
        /// </summary>
        /// <param name="id">货物的ID</param>
        /// <returns>true代表已经选择了</returns>
        private bool IsChoosed(string id)
        {
            for (int i = 0; i < this.commonDataGridView2.Rows.Count; i++)
            {
                string a = (this.commonDataGridView2.Rows[i].Tag as object[])[7].ToString();
                if (a == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 移除
        /// </summary>
        public void SelectGoodsToGrid1()
        {

            int count = this.commonDataGridView2.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string iftrue = this.commonDataGridView2.Rows[i].Cells[0].Value.ToString();
                if (iftrue == "True")
                {
                    DataGridViewRow selectrow = new DataGridViewRow();
                    selectrow = this.commonDataGridView2.Rows[i];
                    this.commonDataGridView2.Rows.Remove(this.commonDataGridView2.Rows[i]);
                    selectrow.Cells.RemoveAt(8); //.Remove(selectrow.Cells[7]);
                   
                    count = this.commonDataGridView2.Rows.Count;
                    i--;
                    this.commonDataGridView1.Rows.Add(selectrow);
                }
            }
        }

 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CategtoryTreeview categtory = new CategtoryTreeview();
            categtory.IsCatetoryOrGoods = 0;
            categtory.ShowDialog();
            if (categtory.Gg != null)
            SelectCate = categtory.Gg;
            if(SelectCate != null)
            this.textBox2.Text = SelectCate.GoodsName;
        }

        /// <summary>
        /// 查询选全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //this.textBox2.Text = "";
            //this.textBox1.Text = "";
            //this.textBox3.Text = "";
            //this.button3.Enabled = true;
            //this.commonDataGridView1.Rows.Clear();

            //IList showGoods;
            //showGoods = opp.GetCategtoryBranching(1, this.textBox1.Text, this.textBox3.Text);
            //ShowSelectInGrid1(showGoods);
        }

        private void SelectGoods_Load(object sender, EventArgs e)
        {
            //this.Width = Screen.PrimaryScreen.WorkingArea.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectGoodsToGrid2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectGoodsToGrid1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsGoodsNoNum())
            {
                ReturnIlist = new List<object[]>();
                int count = this.commonDataGridView2.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    object[] obj = new object[10];
                    obj[0] = (this.commonDataGridView2.Rows[i].Tag as object[])[0];
                    obj[1] = (this.commonDataGridView2.Rows[i].Tag as object[])[1];
                    obj[2] = (this.commonDataGridView2.Rows[i].Tag as object[])[2];
                    obj[3] = (this.commonDataGridView2.Rows[i].Tag as object[])[3];
                    obj[4] = (this.commonDataGridView2.Rows[i].Tag as object[])[4];
                    obj[5] = (this.commonDataGridView2.Rows[i].Tag as object[])[5];
                    obj[6] = (this.commonDataGridView2.Rows[i].Tag as object[])[6];
                    obj[7] = (this.commonDataGridView2.Rows[i].Tag as object[])[7];
                    obj[8] = (this.commonDataGridView2.Rows[i].Tag as object[])[8];
                    obj[9] = this.commonDataGridView2.Rows[i].Cells[8].Value;
                    returnIlist.Add(obj);
                }
                this.DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("您有未填写数量的货物，请填写数量");
        }
        public bool IsGoodsNoNum()
        {
            //bool bol = true;
            int count = this.commonDataGridView2.Rows.Count;

            TestInput test = new TestInput ();
            for (int i = 0; i < count; i++)
            {
                if (this.commonDataGridView2.Rows[i].Cells[8].Value != null)
                {
                    if (!test.TestDecimal(this.commonDataGridView2.Rows[i].Cells[8].Value.ToString()))
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            return true;
        }
       
       /// <summary>
       /// 双击选中取消
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void commonDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string iftrue = this.commonDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //if (iftrue == "True")
            //{
            //    this.commonDataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
            //    //this.commonDataGridView2.Rows.
            //}
            //else
            //{
            //    this.commonDataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
            //}
        }

        private void commonDataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string iftrue = this.commonDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (iftrue == "True")
            {
                this.commonDataGridView2.Rows[e.RowIndex].Cells[0].Value = false;
                //this.commonDataGridView2.Rows.
            }
            else
            {
                this.commonDataGridView2.Rows[e.RowIndex].Cells[0].Value = true;
            }
        }

        private void commonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string iftrue = this.commonDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (iftrue == "True")
            {
                this.commonDataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
                //this.commonDataGridView2.Rows.
            }
            else
            {
                this.commonDataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
            }
        }

    }
}
