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
    }
}