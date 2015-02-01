using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CustomManageWindow.Service;

namespace HeTongGuanLi
{
    public partial class MuBanGuanLi_add_Dialog1 :CommonControl.BaseForm
    {
        /// <summary>
        /// 是用来展示数据还是输入数据，1用来输入数据，0用来展示数据
        /// </summary>
        private int isShowOrInput;

        public int IsShowOrInput
        {
            get { return isShowOrInput; }
            set { isShowOrInput = value; }
        }



        public MuBanGuanLi_add_Dialog1()
        {
            InitializeComponent();
        }

        private TemplateManager templateManager;

        public  TemplateManager TemplateManager
        {
            get { return templateManager; }
            set { templateManager = value; }
        }

        CustomService ss = new CustomService();

        TemplateManager tm = new TemplateManager();

        private void button1_Click(object sender, EventArgs e)
        { 
           if (IsShowOrInput == 1)
          {
            tm.TemplateName = textBox1.Text;
            if (this.comboBox1.Text == "改装类合同")
            {
                tm.TemplateType = (int)TemplateManager.type.gz;

            }
            else if (this.comboBox1.Text == "套件类合同")
            {
                tm.TemplateType = (int)TemplateManager.type.tj;
            }
            tm.Remark = textBox5.Text;

            tm.Contents = htmlEditor1.BodyInnerHTML;

            tm.UserID = this.UserInfo;

            tm.Time = this.dateTimePicker1.Value.Ticks;

            ss.SaveOrUpdateEntity(tm);

            MessageBox.Show("添加成功");
            this.DialogResult = DialogResult.OK;
           
           }
            else if (IsShowOrInput == 0)
            {

              if (this.comboBox1.Text == "改装类合同")
              {
                  TemplateManager.TemplateType=(int)TemplateManager.type.gz;
              }
              else if (this.comboBox1.Text == "套件类合同")
              {
                  TemplateManager.TemplateType=(int)TemplateManager.type.tj;
              }
              TemplateManager.TemplateName = this.textBox1.Text;

              TemplateManager.Time =  this.dateTimePicker1.Value.Ticks ;

              TemplateManager.Remark = this.textBox5.Text;

              TemplateManager.Contents = this.htmlEditor1.BodyInnerHTML;
              TemplateManager.UserID = this.UserInfo;
              ss.SaveOrUpdateEntity(TemplateManager);
              this.DialogResult = DialogResult.OK;

            }
      
        }

        private void MuBanGuanLi_add_Dialog1_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            if (IsShowOrInput == 0)
            {
                this.Text = "模板详细信息";
                if (TemplateManager != null)
                {

                    this.textBox1.Text = TemplateManager.TemplateName;

                    if(TemplateManager.TemplateType==(int)TemplateManager.type.gz)
                   {
                    
                        this.comboBox1.Text = TemplateManager.MuBanType[TemplateManager.TemplateType];
                    }
                    else
                        if(TemplateManager.TemplateType==(int)TemplateManager.type.tj)
                    {
                         this.comboBox1.Text = TemplateManager.MuBanType[TemplateManager.TemplateType];
                    }

                    long ticks  =  TemplateManager.Time;

                    DateTime dt = new DateTime(ticks);

                    this.dateTimePicker1.Value = dt;

                    this.textBox5.Text = TemplateManager.Remark;

                    this.htmlEditor1.BodyInnerHTML = TemplateManager.Contents;


                }
            }
            if (IsShowOrInput == 1)
            {
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            }
        }
    }
}
