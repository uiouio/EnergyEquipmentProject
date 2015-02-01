using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using Iesi.Collections.Generic;
using Iesi.Collections;
namespace CustomManageWindow
{
    public partial class JingXiaoShangGuanLi_View_dialog : CommonControl.BaseForm
    {
        private Agent agent;

        public Agent Agent
        {
            get { return agent; }
            set { agent = value; }
        }
        private ISet currentGoods = new HashedSet<AgentGood>();
        public JingXiaoShangGuanLi_View_dialog()
        {
            InitializeComponent();
        }

        private void JingXiaoShangGuanLi_View_dialog_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = Agent.AgentName;
            this.textBox3.Text = Agent.AgentAera;
            this.textBox4.Text = Agent.ContactName;
            this.textBox5.Text = Agent.ContactPhone;
            this.textBox6.Text = Agent.ContactAddress;
            ShowGoodsGrid(Agent.AgentGoodBaseInfo);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);

        }
        private void ShowGoodsGrid(ISet<AgentGood> goodsList)
        {

            if (goodsList != null && goodsList.Count > 0)
            {
                int i = 0;
                foreach (AgentGood r in goodsList)
                {
                    i++;
                    commonDataGridView1.Rows.Add(0, i.ToString(), r.GoodsBaseInfoId.GoodsName, r.Count,  r.GoodsBaseInfoId.Unit,new DateTime (Agent.DeliveryTime).ToLongDateString(),Agent.Progess );
                    currentGoods.Add(r);
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = r;
                }
            }
        }
    }
}
