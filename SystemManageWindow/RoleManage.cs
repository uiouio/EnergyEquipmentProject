using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;

namespace SystemManageWindow
{
    public partial class RoleManage : CommonControl.CommonTabPage
    {
        Service.RoleService roleService = new Service.RoleService();
        private UserRole currentRole;

        public UserRole CurrentRole
        {
            get { return currentRole; }
            set { currentRole = value; }
        }
        public RoleManage()
        {
            InitializeComponent();
        }

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

        private void RoleManage_Load(object sender, EventArgs e)
        {
            refreshTree(roleService.getAllRoles());
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode treeNode = e.Node;
            UserRole role = (UserRole)treeNode.Tag;
            currentRole = role;
            if (role != null)
            {
                textBox1.Text = role.RoleName;
                textBox3.Text = role.RoleOrder.ToString();
                textBox6.Text = role.Description;
                UserRole pRole = new UserRole();
                if (role.ParentId != 0)
                {
                    pRole.Id = role.ParentId;
                    pRole.RoleLevel = treeNode.Level - 2;
                    pRole.RoleName = treeNode.Parent.Text;

                }
                else
                {
                    pRole.Id = 0;
                    pRole.RoleName = "顶级";
                    pRole.RoleLevel = -1;
                }
                textBox2.Text = pRole.Id + "-" + pRole.RoleName;
                textBox2.Tag = pRole;
            }
            if (e.Node == treeView1.Nodes[0])
            {
                button1.Enabled = false;
                button4.Enabled = false;
                linkLabel1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button4.Enabled = true;
                linkLabel1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentRole == null)
            {
                MessageBox.Show("请选择父角色！");
                return;
            }
            AddRole addRole = new AddRole();
            addRole.PRole = currentRole;
            if (addRole.ShowDialog() == DialogResult.OK)
            {
                refreshTree(roleService.getAllRoles());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UserRole pRole = (UserRole)textBox2.Tag;
            currentRole.ParentId = pRole.Id;
            currentRole.RoleLevel = pRole.RoleLevel + 1;
            currentRole.RoleName = textBox1.Text.Trim();
            currentRole.RoleOrder = Convert.ToInt32(textBox3.Text.Trim());
            currentRole.State = (int)BaseEntity.stateEnum.Normal;
            currentRole.TimeStamp = DateTime.Now.Ticks;
            currentRole.Description = textBox6.Text.Trim();
            roleService.SaveOrUpdateEntity(currentRole);
            refreshTree(roleService.getAllRoles());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentRole != null)
            {
                if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (roleService.checkRoleDelete(currentRole.Id))
                    {
                        try
                        {
                            currentRole.UserResource = null;
                            roleService.SaveOrUpdateEntity(currentRole);
                            roleService.deleteEntity(currentRole);
                        }
                        catch(Exception a)
                        {
                            SQLProvider.Service.CommonService.saveExceptionEntity(a);
                        }
                        finally
                        {
                            currentRole = null;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox6.Text = "";
                            textBox2.Tag = null;
                            MessageBox.Show("删除成功！");
                            refreshTree(roleService.getAllRoles());
                        }
                    }
                    else
                    {
                        MessageBox.Show("该资源具有子资源,若要删除请先删除子资源！");
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectParentRole spr = new SelectParentRole();
            if (spr.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = spr.PRole.Id + "-" + spr.PRole.RoleName;
                textBox2.Tag = spr.PRole;
            }
        }
    }
}
