
using System;
using System.Dynamic;
using System.IO;
using System.Windows.Media.Imaging;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Picture
{
    /// <summary>
    /// Class XtrmAddons Net Picture Meta Data.
    /// </summary>
    public class PictureMeta
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
        /// Property to acces to the Picture file name.
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// Property to acces Picture Meta Data informations.
        /// </summary>
        public dynamic Data { get; } = new ExpandoObject();

        /// <summary>
        /// Property to acces Picture Meta Data informations.
        /// </summary>
        public BitmapMetadata Metadata { get; }

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Picture Meta Data Constructor.
        /// </summary>
        /// <param name="str"></param>
        public PictureMeta(string str)
        {
            Filename = str;
            Initialize();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to initialize Picture Meta Data informations.
        /// </summary>
        /// <exception cref="ArgumentNullException">Occurs when invalid argument Picture file name is passed. Filename must be not null or empty or whitespace.</exception>
        /// <exception cref="FileFormatException">Occurs when loading meta data failed.</exception>
        private void Initialize()
        {
            if (Filename.IsNullOrWhiteSpace())
            {
                ArgumentNullException e = new ArgumentNullException($"Invalid argument Picture file name [{Filename}]. Filename must be not null or empty or whitespace.");
                log.Error(e.Output(), e);
                throw e;
            }

            Data.Filename = Filename;
            Data.Comment = "";
            Data.Copyright = "";
            Data.DateTaken = "";
            Data.Rating = 0;
            Data.Title = "";

            Data.Format = new System.Windows.Media.PixelFormat();
            Data.Height = 0;
            Data.Width = 0;
            Data.PixelHeight = 0;
            Data.PixelWidth = 0;
            Data.Length = 0;

            try
            {
                // open a filestream for the file we wish to look at
                using (Stream fs = File.Open(Filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    Data.Length = fs.Length;

                    // create a decoder to parse the file
                    BitmapDecoder decoder = BitmapDecoder.Create(fs, BitmapCreateOptions.None, BitmapCacheOption.Default);

                    if(decoder == null || decoder.Frames.Count == 0)
                    {
                        log.Error("Creating bipmap decoder : failed ! ");
                        return;
                    }

                    // grab the bitmap frame, which contains the metadata
                    BitmapFrame frame = decoder.Frames[0];

                    if (frame == null)
                    {
                        log.Error("Getting bipmap decoder frame : failed ! ");
                        return;
                    }

                    Data.Format = frame.Format;
                    Data.Height = frame.Height;
                    Data.Width = frame.Width;
                    Data.PixelHeight = frame.PixelHeight;
                    Data.PixelWidth = frame.PixelWidth;

                    // get the metadata as BitmapMetadata
                    BitmapMetadata bmp = frame.Metadata as BitmapMetadata;
                    
                    if(bmp == null)
                    {
                        log.Error("Getting bipmap metadata : failed ! ");
                        Data.DateTaken = new FileInfo(Filename).CreationTime.ToString();
                        return;
                    }

                    Data.Title = bmp.Title ?? Path.GetFileName(Filename);
                    Data.DateTaken = bmp.DateTaken;
                    Data.Copyright = bmp.Copyright;
                    Data.Comment = bmp.Comment;
                    Data.Rating = bmp.Rating;
                }
            }
            catch(Exception e)
            {
                throw new FileFormatException("initializing picture meta data informations : failed !", e);
            }
        }

        #endregion
    }
}
