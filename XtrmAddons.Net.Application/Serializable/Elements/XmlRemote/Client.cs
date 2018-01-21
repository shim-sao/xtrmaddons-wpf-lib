using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Server Informations.
    /// </summary>
    [Serializable]
    public class Client : ServerInfo
    {
        /// <summary>
        /// Property type of server.
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public ServerType Type { get; } = ServerType.Server;
    }
}