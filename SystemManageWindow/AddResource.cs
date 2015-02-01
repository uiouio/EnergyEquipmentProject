using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;

namespace SystemManageWindow
{
    public partial class AddResource : CommonControl.BaseForm
    {
        Service.ResourceService resourceService = new Service.ResourceService();
        private Resource pResource;

        public Resource PResource
        {
            get { return pResource; }
            set { pResource = value; }
        }

        public AddResource()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Resource currentResource = new Resource();
            currentResource.ResourceName = textBox1.Text.Trim();
            currentResource.ResourceOrder = Convert.ToInt32(textBox3.Text.Trim());
            if (textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                currentResource.TypeFullName = textBox4.Text.Trim() + "|" + textBox5.Text.Trim();
            }
            currentResource.ParentId = pResource.Id;
            currentResource.ResourceLevel = pResource.ResourceLevel + 1;
            currentResource.IsDisplay = 0;
            currentResource.Description = textBox6.Text.Trim();
            currentResource.State = (int)BaseEntity.stateEnum.Normal;
            currentResource.TimeStamp = DateTime.Now.Ticks;
            resourceService.SaveOrUpdateEntity(currentResource);
            this.DialogResult = DialogResult.OK;
        }
    }
}
