using System;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CommonWindow;
using Iesi.Collections;
using Iesi.Collections.Generic;

namespace GongYiGuanLi
{
    public partial class PaiGongDanMuBan_add_Dialog : CommonControl.BaseForm
    {
        Service.DispatchService dispatchService = new Service.DispatchService();
        private ISet<RefitWorkModelGoods> currentGoods = new HashedSet<RefitWorkModelGoods>();
        private RefitWorkModel refitModel;
        public RefitWorkModel RefitModel
        {
            get { return refitModel; }
            set { refitModel = value; }
        }
        public PaiGongDanMuBan_add_Dialog()
        {
            InitializeComponent();
        }

        private void PaiGongDanMuBan_add_Dialog_Load(object sender, EventArgs e)
        {
            if (refitModel != null)
            {
                textBox7.Text = refitModel.Name;
                textBox1.Text = refitModel.Remarks;
                addItemToDataGridViewEntity(refitModel.RefitWorkGoodss);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (refitModel == null)
            {
                refitModel = new RefitWorkModel();
                refitModel.UserId = this.UserInfo;
            }
            if (dispatchService.checkIfHave(textBox1.Text.Trim(), refitModel.Id))
            {
                MessageBox.Show("已有次名称模板，请重新命名！");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            refitModel.FinalUserId = this.UserInfo;
            refitModel.Name = this.textBox7.Text.Trim();
            refitModel.Remarks = this.textBox1.Text.Trim();
            refitModel.RefitWorkGoodss = currentGoods;
            if (currentGoods != null && currentGoods.Count > 0)
            {
                foreach (RefitWorkModelGoods r in currentGoods)
                {
                    r.RefitWorkId = null;
                    dispatchService.SaveOrUpdateEntity(r);
                }
            }
            dispatchService.SaveOrUpdateEntity(refitModel);
            this.DialogResult = DialogResult.OK;
        }

        private void addItemToDataGridViewEntity(ISet<RefitWorkModelGoods> goodsList)
        {
            if (goodsList != null && goodsList.Count > 0)
            {
                int i = 0;
                foreach (RefitWorkModelGoods r in goodsList)
                {
                    i++;
                    commonDataGridView.Rows.Add(i.ToString(), r.GoodsBaseInfoId.GoodsName, r.GoodsBaseInfoId.Specifications, r.GoodsBaseInfoId.Unit, r.GoodsBaseInfoId.Material, r.Count, r.Remark, "删除");
                    currentGoods.Add(r);
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = r;
                }
            }
        }
        private void addItemToDataGridViewObject(IList goodsList)
        {
            if (goodsList != null && goodsList.Count > 0)
            {
                int i = this.commonDataGridView.Rows.Count;
                foreach (Object[] g in goodsList)
                {
                    i++;
                    commonDataGridView.Rows.Add(i.ToString(), g[1], g[2], g[3], g[4], g[9], "", "删除");
                    RefitWorkModelGoods rwg = new RefitWorkModelGoods();
                    rwg.Count = float.Parse(g[9].ToString());
                    GoodsBaseInfo gbi = new GoodsBaseInfo();
                    gbi.Id = Convert.ToInt64(g[7]);
                    rwg.GoodsBaseInfoId = gbi;
                    currentGoods.Add(rwg);
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = rwg;
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            SelectGoods selectGoods = new SelectGoods();
            selectGoods.IsChooseAll = 1;
            if (selectGoods.ShowDialog() == DialogResult.OK)
            {
                addItemToDataGridViewObject(selectGoods.ReturnIlist);
            }
        }

        private void commonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefitWorkModelGoods rwg = (RefitWorkModelGoods)commonDataGridView.Rows[e.RowIndex].Tag;
            if (e.ColumnIndex == 7)
            {
                currentGoods.Remove(rwg);
                commonDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void commonDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow r = commonDataGridView.Rows[e.RowIndex];
            RefitWorkModelGoods rwg = (RefitWorkModelGoods)r.Tag;
            if (e.ColumnIndex == 5)
            {
                rwg.Count =  Convert.ToInt32(r.Cells[5].Value);
            }

            if (e.ColumnIndex == 6)
            {
                rwg.Remark = r.Cells[6].Value.ToString();
            }
        }
    }
}
