using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Reflection;
using System.Collections;

namespace CommonControl
{
    public partial class MatterPanel : UserControl
    {
        public MatterPanel()
        {
            InitializeComponent();
        }

        public void refresh(IList matterList)
        {
            flowLayoutPanel1.Controls.Clear();
            if (matterList != null && matterList.Count > 0)
            {
                foreach (Matter matter in matterList)
                {
                    addItem(matter);
                }
            }
        }

        public void addItem(Matter matter)
        {
            Panel panel = new Panel();
            panel.Height = 35;
            panel.Width = 400;
            panel.Parent = flowLayoutPanel1;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(19, 17);
            pictureBox.BackColor = System.Drawing.Color.Transparent;
            pictureBox.Location = new Point(17, 10);
            pictureBox.BackgroundImage = CommonControl.Properties.Resources.dot;
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.AutoSize = true;
            linkLabel.Location = new Point(36,10);
            linkLabel.BackColor = System.Drawing.Color.Transparent;
            linkLabel.Font = new Font("宋体", (float)10.5);
            linkLabel.Text = matter.MatterContent + "(" + matter.Number + ")";
            linkLabel.Tag = matter.TypeFullName;
            linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);
            pictureBox.Parent = panel;
            linkLabel.Parent = panel;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            if (ll.Tag != null)
            {
                DaiBanShiXiang_Main_Dialog dmd = new DaiBanShiXiang_Main_Dialog();
                string[] assAndObj = ll.Tag.ToString().Split('|');
                CommonTabPage ctp = (CommonTabPage)getAssemblyByReflection(assAndObj[0], assAndObj[1]);
                ctp.Parent = dmd;
                dmd.ShowDialog();
            }
        }

        private Object getAssemblyByReflection(string assemblyName, string objectName)
        {
            try
            {
                Assembly ass = Assembly.LoadFrom(CommonMethod.CommonStaticParameter.BASE_PATH + assemblyName + ".dll");
                Type type = ass.GetType(assemblyName + "." + objectName);
                Object obj = Activator.CreateInstance(type);
                PropertyInfo propertyInfo_User = type.GetProperty("User");
                CommonTabPage ctp = (CommonTabPage)this.Parent.Parent;
                propertyInfo_User.SetValue(obj, ctp.User, null);
                return obj;
            }
            catch (Exception e)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(e);
                return null;
            }

        }
    }
}
