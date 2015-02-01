using System;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using Iesi.Collections.Generic;

namespace GongYiGuanLi
{
    public partial class PaiGongDan_select_Dialog : CommonControl.BaseForm
    {
        Service.DispatchService dispatchService = new Service.DispatchService();
        private RefitWork refiWork;

        public RefitWork RefiWork
        {
            get { return refiWork; }
            set { refiWork = value; }
        }
        public PaiGongDan_select_Dialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            PaiGongDan_add_Dialog pad = new PaiGongDan_add_Dialog();
            if (comboBox.SelectedValue != null)
            {
                RefitWorkModel rwm = (RefitWorkModel)comboBox.SelectedValue;
                ISet<RefitWorkGoods> goodsList = new HashedSet<RefitWorkGoods>();
                foreach (RefitWorkModelGoods rwmg in rwm.RefitWorkGoodss)
                {
                    RefitWorkGoods rwg = new RefitWorkGoods();
                    rwg.GoodsBaseInfoId = rwmg.GoodsBaseInfoId;
                    rwg.Count = rwmg.Count;
                    rwg.AddType = (int)RefitWorkGoods.IfAdd.NotAdd;
                    rwg.RefitWorkId = refiWork;
                    rwg.Remark = rwmg.Remark;
                    rwg.ReceiveType = (int)RefitWorkGoods.ReceiveTypeEnum.NotReceive;
                    goodsList.Add(rwg);
                }
                refiWork.RefitWorkGoodss = goodsList;
            }
            pad.RefitWork = refiWork;
            pad.UserInfo = this.UserInfo;
            pad.IsNew = true;
            if (pad.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void PaiGongDan_select_Dialog_Load(object sender, EventArgs e)
        {
            IList modelList = dispatchService.getAllModel();
            if (modelList != null && modelList.Count > 0)
            {
                comboBox.DataSource = modelList;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Itself";
            }
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            if (comboBox.Items.Contains(comboBox.Text))
            {
                comboBox.SelectedIndex = comboBox.Items.IndexOf(comboBox.Text);
            }
        }
    }
}
