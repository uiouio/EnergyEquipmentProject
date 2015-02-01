using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using SQLProvider.Service;

namespace SystemManageWindow
{
    public partial class AddWorkGroup : CommonControl.BaseForm
    {
        public AddWorkGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service.WorkGroupService OP_DS=new Service.WorkGroupService();
            WorkingGroup workGroup=new WorkingGroup();
            workGroup.WorkingGroupName = textBox1.Text;
            IList wkp = OP_DS.getWorkGroupByName(textBox1.Text);
            if (wkp != null)
            {
                MessageBox.Show("工作组名称已存在！");
            }
            else if (textBox1.Text == null)
            {
                MessageBox.Show("工作组名称不能为空！");
            }
            else
            {
                if (MessageBox.Show("确定要添加？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    OP_DS.SaveOrUpdateEntity(workGroup);

                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
