using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CommonMethod
{
    public class Weather
    {
        private string day;
        /// <summary>
        /// 今天的日子例：今天 24号
        /// </summary>
        public string Day
        {
            get { return day; }
            set { day = value; }
        }
        private string maxTem;
        /// <summary>
        /// 最高气温 例：12
        /// </summary>
        public string MaxTem
        {
            get { return maxTem; }
            set { maxTem = value; }
        }
        private string minTem;
        /// <summary>
        /// 最低气温 例：24
        /// </summary>
        public string MinTem
        {
            get { return minTem; }
            set { minTem = value; }
        }
        private string windDirection2;
        /// <summary>
        /// 风向2
        /// </summary>
        public string WindDirection2
        {
            get { return windDirection2; }
            set { windDirection2 = value; }
        }
        private string windDirection1;
        /// <summary>
        /// 风向1
        /// </summary>
        public string WindDirection1
        {
            get { return windDirection1; }
            set { windDirection1 = value; }
        }

        private string windSpeed;
        /// <summary>
        /// 风速
        /// </summary>
        public string WindSpeed
        {
            get { return windSpeed; }
            set { windSpeed = value; }
        }
        private string weaDescription;
        /// <summary>
        /// 天气描述
        /// </summary>
        public string WeaDescription
        {
            get { return weaDescription; }
            set { weaDescription = value; }
        }

        private string picName1;
        /// <summary>
        /// 白天图片的名字
        /// </summary>
        public string PicName1
        {
            get { return picName1; }
            set { picName1 = value; }
        }
        private string picName2;
        /// <summary>
        /// 夜晚图片的名字
        /// </summary>
        public string PicName2
        {
            get { return picName2; }
            set { picName2 = value; }
        }

        /// <summary>
        /// 获取今明后三天的天气预报信息
        /// </summary>
        /// <returns>返回List/weather/数组</returns>
        public static List<Weather> Get3DayWeather()
        {
            List<Weather> weather3day = new List<Weather>();

            string s = string.Empty;
            string s1 = string.Empty;
            string s2 = string.Empty;
            try
            {
                s2 = "{\"returnval\":\"OK\",\"wealist\":[";
                WebRequest request = WebRequest.Create("http://www.weather.com.cn/weather/101091001.shtml");//邯郸地区的代码
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));

                //System.ServiceModel.Description.WSPolicy.Elements
                s = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();
                //return s;
                string div = HtmlUtility.GetElementById(s, "7d");  //根据样式名称获取对应的html代码

                List<string> html = new List<string>();
                string[] d1 = HtmlUtility.GetElementsByTagAndClass(div, "li", "dn on");
                html.Add(d1[0]);
                string[] d23456 = HtmlUtility.GetElementsByTagAndClass(div, "li", "dn");
                for (int i = 0; i < d23456.Length; i++)
                {
                    html.Add(d23456[i]);
                }
              
                for (int i = 0; i < 3; i++)
                {
                    Weather w = new Weather();
                    string h1 = HtmlUtility.GetElementsByTagName(html[i], "h1")[0];
                    h1 = HtmlUtility.NoHTML(h1);

                    string h2 = HtmlUtility.GetElementsByTagName(html[i], "h2")[0];
                    h2 = HtmlUtility.NoHTML(h2);

                    w.Day = h1 + " " + h2;

                    string wea = HtmlUtility.GetElementsByClass(html[i], "wea")[0];
                    w.WeaDescription = HtmlUtility.NoHTML(wea);

                    string temp1 = HtmlUtility.GetElementsByClass(html[i], "tem tem1")[0];
                    w.MaxTem = HtmlUtility.NoHTML(temp1);

                    string temp2 = HtmlUtility.GetElementsByClass(html[i], "tem tem2")[0];
                    w.MinTem = HtmlUtility.NoHTML(temp2);

                    string win = HtmlUtility.GetElementsByClass(html[i], "win")[0];
                    string[] winspan = HtmlUtility.GetElementsByTagName(win, "span");

                    w.WindDirection1 = HtmlUtility.GetTitleContent(winspan[0], "span", "title");

                    if (winspan.Length == 2)
                        w.WindDirection2 = HtmlUtility.GetTitleContent(winspan[1], "span", "title");


                    string drec = HtmlUtility.GetElementsByTagName(win, "i")[0];

                    w.WindSpeed = HtmlUtility.NoHTML(drec);

                    string[] big = HtmlUtility.GetElementsByTagName(html[i], "big");

                    for (int ii = 0; ii < big.Length; ii++)
                    {
                        big[ii] = HtmlUtility.GetHtmlAttr(big[ii], "big", "class")[0];
                        if (big[ii].Contains(" "))
                            big[ii] = big[ii].Substring(big[ii].IndexOf(" ") + 1);
                        else
                            big[ii] = "";
                    }

                    w.PicName1 = big[0];
                    if (big.Length > 1)
                        w.PicName2 = big[1];

                    weather3day.Add(w);
                }


            }
            catch (Exception exception)
            {
                return null;
            }

            return weather3day;
        }


    }
}
