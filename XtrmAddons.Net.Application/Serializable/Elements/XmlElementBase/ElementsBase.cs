using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Interfaces;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Elements Base.
    /// </summary>
    public abstract class ElementsBase<T> : ISerializableElements<T>
    {
        #region Properties

        /// <summary>
        /// Property list of elements.
        /// </summary
        public virtual List<T> Elements { get; set; }

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Elements Base Constructor.
        /// </summary>
        public ElementsBase()
        {
            Elements = new List<T>();
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Elements Base Constructor.
        /// </summary>
        public ElementsBase(List<T> elements)
        {
            Elements = elements;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to find an element by a property value.
        /// </summary>
        /// <param name="propertyName">The name of the property to find.</param>
        /// <param name="value">The value of the property to find.</param>
        /// <returns>The founded element in the elements list or default element.</returns>
        public virtual T Find(string propertyName, object value)
        {
            if (propertyName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("propertyName");
            }

            return Elements.SingleOrDefault(e => e.GetPropertyValue(propertyName).Equals(value));
        }

        /// <summary>
        /// Method to find an element by its property Key value.
        /// </summary>
        /// <param name="value">The value of the property key to find.</param>
        /// <returns>The founded element in the elements list or default element.</returns>
        public virtual T Find(object value)
        {
            return Find("Key", value);
        }

        /// <summary>
        /// Method to find the element flagged to default.
        /// </summary>
        /// <returns>The founded element in the elements list or default element.</returns>
        public virtual T Default()
        {

            return Find("Default", true);
        }

        /// <summary>
        /// Method to add an element in the elements list.
        /// </summary>
        /// <param name="element">The element to add in the list of elements.</param>
        public virtual void Add(T element)
        {
            Elements.Add(element);
        }

        /// <summary>
        /// Method to remove an element from the elements list.
        /// </summary>
        /// <param name="element">The element to remove from the elements list.</param>
        /// <returns></returns>
        public virtual void Remove(T element)
        {
            Elements.Remove(element);
        }

        /// <summary>
        /// Method to update an element in the elements list.
        /// </summary>
        /// <param name="element">The element to update.</param>
        public abstract void Update(T element);

        #endregion
    }
}