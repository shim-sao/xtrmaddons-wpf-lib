using System;
using System.Globalization;
using System.Windows.Data;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Windows.Converter.String
{
    /// <summary>
    /// Class XtrmAddons Net UI Converter string to UCFirst.
    /// </summary>
    public class ConverterUCFirst : IValueConverter
    {
        /// <summary>
        /// Method to convert string to UCFirst.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Return string as UCFirst (same as PHP method)
            return ((string)value).UCFirst();
        }

        /// <summary>
        /// Method to back convert string to UCFirst.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}