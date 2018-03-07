using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Common Extensions String.
    /// </summary>
    public static class StringExtension
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion



        #region Methods

        /// <summary>
        /// Method to get random string to be used like token.
        /// </summary>
        /// <param name="s">The string to generate GUID.</param>
        public static string GuidToBase64(this string s)
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "").Replace("+", "").Replace("/", "");
            return GuidString;
        }

        /// <summary>
        /// Method to convert a string from default to UTF8.
        /// </summary>
        /// <param name="s">The string to convert from Default to UTF8.</param>
        /// <returns>The string converted from Default to UTF8.</returns>
        public static string DefaultToUTF8(this string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Method to uppercase first character of a string.
        /// </summary>
        /// <param name="s">The string to uppercase first character.</param>
        /// <returns>The string with first character uppercase.</returns>
        public static string UCFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                s = string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// Method to count number of words in a string.
        /// </summary>
        /// <param name="str">The string sentence.</param>
        /// <param name="delimiters">The delimiters characters.</param>
        /// <returns>The number of words in the string</returns>
        public static int WordCount(this String str, char[] delimiters = null)
        {
            if (delimiters is null)
            {
                delimiters = new char[] { ' ', '.', '?', ',', ';' };
            }

            return str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Method to get type by string name.
        /// </summary>
        /// <param name="str">A string Class name.</param>
        /// <returns>The Type of the string Class name.</returns>
        public static Type ToType(this string str)
        {
            var type = Type.GetType(str);
            if (type != null) return type;

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(str);

                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }

        /// <summary>
        /// Method to remove all white space in a string.
        /// </summary>
        /// <param name="str">The string to remove white spaces.</param>
        /// <returns>The string with all white spaces removed.</returns>
        public static string RemoveWhitespace(this string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Method to check if the string is null or empty or whitespace only.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if null or empty or whitespace only otherwise False.</returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Method to check if the string is not null or empty or whitespace only.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>False if null or empty or whitespace only otherwise True.</returns>
        public static bool IsNotNullOrWhiteSpace(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Method to remove all white space of a string.
        /// </summary>
        /// <param name="str">The string to remove white spaces.</param>
        /// <returns>The string with all white spaces removed.</returns>
        public static string Sanitize(this string str, string regexPattern = @"[?&^$#@!()+,:;<>’\'*]")
        {
            if(str == null)
            {
                return "";
            }

            return Regex.Replace(str, regexPattern, "")?.Replace(" ", "-")?.Replace("_", "-");
        }

        /// <summary>
        /// Method to replace all diacritics on a string.
        /// </summary>
        /// <param name="str">The string where to replace diacritics.</param>
        /// <returns>A formatted string.</returns>
        public static string RemoveDiacritics(this string str)
        {
            if (str == null)
            {
                return null;
            }

            if (str == "")
            {
                return "";
            }

            var sb = new StringBuilder();

            foreach (char c in str.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Method to check if a string is valid email.
        /// </summary>
        /// <param name="str">An email.</param>
        /// <returns>True if it is a valid email otherwise false.</returns>
        /// <remarks>https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address</remarks>
        public static bool IsValidEmail(this string str)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(str);
                return addr.Address == str;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// <para>Method to deserialize a JSon dictionary to a dynamic object.</para>
        /// <para>The string must be a valid JSon string.</para>
        /// </summary>
        /// <param name="json">A dictionary in JSon string format.</param>
        /// <returns>A dynamic object with dictionary property values.</returns>
        public static ExpandoObject ToExpando(this string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IDictionary<string, object> dictionary = serializer.Deserialize<IDictionary<string, object>>(json);
            return dictionary.ToExpando();
        }

        #endregion
    }
}