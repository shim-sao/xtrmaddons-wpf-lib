using System.Diagnostics;
using XtrmAddons.Net.Application.Serializable.Elements.XmlStorage;

namespace XtrmAddons.Net.Application.Examples.Preferences
{
    /// <summary>
    /// <para>Class XtrmAddons .Net Application Examples Preferences.</para>
    /// <para>This Class privides some examples to set application preferences like application directories...</para>
    /// </summary>
    public static class PreferencesExample
    {
        /// <summary>
        /// Method example of application directories settings adding.
        /// </summary>
        public static void AddStorageDirectories()
        {
            Trace.WriteLine("--- PreferencesExample.AddStorageDirectories()");

            // Example of directory placed in the application \Config directory
            // {application}\Config\Server
            ApplicationBase.Storage.Directories.Add
            (
                new Directory
                {
                    Key = "Config.server",
                    RelativePath = "Server",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Config)
                }
            );

            // Retrieving previews directory settings.
            string absoluteServerFolderName = ApplicationBase.Storage.Directories.FindKey("Config.Server")?.AbsolutePath;
            Trace.WriteLine("Config.Server = " + absoluteServerFolderName);


            // Example of directory placed in the application \Data directory
            // {application}\Data\Database
            ApplicationBase.Storage.Directories.Add
            (
                new Directory
                {
                    Key = "Config.database",
                    RelativePath = "Database",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Data)
                }
            );

            // Retrieving previews directory settings.
            string absoluteDatabaseFolderName = ApplicationBase.Storage.Directories.FindKey("Config.Database")?.AbsolutePath;
            Trace.WriteLine("Config.Database = " + absoluteDatabaseFolderName);
        }

        /// <summary>
        /// Method example of application directories settings replace.
        /// </summary>
        public static void ReplaceStorageDirectories()
        {
            Trace.WriteLine("--- PreferencesExample.ReplaceStorageDirectories()");

            // Example of directory placed in the application \Config directory
            // {application}\Config\Server Replace
            ApplicationBase.Storage.Directories.ReplaceKeyUnique
            (
                new Directory
                {
                    Key = "Config.Server",
                    RelativePath = "Server Replace",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Config)
                }
            );

            // Retrieving previews directory settings.
            string absoluteServerFolderName = ApplicationBase.Storage.Directories.FindKey("Config.Server")?.AbsolutePath;
            Trace.WriteLine("Config.Server = " + absoluteServerFolderName);

            // Example of directory placed in the application \Data directory
            // {application}\Data\Database Replace
            ApplicationBase.Storage.Directories.ReplaceKeyUnique
            (
                new Directory
                {
                    Key = "Config.Database",
                    RelativePath = "Database Replace",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Data)
                }
            );

            // Retrieving previews directory settings.
            string absoluteDatabaseFolderName = ApplicationBase.Storage.Directories.FindKey("Config.Database")?.AbsolutePath;
            Trace.WriteLine("Config.Database = " + absoluteDatabaseFolderName);
        }
    }
}
