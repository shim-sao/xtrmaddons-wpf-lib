using System.Drawing;
using System.Threading.Tasks;

namespace XtrmAddons.Net.Picture.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Common Extensions String.
    /// </summary>
    public static class StringExtensionPicture
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
        /// Method to check if a string is a valid image filename.
        /// </summary>
        /// <param name="str">A file full path name.</param>
        /// <returns>True if the image is valid otherwise false.</returns>
        public static bool IsValidImage(this string str)
        {
            try { (new Bitmap(str)).Dispose(); return true; } catch { }
            return false;
        }

        /// <summary>
        /// Method to check if a string is a valid image filename asynchronous.
        /// </summary>
        /// <param name="str">A file full path name.</param>
        /// <returns>True if the image is valid otherwise false.</returns>
        public static async Task<bool> IsValidImageAsync(this string str)
        {
            return await Task.Run(() =>
            {
                return IsValidImage(str);
            });
        }

        /// <summary>
        /// Method to get image bitmap metadata.
        /// </summary>
        /// <param name="str">An image file name or full path.</param>
        /// <returns>An object of image metadata properties.</returns>
        public static dynamic PictureMetadata(this string str) => new PictureMeta(str).Data;

        /// <summary>
        /// Method to get image bitmap metadata asynchronous.
        /// </summary>
        /// <param name="str">An image file full path name.</param>
        /// <returns>An object of image metadata properties.</returns>
        public static async Task<dynamic> PictureMetadataAsync(this string str)
        {
            return await Task.Run(() =>
            {
                return new PictureMeta(str).Data;
            });
        }

        /// <summary>
        /// Method to check if a string is valid email.
        /// </summary>
        /// <param name="str">An email.</param>
        /// <returns>True if it is a valid email otherwise false.</returns>
        /// <see href="https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address">stackoverflow.com</see>
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

        #endregion
    }
}