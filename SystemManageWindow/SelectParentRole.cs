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
    public partial class SelectParentRole : CommonControl.BaseForm
    {
        Service.RoleService roleService = new Service.RoleService();
        private UserRole pRole;

        public UserRole PRole
        {
            get { return pRole; }
            set { pRole = value; }
        }

        public SelectParentRole()
        {
            InitializeComponent();
        }

        private void refreshTree(IList resourceList)
        {
            treeView1.Nodes.Clear();
            TreeNode pNode = new TreeNode();
            pNode.Text = "顶级";
            Resource pResource = new Resource();
            pResource.Id = 0;
            pResource.ResourceName = "顶级";
            pResource.ResourceLevel = -1;
            pNode.Tag = pResource;
            treeView1.Nodes.Add(pNode);
            if (resourceList != null && resourceList.Count > 0)
            {
                Hashtable treeNodes = new Hashtable();
                foreach (UserRole r in resourceList)
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

        private void button1_Click(object sender, EventArgs e)
        {
            PRole = (UserRole)treeView1.SelectedNode.Tag;
            this.DialogResult = DialogResult.OK;
        }

        private void SelectParentRole_Load(object sender, EventArgs e)
        {
            refreshTree(roleService.getAllRoles());
        }
    }
}
