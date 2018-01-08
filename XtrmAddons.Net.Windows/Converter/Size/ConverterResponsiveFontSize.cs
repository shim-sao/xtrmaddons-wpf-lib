using System;
using System.Globalization;
using System.Windows.Data;

namespace XtrmAddons.Net.Windows.Converter.Size
{
    /// <summary>
    /// Class XtrmAddons Net UI Converter Responsive Font Size.
    /// </summary>
    public class ConverterResponsiveFontSize : IValueConverter
    {
        /// <summary>
        /// Variable font size.
        /// </summary>
        private double fontSize = 34;

        /// <summary>
        /// Method to convert element width.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // The value parameter is the data from the source object.
            double width = (double)value;

            if (width > 1600)
                fontSize = 32;

            else if (width > 1440)
                fontSize = 34;

            else if (width > 1200)
                fontSize = 36;

            else if (width > 990)
                fontSize = 38;

            else if (width > 768)
                fontSize = 40;

            else if (width > 640)
                fontSize = 42;

            else
                fontSize = 44;

            return fontSize;
        }

        /// <summary>
        ///  Method to convert back element width.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // The value parameter is the data from the source object.
            double width = (double)value;

            return fontSize;
        }
    }
}