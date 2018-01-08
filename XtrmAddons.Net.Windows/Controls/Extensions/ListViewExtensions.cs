using System.Windows.Controls;
using System.Windows.Input;

namespace XtrmAddons.Net.Windows.Controls.Extensions
{
    /// <summary>
    /// Class XtrmAddons UIElement Extension
    /// </summary>
    public static class ListViewExtensions
    {
        #region Methods

        /// <summary>
        /// Method to select all items with Ctrl+A
        /// </summary>
        /// <param name="lv">The List View.</param>
        /// <param name="e">The key event arguments.</param>
        public static void AddKeyDownSelectAllItems(this ListView lv, KeyEventArgs e)
        {
            if (e.Key == Key.A && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                lv.SelectionMode = SelectionMode.Multiple;
                foreach (ListViewItem item in lv.Items)
                {
                    item.IsSelected = true;
                }
            }
        }

        #endregion
    }
}