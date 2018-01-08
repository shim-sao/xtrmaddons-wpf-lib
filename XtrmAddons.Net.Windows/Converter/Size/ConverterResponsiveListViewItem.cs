using System;
using System.Globalization;
using System.Windows.Data;

namespace XtrmAddons.Net.Windows.Converter.Size
{
    /// <summary>
    /// Class XtrmAddons Net UI Converter Responsive List View Item.
    /// </summary>
    public class ConverterResponsiveListViewItem : IValueConverter
    {
        /// <summary>
        /// Variable width margin.
        /// </summary>
        private int _margin = 10;

        /// <summary>
        /// Method to convert a list view item width.
        /// </summary>
        /// <param name="value">A list view object width.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">An additional string parameter to format date.</param>
        /// <param name="culture">Culture language to apply.</param>
        /// <returns>A responsive width for list view items.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // The value parameter is the data from the source object.
            double width = (double)value;
            int number = 0;

            if(parameter != null)
                number = (int)parameter;

            width = width - 15;

            if (number < 8)
                number = 8;

            if (width > 1600)
                width = (width / number) - _margin;

            else if (width > 1440)
                width = (width / (number - 1)) - _margin;

            else if (width > 1200)
                width = (width / (number - 2)) - _margin;

            else if (width > 1024)
                width = (width / (number - 3)) - _margin;

            else if (width > 800)
                width = (width / (number - 4)) - _margin;
            
            else if (width > 640)
                width = (width / (number - 5)) - _margin;

            else if (width > 360)
                width = (width / (number - 6)) - _margin;

            else
                width = width - _margin;

            return width;
        }

        /// <summary>
        ///  Method to convert back a list view item width.
        /// </summary>
        /// <param name="value">A list view object width.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">An additional string parameter to format date.</param>
        /// <param name="culture">Culture language to apply.</param>
        /// <returns>throw Not Implemented Exception.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}