using System;
using System.IO;
using System.Security.AccessControl;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.SystemIO
{
    /// <summary>
    /// <para>Class XtrmAddons Net System IO Directory Info Extensions.</para>
    /// <para>Provides additionals tools to manage system DirectoryInfo.</para>
    /// </summary>
    public static class DirectoryInfoExtensions
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
	        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion



        #region Methods

        /// <summary>
        /// Method to check if a Directory or Folder has Permissions.
        /// </summary>
        /// <param name="directoryInfo">The full path or name of the directory.</param>
        /// <param name="accessType">The file system rights to check.</param>
        /// <returns>True if the folder contains access type, otherwise False.</returns>
        /// <see href="http://technico.qnownow.com/how-to-check-read-or-write-permissions-on-a-folder-in-c/"/>
        public static bool HasDirectoryPermissions(this DirectoryInfo directoryInfo, FileSystemRights accessType)
        {
            if(directoryInfo.FullName.IsNullOrWhiteSpace())
            {
                ArgumentNullException e = new ArgumentNullException(nameof(accessType), "FileSystemRights argument must not be null !");
                log.Error(e.Output(), e);
                throw e;
            }

            if(directoryInfo.Exists == false)
            {
                DirectoryNotFoundException e = new DirectoryNotFoundException($"{directoryInfo.FullName} not found !");
                log.Info(e.Output(), e);
                throw e;
            }

            return SysDirectory.HasDirectoryPermissions(directoryInfo.FullName, accessType);
        }

        #endregion
    }
}
