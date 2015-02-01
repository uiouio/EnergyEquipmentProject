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

namespace GongYiGuanLi
{
    public partial class MuBanInfo_Input_Dialog : CommonControl.BaseForm
    {
        Service.DispatchService dispatchService = new Service.DispatchService();
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
        public MuBanInfo_Input_Dialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dispatchService.checkIfHave(textBox1.Text.Trim(),0))
            {
                MessageBox.Show("已有次名称模板，请重新命名！");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            modelName = textBox1.Text.Trim();
            modelRemark = textBox2.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}
