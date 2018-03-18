using System;
using System.Globalization;
using System.Windows.Data;
using XtrmAddons.Net.Picture.Extensions;
using XtrmAddons.Net.Picture.ExtractLargeIconFromFile;

namespace XtrmAddons.Net.Windows.Converter.Picture
{
    /// <summary>
    /// <para>Class Net UI Converter Picture Base.</para>
    /// </summary>
    public class ConverterExtractLargeIconFromFile : IValueConverter
    {
        /// <summary>
        /// Method to convert string path of the file into bitmap image. 
        /// </summary>
        /// <param name="value">The binding object path of the picture.</param>
        /// <param name="targetType">The target type for binding.</param>
        /// <param name="parameter">Parameter for convert.</param>
        /// <param name="culture">The culture to convert.</param>
        /// <returns>A bitmap image for image binding.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var size = ShellEx.IconSizeEnum.ExtraLargeIcon;
            return ShellEx.GetBitmapFromFilePath((string)value, size).ToBitmapImage();
        }

        /// <summary>
        /// Method to convert bitmap image into string path of the file. 
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