using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;

namespace SystemManageWindow
{
    public partial class ChangeWorkGroup : CommonControl.BaseForm
    {
        public UserInfo userInfo;
        public ChangeWorkGroup()
        {
            InitializeComponent();
        }
        private void updateCombox()
        {
            Service.WorkGroupService OP_WG = new Service.WorkGroupService();
            System.Collections.IList workgroupList = OP_WG.getAllWorkGroup();
            if (workgroupList.Count != 0)
            {
                this.comboBox1.DataSource = workgroupList;
                this.comboBox1.DisplayMember = "workingGroupName";
                this.comboBox1.ValueMember = "Itself";
            }

        }
        private void ChangeWorkGroup_Load(object sender, EventArgs e)
        {
            label2.Text = "姓名：" + userInfo.Name;
            updateCombox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定更改？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WorkingGroup workGroup = new WorkingGroup();
                Service.WorkGroupService workGroupService = new Service.WorkGroupService();
                workGroup = (WorkingGroup)comboBox1.SelectedValue;
                workGroup.UserInfo.Add(userInfo);
                workGroupService.SaveOrUpdateEntity(workGroup);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
