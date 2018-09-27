using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XtrmAddons.Net.Windows.Converter.Boolean
{
    /// <summary>
    /// <para>Class XtrmAddons Net UI Converter Integer to Boolean.</para>
    /// </summary>
    public class ConverterIntToBool : IValueConverter
    {
        /// <summary>
        /// Method to convert an integer to boolean. 
        /// </summary>
        /// <param name="value">The binding object path of the picture.</param>
        /// <param name="targetType">The target type for binding.</param>
        /// <param name="parameter">Parameter for convert.</param>
        /// <param name="culture">The culture to convert.</param>
        /// <returns>A bitmap image for image binding.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value != 0;
        }

        /// <summary>
        /// Method to convert back convert an integer to boolean.
        /// </summary>
        /// <param name="value">The binding object path of the picture.</param>
        /// <param name="targetType">The target type for binding.</param>
        /// <param name="parameter">Parameter for convert.</param>
        /// <param name="culture">The culture to convert.</param>
        /// <returns>throw Not Implemented Exception.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 1 : 0;
        }
    }
}