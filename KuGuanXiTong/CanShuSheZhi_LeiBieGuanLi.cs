using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using System.Text.RegularExpressions;
using CommonMethod;
using KuGuanXiTong.Service;
namespace KuGuanXiTong
{
    public partial class CanShuSheZhi_LeiBieGuanLi : CommonControl.CommonTabPage
    {

        TreeNode treeNode;
        private int Ischanged = 0;

        OpStock ops = new OpStock();

        long ParentId_comBox;

        string oldtext;
        
        Service.Categtory categtory = new Service.Categtory();

        TestInput tt = new TestInput();
        string pcode;
        private GoodsBaseInfo currentGoods;

        private GoodsBaseInfo CurrentPargoods;
        /// <summary>
        /// 当前货物
        /// </summary>
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

        public CanShuSheZhi_LeiBieGuanLi()
        {
            InitializeComponent();
        }

        private void CanShuSheZhi_LeiBieGuanLi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }
        public override void reFreshAllControl()
        {
            ReadOnlyAllTextBox();
            RefreshTree(categtory.GetAllCategtory());
            UnEnableButton();
            base.reFreshAllControl();
        }


        /// <summary>
        /// 更新树的数据
        /// </summary>
        /// <param name="goodsList"></param>
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
                        string Specifications = r.Specifications == null ? "" : r.Specifications;
                        node.Text = r.GoodsClassCode + " " + r.GoodsName + Specifications;
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
                            string Specifications = r.Specifications == null ? "" : r.Specifications;
                            node.Text = r.GoodsClassCode + " " + r.GoodsName + Specifications;
                            node.Tag = r;

