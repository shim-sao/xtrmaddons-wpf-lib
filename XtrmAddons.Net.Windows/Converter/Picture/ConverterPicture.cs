using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using XtrmAddons.Net.Picture;
using XtrmAddons.Net.Picture.Extensions;
using XtrmAddons.Net.Picture.ExtractLargeIconFromFile;

namespace XtrmAddons.Net.Windows.Converter.Picture
{
    /// <summary>
    /// <para>Class Net UI Converter Picture Base.</para>
    /// </summary>
    public class ConverterPictureBase : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public static string[] Extensions { get; set; } = { ".jpg", ".jpeg", ".png", ".bmp", ".tiff" };

        /// <summary>
        /// 
        /// </summary>
        public static int Width { get; set; } = 512;

        /// <summary>
        /// 
        /// </summary>
        public static ShellEx.IconSizeEnum IconSize { get; set; } = ShellEx.IconSizeEnum.ExtraLargeIcon;


        /// <summary>
        /// Method to convert string path of the picture into bitmap image. 
        /// </summary>
        /// <param name="value">The binding object path of the picture.</param>
        /// <param name="targetType">The target type for binding.</param>
        /// <param name="parameter">Parameter for convert.</param>
        /// <param name="culture">The culture to convert.</param>
        /// <returns>A bitmap image for image binding.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // The value parameter is the data from the source object.
            string filename = (string)value;
            string ext = Path.GetExtension(filename);
            BitmapImage bmp = null;

            try
            {
                if (Extensions.Contains(ext))
                {
                    if (parameter != null)
                    {
                        Width = int.Parse((string)parameter);
                    }

                    bmp = PictureMemoryCache.Set(filename, Width, false);
                }
                else
                {
                    bmp = ShellEx.GetBitmapFromFilePath(filename, IconSize).ToBitmapImage();
                }
            }
            catch { }

            return bmp;
        }

        /// <summary>
        /// Method to convert bitmap image into string path of the picture. 
        /// </summary>
        /// <param name="value">The binding object path of the picture.</param>
        /// <param name="targetType">The target type for binding.</param>
        /// <param name="parameter">Parameter for convert.</param>
        /// <param name="culture">The culture to convert.</param>
        /// <returns>throw Not Implemented Exception.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}