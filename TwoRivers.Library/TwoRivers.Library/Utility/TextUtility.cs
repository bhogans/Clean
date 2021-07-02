using System.Globalization;
using System.Text.RegularExpressions;

namespace TwoRivers.Library.Utility
{
    public static class TextUtility
    {
        public static string CleanForDisplay(string data)
        {
            if (string.IsNullOrEmpty(data))
                return data;
            else
                return Regex.Replace(data, @"[^\u0000-\u007F]", "");
        }

        public static string UpperFirst(string word)
        {
            //word = word[0].ToString().ToUpper() + word.Substring(1);

            //return word;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);
        }
    }
}
