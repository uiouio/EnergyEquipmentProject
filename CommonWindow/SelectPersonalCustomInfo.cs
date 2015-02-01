using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using CommonWindow.Service;
namespace CommonWindow
{
    public partial class SelectPersonalCustomInfo : Form
    {
        IList currentcustoms;
        CustomInfoService ss = new CustomInfoService();
        private CustomBaseInfo customBaseInfo;

        public CustomBaseInfo CustomBaseInfo
        {
            get { return customBaseInfo; }
            set { customBaseInfo = value; }
        }
        CustomBaseInfo s = new CustomBaseInfo();
        public SelectPersonalCustomInfo()
        {
            InitializeComponent();
        }
        public void ShowSelectCustomGrid()
        {
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CustomBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView2.Rows.Add(i.ToString(), s.Name, s.IdentifyCardNo, s.Telephone, s.Address);
                    customBaseInfo = s;
                   
                    i++;
                }
            }
        }
 
        private void SelectPersonalCustomInfo_Load(object sender, EventArgs e)
        {

            ShowAllPersonalGrid();
        }
        public void ShowAllPersonalGrid()
        {
            currentcustoms = ss.GetAllPersonal();
            int i = 1;
            if (currentcustoms != null)
            {
                foreach (CustomBaseInfo s in currentcustoms)
                {
                    this.commonDataGridView2.Rows.Add(i.ToString(), s.Name, s.IdentifyCardNo, s.Telephone, s.Address);
                    i++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customBaseInfo = (CustomBaseInfo)currentcustoms[this.commonDataGridView2.CurrentCell.RowIndex];
            this.DialogResult = DialogResult.OK;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string cname = textBox2.Text;
            this.commonDataGridView2.Rows.Clear();

            currentcustoms = ss.SelectByNameAndCname(name, cname);
            ShowSelectCustomGrid();

        }

        private void commonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(commonDataGridView2.CurrentRow!=null)
            {
                customBaseInfo = (CustomBaseInfo)currentcustoms[this.commonDataGridView2.CurrentCell.RowIndex];
                    
            } 
        }
  
    }
}
 