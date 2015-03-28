using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CommonControl;
using System.Reflection;
using System.IO;
using CommonMethod;

namespace CommonWindow
{
    public partial class TitlePage : CommonTabPage
    {
        Service.UserInfoService userInfoService = new Service.UserInfoService();
        public TitlePage()
        {
            InitializeComponent();
        }

        private Object getAssemblyByReflection(string assemblyName, string objectName, string title, Resource resource)
        {
            try
            {
                Assembly ass = Assembly.LoadFrom(CommonMethod.CommonStaticParameter.BASE_PATH + assemblyName + ".dll");
                Type type = ass.GetType(assemblyName + "." + objectName);
                Object obj = Activator.CreateInstance(type);
                PropertyInfo propertyInfo_Name = type.GetProperty("Name");
                propertyInfo_Name.SetValue(obj, title, null);
                PropertyInfo propertyInfo_Tag = type.GetProperty("Tag");
                propertyInfo_Tag.SetValue(obj, resource, null);
                PropertyInfo propertyInfo_User = type.GetProperty("User");
                propertyInfo_User.SetValue(obj, this.User, null);
                return obj;
            }
            catch (Exception e)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(e);
                return null;
            }

        }

        private void TitlePage_Load(object sender, EventArgs e)
        {
            //this.Visible = false;
            Resource pResource = (Resource)this.Tag;
            IList resourceList = userInfoService.getAllChildResourcePID(pResource.Id);
            Hashtable pageNodesId = new Hashtable();
            if (resourceList != null && resourceList.Count > 0)
            {
                CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                foreach (Resource r in resourceList)
                {
                    PageNode node = new PageNode();
                    node.PResource = r;
                    if (r.PicturePath != null)
                    {
                        string tempPath = CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE + "\\" + r.PicturePath;
                        if (File.Exists(tempPath))
                        {
                            node.NonSelectBackGroundImage = new Bitmap(tempPath);
                        }
                        else
                        {
                            fileUpDown.Download(CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE, r.PicturePath, CommonStaticParameter.TITLE_RSOURCE);
                            if (File.Exists(tempPath))
                            {
                                node.NonSelectBackGroundImage = new Bitmap(tempPath);
                            }
                        }
                    }
                    if (r.SelectedPicturePath != null)
                    {
                        string tempPath1 = CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE + "\\" + r.SelectedPicturePath;
                        if (File.Exists(tempPath1))
                        {
                            node.SelectBackGroundImage = new Bitmap(tempPath1);
                        }
                        else
                        {
                            fileUpDown.Download(CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.TITLE_RSOURCE, r.SelectedPicturePath, CommonStaticParameter.TITLE_RSOURCE);
                            if (File.Exists(tempPath1))
                            {
                                node.SelectBackGroundImage = new Bitmap(tempPath1);
                            }
                        }
                    }
                    node.NodeText = r.ResourceName;
                    node.OnControlClick += new EventHandler(TitleNodeClick);
                    if (r.TypeFullName != null)
                    {
                        string[] assembleAndClass = r.TypeFullName.Split('|');
                        node.Tag = getAssemblyByReflection(assembleAndClass[0], assembleAndClass[1], r.ResourceName,r);
                    }
                    node.Parent = this.flowLayoutPanel1;
                    pageNodesId.Add(r.Id,node);
                }
            }

            IList allowResourceList = userInfoService.getChildResourceByRoleIdAndPID(pResource.Id, this.User.UserRole);
            if (allowResourceList != null && allowResourceList.Count > 0)
            {
                foreach (long r in allowResourceList)
                {
                    if (pageNodesId.Contains(r))
                    {
                        PageNode node = (PageNode)pageNodesId[r];
                        node.NonSelectBackGroundImage = node.SelectBackGroundImage;
                        node.AllowClick = true;
                    }
                }
            }
            //this.Visible = true;
        }

        private void TitleNodeClick(object sender, EventArgs e)
        {
            try
            {

                PictureBox pic = (PictureBox)sender;
                pic.Cursor = Cursors.WaitCursor;
                CommonTabControl commonTabControl1 = (CommonTabControl)pic.Parent.Parent.Parent.Parent.Parent;
                commonTabControl1.AddTabPage((CommonTabPage)pic.Parent.Tag);
                pic.Cursor = Cursors.Hand; 


            }
            catch (Exception exc)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(exc);
            }
        }


    }
}
