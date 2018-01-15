using System;
using System.Collections.Generic;
using System.Linq;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlDatabases
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Databases.
    /// </summary>
    [Serializable]
    public class Databases : ElementsBase<Database>
    {
        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Databases Constructor.
        /// </summary>
        public Databases() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Databases Constructor.
        /// </summary>
        public Databases(List<Database> elements) : base(elements) { }

        #endregion


        #region Methods

        /// <summary>
        /// Method to update a Database informations in the list.
        /// </summary>
        /// <param name="item">The Database to update.</param>
        public override void Update(Database item)
        {
            Set(item.Key, item.Name, item.Type, item.Source, item.Host, item.Port, item.Default, item.UserName, item.Password, item.Comment);
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


        #endregion
    }
}