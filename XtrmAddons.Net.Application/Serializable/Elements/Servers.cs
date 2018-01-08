using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Servers.
    /// </summary>
    public class Servers
    {
        [XmlElement("Server")]
        public List<Server> Elements { get; set; }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Servers constructor.
        /// </summary>
        public Servers()
        {
            Elements = new List<Server>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Server Get(string key)
        {
            return Elements.SingleOrDefault(e => e.Key == key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Add(Server item)
        {
            Elements.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Remove(Server item)
        {
            Elements.Remove(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Update(Server item)
        {
            Set(item.Name, item.Type, item.Default, item.Host, item.Port, item.UserName, item.Password, item.Comment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Server Set(string name, ServerType type, bool Default = false, string host = "", string port = "", string username = "", string password = "", string comment = "")
        {
            Server el = Elements.SingleOrDefault(d => d.Key == name);

            if(Default == true)
            {
                Server eldef = Elements.SingleOrDefault(d => d.Default == true);
                if(eldef != null && eldef.Key != null)
                {
                    eldef.Default = false;
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
                el = new Server { Key = name, Default = Default, Name = name, Type = type, Host = host, Port = port, UserName = username, Password = password, Comment = comment };
                Elements.Add(el);
            }

            return el;
        }
    }
}