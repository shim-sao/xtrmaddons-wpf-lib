using System.Windows.Media;

namespace XtrmAddons.Net.Windows.Tools
{
    /// <summary>
    /// Class XtrmAddons Net UI Tools WPF Color Hex.
    /// </summary>
    public class WPFColorHex
    {
        /// <summary>
        /// Method to convert hexadecimal color to brush.
        /// </summary>
        /// <param name="hexadecimal">hexadecimal color. ex: #000000</param>
        /// <returns>Brush that corresponding to color else null on bad format string.</returns>
        public static Brush ColorToBrush(string hexadecimal)
        {
            if (hexadecimal.Length == 7)
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom(hexadecimal));
            }
            else
            {
                return null;
            }
        }
    }
}
