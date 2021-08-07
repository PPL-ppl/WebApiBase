using System;
using System.Text;

namespace WebApiBase.Common
{
    public class StringConversionHelper
    {
        #region 将 16进制 字符串解码成对应的 字符串

        public static string S16ConversionStr(string str)
        {
            /*************** 将 16进制字符串 解码成 字符串 ***************/

            string strData1 = "56311F31";
            string getData1 = "";

            // 声明一个byte数组，大小为 16进制字符串 长度的一半，因为16进制数据都是两个一组
            byte[] buf1 = new byte[str.Length / 2];
            for (int i = 0; i < str.Length; i += 2)
            {
                // 将 16进制字符串 中的每两个字符转换成 byte，并加入到新申请的 byte数组 中
                buf1[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
            }

            // 将 byte数组 解码成 字符串：
            getData1 = Encoding.Default.GetString(buf1);
            Console.WriteLine("56312E31 对应的字符串是：" + getData1);
            return getData1;
            /*/*************** 将 16进制字符串 解码成 字符串 **************#1#

            string strData1 = "56312E31";
            string getData1 = "";

            // 声明一个byte数组，大小为 16进制字符串 长度的一半，因为16进制数据都是两个一组
            byte[] buf1 = new byte[strData1.Length / 2];
            for (int i = 0; i < strData1.Length; i += 2)
            {
                // 将 16进制字符串 中的每两个字符转换成 byte，并加入到新申请的 byte数组 中
                buf1[i / 2] = Convert.ToByte(strData1.Substring(i, 2), 16);
            }

            // 将 byte数组 解码成 字符串：
            getData1 = Encoding.Default.GetString(buf1);
            Console.WriteLine("56312E31 对应的字符串是：" + getData1);*/
        }

        #endregion

        #region 将 16进制 字符串解码成对应的 中文

        public static string S16ConversionChinese(string str)
        {
            /***************** 将 16进制字符串 解码成 汉字 *******************/

            string strData2 = "C1F5D5F1D3A2";
            string getData2 = "";

            byte[] buf2 = new byte[str.Length / 2];
            for (int i = 0; i < str.Length; i += 2)
            {
                buf2[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
            }

            // 解码成汉字
            getData2 = Encoding.GetEncoding("GB2312").GetString(buf2);
            Console.WriteLine("E58898E68CAFE88BB1 对应的字符串是：" + getData2);


            /*/***************** 将 16进制字符串 解码成 汉字 ******************#1#

            string strData2 = "C1F5D5F1D3A2";
            string getData2 = "";

            byte[] buf2 = new byte[strData2.Length / 2];
            for (int i = 0; i < strData2.Length; i += 2)
            {
                buf2[i / 2] = Convert.ToByte(strData2.Substring(i, 2), 16);
            }

            // 解码成汉字
            getData2 = Encoding.GetEncoding("GB2312").GetString(buf2);
            Console.WriteLine("C1F5D5F1D3A2 对应的字符串是：" + getData2);*/
            return getData2;
        }

        #endregion

        #region 将字符串转换为16进制

        public static string StrConversion16(string str)
        {
            // 将字符串转换成16进制表示：
            // 先将字符串转换成 byte 数组；
            // (1)、如果是数字或者字符：byte[] data = Encoding.ASCII.GetBytes(str);
            // (2)、如果是汉字：byte[] data = Encoding.Default.GetBytes(str);
            // 然后将 byte 数组中的每一个元素都转换成 16进制 字符串。
            string strResult1 = "";
            byte[] data1 = Encoding.Default.GetBytes(str); // 将“字符或数字”字符串转换成byte数组
            // 将 byte 数组中的每一个元素都转换成 16进制 字符串。
            for (int i = 0; i < data1.Length; i++)
            {
                strResult1 += data1[i].ToString("X2");
            }

            Console.WriteLine(strResult1);
            return strResult1;
        }

        #endregion

        #region 将中文转换为16进制

        public static string ChineseConversion16(string str)
        {
            string strResult2 = "";
            string strData2 = "刘振英";
            byte[] data2 = Encoding.GetEncoding("gb2312").GetBytes(str); // 将“汉字”字符串转换成byte数组
            for (int i = 0; i < data2.Length; i++) // 将byte数组中的每一个字符串都转换成 16进制 字符串
            {
                strResult2 += data2[i].ToString("X2");
            }

            Console.WriteLine(strResult2);

            return strResult2;


            /*string strResult2 = "";
            string strData2 = "刘振英";
            byte[] data2 = Encoding.Default.GetBytes(strData2); // 将“汉字”字符串转换成byte数组

            for (int i = 0; i < data2.Length; i++) // 将byte数组中的每一个字符串都转换成 16进制 字符串
            {
                strResult2 += data2[i].ToString("X2");
            }

            Console.WriteLine(strResult2);*/
        }

        #endregion
    }
}