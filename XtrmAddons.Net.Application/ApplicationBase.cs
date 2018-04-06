using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable;
using XtrmAddons.Net.Application.Serializable.Elements.XmlStorage;
using XtrmAddons.Net.Common.Extensions;
using XtrmAddons.Net.SystemIO;

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
        /// Variable application serializable preferences.
        /// </summary>
        private static Preferences preferences;

        /// <summary>
        /// Variable application serializable options.
        /// </summary>
        private static Options options;

        /// <summary>
        /// Variable application serializable user interface.
        /// </summary>
        private static UserInterface ui;

        /// <summary>
        /// Constant preferences XML file name. 
        /// </summary>
        private const string filePreferencesXmlName = "preferences.xml";

        /// <summary>
        /// Constant options XML file name.
        /// </summary>
        private const string fileOptionsXmlName = "options.xml";

        /// <summary>
        /// Constant user interface XML file name.
        /// </summary>
        private const string fileUiXmlName = "ui.xml";

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the preferences storage informations.
        /// </summary>
        public static StorageOptions Storage => preferences.Storage;

        /// <summary>
        /// Property to access to the application options informations.
        /// </summary>
        public static Options Options { get { return options; } }

        /// <summary>
        /// Property to access to the application user interface.
        /// </summary>
        public static UserInterface UI { get { return ui; } }

        /// <summary>
        /// Property to access to the preferences directory file absolute path.
        /// </summary>
        public static string FilePreferencesXml => Path.Combine(UserMyDocumentsDirectory, filePreferencesXmlName);

        /// <summary>
        /// Property to access to the options directory file absolute path.
        /// </summary>
        public static string FileOptionsXml => Path.Combine(ConfigDirectory, fileOptionsXmlName);

        /// <summary>
        /// Property to access to the user interface directory file absolute path.
        /// </summary>
        public static string FileUiXml => Path.Combine(ConfigDirectory, fileUiXmlName);

        /// <summary>
        /// Property to access to the application base directory.
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
        /// Property to access to the user defined language.
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
        /// <para>Property to access to the cache directory.</para>
        /// <para>A new cache directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public static string CacheDirectory
        {
            get => GetSpecialDirectory("Cache", BaseDirectory, SpecialDirectoriesName.Cache.Name());
            set => SetSpecialDirectory("Cache", value);
        }

        /// <summary>
        /// <para>Property to access to the application custom configuration directory.</para>
        /// <para>A new config directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public static string ConfigDirectory
        {
            get => GetSpecialDirectory("Config", BaseDirectory, SpecialDirectoriesName.Config.Name());
            set => SetSpecialDirectory("Config", value);
        }

        /// <summary>
        /// <para>Property to access to the application data directory.</para>
        /// <para>A new data directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public static string DataDirectory
        {
            get => GetSpecialDirectory("Data", BaseDirectory, SpecialDirectoriesName.Data.Name());
            set => SetSpecialDirectory("Data", value);
        }

        /// <summary>
        /// <para>Property to access to the application theme directory.</para>
        /// <para>A new theme directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public static string ThemeDirectory
        {
            get => GetSpecialDirectory("Theme", BaseDirectory, SpecialDirectoriesName.Theme.Name());
            set => SetSpecialDirectory("Theme", value);
        }

        /// <summary>
        /// <para>Property to access to the application bin directory.</para>
        /// <para>A new bin directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public static string BinDirectory
        {
            get => GetSpecialDirectory("Bin", UserAppDataDirectory, SpecialDirectoriesName.Bin.Name());
            set => SetSpecialDirectory("Bin", value);
        }

        /// <summary>
        /// <para>Property to access to the application plugin directory.</para>
        /// <para>A new plugin directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public static string PluginDirectory
        {
            get => GetSpecialDirectory("Plugin", UserAppDataDirectory, SpecialDirectoriesName.Plugin.Name());
            set => SetSpecialDirectory("Plugin", value);
        }

        /// <summary>
        /// <para>Property to access to the application logs directory.</para>
        /// <para>A new logs directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        public static string LogsDirectory
        {
            get => GetSpecialDirectory("Logs", UserAppDataDirectory, SpecialDirectoriesName.Logs.Name());
            set => SetSpecialDirectory("Logs", value);
        }

        /// <summary>
        /// Property to access to the default assets images directory.
        /// </summary>
        public static string AssetsImagesDefaultDirectory
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\Images\\Default"); }
        }

        /// <summary>
        /// Property to access to the default assets icons directory.
        /// </summary>
        public static string AssetsImagesIconsDirectory
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\Images\\Icons"); }
        }

        /// <summary>
        /// Property to get Window User My Documents path.
        /// </summary>
        /// <returns>The absolute path to Window User My Documents.</returns>
        public static string UserMyDocumentsDirectory
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ApplicationFriendlyName);

        /// <summary>
        /// Property to get Window User My Documents path.
        /// </summary>
        /// <returns>The absolute path to Window User My Documents.</returns>
        public static string UserAppDataDirectory
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ApplicationFriendlyName);

        /// <summary>
        /// <para>Method to get the application friendly name.</para>
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
            LoadUi();
        }

        /// <summary>
        /// Method to load and deserialize an XML file.
        /// </summary>
        /// <typeparam name="T">The Class of object to deserialize.</typeparam>
        /// <param name="filename">The file name, absolute file path.</param>
        /// <returns>A deserialized XML object.</returns>
        public static T Deserialize<T>(string filename) where T : class
        {
            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // If the XML document has been altered with unknown nodes or attributes, handle them with the UnknownNode and UnknownAttribute events.
            serializer.UnknownNode += new XmlNodeEventHandler(Serializer_UnknownNode);
            serializer.UnknownAttribute += new XmlAttributeEventHandler(Serializer_UnknownAttribute);

            // A FileStream is needed to read the XML document.
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                // Use the Deserialize method to restore the object's state with data from the XML document.
                return (T)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Method to load the application user interface.
        /// </summary>
        public static void LoadUi()
        {
            if (!File.Exists(FileUiXml))
            {
                if (!System.IO.Directory.Exists(UserMyDocumentsDirectory))
                {
                    System.IO.Directory.CreateDirectory(UserMyDocumentsDirectory);
                }

                ui = new UserInterface();
            }
            else if (preferences == null)
            {
                ui = Deserialize<UserInterface>(FileUiXml);
            }
        }

        /// <summary>
        /// Method to load the application preferences.
        /// </summary>
        public static void LoadPreferences()
        {
            if (!File.Exists(FilePreferencesXml))
            {
                if (!System.IO.Directory.Exists(UserMyDocumentsDirectory))
                {
                    System.IO.Directory.CreateDirectory(UserMyDocumentsDirectory);
                }

                preferences = new Preferences();
            }
            else if (preferences == null)
            {
                preferences = Deserialize<Preferences>(FilePreferencesXml);
            }
        }

        /// <summary>
        /// Method to load the application options.
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
                options = Deserialize<Options>(FileOptionsXml);
            }
        }

        /// <summary>
        /// Method to save the application preferences, options and user interface.
        /// </summary>
        public static void Save()
        {
            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            using (TextWriter writer = new StreamWriter(FilePreferencesXml))
            {
                XmlSerializer serializerPreferences = new XmlSerializer(typeof(Preferences));
                serializerPreferences.Serialize(writer, preferences);
            }

            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            using (TextWriter writer = new StreamWriter(FileOptionsXml))
            {
                XmlSerializer serializerOptions = new XmlSerializer(typeof(Options));
                serializerOptions.Serialize(writer, options);
            }

            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            using (TextWriter writer = new StreamWriter(FileUiXml))
            {
                XmlSerializer serializerUi = new XmlSerializer(typeof(UserInterface));
                serializerUi.Serialize(writer, ui);
            }
        }

        /// <summary>
        /// Method to handle unknown-ed XML nodes.
        /// </summary>
        /// <param name="sender">The object sender of the event</param>
        /// <param name="e">XML node event arguments.</param>
        private static void Serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        /// <summary>
        /// Method to handle unknown-ed XML attributes.
        /// </summary>
        /// <param name="sender">The object sender of the event</param>
        /// <param name="e">XML node event arguments.</param>
        private static void Serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
        }

        /// <summary>
        /// <para>Method to copy application configuration files to the user documents directory.</para>
        /// <para>Always replace user config documents by application default config documents.</para>
        /// </summary>
        public static Task CopyConfigFiles(bool Override = false)
        {
            return Task.Run(() =>
            {
                // Get installed application path.
                string src = Path.Combine(Environment.CurrentDirectory, "Config");

                // Copy configuration to defined user config directory.
                SysDirectory.Copy(src, ApplicationBase.ConfigDirectory, Override);
            });
        }

        /// <summary>
        /// <para>Method to get a special directory path from preferences.</para>
        /// <para>A new directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        /// <param name="prefName">The name of the preferences property.</param>
        /// <param name="root">The root path for the directory.</param>
        /// <param name="sdName">A special directory name.</param>
        /// <returns>The absolute path of the special directory.</returns>
        private static string GetSpecialDirectory(string prefName, string root, string sdName)
        {
           string path = preferences.SpecialDirectories.GetPropertyValue<string>(prefName);

            if (path.IsNullOrWhiteSpace())
            {
                path = Path.Combine(root, sdName);

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                preferences.SpecialDirectories.SetPropertyValue(prefName, path);
            }

            return path;
        }

        /// <summary>
        /// <para>Method to set a special directory path to preferences.</para>
        /// <para>A new directory will be created on the first call if the directory is not found.</para>
        /// </summary>
        /// <param name="prefName">The name of the preferences property.</param>
        /// <param name="value">The absolute path of the directory.</param>
        /// <returns>The value pasted or the absolute path of the special directory.</returns>
        private static string SetSpecialDirectory(string prefName, string value)
        {
            Task.Run(() =>
            {
                if (!System.IO.Directory.Exists(value))
                {
                    System.IO.Directory.CreateDirectory(value);
                }
            });

            return (string)preferences.SpecialDirectories.SetPropertyValue(prefName, value);
        }
        
        #endregion
    }
}