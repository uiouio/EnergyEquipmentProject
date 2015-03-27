using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnergyEquipmentProject
{
    public partial class MessageShow : Form
    {
        public MessageShow()
        {
            InitializeComponent();
        }

        private void MessageShow_Load(object sender, EventArgs e)
        {
            base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height);
        }

        #region 禁止窗体移动
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int HTCAPTION = 2;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
                return;
            base.WndProc(ref m);
        }
        #endregion


        public void AddMessage(string message)
        {
            Label l1 = new Label();
            l1.Font = new Font(new FontFamily("微软雅黑"), 15, FontStyle.Regular);
            l1.ForeColor = Color.DarkRed;
            l1.AutoSize = true;
            l1.Text = message;
            l1.Parent = flowLayoutPanel1;
            this.flowLayoutPanel1.Height = this.flowLayoutPanel1.Height + l1.Height;
            this.Height = this.Height + l1.Height;
            base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height);
        }

    }
}
