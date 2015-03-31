using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow.Service;
using CommonControl;
using CommonWindow;
using Iesi.Collections.Generic;
using Iesi.Collections;
namespace CustomManageWindow
{
    public partial class JiHua_Add_dialog : CommonControl.BaseForm
    { /// <summary>
        /// 是用来展示数据还是输入数据，1用来输入数据，0用来展示数据
        /// </summary>
        private int isShowOrInput;
        public int IsShowOrInput
        {
            get { return isShowOrInput; }
            set { isShowOrInput = value; }
        }
        private Agent agent;

        public Agent Agent
        {
            get { return agent; }
            set { agent = value; }
        }
        IList currentagents;
        IList goods;
        private ISet currentGoods = new HashedSet<AgentGood>();
        CustomService ss = new CustomService();
       
        public  int IfSaved = 0;
        public JiHua_Add_dialog()
        {
            InitializeComponent();
        }
        public JiHua_Add_dialog(string headtextname)
        {
          
            this.Text = headtextname;
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JiHua_Add_dialog_Load(object sender, EventArgs e)
        {
           if(IsShowOrInput == 0)
            {
                this.Text = "计划详细信息";
                if(agent!=null)
                {
                  
                   
                    this.dateTimePicker1.Enabled = false;
                    this.comboBox1.Enabled = false;
                    this.comboBox2.Enabled = false;
                    this.button4.Visible = false;
                    long tick=Agent.DeliveryTime;
                    DateTime dt = new DateTime(tick);
                    this.dateTimePicker1.Value = dt;
                    this.comboBox1.SelectedIndex = (Agent.DeliveryForm.Contains("自提")?0:1);
                    this.comboBox2.SelectedIndex = (Agent.Progess.Contains("执行中")?0:1);
                    ShowGoodsGrid(Agent.AgentGoodBaseInfo);
                }

            }
           
            if (IsShowOrInput == 1)
            {
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            }
        }
        private void ShowGoodsGrid(ISet<AgentGood> goodsList)
        {

            if (goodsList != null && goodsList.Count > 0)
            {
                int i = 0;
                foreach (AgentGood r in goodsList)
                {
                    i++;
                    commonDataGridView1.Rows.Add(0,i.ToString(), r.GoodsBaseInfoId.GoodsClassCode, r.GoodsBaseInfoId.GoodsName,r.Count, r.GoodsBaseInfoId.Material, r.GoodsBaseInfoId.Unit);
                    currentGoods.Add(r);
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = r;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int i=1;
            SelectGoods xzhw = new SelectGoods();
            if (xzhw.ShowDialog() == DialogResult.OK)
            {
                goods = xzhw.ReturnIlist;
                foreach(Object[] s in goods)
                {
                    i++;
                    commonDataGridView1.Rows.Add(0,i.ToString(),s[8],s[1],s[9],s[4],s[2],this.UserInfo.Name,DateTime.Now.ToLongDateString());
                    AgentGood ag = new AgentGood();
                    ag.Count = float.Parse(s[9].ToString());
                    GoodsBaseInfo gbi = new GoodsBaseInfo();
                    gbi.Id = Convert.ToInt64(s[7]);
                    ag.GoodsBaseInfoId = gbi;
                    currentGoods.Add(ag);
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = ag;
                }
               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            agent.DeliveryTime = dateTimePicker1.Value.Ticks;
            agent.DeliveryForm = comboBox1.Text;
            agent.Progess = comboBox2.Text;
            agent.PlanFlag=(int)Agent.chehaveplan.Yes;
            agent.AgentGoodBaseInfo = (Iesi.Collections.Generic.ISet<AgentGood>)currentGoods;
            foreach (AgentGood rwg in currentGoods)
            {
                rwg.AgentId = null;
                ss.SaveOrUpdateEntity(rwg);
            }
            ss.SaveOrUpdateEntity(agent);
            IfSaved = 1;
            
            if (IsShowOrInput == 1)
            {
                MessageBox.Show("添加成功");
                this.Close();
            }
            else if (IsShowOrInput == 0)
            {
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = this.textBox4.Text;
            currentagents = ss.SelectAgentsByName(name);
            int i = 1;
            if (currentagents != null)
            {
                foreach (Agent s in currentagents)
                {
                    this.commonDataGridView2.Rows.Add(0, i.ToString(), s.AgentName, s.ContactName, s.ContactPhone);
                    agent = (Agent)currentagents[this.commonDataGridView2.CurrentCell.RowIndex];
                    i++;
                }
            }
        }

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < commonDataGridView2.RowCount; i++)
            {
                DataGridViewCheckBoxCell check = commonDataGridView2.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                if (check.EditedFormattedValue.ToString() == "True")
                {
                    agent = (Agent)currentagents[this.commonDataGridView2.CurrentCell.RowIndex];
                    this.textBox4.Text = agent.AgentName;
                }

            }
        }
 
    }
}
