using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlData;
using XtrmAddons.Net.Application.Serializable.Elements.XmlRemote;
using XtrmAddons.Net.Application.Serializable.Elements.XmlStorage;

namespace XtrmAddons.Net.Application.Serializable
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Options.
    /// </summary>
    [XmlRoot("Options", Namespace="http://www.xtrmaddons.com/", IsNullable = false)]
    public class Options
    {
        #region Properties

        /// <summary>
        /// Property list of databases.
        /// </summary>
        [XmlElement("Databases")]
        public DataOptions Data;

        /// <summary>
        /// Property list of directories.
        /// </summary>
        [XmlElement("Storage")]
        public StorageOptions Storage;

        /// <summary>
        /// Property list of servers.
        /// </summary>
        [XmlElement("Remote")]
        public RemoteOptions Remote;

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Options Constructor.
        /// </summary>
        public Options()
        {
            Data = new DataOptions();
            Storage = new StorageOptions();
            Remote = new RemoteOptions();
        }

        #endregion
    }
}
