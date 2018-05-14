using System.Globalization;
using System.Windows.Controls;

namespace XtrmAddons.Net.Windows.ValidationRules
{
    /// <summary>
    /// <para>Class XtrmAddons Net Windows Validation Rule String Password Required.</para>
    /// <para>Check if a formated string as Password is valid and not null, empty or whitespace.</para>
    /// </summary>
    public class StringRequiredPassword : ValidationRule
    {
        /// <summary>
        /// Static property to access or define the minimum password number of characters.
        /// </summary>
        public static int MinPasswordLength { get; set; } = 8;

        /// <summary>
        /// Method to validate rule to apply to the object.
        /// </summary>
        /// <param name="value">A string.</param>
        /// <param name="cultureInfo">The culture informations.</param>
        /// <returns>True if conditions are validated otherwise false.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;

            if (str.Length < MinPasswordLength)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "This Password is not not valid. You must provide at least 8 characters.");
            }
        }
    }
}