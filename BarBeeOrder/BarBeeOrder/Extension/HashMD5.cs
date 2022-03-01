using System.Security.Cryptography;
using System.Text;

namespace BarBeeOrder.Extension
{
    public static class HashMD5
    {
        public static string ToMD5(this string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in hash)
            {
                sbHash.Append(string.Format("{0:x2}",b));
            }
            return sbHash.ToString();
        }   
    }
}
