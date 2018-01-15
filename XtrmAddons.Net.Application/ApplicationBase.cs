using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable;
using XtrmAddons.Net.Application.Serializable.Elements.XmlDirectories;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application
{
    /// <summary>
    /// <para>Class XtrmAddons Common Classes Configuration Properties Application.</para>
    /// <para>Provides some application default properties settings.</para>
    /// </summary>
    public static class ApplicationBase
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Variable application preferences serializable.
        /// </summary>
        private static Preferences preferences;

        /// <summary>
        /// Variable application options serializable.
        /// </summary>
        private static Options options;

        /// <summary>
        /// 
        /// </summary>
        private const string filePreferencesXmlName = "preferences.xml";

        /// <summary>
        /// 
        /// </summary>
        private const string fileOptionsXmlName = "options.xml";

        #endregion Variables


        #region Properties

        /// <summary>
        /// Property access to directories preferences.
        /// </summary>
        public static Directories Directories => preferences.Directories;

        /// <summary>
        /// Property application options serializable.
        /// </summary>
        public static Options Options { get { return options; } }

        /// <summary>
        /// Property default config directory.
        /// </summary>
        private static string FilePreferencesXml => Path.Combine(UserMyDocumentsDirectory, filePreferencesXmlName);

        /// <summary>
        /// Property default config directory.
        /// </summary>
        private static string FileOptionsXml => Path.Combine(ConfigDirectory, fileOptionsXmlName);

        /// <summary>
        /// Property default application directory.
        /// </summary>
        public static string BaseDirectory
        {
            get
            {
                if (preferences.BaseDirectory.IsNullOrWhiteSpace())
                {
                    preferences.BaseDirectory = UserMyDocumentsDirectory;
                }

                return preferences.BaseDirectory;
            }

            set
            {
                if (!System.IO.Directory.Exists(value))
                {
                    System.IO.Directory.CreateDirectory(value);
                }

                preferences.BaseDirectory = value;
            }
        }

        /// <summary>
        /// Property default application directory.
        /// </summary>
        public static string Language
        {
            get
            {
                if (preferences.Language.IsNullOrWhiteSpace())
                {
                    preferences.Language = Thread.CurrentThread.CurrentCulture.ToString();
                }

                return preferences.Language;
            }

            set => preferences.Language = value;
        }

        /// <summary>
        /// Property default cache directory.
        /// </summary>
        public static string CacheDirectory
        {
            get
            {
                if (preferences.SpecialDirectories.Cache.IsNullOrWhiteSpace())
                {
                    preferences.SpecialDirectories.Cache = Path.Combine(BaseDirectory, SpecialDirectoriesName.Cache.Name());
                }

                return preferences.SpecialDirectories.Cache;
            }
            set
            {
                if (!System.IO.Directory.Exists(value))
                {
                    System.IO.Directory.CreateDirectory(value);
                }

                preferences.SpecialDirectories.Cache = value;
            }
        }

        /// <summary>
        /// Property default application custom Config directory.
        /// </summary>
        public static string ConfigDirectory
        {
            get
            {
                if (preferences.SpecialDirectories.Config.IsNullOrWhiteSpace())
                {
                    ConfigDirectory = Path.Combine(BaseDirectory, SpecialDirectoriesName.Config.Name());
                }
                return preferences.SpecialDirectories.Config;
            }
            set
            {
                if (!System.IO.Directory.Exists(value))
                    System.IO.Directory.CreateDirectory(value);
                preferences.SpecialDirectories.Config = value;
            }
        }

        /// <summary>
        /// Property default data directory.
        /// </summary>
        public static string DataDirectory
        {
            get
            {
                if (preferences.SpecialDirectories.Data.IsNullOrWhiteSpace())
                {
                    preferences.SpecialDirectories.Data = Path.Combine(BaseDirectory, SpecialDirectoriesName.Data.Name());
                    if (!System.IO.Directory.Exists(preferences.SpecialDirectories.Data))
                        System.IO.Directory.CreateDirectory(preferences.SpecialDirectories.Data);
                }
                return preferences.SpecialDirectories.Data;
            }
            set
            {
                if (!System.IO.Directory.Exists(value))
                    System.IO.Directory.CreateDirectory(value);
                preferences.SpecialDirectories.Data = value;
            }
        }
        
        /// <summary>
         /// Property default logs directory.
         /// </summary>
        public static string LogsDirectory
        {
            get
            {
                if (preferences.SpecialDirectories.Logs.IsNullOrWhiteSpace())
                {
                    preferences.SpecialDirectories.Logs = Path.Combine(BaseDirectory, SpecialDirectoriesName.Logs.Name());
                    if (!System.IO.Directory.Exists(preferences.SpecialDirectories.Logs))
                        System.IO.Directory.CreateDirectory(preferences.SpecialDirectories.Logs);
                }
                return preferences.SpecialDirectories.Logs;
            }
            set
            {
                if (!System.IO.Directory.Exists(value))
                    System.IO.Directory.CreateDirectory(value);
                preferences.SpecialDirectories.Logs = value;
            }
        }

        /// <summary>
        /// Property default assets images directory.
        /// </summary>
        public static string AssetsImagesDefaultDirectory
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\Images\\Default"); }
        }

        /// <summary>
        /// Property default assets images directory.
        /// </summary>
        public static string AssetsImagesIconsDirectory
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\Images\\Icons"); }
        }

        /// <summary>
        /// Method to get Window User My Documents path.
        /// </summary>
        /// <returns>The absolute path to Window User My Documents.</returns>
        public static string UserMyDocumentsDirectory
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        ApplicationFriendlyName
                    )
                ;
            }
        }

        /// <summary>
        /// Method to get the application friendly name.
        /// <para>This method remove extensions from file name.</para>
        /// </summary>
        /// <returns>The cleaned application friendly name.</returns>
        public static string ApplicationFriendlyName
            => AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", "").Replace(".exe", "");

        #endregion



        #region Methods

        /// <summary>
        /// Method to start an application.
        /// </summary>
        public static void Start()
        {
            LoadPreferences();
            LoadOptions();
        }

        /// <summary>
        /// Method to load application preferences.
        /// </summary>
        public static void LoadPreferences()
        {
            if (!File.Exists(FilePreferencesXml))
            {
                if (!System.IO.Directory.Exists(UserMyDocumentsDirectory))
                    System.IO.Directory.CreateDirectory(UserMyDocumentsDirectory);

                preferences = new Preferences();
            }
            else if (preferences == null)
            {
                // Create an instance of the XmlSerializer class;
                // specify the type of object to serialize.
                XmlSerializer serializer = new XmlSerializer(typeof(Preferences));

                /* If the XML document has been altered with unknown 
                nodes or attributes, handle them with the 
                UnknownNode and UnknownAttribute events.*/
                serializer.UnknownNode += new XmlNodeEventHandler(Serializer_UnknownNode);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(Serializer_UnknownAttribute);

                // A FileStream is needed to read the XML document.
                using (FileStream fs = new FileStream(FilePreferencesXml, FileMode.Open))
                {
                    /* Use the Deserialize method to restore the object's state with data from the XML document. */
                    preferences = (Preferences)serializer.Deserialize(fs);
                }
            }
        }

        /// <summary>
        /// Method to load application options.
        /// </summary>
        public static void LoadOptions()
        {
            if (!File.Exists(FileOptionsXml))
            {
                if (!System.IO.Directory.Exists(ConfigDirectory))
                {
                    System.IO.Directory.CreateDirectory(UserMyDocumentsDirectory);
                }

                options = new Options();
            }
            else if (options == null)
            {
                // Create an instance of the XmlSerializer class;
                // specify the type of object to serialize.
                XmlSerializer serializer = new XmlSerializer(typeof(Options));

                /* If the XML document has been altered with unknown 
                nodes or attributes, handle them with the 
                UnknownNode and UnknownAttribute events.*/
                serializer.UnknownNode += new XmlNodeEventHandler(Serializer_UnknownNode);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(Serializer_UnknownAttribute);

                // A FileStream is needed to read the XML document.
                using (FileStream fs = new FileStream(FileOptionsXml, FileMode.Open))
                {
                    /* Use the Deserialize method to restore the object's state with data from the XML document. */
                    options = (Options)serializer.Deserialize(fs);
                }
            }
        }

        /// <summary>
        /// Method to save application preferences and options.
        /// </summary>
        public static void Save()
        {
            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            XmlSerializer serializerPreferences = new XmlSerializer(typeof(Preferences));
            using (TextWriter writer = new StreamWriter(FilePreferencesXml))
            {
                serializerPreferences.Serialize(writer, preferences);
            }

            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            XmlSerializer serializerOptions = new XmlSerializer(typeof(Options));
            using (TextWriter writer = new StreamWriter(FileOptionsXml))
            {
                serializerOptions.Serialize(writer, options);
            }
        }

        /// <summary>
        /// Method to handle unknown-ed XML nodes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Serializer_UnknownNode (object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        /// <summary>
        /// Method to handle unknown-ed XML attributes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Serializer_UnknownAttribute (object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
        }

        #endregion
    }
}