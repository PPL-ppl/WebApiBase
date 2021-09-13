using System;
using Microsoft.AspNetCore.Mvc;
using WebApiBase.Common;

namespace WebApiBase.Controllers
{
    public class AExampleController : BaseController
    {
        [HttpGet]
        public string GetSte()
        {
            string str1 = "56311F31";
            StringConversionHelper.S16ConversionStr(str1);
            string str2 = "E58898E68CAFE88BB1";
            StringConversionHelper.S16ConversionChinese(str2);
            string strData1 = "V1,1";
            StringConversionHelper.StrConversion16(strData1);
            string strData2 = "刘振英";
            StringConversionHelper.ChineseConversion16(strData2);
            Console.WriteLine(strData2);
            return strData2;
        }
    }
}