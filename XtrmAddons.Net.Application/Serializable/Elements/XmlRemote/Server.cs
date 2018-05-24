using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Server Informations.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Server : RemoteInfo
    {
        #region Properties

        /// <summary>
        /// Property type of server.
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        [JsonProperty(PropertyName = "Type")]
        public RemoteType Type { get; } = RemoteType.Server;

        #endregion
    }
}