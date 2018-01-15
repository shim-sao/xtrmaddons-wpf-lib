using System;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlServerInfo
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Server Informations.
    /// </summary>
    [Serializable]
    public class ServerInfo : ElementBase
    {
        #region Properties

        /// <summary>
        /// Property name of the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property type of server.
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public ServerInfoType Type { get; set; }

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



    /// <summary>
    /// Enumerator XtrmAddons Net Application Serializable Elements XML Server Informations Types.
    /// </summary>
    [Serializable]
    public enum ServerInfoType
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



    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Enumerator XML Server Informations Types Extensions.
    /// </summary>
    public static class ServerInfoExtensions
    {
        /// <summary>
        /// Method to get string name of a server informations type.
        /// </summary>
        /// <param name="type">The server informations type.</param>
        /// <returns>The string name of the server informations type otherwise return null.</returns>
        public static string Name(this ServerInfoType type)
        {
            switch (type)
            {
                case ServerInfoType.Server:
                    return "Server";
                case ServerInfoType.Client:
                    return "Client";
            }

            return null;
        }

        /// <summary>
        /// Method to get int value of a server informations type.
        /// </summary>
        /// <param name="type">The server informations type.</param>
        /// <returns>The int value of the server informations type otherwise return -1.</returns>
        public static int Value(this ServerInfoType type)
        {
            switch (type)
            {
                case ServerInfoType.Server:
                    return 0;
                case ServerInfoType.Client:
                    return 1;
            }

            return -1;
        }
    }
}