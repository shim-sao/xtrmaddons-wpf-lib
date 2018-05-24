using System;
using System.Diagnostics;
using System.Windows.Controls;
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
        #region Properties

        /// <summary>
        /// Property name of the UI element.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property value of the UI element.
        /// </summary>
        ///[XmlAttribute(DataType = "string", AttributeName = "Value
        [XmlElement("JsonContext")]
        public string JsonContext { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML UI Element Constructor.
        /// </summary>
        public UiElement() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML UI Element Constructor.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <exception cref="ArgumentNullException"/>
        public UiElement(Control ctrl)
        {
            if (ctrl.Uid.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(ctrl.Uid));
            }

            if (ctrl.Name.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(ctrl.Name));
            }

            Key = ctrl.Uid;
            Name = ctrl.Name;
            JsonContext = new UiControlSerializer(ctrl).ToJson();
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML UI Element Constructor.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <exception cref="ArgumentNullException"/>
        public UiElement(CheckBox ctrl)
        {
            if (ctrl.Uid.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(ctrl.Uid));
            }

            if (ctrl.Name.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(ctrl.Name));
            }

            Key = ctrl.Uid;
            Name = ctrl.Name;
            JsonContext = new UiControlSerializer(ctrl).ToJson();
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML UI Element Constructor.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <exception cref="ArgumentNullException"/>
        public UiElement(MenuItem ctrl)
        {
            if (ctrl.Uid.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(ctrl.Uid));
            }

            if (ctrl.Name.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(ctrl.Name));
            }

            Key = ctrl.Uid;
            Name = ctrl.Name;
            JsonContext = new UiControlSerializer(ctrl).ToJson();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to convert a windows control into a serialized string.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <returns></returns>
        public Control ToControl(Control ctrl)
        {
            try
            {
                UiControlSerializer ucs = new UiControlSerializer(JsonContext);
                ucs.ToControl(ctrl);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }

            return ctrl;
        }

        /// <summary>
        /// Method to convert a windows control into a serialized string.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <returns></returns>
        public CheckBox ToControl(CheckBox ctrl)
        {
            try
            {
                UiControlSerializer ucs = new UiControlSerializer(JsonContext);
                ucs.ToControl(ctrl);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }

            return ctrl;
        }

        /// <summary>
        /// Method to convert a windows control into a serialized string.
        /// </summary>
        /// <param name="ctrl">A windows control to serialize.</param>
        /// <returns></returns>
        public MenuItem ToControl(MenuItem ctrl)
        {
            try
            {
                UiControlSerializer ucs = new UiControlSerializer(JsonContext);
                ucs.ToControl(ctrl);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }

            return ctrl;
        }

        #endregion
    }
}
