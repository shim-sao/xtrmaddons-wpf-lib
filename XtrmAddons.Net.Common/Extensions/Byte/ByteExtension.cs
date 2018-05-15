using System.Text;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Common Byte Extensions.
    /// </summary>
    public static class ByteExtension
    {
        /// <summary>
        /// Method to convert bytes to string with default encoding as UTF8.
        /// </summary>
        /// <param name="source">The bytes array.</param>
        /// <param name="encoding">The encoding characters.</param>
        /// <returns>A string encoding UTF8 by default.</returns>
        public static string ConvertByteToString(this byte[] source, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return source != null ? encoding.GetString(source) : null;
        }
    }
}