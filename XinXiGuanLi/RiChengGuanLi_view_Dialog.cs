using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using SQLProvider.Service;

namespace XinXiGuanLi
{
    public partial class RiChengGuanLi_view_Dialog : CommonControl.BaseForm
    {
        BaseService baseService = new BaseService();
        private UserInfo user;

        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
        private Schedule schedule;

        public Schedule Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }

        public RiChengGuanLi_view_Dialog()
        {
            InitializeComponent();
        }

        private void RiChengGuanLi_view_Dialog_Load(object sender, EventArgs e)
        {
            if (schedule == null || (schedule!=null&&schedule.ScheduleTime > DateTime.Now.Ticks))
            {
                textBox1.Enabled = true;
                dateTimePicker1.Enabled = true;
                button1.Enabled = true;
            }
            if (schedule != null)
            {
                textBox1.Text = schedule.ScheduleContent;
                dateTimePicker1.Value = new DateTime(schedule.ScheduleTime);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 100)
            {
                MessageBox.Show("日称内容不能超过100个字！");
                textBox1.Focus();
            }
            if (schedule == null)
            {
                schedule = new Schedule();
            }
            schedule.ScheduleTime = dateTimePicker1.Value.Ticks;
            schedule.ScheduleContent = textBox1.Text.Trim();
            schedule.ScheduleUser = this.user;
            baseService.SaveOrUpdateEntity(schedule);
            this.DialogResult = DialogResult.OK;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Enabled == false)
            {
                return;
            }
            if (dateTimePicker1.Value.Ticks < DateTime.Now.Ticks)
            {
                MessageBox.Show("不可设置以前的日程，请选择此时之后的时间！");
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker1.Focus();
            }
        }
    }
}
