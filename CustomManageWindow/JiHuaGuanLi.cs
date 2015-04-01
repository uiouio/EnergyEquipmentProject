using System;
using System.Collections.Generic;
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
using CommonMethod;
namespace CustomManageWindow
{
    public partial class JiHuaGuanLi : CommonControl.CommonTabPage
    {
        CustomService ss = new CustomService();
        IList currentagents;
        public JiHuaGuanLi()
        {
            InitializeComponent();
        }

        private void XuQiuGuanLi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void add_Click(object sender, EventArgs e)
        {
            JiHua_Add_dialog add = new JiHua_Add_dialog();
            add.UserInfo = this.User;
            add.IsShowOrInput = 1;
            add.ShowDialog();
             if(add.IfSaved==1)
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
                JiHua_Add_dialog jj = new JiHua_Add_dialog("计划详细信息");
                jj.Agent=(Agent)currentagents[this.commonDataGridView1.CurrentCell.RowIndex];
                jj.IsShowOrInput = 0;
                jj.ShowDialog();
            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                Agent  s = (Agent)currentagents[this.commonDataGridView1.CurrentCell.RowIndex];
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
            currentagents = ss.GetAllAgentPlan();
            int i = 1;
            if (currentagents != null)
            {
                foreach (Agent s in currentagents)
                {
                    this.commonDataGridView1.Rows.Add(0, i.ToString(), s.AgentName,s.ContactName, s.ContactPhone,new DateTime (s.DeliveryTime) ,s.Progess,"查看", "删除");
                    i++;
                }
            }
        }

        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView1);
            div.Columns.Remove(div.Columns[7]);
            div.Columns.Remove(div.Columns[7]);
            DoExport.DoTheExport(div);
        }

        private void commonPictureButton5_Click(object sender, EventArgs e)
        {
            DataGridView div = new DataGridView();
            div = OperateDateGridView.CloneDataGridView(this.commonDataGridView1);
            div.Columns.Remove(div.Columns[7]);
            div.Columns.Remove(div.Columns[7]);
            PrintDataGridView.PrintTheDataGridView(div);
        }

        private void commonDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            JiHua_Add_dialog jj = new JiHua_Add_dialog("计划详细信息");
            jj.Agent = (Agent)currentagents[this.commonDataGridView1.CurrentCell.RowIndex];
            jj.IsShowOrInput = 0;
            jj.ShowDialog();
        }
    }
}
