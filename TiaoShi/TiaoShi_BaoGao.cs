using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using TiaoShi.SQL;
using System.Collections;

namespace TiaoShi
{
    public partial class TiaoShi_BaoGao :CommonControl.BaseForm
    {
       

        public TiaoShi_BaoGao()
        {
            InitializeComponent();
            
        }

        IList Currentss;
        OP_TS OP_TS = new OP_TS();
        private TiaoShiBaoGao tiaoShiBaoGao;
        public TiaoShiBaoGao TiaoShiBaoGao
        {
            get { return tiaoShiBaoGao; }
            set { tiaoShiBaoGao = value; }
        }

        private void TiaoShi_BaoGao_Load(object sender, EventArgs e)
        {
            ShowTiaoShiBaoGaoChaKan();
            if (tiaoShiBaoGao.Status == (int)EntityClassLibrary.TiaoShiBaoGao.savecheck.check)
            {
                AllEnable();
                load();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan.CarInfo.Cbi.Name= this.textBox3.Text;
            TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan.CarInfo.VehicleType=this.textBox1.Text ;
            TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan.CarInfo.PlateNumber=this.textBox6.Text;
            TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan.CarInfo.Cbi.Unit=this.textBox4.Text ;
             tiaoShiBaoGao.DebugPerson = this.textBox22.Text;
            if (textBox12.Text == "")
            {
                tiaoShiBaoGao.SingleFirewoodOilyFees = 0;
            }
            else
            {
                tiaoShiBaoGao.SingleFirewoodOilyFees = float.Parse(this.textBox12.Text);
            }
            if (textBox13.Text == "")
            {
                tiaoShiBaoGao.SingleFirewoodOilyTotalFees = 0;
            }
            else
            {
                tiaoShiBaoGao.SingleFirewoodOilyTotalFees = float.Parse(this.textBox13.Text);
            }
            if (textBox14.Text == "")
            {
                tiaoShiBaoGao.SingleFirewoodOilyAverageFees = 0;
            }
            else
            {
                tiaoShiBaoGao.SingleFirewoodOilyAverageFees = float.Parse(this.textBox14.Text);
            }
            if (textBox19.Text == "")
            {
                tiaoShiBaoGao.OilAndGasGasFees = 0;
            }
            else
            {
                tiaoShiBaoGao.OilAndGasGasFees = float.Parse(this.textBox19.Text);
            }
            if (textBox15.Text == "")
            {
                tiaoShiBaoGao.OilAndGasOilFees = 0;
            }
            else
            {
                tiaoShiBaoGao.OilAndGasOilFees = float.Parse(this.textBox15.Text);
            }
            if (textBox16.Text == "")
            {
                tiaoShiBaoGao.OilAndGasTotalFees = 0;
            }
            else
            {
                tiaoShiBaoGao.OilAndGasTotalFees = float.Parse(this.textBox16.Text);
            }
            if (textBox17.Text == "")
            {
                tiaoShiBaoGao.OilAndGasAverageFees = 0;
            }
            else
            {
                tiaoShiBaoGao.OilAndGasAverageFees = float.Parse(this.textBox17.Text);
            }
            if (textBox18.Text == "")
            {
                tiaoShiBaoGao.OilAndGasSave = 0;
            }
            else
            {
                tiaoShiBaoGao.OilAndGasSave = float.Parse(this.textBox18.Text);
            }
            if (textBox7.Text == "")
            {
                tiaoShiBaoGao.Dieselfuel = 0;
            }
            else
            {
                tiaoShiBaoGao.Dieselfuel = float.Parse(this.textBox7.Text);
            }
            if (textBox8.Text == "")
            {
                tiaoShiBaoGao.DieselPrices = 0;
            }
            else
            {
                tiaoShiBaoGao.DieselPrices = float.Parse(this.textBox8.Text);
            }
            if (textBox9.Text == "")
            {
                tiaoShiBaoGao.CNGPrices = 0;
            }
            else
            {
                tiaoShiBaoGao.CNGPrices = float.Parse(this.textBox9.Text);
            }
            tiaoShiBaoGao.Dynamic = this.textBox10.Text;
            tiaoShiBaoGao.Issue = this.textBox11.Text;
            if (textBox2.Text == "")
            {
                tiaoShiBaoGao.Mileage = 0;
            }
            else
            {
                tiaoShiBaoGao.Mileage = float.Parse(this.textBox2.Text);
            }
            if (textBox20.Text == "")
            {
                tiaoShiBaoGao.SingleDiesekm = 0;
            }
            else
            {
                tiaoShiBaoGao.SingleDiesekm = float.Parse(this.textBox20.Text);
            }
            tiaoShiBaoGao.Time = this.dateTimePicker1.Value.Ticks;
            if (textBox21.Text == "")
            {
                tiaoShiBaoGao.OilAndGaskm = 0;
            }
            else
            {
                tiaoShiBaoGao.OilAndGaskm = float.Parse(this.textBox21.Text);
            }

            tiaoShiBaoGao.DrivingDirections = this.textBox5.Text;

           

            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                
                tiaoShiBaoGao.Status = (int)EntityClassLibrary.TiaoShiBaoGao.savecheck.check;
                OP_TS.SaveBao(tiaoShiBaoGao);
                

                CheRuKuInfo cheRuKuInfo=new CheRuKuInfo();
                RefitWork rf = new RefitWork();
                rf = tiaoShiBaoGao.LiuZhuanBiao.PaiGongDan;

                cheRuKuInfo.TiaoShiBaoGao = tiaoShiBaoGao;
                cheRuKuInfo.WorkingGroup = rf.WorkingGroupId;
                cheRuKuInfo.RefitWork =rf;
                OP_TS.SaveOrUpdateEntity(cheRuKuInfo);
                //OP_TS.SaveOrUpdateEntity(tiaoShiBaoGao);

                this.DialogResult = DialogResult.OK;
                

            }
           
        }

