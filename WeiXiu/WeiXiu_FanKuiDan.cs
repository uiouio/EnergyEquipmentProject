using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using WeiXiu.SQL;
using CommonWindow;
using System.Collections;
using Iesi.Collections.Generic;
using System.Runtime.InteropServices;


namespace WeiXiu
{
    public partial class WeiXiu_FanKuiDan : CommonControl.BaseForm

    {
        OP_WX oo = new OP_WX();

        WeiXiuFanKuiDan wx;
        /// <summary>
        /// 维修单
        /// </summary>
        public WeiXiuFanKuiDan Wx
        {
            get { return wx; }
            set { wx = value; }
        }

        private bool isNew;
        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        ISet<ServiceGoods> Currentss;
      
        public WeiXiu_FanKuiDan()
        {
            InitializeComponent();
            
        }



        private void button3_Click(object sender, EventArgs e)
        {
            CommonMethod.DocumentPrint print = new CommonMethod.DocumentPrint();
            print.DocPrint(panel3);
        }
       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            
            wx = new WeiXiuFanKuiDan();
            wx.Name = this.textBox1.Text;
            wx.LicensePlateNumber = this.textBox15.Text;
            wx.Models = this.textBox3.Text;
            wx.FeedbackTime = dateTimePicker2.Value.Ticks;
            wx.FeedbackForm = this.textBox2.Text;
            wx.TelephoneNumber = this.textBox4.Text;
            if (radioButton1.Checked)
            {
                wx.Payment = (int)BaseEntity.YesNo.Yes;
                if (textBox14.Text == "")
                {
                    wx.Money = 0;
                }
                else
                {
                    wx.Money = float.Parse(this.textBox14.Text);
                }
            }
            else
            {
                wx.Money = (int)BaseEntity.YesNo.No;
            }
            wx.ServicePerson = this.textBox6.Text;
            wx.QualityProblems = this.textBox7.Text;
            wx.Remarks = this.textBox5.Text;
            DateTime now = DateTime.Now;
            textBox8.Text = "WX" + now.Year + (now.Month.ToString().Length == 1 ? ("0" + now.Month) : now.Month.ToString()) + (now.Day.ToString().Length == 1 ? ("0" + now.Day) : now.Day.ToString()) + DateTime.Now.ToLongTimeString().Replace(":", "");
            wx.ServiceNumber = this.textBox8.Text;

           // wx.ServiceGoods=Currentss;

            wx = oo.SaveOrUpdateEntity(wx) as WeiXiuFanKuiDan;

 
            if(this.commonDataGridView1.Rows.Count>0)
            {
                int count = this.commonDataGridView1.Rows.Count;
                for (int i = 0; i < count;i++)
                {
                  Object[] obj =   (this.commonDataGridView1.Rows[i].Tag as Object[]);
                  ServiceGoods sergoo = new ServiceGoods();
                  sergoo.WeiXiuFanKuiDanId = wx;
                    GoodsBaseInfo gg = new GoodsBaseInfo ();
                    gg.Id = Convert.ToInt64(obj[7]);
                    sergoo.GoodsBaseInfoId = gg;
                    sergoo.Number =  Convert.ToInt32 (obj[9]);
                    oo.SaveOrUpdateEntity(sergoo);
                }
            }

            //foreach (ServiceGoods rwg in Currentss)
            //{
               
                //oo.SaveOrUpdateEntity(rwg);
           // }
            //oo.SaveOrUpdateEntity(wx);

            //weixiugoods.WeiXiuFanKuiDanId = tt;
            // GoodsBaseInfo gg = new  ();
            // gg.Id = (this.com.tag as object[])[7];
            //weixiugoods.GoodsBaseInfoId = gg;
            if (MessageBox.Show("是否确认？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;

            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WeiXiu_FanKuiDan_Load(object sender, EventArgs e)
        {
            if (wx != null)
            {

                this.textBox1.Text = wx.Name;
                textBox15.Text = wx.LicensePlateNumber;
                textBox3.Text = wx.Models;
                textBox2.Text = wx.FeedbackForm;
                textBox4.Text = wx.TelephoneNumber;
                textBox6.Text = wx.ServicePerson;
                textBox7.Text = wx.QualityProblems;
                textBox5.Text = wx.Remarks;
                textBox8.Text = wx.ServiceNumber;
               
                if (wx.Payment == 1)
                {
                    this.radioButton1.Checked = true;
                    textBox14.Text = wx.Money.ToString();
                }
                else if (wx.Payment == 0)
                {
                    this.radioButton2.Checked = true;
                }

                IList i = oo.QueryWeiXiuFGoods(wx.Id);
                
                if( i!= null && i.Count>0)
                {
                    foreach (ServiceGoods o in i)
                    {
                        this.commonDataGridView1.Rows.Add(o.GoodsBaseInfoId.GoodsName, o.GoodsBaseInfoId.Specifications, o.GoodsBaseInfoId.Material, o.GoodsBaseInfoId.Unit, o.Number);

                    }
                }
        DateTime newdatetime = new DateTime(wx.FeedbackTime);
                dateTimePicker2.Value = newdatetime;
            }
            
        }

        public void SetAllTextEnableUnActive()
        {
            this.textBox1.Enabled = false;
            textBox15.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
            textBox7.Enabled = false;
            textBox5.Enabled = false;
            panel1.Enabled = false;
            panel2.Enabled = false;
            dateTimePicker2.Enabled = false;
            commonDataGridView1.Enabled = false;
            button5.Enabled = false;
            button1.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {

            SelectGoods sg = new SelectGoods();
            sg.ShowDialog();
            IList goodslist = sg.ReturnIlist;
            if (goodslist != null)
            {
                foreach (object[] o in goodslist)
                {
                    this.commonDataGridView1.Rows.Add(o[2].ToString(), o[3].ToString(), o[4].ToString(), o[5].ToString(), Convert.ToInt32(o[9]));
                    this.commonDataGridView1.Rows[this.commonDataGridView1.Rows.Count - 1].Tag = o;
                }
            }
        }     
          
    }
}
