using System;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlUiElement
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML UI Element.
    /// </summary>
    [Serializable]
    public class UiElement : ElementBase
    {
        #region Properties

        /// <summary>
        /// Property name of the UI element.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property value of the UI element.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Value")]
        public string Value { get; set; }

        /// <summary>
        /// Property is UI element visible ?
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "IsVisible")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Property is UI element enabled ?
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "IsEnable")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Property data type of UI element.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "DataType")]
        public string DataType { get; set; }

        #endregion
    }
}
