using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlUiElement
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML UI Element.
    /// </summary>
    [Serializable]
    public class UiElement : ElementBase
    {
        #region Variable

        /// <summary>
        /// Variable serialized windows control.
        /// </summary>
        [NonSerialized]
        private string objectValue = "";

        #endregion



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
        public object Value
        {
            get => GetValue();
            set => objectValue = SetValue(value);
        }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML UI Element Constructor.
        /// </summary>
        public UiElement() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML UI Element Constructor.
        /// </summary>
        /// <param name="control">A windows control to serialize.</param>
        /// <exception cref="ArgumentNullException"/>
        public UiElement(Control control)
        {
            if (control.Uid.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(control.Uid));
            }

            if (control.Name.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(control.Name));
            }

            Key = control.Uid;
            Name = control.Name;
            Value = control;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to convert a windows control into a serialized string.
        /// </summary>
        /// <param name="value">A windows control to serialize.</param>
        /// <returns>A serialized string.</returns>
        private static string SetValue(object value)
        {
            try
            {
                return XamlWriter.Save(value);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }

            return "";
        }

        /// <summary>
        /// Method to convert a serialized string into a windows control.
        /// </summary>
        /// <returns>A deserialized windows control. Return null if deserialization fail.</returns>
        private object GetValue()
        {
            try
            {
                StringReader stringReader = new StringReader(objectValue);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                return XamlReader.Load(xmlReader);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return null;
            }
        }

        #endregion
    }
}
