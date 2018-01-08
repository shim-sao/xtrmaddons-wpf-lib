using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace XtrmAddons.Net.Application.Tools
{
    /// <summary>
    /// Class WPF Application Tools.
    /// </summary>
    public static class ApplicationTools
    {
        /// <summary>
        /// Method to grant file access to everybody.
        /// </summary>
        /// <param name="fullPath">The directory full path.</param>
        public static void GrantApplication(string fullPath)
        {
            FileSystemAccessRule rule = new FileSystemAccessRule("ALL_APPLICATION_PACKAGES", FileSystemRights.FullControl, AccessControlType.Allow);
            FileSecurity fSecurity = File.GetAccessControl(fullPath);
            fSecurity.SetAccessRule(rule);
            File.SetAccessControl(fullPath, fSecurity);
        }

        /// <summary>
        /// Method to get the current user directory full path.
        /// </summary>
        /// <returns>The current user directory full path</returns>
        public static string GetCurrentUserDirectory()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }

            return path;
        }

        /// <summary>
        /// Method to grant file access to everybody.
        /// </summary>
        /// <param name="fullPath">The directory full path.</param>
        public static void GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(
                new FileSystemAccessRule(
                    new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                    FileSystemRights.FullControl,
                    InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                    PropagationFlags.NoPropagateInherit,
                    AccessControlType.Allow
                )
            );

            dInfo.SetAccessControl(dSecurity);
        }
    }
}