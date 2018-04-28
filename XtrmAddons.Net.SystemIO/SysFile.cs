using System;
using System.IO;
using System.Threading.Tasks;

namespace XtrmAddons.Net.SystemIO
{
    /// <summary>
    /// Class XtrmAddons Net System IO File.
    /// </summary>
    public static class SysFile
    {
        #region Methods

        /// <summary>
        /// Method to create data file; fail if exists.
        /// </summary>
        /// <param name="filename">The full path name of the file.</param>
        /// <param name="content">The content to add or append in the file.</param>
        /// <param name="append">Append or create new file content.</param>
        public static void Create(string filename, string content, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(filename, append))
            {
                writer.WriteLine(content);
            }
        }

        /// <summary>
        /// Method to create data file; fail if exists.
        /// </summary>
        /// <param name="filename">The full path name of the file.</param>
        /// <param name="content">The content to add or append in the file.</param>
        /// <param name="append">Append or create new file content.</param>
        public static async void CreateAsync(string filename, string content, bool append = false)
        {
            await Task.Run(() =>
            {
                Create(filename, content, append);
            });
        }

        /// <summary>
        /// Method to check if a file exists.
        /// </summary>
        /// <param name="filename">The full path name of the file.</param>
        /// <returns>True if the file exists, otherwise false.</returns>
        public static Task<bool> ExistsAsync(string filename)
        {
            return Task.Run(() =>
            {
                return File.Exists(filename);
            });
        }

        /// <summary>
        /// Method to check and get a unique file name by auto increment.
        /// </summary>
        /// <param name="fullPath">A full path of a file to check.</param>
        /// <returns>A unique full path for a new file.</returns>
        public static string GetUniqueFilename(string fullPath)
        {
            if (!Path.IsPathRooted(fullPath))
                fullPath = Path.GetFullPath(fullPath);

            if (File.Exists(fullPath))
            {
                String filename = Path.GetFileName(fullPath);
                String path = fullPath.Substring(0, fullPath.Length - filename.Length);
                String filenameWOExt = Path.GetFileNameWithoutExtension(fullPath);
                String ext = Path.GetExtension(fullPath);
                int n = 1;
                do
                {
                    fullPath = Path.Combine(path, String.Format("{0} ({1}){2}", filenameWOExt, (n++), ext));
                }
                while (File.Exists(fullPath));
            }
            return fullPath;
        }

        /// <summary>
        /// Method to check and get a unique file name by auto increment asynchronous.
        /// </summary>
        /// <param name="fullPath">A full path of a file to check.</param>
        /// <returns>A unique full path for a new file.</returns>
        public static async Task<string> GetUniqueFilenameAsync(string fullPath)
        {
            return await Task.Run(() =>
            {
                return GetUniqueFilenameAsync(fullPath);
            });
        }

        #endregion
    }
}