using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkProcedure.SQL;
using EntityClassLibrary;


namespace WorkProcedure
{
    public partial class LiuZhuanBiaoView_Detail : CommonControl.BaseForm
    {
        OP_LZB oplaz = new OP_LZB();
        public string ChePaiHao;

        LiuZhuanBiao receiveLiuZhuanDate;
        /// <summary>
        /// 用来接受传入数据
        /// </summary>
        public LiuZhuanBiao ReceiveLiuZhuanDate
        {
            get { return receiveLiuZhuanDate; }
            set { receiveLiuZhuanDate = value; }
        }

        private LiuZhuanBiaoView_Detail liuZhuanBiaoView_Detail;
        /// <summary>
        /// 流转表的传值
        /// </summary>
        public LiuZhuanBiaoView_Detail LiuZhuanBiaoView_Detail1
        {
            get { return liuZhuanBiaoView_Detail; }
            set { liuZhuanBiaoView_Detail = value; }
        }

        private int isLiuZhuanBiao;
        /// <summary>
        /// 是否已经填写流转表
        /// </summary>
        public int IsLiuZhuanBiao
        {
            get { return isLiuZhuanBiao; }
            set { isLiuZhuanBiao = value; }
        }

        
        public LiuZhuanBiaoView_Detail()
        {
            InitializeComponent();
      
        }


