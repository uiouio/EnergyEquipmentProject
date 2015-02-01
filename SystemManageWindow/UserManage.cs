using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using CommonWindow;

namespace SystemManageWindow
{
    public partial class UserManage : CommonControl.CommonTabPage
    {
        Service.DepartmentService deptService = new Service.DepartmentService();
        Service.RoleService roleService = new Service.RoleService();
        private IList selectedUserList;
        public IList SelectedUserList
        {
            get { return selectedUserList; }
            set { selectedUserList = value; }
        }
        private UserRole currentRole;
        public UserRole CurrentRole
        {
            get { return currentRole; }
            set { currentRole = value; }
        }
        private IList selectedDeptUserList;
        public IList SelectedDeptUserList
        {
            get { return selectedDeptUserList; }
            set { selectedDeptUserList = value; }
        }
        private Department currentDept;
        public Department CurrentDept
        {
            get { return currentDept; }
            set { currentDept = value; }
        }
        public UserManage()
        {
            InitializeComponent();
        }
        private void UserManage_Load(object sender, EventArgs e)
        {
            refreshTree(roleService.getAllRoles());
            refreshDeptTree(deptService.getAllDepts());          
        }
        #region 人员角色管理
        private void refreshTree(IList roleList)
        {
            treeView1.Nodes.Clear();
            TreeNode pNode = new TreeNode();
            pNode.Text = "顶级";
            UserRole pRole = new UserRole();
            pRole.Id = 0;
            pRole.RoleName = "顶级";
            pRole.RoleLevel = -1;
            pNode.Tag = pRole;
            treeView1.Nodes.Add(pNode);
            if (roleList != null && roleList.Count > 0)
            {
                Hashtable treeNodes = new Hashtable();
                foreach (UserRole r in roleList)
                {
                    if (r.RoleLevel == 0)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = r.RoleName;
                        node.Tag = r;
                        pNode.Nodes.Add(node);
                        treeNodes.Add(r.Id, node);
                    }
                    else
                    {
                        TreeNode fatherNode = (TreeNode)treeNodes[r.ParentId];
                        if (fatherNode != null)
                        {
                            TreeNode node = new TreeNode();
                            node.Text = r.RoleName;
                            node.Tag = r;

                            fatherNode.Nodes.Add(node);
                            treeNodes.Add(r.Id, node);
                        }
                    }
                }
            }
            treeView1.Nodes[0].Expand();
        }     
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode treeNode = e.Node;
            UserRole role = (UserRole)treeNode.Tag;
            currentRole = role;
            selectedUserList = roleService.getUsersByRoleId(currentRole.Id);
            groupBox1.Text = "人员角色管理-" + role.RoleName;
            refreshListView(selectedUserList);
        }
        private void refreshListView(IList userList)
        {
            listView1.Items.Clear();
            if (userList != null && userList.Count > 0)
            {
                foreach (UserInfo u in userList)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = u;
                    ListViewItem.ListViewSubItem userName = new ListViewItem.ListViewSubItem();
                    userName.Text = u.UserName;
                    ListViewItem.ListViewSubItem dept = new ListViewItem.ListViewSubItem();
                    dept.Text = u.Dept!=null?u.Dept.DepartmentName:"";
                    ListViewItem.ListViewSubItem name = new ListViewItem.ListViewSubItem();
                    name.Text = u.Name;
                    ListViewItem.ListViewSubItem sfzh = new ListViewItem.ListViewSubItem();
                    sfzh.Text = u.IdentifyCardNo;
                    item.SubItems.Add(userName);
                    item.SubItems.Add(name);
                    item.SubItems.Add(dept);
                    item.SubItems.Add(sfzh);
                    listView1.Items.Add(item);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SelectUser selectUser = new SelectUser();
            selectUser.SelectedUserList = new List<UserInfo>();
            selectUser.SelectUserList = roleService.getSelectUserBySelectedId(this.selectedUserList);
            if (selectUser.ShowDialog() == DialogResult.OK)
            {
                if (selectUser.SelectedUserList != null && selectUser.SelectedUserList.Count > 0)
                {
                    foreach (UserInfo u in selectUser.SelectedUserList)
                    {
                        u.UserRole.Add(currentRole);
                        roleService.SaveOrUpdateEntity(u);
                        this.selectedUserList.Add(u);
                    }
                }
                refreshListView(this.selectedUserList);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems != null && listView1.CheckedItems.Count > 0)
            {
                while(listView1.CheckedItems!=null&&listView1.CheckedItems.Count>0)
                {
                    UserInfo u = (UserInfo)listView1.CheckedItems[0].Tag;
                    for (int i = 0; i < u.UserRole.Count; i++)
                    {
                        if (u.UserRole[i].Id == currentRole.Id)
                        {
                            u.UserRole.Remove(u.UserRole[i]);
                        }
                    }
                    roleService.SaveOrUpdateEntity(u);
                    this.selectedUserList.Remove(u);
                    listView1.CheckedItems[0].Remove();
                }
            }
            else
            {
                MessageBox.Show("请选择要移除的人员！");
            }
        }
        #endregion

        #region 人员部门管理
        private void refreshDeptTree(IList roleList)
        {
            treeView2.Nodes.Clear();
            TreeNode pNode = new TreeNode();
            pNode.Text = "顶级";
            Department pRole = new Department();
            pRole.Id = 0;
            pRole.DepartmentName = "顶级";
            pRole.DeptLevel = -1;
            pNode.Tag = pRole;
            treeView2.Nodes.Add(pNode);
            if (roleList != null && roleList.Count > 0)
            {
                Hashtable treeNodes = new Hashtable();
                foreach (Department r in roleList)
                {
                    if (r.DeptLevel == 0)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = r.DepartmentName;
                        node.Tag = r;
                        pNode.Nodes.Add(node);
                        treeNodes.Add(r.Id, node);
                    }
                    else
                    {
                        TreeNode fatherNode = (TreeNode)treeNodes[r.ParentId];
                        if (fatherNode != null)
                        {
                            TreeNode node = new TreeNode();
                            node.Text = r.DepartmentName;
                            node.Tag = r;

                            fatherNode.Nodes.Add(node);
                            treeNodes.Add(r.Id, node);
                        }
                    }
                }
            }
            treeView2.Nodes[0].Expand();
        }
        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode treeNode = e.Node;
            Department role = (Department)treeNode.Tag;
            currentDept = role;
            selectedDeptUserList = deptService.getUsersByDeptId(currentDept.Id);
            groupBox2.Text = "人员部门管理-" + role.DepartmentName;
            refreshDeptListView(selectedDeptUserList);
        }
        private void refreshDeptListView(IList userList)
        {
            listView2.Items.Clear();
            if (userList != null && userList.Count > 0)
            {
                foreach (UserInfo u in userList)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = u;
                    ListViewItem.ListViewSubItem userName = new ListViewItem.ListViewSubItem();
                    userName.Text = u.UserName;
                    ListViewItem.ListViewSubItem dept = new ListViewItem.ListViewSubItem();
                    dept.Text = u.Dept != null ? u.Dept.DepartmentName : "";
                    ListViewItem.ListViewSubItem name = new ListViewItem.ListViewSubItem();
                    name.Text = u.Name;
                    ListViewItem.ListViewSubItem sfzh = new ListViewItem.ListViewSubItem();
                    sfzh.Text = u.IdentifyCardNo;
                    item.SubItems.Add(userName);
                    item.SubItems.Add(name);
                    item.SubItems.Add(dept);
                    item.SubItems.Add(sfzh);
                    listView2.Items.Add(item);
                }
            }
        }
        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            EidtUserInfo eui = new EidtUserInfo();
            eui.entrance = 1;
            eui.UserInfo = (UserInfo)this.listView2.SelectedItems[0].Tag;
            eui.ShowDialog();
            refreshDeptListView(deptService.getUsersByDeptId(eui.UserInfo.Dept.Id));

        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            EidtUserInfo eui = new EidtUserInfo();
            eui.entrance = 0;
            //eui.UserInfo = this.User;
            eui.ShowDialog();
        }

    }
}
