using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlUiElement
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Ui Control Serializer.
    /// </summary>
    public class UiControlSerializer
    {
        #region Properties

        private Dictionary<string, object> Properties { get; set; }
            = new Dictionary<string, object>();

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List Constructor.
        /// </summary>
        public UiControlSerializer() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List Constructor.
        /// </summary>
        /// <param name="ctrl">The initial capacity of the list.</param>
        public UiControlSerializer(Control ctrl) : base()
        {
            Properties.Add("Visibility", ctrl.Visibility);
            Properties.Add("IsEnabled", ctrl.IsEnabled);
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List Constructor.
        /// </summary>
        /// <param name="ctrl">The initial capacity of the list.</param>
        public UiControlSerializer(ComboBox ctrl) : base()
        {
            Properties.Add("Visibility", ctrl.Visibility);
            Properties.Add("IsEnabled", ctrl.IsEnabled);
            Properties.Add("SelectedIndex", ctrl.SelectedIndex);
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List Constructor.
        /// </summary>
        /// <param name="ctrl">The initial capacity of the list.</param>
        public UiControlSerializer(CheckBox ctrl) : base()
        {
            Properties.Add("Visibility", ctrl.Visibility);
            Properties.Add("IsEnabled", ctrl.IsEnabled);
            Properties.Add("IsChecked", ctrl.IsChecked);
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Ui Elements List Constructor.
        /// </summary>
        /// <param name="ctrl">The initial capacity of the list.</param>
        public UiControlSerializer(MenuItem ctrl) : base()
        {
            Properties.Add("Visibility", ctrl.Visibility);
            Properties.Add("IsEnabled", ctrl.IsEnabled);
            Properties.Add("IsChecked", ctrl.IsChecked);
            Properties.Add("IsCheckable", ctrl.IsCheckable);
        }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML UI Element Constructor.
        /// </summary>
        /// <param name="str">A windows control to serialize.</param>
        public UiControlSerializer(string str) : base()
        {
            FromJson(str);
        }

        #endregion



        #region Constructors

        /// <summary>
        /// </summary>
        public string ToJson()
        {
            return JsonConvert.SerializeObject
            (
                Properties,
#if DEBUG
                Formatting.Indented,
#else
                Formatting.None,
#endif
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }
            );
        }

        /// <summary>
        /// </summary>
        public void FromJson(string str)
        {
            Properties = (Dictionary<string, object>)JsonConvert.DeserializeObject(str);
        }

        /// <summary>
        /// </summary>
        public void ToControl(Control ctrl)
        {
            ctrl.Visibility = (Visibility)Properties["Visibility"];
            ctrl.IsEnabled = (bool)Properties["IsEnabled"];
        }

        /// <summary>
        /// </summary>
        public Control ToControl(Control ctrl, string str)
        {
            FromJson(str);
            ctrl.Visibility = (Visibility)Properties["Visibility"];
            ctrl.IsEnabled = (bool)Properties["IsEnabled"];

            return ctrl;
        }

        /// <summary>
        /// </summary>
        public CheckBox ToControl(CheckBox ctrl, string str)
        {
            FromJson(str);
            ctrl.Visibility = (Visibility)Properties["Visibility"];
            ctrl.IsEnabled = (bool)Properties["IsEnabled"];
            ctrl.IsChecked = (bool?)Properties["IsChecked"];

            return ctrl;
        }

        /// <summary>
        /// </summary>
        public ComboBox ToControl(ComboBox ctrl, string str)
        {
            FromJson(str);
            ctrl.Visibility = (Visibility)Properties["Visibility"];
            ctrl.IsEnabled = (bool)Properties["IsEnabled"];
            ctrl.SelectedIndex = (int)Properties["SelectedIndex"];

            return ctrl;
        }

        /// <summary>
        /// </summary>
        public MenuItem ToControl(MenuItem ctrl, string str)
        {
            FromJson(str);
            ctrl.Visibility = (Visibility)Properties["Visibility"];
            ctrl.IsEnabled = (bool)Properties["IsEnabled"];
            ctrl.IsChecked = (bool)Properties["IsChecked"];

            return ctrl;
        }

        #endregion
    }
}