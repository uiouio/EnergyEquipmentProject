using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CustomManageWindow.Service;
using EntityClassLibrary;
using CommonControl;
using CommonMethod;
namespace CustomManageWindow
{
    public partial class JingXiaoShangGuanLi : CommonControl.CommonTabPage
    {
        IList currentagents;
        CustomService ss = new CustomService();
        public JingXiaoShangGuanLi()
        {
            InitializeComponent();
        }

        private void JingXiaoShangGuanLi_Load(object sender, EventArgs e)
        {
            this.commonDataGridView1.Rows.Clear();
            reFreshAllControl();
            
        }

        

        private void add_Click(object sender, EventArgs e)
        {
            JingXiaoShangGuanLi_Add_dialog add = new JingXiaoShangGuanLi_Add_dialog();
            add.ShowDialog();
            if (add.isSaved == 1)
            {
                this.commonDataGridView1.Rows.Clear();
                reFreshAllControl();
            }

        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "查看")
            {
                JingXiaoShangGuanLi_View_dialog jw = new JingXiaoShangGuanLi_View_dialog();
                jw.Agent = (Agent)currentagents[this.commonDataGridView1.CurrentCell.RowIndex];
                if (jw.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }
            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                Agent s = (Agent)currentagents[this.commonDataGridView1.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ss.RemoveAgent(s);
                    this.commonDataGridView1.Rows.Clear();
                    reFreshAllControl();
                }


            }
        }
        public override void reFreshAllControl()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.commonDataGridView1.Rows.Clear();
            currentagents = ss.GetAllAgent();
            int i = 1;
            if (currentagents != null)
            {
                foreach (Agent s in currentagents)
                {
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.AgentName, s.AgentAera, s.ContactName, s.ContactPhone,  "查看", "删除");
                    i++;
                }
            }
        }
        public void ShowSelectAgentGrid()
        {
            int i = 1;
            if (currentagents != null)
            {
                foreach (Agent s in currentagents)
                {
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.AgentName, s.AgentAera, s.ContactName, s.ContactPhone, "查看", "删除");
                    i++;
                }
            }
        }
        private void gongHuoShangButton_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            string cname = textBox2.Text;

            this.commonDataGridView1.Rows.Clear();

            currentagents = ss.SelectAgents(name,cname);

            ShowSelectAgentGrid();
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView1);
            div.Columns.Remove(div.Columns[div.ColumnCount - 1]);
            DoExport.DoTheExport(div);

        }

        private void commonPictureButton5_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView1);
            div.Columns.Remove(div.Columns[div.ColumnCount-1]);
            PrintDataGridView.PrintTheDataGridView(div);
        }

        private void commonDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            JingXiaoShangGuanLi_View_dialog jw = new JingXiaoShangGuanLi_View_dialog();
            jw.Agent = (Agent)currentagents[this.commonDataGridView1.CurrentCell.RowIndex];
            if (jw.ShowDialog() == DialogResult.OK)
            {
                this.commonDataGridView1.Rows.Clear();
                reFreshAllControl();
            }
        }
    }
}
