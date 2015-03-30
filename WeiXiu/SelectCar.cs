using EntityClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeiXiu.SQL;

namespace WeiXiu
{
    public partial class SelectCar : Form
    {
        public SelectCar()
        {
            InitializeComponent();
        }
        OP_WX op = new OP_WX();
        private object[] selectedCar;
        /// <summary>
        /// 0=〉保存ModificationContract 1=〉CarBaseInfo
        /// </summary>
        public object[] SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; }
        }

        private void SelectCar_Load(object sender, EventArgs e)
        {
            //selectedCar = new Object[]();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedCar != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else 
            {
                MessageBox.Show("您未选择车辆");
            }
        }
      
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IList carlist = null;
            this.button1.Cursor = Cursors.WaitCursor;
            if (this.textBox1.Text == "")
            {
                if (MessageBox.Show("您未填写输入框，这样将列出所有车辆，您确实要这么做？", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            carlist = op.SelectCarBuyCarNum(this.textBox1.Text.Trim());
            if (carlist != null && carlist.Count > 0)
            {
                foreach (object[] obj in carlist)
                {
                    ModificationContract mo = obj[0] as ModificationContract ;
                    CarBaseInfo car = obj[1] as CarBaseInfo;
                    this.commonDataGridView1.Rows.Add(mo.ContractNo.ToString(), car.PlateNumber.ToString(), CarBaseInfo.ModifyType[car.ModidiedType]);
                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = obj;
                }
            }
            else
            {
                MessageBox.Show("未查到信息…");
            }


            this.button1.Cursor = Cursors.Hand;

        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.commonDataGridView1.Rows.Count>0)
            {
                selectedCar = this.commonDataGridView1.Rows[e.RowIndex].Tag as Object[];
                this.textBox2.Text = ((CarBaseInfo)selectedCar[1]).PlateNumber;
            }
        }
    }
}
