using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HeTongGuanLi.Service;
using System.Collections;
using EntityClassLibrary;
namespace HeTongGuanLi
{
    public partial class MuBanSelect_Dialog : CommonControl.BaseForm
    {
        /// <summary>
        /// 
        /// 0代表改装模板 1代表套件模板
        /// </summary>
        private int isModifyOrSuite;

        public int IsModifyOrSuite
        {
            get { return isModifyOrSuite; }
            set { isModifyOrSuite = value; }
        }

        ContractService ss = new ContractService();
        private ModificationContract templateManager; 

        public ModificationContract TemplateManager
        {
            get { return templateManager; }
            set { templateManager = value; }
        }

        public MuBanSelect_Dialog()
        {
            InitializeComponent();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.Items.Contains(comboBox.Text))
            {
                comboBox.SelectedIndex = comboBox.Items.IndexOf(comboBox.Text);
            }

        }

        private void MuBanSelect_Dialog_Load(object sender, EventArgs e)
        {     
           if(this.isModifyOrSuite==0)
           {
                IList modelList = ss.GetAllGaiZhuangMuBan();
                if (modelList != null && modelList.Count > 0)
                {
                    comboBox.DataSource = modelList;
                    comboBox.DisplayMember = "TemplateName";
                    comboBox.ValueMember = "Itself";
                }
           }  
           else if(this.isModifyOrSuite==1)
           {
               IList modelList = ss.GetAllSuiteMuBan();
               if (modelList != null && modelList.Count > 0)
               {
                   comboBox.DataSource = modelList;
                   comboBox.DisplayMember = "TemplateName";
                   comboBox.ValueMember = "Itself";
               }
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            if(this.IsModifyOrSuite==0)
            {
              GaiZhuangHeTong_add_Dialog1 pad = new GaiZhuangHeTong_add_Dialog1();
            
              pad.UserInfo = this.UserInfo;
              if (comboBox.SelectedValue != null)
              {
                TemplateManager tm = (TemplateManager)comboBox.SelectedValue;
                //ModificationContract.ContractContents = tm.Contents;
                //pad.ModificationContract.ContractContents = tm.Contents;
                pad.TemplateManager = tm;
               }
           
              if (pad.ShowDialog() == DialogResult.OK)
              {
                 this.DialogResult = DialogResult.OK;
              }
              else
              {
                this.DialogResult = DialogResult.Cancel;
              }
            }
            else if(this.isModifyOrSuite==1)
            {
                TaoJianHeTong_add_Dialog tj = new TaoJianHeTong_add_Dialog();
                tj.UserInfo = this.UserInfo;
                if (comboBox.SelectedValue != null)
                {
                    TemplateManager tm = (TemplateManager)comboBox.SelectedValue;
                    //ModificationContract.ContractContents = tm.Contents;
                    //pad.ModificationContract.ContractContents = tm.Contents;
                    tj.TemplateManager = tm;
                }

                if (tj.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
