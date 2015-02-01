using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianJian.SQL;

namespace JianJian
{
    public partial class ZiLiao_ChaiYouLNG : Form
    {
        public string Flag;
        OP_JianJian OP_JianJian = new OP_JianJian();
        public int status;
        public long carId;
        public ZiLiao_ChaiYouLNG()
        {
            InitializeComponent();
        }

        private void ZiLiao_ChaiYouLNG_Load(object sender, EventArgs e)
        {
            if (Flag != null)
            {
                char[] str = Flag.ToArray<char>();
                checkBox9.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.LNGDiesel.License] - 48));
                checkBox1.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.LNGDiesel.TestReport] - 48));
                checkBox2.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.LNGDiesel.LNGAssembly] - 48));
                checkBox3.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.LNGDiesel.QualityCertificate] - 48));
                checkBox4.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.LNGDiesel.LiquefiedNaturalGas] - 48));
                checkBox5.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.LNGDiesel.CylindersSupervision] - 48));
            }

            //if (string.Equals(str[(int)EntityClassLibrary.Car.LNGDiesel.PreInstallationRecords],"1"))
            //{
            //    checkBox1.Checked = true;
            //}
            
            if (status==1) 
            {
                checkBox1.Enabled=false;
                checkBox2.Enabled=false;
                checkBox3.Enabled=false;
                checkBox4.Enabled=false;
                checkBox5.Enabled=false;
                checkBox9.Enabled = false;
                checkBox7.Enabled=false;
                button1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EntityClassLibrary.Car cc = new EntityClassLibrary.Car();
            //char[] str = new char[10];
            string s1, s2, s3, s4, s5, s6;


            //if (checkBox1.Checked)
            //    str[0] = '1';
            //else
            //    str[0]='0';
            
            //if (checkBox2.Checked)
            //    str[1] = '1';
            //else
            //    str[1]='0';

            //if (checkBox3.Checked)            
            //    str[2] = '1';
            //else
            //    str[2]='0';

            //if (checkBox4.Checked)            
            //    str[3] = '1';
            //else
            //    str[3]='0';

            //if (checkBox5.Checked)            
            //    str[4] = '1';
            //else
            //    str[4]='0';

            //if (checkBox6.Checked)            
            //    str[5] = '1';
            //else
            //    str[5]='0';
            if (checkBox1.Checked)
                s1 = "1";
            else
                s1="0";

            if (checkBox2.Checked)
                s2 = "1";
            else
                s2 = "0";

            if (checkBox3.Checked)
                s3 = "1";
            else
                s3 = "0";

            if (checkBox4.Checked)
                s4 = "1";
            else
                s4 = "0";

            if (checkBox5.Checked)
                s5 = "1";
            else
                s5 = "0";
            if (checkBox9.Checked)
                s6 = "1";
            else
                s6 = "0";
           
            MessageBox.Show("暂存成功");
            cc=(EntityClassLibrary.Car)(OP_JianJian.GetFlag(carId)[0]);
            //string.Format(cc.Flag,str);
            cc.Flag = s1 + s2 + s3 + s4 + s5 + s6;
            OP_JianJian.SaveOrUpdateEntity(cc);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityClassLibrary.Car cc = new EntityClassLibrary.Car();
            string s1, s2, s3, s4, s5, s6;
            if (checkBox1.Checked)
                s1 = "1";
            else
                s1 = "0";

            if (checkBox2.Checked)
                s2 = "1";
            else
                s2 = "0";

            if (checkBox3.Checked)
                s3 = "1";
            else
                s3 = "0";

            if (checkBox4.Checked)
                s4 = "1";
            else
                s4 = "0";

            if (checkBox5.Checked)
                s5 = "1";
            else
                s5 = "0";
            if (checkBox9.Checked)
                s6 = "1";
            else
                s6 = "0";
            

            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                cc = (EntityClassLibrary.Car)(OP_JianJian.GetFlag(carId)[0]);
                cc.Flag = s1 + s2 + s3 + s4 + s5 + s6;
                cc.Status = 1;
                OP_JianJian.SaveOrUpdateEntity(cc);
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox1.Checked=true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox9.Checked = true;
               
            }
        }
    }
}
