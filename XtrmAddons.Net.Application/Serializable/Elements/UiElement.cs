using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements UI.
    /// </summary>
    public class UiElement
    {
        #region Properties

        /// <summary>
        /// Property name of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property Value of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Value")]
        public string Value { get; set; }

        /// <summary>
        /// Property name of the database.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "IsVisible")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Property name of the database.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "IsEnable")]
        public bool IsEnable { get; set; }

        /// <summary>
        /// Property name of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "DataType")]
        public string DataType { get; set; }

        #endregion
    }
}
