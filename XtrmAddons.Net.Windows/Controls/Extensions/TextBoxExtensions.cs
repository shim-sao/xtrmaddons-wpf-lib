using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace XtrmAddons.Net.Windows.Controls.Extensions
{
    /// <summary>
    /// Class XtrmAddons Windows Controls TextBox Extensions.
    /// </summary>
    public static class TextBoxExtensions
    {
        #region Methods

        /// <summary>
        /// Method to clear invalid TextBox base on DependencyProperty Binding.
        /// </summary>
        /// <param name="tb">The TextBox.</param>
        /// <param name="dp">A TextBox DependencyProperty where a Binding is attached.</param>
        public static void ValidationClear(this TextBox tb, DependencyProperty dp = null)
        {
            dp = dp ?? TextBox.TextProperty;
            Validation.ClearInvalid(BindingOperations.GetBindingExpression(tb, dp));
        }

        #endregion
    }
}
