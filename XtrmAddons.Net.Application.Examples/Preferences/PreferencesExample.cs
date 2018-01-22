using System;
using XtrmAddons.Net.Application.Serializable.Elements.XmlStorage;

namespace XtrmAddons.Net.Application.Examples.Preferences
{
    public class PreferencesExample
    {
        public PreferencesExample()
        {
            AddStorageDirectories();
            ReplaceStorageDirectories();
        }

        private void AddStorageDirectories()
        {
            ApplicationBase.Storage.Directories.Add
            (
                new Directory
                {
                    Key = "cfg.server",
                    RelativePath = "Server",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Config)
                }
            );

            ApplicationBase.Storage.Directories.Add
            (
                new Directory
                {
                    Key = "cfg.database",
                    RelativePath = "Database",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Data)
                }
            );
        }

        private void ReplaceStorageDirectories()
        {
            ApplicationBase.Storage.Directories.ReplaceKeyUnique
            (
                new Directory
                {
                    Key = "cfg.server",
                    RelativePath = "Server Replace",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Config)
                }
            );

            ApplicationBase.Storage.Directories.ReplaceKeyUnique
            (
                new Directory
                {
                    Key = "cfg.database",
                    RelativePath = "Database Replace",
                    IsRelative = true,
                    Root = SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Data)
                }
            );
        }
    }
}
