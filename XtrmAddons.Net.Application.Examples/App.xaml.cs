using System.Diagnostics;
using XtrmAddons.Net.Application.Examples.Options;
using XtrmAddons.Net.Application.Examples.Preferences;

namespace XtrmAddons.Net.Application.Examples
{
    /// <summary>
    /// Class XtrmAddons Net Application Examples Application.
    /// </summary>
    public partial class App : System.Windows.Application
    {
        /// <summary>
        /// Class XtrmAddons Net Application Examples Application Constructor.
        /// </summary>
        public App()
        {
            // Reset example : delete user my documents application folder.
            if(System.IO.Directory.Exists(ApplicationBase.UserMyDocumentsDirectory))
            {
                System.IO.Directory.Delete(ApplicationBase.UserMyDocumentsDirectory, true);
            }

            // Starting the application
            // The application loads options & parameters from files.
            // Create default files if not exists
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Starting the application options & parameters. Please wait...");
            ApplicationBase.Start();
            TraceStart();
            InitializePreferences();
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");

            // Add automatic application saving before application closing.
            Exit += App_Exit;
        }

        /// <summary>
        /// Method called before the application closing.
        /// </summary>
        /// <param name="sender">The object sender of the event</param>
        /// <param name="e">Exit event arguments.</param>
        private void App_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Saving the application options & parameters before exit. Please wait...");
            ApplicationBase.Save();
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Method to trace main application preferences.
        /// </summary>
        private void TraceStart()
        {
            Trace.WriteLine("Application Friendly Name = " + ApplicationBase.ApplicationFriendlyName);
            Trace.WriteLine("Application Roaming Directory = " + ApplicationBase.UserAppDataDirectory);
            Trace.WriteLine("User My Documents Directory = " + ApplicationBase.UserMyDocumentsDirectory);

            // Displays default application specials directories.
            Trace.WriteLine("--- Specials Directories ---");
            Trace.WriteLine("Bin = " + ApplicationBase.BinDirectory);
            Trace.WriteLine("Cache = " + ApplicationBase.CacheDirectory);
            Trace.WriteLine("Config = " + ApplicationBase.ConfigDirectory);
            Trace.WriteLine("Data = " + ApplicationBase.DataDirectory);
            Trace.WriteLine("Theme = " + ApplicationBase.ThemeDirectory);
        }

        /// <summary>
        /// Method example of custom preferences settings adding.
        /// </summary>
        public void InitializePreferences()
        {
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");

            // Adding some application folders.
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
