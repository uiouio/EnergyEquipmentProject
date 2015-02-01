using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;

namespace CommonControl
{
    public partial class CommonTabPage : UserControl
    {
        public virtual void reFreshAllControl()
        {
        }
        private UserInfo user;

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
        public CommonTabPage()
        {
            InitializeComponent();
        }
    }
}
