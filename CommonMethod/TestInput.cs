using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonMethod
{
    public class TestInput
    {
        /// <summary>
        /// 验证身份证是否正确
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool TestIdCard(string str)
        {
            bool ii = new bool();
            ii = false;
            Regex re = new Regex("/^[1-9]\\d{5}[1-9]\\d{3}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])\\d{3}([0-9]|X)$/");
            Match m = re.Match(str);
            if (m.Success)
            {
                ii = true;
            }

            return ii;
        }
        /// <summary>
        /// 验证Email
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool TestEmail(string str)
        {
            bool ii = new bool();
            ii = false;
            Regex re = new Regex("^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$");
            Match m = re.Match(str);
            if (m.Success)
            {
                ii = true;
            }

            return ii;
        }
        /// <summary>
        /// 验证电话号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool TestPhoneNum(string str)
        {
            bool ii = new bool();
            ii = false;
            Regex re = new Regex("^[1][358]\\d{9}$");
            Match m = re.Match(str);
            if (m.Success)
            {
                ii = true;
            }

            return ii;
        }
        /// <summary>
        /// 验证是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool TestNum(string str)
        {
            bool ii = new bool();
            ii = false;
            Regex re = new Regex("^[0-9]*$");
            Match m = re.Match(str);
            if (m.Success)
            {
                ii = true;
            }

            return ii;
        }

        /// <summary>
        /// 验证邮政编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool TestZioCode(string str)
        {
            bool ii = new bool();
            ii = false;
            Regex re = new Regex("^[0-9]\\d{5}$");
            Match m = re.Match(str);
            if (m.Success)
            {
                ii = true;
            }

            return ii;
        }

        public bool TestGoodsCode(string str)
        {
            bool ii = new bool();
            ii = false;
            Regex re = new Regex("^\\d{23}$");
            Match m = re.Match(str);
            if (m.Success)
            {
                ii = true;
            }

            return ii;
        }

        public bool TestDecimal(string str)
        {
            //bool ii = new bool();
            //ii = false;
            //Regex re = new Regex("^[0-9]{1,5}\\.[0-9]{2}$");
            //Match m = re.Match(str);
            //if (m.Success)
            //{
            //    ii = true;
            //}

            //return ii;


            string pattern = @"^[+-]?\\d*[.]?\\d*$";
            if (Regex.Match(str, "^[+-]?\\d*[.]?\\d*$").Success == true)//可以转化为数字
            {
                if (str.IndexOf('.') == -1)//整数
                {
                    return true;
                }
                else                       //小数
                {
                    int d = str.Length - 1 - str.IndexOf('.');//d是小数位数
                    if (d <= 3)
                    {
                        return true;
                    }
                    else
                        return false;
                }

            }
            else//不可以转化为数字
            {
                return false;
            }

        }



    }

}

