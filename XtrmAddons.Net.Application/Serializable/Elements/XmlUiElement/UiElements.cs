using System;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlUiElement
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List.
    /// </summary>
    public class UiElements : ElementsBase<UiElement>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List Constructor.
        /// </summary>
        public UiElements() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public UiElements(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public UiElements(IEnumerable<UiElement> collection) : base(collection) { }

        #endregion

        /// <summary>
        /// <para>Method to add or update an element by its Key property value.</para>
        /// <para>Update the first elemet and remove all others elements with the same Key if at least one element is found in the list otherwise, add the element to the list.</para>
        /// </summary>
        /// <param name="element">The element to add or update.</param>
        public void ReplaceKeyUnique(UiElement element)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                string key = element.Key;
                List<UiElement> items = FindKeyAll(key);

                if (items.Count == 0)
                {
                    Add(element);
                }
                else
                {
                    Predicate<UiElement> match = x => x.Key == element.Key;
                    int index = FindIndex(match);

                    if (items.Count > 1)
                    {
                        int i = 0;
                        foreach (UiElement item in items)
                        {
                            if (i > 0)
                            {
                                Remove(item);
                            }
                            i++;
                        }
                    }

                    this[index] = element;
                }
            }));
        }
    }
}