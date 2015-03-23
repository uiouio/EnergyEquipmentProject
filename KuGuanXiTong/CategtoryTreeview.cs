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
using System.Threading;
using KuGuanXiTong.Service;
namespace KuGuanXiTong
{
    public partial class CategtoryTreeview : Form
    {
        private string str;
        private string str2;//用来向内部传值，判断是不是选择了自己
        private int isCatetoryOrGoods;
        private OpStock opstock = new OpStock ();

       
        private GoodsBaseInfo gg;
        
        /// <summary>
        ///向外返回货物 
        /// </summary>
        public GoodsBaseInfo Gg
        {
            get { return gg; }
            set { gg = value; }
        }

        /// <summary>
        ///用来判断是显示货物还是现实类别1为货物0为类别 
        /// </summary>
        public int IsCatetoryOrGoods
        {
            get { return isCatetoryOrGoods; }
            set { isCatetoryOrGoods = value; }
        }
        
        /// <summary>
        ///用来向外传值传出所选择的类别
        /// </summary>
        public string Str
        {
            get { return str; }
            set { str = value; }
        }

       

        public CategtoryTreeview()
        {
            InitializeComponent();
        }
        public CategtoryTreeview(string str)
        {
            InitializeComponent();
            str2 = str;
            this.ControlBox = false;
        }

        Service.Categtory categtory = new Service.Categtory();
        private GoodsBaseInfo currentGoods;

        public GoodsBaseInfo CurrentGoods
        {
            get { return currentGoods; }
            set { currentGoods = value; }
        }

        private IList currentGoodsList;

        public IList CurrentGoodsList
        {
            get { return currentGoodsList; }
            set { currentGoodsList = value; }
        }

        private void RefreshTree(IList goodsList)
        {
            this.treeView1.Nodes.Clear();
            currentGoodsList = goodsList;
            TreeNode pNode = new TreeNode();
            pNode.Text = ((GoodsBaseInfo)goodsList[0]).GoodsName;
            GoodsBaseInfo pGoodsInfo = ((GoodsBaseInfo)goodsList[0]);
            pNode.Tag = pGoodsInfo;
            treeView1.Nodes.Add(pNode);

            if (goodsList != null && goodsList.Count > 0)
            {
                Hashtable treeNodes = new Hashtable();
                foreach (GoodsBaseInfo r in goodsList)
                {
                    if (r.GoodsClassLevel == 1)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = r.GoodsClassCode + " " + r.GoodsName;
                        node.Tag = r;
                        pNode.Nodes.Add(node);
                        treeNodes.Add(r.Id, node);
                    }
                    else
                    {
                        TreeNode fatherNode = (TreeNode)treeNodes[r.GoodsParentClassId];
                        if (fatherNode != null)
                        {
                            TreeNode node = new TreeNode();
                            node.Text = r.GoodsClassCode + " " + r.GoodsName;
                            node.Tag = r;

                            fatherNode.Nodes.Add(node);
                            treeNodes.Add(r.Id, node);
                        }
                    }
                }
            }
            treeView1.Nodes[0].Expand();

        }

        private void CategtoryTreeview_Load(object sender, EventArgs e)
        {
            if (IsCatetoryOrGoods == 1)
            {
                RefreshTree(categtory.GetAllCategtory());
            }
            else 
            {
                RefreshTree(categtory.GetAllCategtoryCalss());
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            this.button3.Visible = false;
            if (IsCatetoryOrGoods != 1)
            {
                GoodsBaseInfo Catetory = new GoodsBaseInfo();
                Catetory = (GoodsBaseInfo)e.Node.Tag;
                this.textBox1.Text = Catetory.GoodsName;
                Str = Catetory.GoodsClassCode;
                Gg = e.Node.Tag as GoodsBaseInfo;


            }
            else if (IsCatetoryOrGoods == 1)
            {
                Gg = e.Node.Tag as GoodsBaseInfo;
                this.textBox1.Text = Gg.GoodsClassCode + " " + Gg.GoodsName;

                if (Gg.GoodsFlag == (int)GoodsBaseInfo.TheGoodsFlag.goods)
                {
                    this.button3.Visible = true;
                    currentGoods = Gg;
                    this.textBox2.Text = currentGoods.Specifications;
                    this.textBox3.Text = currentGoods.Material;
                    this.textBox5.Text = currentGoods.Unit;
                    this.textBox4.Text = currentGoods.GoodsClassDescribe;
                
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsCatetoryOrGoods != 1)
            {
                if (this.textBox1.Text != "" && this.textBox1.Text != null && Str != str2)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else if (Str == str2)
                {
                    MessageBox.Show("不能选择自己");
                }
                else
                {
                    MessageBox.Show("请选择");
                }
            }
            else if (IsCatetoryOrGoods == 1)
            {
                if (this.textBox1.Text != "")
                {
                    if (Gg.GoodsFlag == 1) // 为类别
                    {
                        MessageBox.Show("请选择货物！");
                        this.textBox1.Text = "";
                        Gg = null;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        IsCatetoryOrGoods = 0;
                    }
                }
                else 
                {
                    MessageBox.Show("您尚未选择！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Str = "";
            Gg = null;
            this.Close();
            IsCatetoryOrGoods = 0;
        }

        /// <summary>
        /// 查询库存数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
           this.button3.Cursor = Cursors.WaitCursor;
           Stock s = opstock.GetStockByGoodsInfoId(currentGoods.Id);
           this.button3.Cursor = Cursors.Hand;
            MessageBox.Show(s.Quantity.ToString());
            

        }
    }
}
