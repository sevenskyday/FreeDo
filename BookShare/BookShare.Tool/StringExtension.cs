using System;
using System.Linq;

namespace BookShare.Tool
{
    public static class StringExtension
    {
        /// <summary>
        /// 字符串为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNull(this string str)
        {
            return !(string.IsNullOrWhiteSpace(str) && string.IsNullOrEmpty(str));
        }
        /// <summary>
        /// 字符串不为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNull(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) || !string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 是否包含危险字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHaveDangerStr(this string str)
        {
            str = str.Trim();
            string[] _dangerString = { "<javascript", "<img", "</javascript", "<iframe", "insert", "delete", "update", "script", "<>", "<script", "<", ">" };
            if (string.IsNullOrEmpty(str)) return false;
            str = str.ToLower();
            return _dangerString.Any(x => str.Contains(x));
        }
        /// <summary>
        /// 只显示第一个字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len">开头显示字符数量</param>
        /// <returns></returns>
        public static string OnlyHeadString(this string str, int len = 1)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 0)
            {
                var newstr = "*";
                return newstr.PadLeft(3, '*');
            }
            var first = str.Substring(0, len);
            return first.PadRight(str.Length, '*');

        }
        /// <summary>
        /// 只显示最后一个字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len">结尾显示字符数量</param>
        /// <returns></returns>
        public static string OnlyTailString(this string str, int len = 1)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 0)
            {
                var newstr = "*";
                return newstr.PadLeft(3, '*');
            }
            var first = str.Substring(str.Length - len, len);
            return first.PadLeft(str.Length, '*');
        }

        /// <summary>
        /// 只显示开头和结尾的字符
        /// </summary>
        /// <param name="headlen">开头显示字符数量</param>
        /// <param name="taillen">结尾显示字符数量</param>
        /// <returns></returns>
        public static string OnlyHeadAndTailString(this string str, int headlen = 1, int taillen = 1)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 0)
            {
                var newstr = "*";
                return newstr.PadLeft(3, '*');
            }
            var first = str.Substring(0, headlen);
            var last = str.Substring(str.Length - taillen, taillen);
            return first.PadRight(str.Length - taillen, '*') + last;
        }
    }
}
