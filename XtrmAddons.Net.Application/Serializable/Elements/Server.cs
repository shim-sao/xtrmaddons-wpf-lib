using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Server.
    /// </summary>
    public class Server : Element
    {
        /// <summary>
        /// Property name of the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property type of server.
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public ServerType Type { get; set; }

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

    }

    /// <summary>
    /// Enumerator of server types.
    /// </summary>
    [Serializable]
    public enum ServerType
    {
        /// <summary>
        /// Server type for server provider parameters.
        /// </summary>
        [XmlEnum(Name = "Server")]
        Server = 0,

        /// <summary>
        /// Server type for client server parameters.
        /// </summary>
        [XmlEnum(Name = "Client")]
        Client = 1
    }
}