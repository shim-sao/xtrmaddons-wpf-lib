using System.Windows.Controls;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Windows.ValidationRules
{
    /// <summary>
    /// <para>Class XtrmAddons Net Windows Validation Rule String Required Alias.</para>
    /// <para>Check if a formated string as alias is not null, empty or whitespace.</para>
    /// </summary>
    public class StringRequiredAlias : ValidationRule
    {
        /// <summary>
        /// Method to validate rule to apply to the object.
        /// </summary>
        /// <param name="value">A string.</param>
        /// <param name="cultureInfo">The culture informations.</param>
        /// <returns>True if conditions are validated otherwise false.</returns>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = value as string;
            str = str.Sanitize().RemoveDiacritics().ToLower();

            if (str.IsNotNullOrWhiteSpace())
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Value must not be null, empty or whitespace.");
            }
        }
    }
}