using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System;

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

        /// <summary>
        /// Method to save an BitmapImage.
        /// </summary>
        /// <param name="image">A BitmapImage to save.</param>
        /// <param name="filePath">The fullname or path to the image.</param>
        /// <see cref="https://stackoverflow.com/questions/35804375/how-do-i-save-a-bitmapimage-from-memory-into-a-file-in-wpf-c"/>
        public static void Save(this BitmapImage bitmapImage, string filePath, bool? overrride = true)
        {
            if(overrride == true)
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    encoder.Save(fileStream);
                }
            }
            else if (overrride == false)
            {
                throw new InvalidOperationException("The image file already exits !");
            }

        }

        #endregion
    }
}