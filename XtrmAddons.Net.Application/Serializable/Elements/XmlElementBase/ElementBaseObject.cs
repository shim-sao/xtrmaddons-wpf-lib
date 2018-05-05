using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Elements Base Object.
    /// </summary>
    [Serializable]
    public class Property : ElementBase
    {
        #region Properties

        /// <summary>
        /// Property name of the object or property.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property value of the object or property.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Value")]
        public string Value { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Elements Base Object Constructor.
        /// </summary>
        public Property() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Elements Base Object Constructor.
        /// </summary>
        public Property(string Name ="", string Value = "" ) : base() { }
        
        #endregion
    }
}
