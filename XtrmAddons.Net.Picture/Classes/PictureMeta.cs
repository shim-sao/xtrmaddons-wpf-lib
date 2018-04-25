
using System;
using System.Dynamic;
using System.IO;
using System.Windows.Media.Imaging;

namespace XtrmAddons.Net.Picture
{
    /// <summary>
    /// Class XtrmAddons Net Picture Meta Data.
    /// </summary>
    public class PictureMeta
    {
        #region Properties

        /// <summary>
        /// Property to acces to the Picture file name.
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// Property to acces Picture Meta Data informations.
        /// </summary>
        public dynamic Data { get; } = new ExpandoObject();

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
            if (string.IsNullOrEmpty(Filename.Replace(" ", "")))
            {
                throw new ArgumentNullException(string.Format("Invalid argument Picture file name [{0}]. Filename must be not null or empty or whitespace.", Filename));
            }

            try
            {
                // open a filestream for the file we wish to look at
                using (Stream fs = File.Open(Filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    // create a decoder to parse the file
                    BitmapDecoder decoder = BitmapDecoder.Create(fs, BitmapCreateOptions.None, BitmapCacheOption.Default);

                    // grab the bitmap frame, which contains the metadata
                    BitmapFrame frame = decoder.Frames[0];

                    // get the metadata as BitmapMetadata
                    BitmapMetadata bmp = frame.Metadata as BitmapMetadata;

                    Data.Comment = bmp.Comment;
                    Data.Copyright = bmp.Copyright;
                    Data.DateTaken = bmp.DateTaken;
                    Data.Rating = bmp.Rating;
                    Data.Title = bmp.Title ?? Path.GetFileName(Filename);

                    Data.Format = frame.Format;
                    Data.Height = frame.Height;
                    Data.Width = frame.Width;
                    Data.PixelHeight = frame.PixelHeight;
                    Data.PixelWidth = frame.PixelWidth;
                    Data.Filename = Filename;
                    Data.Length = fs.Length;
                }
            }
            catch(Exception e)
            {
                throw new FileFormatException("Picture initialize meta data informations failed !", e);
            }
        }

        #endregion
    }
}
