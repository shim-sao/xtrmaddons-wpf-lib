using System.Windows.Controls;

namespace XtrmAddons.Net.Controls.ListView.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Controls ListView Extensions.
    /// </summary>
    public static class ListViewExtensions
    {
        /// <summary>
        /// Method to get tree view root as TreeViewItem for an TreeViewItem.
        /// </summary>
        /// <param name="item">A TreeViewItem.</param>
        /// <returns>The root as TreeViewItem of the TreeViewItem.</returns>
        public static TreeViewItem GetTreeViewItemRoot(this TreeViewItem item)
        {
            TreeViewItem parent = GetTreeViewItemParent(item);

            while (parent != null)
            {
                parent = GetTreeViewItemParent(parent);
            }

            return parent;
        }

        /// <summary>
        /// Method to get tree view parent as TreeViewItem for an TreeViewItem.
        /// </summary>
        /// <param name="item">A tree view item.</param>
        /// <returns>The parent as TreeViewItem of the TreeViewItem.</returns>
        public static TreeViewItem GetTreeViewItemParent(this TreeViewItem item)
        {
            TreeViewItem parent = null;

            if (item.Parent != null && item.Parent.GetType() == typeof(TreeViewItem))
            {
                parent = (TreeViewItem)item.Parent;
            }

            return parent;
        }
    }
}
