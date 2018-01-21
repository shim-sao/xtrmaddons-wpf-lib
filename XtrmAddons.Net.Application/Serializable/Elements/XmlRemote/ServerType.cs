using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Enumerator XtrmAddons Net Application Serializable Elements XML Server Informations Types.
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
