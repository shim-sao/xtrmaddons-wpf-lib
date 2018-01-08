using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Databases.
    /// </summary>
    public class Databases
    {
        #region Properties

        /// <summary>
        /// Property list of databases elements.
        /// </summary>
        [XmlElement("Database")]
        public List<Database> Elements { get; set; }

        #endregion Properties


        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Databases constructor.
        /// </summary>
        public Databases()
        {
            Elements = new List<Database>();
        }

        /// <summary>
        /// Method to get a database by its Key property.
        /// </summary>
        /// <param name="key">A database Key.</param>
        /// <returns>A Database object or null.</returns>
        public Database Get(string key)
        {
            return Elements.SingleOrDefault(e => e.Key == key);
        }

        /// <summary>
        /// Method to set a database in the list. Replace database properties if Key property exists.
        /// </summary>
        /// <param name="key">Property key of the database.</param>
        /// <param name="name">Property name of the database.</param>
        /// <param name="type">Property type of the database.</param>
        /// <param name="source">Property source of the database.</param>
        /// <param name="host">Property host of the database.</param>
        /// <param name="Default">Property is default database.</param>
        /// <param name="Port">Property host of the database.</param>
        /// <param name="username">Property user name of the database.</param>
        /// <param name="password">Property password of the database.</param>
        /// <param name="comment">Property comment of the database.</param>
        /// <returns>A Database object.</returns>
        public Database Set(string key, string name, DatabaseType type, string source = "", string host = "", string port = "", bool Default = false, string username = "", string password = "", string comment = "")
        {
            Database el = Elements.SingleOrDefault(d => d.Key == name);

            if (Default == true)
            {
                Database eldef = Elements.SingleOrDefault(d => d.Default == true);
                if (eldef != null && eldef.Key != null)
                {
                    eldef.Default = false;
                }
            }

            if (el != null && el.Key != null)
            {
                el.Default = Default;
                el.Name = name;
                el.Type = type;
                el.Source = source;
                el.Host = host;
                el.Port = port;
                el.UserName = username;
                el.Password = password;
            }
            else
            {
                el = new Database { Key = key, Name = name, Type = type, Source = source, Host = host, Default = Default, UserName = username, Password = password, Comment = comment };
                Elements.Add(el);
            }

            return el;
        }

        #endregion Methods
    }
}