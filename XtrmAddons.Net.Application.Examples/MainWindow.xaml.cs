using System.Diagnostics;
using System.Windows;
using XtrmAddons.Net.Application.Examples.Options;
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
            ApplicationStart();
        }

        /// <summary>
        /// Method example of application start.
        /// </summary>
        public void ApplicationStart()
        {
            TextBox_UserApplicationData.Text = ApplicationBase.UserAppDataDirectory;
            TextBox_UserMyDocuments.Text = ApplicationBase.UserMyDocumentsDirectory;

            // Displays default application scheme directories.
            TextBox_Bin.Text = ApplicationBase.BinDirectory;
            TextBox_Cache.Text = ApplicationBase.CacheDirectory;
            TextBox_Config.Text = ApplicationBase.ConfigDirectory;
            TextBox_Data.Text = ApplicationBase.DataDirectory;
            TextBox_Theme.Text = ApplicationBase.ThemeDirectory;
            
            //
            InitializePreferences();
        }

        /// <summary>
        /// Method example of preferences setting.
        /// </summary>
        public void InitializePreferences()
        {
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");

            // Adding some application folders.
            Trace.WriteLine(string.Format("Path to application user documents : {0}", ApplicationBase.UserMyDocumentsDirectory));
            PreferencesExample.AddStorageDirectories();
            PreferencesExample.ReplaceStorageDirectories();

            OptionsExample.AddStorageDirectories();

            Trace.WriteLine("Application base directory = " + ApplicationBase.BaseDirectory);
            Trace.WriteLine("Application base directory = " + ApplicationBase.ApplicationFriendlyName);

            // Retrieving application folders absolute path.
            // ApplicationBase.Storage.Directories.Find(x => x.Key == "Config.Server")?.AbsolutePath
            string absoluteServerFolderName = ApplicationBase.Storage.Directories.FindKey("Config.Server")?.AbsolutePath;
            string absoluteDatabaseFolderName = ApplicationBase.Storage.Directories.FindKey("Config.Database")?.AbsolutePath;

            Trace.WriteLine("Config.Server = " + absoluteServerFolderName);
            Trace.WriteLine("Config.Database = " + absoluteDatabaseFolderName);
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
        }
    }
}
