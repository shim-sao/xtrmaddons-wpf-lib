using System;
using System.Drawing;
using System.Threading.Tasks;

namespace XtrmAddons.Net.Picture.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Picture Image Extensions.
    /// </summary>
    public static class ImageExtension
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
        /// Method to crop an image.
        /// </summary>
        /// <param name="image">The image to crop.</param>
        /// <param name="height">The desired height.</param>
        /// <param name="width">The desired width.</param>
        /// <param name="centered">Define if crop must be centered or not.</param>
        /// <returns>The croped image.</returns>
        /// <exception cref="ArgumentNullException">Occurs when Image reference is null.</exception>
        public static Image Crop(this Image image, int height, int width, bool centered = true)
        {
            if (image is null)
            {
                throw new ArgumentNullException("Image");
            }

            int squareLength = image.Width < image.Height ? image.Width : image.Height;
            int top = 0;
            int left = 0;

            if (centered)
            {
                if (image.Width > image.Height)
                {
                    left = (image.Width / 2) - (image.Height / 2);
                    top = 0;
                }
                else
                {
                    left = 0;
                    top = (image.Height / 2) - (image.Width / 2);
                }
            }

            Rectangle rect = new Rectangle(new Point(left, top), new Size(squareLength, squareLength));
            using (Bitmap cloned = new Bitmap(image).Clone(rect, image.PixelFormat))
            {
                return new Bitmap(cloned, new Size(width, height));
            }
        }

        /// <summary>
        /// Method to crop an image.
        /// </summary>
        /// <param name="image">The image to crop.</param>
        /// <param name="height">Desired height.</param>
        /// <param name="width">Desired width.</param>
        /// <param name="centered">Define if crop muxt be centered or not.</param>
        /// <returns></returns>
        public static async Task<Image> CropAsync(this Image image, int height, int width, bool centered = true)
        {
            return await Task.Run(() =>
            {
                return Crop(image, height, width, centered);
            });
        }

        /// <summary>
        /// Method to resize an image.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="maxSize">Desired maximum width/height to apply.</param>
        /// <param name="resizeUp">Resize even if the ime size is lower than maximum size.</param>
        /// <returns>The resized image.</returns>
        /// <exception cref="ArgumentNullException">Occurs when Image reference is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Occurs when Image reference is null.</exception>
        public static Image ResizeRatio(this Image image, int maxSize, bool resizeUp = false)
        {
            if (maxSize <= 0)
            {
                throw new ArgumentOutOfRangeException($"'{nameof(maxSize)}' must be positive and greater than 0.");
            }

            double ratio = image.Height > image.Width ? image.Width / image.Height : image.Height / image.Width;
            double height = 0;
            double width = 0;

            if (image.Height > image.Width)
            {
                if(resizeUp == false)
                {
                    height = image.Height > maxSize ? maxSize : image.Height;
                }
                else
                {
                    height = maxSize;
                }

                width = height * ratio;
            }
            else
            {
                if (resizeUp == false)
                {
                    width = image.Width > maxSize ? maxSize : image.Width;
                }
                else
                {
                    width = maxSize;
                }

                height = width * ratio;
            }

            Rectangle rect = new Rectangle(new Point(0, 0), new Size(image.Width, image.Height));
            using (Bitmap cloned = new Bitmap(image).Clone(rect, image.PixelFormat))
            {
                return new Bitmap(cloned, new Size((int)width, (int)height));
            }
        }

        /// <summary>
        /// Method to resize an image.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="max">Desired maximum width/height to apply.</param>
        /// <param name="resizeUp">Resize even if the ime size is lower than maximum size.</param>
        /// <returns>The resized image.</returns>
        public static async Task<Image> ResizeRatioAsync(this Image image, int max, bool resizeUp = false)
        {
            return await Task.Run(() =>
            {
                return ResizeRatio(image, max, resizeUp);
            });
        }

        #endregion
    }
}