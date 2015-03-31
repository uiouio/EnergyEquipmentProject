using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;
using CustomManageWindow.Service;
using CommonControl;
using CommonMethod;
using System.IO;

namespace CustomManageWindow
{
    public partial class YanChe_add_Dialog : CommonControl.BaseForm
    {
        /// <summary>
        /// 是用来展示数据还是输入数据，1用来输入数据，0用来展示数据
        /// </summary>
        private int isShowOrInput;
        public int IsShowOrInput
        {
            get { return isShowOrInput; }
            set { isShowOrInput = value; }
        }
        private CarBaseInfo carBaseInfo;
        public CarBaseInfo CarBaseInfo
        {
            get { return carBaseInfo; }
            set { carBaseInfo = value; }
        }
        IList cylinder;
        CustomService ss = new CustomService();
        public YanChe_add_Dialog()
        {
            InitializeComponent();
        }
        private void YanChe_GaiZhuangDan_Load(object sender, EventArgs e)
        {
            if(CarBaseInfo.ModidiedType==(int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGGas)
            {
                this.comboBox1.DataSource = ss.SelectCylinderType("CNG汽油");
                this.comboBox2.Text = "1";
            }
            else if (CarBaseInfo.ModidiedType == (int)ModificationContract.CNGGasCNGDieselLNGDiesel.CNGDiesel)
            {
                this.comboBox1.DataSource = ss.SelectCylinderType("CNG柴油");
                this.comboBox2.Items.Add("1");
                this.comboBox2.Items.Add("2");
                this.comboBox2.Items.Add("3");
                this.comboBox2.Items.Add("4");
                
            }
            else if (CarBaseInfo.ModidiedType == (int)ModificationContract.CNGGasCNGDieselLNGDiesel.LNGDiesel)
            {
                this.comboBox1.DataSource = ss.SelectCylinderType("LNG柴油");
                this.comboBox2.Items.Add("1");
                this.comboBox2.Items.Add("2");

            }
            
            this.textBox13.Text = CarBaseInfo.TotalMass.ToString();
            if (CarBaseInfo.Cylinder != null)
            {
                this.comboBox1.Text = CarBaseInfo.Cylinder.CylinderType;
                this.comboBox2.Text = CarBaseInfo.Cylinder.CylinderNumber.ToString();
            }
            else
            {
                this.comboBox1.Text = "";
            }
           
            //this.textBox3.Text = CarBaseInfo.CylinderType;
            if (CarBaseInfo.SupperTime==0)
            {
                this.dateTimePicker1.Value = DateTime.Now;
            }
            else 
            { 
                long ticks = CarBaseInfo.SupperTime;
                DateTime dt = new DateTime(ticks);
                this.dateTimePicker1.Value= dt;
            }
            this.textBox9.Text = CarBaseInfo.CylinderWeight.ToString();
            this.textBox15.Text = (20).ToString();
            this.textBox14.Text = CarBaseInfo.CylinderVolume.ToString();
            this.textBox13.Text = CarBaseInfo.KerbMass.ToString();
            this.textBox4.Text = CarBaseInfo.Thinckness.ToString();
            this.textBox5.Text = CarBaseInfo.ChargeWeight.ToString();
            this.textBox2.Text = CarBaseInfo.CylinderNo;

            string tempPath = CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.CAR_RSOURCE + "\\" + CarBaseInfo.BodyImage;
            CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
            fileUpDown.Download(CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.CAR_RSOURCE, CarBaseInfo.BodyImage, CommonStaticParameter.CAR_RSOURCE);
            if (File.Exists(tempPath))
            {
                pictureBox1.Image = new Bitmap(tempPath);
            }
            #region 功能确认 判断checkebox
            string s = null;
                if (CarBaseInfo.GoodsValidation == null)
                {
                    s = "";
                }
                else
                {
                    s = CarBaseInfo.GoodsValidation;
                    char[] s1 = s.ToCharArray();
                    #region
                    if (s1[0] == '1')
                    {
                        checkBox1.Checked = true;
                    }
                    else if (s1[0] == '0')
                    {
                        checkBox1.Checked = false;
                    }
                    if (s1[1] == '1')
                    {
                        checkBox5.Checked = true;
                    }
                    else if (s1[1] == '0')
                    {
                        checkBox5.Checked = false;
                    }
                    if (s1[2] == '1')
                    {
                        checkBox2.Checked = true;
                    }
                    else if (s1[2] == '0')
                    {
                        checkBox2.Checked = false;
                    }
                    if (s1[3] == '1')
                    {
                        checkBox6.Checked = true;
                    }
                    else if (s1[3] == '0')
                    {
                        checkBox6.Checked = false;
                    }
                    if (s1[4] == '1')
                    {
                        checkBox3.Checked = true;
                    }
                    else if (s1[4] == '0')
                    {
                        checkBox3.Checked = false;
                    }
                    if (s1[5] == '1')
                    {
                        checkBox7.Checked = true;
                    }
                    else if (s1[5] == '0')
                    {
                        checkBox7.Checked = false;
                    }
                    if (s1[6] == '1')
                    {
                        checkBox4.Checked = true;
                    }
                    else if (s1[6] == '0')
                    {
                        checkBox4.Checked = false;
                    }
                    if (s1[7] == '1')
                    {
                        checkBox8.Checked = true;
                    }
                    else if (s1[7] == '0')
                    {
                        checkBox8.Checked = false;
                    }
                    if (s1[8] == '1')
                    {
                        checkBox10.Checked = true;
                    }
                    else if (s1[8] == '0')
                    {
                        checkBox10.Checked = false;
                    }
                    if (s1[9] == '1')
                    {
                        checkBox14.Checked = true;
                    }
                    else if (s1[9] == '0')
                    {
                        checkBox14.Checked = false;
                    }
                    if (s1[10] == '1')
                    {
                        checkBox9.Checked = true;
                    }
                    else if (s1[10] == '0')
                    {
                        checkBox9.Checked = false;
                    }
                    if (s1[11] == '1')
                    {
                        checkBox13.Checked = true;
                    }
                    else if (s1[11] == '0')
                    {
                        checkBox13.Checked = false;
                    }
                    if (s1[12] == '1')
                    {
                        checkBox16.Checked = true;
                    }
                    else if (s1[12] == '0')
                    {
                        checkBox16.Checked = false;
                    }
                    if (s1[13] == '1')
                    {
                        checkBox12.Checked = true;
                    }
                    else if (s1[13] == '0')
                    {
                        checkBox12.Checked = false;
                    }
                    if (s1[14] == '1')
                    {
                        checkBox15.Checked = true;
                    }
                    else if (s1[14] == '0')
                    {
                        checkBox15.Checked = false;
                    }
                    if (s1[15] == '1')
                    {
                        checkBox11.Checked = true;
                    }
                    else if (s1[15] == '0')
                    {
                        checkBox11.Checked = false;
                    }
                    #endregion
                }
            #endregion
           
           
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            
         }
        private void button1_Click(object sender, EventArgs e)
        {
            
            CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
            string filename = DateTime.Now.Ticks.ToString() + ".jpg";
            if (!File.Exists(CommonStaticParameter.TEMP + @"\carCheckTemp\"))
            {
                Directory.CreateDirectory(CommonStaticParameter.TEMP + @"\carCheckTemp\");
            }
            pictureBox1.Image.Save(CommonStaticParameter.TEMP+@"\carCheckTemp\"+filename);
            String file = fileUpDown.Upload(CommonStaticParameter.TEMP + @"\carCheckTemp\" + filename, CommonStaticParameter.CAR_RSOURCE);
            //File.Delete(CommonStaticParameter.TEMP + @"\" + filename);懒得弄了，资源占用删不了
            CarBaseInfo.BodyImage = file;
            #region 判断整备质量
            if (textBox13.Text == "")
            {
                CarBaseInfo.KerbMass = 0;
            }
            else
            {
                CarBaseInfo.KerbMass= float.Parse(this.textBox13.Text);
            }
            #endregion
            CarBaseInfo.SupperTime= dateTimePicker1.Value.Ticks;
            CarBaseInfo.CylinderWeight =float.Parse(textBox9.Text);
            CarBaseInfo.CylinderPressure = float.Parse(textBox15.Text);
        
            if (textBox14.Text == "")
            {
                CarBaseInfo.CylinderVolume = 0;
            }
            else
            {
                CarBaseInfo.CylinderVolume = float.Parse(textBox14.Text);
            }

            if (textBox4.Text == "")
            {
                CarBaseInfo.Thinckness = 0;
            }
            else
            {
                CarBaseInfo.Thinckness = float.Parse(textBox4.Text);
            }
            if (textBox5.Text == "")
            {
                CarBaseInfo.ChargeWeight = 0;
            }
            else
            {
                CarBaseInfo.ChargeWeight = float.Parse(textBox5.Text);
            }
            CarBaseInfo.CylinderNo = this.textBox2.Text;
           //CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
           // String a = fileUpDown.Upload(openFileDialog1.FileName, CommonStaticParameter.TITLE_RSOURCE);
           // Bitmap bitMap = new Bitmap(openFileDialog1.FileName);
           // pictureBox1.Image = bitMap;
           // pictureBox1.Tag = a.Substring(a.LastIndexOf('/') + 1);
            string s;
            int s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16;
            #region 判断CheckBox
            if (checkBox1.Checked)
            {
                s1 = 1;
            }
            else
            {
                s1 = 0;
            }
            if (checkBox5.Checked)
            {
                s2 = 1;
            }
            else
            {
                s2 = 0;
            }
            if (checkBox2.Checked)
            {
                s3 = 1;
            }
            else
            {
                s3 = 0;
            }
            if (checkBox6.Checked)
            {
                s4 = 1;
            }
            else
            {
                s4 = 0;
            }
            if (checkBox3.Checked)
            {
                s5 = 1;
            }
            else
            {
                s5 = 0;
            }
            if (checkBox7.Checked)
            {
                s6 = 1;
            }
            else
            {
                s6 = 0;
            }
            if (checkBox4.Checked)
            {
                s7 = 1;
            }
            else
            {
                s7 = 0;
            }
            if (checkBox8.Checked)
            {
                s8 = 1;
            }
            else
            {
                s8 = 0;
            }
            if (checkBox10.Checked)
            {
                s9 = 1;
            }
            else
            {
                s9 = 0;
            }
            if (checkBox14.Checked)
            {
                s10 = 1;
            }
            else
            {
                s10 = 0;
            }
            if (checkBox9.Checked)
            {
                s11= 1;
            }
            else
            {
                s11 = 0;
            }
            if (checkBox13.Checked)
            {
                s12 = 1;
            }
            else
            {
                s12 = 0;
            }
            if (checkBox16.Checked)
            {
                s13 = 1;
            }
            else
            {
                s13 = 0;
            }
            if (checkBox12.Checked)
            {
                s14 = 1;
            }
            else
            {
                s14 = 0;
            }
            if (checkBox15.Checked)
            {
                s15 = 1;
            }
            else
            {
                s15 = 0;
            }
            if (checkBox11.Checked)
            {
                s16 = 1;
            }
            else
            {
                s16= 0;
            }
            #endregion
            s = s1.ToString() + s2.ToString()+ s3.ToString() + s4.ToString() + s5.ToString() + s6.ToString() + s7.ToString() + s8.ToString() + s9.ToString() + s10.ToString() + s11.ToString() + s12.ToString() + s13.ToString() + s14.ToString() + s15.ToString() + s16.ToString();
            CarBaseInfo.GoodsValidation = s;
            CarBaseInfo.QJRemarks = textBox17.Text;
            carBaseInfo.BodyImage = file.Substring(file.LastIndexOf('/')+1);
            cylinder= ss.SelectCylinderID(this.comboBox1.Text,Convert.ToInt16( this.comboBox2.Text));
            CarBaseInfo.Cylinder=(CylinderInfo)cylinder[0];
            ss.Save(CarBaseInfo);
            MessageBox.Show("保存成功！");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        //int x, y;
        //Image image;
        Label a = null;
        private void label24_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                a = (Label)sender;
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (a != null && e.Button == MouseButtons.Left)
            {
                Graphics g = pictureBox1.CreateGraphics();
                Image imgTemp = new Bitmap(pictureBox1.Width, pictureBox1.Height,g);
                Graphics g2 = Graphics.FromImage(imgTemp);
                g2.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
                g2.DrawString(a.Text, this.Font, new SolidBrush(Color.Red), new PointF(e.X, e.Y));
                g2.DrawString(a.Text, this.Font, new SolidBrush(Color.Transparent), new PointF(e.X, e.Y));
                pictureBox1.Image = imgTemp;
                g2.Dispose();
                g.Dispose();
                a = null;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //pictureBox1.Cursor = Cursors.Cross;
            pictureBox1.Image = pictureBox1.BackgroundImage;
        }

        //private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (pictureBox1.Cursor == Cursors.Cross)
        //    {
        //        x = e.X;
        //        y = e.Y;
        //        image = pictureBox1.Image;
        //    }
        //}
        //private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    Graphics g = pictureBox1.CreateGraphics();
        //    Image imgTemp = new Bitmap(pictureBox1.Width, pictureBox1.Height, g);
        //    Graphics g2 = Graphics.FromImage(imgTemp);
        //    g2.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
        //    g2.FillRectangle(Brushes.White, new Rectangle(e.X > x ? x : e.X, e.Y > y ? y : e.Y, (e.X > x ? (e.X - x) : (x - e.X)), (e.Y > y ? (e.Y - y) : (y - e.Y))));
        //    pictureBox1.Image = imgTemp;
        //    g2.Dispose();
        //    g.Dispose();
        //    x = 0; y = 0; image = null;
        //    pictureBox1.Cursor = Cursors.Default;
        //}

        //private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        //pictureBox1.Update();
        //        pictureBox1.Image = this.image;
        //        using (Graphics g = pictureBox1.CreateGraphics())
        //        {
        //            g.DrawRectangle(Pens.Black, e.X > x ? x : e.X, e.Y > y ? y : e.Y, (e.X > x ? (e.X - x) : (x - e.X)), (e.Y > y ? (e.Y - y) : (y - e.Y)));
        //        }
        //    }
        //}
        private void button4_Click(object sender, EventArgs e)
        {
            CommonMethod.DocumentPrint print = new DocumentPrint();
            print.DocPrint(panel1);
        }

      
    }
}
