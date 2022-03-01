using System.Text.RegularExpressions;

namespace BarBeeOrder.Extension
{
    public static class Extension
    {
        public static string ToVND(this double donGia)
        {
            return donGia.ToString("#,##0") + "đ";
        }
        public static string ToTitleCase(string str)
        {
            string result = str;
            if (!string.IsNullOrEmpty(str))
            {
                var words = str.Split(' ');
                for (int index = 0; index < words.Length; index++)
                {
                    var s = words[index];
                    if (s.Length > 0)
                    {
                        words[index] = s[0].ToString().ToUpper() + s.Substring(1);
                    } 
                    result = string.Join(" ", words);
                }
            } 
            return result;
        }
        public static string ToFriendlyURL(this string url)
        {
            var result = url.ToLower().Trim();
            result = Regex.Replace(result,"áà","a");
            result = Regex.Replace(result, "áà", "e");
            result = Regex.Replace(result, "áà", "o");
            result = Regex.Replace(result, "áà", "u");
            result = Regex.Replace(result, "áà", "i");
            result = Regex.Replace(result, "áà", "y");
            result = Regex.Replace(result, "đ", "d");
            result = Regex.Replace(result, "[]", "");
            result = Regex.Replace(result, "áà", "a");
            return result;
        }
    }
}
