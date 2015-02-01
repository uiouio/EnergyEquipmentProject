using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;

namespace CommonWindow
{
    public partial class SelectUser : CommonControl.BaseForm
    {
        Service.UserInfoService userInfoService = new Service.UserInfoService();
        private IList selectUserList;

        public IList SelectUserList
        {
            get { return selectUserList; }
            set { selectUserList = value; }
        }

        private IList selectedUserList;

        public IList SelectedUserList
        {
            get { return selectedUserList; }
            set { selectedUserList = value; }
        }
        public SelectUser()
        {
            InitializeComponent();
        }

        private void refreshListView(ListView listView,IList userList)
        {
            listView.Items.Clear();
            if (userList != null && userList.Count > 0)
            {
                foreach (UserInfo u in userList)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = u.UserName;
                    item.Tag = u;
                    ListViewItem.ListViewSubItem dept = new ListViewItem.ListViewSubItem();
                    dept.Text = u.Dept != null ? u.Dept.DepartmentName : "";
                    ListViewItem.ListViewSubItem name = new ListViewItem.ListViewSubItem();
                    name.Text = u.Name;
                    item.SubItems.Add(name);
                    item.SubItems.Add(dept);
                    listView.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            UserInfo u = (UserInfo)item.Tag;
            item.Remove();
            listView2.Items.Add(item);
            selectUserList.Remove(u);
            selectedUserList.Add(u);
        }

        private void SelectUser_Load(object sender, EventArgs e)
        {
            if (selectUserList == null)
            {
                selectUserList = new List<UserInfo>();
            }
            if (SelectedUserList == null)
            {
                selectedUserList = new List<UserInfo>();
            }
            refreshListView(listView1, SelectUserList);
            refreshListView(listView2, SelectedUserList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView2.SelectedItems[0];
            UserInfo u = (UserInfo)item.Tag;
            item.Remove();
            listView1.Items.Add(item);
            selectedUserList.Remove(u);
            selectUserList.Add(u);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IList userList = userInfoService.getUserByUserNameAndUserNumAndDept(textBox1.Text.Trim(), textBox3.Text.Trim(), comboBox1.Text.Trim(),this.selectedUserList);
            selectUserList = userList;
            refreshListView(listView1, userList);
        }
    }
}
