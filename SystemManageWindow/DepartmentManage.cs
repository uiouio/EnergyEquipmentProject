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
    public partial class DepartmentManage : CommonControl.CommonTabPage
    {
        Service.DepartmentService departmentService = new Service.DepartmentService();
        private Department currentDepartment;
        public Department CurrentDepartment
        {
            get { return currentDepartment; }
            set { currentDepartment = value; }
        }
        public DepartmentManage()
        {
            InitializeComponent();
        }
        private void refreshTree(IList deptList)
        {
            treeView1.Nodes.Clear();
            TreeNode pNode = new TreeNode();
            pNode.Text = "新兴能源";
            Department pDepartment = new Department();
            pDepartment.Id = 0;
            pDepartment.DepartmentName = "新兴能源";
            pDepartment.DeptLevel = -1;
            pNode.Tag = pDepartment;
            treeView1.Nodes.Add(pNode);
            if (deptList != null && deptList.Count > 0)
            {
                Hashtable treeNodes = new Hashtable();
                foreach (Department d in deptList)
                {
                    if (d.DeptLevel == 0)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = d.DepartmentName;
                        node.Tag = d;
                        pNode.Nodes.Add(node);
                        treeNodes.Add(d.Id, node);
                    }
                    else
                    {
                        TreeNode fatherNode = (TreeNode)treeNodes[d.ParentId];
                        if (fatherNode != null)
                        {
                            TreeNode node = new TreeNode();
                            node.Text = d.DepartmentName;
                            node.Tag = d;

                            fatherNode.Nodes.Add(node);
                            treeNodes.Add(d.Id, node);
                        }
                    }
                }
            }
            treeView1.Nodes[0].Expand();
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode treeNode = e.Node;
            Department dept = (Department)treeNode.Tag;
            currentDepartment = dept;
            if (dept != null)
            {
                textBox1.Text = dept.DepartmentName;
                textBox3.Text = dept.DeptOrder.ToString();
                textBox6.Text = dept.Description;
                Department pDept = new Department();
                if (dept.ParentId != 0)
                {
                    pDept.Id = dept.ParentId;
                    pDept.DeptLevel = treeNode.Level - 2;
                    pDept.DepartmentName = treeNode.Parent.Text;
                }
                else
                {
                    pDept.Id = 0;
                    pDept.DepartmentName = "顶级";
                    pDept.DeptLevel = -1;
                }
                textBox2.Text = pDept.Id + "-" + pDept.DepartmentName;
                textBox2.Tag = pDept;
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

        private void DepartmentManage_Load(object sender, EventArgs e)
        {
            refreshTree(departmentService.getAllDepts());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Department pDept = (Department)textBox2.Tag;
            currentDepartment.ParentId = pDept.Id;
            currentDepartment.DeptLevel = pDept.DeptLevel + 1;
            currentDepartment.DepartmentName = textBox1.Text.Trim();
            currentDepartment.DeptOrder = Convert.ToInt32(textBox3.Text.Trim());
            currentDepartment.State = (int)BaseEntity.stateEnum.Normal;
            currentDepartment.TimeStamp = DateTime.Now.Ticks;
            currentDepartment.Description = textBox6.Text.Trim();
            departmentService.SaveOrUpdateEntity(currentDepartment);
            refreshTree(departmentService.getAllDepts());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentDepartment == null)
            {
                MessageBox.Show("请选择父角色！");
                return;
            }
            AddDepartment addDept = new AddDepartment();
            addDept.PDept = currentDepartment;
            if (addDept.ShowDialog() == DialogResult.OK)
            {
                refreshTree(departmentService.getAllDepts());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentDepartment != null)
            {
                if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (departmentService.checkDeptDelete(currentDepartment.Id))
                    {
                        try
                        {
                            departmentService.deleteEntity(currentDepartment);
                        }
                        catch (Exception a)
                        {
                            SQLProvider.Service.CommonService.saveExceptionEntity(a);
                        }
                        finally
                        {
                            currentDepartment = null;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox6.Text = "";
                            textBox2.Tag = null;
                            MessageBox.Show("删除成功！");
                            refreshTree(departmentService.getAllDepts());
                        }
                    }
                    else
                    {
                        MessageBox.Show("该资源具有子资源,若要删除请先删除子资源！");
                    }
                }
            }
        }
    }
}
