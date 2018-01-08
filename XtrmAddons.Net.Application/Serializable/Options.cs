using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements;

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
        public Servers Servers;

        #endregion Properties


        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Options constructor.
        /// </summary>
        public Options()
        {
            Databases = new Databases();
            Directories = new Directories();
            Servers = new Servers();
        }

        #endregion Methods
    }
}
