using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLProvider.Service;
using EntityClassLibrary;
using CommonControl;
using System.Reflection;
using CommonMethod;
using System.Collections;

namespace EnergyEquipmentProject
{
    public partial class MainForm : CommonControl.BaseForm
    {
        Service.UserInfoService userInfoService = new Service.UserInfoService();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            MainPage u = new MainPage();
            u.Name = "首页";
            commonTabControl1.AddTabPage(u);
            treeView2.Nodes.Clear();
            menuStrip1.Items.Clear();
            if (this.UserInfo.UserRole != null && this.UserInfo.UserRole.Count > 0)
            {
                foreach (UserRole r in this.UserInfo.UserRole)
                {
                    IList resourceList = userInfoService.getResourceByRoleId(r.Id);
                    TreeNode firstNode = new TreeNode();
                    firstNode.Text = r.RoleName;
                    treeView2.Nodes.Add(firstNode);
                    
                    Hashtable treeNodes = new Hashtable();
                    Hashtable menuNodes = new Hashtable();
                    if (resourceList != null && resourceList.Count > 0)
                    {
                        foreach (Resource resource in resourceList)
                        {
                            if (resource.ResourceLevel == 0)
                            {
                                TreeNode node = new TreeNode();
                                node.Text = resource.ResourceName;
                                if (resource.TypeFullName != null)
                                {
                                    string[] assembleAndClass = resource.TypeFullName.Split('|');
                                    node.Tag = getAssemblyByReflection(assembleAndClass[0], assembleAndClass[1], resource.ResourceName);
                                }
                                firstNode.Nodes.Add(node);
                                treeNodes.Add(resource.Id, node);
                                
                                ToolStripMenuItem firstMenu = new ToolStripMenuItem();
                                firstMenu.ForeColor = System.Drawing.Color.Black;
                                firstMenu.Text = resource.ResourceName;
                                menuStrip1.Items.Add(firstMenu);
                                menuNodes.Add(resource.Id, firstMenu);
                            }
                            else
                            {
                                TreeNode fatherNode = (TreeNode)treeNodes[resource.ParentId];
                                ToolStripMenuItem fatherMenu = (ToolStripMenuItem)menuNodes[resource.ParentId];
                                if (fatherNode != null)
                                {
                                    TreeNode node = new TreeNode();
                                    node.Text = resource.ResourceName;
                                    if (resource.TypeFullName != null)
                                    {
                                        string[] assembleAndClass = resource.TypeFullName.Split('|');
                                        node.Tag = getAssemblyByReflection(assembleAndClass[0], assembleAndClass[1], resource.ResourceName);
                                    }
                                    fatherNode.Nodes.Add(node);
                                    treeNodes.Add(resource.Id, node);
                                }
                                if (fatherMenu != null)
                                {
                                    ToolStripMenuItem firstMenu = new ToolStripMenuItem();
                                    firstMenu.Text = resource.ResourceName;
                                    firstMenu.ForeColor = System.Drawing.Color.Black;
                                    fatherMenu.DropDownItems.Add(firstMenu);
                                    menuNodes.Add(resource.Id, firstMenu);
                                }
                            }
                        }
                    }
                }
            }
            this.Opacity = 1;
            this.Visible = true;
            treeView2.Nodes[0].Expand();
            treeView2.Nodes[0].Tag = u;
        }

        private Object getAssemblyByReflection(string assemblyName, string objectName, string title)
        {
            try
            {
                Assembly ass = Assembly.LoadFrom(CommonMethod.CommonStaticParameter.BASE_PATH + assemblyName + ".dll");
                Type type = ass.GetType(assemblyName + "." + objectName);
                Object obj = Activator.CreateInstance(type);
                PropertyInfo propertyInfo = type.GetProperty("Name");
                propertyInfo.SetValue(obj, title, null);
                return obj;
            }
            catch(Exception e)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(e);
                return null;
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Tag != null)
                {
                    commonTabControl1.AddTabPage((CommonTabPage)e.Node.Tag);
                }
            }
            catch (Exception exc)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(exc);
            }
        }

        private void splitter1_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
            }
        }

    }
}
