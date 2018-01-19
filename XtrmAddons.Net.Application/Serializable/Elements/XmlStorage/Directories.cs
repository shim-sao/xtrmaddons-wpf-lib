using System.Collections.Generic;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlStorage
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Directories List.
    /// </summary>
    public class Directories : ElementsBase<Directory>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Directories List Constructor.
        /// </summary>
        public Directories() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Directories List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public Directories(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Directories List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public Directories(IEnumerable<Directory> collection) : base(collection) { }

        #endregion
    }
}
