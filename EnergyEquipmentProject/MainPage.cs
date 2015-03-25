using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;
using System.Data.SqlClient;
using SQLProvider.Service;
using CommonMethod;
using System.IO;

namespace EnergyEquipmentProject
{
    public partial class MainPage : CommonControl.CommonTabPage
    {
        public delegate void dataChangedHandler(IList newsList);
        Service.MainPageService mainPageService = new Service.MainPageService();
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(UserInfo user)
        {
            this.User = user;
            InitializeComponent();
        }

        public override void reFreshAllControl()
        {
            IList matterList = mainPageService.getMatterByUserId(this.User);
            matterPanel1.refresh(matterList);
            IList newsList = mainPageService.getNews();
            newsPanel1.refresh(newsList);
            IList scheduleList = mainPageService.getScheduleByUserIdAndDate(this.User.Id, DateTime.Now.Date.Ticks, DateTime.Now.Date.Ticks + new DateTime(1, 1, 2).Date.Ticks);
            schedulePanel1.refresh(scheduleList);
            IList letterList = mainPageService.getLetterByPublishUser(this.User.Id);
            letterPanel1.refresh(letterList);
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Visible = false;
            label_userName.Text = User.Name;
            if (User.Sex != null)
            {
                if (User.Sex.Trim() == ((char)BaseEntity.SexEnum.Man).ToString())
                {
                    label_userName.Text += "先生";
                }
                else if (User.Sex.Trim() == ((char)BaseEntity.SexEnum.Woman).ToString())
                {
                    label_userName.Text += "女士";
                }
            }
            this.reFreshAllControl();
            //listenMethod_News();
            //listenMethod_Matter();
            initTodayInfo();
            this.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void newsChange(object sender, SqlNotificationEventArgs e)
        {
            IList newsList = mainPageService.getNews();
            if (newsPanel1.InvokeRequired)
            {
                dataChangedHandler dch = new dataChangedHandler(newsPanel1.refresh);
                newsPanel1.Invoke(dch, newsList);
            }
            else
            {
                newsPanel1.refresh(newsList);
            }
            listenMethod_News();
        }
        private void matterChange(object sender, SqlNotificationEventArgs e)
        {
            IList matterList = mainPageService.getMatterByUserId(this.User);
            if (matterPanel1.InvokeRequired)
            {
                dataChangedHandler dch = new dataChangedHandler(matterPanel1.refresh);
                matterPanel1.Invoke(dch, matterList);
            }
            else
            {
                matterPanel1.refresh(matterList);
            }
            listenMethod_Matter();
        }
        private void schduleChange(object sender, SqlNotificationEventArgs e)
        {
            IList scheduleList = mainPageService.getScheduleByUserIdAndDate(this.User.Id, DateTime.Now.Date.Ticks, DateTime.Now.Date.Ticks + new DateTime(1, 1, 2).Date.Ticks);
            if (schedulePanel1.InvokeRequired)
            {
                dataChangedHandler dch = new dataChangedHandler(schedulePanel1.refresh);
                schedulePanel1.Invoke(dch, scheduleList);
            }
            else
            {
                schedulePanel1.refresh(scheduleList);
            }
            listenMethod_Schedule();
        }
        private void letterChange(object sender, SqlNotificationEventArgs e)
        {
            IList letterList = mainPageService.getLetterByPublishUser(this.User.Id);
            if (letterPanel1.InvokeRequired)
            {
                dataChangedHandler dch = new dataChangedHandler(letterPanel1.refresh);
                letterPanel1.Invoke(dch, letterList);
            }
            else
            {
                letterPanel1.refresh(letterList);
            }
            listenMethod_Letter();
        }

        private void listenMethod_News()
        {
            OnChangeEventHandler onChangeNews = new OnChangeEventHandler(newsChange);
            BaseService.autoUpdateForm(onChangeNews, "select ID from [dbo].News where State=" + (int)BaseEntity.stateEnum.Normal);
        }
        private void listenMethod_Matter()
        {
            OnChangeEventHandler onChangeMatter = new OnChangeEventHandler(matterChange);
            BaseService.autoUpdateForm(onChangeMatter, "select Number from [dbo].Matter where State=" + (int)BaseEntity.stateEnum.Normal + " and UserId=" + this.User.Id);
        }
        private void listenMethod_Schedule()
        {
            OnChangeEventHandler onChangeSchduleChange = new OnChangeEventHandler(schduleChange);
            BaseService.autoUpdateForm(onChangeSchduleChange, "select ID from [dbo].Schedule where ScheduleTime>=" + DateTime.Now.Date.Ticks + " and ScheduleTime<" + (DateTime.Now.Date.Ticks + new DateTime(1, 1, 2).Date.Ticks) + " and State=" + (int)BaseEntity.stateEnum.Normal + " and ScheduleUser=" + this.User.Id);
        }
        private void listenMethod_Letter()
        {
            OnChangeEventHandler onChangeLetterChange = new OnChangeEventHandler(letterChange);
            BaseService.autoUpdateForm(onChangeLetterChange, "select ID from [dbo].Letter where State=" + (int)BaseEntity.stateEnum.Normal + " and SenderUser=" + this.User.Id);
        }

        private void initTodayInfo()
        {
            try
            {
                List<Weather> weather3day = new List<Weather>();
                weather3day = Weather.Get3DayWeather();

                DownloadOrShowWeather(weather3day[0].PicName1, today_weather_pictureBox1);
                DownloadOrShowWeather(weather3day[0].PicName2, today_weather_pictureBox2);

                today_weather_label.Text = weather3day[0].Day + "" + weather3day[0].WeaDescription;
                today_weather_label1.Text = weather3day[0].MinTem + "---" + weather3day[0].MaxTem;
                today_weather_label2.Text = weather3day[0].WindDirection1 + " " + weather3day[0].WindDirection2 + "  " + weather3day[0].WindSpeed;

                DownloadOrShowWeather(weather3day[1].PicName1, tomorrow_weather_pictureBox1);
                DownloadOrShowWeather(weather3day[1].PicName2, tomorrow_weather_pictureBox2);

                tomorrow_weather_label.Text = weather3day[1].Day + "" + weather3day[1].WeaDescription;
                tomorrow_weather_label1.Text = weather3day[1].MinTem + "---" + weather3day[1].MaxTem;
                tomorrow_weather_label2.Text = weather3day[1].WindDirection1 + " " + weather3day[1].WindDirection2 + "  " + weather3day[1].WindSpeed;


                DownloadOrShowWeather(weather3day[2].PicName1, tomorrow2_weather_pictureBox1);
                DownloadOrShowWeather(weather3day[2].PicName2, tomorrow2_weather_pictureBox2);

                tomorrow2_weather_label.Text = weather3day[2].Day + "" + weather3day[2].WeaDescription;
                tomorrow2_weather_label1.Text = weather3day[2].MinTem + "---" + weather3day[2].MaxTem;
                tomorrow2_weather_label2.Text = weather3day[2].WindDirection1 + " " + weather3day[2].WindDirection2 + "  " + weather3day[2].WindSpeed;

            }
            catch
            {
                MessageBox.Show("网络原因无法加载天气情况");
                today_weather_label.Text = DateTime.Now.ToString("yyyy-MM-dd");
                tomorrow_weather_label.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                tomorrow2_weather_label.Text = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
            }
        }

        private void DownloadOrShowWeather(string PicName1, PictureBox p)
        {
            if (PicName1 != "")
            {
                string tempPath = CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.WEATHERLOGO + "\\" + PicName1 + ".png";
                if (File.Exists(tempPath))
                {
                    p.BackgroundImage = new Bitmap(tempPath);
                }
                else
                {
                    CommonMethod.FileUpDown fileUpDown = new FileUpDown(Securit.DeDES(FileReadAndWrite.IniReadValue("file", "ip")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "id")), Securit.DeDES(FileReadAndWrite.IniReadValue("file", "pwd")));
                    fileUpDown.Download(CommonStaticParameter.TEMP + "\\" + CommonStaticParameter.WEATHERLOGO, PicName1 + ".png", CommonStaticParameter.WEATHERLOGO);
                    if (File.Exists(tempPath))
                    {
                        p.BackgroundImage = new Bitmap(tempPath);
                    }
                }
            }
            else
            {
                p.BackgroundImage = null;
            }
        
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.xxzjgs.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.xxsrl.com/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.xxhi.net/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.hebut.edu.cn/");
        }
    }
}
