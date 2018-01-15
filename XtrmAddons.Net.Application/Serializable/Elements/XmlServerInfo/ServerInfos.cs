using System;
using System.Collections.Generic;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlServerInfo
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Servers Informations.
    /// </summary>
    [Serializable]
    public class ServerInfos : ElementsBase<ServerInfo>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Servers Informations Constructor.
        /// </summary>
        public ServerInfos(List<ServerInfo> elements = null) : base(elements) { }

        #endregion



        #region Methods

        /// <summary>
        /// Method to update a server informations in the list.
        /// </summary>
        /// <param name="element">The server informations to update.</param>
        public override void Update(ServerInfo element)
        {
            Set(element.Name, element.Type, element.Default, element.Host, element.Port, element.UserName, element.Password, element.Comment);
        }


        /// <summary>
        /// Method to add or update a server informations by settings property values.
        /// </summary>
        /// <param name="name">The name of the Server.</param>
        /// <param name="type">The type of Server informations.</param>
        /// <param name="Default">Is default ?</param>
        /// <param name="host">The host name of the Server.</param>
        /// <param name="port">The port of the Server.</param>
        /// <param name="username">The user name or login for the connexion to the Server.</param>
        /// <param name="password">The password for the connexion to the Server</param>
        /// <param name="comment">A comment.</param>
        /// <returns>The added or updated Server Informations.</returns>
        public ServerInfo Set(string name, ServerInfoType type, bool Default = false, string host = "", string port = "", string username = "", string password = "", string comment = "")
        {
            ServerInfo el = Find(name);

            if(Default == true)
            {
                ServerInfo s = this.Default();
                if(s != null && s.Key != null)
                {
                    s.Default = false;
                }
            }

            if (el != null && el.Key != null)
            {
                el.Default = Default;
                el.Type = type;
                el.Host = host;
                el.Port = port;
                el.UserName = username;
                el.Password = password;
                el.Comment = comment;
            }
            else
            {
                el = new ServerInfo { Key = name, Default = Default, Name = name, Type = type, Host = host, Port = port, UserName = username, Password = password, Comment = comment };
                Elements.Add(el);
            }

            return el;
        }

        #endregion
    }
}