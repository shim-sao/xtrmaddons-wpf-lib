using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Server Informations.
    /// </summary>
    public class ServerInfo : ElementBase
    {
        #region Variables

        /// <summary>
        /// Private name of the server.
        /// </summary>
        [XmlIgnore]
        private string name = "";

        /// <summary>
        /// Private host name or IP address of the server.
        /// </summary>
        [XmlIgnore]
        private string host = "";

        /// <summary>
        /// Private port of the server.
        /// </summary>
        [XmlIgnore]
        private string port = "";

        /// <summary>
        /// Private user name for server connexion.
        /// </summary>
        [XmlIgnore]
        private string userName = "";

        /// <summary>
        /// Private email for server connexion.
        /// </summary>
        [XmlIgnore]
        private string email = "";

        /// <summary>
        /// Private password for server connexion.
        /// </summary>
        [XmlIgnore]
        private string password = "";

        /// <summary>
        /// Private comment about the server.
        /// </summary>
        [XmlIgnore]
        private string comment = "";

        /// <summary>
        /// Private to define if server can auto started by the application or required to be started manually.
        /// </summary>
        [XmlIgnore]
        private bool autoStart = true;

        /// <summary>
        /// Private status of the server.
        /// </summary>
        [XmlIgnore]
        private string status = "";

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the name of the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Name")]
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the host name or IP address of the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Host")]
        public string Host
        {
            get { return host; }
            set
            {
                if (value != host)
                {
                    host = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the port of the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Port")]
        public string Port
        {
            get { return port; }
            set
            {
                if (value != port)
                {
                    port = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the user name for server connexion.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "UserName")]
        public string UserName
        {
            get { return userName; }
            set
            {
                if (value != userName)
                {
                    userName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the email for server connexion.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Email")]
        public string Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the password for server connexion.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Password")]
        public string Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the comment about the server.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Comment")]
        public string Comment
        {
            get { return comment; }
            set
            {
                if (value != comment)
                {
                    comment = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to check if the server can auto started by the application or required to be started manually.
        /// </summary>
        [XmlAttribute(DataType = "boolean", AttributeName = "AutoStart")]
        public bool AutoStart
        {
            get { return autoStart; }
            set
            {
                if (value != autoStart)
                {
                    autoStart = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Property to access to the status of the server.
        /// </summary>
        [XmlIgnore]
        public string Status
        {
            get { return status; }
            set
            {
                if (value != status)
                {
                    status = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion
    }
}