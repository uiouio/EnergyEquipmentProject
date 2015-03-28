using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkProcedure
{
    public partial class UNDODispatch : CommonControl.CommonTabPage
    {
        public UNDODispatch()
        {
            InitializeComponent();
        }

        private void Dispatch_Load(object sender, EventArgs e)
        {
            
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

            DataGridViewLinkColumn PaiGong = new DataGridViewLinkColumn();
            PaiGong.Name = "Operate";
            PaiGong.DataPropertyName = "acCode";
            PaiGong.HeaderText = "操作";
            PaiGong.Text = "派工";
            PaiGong.UseColumnTextForLinkValue = true;
            dataGridView1.Columns.Add(PaiGong);
            
            

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            //if (dataGridView1["Operate", dataGridView1.CurrentCell.RowIndex].Value.ToString() == "派工")
            //    MessageBox.Show(dataGridView1.SelectedCells[0].Value + " right");
            if (dataGridView1.CurrentCell.Value.ToString() == "派工")
            {
                Dispatch_PaiGong myDispatch_PaiGong = new Dispatch_PaiGong();
                myDispatch_PaiGong.gaiZhuangBianHao = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                myDispatch_PaiGong.chePaiHao = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                myDispatch_PaiGong.ShowDialog();
            }
            */
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PaiGongDanShaiXuanGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
