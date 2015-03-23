using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow.Service;
using SQLProvider.Service;
 

namespace CustomManageWindow
{
    public partial class CustomReport_Add_Dialog : Form
    {
        /// <summary>
        /// 0为查看，1为新建
        /// </summary>
        public int dialogFlag = 0;

        DataBase_wp dataBase = new DataBase_wp();

        /// <summary>
        /// 车牌号
        /// </summary>
        public string plateNo = "";
        CustomerRecordService ss = new CustomerRecordService();
        CarTheLibrary s;

        IList CarMesg;

        private void showViewState()
        {
            this.Text = "查看客户回访记录";
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = false;
            label3.Text = Currentrecords.PhoneWorker;
            label4.Text = Currentrecords.PhoneTime.ToString();
            textBox1.Text = Currentrecords.CarInfo.Cbi.Name;
            textBox5.Text = Currentrecords.CarInfo.Cbi.ContactName;
            textBox6.Text = Currentrecords.CarInfo.Cbi.Telephone;
            textBox7.Text = Currentrecords.CarInfo.PlateNumber;
            textBox8.Text = Currentrecords.CarInfo.ModificationID.ContractNo;
            //textBox9.Text=Currentrecords.CarInfo
            textBox2.Text = Currentrecords.Question;
            textBox3.Text = Currentrecords.HandleOpinion;
            textBox4.Text = Currentrecords.Remark;
        }

        private void showNewState()
        {
            CarMesg =ss.SelectCarsRecord(plateNo, "", "", DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks);
            s=(CarTheLibrary)CarMesg[0];
            
            this.Text = "新建客户回访记录";
            //label3.Text = Currentrecords.PhoneWorker;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            label4.Text = DateTime.Today.ToString();
            textBox1.Text = s.RefitWork.CarInfo.Cbi.Name;
            textBox5.Text = s.RefitWork.CarInfo.Cbi.ContactName;
            textBox6.Text = s.RefitWork.CarInfo.Cbi.Telephone;
            textBox7.Text = s.RefitWork.CarInfo.PlateNumber;
            textBox8.Text = s.RefitWork.CarInfo.ModificationID.ContractNo;
            textBox9.Text = new DateTime(s.FinishTime).ToString();//出厂时间
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        
        private CustomerServiceRecord currentrecords;        
        public CustomerServiceRecord Currentrecords       
        {
            get { return currentrecords; }
            set { currentrecords = value; }
         }
        public CustomReport_Add_Dialog()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CustomReport_Add_Dialog_Load(object sender, EventArgs e)
        {
                       
            if (dialogFlag == 0)
                this.showViewState();//查看
            else this.showNewState();//新建
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string CarId = ss.getCarIdByPlateNum(textBox7.Text.Trim());

            if (dialogFlag == 0)
            {
                ss.updateCustomServiceRecord(this.textBox4.Text.Trim(),CarId);
                MessageBox.Show("保存成功");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else//保存新建记录
            {                
                ss.addCustomServiceRecord(CarId, DateTime.Now, label3.Text, textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
                MessageBox.Show("新建回访记录成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
                
        }
    }
}
