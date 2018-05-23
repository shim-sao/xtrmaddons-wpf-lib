using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Element Base.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ElementBase : INotifyPropertyChanged
    {
        #region Variables

        /// <summary>
        /// Variable unique Key of the element.
        /// </summary>
        [XmlIgnore]
        private string key = "";

        /// <summary>
        /// Variable is default of the element.
        /// </summary>
        [XmlIgnore]
        private bool isDefault = false;

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the unique Key of the element.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Key")]
        [JsonProperty]
        public string Key
        {
            get => key;
            set
            {
                if (value != key)
                {
                    key = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to check it i thes default element.
        /// </summary>
        [XmlIgnore]
        [Obsolete("Use IsDefault instead to be pertinent.")]
        public bool Default
        {
            get => isDefault;
            set
            {
                if (value != isDefault)
                {
                    isDefault = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to check it i thes default element.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "Default")]
        [JsonProperty]
        public bool IsDefault
        {
            get => isDefault;
            set
            {
                if (value != isDefault)
                {
                    isDefault = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion



        #region Event Handler

        /// <summary>
        /// Delegate property changed event handler of the model.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Element Base Constructor.
        /// </summary>
        public ElementBase() { }

        #endregion



        #region Methods

        /// <summary>
        /// This method is called by the Set accessor of each property.
        /// The CallerMemberName attribute that is applied to the optional propertyName.
        /// parameter causes the property name of the caller to be substituted as an argument.
        /// </summary>
        /// <param name="propertyName">A name of a property to notify changed event.</param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}
