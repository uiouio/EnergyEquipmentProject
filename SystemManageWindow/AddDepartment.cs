using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;

namespace SystemManageWindow
{
    public partial class AddDepartment : CommonControl.BaseForm
    {
        Service.DepartmentService departmentService = new Service.DepartmentService();
        private Department pDept;

        public Department PDept
        {
            get { return pDept; }
            set { pDept = value; }
        }
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Department currentDepartment = new Department();
            currentDepartment.ParentId = pDept.Id;
            currentDepartment.DeptLevel = pDept.DeptLevel + 1;
            currentDepartment.DepartmentName = textBox1.Text.Trim();
            currentDepartment.DeptOrder = Convert.ToInt32(textBox3.Text.Trim());
            currentDepartment.State = (int)BaseEntity.stateEnum.Normal;
            currentDepartment.TimeStamp = DateTime.Now.Ticks;
            currentDepartment.Description = textBox6.Text.Trim();
            departmentService.SaveOrUpdateEntity(currentDepartment);
            this.DialogResult = DialogResult.OK;
        }
    }
}
