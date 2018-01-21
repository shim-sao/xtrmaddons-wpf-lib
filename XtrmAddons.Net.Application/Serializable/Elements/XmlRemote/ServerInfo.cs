using System;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Server Informations.
    /// </summary>
    public class ServerInfo : ElementBase
    {
        #region Properties

        /// <summary>
        /// Property name of the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property host name or IP address of the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Host")]
        public string Host { get; set; }

        /// <summary>
        /// Property port of the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Port")]
        public string Port { get; set; }

        /// <summary>
        /// Property user name for server connexion.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Property password for server connexion.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Property comment about the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Comment")]
        public string Comment { get; set; }

        #endregion
    }
}