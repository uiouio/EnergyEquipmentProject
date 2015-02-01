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
    public partial class AddRole : CommonControl.BaseForm
    {
        private UserRole pRole;

        public UserRole PRole
        {
            get { return pRole; }
            set { pRole = value; }
        }
        Service.RoleService roleService = new Service.RoleService();
        public AddRole()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRole currentRole = new UserRole();
            currentRole.ParentId = pRole.Id;
            currentRole.RoleLevel = pRole.RoleLevel + 1;
            currentRole.RoleName = textBox1.Text.Trim();
            currentRole.RoleOrder = Convert.ToInt32(textBox3.Text.Trim());
            currentRole.State = (int)BaseEntity.stateEnum.Normal;
            currentRole.TimeStamp = DateTime.Now.Ticks;
            currentRole.Description = textBox6.Text.Trim();
            roleService.SaveOrUpdateEntity(currentRole);
            this.DialogResult = DialogResult.OK;
        }
    }
}
