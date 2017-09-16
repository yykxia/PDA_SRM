using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text;

namespace PDA_SRM
{
    static class Program
    {
        public static string supplierNo = string.Empty;//供应商编号
        public static string srmAPIUrl = "http://localhost:30018/SRMWebService.asmx";//接口地址
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new SerialsPrint());
        }

        /// <summary>  
        /// POST请求与获取结果  
        /// <param name="Url">接口地址</param>
        /// <param name="opt">调用方法</param>
        /// <param name="postDataStr">相关参数</param>
        /// </summary>  
        public static string HttpPost(string Url,string opt, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(opt + "&" + postDataStr);
            writer.Flush();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }  
    }
}