using System;
using System.Globalization;
using System.Windows.Data;

namespace XtrmAddons.Net.Windows.Converter.Date
{
    /// <summary>
    /// Class XtrmAddons Net UI DateTime Converter.
    /// </summary>
    public class ConverterDate : IValueConverter
    {
        /// <summary>
        /// Method to convert DatTime to string according format parameter.
        /// </summary>
        /// <param name="value">A DateTime object.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">An additional string parameter to format date. Use ConverterDate.Properties</param>
        /// <param name="culture">Culture language to apply.</param>
        /// <returns>A formatted date string.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            string format = (string)parameter;

            switch (format)
            {
                case "DateSQL":
                    return date.ToString("yyyy-MM-dd") + " " + date.ToString("HH:mm:ss");

                case "DateLong":
                    return date.ToString("dddd d MMMM yyyy");

                case "DateTimeLong":
                    return date.ToString("dddd d MMMM yyyy") + " " + date.ToString("HH:mm:ss");

                case "Time":
                    return date.ToString("HH:mm:ss");

            }

            return date.ToString("yyyy-MM-dd") + " " + date.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Method to back convert DatTime to string.
        /// </summary>
        /// <param name="value">A DateTime object.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">An additional string parameter to format date. Use ConverterDate.Properties</param>
        /// <param name="culture">Culture language to apply.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}