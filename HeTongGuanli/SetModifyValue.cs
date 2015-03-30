using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using HeTongGuanLi.Service;
using System.Collections;
using CommonControl;
namespace HeTongGuanLi
{
    public partial class SetModifyValue : CommonControl.CommonTabPage
    {
        ContractService ss = new ContractService();

        IList currentcylinder;

        public SetModifyValue()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void SetModifyValue_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
         
        }
        public override void reFreshAllControl()
        {
            currentcylinder = ss.GetAllCylinderType();
            int i = 1;
            if (currentcylinder != null)
            {
                foreach (CylinderInfo s in currentcylinder)
                {
                    this.commonDataGridView2.Rows.Add(0, i.ToString(), s.CylinderType, s.CylinderNumber, s.CylinderValue, "编辑", "删除");
                    i++;
                }
            }  
        }

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommonDataGridView grid = (CommonDataGridView)sender;
            if (grid.CurrentCell.Value.ToString() == "编辑")
            {
                CylinderAddDialog newGhs = new CylinderAddDialog();
                newGhs.IsShowOrInput = 0;
                newGhs.CylinderInfo = (CylinderInfo)currentcylinder[this.commonDataGridView2.CurrentCell.RowIndex];
                if (newGhs.ShowDialog() == DialogResult.OK)
                {
                    this.commonDataGridView2.Rows.Clear();
                    reFreshAllControl();
                }

            }
            else if (grid.CurrentCell.Value.ToString() == "删除")
            {

                CylinderInfo s = (CylinderInfo)currentcylinder[this.commonDataGridView2.CurrentCell.RowIndex];
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ss.Remove(s);
                    this.commonDataGridView2.Rows.Clear();
                    reFreshAllControl();
                }

            }
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            CylinderAddDialog ca = new CylinderAddDialog();
            ca.IsShowOrInput = 1;
            if (ca.ShowDialog() == DialogResult.OK)
            {
                this.commonDataGridView2.Rows.Clear();
                reFreshAllControl();
            }
        }
    }
}
