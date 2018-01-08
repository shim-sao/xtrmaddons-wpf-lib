using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XtrmAddons.Net.Windows.Converter.Boolean
{
    /// <summary>
    /// <para>Class XtrmAddons Net UI Converter Boolean to visibility.</para>
    /// </summary>
    public class ConverterVisibility : IValueConverter
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
            bool val = (bool)value;

            if (val)
            {
                return Visibility.Visible;
            }

            return Visibility.Hidden;
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