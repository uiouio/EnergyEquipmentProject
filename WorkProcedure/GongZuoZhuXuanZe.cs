using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WorkProcedure.SQL;
using EntityClassLibrary;

namespace WorkProcedure
{
    public partial class GongZuoZhuXuanZe : Form
    {
        OP_LZB OP_LZB = new OP_LZB();
        IList Currentss;      

        RefitWork refitWork;
        /// <summary>
        ///传输Dispatch1传过来的值 
        /// </summary>
        public RefitWork RefitWork
        {
            get { return refitWork; }
            set { refitWork = value; }
        }

        public GongZuoZhuXuanZe()
        {
            InitializeComponent();
            comboBox2.Text = "工作组1";
            
        }

        private void GongZuoZhuXuanZe_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            ShowGridViewPaiGongDan();
        }

        public void ShowGridViewPaiGongDan()
        {
            Currentss = OP_LZB.GetAllPaiGongDanChaKan();
            int i = 1;
            if (Currentss != null)
            {
                foreach (RefitWork s in Currentss)
                {
                    GongZuoZuDataGridView1.Rows.Add(i.ToString(), s.DispatchOrder, new DateTime(s.DispatchTime).ToString("yyyy-MM-dd"), s.WorkingGroupId.WorkingGroupName);
                    this.GongZuoZuDataGridView1.Rows[this.GongZuoZuDataGridView1.Rows.Count - 1].Tag = s;
                    i++;
                }
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != null)
            {
               refitWork.WorkingGroupId = this.comboBox2.SelectedValue as WorkingGroup;
               refitWork.DispatchTime = DateTime.Now.Ticks;
               refitWork.DispatchState = (int)RefitWork.SaveDispatchingDispatchReceive.Dispacth;
               OP_LZB.SaveOrUpdateEntity(refitWork);
               LiuZhuanBiao LiuZhuanBiao = new LiuZhuanBiao();
               LiuZhuanBiao.PaiGongDan = refitWork;
               OP_LZB.SaveOrUpdateEntity(LiuZhuanBiao);
               if (MessageBox.Show("确定要派工？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                   this.DialogResult = DialogResult.OK;

               }
                           
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadComboBox()
        {
            if (this.comboBox2.Items.Count == 0)
            {
                IList group = OP_LZB.GetAllGroups();
                if (group != null)
                {
                    this.comboBox2.DataSource = group;
                    this.comboBox2.DisplayMember = "WorkingGroupName";
                    this.comboBox2.ValueMember = "Itself";
                }
            }
        }
                
    }
}
