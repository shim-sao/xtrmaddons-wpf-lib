using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements UI Elements.
    /// </summary>
    public class UiElements
    {
        #region Properties

        /// <summary>
        /// Property list of UI Elements elements.
        /// </summary>
        [XmlElement("Database")]
        public List<UiElement> Elements { get; set; }

        #endregion Properties


        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Elements Constructor.
        /// </summary>
        public UiElements()
        {
            Elements = new List<UiElement>();
        }

        /// <summary>
        /// Method to get a UI Element by its Name property.
        /// </summary>
        /// <param name="Name">A database Name.</param>
        /// <returns>A UI Element object or null.</returns>
        public UiElement Get(string name)
        {
            return Elements.SingleOrDefault(e => e.Name == name);
        }

        /// <summary>
        /// Method to set a UI Element in the list. Replace UI Element properties if Name property exists.
        /// </summary>
        /// <param name="name">The name of the UI Element.</param>
        /// <param name="value">The value of the UI Element.</param>
        /// <param name="IsEnable">Is enable property ?</param>
        /// <param name="IsVisible">Is visible property ?</param>
        /// <param name="DataType">The data type of the UI Element.</param>
        /// <returns></returns>
        public UiElement Set(string name, string value="", bool isEnable = true, bool isVisible = true,  string dataType = "")
        {
            UiElement el = Elements.SingleOrDefault(d => d.Name == name);

            if (el != null && el.Name != null)
            {
                el.Name = name;
                el.Value = value;
                el.IsEnable = isEnable;
                el.IsVisible = isVisible;
                el.DataType = dataType;
            }
            else
            {
                el = new UiElement { Name = name, Value = value, IsEnable = isEnable, IsVisible = isVisible, DataType = dataType };
                Elements.Add(el);
            }

            return el;
        }

        #endregion
    }
}