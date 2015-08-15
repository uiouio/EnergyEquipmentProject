using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;

namespace GongYiGuanLi
{
    public partial class PaiGongDanMuBan : CommonControl.CommonTabPage
    {
        Service.DispatchService dispatchService = new Service.DispatchService();
        public PaiGongDanMuBan()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            PaiGongDanMuBan_add_Dialog pad = new PaiGongDanMuBan_add_Dialog();
            pad.UserInfo = this.User;
            pad.ShowDialog();
            if(pad.DialogResult==DialogResult.OK)
            {
                reFreshAllControl();
            }
        }

        private void initDataGridView(IList modelList)
        {
            commonDataGridView.Rows.Clear();
            if (modelList != null && modelList.Count > 0)
            {
                int i=0;
                foreach (RefitWorkModel rwm in modelList)
                {
                    i++;
                    commonDataGridView.Rows.Add(i.ToString(), rwm.Name, rwm.UserId.Name, rwm.FinalUserId.Name, rwm.Remarks, "编辑", "删除");
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = rwm;
                }
            }
        }

        public override void reFreshAllControl()
        {
            IList modelList = dispatchService.getAllModel();
            initDataGridView(modelList);
        }

        private void PaiGongDanMuBan_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IList modelList = dispatchService.getAllModel(textBox1.Text.Trim(),textBox2.Text.Trim());
            initDataGridView(modelList);
        }

        private void commonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = commonDataGridView.Rows[e.RowIndex];
            RefitWorkModel rwm = (RefitWorkModel)r.Tag;
            if (e.ColumnIndex == 5)
            {
                PaiGongDanMuBan_add_Dialog pad = new PaiGongDanMuBan_add_Dialog();
                pad.RefitModel = rwm;
                pad.UserInfo = this.User;
                if (pad.ShowDialog() == DialogResult.OK)
                {
                    r.Cells[1].Value = pad.RefitModel.Name;
                    r.Cells[3].Value = pad.RefitModel.FinalUserId.Name;
                    r.Cells[4].Value = pad.RefitModel.Remarks;
                }
            }
            else if (e.ColumnIndex == 6)
            {
                try
                {
                    if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dispatchService.deleteEntity(rwm);
                    }
                }
                catch (Exception exc)
                {
                    SQLProvider.Service.CommonService.saveExceptionEntity(exc);
                }
                MessageBox.Show("删除成功！");
                reFreshAllControl();
            }
        }
    }
}
