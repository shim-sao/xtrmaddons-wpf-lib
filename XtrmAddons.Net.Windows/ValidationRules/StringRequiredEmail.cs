using System.Globalization;
using System.Windows.Controls;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Windows.ValidationRules
{
    /// <summary>
    /// <para>Class XtrmAddons Net Windows Validation Rule String Required.</para>
    /// <para>Check if a formated string as email is valid and not null, empty or whitespace.</para>
    /// </summary>
    public class StringRequiredEmail : ValidationRule
    {
        /// <summary>
        /// Method to validate rule to apply to the object.
        /// </summary>
        /// <param name="value">A string.</param>
        /// <param name="cultureInfo">The culture informations.</param>
        /// <returns>True if conditions are validated otherwise false.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;

            if (str.IsValidEmail())
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "This email is not not valid.");
            }
        }
    }
}