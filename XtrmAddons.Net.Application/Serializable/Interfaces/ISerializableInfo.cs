using System.Collections.Generic;

namespace XtrmAddons.Net.Application.Serializable.Interfaces
{
    /// <summary>
    /// Interface XtrmAddons Net Application Serializable Elements Informations List.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializableInfo<T>
    {
        #region Methods

        /// <summary>
        /// Method to find an element by its Key property value.
        /// </summary>
        /// <param name="key">The Key value to search.</param>
        /// <returns>The founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        T FindKey(string key);

        /// <summary>
        /// Method to find all elements by a Key property value.
        /// </summary>
        /// <param name="key">The Key value to search.</param>
        /// <returns>The founded list of elements otherwise, default empty List.</returns>
        List<T> FindKeyAll(string key);

        /// <summary>
        /// Method to find the first element found flagged to default.
        /// </summary>
        /// <returns>The founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        T FindDefault();

        /// <summary>
        /// Method to find all elements found flagged to default.
        /// </summary>
        /// <returns>The founded elements otherwise, default empty List.</returns>
        List<T> FindAllDefault();

        /// <summary>
        /// Method to add a new unique default element into the list.
        /// </summary>
        /// <param name="item">The element to add.</param>
        void AddDefaultUnique(T element);

        /// <summary>
        /// <para>Method to add or update an element by its Key property value.</para>
        /// <para>Update element with the same Key if is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update.</param>
        void ReplaceKey(T element);

        /// <summary>
        /// <para>Method to add or update an element by its Key property value. Also flag it by unique default.</para>
        /// <para>Update element with the same Key if is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update and flag it by unique default.</param>
        void ReplaceKeyDefaultUnique(T element);

        /// <summary>
        /// Method to flag all elements default to false or none.
        /// </summary>
        void SetAllDefaultNone();

        /// <summary>
        /// Method to flag all elements default to true or yes.
        /// </summary>
        void SetAllDefault();

        #endregion
    }
}
