using System;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Interfaces;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Elements Base.
    /// </summary>
    public abstract class ElementsBase<T> : List<T>, ISerializableInfo<T>
    {
        #region constructor

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Elements Base.
        /// </summary>
        public ElementsBase() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Elements Base.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public ElementsBase(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Elements Base.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public ElementsBase(IEnumerable<T> collection) : base(collection) { }

        #endregion



        #region Methods

        /// <summary>
        /// Method to find an element by its Key property value.
        /// </summary>
        /// <param name="key">The Key value to search.</param>
        /// <returns>The founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        public T FindKey(string key)
        {
            return Find(x => x.GetPropertyValue("Key").Equals(key));
        }

        /// <summary>
        /// Method to find all elements by a Key property value.
        /// </summary>
        /// <param name="key">The Key value to search.</param>
        /// <returns>The founded list of elements otherwise, default empty List.</returns>
        public List<T> FindKeyAll(string key)
        {
            return FindAll(x => x.GetPropertyValue("Key").Equals(key));
        }

        /// <summary>
        /// <para>Method to add or update an element by its Key property value.</para>
        /// <para>Update element with the same Key if is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update.</param>
        public void ReplaceKey(T element)
        {
            Predicate<T> match = x => x.GetPropertyValue("Key").Equals(element.GetPropertyValue("Key"));
            
            if (Find(match) != null)
            {
                Insert(FindIndex(match), element);
            }
            else
            {
                Add(element);
            }
        }

        /// <summary>
        /// <para>Method to add or update an element by its Key property value. Also flag it by unique default.</para>
        /// <para>Update element with the same Key if is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update and flag it by unique default.</param>
        public void ReplaceKeyDefaultUnique(T element)
        {
            SetAllDefaultNone();
            element.SetPropertyValue("Default", true);
            ReplaceKey(element);
        }

        /// <summary>
        /// Method to find the first element found flagged to default.
        /// </summary>
        /// <returns>The founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        public T FindDefault()
        {
            return Find(x => x.GetPropertyValue("Default").Equals(true));
        }

        /// <summary>
        /// Method to find all elements found flagged to default.
        /// </summary>
        /// <returns>The founded elements otherwise, default empty List.</returns>
        public List<T> FindAllDefault()
        {
            return FindAll(x => x.GetPropertyValue("Default").Equals(true));
        }

        /// <summary>
        /// Method to add a new unique default element into the list.
        /// </summary>
        /// <param name="item">The element to add.</param>
        public void AddDefaultUnique(T item)
        {
            SetAllDefaultNone();
            item.SetPropertyValue("Default", true);
            Add(item);
        }

        /// <summary>
        /// Method to flag all elements default to false or none.
        /// </summary>
        public void SetAllDefaultNone()
        {
            List<T> defaultElements = FindAllDefault();
            foreach (T e in defaultElements)
            {
                e.SetPropertyValue("Default", false);
            }
        }

        /// <summary>
        /// Method to flag all elements default to true or yes.
        /// </summary>
        public void SetAllDefault()
        {
            List<T> defaultElements = FindAllDefault();
            foreach (T e in defaultElements)
            {
                e.SetPropertyValue("Default", true);
            }
        }

        #endregion
    }
}