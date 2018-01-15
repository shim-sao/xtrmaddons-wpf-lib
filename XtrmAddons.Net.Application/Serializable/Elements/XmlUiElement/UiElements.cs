using System;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlUiElement
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML UI Elements.
    /// </summary>
    [Serializable]
    public class UiElements : ElementsBase<UiElement>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Elements Constructor.
        /// </summary>
        public UiElements() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements UI Elements Constructor.
        /// </summary>
        public UiElements(List<UiElement> elements) : base(elements) { }

        #endregion



        #region Methods

        /// <summary>
        /// Method to update a UI Element informations in the list.
        /// </summary>
        /// <param name="element">The UI Element informations to update.</param>
        public override void Update(UiElement element)
        {
            Set(element.Key, element.Name, element.Value, element.IsEnabled, element.IsVisible, element.DataType);
        }

        /// <summary>
        /// Method to set a UI Element in the list. Replace UI Element properties if Key property exists.
        /// </summary>
        /// <param name="key">The key of the UI Element.</param>
        /// <param name="name">The name of the UI Element.</param>
        /// <param name="value">The value of the UI Element.</param>
        /// <param name="IsEnable">Is enable property ?</param>
        /// <param name="IsVisible">Is visible property ?</param>
        /// <param name="DataType">The data type of the UI Element.</param>
        /// <returns></returns>
        public UiElement Set(string key, string name, string value ="", bool isEnabled = true, bool isVisible = true,  string dataType = "")
        {
            UiElement el = Find(key);

            if (el != null && el.Key != null)
            {
                el.Key = key;
                el.Name = name;
                el.Value = value;
                el.IsEnabled = isEnabled;
                el.IsVisible = isVisible;
                el.DataType = dataType;
            }
            else
            {
                el = new UiElement { Key = key, Name = name, Value = value, IsEnabled = isEnabled, IsVisible = isVisible, DataType = dataType };
                Elements.Add(el);
            }

            return el;
        }

        #endregion
    }
}