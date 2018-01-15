using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Element Base.
    /// </summary>
    public class ElementBase
    {
        #region Properties

        /// <summary>
        /// Property unique Key of the element.
        /// </summary>
        [XmlAttribute(DataType="string", AttributeName="Key")]
        public string Key { get; set; }

        /// <summary>
        /// Property is default of the element.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "Default")]
        public bool Default { get; set; }

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Element Base Constructor.
        /// </summary>
        public ElementBase() { }

        #endregion
    }
}