                            fatherNode.Nodes.Add(node);
                            treeNodes.Add(r.Id, node);
                        }
                    }
                }
            }
            treeView1.Nodes[0].Expand();

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.button3.Visible = false; //删除按钮
            this.textBox9.Text = "";
            //打印条码
            this.button5.Enabled = false;

            if(this.button4.Enabled == false)
            {
                EnableButton();
            }
    
            treeNode = e.Node;
            //GoodsBaseInfo goods = new GoodsBaseInfo();
            currentGoods = (GoodsBaseInfo)treeNode.Tag;
            if (currentGoods != null)
            {
                Stock stoc = ops.GetStockByGoodsInfoId(CurrentGoods.Id);
                if (stoc != null && CurrentGoods.IsUniqueCode == 0 && currentGoods.GoodsFlag != (int)GoodsBaseInfo.TheGoodsFlag.categtory)
                {
                    this.button5.Enabled = true;
                }


                this.textBox1.Text = currentGoods.GoodsName; //类别名称
                textBox2.Text = currentGoods.GoodsClassCode;// 类别编号

                GoodsBaseInfo gg //= new GoodsBaseInfo();
                 = this.categtory.GetParent(currentGoods.GoodsParentClassId);
                textBox7.Text = (gg == null)?"":gg.GoodsName;//上级名称
                pcode = (gg == null) ? "" :gg.GoodsClassCode;
                ParentId_comBox = currentGoods.GoodsParentClassId;
                textBox6.Text = currentGoods.GoodsClassOrder.ToString();//类别顺序
                textBox4.Text = currentGoods.Specifications; // 规格型号
                textBox8.Text = currentGoods.Material;//材质
                textBox5.Text = currentGoods.Unit;//单位
                textBox3.Text = currentGoods.GoodsClassDescribe;

                #region RedioBox
                if (currentGoods.GoodsFlag == (int)GoodsBaseInfo.TheGoodsFlag.categtory) // 类别
                {
                    this.radioButton2.Checked = true;
                    this.button1.Enabled = true; // 新增按钮
                }
                
                else if (currentGoods.GoodsFlag == (int)GoodsBaseInfo.TheGoodsFlag.goods)//货物
                {
                    this.radioButton1.Checked = true;
                    this.button1.Enabled = false;

                    if(CurrentGoods.IsWaring == 1)
                    {
                        this.checkBox2.Checked = true;
                        this.textBox9.Text = CurrentGoods.WaringNum.ToString();
                    }
                    else if (CurrentGoods.IsWaring == 0)
                    {
                        this.checkBox2.Checked = false;
                    }
                }
                
                else if (currentGoods.GoodsFlag == (int)GoodsBaseInfo.TheGoodsFlag.Taojian) //套件
                {
                    this.radioButton3.Checked = true;
                    this.button1.Enabled = true;//新增按钮

                    if (CurrentGoods.IsWaring == 1)
                    {
                        this.checkBox2.Checked = true;
                        this.textBox9.Text = CurrentGoods.WaringNum.ToString();
                    }
                    else if (CurrentGoods.IsWaring == 0)
                    {
                        this.checkBox2.Checked = false;
                    }

                }
                #endregion

                if (currentGoods.IsUniqueCode == 1)
                {
                    this.checkBox1.Checked = true;
                }
                else if(currentGoods.IsUniqueCode != 1)
                    this.checkBox1.Checked = false;
                if (currentGoods.GoodsFlag == (int)GoodsBaseInfo.TheGoodsFlag.goods)
                {
                    string sql = "select u from Stock u where u.GoodsBaseInfoID = " + currentGoods.Id;
                    IList li =  categtory.loadEntityList(sql);
                    if (li == null || li.Count == 0)
                    {
                        this.button3.Visible = true;
                    }
                }
                else if (currentGoods.GoodsFlag == (int)GoodsBaseInfo.TheGoodsFlag.categtory)
                {
                    string sql = "select u from GoodsBaseInfo u where u.GoodsParentClassId = " + currentGoods.Id;
                    IList li = categtory.loadEntityList(sql);
                    if (li == null || li.Count == 0)
                    {
                        this.button3.Visible = true;
                    }
                
                }
                else if (currentGoods.GoodsFlag == (int)GoodsBaseInfo.TheGoodsFlag.Taojian)
                {
                    string sql = "select u from GoodsBaseInfo u where u.GoodsParentClassId = " + currentGoods.Id;
                    string sql2 = "select u from Stock u where u.GoodsBaseInfoID = " + currentGoods.Id;
                    IList li = categtory.loadEntityList(sql);
                    IList li2 = categtory.loadEntityList(sql2);
                    if ((li == null || li.Count == 0) && (li2 == null || li2.Count == 0))
                    {
                        this.button3.Visible = true;
                    }

                }

            }

        }

        public void ReadOnlyAllTextBox()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox8.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            checkBox2.Enabled = false;
            textBox9.Enabled = false;

            

            linkLabel1.Enabled = false;
            this.checkBox1.Enabled = false;
        }

        public void UnReadOnlyAllTextBox()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox8.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
           
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            linkLabel1.Enabled = true;

            if(currentGoods.GoodsFlag != (int)GoodsBaseInfo.TheGoodsFlag.categtory )
            {
                this.checkBox1.Enabled = true;
                this.checkBox2.Enabled = true;
                this.textBox9.Enabled = true;
            }
        }

      

        public void EnableButton()
        {
            this.button1.Enabled = true;
            this.button3.Enabled = true;
            this.button4.Enabled = true;
        }

        public void UnEnableButton()
        {
            this.button1.Enabled = false;
            this.button3.Enabled = false;
            this.button2.Enabled = false;
            this.button4.Enabled = false;
            this.button5.Enabled = false;
        }

        /// <summary>
        /// 编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == false)
            {
                this.button2.Enabled = true;
                this.button1.Enabled = false;
                this.button3.Enabled = false;
            }

            UnReadOnlyAllTextBox();

          
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            NullToKong();
           
           if(Ischanged == 1)
           {
               if (textBox7.Text == "" || textBox7.Text == null)
               {
                   currentGoods.GoodsParentClassId = 0;
                   currentGoods.GoodsClassLevel = 0;
               }
               else
               {
                   //GoodsBaseInfo pgoods = new GoodsBaseInfo();
                   //pgoods = categtory.GetClassByPcode(pcode);
                   if (CurrentPargoods != null)
                   {
                       currentGoods.GoodsParentClassId = CurrentPargoods.Id;
                       currentGoods.GoodsClassLevel = CurrentPargoods.GoodsClassLevel + 1;
                   }
               }
               currentGoods.GoodsName = textBox1.Text;
               currentGoods.GoodsClassCode = textBox2.Text;
               currentGoods.GoodsClassOrder = long.Parse(this.textBox6.Text);
               currentGoods.Specifications = this.textBox4.Text;
               currentGoods.Unit = textBox5.Text;
               currentGoods.Material = textBox8.Text;
               currentGoods.GoodsClassDescribe = this.textBox3.Text;
               if (this.radioButton1.Checked) // 货物
               {
                   currentGoods.GoodsFlag = (int)GoodsBaseInfo.TheGoodsFlag.goods;
               }
               else if (this.radioButton2.Checked) // 分类
               {
                   currentGoods.GoodsFlag = (int)GoodsBaseInfo.TheGoodsFlag.categtory;
               }
               else if (this.radioButton3.Checked)
               {
                   currentGoods.GoodsFlag = (int)GoodsBaseInfo.TheGoodsFlag.Taojian;
               }
               if (this.checkBox1.Checked)
                   currentGoods.IsUniqueCode = 1;
               else if (!this.checkBox1.Checked)
                   currentGoods.IsUniqueCode = 0;
               
               if(checkBox2.Checked  == true)
               {
                   
                   currentGoods.IsWaring = 1;
                   currentGoods.WaringNum = long.Parse(this.textBox9.Text);

               }
               else if(checkBox2.Checked == false)
               {
                   currentGoods.IsWaring = 0;
               }

               currentGoods =  categtory.SaveOrUpdateEntity(currentGoods) as GoodsBaseInfo;

               //保持原来的展开状态
               treeNode.Text = currentGoods.GoodsName;
               treeNode.Tag = currentGoods;
               

               //this.treeView1.Nodes.Clear();
               //RefreshTree(categtory.GetAllCategtory());

               Ischanged = 0;
           
           }
           
            ReadOnlyAllTextBox();
            this.button2.Enabled = false;
            this.button1.Enabled = true;
            this.button3.Enabled = true;
        }

        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            CanShuSheZhi_LeiBieGuanLi_NewClass newClass = new CanShuSheZhi_LeiBieGuanLi_NewClass(currentGoods);
            newClass.ShowDialog();
            if(newClass.DialogResult == DialogResult.OK)
            {
                TreeNode newnode =  new TreeNode ();
                newnode.Text = newClass.NewGoods.GoodsName;
                newnode.Tag = newClass.NewGoods;
                treeNode.Nodes.Add(newnode);
                //this.treeView1.Nodes.Clear();
                //RefreshTree(categtory.GetAllCategtory());
            }
           
        }



       
       

        /// <summary>
        /// 类别编号 输入框失焦事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_Leave(object sender, EventArgs e)
        {
            
            if(!tt.TestNum(this.textBox2.Text)||this.textBox2.Text == "")
            {
                MessageBox.Show("请输入数字");
                this.textBox2.Text = oldtext;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            oldtext = this.textBox2.Text;
        }

        public void NullToKong()
        {
            if (textBox3.Text == null)
            {
                textBox3.Text = "";
            }
            if (textBox4.Text == null)
            {
                textBox4.Text = "";
            }
            if (textBox5.Text == null)
            {
                textBox5.Text = "";
            }
        
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                this.textBox1.Text = oldtext;
                
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            oldtext = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            oldtext = this.textBox2.Text;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            Regex classCode = new Regex("^[0-9]*$");
            Match m = classCode.Match(this.textBox2.Text);
            if (!m.Success || this.textBox2.Text == "")
            {
                MessageBox.Show("请输入数字");
                this.textBox2.Text = oldtext;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CategtoryTreeview tree = new CategtoryTreeview(currentGoods.GoodsClassCode);
            tree.ShowDialog();

            if (tree.Str != "" && tree.Str != null&&tree.Gg!=null)
            {
                CurrentPargoods = tree.Gg;
                pcode = tree.Str;
                textBox7.Text = categtory.GetGnameByCode(tree.Str);
            }
            

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("您确定要删除该节点吗？", "提示消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                GoodsBaseInfo gg  = currentGoods;
                RemoveNode(gg.Id);

                TreeNode t = treeNode.Parent;
                t.Nodes.Remove(treeNode);
                //this.treeView1.Nodes.Clear();
                //RefreshTree(categtory.GetAllCategtory());
                
                MessageBox.Show("删除成功！");
            }

        }

        public void RemoveNode(long id)
        {
            IList goods =  categtory.GetTheSamePidGoodsByPid(id);
            if (goods != null)
            {
                foreach (GoodsBaseInfo o in goods)
                {
                    RemoveNode(o.Id);
                }
                categtory.RemoveGoods(id);
            }
            else 
            {
                categtory.RemoveGoods(id);
            }
        }


        /// <summary>
        /// 打印条码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            String str = CurrentGoods.Id.ToString().PadLeft(8, '0') + "000000000000000";
            CommonMethod.PrintCode.print(str, CurrentGoods.GoodsName);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TextChanged(object sender, EventArgs e)
        {
            Ischanged = 1;
            
           
        }

    }
}
