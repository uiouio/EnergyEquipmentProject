using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonMethod
{
   public  class ToChineseNum
    {

        //public  string GetChineseNum( string strIn)
        //{
        //    string m_1, m_2, m_3, m_4, m_5, m_6, m_7, m_8, m_9;
        //    //m_1 
        //    m_1 = strIn;
        //    string numNum = "0123456789.";
        //    string numChina = "零壹贰叁肆伍陆柒捌玖点";
        //    string numChinaWeigh = "个拾佰仟万拾佰仟亿拾佰仟万";


        //    //m_1.Format("%.2f",   atof(m_1)); 
        //    m_1 = (float.Parse(strIn)).ToString("f2");
        //    m_2 = m_1;
        //    m_3 = m_4 = "";
        //    //m_2:1234-> 壹贰叁肆 
        //    for (int i = 0; i < 11; i++)
        //    {
        //        //m_2=m_2.Replace(numNum.Mid(i,   1),   numChina.Mid(i   *   2,   2)); 
        //        m_2 = m_2.Replace(numNum.Substring(i, 1), numChina.Substring(i, 1));
        //    }

        //    //m_3:佰拾万仟佰拾个 
        //    int iLen = m_1.Length;
        //    if (iLen > 16)
        //    {
        //        m_8 = m_9 = "越界错!";
        //        return "";
        //    }
        //    if (m_1.IndexOf('.') > 0)
        //        iLen = m_1.IndexOf('.');

        //    for (int j = iLen; j >= 1; j--)
        //    {
        //        m_3 += numChinaWeigh.Substring(j - 1, 1);
        //    }
        //    //m_4:2行+3行 

        //    for (int i = 0; i < m_3.Length; i++)
        //    {
        //        m_4 += m_2.Substring(i, 1) + m_3.Substring(i, 1);
        //    }
        //    //m_5:4行去"0"后拾佰仟 

        //    m_5 = m_4;
        //    m_5 = m_5.Replace("零拾", "零");
        //    m_5 = m_5.Replace("零佰", "零");
        //    m_5 = m_5.Replace("零仟", "零");
        //    //m_6:00-> 0,000-> 0 

        //    m_6 = m_5;
        //    for (int i = 0; i < iLen; i++)
        //        m_6 = m_6.Replace("零零", "零");

        //    //m_7:6行去亿,万,个位"0" 
        //    m_7 = m_6;
        //    m_7 = m_7.Replace("亿零万零", "亿零");
        //    m_7 = m_7.Replace("亿零万", "亿零");
        //    m_7 = m_7.Replace("零亿", "亿");
        //    m_7 = m_7.Replace("零万", "万");
        //    if (m_7.Length > 2)
        //        m_7 = m_7.Replace("零个", "个");

        //    //m_8:7行+2行小数-> 数目 
        //    m_8 = m_7;
        //    m_8 = m_8.Replace("个", "");
        //    if (m_2.Substring(m_2.Length - 3, 3) != "点零零")
        //        m_8 += m_2.Substring(m_2.Length - 3, 3);

        //    //m_9:7行+2行小数-> 价格 
        //    m_9 = m_7;
        //    m_9 = m_9.Replace("个", "圆");
        //    if (m_2.Substring(m_2.Length - 3, 3) != "点零零")
        //    {
        //        m_9 += m_2.Substring(m_2.Length - 2, 2);
        //        m_9 = m_9.Insert(m_9.Length - 1, "角");
        //        m_9 += "分";
        //    }
        //    else m_9 += "整";
        //    if (m_9 != "零圆整")
        //        m_9 = m_9.Replace("零圆", "");
        //    m_9 = m_9.Replace("零分", "整");
         
        //        return m_9;

        //}

       public string GetChineseNum(float innum)
        {
            decimal num = Convert.ToDecimal(innum);
            string strUpperMum = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字 
            string strNumUnit = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
            string strOfNum = "";    //从原num值中取出的值 
            string strNum = "";    //数字的字符串形式 
            string strReturnUpper = "";  //人民币大写金额形式 
            int i;    //循环变量 
            int sumLength;    //num的值乘以100的字符串长度 
            string ch1 = "";    //数字的汉语读法 
            string ch2 = "";    //数字位的汉字读法 
            int nzero = 0;  //用来计算连续的零值是几个 
            int temp;            //从原num值中取出的值 

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数 
            strNum = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式 
            sumLength = strNum.Length;      //找出最高位 
            if (sumLength > 15) { return "溢出"; }
            strNumUnit = strNumUnit.Substring(15 - sumLength);   //取出对应位数的strNumUnit的值。如：200.55,sumLength为5所以strNumUnit=佰拾元角分 

            //循环取出每一位需要转换的值 
            for (i = 0; i < sumLength; i++)
            {
                strOfNum = strNum.Substring(i, 1);          //取出需转换的某一位的值 
                temp = Convert.ToInt32(strOfNum);      //转换为数字 
                if (i != (sumLength - 3) && i != (sumLength - 7) && i != (sumLength - 11) && i != (sumLength - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (strOfNum == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (strOfNum != "0" && nzero != 0)
                        {
                            ch1 = "零" + strUpperMum.Substring(temp * 1, 1);
                            ch2 = strNumUnit.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = strUpperMum.Substring(temp * 1, 1);
                            ch2 = strNumUnit.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (strOfNum != "0" && nzero != 0)
                    {
                        ch1 = "零" + strUpperMum.Substring(temp * 1, 1);
                        ch2 = strNumUnit.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (strOfNum != "0" && nzero == 0)
                        {
                            ch1 = strUpperMum.Substring(temp * 1, 1);
                            ch2 = strNumUnit.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (strOfNum == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (sumLength >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = strNumUnit.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (sumLength - 11) || i == (sumLength - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = strNumUnit.Substring(i, 1);
                }
                strReturnUpper = strReturnUpper + ch1 + ch2;

                if (i == sumLength - 1 && strOfNum == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    strReturnUpper = strReturnUpper + '整';
                }
            }
            if (num == 0)
            {
                strReturnUpper = "零元整";
            }
            return strReturnUpper;
        }

    }
}
