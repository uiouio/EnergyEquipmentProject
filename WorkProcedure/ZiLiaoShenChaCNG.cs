using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkProcedure
{
    public partial class ZiLiaoShenChaCNG : CommonControl.CommonTabPage
    {
        public ZiLiaoShenChaCNG()
        {
            InitializeComponent();
        }

        private void ZiLiaoShenCha_Load(object sender, EventArgs e)
        {
            ZiLiaoShenChaCNGDataGridView1.Rows.Add(1, "1", "冀B2008", "123", "0000001", "2014.6.30", "正在验车",  "编辑");
            ZiLiaoShenChaCNGDataGridView1.Rows.Add(0, "2", "冀B2028", "166", "0000002", "2014.6.30", "正在验车",  "编辑");
            ZiLiaoShenChaCNGDataGridView1.Rows.Add(1, "3", "冀B2038", "130", "0000003", "2014.6.30", "正在验车", "编辑");


            /*
            //Datagridview添加列    
            DataGridViewTextBoxColumn DispatchNo = new DataGridViewTextBoxColumn();
            DispatchNo.Name = "acCode";
            DispatchNo.DataPropertyName = "acCode";
            DispatchNo.HeaderText = "派工单编号";
            dataGridView1.Columns.Add(DispatchNo);

            DataGridViewTextBoxColumn ChePaiHao = new DataGridViewTextBoxColumn();
            ChePaiHao.Name = "acCode";
            ChePaiHao.DataPropertyName = "acCode";
            ChePaiHao.HeaderText = "车牌号";
            dataGridView1.Columns.Add(ChePaiHao);

            DataGridViewTextBoxColumn CheZhuXingMing = new DataGridViewTextBoxColumn();
            CheZhuXingMing.Name = "acCode";
            CheZhuXingMing.DataPropertyName = "acCode";
            CheZhuXingMing.HeaderText = "车主姓名";
            dataGridView1.Columns.Add(CheZhuXingMing);

            DataGridViewLinkColumn Operate1 = new DataGridViewLinkColumn();
            Operate1.Name = "Operate1";
            Operate1.DataPropertyName = "acCode";
            Operate1.HeaderText = "操作";
            Operate1.Text = "编辑";
            Operate1.UseColumnTextForLinkValue = true;
            dataGridView1.Columns.Add(Operate1);

            DataGridViewLinkColumn Operate2 = new DataGridViewLinkColumn();
            Operate2.Name = "Operate2";
            Operate2.DataPropertyName = "acCode";
            Operate2.HeaderText = "操作";
            Operate2.Text = "查看";
            Operate2.UseColumnTextForLinkValue = true;
            dataGridView1.Columns.Add(Operate2);
            
            //Datagridview创建行  
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "2002020";
            this.dataGridView1.Rows[index].Cells[1].Value = "冀J29292";
            this.dataGridView1.Rows[index].Cells[2].Value = "李世杰";
            //Datagridview创建行  
            index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "2002021";
            this.dataGridView1.Rows[index].Cells[1].Value = "冀J66880";
            this.dataGridView1.Rows[index].Cells[2].Value = "爱因斯坦";
            //Datagridview创建行  
            index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "2002022";
            this.dataGridView1.Rows[index].Cells[1].Value = "冀J00110";
            this.dataGridView1.Rows[index].Cells[2].Value = "米开朗基罗";
        */
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (dataGridView1.CurrentCell.Value.ToString() == "编辑")
            {
                ZiLiaoShenCha_LNGEdit myZiLiaoShenCha_LNGEdit = new ZiLiaoShenCha_LNGEdit();
                myZiLiaoShenCha_LNGEdit.gaiZhuangBianHao = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                myZiLiaoShenCha_LNGEdit.chePaiHao = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                myZiLiaoShenCha_LNGEdit.ShowDialog();
            }

            if (dataGridView1.CurrentCell.Value.ToString() == "查看")
            {
                ZiLiaoShenCha_LNGEdit myZiLiaoShenCha_LNGEdit = new ZiLiaoShenCha_LNGEdit();
                myZiLiaoShenCha_LNGEdit.gaiZhuangBianHao = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                myZiLiaoShenCha_LNGEdit.chePaiHao = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                myZiLiaoShenCha_LNGEdit.ShowDialog();
                
            }
             */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                ZiLiaoShenCha_CNGEdit tt = new ZiLiaoShenCha_CNGEdit();
                tt.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {


        }
    }
}