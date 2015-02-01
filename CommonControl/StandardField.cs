using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonControl
{
    public partial class StandardField : UserControl
    {
        public StandardField()
        {
            InitializeComponent();
        }

        private void StandardField_Leave(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void StandardField_ChangeUICues(object sender, UICuesEventArgs e)
        {
            MessageBox.Show("sd");
        }

        private void StandardField_MouseCaptureChanged(object sender, EventArgs e)
        {
            //ComboBox comboBox = (ComboBox)sender;

            //// 


            //if (Mouse.Captured != comboBox)
            //{
            //    if (e.OriginalSource == comboBox)
            //    {
            //        // If capture is null or it's not below the combobox, close. 
            //        // More workaround for task 22022 -- check if it's a descendant (following Logical links too)
            //        if (Mouse.Captured == null || !MenuBase.IsDescendant(comboBox, Mouse.Captured as DependencyObject))
            //        {
            //            comboBox.Close();
            //        }
            //    }
            //    else
            //    {
            //        if (MenuBase.IsDescendant(comboBox, e.OriginalSource as DependencyObject))
            //        {
            //            // Take capture if one of our children gave up capture (by closing their drop down) 
            //            if (comboBox.IsDropDownOpen && Mouse.Captured == null && MS.Win32.SafeNativeMethods.GetCapture() == IntPtr.Zero)
            //            {
            //                Mouse.Capture(comboBox, CaptureMode.SubTree);
            //                e.Handled = true;
            //            }
            //        }
            //        else
            //        {
            //            comboBox.Close();
            //        }
            //    }
            //} 
        }
    }
}
