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
    public partial class ZiLiao_ChaiYouCNG : Form
    {
        public string Flag;
        OP_JianJian OP_JianJian = new OP_JianJian();
        public int status;
        public long carId;

        public ZiLiao_ChaiYouCNG()
        {
            InitializeComponent();
        }

        private void ZiLiao_ChaiYouCNG_Load(object sender, EventArgs e)
        {
            if (Flag != null)
            {
                char[] str = Flag.ToArray<char>();
                checkBox1.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.CNGDiesel.ID] - 48));
                checkBox2.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.CNGDiesel.License] - 48));
                checkBox3.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.CNGDiesel.TestReport] - 48));
                checkBox4.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.CNGDiesel.CNGDataReview] - 48));
                checkBox5.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.CNGDiesel.CylinderBracket] - 48));
                checkBox6.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.CNGDiesel.CNGAssembly] - 48));
                checkBox8.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.CNGDiesel.CylindersBatch] - 48));
                checkBox9.Checked = Convert.ToBoolean((int)(str[(int)EntityClassLibrary.Car.CNGDiesel.CylindersSupervision] - 48));
            }
      

            if (status == 1)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox9.Enabled = false;
                checkBox7.Enabled = false;
                checkBox8.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EntityClassLibrary.Car cc = new EntityClassLibrary.Car();
            //char[] str = new char[10];
            string s1, s2, s3, s4, s5, s6, s7, s8;

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
            if (checkBox6.Checked)
                s6 = "1";
            else
                s6 = "0";
            if (checkBox8.Checked)
                s7 = "1";
            else
                s7 = "0";
            if (checkBox9.Checked)
                s8 = "1";
            else
                s8 = "0";

            MessageBox.Show("暂存成功");
            cc = (EntityClassLibrary.Car)(OP_JianJian.GetFlag(carId)[0]);
            //string.Format(cc.Flag,str);
            cc.Flag = s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8;
            OP_JianJian.SaveOrUpdateEntity(cc);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityClassLibrary.Car cc = new EntityClassLibrary.Car();
            string s1, s2, s3, s4, s5, s6,s7,s8;
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
            if (checkBox6.Checked)
                s6 = "1";
            else
                s6 = "0";
            if (checkBox8.Checked)
                s7 = "1";
            else
                s7 = "0";
            if (checkBox9.Checked)
                s8 = "1";
            else
                s8 = "0";


            if (MessageBox.Show("确定要提交？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                cc = (EntityClassLibrary.Car)(OP_JianJian.GetFlag(carId)[0]);
                cc.Flag = s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8;
                cc.Status = 1;
                OP_JianJian.SaveOrUpdateEntity(cc);
                this.Close();
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;

            }
        }
    }
}
