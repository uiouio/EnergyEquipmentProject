using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonMethod;

namespace XinXiGuanLi
{
    public partial class SiXinGuanLi_view_Dialog : CommonControl.BaseForm
    {
        private Letter letter;

        public Letter Letter
        {
            get { return letter; }
            set { letter = value; }
        }
        public SiXinGuanLi_view_Dialog()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                fileUpDown.Download(folderBrowserDialog1.SelectedPath, letter.FilePath, CommonStaticParameter.LETTER_RSOURCE);
            }
        }

        private void SiXinGuanLi_view_Dialog_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Text = "查看信件-" + letter.LetterTitle;
            this.htmlEditor1.BodyInnerHTML = letter.LetterContent;
            this.linkLabel1.Text = letter.FileName;
            this.label_name.Text = letter.SenderUser.UserName;
            this.label_time.Text = new DateTime(letter.SenderTime).ToShortDateString();
        }
    }
}
