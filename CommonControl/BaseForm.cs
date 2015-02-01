using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;

namespace CommonControl
{
    public partial class BaseForm : Form
    {
        private UserInfo userInfo;

        public UserInfo UserInfo
        {
            get { return userInfo; }
            set { userInfo = value; }
        }
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
