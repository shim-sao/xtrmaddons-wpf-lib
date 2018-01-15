using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlDatabases;
using XtrmAddons.Net.Application.Serializable.Elements.XmlDirectories;
using XtrmAddons.Net.Application.Serializable.Elements.XmlServerInfo;
using XtrmAddons.Net.Application.Serializable.Elements.XmlUiElement;

namespace XtrmAddons.Net.Application.Serializable
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Options.
    /// </summary>
    [XmlRootAttribute("Options", Namespace="http://www.xtrmaddons.com/", IsNullable = false)]
    public class Options
    {
        #region Properties

        /// <summary>
        /// Property list of databases.
        /// </summary>
        [XmlElement("Databases")]
        public Databases Databases;

        /// <summary>
        /// Property list of directories.
        /// </summary>
        [XmlElement("Directories")]
        public Directories Directories;

        /// <summary>
        /// Property list of servers.
        /// </summary>
        [XmlElement("Servers")]
        public ServerInfos Servers;

        /// <summary>
        /// Property list of UI Elements.
        /// </summary>
        [XmlElement("UI")]
        public UiElements UI;

        #endregion



        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Options constructor.
        /// </summary>
        public Options()
        {
            Databases = new Databases();
            Directories = new Directories();
            Servers = new ServerInfos();
            UI = new UiElements();
        }

        #endregion
    }
}
