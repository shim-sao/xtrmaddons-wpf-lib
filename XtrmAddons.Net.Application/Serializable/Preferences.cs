using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlDirectories;
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
        /// Property base directory for application options and directories.
        /// </summary>
        [XmlElement("BaseDirectory")]
        public string BaseDirectory { get; set; }

        /// <summary>
        /// Property language used by the user.
        /// </summary>
        [XmlElement("Language")]
        public string Language { get; set; }

        /// <summary>
        /// Property list of directories.
        /// </summary>
        [XmlElement("Directories")]
        public Directories Directories;

        /// <summary>
        /// Property list of specials directories used by the application.
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
            Directories = new Directories();
        }

        #endregion
    }
}
