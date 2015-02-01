using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using CommonMethod;
using System.IO;

namespace SystemManageWindow
{
    public partial class ResourceManage : CommonControl.CommonTabPage
    {
        Service.ResourceService resourceService = new Service.ResourceService();
        private Resource currentResource;

        public Resource CurrentResource
        {
            get { return currentResource; }
            set { currentResource = value; }
        }

        private IList currentResourceList;

        public IList CurrentResourceList
        {
            get { return currentResourceList; }
            set { currentResourceList = value; }
        }

        public ResourceManage()
        {
            InitializeComponent();
        }

        private void ResourceManage_Load(object sender, EventArgs e)
        {
            refreshTree(resourceService.getAllResources());
        }

        private void refreshTree(IList resourceList)
        {
            treeView1.Nodes.Clear();
            currentResourceList = resourceList;
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
                foreach (Resource r in resourceList)
                {
                    if (r.ResourceLevel == 0)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = r.ResourceName;
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
                            node.Text = r.ResourceName;
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
            Resource resource = (Resource)treeNode.Tag;
            currentResource = resource;
            if (resource != null)
            {
                textBox1.Text = resource.ResourceName;
                textBox3.Text = resource.ResourceOrder.ToString();
                if (resource.TypeFullName != null && resource.TypeFullName.Contains("|"))
                {
                    textBox4.Text = resource.TypeFullName.Split('|')[0];
                    textBox5.Text = resource.TypeFullName.Split('|')[1];
                }
                else
                {
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                textBox6.Text = resource.Description;
                Resource pResource = new Resource();
                if (resource.ParentId != 0)
                {
                    pResource.Id = resource.ParentId;
                    pResource.ResourceLevel = treeNode.Level - 2;
                    pResource.ResourceName = treeNode.Parent.Text;
                }
                else
                {
                    pResource.Id = 0;
                    pResource.ResourceName = "顶级";
                    pResource.ResourceLevel = -1;
                }
                textBox2.Text = pResource.Id + "-" + pResource.ResourceName;
                textBox2.Tag = pResource;

                string tempPath = CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE + "\\" + resource.PicturePath;
                CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                fileUpDown.Download(CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE, resource.PicturePath, CommonStaticParameter.TITLE_RSOURCE);
                if (File.Exists(tempPath))
                {
                    pictureBox1.Image = new Bitmap(tempPath);
                    pictureBox1.Tag = resource.PicturePath;
                }
                else
                {
                    pictureBox1.Image = null;
                    pictureBox1.Tag = resource.PicturePath;
                }

                string tempPath1 = CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE + "\\" + resource.SelectedPicturePath;
                fileUpDown.Download(CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE, resource.SelectedPicturePath, CommonStaticParameter.TITLE_RSOURCE);
                if (File.Exists(tempPath1))
                {
                    pictureBox2.Image = new Bitmap(tempPath1);
                    pictureBox2.Tag = resource.SelectedPicturePath;
                }
                else
                {
                    pictureBox2.Image = null;
                    pictureBox2.Tag = resource.PicturePath;
                }
            }
            if (e.Node == treeView1.Nodes[0])
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                linkLabel1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                linkLabel1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentResource.ResourceName = textBox1.Text.Trim();
            currentResource.ResourceOrder = Convert.ToInt32(textBox3.Text.Trim());
            if (textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                currentResource.TypeFullName = textBox4.Text.Trim() + "|" + textBox5.Text.Trim();
            }
            Resource pResource = (Resource)textBox2.Tag;
            currentResource.ParentId = pResource.Id;
            currentResource.ResourceLevel = pResource.ResourceLevel + 1;
            currentResource.IsDisplay = 0;
            currentResource.Description = textBox6.Text.Trim();
            currentResource.PicturePath = pictureBox1.Tag==null?null:pictureBox1.Tag.ToString();
            currentResource.SelectedPicturePath = pictureBox2.Tag == null ? null : pictureBox2.Tag.ToString();
            currentResource.State = (int)BaseEntity.stateEnum.Normal;
            currentResource.TimeStamp = DateTime.Now.Ticks;
            resourceService.SaveOrUpdateEntity(currentResource);
            refreshTree(resourceService.getAllResources());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentResource != null)
            {
                if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (resourceService.checkResourceDelete(currentResource.Id))
                    {
                        try
                        {
                            currentResource.UserRoles = null;
                            resourceService.SaveOrUpdateEntity(currentResource);
                            resourceService.deleteEntity(currentResource);
                        }
                        catch (Exception a)
                        {
                            SQLProvider.Service.CommonService.saveExceptionEntity(a);
                        }
                        finally
                        {
                            currentResource = null;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox2.Tag = null;
                            MessageBox.Show("删除成功！");
                            refreshTree(resourceService.getAllResources());
                        }
                    }
                    else
                    {
                        MessageBox.Show("该资源具有子资源,若要删除请先删除子资源！");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentResource == null)
            {
                MessageBox.Show("请选择父资源！");
                return;
            }
            AddResource addResource = new AddResource();
            addResource.PResource = currentResource;
            if (addResource.ShowDialog() == DialogResult.OK)
            {
                refreshTree(resourceService.getAllResources());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AuthResource authResource = new AuthResource();
            if (currentResource.UserRoles == null)
            {
                currentResource.UserRoles = new List<UserRole>();
            }
            else
            {
                currentResource.UserRoles = (IList<UserRole>)resourceService.getAllRolesByResourceId(currentResource.Id);
            }
            authResource.CurrentRoleList = (IList)currentResource.UserRoles;
            if (authResource.ShowDialog() == DialogResult.OK)
            {
                currentResource.UserRoles = (IList<UserRole>)authResource.CurrentRoleList;
                resourceService.SaveOrUpdateEntity(currentResource);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectParentResource spr = new SelectParentResource();
            if (spr.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = spr.PResource.Id + "-" + spr.PResource.ResourceName;
                textBox2.Tag = spr.PResource;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                    String s = fileUpDown.Upload(openFileDialog1.FileName, CommonStaticParameter.TITLE_RSOURCE);
                    Bitmap bitMap = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = bitMap;
                    pictureBox1.Tag = s.Substring(s.LastIndexOf('/')+1);
                }
                catch(Exception exc)
                {
                    SQLProvider.Service.CommonService.saveExceptionEntity(exc);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                    String s = fileUpDown.Upload(openFileDialog1.FileName, CommonStaticParameter.TITLE_RSOURCE);
                    Bitmap bitMap = new Bitmap(openFileDialog1.FileName);
                    pictureBox2.Image = bitMap;
                    pictureBox2.Tag = s.Substring(s.LastIndexOf('/') + 1);
                }
                catch (Exception exc)
                {
                    SQLProvider.Service.CommonService.saveExceptionEntity(exc);
                }
            }
        }
    }
}
