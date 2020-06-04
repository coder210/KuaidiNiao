using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lazy.KuaidiNiaoCore
{
    public class Utils
    {
        public static string Serialize(object value)
        {
            string str = JsonConvert.SerializeObject(value);
            return str;
        }
        public static T Deserialize<T>(string value)
        {
            var entity = JsonConvert.DeserializeObject<T>(value);
            return entity;
        }
        public static string Sign(string content, string keyValue, string charset)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                return Base64(MD5(content + keyValue, charset), charset);
            }
            return Base64(MD5(content, charset), charset);
        }
        private static string MD5(string str, string charset)
        {
            byte[] buffer = System.Text.Encoding.GetEncoding(charset).GetBytes(str);
            System.Security.Cryptography.MD5CryptoServiceProvider check;
            check = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] somme = check.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (byte a in somme)
            {
                if (a < 16)
                    sb.Append("0" + a.ToString("X"));
                else
                    sb.Append(a.ToString("X"));
            }
            return sb.ToString().ToLower();
        }
        private static string Base64(String str, String charset)
        {
            return Convert.ToBase64String(System.Text.Encoding.GetEncoding(charset).GetBytes(str));
        }
        public static string GetIp()
        {
            var ip = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];
            }
            else
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            //如服务端与客户端在同一网络，则ip会得到内网ip，需通过外网获取客户端ip
            if (string.IsNullOrEmpty(ip) || ip == "::1" || IsInnerIP(ip))
            {
                string url = "http://www.kdniao.com/External/GetIp.ashx";
                try
                {
                    //从网址中获取本机ip数据    
                    System.Net.WebClient client = new System.Net.WebClient();
                    client.Encoding = System.Text.Encoding.Default;
                    string str = client.DownloadString(url);
                    client.Dispose();
                    if (!str.Equals("")) ip = str;
                }
                catch (Exception)
                {

                }
            }

            return ip;
        }
        private static bool IsInnerIP(String ipAddress)
        {
            bool isInnerIp = false;
            long ipNum = GetIpNum(ipAddress);
            long aBegin = GetIpNum("10.0.0.0");
            long aEnd = GetIpNum("10.255.255.255");
            long bBegin = GetIpNum("172.16.0.0");
            long bEnd = GetIpNum("172.31.255.255");
            long cBegin = GetIpNum("192.168.0.0");
            long cEnd = GetIpNum("192.168.255.255");
            isInnerIp = IsInner(ipNum, aBegin, aEnd) || IsInner(ipNum, bBegin, bEnd) || IsInner(ipNum, cBegin, cEnd) || ipAddress.Equals("127.0.0.1");
            return isInnerIp;
        }
        private static long GetIpNum(String ipAddress)
        {
            String[] ip = ipAddress.Split('.');
            long a = int.Parse(ip[0]);
            long b = int.Parse(ip[1]);
            long c = int.Parse(ip[2]);
            long d = int.Parse(ip[3]);

            long ipNum = a * 256 * 256 * 256 + b * 256 * 256 + c * 256 + d;
            return ipNum;
        }
        private static bool IsInner(long userIp, long begin, long end)
        {
            return (userIp >= begin) && (userIp <= end);
        }
    }
}
