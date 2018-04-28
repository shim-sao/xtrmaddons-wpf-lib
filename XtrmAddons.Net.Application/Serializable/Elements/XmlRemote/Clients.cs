using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Clients List.
    /// </summary>
    public class Clients : ElementsBase<Client>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Clients List Constructor.
        /// </summary>
        public Clients() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Clients List Constructor.
        /// </summary>
        /// <param name="capacity">The initial capacity of the list.</param>
        public Clients(int capacity) : base(capacity) { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Clients List Constructor.
        /// </summary>
        /// <param name="collection">Collection whose items are copied to the new list.</param>
        public Clients(IEnumerable<Client> collection) : base(collection) { }

        #endregion
    }
}
