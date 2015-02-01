using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CheChuKu.SQL;
using EntityClassLibrary;

namespace CheChuKu
{
    public partial class CheChuKuDan : CommonControl.BaseForm
    {
       
        IList Currentss;
        OP_CheChuKu OP_CheChuKu = new OP_CheChuKu();

        RefitWork refitWork;
        /// <summary>
        /// 接受传来的值
        /// </summary>
        public RefitWork RefitWork
        {
            get { return refitWork; }
            set { refitWork = value; }
        }


        CarTheLibrary sendcarTheLibrary;
        public CarTheLibrary SendCarTheLibrary
        {
            get { return sendcarTheLibrary; }
            set { sendcarTheLibrary = value; }
        }
        public CheChuKuDan()
        {
            InitializeComponent();
            RefitWork = new RefitWork();
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SendCarTheLibrary = new CarTheLibrary();

                SendCarTheLibrary.RefitWork = RefitWork;
                SendCarTheLibrary.FinishTime = this.dateTimePicker1.Value.Ticks;

               SendCarTheLibrary =   OP_CheChuKu.SaveOrUpdateEntity(SendCarTheLibrary) as CarTheLibrary; 

                this.DialogResult = DialogResult.OK;
            }          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheChuKuDan_Load(object sender, EventArgs e)
        {
            //if (Currentss != null)
            //{
            //    this.textBox1.Text = carTheLibrary.RefitWork.CarInfo.PlateNumber;
            //    this.textBox2.Text = carTheLibrary.RefitWork.CarInfo.Cbi.Name;
            //    this.textBox3.Text = carTheLibrary.RefitWork.CarInfo.VehicleType;
            //}
            if(RefitWork.CarInfo != null)
            {
                this.textBox1.Text = RefitWork.CarInfo.PlateNumber;
                this.textBox2.Text = RefitWork.CarInfo.Cbi.Name;
                this.textBox3.Text = RefitWork.CarInfo.VehicleType;

            
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CommonMethod.DocumentPrint print = new CommonMethod.DocumentPrint();
            print.DocPrint(panel1);
        }
    }
}
