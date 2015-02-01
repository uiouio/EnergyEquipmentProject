using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KuGuanXiTong
{
    public partial class UNDOChuKu_New_dialog : Form
    {
        public UNDOChuKu_New_dialog()
        {
            InitializeComponent();
        }

        private string tiaoMaCode;

        public string TiaoMaCode
        {
            get { return tiaoMaCode; }
            set { tiaoMaCode = value; }
        }

        private void ChuKu_New_dialog_Load(object sender, EventArgs e)
        {
            this.commonDataGridView2.Rows.Add("010209","LNG","","40*40","瓶","1","300","","","");
        }


        private void commonDataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (e.Control is TextBox && this.commonDataGridView2.CurrentCell.OwningColumn.Name == "Column2")
            //{
            //   // e.Control.MouseClick += new MouseEventHandler(Control_MouseClick);
            //    e.Control.MouseDoubleClick += new MouseEventHandler(Control_MouseDoubleClick);
            //    e.Control.Text = TiaoMaCode;
            //    this.commonDataGridView2.Rows[this.commonDataGridView2.CurrentCell.RowIndex].Cells[this.commonDataGridView2.CurrentCell.ColumnIndex].Value = TiaoMaCode;
            //}


        }

        void Control_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UNDOKuCun_SaoMa saoma = new UNDOKuCun_SaoMa();
            saoma.ShowDialog();
            TextBox tb = sender as TextBox;
            tb.Text = saoma.TheText;
            TiaoMaCode = saoma.TheText;
        }

        void Control_MouseClick(object sender, MouseEventArgs e)
        {
            UNDOKuCun_SaoMa saoma = new UNDOKuCun_SaoMa();
            saoma.ShowDialog();
            TextBox tb = sender as TextBox;
            tb.Text = saoma.TheText;
            TiaoMaCode = saoma.TheText;
        }
    }
}
