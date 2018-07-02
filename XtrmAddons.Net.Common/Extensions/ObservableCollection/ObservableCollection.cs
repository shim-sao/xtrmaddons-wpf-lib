using System;
using System.Collections.Generic;
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
        #region Variables
        
        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
        	log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        #endregion



        #region Methods

        /// <summary>
        /// Method to check if an item exists with the predicate paste in argument.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to search in.</param>
        /// <param name="predicate">The predicate matching to check.</param>
        /// <returns>True if an item or more is found otherwise false.</returns>
        public static bool Exists<T>(this ObservableCollection<T> collection, Predicate<T> predicate)
        {
            if (predicate == null)
            {
                ArgumentNullException e = new ArgumentNullException($"'{nameof(predicate)}' type of '{typeof(Predicate<T>)}' must not be null.");
                log.Error(e.Output(), e);
                throw e;
            }

            return collection.ToList().Exists(predicate);
        }

        /// <summary>
        /// Method to check if an item exists with the predicate paste in argument.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to search in.</param>
        /// <param name="match">The predicate matching to check.</param>
        /// <returns>True if an item or more is found otherwise false.</returns>
        public static bool Exists<T>(this ObservableCollection<T> collection, Func<T, bool> match)
        {
            if (match == null)
            {
                ArgumentNullException e = new ArgumentNullException($"'{nameof(match)}' type of '{typeof(Predicate<T>)}' must not be null.");
                log.Error(e.Output(), e);
                throw e;
            }

            return collection.Exists(new Predicate<T>(match));
        }
        
        /// <summary>
        /// Method to add an item to the collection if the item not already exists with the predicate paste in argument.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to search in and add in.</param>
        /// <param name="item">The object to add to the collection.</param>
        /// <param name="predicate">The predicate matching to check.</param>
        /// <returns>The updated collection.</returns>
        /// <exception cref="InvalidOperationException">Occurs if the predicate argument is null.</exception>
        public static ObservableCollection<T> AddIfNotExists<T>(this ObservableCollection<T> collection, T item, Predicate<T> predicate)
        {
            try
            {
                if (collection.Exists(predicate) == false)
                {
                    collection.Add(item);
                }
            }
            catch (ArgumentNullException e)
            {
                ArgumentNullException ex = new ArgumentNullException($"An Exception occurs while adding object to the collection.", e);
                log.Error(ex.Output());
                log.Error(e.Output(), e);
                throw ex;
            }
            catch (Exception e)
            {
                InvalidOperationException ex = new InvalidOperationException($"An Exception occurs while adding object to the collection.", e);
                log.Error(ex.Output());
                log.Error(e.Output(), e);
                throw ex;
            }

            return collection;
        }

        /// <summary>
        /// Method to add an item to the collection if the item not already exists with the predicate paste in argument.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to search in and add in.</param>
        /// <param name="item">The object to add to the collection.</param>
        /// <param name="match">The predicate matching to check.</param>
        /// <returns>The updated collection.</returns>
        /// <exception cref="InvalidOperationException">Occurs if the match argument is null.</exception>
        public static ObservableCollection<T> AddIfNotExists<T>(this ObservableCollection<T> collection, T item, Func<T, bool> match)
        {
            return AddIfNotExists(collection, item, new Predicate<T>(match));
        }

        /// <summary>
        /// Method to clear and add a new collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to add in new objects.</param>
        /// <param name="items">The items to add into the collection.</param>
        /// <returns>The updated collection.</returns>
        public static ObservableCollection<T> ClearAndAdd<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            // Clear the colletion before adding.
            collection.Clear();

            // Check if the list of items is not null.
            // Add new items into the collection.
            if (items != null)
            {
                foreach (var item in items)
                {
                    collection.Add(item);
                }

            }

            return collection;
        }

        #endregion
    }
}