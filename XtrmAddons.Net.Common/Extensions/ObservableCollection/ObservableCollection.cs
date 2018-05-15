using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// <para>Class XtrmAddons Net Common ObservableCollection Extensions.</para>
    /// <para>This Class add some methods to ObservableCollection by extension.</para>
    /// </summary>
    public static class ObservableCollectionExtension
    {
        #region Methods

        /// <summary>
        /// Method to check if an item exists with the predicate paste in argument.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to search in.</param>
        /// <param name="predicate">The predicate matching to check.</param>
        /// <returns>True if an item or more is found otherwise false.</returns>
        public static bool Exists<T>(this ObservableCollection<T> collection, Predicate<T> predicate) where T : class
        {
            return collection.ToList().Exists(predicate);
        }

        /// <summary>
        /// Method to check if an item exists with the predicate paste in argument.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to search in.</param>
        /// <param name="match">The predicate matching to check.</param>
        /// <returns>True if an item or more is found otherwise false.</returns>
        public static bool Exists<T>(this ObservableCollection<T> collection, Func<T, bool> match) where T : class
        {
            return collection.Exists(new Predicate<T>(match));
        }

        #endregion
    }
}