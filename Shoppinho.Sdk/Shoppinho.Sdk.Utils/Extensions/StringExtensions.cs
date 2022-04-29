using System.Text.RegularExpressions;

namespace Shoppinho.Sdk.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string SomenteNumeros(this string str)
        {
            var regex = new Regex(@"[^\d]");
            return regex.Replace(str, string.Empty);
        }
    }
}