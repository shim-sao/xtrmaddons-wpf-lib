using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlStorage;
using XtrmAddons.Net.Application.Serializable.Elements.XmlUiElement;

namespace XtrmAddons.Net.Application.Serializable
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Preferences.
    /// </summary>
    [XmlRoot("Configuration", Namespace= "http://www.xtrmaddons.com/", IsNullable = false)]
    public class Preferences
    {
        #region Properties

        /// <summary>
        /// Property to access to the base directory for application options and directories.
        /// </summary>
        [XmlElement("BaseDirectory")]
        public string BaseDirectory { get; set; }

        /// <summary>
        /// Property to access to the language used by the user.
        /// </summary>
        [XmlElement("Language")]
        public string Language { get; set; }

        /// <summary>
        /// Property to access to the storage informations like list of directories... used by default by the application.
        /// </summary>
        [XmlElement("Storage")]
        public StorageOptions Storage;

        /// <summary>
        /// Property to access to the list of specials directories used by default by the application.
        /// </summary>
        [XmlElement("SpecialDirectories")]
        public SpecialDirectories SpecialDirectories;

        #endregion



        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Preferences constructor.
        /// </summary>
        public Preferences()
        {
            SpecialDirectories = new SpecialDirectories();
            Storage = new StorageOptions();
        }

        #endregion
    }
}
