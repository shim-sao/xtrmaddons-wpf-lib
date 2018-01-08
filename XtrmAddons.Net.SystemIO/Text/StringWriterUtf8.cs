using System.IO;
using System.Text;

namespace XtrmAddons.Net.SystemIO.Text
{
    /// <summary>
    /// <para>Class XtrmAddons Net System IO Utf8 String Writer.</para>
    /// </summary>
    public class StringWriterUtf8 : StringWriter
    {
        #region Properties

        /// <summary>
        /// Property encoding format.
        /// </summary>
        public override Encoding Encoding => Encoding.UTF8;

        #endregion
    }
}