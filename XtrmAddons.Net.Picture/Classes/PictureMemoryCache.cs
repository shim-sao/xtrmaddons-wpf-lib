using Microsoft.Extensions.Caching.Memory;
using System;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;

namespace XtrmAddons.Net.Picture
{
    /// <summary>
    /// Class XtrmAddons Net Picture Memory Cache.
    /// </summary>
    public class PictureMemoryCache
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        protected static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion



        #region Properties

        /// <summary>
        /// Property memory cache dictionary of pictures.
        /// </summary>
        public static MemoryCache MemCache;

        /// <summary>
        /// Property global cache limit expiration.
        /// </summary>
        public static TimeSpan ExpirationScanFrequency = new TimeSpan(0, 0, 5);

        /// <summary>
        /// Property cache limit expiration for a picture.
        /// </summary>
        public static TimeSpan SlidingExpiration = TimeSpan.FromSeconds(3);

        #endregion



        #region Methods

        /// <summary>
        /// Method to get a picture from memory cache.
        /// </summary>
        /// <param name="filename">The full path file name of the picture.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="replace">Force to load and replace picture in memory.</param>
        /// <returns>A Bitmap Image.</returns>
        public static BitmapImage Get(string filename, int width = 512, bool replace = false)
        {
            return Set(filename, width, replace);
        }

        /// <summary>
        /// Method to set a picture into memory cache.
        /// </summary>
        /// <param name="filename">The full path file name of the picture.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="replace">Force to load and replace picture in memory.</param>
        /// <param name="slidingExpiration">Define the time span sliding expiration..</param>
        /// <returns>A Bitmap Image.</returns>
        public static BitmapImage Set(string filename, int width = 512, bool replace = false, TimeSpan slidingExpiration = new TimeSpan())
        {
            // Check if filename is empty.
            // Just log error but generate no exception.
            if (string.IsNullOrWhiteSpace(filename))
            {
                log.Error("PictureMemoryCache try to set BitmapImage but filename of the picture is empty.");
                return null;
            }

            // Check if picture exists in cache.
            if (MemCache == null)
            {
                // Create cache options.
                MemoryCacheOptions mco = new MemoryCacheOptions();
                mco.ExpirationScanFrequency = ExpirationScanFrequency;

                // Create cache dictionary instance.
                MemCache = new MemoryCache(mco);
            }

            // Initialize bitmap image.
            BitmapImage bmp;

            // Set the cache key for the picture according to the width value.
            string key = filename + ":" + width.ToString();

            // Check if image is in cache.
            // Replace it if required.
            if (!MemCache.TryGetValue(key, out bmp) || replace)
            {
                // Load picture.
                bmp = GetPicture(filename);

                // Check if cache expiration is define.
                if (slidingExpiration.CompareTo(new TimeSpan()) == 0)
                {
                    slidingExpiration = SlidingExpiration;
                }

                // Set cahce lifetime for the picture.
                MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(slidingExpiration);

                // Add picture to memory cache.
                MemCache.Set(filename, bmp, cacheEntryOptions);
            }

            return bmp;
        }

        /// <summary>
        /// Method to load picture from disk.
        /// </summary>
        /// <param name="filename">The full path file name of the picture.</param>
        /// <param name="width">The width of the image.</param>
        /// <returns>A BitmapImage that contain the picture.</returns>
        public static BitmapImage GetPicture(string filename, int width = 512)
        {
            // Initialize bitmap image.
            BitmapImage src = new BitmapImage();

            // Try to create bitmap image from picture.
            try
            {
                if (string.IsNullOrWhiteSpace(filename))
                {
                    throw new ArgumentNullException(nameof(filename));
                }

                if (!Path.IsPathRooted(filename))
                {
                    filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                }

                if (!File.Exists(filename))
                {
                    throw new FileNotFoundException(filename);
                }

                src.BeginInit();
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.CreateOptions = BitmapCreateOptions.IgnoreImageCache | BitmapCreateOptions.PreservePixelFormat;
                src.UriSource = new Uri(@filename, UriKind.Absolute);
                src.DecodePixelWidth = width;
                src.EndInit();

                // Freeze picture if possible.
                if (!src.IsFrozen && src.CanFreeze)
                {
                    src.Freeze();
                }
            }

            // Catch create bitmap image fail.
            // Just log error but generate no new exception.
            catch(Exception e)
            {
                log.Error("filename = " + filename);
                log.Error("PictureMemoryCache try to create bitmap image but operation failed !", e);
            }

            return src;
        }

        /// <summary>
        /// Method to get picture stream from an url.
        /// </summary>
        /// <param name="url">The url of the picture.</param>
        /// <returns>A stream to the picture url.</returns>
        private static Stream GetStreamFromUrl(string url)
        {
            byte[] img = null;

            using (var wc = new WebClient())
            {
                img = wc.DownloadData(url);
            }

            return new MemoryStream(img);
        }

        #endregion
    }
}