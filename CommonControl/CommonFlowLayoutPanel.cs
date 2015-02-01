using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonControl
{
    public partial class CommonFlowLayoutPanel : FlowLayoutPanel
    {
        public CommonFlowLayoutPanel()
        {
            InitializeComponent();
        }

        public CommonFlowLayoutPanel(IContainer container)
        {
            InitializeComponent();
        }
    }
}
