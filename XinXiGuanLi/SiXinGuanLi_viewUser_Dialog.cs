using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;

namespace XinXiGuanLi
{
    public partial class SiXinGuanLi_viewUser_Dialog : CommonControl.BaseForm
    {
        private IList selectedUser;

        public IList SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; }
        }
        public SiXinGuanLi_viewUser_Dialog()
        {
            InitializeComponent();
        }

        private void SiXinGuanLi_viewUser_Dialog_Load(object sender, EventArgs e)
        {
            if (selectedUser != null && selectedUser.Count > 0)
            {
                foreach (UserInfo u in selectedUser)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = (listView1.Items.Count + 1).ToString();
                    ListViewItem.ListViewSubItem name = new ListViewItem.ListViewSubItem();
                    name.Text = u.Name;
                    ListViewItem.ListViewSubItem dept = new ListViewItem.ListViewSubItem();
                    dept.Text = u.Dept.DepartmentName;
                    item.SubItems.Add(name);
                    item.SubItems.Add(dept);
                    listView1.Items.Add(item);
                }
            }
        }
    }
}
