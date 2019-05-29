using Microsoft.Extensions.Caching.Memory;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Media.Imaging;
using XtrmAddons.Net.Common.Extensions;

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
        /// <param name="isHttp">Define if immage is an Http request.</param>
        /// <returns>A Bitmap Image.</returns>
        public static BitmapImage Get(string filename, int width = 512, bool replace = false, bool isHttp = false)
        {
            return Set(filename, width, replace, new TimeSpan(), isHttp);
        }

        /// <summary>
        /// Method to set a picture into memory cache.
        /// </summary>
        /// <param name="filename">The full path file name of the picture.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="replace">Force to load and replace picture in memory.</param>
        /// <param name="slidingExpiration">Define the time span sliding expiration..</param>
        /// <returns>A Bitmap Image.</returns>
        public static BitmapImage Set(string filename, int width = 512, bool replace = false, TimeSpan slidingExpiration = new TimeSpan(), bool isHttp = false)
        {
            // Check if filename is empty.
            // Just log error but generate no exception.
            if (string.IsNullOrWhiteSpace(filename))
            {
                log.Error("PictureMemoryCache try to set BitmapImage but filename of the picture is empty.");
                return null;
            }

            InitializeCacheOptions();

            // Initialize bitmap image.
            BitmapImage bmp;

            // Set the cache key for the picture according to the width value.
            string key = filename + ":" + width.ToString();

            // Check if image is in cache.
            // Replace it if required.
            if (!MemCache.TryGetValue(key, out bmp) || replace)
            {
                // Load picture.
                bmp = GetPicture(filename, width, isHttp);

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
        /// Method to initialize memory cache with options...
        /// </summary>
        private static void InitializeCacheOptions()
        {
            // Check if picture exists in cache.
            if (MemCache == null)
            {
                // Create cache options.
                MemoryCacheOptions mco = new MemoryCacheOptions
                {
                    ExpirationScanFrequency = ExpirationScanFrequency
                };

                // Create cache dictionary instance.
                MemCache = new MemoryCache(mco);
            }
        }

        /// <summary>
        /// Method to load picture from disk.
        /// </summary>
        /// <param name="filename">The full path file name of the picture.</param>
        /// <param name="width">The width of the image.</param>
        /// <param name="isHttp">Is Http filename Url ?.</param>
        /// <returns>A BitmapImage that contain the picture.</returns>
        public static BitmapImage GetPicture(string filename, int width = 512, bool isHttp = false)
        {
            // Initialize bitmap image.
            BitmapImage src = new BitmapImage();

            // Try to create bitmap image from picture.
            try
            {
                log.Debug($"{typeof(PictureMemoryCache).Name}.{MethodBase.GetCurrentMethod().Name} : Creating bitmap image from picture.");

                if (string.IsNullOrWhiteSpace(filename))
                {
                    ArgumentNullException e = new ArgumentNullException(nameof(filename));
                    log.Error(e.Output(), e);

                    return src;
                }

                if (!Path.IsPathRooted(filename) && !isHttp)
                {
                    filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                }

                if (!File.Exists(filename) && !isHttp)
                {
                    FileNotFoundException e = new FileNotFoundException("File not found :", filename);
                    log.Error(e.Output(), e);

                    return src;
                }

                log.Debug($"{typeof(PictureMemoryCache).Name}.{MethodBase.GetCurrentMethod().Name} : {filename}");

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
                    log.Debug($"{typeof(PictureMemoryCache).Name}.{MethodBase.GetCurrentMethod().Name} : Freezing Picture => done.");
                }
            }

            // Catch create bitmap image fail.
            // Just log error but generate no new exception.
            catch(Exception e)
            {
                log.Error("PictureMemoryCache try to create bitmap image but operation failed !", e);
                log.Error("filename : " + filename);
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

        /// <summary>
        /// Method to reset memory cache.
        /// </summary>
        public static void Clear()
        {
            if (MemCache != null)
            {
                MemCache.Dispose();
                MemCache = null;
            }
        }

        #endregion
    }
}