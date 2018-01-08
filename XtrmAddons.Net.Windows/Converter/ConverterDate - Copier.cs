using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFXA.Net.UI.Converter
{
    /// <summary>
    /// Class WPFXA PhotoAlbum Server UI Converter DateTime to Sql.
    /// </summary>
    public class ConverterDate : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // The value parameter is the data from the source object.
            ConvertibleDate date = (ConvertibleDate)value;

           // AppDomain.CurrentDomain.

            return date.DateToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ConvertibleDate
    {

        public ConvertibleDate(DateTime date)
        {
            Date = date;
            Format = ConvertibleDateFormat.SQL;
        }

        public ConvertibleDate(DateTime date, ConvertibleDateFormat format)
        {
            Date = date;
            Format = format;
        }

        public DateTime Date { get; set; }

        public ConvertibleDateFormat Format { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DateToString()
        {
            switch(Format)
            {
                case ConvertibleDateFormat.SQL:
                    return Date.ToString("yyyy-MM-dd") + " " + Date.ToString("HH:mm:ss");

                case ConvertibleDateFormat.DateLong:
                    return Date.ToString("dddd d MMMM yyyy");

                case ConvertibleDateFormat.DateTimeLong:
                    return Date.ToString("dddd d MMMM yyyy") + " " + Date.ToString("HH:mm:ss");

            }

            return Date.ToString("yyyy-MM-dd") + " " + Date.ToString("HH:mm:ss");
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public enum ConvertibleDateFormat
    {
        SQL,

        DateLong,

        DateTimeLong,

        DateBrTimeLong
    }
}