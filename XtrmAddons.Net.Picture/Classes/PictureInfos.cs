using System;
using System.Windows.Media.Imaging;

namespace XtrmAddons.Net.Picture
{
    /// <summary>
    /// Class XtrmAddons Net Picture Infos
    /// </summary>
    public class PictureInfos
    {
        #region Variables

        /// <summary>
        /// Variable original bitmap image.
        /// </summary>
        protected BitmapImage bmpOriginal;

        /// <summary>
        /// Variable preview bitmap image.
        /// </summary>
        protected BitmapImage bmpPreview;

        /// <summary>
        /// Variable thumbnail bitmap image.
        /// </summary>
        protected BitmapImage bmpThumbnail;

        #endregion



        #region Properties

        /// <summary>
        /// Property name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property is default item.
        /// </summary>
        public bool Default { get; set; }

        /// <summary>
        /// Property order place of the item.
        /// </summary>
        public int Ordering { get; set; }

        /// <summary>
        /// Property created date.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Property modified date.
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Property picture date taken.
        /// </summary>
        public DateTime DateTaken { get; set; }

        /// <summary>
        /// Property the original picture.
        /// </summary>
        public string OriginalPath { get; set; }

        /// <summary>
        /// Property the original picture width.
        /// </summary>
        public int OriginalWidth { get; set; }

        /// <summary>
        /// Property the original picture height.
        /// </summary>
        public int OriginalHeight { get; set; }

        /// <summary>
        /// Property the preview picture path.
        /// </summary>
        public string PreviewPath { get; set; }

        /// <summary>
        /// Property the preview picture width.
        /// </summary>
        public int PreviewWidth { get; set; }

        /// <summary>
        /// Property the preview picture height.
        /// </summary>
        public int PreviewHeight { get; set; }

        /// <summary>
        /// Property the thumbnail picture path.
        /// </summary>
        public string ThumbnailPath { get; set; }

        /// <summary>
        /// Property the thumbnail width.
        /// </summary>
        public int ThumbnailWidth { get; set; }

        /// <summary>
        /// Property the thumbnail height.
        /// </summary>
        public int ThumbnailHeight { get; set; }

        /// <summary>
        /// Property picture description.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Property to access to the thumbnail image.
        /// </summary>
        public virtual BitmapImage Thumbnail
        {
            get => PictureMemoryCache.GetPicture(ThumbnailPath, ThumbnailWidth);
            set => bmpThumbnail = value;
        }

        /// <summary>
        /// Property to access to the image.
        /// </summary>
        public virtual BitmapImage Original
        {
            get => PictureMemoryCache.GetPicture(OriginalPath, OriginalWidth);
            set => bmpOriginal = value;
        }

        /// <summary>
        /// Property to access to the resized image.
        /// </summary>
        public virtual BitmapImage Preview
        {
            get => PictureMemoryCache.GetPicture(PreviewPath, PreviewWidth);
            set => bmpPreview = value;
        }

        #endregion
    }
}
