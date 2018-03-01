using System;
using System.Diagnostics;
using System.Windows;
using XtrmAddons.Net.Application.Examples.Preferences;

namespace XtrmAddons.Net.Application.Examples
{
    /// <summary>
    /// Class XtrmAddons Net Application Examples.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Class XtrmAddons Net Application Examples Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeApplication();
        }

        /// <summary>
        /// Method example of application start.
        /// </summary>
        public void InitializeApplication()
        {
            // Starting the application
            // The application loads options & parameters.
            Console.WriteLine("Starting the application options & parameters. Please wait...");
            ApplicationBase.Start();

            Console.WriteLine("User Application Data = " + ApplicationBase.UserAppDataDirectory);
            TextBox_UserApplicationData.Text = ApplicationBase.UserAppDataDirectory;

            Console.WriteLine("User My Documents = " + ApplicationBase.UserMyDocumentsDirectory);
            TextBox_UserMyDocuments.Text = ApplicationBase.UserMyDocumentsDirectory;

            // Displays default application scheme directories.
            TextBox_Bin.Text = ApplicationBase.BinDirectory;
            TextBox_Cache.Text = ApplicationBase.CacheDirectory;
            TextBox_Config.Text = ApplicationBase.ConfigDirectory;
            TextBox_Data.Text = ApplicationBase.DataDirectory;
            TextBox_Theme.Text = ApplicationBase.ThemeDirectory;


            InitializePreferences();

            ApplicationBase.Save();
        }

        /// <summary>
        /// Method example of preferences setting.
        /// </summary>
        public void InitializePreferences()
        {
            // Adding some application folders.
            Console.WriteLine(string.Format("Path to application user documents : {0}", ApplicationBase.UserMyDocumentsDirectory));
            PreferencesExample preferences = new PreferencesExample();

            // Retrieving application folders absolute path.
            // ApplicationBase.Storage.Directories.Find(x => x.Key == "Config.Server")?.AbsolutePath
            string absoluteServerFolderName = ApplicationBase.Storage.Directories.FindKey("Config.Server")?.AbsolutePath;
            string absoluteDatabaseFolderName = ApplicationBase.Storage.Directories.FindKey("Config.Database")?.AbsolutePath;

            Trace.WriteLine("Config.Server = " + absoluteServerFolderName);
            Trace.WriteLine("Config.Database = " + absoluteDatabaseFolderName);
        }
    }
}