        private void LiuZhuanBiaoView_Detail_Load(object sender, EventArgs e)
        {
            if (ReceiveLiuZhuanDate != null)
            {
                if (receiveLiuZhuanDate.ScratchSaveState == (int)LiuZhuanBiao.ScratchSave.Save)
                {
                    GetAllEnable();
                }
                this.textBox43.Text = receiveLiuZhuanDate.Factory;
                if (this.textBox42.Text != "")
                {
                    this.textBox42.Text = receiveLiuZhuanDate.EngingPower.ToString();
                }
                //else
                //{
                //    receiveLiuZhuanDate.EngingPower = 0;
                //}
                this.textBox45.Text = ReceiveLiuZhuanDate.PaiGongDan.CarInfo.PlateNumber;
                this.textBox44.Text = ReceiveLiuZhuanDate.PaiGongDan.CarInfo.EngineIdentificationNumber;
                this.textBox46.Text = ReceiveLiuZhuanDate.PaiGongDan.CarInfo.FuelConsumption.ToString();
                this.textBox39.Text = receiveLiuZhuanDate.WiringInstaller;
                this.textBox1.Text = receiveLiuZhuanDate.WiringHead;
                this.textBox7.Text = receiveLiuZhuanDate.WiringRemark;
                this.textBox49.Text = receiveLiuZhuanDate.ElectricECUInstaller;
                this.textBox8.Text = receiveLiuZhuanDate.ElectricECUHead;
                this.textBox9.Text = receiveLiuZhuanDate.ElectricECURemark;
                this.textBox48.Text = receiveLiuZhuanDate.LimitOilInstaller;
                this.textBox10.Text = receiveLiuZhuanDate.LimitOilHead;
                this.textBox11.Text = receiveLiuZhuanDate.LimitOilRemark;
                this.textBox47.Text = receiveLiuZhuanDate.SensorInstaller;
                this.textBox12.Text = receiveLiuZhuanDate.SensorHead;
                this.textBox13.Text = receiveLiuZhuanDate.SensorRemark;
                this.textBox41.Text = receiveLiuZhuanDate.SwitchInstaller;
                this.textBox14.Text = receiveLiuZhuanDate.SwitchHead;
                this.textBox15.Text = receiveLiuZhuanDate.SwitchRemark;
                this.textBox40.Text = receiveLiuZhuanDate.KeySwitchInstaller;
                this.textBox16.Text = receiveLiuZhuanDate.KeySwitchHead;
                this.textBox17.Text = receiveLiuZhuanDate.KeySwitchReamrk;
                this.textBox57.Text = receiveLiuZhuanDate.LNGConnectionInstaller;
                this.textBox29.Text = receiveLiuZhuanDate.LNGConnectionHead;
                this.textBox28.Text = receiveLiuZhuanDate.LNGConnectionHeadRemark;
                this.textBox56.Text = receiveLiuZhuanDate.CNGConnectionInstaller;
                this.textBox27.Text = receiveLiuZhuanDate.CNGConnectionHead;
                this.textBox26.Text = receiveLiuZhuanDate.CNGConnectionRemark;
                this.textBox55.Text = receiveLiuZhuanDate.MixerConnectionInstaller;
                this.textBox25.Text = receiveLiuZhuanDate.MixerConnectionHead;
                this.textBox24.Text = receiveLiuZhuanDate.MixerConnectionRemark;
                this.textBox54.Text = receiveLiuZhuanDate.SpeedAcquisitionInstaller;
                this.textBox23.Text = receiveLiuZhuanDate.SpeedAcquisitionHead;
                this.textBox22.Text = receiveLiuZhuanDate.SpeedAcquisitionRemark;
                this.textBox53.Text = receiveLiuZhuanDate.SpeedSignalInstaller;
                this.textBox21.Text = receiveLiuZhuanDate.SpeedSignalHead;
                this.textBox20.Text = receiveLiuZhuanDate.SpeedSignalRemark;
                this.textBox52.Text = receiveLiuZhuanDate.TemperatureSignalInstaller;
                this.textBox19.Text = receiveLiuZhuanDate.TemperatureSignalHead;
                this.textBox18.Text = receiveLiuZhuanDate.TemperatureSignalRemark;
                this.textBox51.Text = receiveLiuZhuanDate.FuelSignalInstaller;
                this.textBox33.Text = receiveLiuZhuanDate.FuelSignalHead;
                this.textBox32.Text = receiveLiuZhuanDate.FuelSignalRemark;
                this.textBox50.Text = receiveLiuZhuanDate.SystemDebugInstaller; ;
                this.textBox31.Text = receiveLiuZhuanDate.SystemDebugHead;
                this.textBox30.Text = receiveLiuZhuanDate.SystemDebugRemark;
                this.textBox34.Text = receiveLiuZhuanDate.TrainingLocation;
                this.textBox35.Text = receiveLiuZhuanDate.Training;
                this.textBox36.Text = receiveLiuZhuanDate.DriverGuideCollect;
                this.textBox37.Text = receiveLiuZhuanDate.TrainersSign;
                this.textBox38.Text = receiveLiuZhuanDate.TrainerDriverSign;

                //if (this.dateTimePicker1.Value == 0)
                //{
                //    receiveLiuZhuanDate.TrainingDates = DateTime.Now;
                //}
                //else
                //{
                //    this.dateTimePicker1.Value = new DateTime(receiveLiuZhuanDate.TrainingDates);
                //}
                //if (comboBox15.SelectedIndex != -1)
                //{
                    comboBox15.SelectedIndex = receiveLiuZhuanDate.AffectOriginalCar;
                //}

                //if (comboBox16.SelectedIndex != -1)
                //{
                    comboBox16.SelectedIndex = receiveLiuZhuanDate.AffectOriginalGasPedal;
                //}

                //if (comboBox17.SelectedIndex != -1)
                //{
                    comboBox17.SelectedIndex = receiveLiuZhuanDate.AffectOriginalSpeed;
                //}

                //if (comboBox18.SelectedIndex != -1)
                //{
                    comboBox18.SelectedIndex = receiveLiuZhuanDate.AffectOriginalPower;
                //}               


            }
           
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OP_LZB oo = new OP_LZB();
            receiveLiuZhuanDate.Factory=this.textBox43.Text;
            if (this.textBox42.Text == "")
            {
                receiveLiuZhuanDate.EngingPower = 0;
            }
            else
            {
                receiveLiuZhuanDate.EngingPower = long.Parse(this.textBox42.Text);
            }
            receiveLiuZhuanDate.WiringInstaller = this.textBox39.Text;
            receiveLiuZhuanDate.WiringHead = this.textBox1.Text;
            receiveLiuZhuanDate.WiringRemark = this.textBox7.Text;
            receiveLiuZhuanDate.ElectricECUInstaller = this.textBox49.Text;
            receiveLiuZhuanDate.ElectricECUHead = this.textBox8.Text;
            receiveLiuZhuanDate.ElectricECURemark = this.textBox9.Text;
            receiveLiuZhuanDate.LimitOilInstaller = this.textBox48.Text;
            receiveLiuZhuanDate.LimitOilHead = this.textBox10.Text;
            receiveLiuZhuanDate.LimitOilRemark = this.textBox11.Text;
            receiveLiuZhuanDate.SensorInstaller = this.textBox47.Text;
            receiveLiuZhuanDate.SensorHead = this.textBox12.Text;
            receiveLiuZhuanDate.SensorRemark = this.textBox13.Text;
            receiveLiuZhuanDate.SwitchInstaller = this.textBox41.Text;
            receiveLiuZhuanDate.SwitchHead = this.textBox14.Text;
            receiveLiuZhuanDate.SwitchRemark = this.textBox15.Text;
            receiveLiuZhuanDate.KeySwitchInstaller = this.textBox40.Text;
            receiveLiuZhuanDate.KeySwitchHead = this.textBox16.Text;
            receiveLiuZhuanDate.KeySwitchReamrk = this.textBox17.Text;
            receiveLiuZhuanDate.LNGConnectionInstaller = this.textBox57.Text;
            receiveLiuZhuanDate.LNGConnectionHead = this.textBox29.Text;
            receiveLiuZhuanDate.LNGConnectionHeadRemark = this.textBox28.Text;
            receiveLiuZhuanDate.CNGConnectionInstaller = this.textBox56.Text;
            receiveLiuZhuanDate.CNGConnectionHead = this.textBox27.Text;
            receiveLiuZhuanDate.CNGConnectionRemark = this.textBox26.Text;
            receiveLiuZhuanDate.MixerConnectionInstaller = this.textBox55.Text;
            receiveLiuZhuanDate.MixerConnectionHead = this.textBox25.Text;
            receiveLiuZhuanDate.MixerConnectionRemark = this.textBox24.Text;
            receiveLiuZhuanDate.SpeedAcquisitionInstaller = this.textBox54.Text;
            receiveLiuZhuanDate.SpeedAcquisitionHead = this.textBox23.Text;
            receiveLiuZhuanDate.SpeedAcquisitionRemark = this.textBox22.Text;
            receiveLiuZhuanDate.SpeedSignalInstaller = this.textBox53.Text;
            receiveLiuZhuanDate.SpeedSignalHead = this.textBox21.Text;
            receiveLiuZhuanDate.SpeedSignalRemark = this.textBox20.Text;
            receiveLiuZhuanDate.TemperatureSignalInstaller = this.textBox52.Text;
            receiveLiuZhuanDate.TemperatureSignalHead = this.textBox19.Text;
            receiveLiuZhuanDate.TemperatureSignalRemark = this.textBox18.Text;
            receiveLiuZhuanDate.FuelSignalInstaller = this.textBox51.Text;
            receiveLiuZhuanDate.FuelSignalHead = this.textBox33.Text;
            receiveLiuZhuanDate.FuelSignalRemark = this.textBox32.Text;
            receiveLiuZhuanDate.SystemDebugInstaller = this.textBox50.Text; ;
            receiveLiuZhuanDate.SystemDebugHead = this.textBox31.Text;
            receiveLiuZhuanDate.SystemDebugRemark = this.textBox30.Text;
            receiveLiuZhuanDate.TrainingLocation = this.textBox34.Text;
            receiveLiuZhuanDate.Training = this.textBox35.Text;
            receiveLiuZhuanDate.DriverGuideCollect = this.textBox36.Text;
            receiveLiuZhuanDate.TrainersSign = this.textBox37.Text;
            receiveLiuZhuanDate.TrainerDriverSign = this.textBox38.Text;
            receiveLiuZhuanDate.TrainingDates = this.dateTimePicker1.Value.Ticks;
            
            receiveLiuZhuanDate.AffectOriginalCar = comboBox15.SelectedIndex;
            receiveLiuZhuanDate.AffectOriginalGasPedal = comboBox16.SelectedIndex;

            receiveLiuZhuanDate.AffectOriginalSpeed = comboBox17.SelectedIndex;

            receiveLiuZhuanDate.AffectOriginalPower = comboBox18.SelectedIndex;
           
            //if (comboBox16.Text == "是")
            //{
            //    receiveLiuZhuanDate.AffectOriginalGasPedal = (int)LiuZhuanBiao.YesNo.Yes;
            //}
            //else
            //{
            //    receiveLiuZhuanDate.AffectOriginalGasPedal = (int)LiuZhuanBiao.YesNo.No;
            //}
            //if (comboBox17.Text == "是")
            //{
            //    receiveLiuZhuanDate.AffectOriginalSpeed = (int)LiuZhuanBiao.YesNo.Yes;
            //}
            //else
            //{
            //    receiveLiuZhuanDate.AffectOriginalSpeed = (int)LiuZhuanBiao.YesNo.No;
            //}
            //if (comboBox18.Text == "是")
            //{
            //    receiveLiuZhuanDate.AffectOriginalPower = (int)LiuZhuanBiao.YesNo.Yes;
            //}
            //else
            //{
            //    receiveLiuZhuanDate.AffectOriginalPower = (int)LiuZhuanBiao.YesNo.No;
            //}
            receiveLiuZhuanDate.Factory = this.textBox43.Text;
          
                       
            oo.saveLiuZhuanBiao(receiveLiuZhuanDate);
            MessageBox.Show("暂存成功");                  
            this.DialogResult = DialogResult.OK;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OP_LZB oo = new OP_LZB();
            receiveLiuZhuanDate.WiringInstaller = this.textBox39.Text;
            receiveLiuZhuanDate.WiringHead = this.textBox1.Text;
            receiveLiuZhuanDate.WiringRemark = this.textBox7.Text;
            receiveLiuZhuanDate.ElectricECUInstaller = this.textBox49.Text;
            receiveLiuZhuanDate.ElectricECUHead = this.textBox8.Text;
            receiveLiuZhuanDate.ElectricECURemark = this.textBox9.Text;
            receiveLiuZhuanDate.LimitOilInstaller = this.textBox48.Text;
            receiveLiuZhuanDate.LimitOilHead = this.textBox10.Text;
            receiveLiuZhuanDate.LimitOilRemark = this.textBox11.Text;
            receiveLiuZhuanDate.SensorInstaller = this.textBox47.Text;
            receiveLiuZhuanDate.SensorHead = this.textBox12.Text;
            receiveLiuZhuanDate.SensorRemark = this.textBox13.Text;
            receiveLiuZhuanDate.SwitchInstaller = this.textBox41.Text;
            receiveLiuZhuanDate.SwitchHead = this.textBox14.Text;
            receiveLiuZhuanDate.SwitchRemark = this.textBox15.Text;
            receiveLiuZhuanDate.KeySwitchInstaller = this.textBox40.Text;
            receiveLiuZhuanDate.KeySwitchHead = this.textBox16.Text;
            receiveLiuZhuanDate.KeySwitchReamrk = this.textBox17.Text;
            receiveLiuZhuanDate.LNGConnectionInstaller = this.textBox57.Text;
            receiveLiuZhuanDate.LNGConnectionHead = this.textBox29.Text;
            receiveLiuZhuanDate.LNGConnectionHeadRemark = this.textBox28.Text;
            receiveLiuZhuanDate.CNGConnectionInstaller = this.textBox56.Text;
            receiveLiuZhuanDate.CNGConnectionHead = this.textBox27.Text;
            receiveLiuZhuanDate.CNGConnectionRemark = this.textBox26.Text;
            receiveLiuZhuanDate.MixerConnectionInstaller = this.textBox55.Text;
            receiveLiuZhuanDate.MixerConnectionHead = this.textBox25.Text;
            receiveLiuZhuanDate.MixerConnectionRemark = this.textBox24.Text;
            receiveLiuZhuanDate.SpeedAcquisitionInstaller = this.textBox54.Text;
            receiveLiuZhuanDate.SpeedAcquisitionHead = this.textBox23.Text;
            receiveLiuZhuanDate.SpeedAcquisitionRemark = this.textBox22.Text;
            receiveLiuZhuanDate.SpeedSignalInstaller = this.textBox53.Text;
            receiveLiuZhuanDate.SpeedSignalHead = this.textBox21.Text;
            receiveLiuZhuanDate.SpeedSignalRemark = this.textBox20.Text;
            receiveLiuZhuanDate.TemperatureSignalInstaller = this.textBox52.Text;
            receiveLiuZhuanDate.TemperatureSignalHead = this.textBox19.Text;
            receiveLiuZhuanDate.TemperatureSignalRemark = this.textBox18.Text;
            receiveLiuZhuanDate.FuelSignalInstaller = this.textBox51.Text;
            receiveLiuZhuanDate.FuelSignalHead = this.textBox33.Text;
            receiveLiuZhuanDate.FuelSignalRemark = this.textBox32.Text;
            receiveLiuZhuanDate.SystemDebugInstaller = this.textBox50.Text; ;
            receiveLiuZhuanDate.SystemDebugHead = this.textBox31.Text;
            receiveLiuZhuanDate.SystemDebugRemark = this.textBox30.Text;
            receiveLiuZhuanDate.TrainingLocation = this.textBox34.Text;
            receiveLiuZhuanDate.Training = this.textBox35.Text;
            receiveLiuZhuanDate.DriverGuideCollect = this.textBox36.Text;
            receiveLiuZhuanDate.TrainersSign = this.textBox37.Text;
            receiveLiuZhuanDate.TrainerDriverSign = this.textBox38.Text;
            receiveLiuZhuanDate.TrainingDates = this.dateTimePicker1.Value.Ticks;

            receiveLiuZhuanDate.AffectOriginalCar = comboBox15.SelectedIndex;
            receiveLiuZhuanDate.AffectOriginalGasPedal = comboBox16.SelectedIndex;

            receiveLiuZhuanDate.AffectOriginalSpeed = comboBox17.SelectedIndex;

            receiveLiuZhuanDate.AffectOriginalPower = comboBox18.SelectedIndex;
            receiveLiuZhuanDate.Time = DateTime.Now.Ticks;

            receiveLiuZhuanDate.Factory = this.textBox43.Text;
            if (textBox42.Text == "")
            {
                receiveLiuZhuanDate.EngingPower = 0;
            }
            else
            {
                receiveLiuZhuanDate.EngingPower = float.Parse(this.textBox42.Text);
            }

            receiveLiuZhuanDate.ScratchSaveState = (int)LiuZhuanBiao.ScratchSave.Save;

            oo.saveLiuZhuanBiao(receiveLiuZhuanDate);
            TiaoShiBaoGao TiaoShiBaoGao = new TiaoShiBaoGao();
            TiaoShiBaoGao.LiuZhuanBiao = receiveLiuZhuanDate;
            oo.SaveOrUpdateEntity(TiaoShiBaoGao);

            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;

            }

        }


        public void GetAllEnable()
        {
            this.groupBox5.Enabled = false;
            this.groupBox4.Enabled = false;
            this.groupBox3.Enabled = false;
            this.groupBox2.Enabled = false;
            this.groupBox7.Enabled = false;
            this.button1.Enabled = false;
            this.button5.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CommonMethod.DocumentPrint print = new CommonMethod.DocumentPrint();
            print.DocPrint(panel1);
        }
            
            
            //if (MessageBox.Show(this, "您确定提交吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    MessageBox.Show("恭喜您提交成功", "提示信息");
            //}
           
        }

     
    }

