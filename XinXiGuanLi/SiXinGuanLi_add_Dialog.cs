using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonWindow;
using SQLProvider.Service;
using EntityClassLibrary;
using CommonMethod;
using System.Collections;

namespace XinXiGuanLi
{
    public partial class SiXinGuanLi_add_Dialog : CommonControl.BaseForm
    {
        BaseService baseService = new BaseService();
        private Letter letter;

        public Letter Letter
        {
            get { return letter; }
            set { letter = value; }
        }
        private IList selectedUser;

        public IList SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; }
        }
        public SiXinGuanLi_add_Dialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectUser su = new SelectUser();
            su.SelectUserList = selectedUser;
            if (su.ShowDialog() == DialogResult.OK)
            {
                selectedUser = su.SelectedUserList;
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_title.Text.Length > 25)
                {
                    MessageBox.Show("标题字数过多！");
                    textBox_title.Focus();
                }
                Letter l = new Letter();
                l.LetterTitle = textBox_title.Text.Trim();
                l.LetterContent = htmlEditor1.BodyInnerHTML;
                l.SenderTime = DateTime.Now.Ticks;
                l.SenderUser = this.UserInfo;
                l.Users = (IList<UserInfo>)selectedUser;
                if (textBox_filepath.Tag != null)
                {
                    l.FileName = textBox_filepath.Text.Trim();
                    CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                    String filePath = fileUpDown.Upload(textBox_filepath.Tag.ToString(), CommonStaticParameter.LETTER_RSOURCE);
                    l.FilePath = filePath.Substring(filePath.LastIndexOf('/') + 1);
                }
                baseService.SaveOrUpdateEntity(l);
                MessageBox.Show("保存成功！");
                Letter = l;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception exc)
            {
                SQLProvider.Service.CommonService.saveExceptionEntity(exc);
            }
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_filepath.Text = openFileDialog1.SafeFileName.Substring(0, openFileDialog1.SafeFileName.LastIndexOf('.'));
                textBox_filepath.Tag = openFileDialog1.FileName;
            }
        }

        private void SiXinGuanLi_add_Dialog_Load(object sender, EventArgs e)
        {
            //this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
    }
}
