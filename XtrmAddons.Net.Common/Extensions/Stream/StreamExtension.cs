using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Common Stream Extensions.
    /// </summary>
    public static class StreamExtension
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
        /// Method to check if a file is a valid image.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <returns>True if the image is valid otherwise false.</returns>
        public static bool IsValidImage(this Stream stream)
        {
            try { (new Bitmap(stream)).Dispose(); return true; } catch { }
            return false;
        }

        /// <summary>
        /// Method to check if a file is a valid image.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <returns>True if the image is valid otherwise false.</returns>
        public static async Task<bool> IsValidImageAsync(this Stream stream)
        {
            return await Task.Run(() =>
            {
                return IsValidImage(stream);
            });
        }

        #endregion
    }
}