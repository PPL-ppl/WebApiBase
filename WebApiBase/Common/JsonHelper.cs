using System;
using System.Collections.Generic;

namespace WebApiBase.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 转Json回HttpResponseMessage
        /// </summary>
        /// <param name="code"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string toJson(object result)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        //取Json数据中的字段数据
        public static string toStr(string end, string start)
        {
            Object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(end);
            Newtonsoft.Json.Linq.JObject js = obj as Newtonsoft.Json.Linq.JObject;
            var result = js[end].ToString();
            return result;
        }

        //将Json数据转换为T数组
        public static T[] toStrs<T>(string result)
        {
            List<T> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(result);
            T[] sArray = list.ToArray();
            return sArray;
        }
    }
}