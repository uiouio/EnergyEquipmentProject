using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;

namespace SystemManageWindow
{
    public partial class AuthResource : CommonControl.BaseForm
    {
        Service.RoleService authservice = new Service.RoleService();
        private IList currentRoleList;

        public IList CurrentRoleList
        {
            get { return currentRoleList; }
            set { currentRoleList = value; }
        }
        public AuthResource()
        {
            InitializeComponent();
        }

        private void refreshTree(TreeView treeView,IList roleList)
        {
            treeView.Nodes.Clear();
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
                        treeView.Nodes.Add(node);
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
        }

        private void refreshListView(ListView listView, IList roleList)
        {
            listView.Items.Clear();
            if (roleList != null && roleList.Count > 0)
            {
                foreach (UserRole r in roleList)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = r.RoleName;
                    item.Tag = r;
                    listView.Items.Add(item);
                }
            }
        }

        private void AuthResource_Load(object sender, EventArgs e)
        {
            refreshTree(treeView1, authservice.getAllRoles());
            refreshListView(listView1, currentRoleList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                return;
            }
            UserRole r = (UserRole)treeView1.SelectedNode.Tag;
            foreach (UserRole role in currentRoleList)
            {
                if (role.Id == r.Id)
                    return;
            }
            ListViewItem item = new ListViewItem();
            item.Text = r.RoleName;
            item.Tag = r;
            listView1.Items.Add(item);
            CurrentRoleList.Add(r);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems==null)
            {
                return;
            }
            while (listView1.SelectedItems.Count>0)
            {
                UserRole r = (UserRole)listView1.SelectedItems[0].Tag;
                currentRoleList.Remove(r);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
