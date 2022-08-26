using System.Text.RegularExpressions;

namespace BrunSker.Business.Extensions
{
    public static class FormatExtensions
    {
        public static string CleanCaracters(this string value) => Regex.Replace(value, @"[^0-9]+", "");
    }
}