        public void ShowTiaoShiBaoGaoChaKan()
        {
            Currentss = OP_TS.GetTiaoShiBaoGaoChaKan();
            if (Currentss != null)
            {

                this.textBox3.Text = TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan.CarInfo.Cbi.Name;
                this.textBox1.Text = TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan.CarInfo.VehicleType;
                this.textBox6.Text = TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan.CarInfo.PlateNumber;
                this.textBox4.Text = TiaoShiBaoGao.LiuZhuanBiao.PaiGongDan.CarInfo.Cbi.Unit;
            }
        }

        public void AllEnable()
        {
            this.groupBox1.Enabled = false;
            this.button1.Enabled = false;
        }

        public void load()
        {
            textBox5.Text = tiaoShiBaoGao.DrivingDirections;
            textBox2.Text = tiaoShiBaoGao.Mileage.ToString();
            textBox7.Text = tiaoShiBaoGao.Dieselfuel.ToString();
            textBox8.Text = tiaoShiBaoGao.DieselPrices.ToString();
            textBox9.Text = tiaoShiBaoGao.CNGPrices.ToString();
            textBox19.Text = tiaoShiBaoGao.OilAndGasGasFees.ToString();
            textBox20.Text = tiaoShiBaoGao.SingleDiesekm.ToString();
            textBox21.Text = tiaoShiBaoGao.OilAndGaskm.ToString();
            textBox15.Text = tiaoShiBaoGao.OilAndGasOilFees.ToString();
            textBox12.Text = tiaoShiBaoGao.SingleFirewoodOilyFees.ToString();
            textBox13.Text = tiaoShiBaoGao.SingleFirewoodOilyTotalFees.ToString();
            textBox16.Text = tiaoShiBaoGao.OilAndGasTotalFees.ToString();
            textBox14.Text = tiaoShiBaoGao.SingleFirewoodOilyAverageFees.ToString();
            textBox17.Text = tiaoShiBaoGao.OilAndGasAverageFees.ToString();
            textBox18.Text = tiaoShiBaoGao.OilAndGasSave.ToString();
            textBox10.Text = tiaoShiBaoGao.Dynamic;
            textBox11.Text = tiaoShiBaoGao.Issue;
            this.dateTimePicker1.Value = new DateTime(tiaoShiBaoGao.Time);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CommonMethod.DocumentPrint print = new CommonMethod.DocumentPrint();
            print.DocPrint(panel1);
        }


        ///由于测试的提交
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
