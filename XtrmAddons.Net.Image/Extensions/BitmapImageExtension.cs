using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace XtrmAddons.Net.Picture.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Picture BitmapImage Extensions.
    /// </summary>
    public static class BitmapImageExtension
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
        /// Method to convert a BitmapImage to Bitmap.
        /// </summary>
        /// <param name="bitmapImage">A BitmapImage to convert.</param>
        /// <remarks>
        /// Source : https://stackoverflow.com/questions/6484357/converting-bitmapimage-to-bitmap-and-vice-versa
        /// </remarks>
        /// <returns>A Bitmap</returns>
        public static Bitmap ToBitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        #endregion
    }
}