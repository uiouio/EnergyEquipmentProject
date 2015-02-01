using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonControl
{
    public class CommonDataGridView:System.Windows.Forms.DataGridView
    {
    
        public CommonDataGridView()
        {
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ReadOnly = false;
            this.BackgroundColor = System.Drawing.Color.White;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToResizeColumns = true;
            this.AllowUserToResizeRows = false;
            this.RowHeadersVisible = false;
            this.AllowUserToAddRows = false;
            this.MultiSelect = false;
            this.BackgroundColor = System.Drawing.Color.White;
            this.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige;
        }

        public void addCheckBox()
        {
            System.Windows.Forms.DataGridViewCheckBoxColumn checkBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Columns.Insert(0, checkBoxColumn1);
            for (int i = 1; i < this.Columns.Count; i++)
            {
                this.Columns[i].ReadOnly = true;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CommonDataGridView
            // 
            this.RowTemplate.Height = 23;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }        
    }
}
