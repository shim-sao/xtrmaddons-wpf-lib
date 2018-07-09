using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;

namespace XtrmAddons.Net.SystemIO
{
    /// <summary>
    /// <para>Class XtrmAddons Net System IO Directory.</para>
    /// <para>Provides additionals tools to manage system directories.</para>
    /// </summary>
    public static class SysDirectory
    {
        #region Properties

        /// <summary>
        /// Property current user directory full path.
        /// </summary>
        public static string CurrentUserDirectory
        {
            get
            {
                string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    path = Directory.GetParent(path).ToString();
                }

                return path;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to get and create a directory.
        /// </summary>
        /// <param name="parts">The parts of the path to combine.</param>
        /// <returns>The absolute path to the directory</returns>
        public static string Create(string[] parts)
        {
            string destDir = Path.Combine(parts);
            Directory.CreateDirectory(Path.Combine(parts));
            return destDir;
        }

        /// <summary>
        /// Method to get and create a directory asynchronous.
        /// </summary>
        /// <param name="parts">The parts of the path to combine.</param>
        /// <returns>The absolute path to the directory</returns>
        public static async Task<string> CreateAsync(string[] parts)
        {
            return await Task.Run(() =>
            {
                return Create(parts);
            });
        }

        /// <summary>
        /// Method to get and create a directory.
        /// </summary>
        /// <param name="begin">The first part of the path to combine.</param>
        /// <param name="end">>The second part of the path to combine.</param>
        /// <returns>The absolute path to the directory.</returns>
        public static string Create(string begin, string end)
        {
            string destDir = Path.Combine(begin, end);
            Directory.CreateDirectory(destDir);
            return destDir;
        }

        /// <summary>
        /// Method to get and create a directory asynchronous.
        /// </summary>
        /// <param name="begin">The first part of the path to combine.</param>
        /// <param name="end">>The second part of the path to combine.</param>
        /// <returns>The absolute path to the directory.</returns>
        public static async Task<string> CreateAsync(string begin, string end)
        {
            return await Task.Run(() =>
            {
                return Create(begin, end);
            });
        }

        /// <summary>
        /// Method to grant directory files access to everybody.
        /// </summary>
        /// <param name="fullPath">The directory full path.</param>
        /// <param name="sid">The commonly security identifiant SID used.</param>
        /// <param name="rights">File system rights to grant.</param>
        public static void GrantAccess(string fullPath, WellKnownSidType sid, FileSystemRights rights)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(
                new FileSystemAccessRule(
                    new SecurityIdentifier(sid, null),
                    rights,
                    InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                    PropagationFlags.NoPropagateInherit,
                    AccessControlType.Allow
                )
            );

            dInfo.SetAccessControl(dSecurity);
        }

        /// <summary>
        /// Method to copy a directory and all its contents.
        /// </summary>
        /// <param name="source">The directory to copy.</param>
        /// <param name="target">The destination path.</param>
        /// <param name="Override">Override directories files.</param>
        public static void Copy(string source, string target, bool Override = false)
        {
            // Format folders paths.
            var SourcePath = source.TrimEnd('\\', ' ');
            var DestinationPath = target.TrimEnd('\\', ' ');

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
            {
                string dirDest = dirPath.Replace(SourcePath, DestinationPath);
                Directory.CreateDirectory(dirDest);
            }

            // Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    string newPathDest = newPath.Replace(SourcePath, DestinationPath);

                    if (!File.Exists(newPathDest) || Override)
                    {
                        if (File.Exists(newPathDest))
                        {
                            File.SetAttributes(newPathDest, File.GetAttributes(newPathDest) & ~FileAttributes.ReadOnly);
                        }

                        File.Copy(newPath, newPathDest, true);
                    }
                }
                catch (Exception e)
                {
                    throw new SystemException(string.Format("Cannot copy file [{0}] to [{1}] : {2}", SourcePath, DestinationPath, e.Message), e);
                }
            }
        }

        /// <summary>
        /// Method to copy a directory and all its contents.
        /// </summary>
        /// <param name="source">The directory to copy.</param>
        /// <param name="target">The destination path.</param>
        /// <param name="Override">Override directories files.</param>
        public static async void CopyAsync(string source, string target, bool Override = false)
        {
            await Task.Run(() =>
            {
                Copy(source, target, Override);
            });
        }
        
        /// <summary>
        /// Method to move all contents of a directory.
        /// </summary>
        /// <param name="source">The directory to move.</param>
        /// <param name="target">The destination path.</param>
        /// <param name="Override">Override directories files.</param>
        public static void Move(string source, string target, bool Override = true)
        {
            // Format folders paths.
            var sourcePath = source.TrimEnd('\\', ' ');
            var targetPath = target.TrimEnd('\\', ' ');

            // Create files list in all sub folders.
            var files = Directory
                .EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                .GroupBy(s => Path.GetDirectoryName(s));

            // Process on each sub folder.
            foreach (var folder in files)
            {
                // Create target sub folder path.
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);

                // Create sub folder.
                Directory.CreateDirectory(targetFolder);
                
                // Move each files.
                foreach (var file in folder)
                {
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    bool exists = File.Exists(targetFile);

                    try
                    {
                        if (exists && Override)
                        {
                            File.Delete(targetFile);
                            File.Move(file, targetFile);
                        }
                        else if(!exists)
                        {
                            File.Move(file, targetFile);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new SystemException(string.Format("Cannot move file [{0}] to [{1}] : {2}", file, targetFile, e.Message), e);
                    }
                }
            }

            Directory.Delete(source, true);
        }

        /// <summary>
        /// Method to move all contents of a directory asynchronous.
        /// </summary>
        /// <param name="source">The directory to move.</param>
        /// <param name="target">The destination path.</param>
        /// <param name="Override">Override directories files.</param>
        public static async void MoveAsync(string source, string target, bool Override = true)
        {
            await Task.Run(() =>
            {
                Move(source, target, Override);
            });
        }

        /// <summary>
        /// Method to check if a dirctory is empty.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns></returns>
        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        /// <summary>
        /// Method to check if a dirctory is empty.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns></returns>
        public static async Task<bool> IsDirectoryEmptyAsync(string path)
        {
            return await Task.Run(() =>
            {
                return !Directory.EnumerateFileSystemEntries(path).Any();
            });
        }

        /// <summary>
        /// Method to check if a Directory or Folder has Permissions.
        /// </summary>
        /// <param name="directoryPath">The full path or name of the directory.</param>
        /// <param name="accessType">The file system rights to check.</param>
        /// <returns>True if the folder contains access type, otherwise False.</returns>
        /// <see href="http://technico.qnownow.com/how-to-check-read-or-write-permissions-on-a-folder-in-c/"/>
        public static bool HasDirectoryPermissions(string directoryPath, FileSystemRights accessType)
        {
            bool hasAccess = true;
            try
            {
                AuthorizationRuleCollection collection
                    = Directory.GetAccessControl(directoryPath)
                     .GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

                foreach (FileSystemAccessRule rule in collection)
                {
                    if ((rule.FileSystemRights & accessType) > 0)
                    {
                        return hasAccess;
                    }
                }
            }
            catch
            {
                hasAccess = false;
            }

            return hasAccess;
        }

        #endregion
    }
}
