using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Element.
    /// </summary>
    public class Element
    {
        #region Properties

        /// <summary>
        /// Property unique Key of the element.
        /// </summary>
        [XmlAttribute(DataType="string", AttributeName="Key")]
        public string Key { get; set; }

        /// <summary>
        /// Property default of the element.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "Default")]
        public bool Default { get; set; }

        #endregion Properties


        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Element constructor.
        /// </summary>
        public Element() { }

        #endregion Methods
    }
}
