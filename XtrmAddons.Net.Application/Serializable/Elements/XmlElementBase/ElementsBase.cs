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
        /// <param name="field">The name of the field to find. [Key] by default.</param>
        /// <returns>The founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        public T FindKey(string key, string field = "Key")
        {
            return Find(x => x.HasPropertyEquals(field, key));
        }

        /// <summary>
        /// Method to remove an element by its Key property value.
        /// </summary>
        /// <param name="key">The Key value to search.</param>
        /// <param name="field">The name of the field to find. [Key] by default.</param>
        public bool RemoveKey(string key, string field = "Key")
        {
            List<T> items = FindKeyAll(key, field);
            bool result = true;

            if(items.Count > 0)
            {
                foreach(T item in items)
                {
                    if (!Remove(item))
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Method to find all elements by a Key property value.
        /// </summary>
        /// <param name="key">The Key value to search.</param>
        /// <param name="field">The name of the field to find. [Key] by default.</param>
        /// <returns>The founded list of elements otherwise, default empty List.</returns>
        public List<T> FindKeyAll(string key, string field = "Key")
        {
            return FindAll(x => x.HasPropertyEquals(field, key));
        }

        /// <summary>
        /// <para>Method to add or update an element by its Key property value.</para>
        /// <para>Update the first element with the same Key if is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update.</param>
        /// <param name="field">The name of the field to find. [Key] by default.</param>
        public void ReplaceKey(T element, string field = "Key")
        {
            Predicate<T> match = x => x.HasPropertyEquals(field, element.GetPropertyValue(field));

            if (Find(match) != null)
            {
                this[FindIndex(match)] = element;
            }
            else
            {
                Add(element);
            }
        }

        /// <summary>
        /// <para>Method to add or update an element by its Key property value.</para>
        /// <para>Update the first elemet and remove all others elements with the same Key if at least one element is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update.</param>
        /// <param name="field">The name of the field to find. [Key] by default.</param>
        public void ReplaceKeyUnique(T element, string field = "Key")
        {
            string key = element.GetPropertyValue<string>(field);
            List<T> items = FindKeyAll(key);

            if(items.Count == 0)
            {
                Add(element);
            }
            else
            {
                Predicate<T> match = x => x.HasPropertyEquals(field, element.GetPropertyValue(field));
                int index = FindIndex(match);

                if (items.Count > 1)
                {
                    int i = 0;
                    foreach(T item in items)
                    {
                        if(i > 0)
                        {
                            Remove(item);
                        }
                        i++;
                    }
                }

                this[index] = element;
            }
        }

        /// <summary>
        /// <para>Method to add or update an element by its Key property value. Also flag it by unique default.</para>
        /// <para>Update element with the same Key if is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update and flag it by unique default.</param>
        /// <param name="field1">The name of the field to find. [Key] by default.</param>
        /// <param name="field2">The name of the field to set to default. [Default] by default.</param>
        public void ReplaceKeyDefaultUnique(T element, string field1 = "Key", string field2 = "Default")
        {
            SetAllDefaultNone(field2);
            element.SetPropertyValue(field2, true);
            ReplaceKey(element, field1);
        }

        /// <summary>
        /// Method to find the first element found flagged to default.
        /// </summary>
        /// <param name="field">The name of the field to find. [Default] by default.</param>
        /// <returns>The founded element otherwise, default value of type T, or null if type T is nullable.</returns>
        public T FindDefault(string field = "Default")
        {
            return Find(x => x.HasPropertyEquals(field, true));
        }

        /// <summary>
        /// Method to find all elements found flagged to default.
        /// </summary>
        /// <param name="field">The name of the field to find. [Default] by default.</param>
        /// <returns>The founded elements otherwise, default empty List.</returns>
        public List<T> FindAllDefault(string field = "Default")
        {
            return FindAll(x => x.HasPropertyEquals(field, true));
        }

        /// <summary>
        /// Method to add a new unique default element into the list.
        /// </summary>
        /// <param name="field">The name of the field to find. [Default] by default.</param>
        /// <param name="item">The element to add.</param>
        public void AddDefaultUnique(T item, string field = "Default")
        {
            SetAllDefaultNone();
            item.SetPropertyValue(field, true);
            Add(item);
        }

        /// <summary>
        /// Method to flag all elements default to false or none.
        /// </summary>
        /// <param name="field">The name of the field to find. [Default] by default.</param>
        public void SetAllDefaultNone(string field = "Default")
        {
            List<T> defaultElements = FindAllDefault();
            foreach (T e in defaultElements)
            {
                e.SetPropertyValue(field, false);
            }
        }

        /// <summary>
        /// Method to flag all elements default to true or yes.
        /// </summary>
        /// <param name="field">The name of the field to find. [Default] by default.</param>
        public void SetAllDefault(string field = "Default")
        {
            List<T> defaultElements = FindAllDefault();
            foreach (T e in defaultElements)
            {
                e.SetPropertyValue(field, true);
            }
        }

        #endregion
    }
}