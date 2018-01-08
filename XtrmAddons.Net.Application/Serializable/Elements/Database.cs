using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Database.
    /// </summary>
    public class Database : Element
    {
        #region Properties

        /// <summary>
        /// Property name of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Property type of the database.
        /// </summary>
        [XmlAttribute(AttributeName = "Type")]
        public DatabaseType Type { get; set; }

        /// <summary>
        /// Property source of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Source")]
        public string Source { get; set; }

        /// <summary>
        /// Property host of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Host")]
        public string Host { get; set; }

        /// <summary>
        /// Property Port of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Port")]
        public string Port { get; set; }

        /// <summary>
        /// Property user name or login of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Property password of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Property comment of the database.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Comment")]
        public string Comment { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Database constructor.
        /// </summary>
        public Database() : base() { }

        #endregion Methods
    }


    /// <summary>
    /// Enumerator of database types.
    /// </summary>
    [Serializable]
    public enum DatabaseType
    {
        /// <summary>
        /// Database type for SQLite database. 
        /// </summary>
        [XmlEnum(Name = "SQLite")]
        SQLite = 1,

        /// <summary>
        /// Database type for MySQL database. 
        /// </summary>
        [XmlEnum(Name = "MySQL")]
        MySQL = 2
    }
}