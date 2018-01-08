using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using XtrmAddons.Net.Picture;

namespace XtrmAddons.Net.Windows.Converter.Picture
{
    /// <summary>
    /// <para>Class Net UI Converter Picture Base.</para>
    /// </summary>
    public class ConverterPictureBase : IValueConverter
    {
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
            int width = 512;

            if (parameter != null)
            {
                width = int.Parse((string)parameter);
            }

            BitmapImage bmp = PictureMemoryCache.Set(filename, width, false);

            if (bmp == null)
            {
                /*if (string.IsNullOrWhiteSpace(filename))
                {
                    var a = MainSettings.Application.Settings;
                    filename = MainSettings.Settings["assets.images.default.picture"];
                    bmp = PictureMemoryCache.Set(filename, width);
                }*/
            }

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