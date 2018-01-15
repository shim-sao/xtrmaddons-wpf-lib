using System.Collections.Generic;

namespace XtrmAddons.Net.Application.Serializable.Interfaces
{
    /// <summary>
    /// Interface XtrmAddons Net Application Serializable Elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializableElements<T>
    {
        #region Properties

        /// <summary>
        /// Property list of elements.
        /// </summary>
        List<T> Elements { get; set; }

        #endregion



        #region Methods

        /// <summary>
        /// Method to find an element by property value.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value to search.</param>
        /// <returns>The founded element otherwise default element or null if element type is nullable.</returns>
        T Find(string propertyName, object value);

        /// <summary>
        /// Method to find an element by its Key property value.
        /// </summary>
        /// <param name="value">The Key value to search.</param>
        /// <returns>The founded element otherwise default element or null if element type is nullable.</returns>
        T Find(object value);

        /// <summary>
        /// Method to find default set element.
        /// </summary>
        /// <returns>The founded element otherwise default element or null if element type is nullable.</returns>
        T Default();

        /// <summary>
        /// Method to add a new element into the list.
        /// </summary>
        /// <param name="item">The element to add.</param>
        void Add(T item);

        /// <summary>
        /// Method to remove an element from the list.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        void Remove(T item);

        /// <summary>
        /// Method to update an element in the list.
        /// </summary>
        /// <param name="item">The element to update.</param>
        void Update(T item);

        #endregion
    }
}
