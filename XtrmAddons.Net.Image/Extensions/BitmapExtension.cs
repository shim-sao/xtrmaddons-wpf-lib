using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace XtrmAddons.Net.Picture.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Picture Bitmap Extensions.
    /// </summary>
    public static class BitmapExtension
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        #region Methods
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Method to convert a Bitmap to BitmapSource.
        /// </summary>
        /// <param name="bitmap">A Bitmap to convert.</param>
        /// <remarks>
        /// Source : https://stackoverflow.com/questions/6484357/converting-bitmapimage-to-bitmap-and-vice-versa
        /// </remarks>
        /// <returns>A Bitmap Image</returns>
        public static BitmapSource ToBitmapSource(this Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSource retval;

            try
            {
                retval = Imaging.CreateBitmapSourceFromHBitmap
                    (
                        hBitmap,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions()
                    );
            }
            finally
            {
                DeleteObject(hBitmap);
            }

            return retval;
        }

        /// <summary>
        /// Method to convert a Bitmap to BitmapImage.
        /// </summary>
        /// <param name="bitmap">A Bitmap to convert.</param>
        /// <remarks>
        /// Source : https://stackoverflow.com/questions/6484357/converting-bitmapimage-to-bitmap-and-vice-versa
        /// </remarks>
        /// <returns>A BitmapImage</returns>
        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                memory.Seek(0, SeekOrigin.Begin);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        #endregion
    }
}