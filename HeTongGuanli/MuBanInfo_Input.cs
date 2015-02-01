using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomManageWindow.Service;

namespace HeTongGuanLi
{
    public partial class MuBanInfo_Input : CommonControl.BaseForm
    {
        Service.ContractService contractService = new Service.ContractService();
        private string modelName;
        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }
        private string modelRemark;
        public string ModelRemark
        {
            get { return modelRemark; }
            set { modelRemark = value; }
        }
        public MuBanInfo_Input()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (contractService.checkIfExist(textBox1.Text.Trim(), 0))
            {
                MessageBox.Show("已有次名称模板，请重新命名！");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            modelName = textBox1.Text.Trim();
            modelRemark = textBox2.Text.Trim();
            MessageBox.Show("保存成功");
            this.DialogResult = DialogResult.OK;
        }
    }
}
