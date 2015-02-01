using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using System.Text.RegularExpressions;
using CommonMethod;

namespace XinXiGuanLi
{
    public partial class RiChengGuanLi : CommonControl.CommonTabPage
    {
        Service.ScheduleService scheduleService = new Service.ScheduleService();
        public RiChengGuanLi()
        {
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            commonDataGridView1.Rows.Clear();
            IList scheduleList = scheduleService.getScheduleByUserIdAndTime(this.User.Id, 0, 999999999999999999);
            initDataGridView(scheduleList);
        }

        private void initDataGridView(IList scheduleList)
        {
            if (scheduleList != null && scheduleList.Count > 0)
            {
                for (int i = 0; i < scheduleList.Count; i++)
                {
                    Schedule schedule = (Schedule)scheduleList[i];
                    DateTime publishTime = new DateTime(schedule.ScheduleTime);
                    commonDataGridView1.Rows.Add(i + 1, schedule.ScheduleContent, publishTime.ToLongDateString()+CNDate.getTimeByTimeTicks(publishTime.Ticks), "查看", "删除");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = scheduleList[i];
                }
            }
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            RiChengGuanLi_view_Dialog rvd = new RiChengGuanLi_view_Dialog();
            rvd.User = this.User;
            if (rvd.ShowDialog() == DialogResult.OK)
            {
                reFreshAllControl();
            }
        }

        private void RiChengGuanLi_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            commonDataGridView1.Rows.Clear();
            IList scheduleList = scheduleService.getScheduleByUserIdAndTime(this.User.Id, dateTimePicker1.Value.Date.Ticks, dateTimePicker2.Value.Date.Ticks + new DateTime(1, 1, 2).Date.Ticks);
            initDataGridView(scheduleList);
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Schedule schedule = (Schedule)commonDataGridView1.Rows[e.RowIndex].Tag;
            if (e.ColumnIndex == 3)
            {
                RiChengGuanLi_view_Dialog rvd = new RiChengGuanLi_view_Dialog();
                rvd.Schedule = schedule;
                if (rvd.ShowDialog() == DialogResult.OK)
                {
                    button1_Click(button1, new EventArgs());
                }
            }
            else if (e.ColumnIndex == 4)
            {
                if (schedule.ScheduleTime <= DateTime.Now.Ticks)
                {
                    MessageBox.Show("不可删除之前的日程！");
                    return;
                }
                scheduleService.deleteEntity(schedule);
            }
        }
    }
}
