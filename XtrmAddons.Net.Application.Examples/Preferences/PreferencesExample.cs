using System;
using System.Diagnostics;
using XtrmAddons.Net.Application.Serializable.Elements.XmlRemote;
using XtrmAddons.Net.Application.Serializable.Elements.XmlStorage;
using XtrmAddons.Net.Network;

namespace XtrmAddons.Net.Application.Examples.Preferences
{
    /// <summary>
    /// <para>Class XtrmAddons .Net Application Examples Preferences.</para>
    /// <para>This Class privides some examples to set application preferences like application directories...</para>
    /// </summary>
    public class PreferencesExample
    {
        /// <summary>
        /// Class XtrmAddons .Net Application Examples Preferences Constructor.
        /// </summary>
        public PreferencesExample()
        {
            // Add some application directories.
            AddStorageDirectories();

            // Replace some application directories name (path).
            ReplaceStorageDirectories();

            // Adding a default server configuration.
            InitializeServerInformations();
        }

        /// <summary>
        /// Method example of application directories settings adding.
        /// </summary>
        private void AddStorageDirectories()
        {
            // Example of directory placed in the application \Config directory
            // {application}\Config\Server
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

            // Example of directory placed in the application \Data directory
            // {application}\Data\Database
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

        /// <summary>
        /// Method example of application directories settings replace.
        /// </summary>
        private void ReplaceStorageDirectories()
        {
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
        }

        /// <summary>
        /// Method to initialize default server informations.
        /// </summary>
        public static void InitializeServerInformations()
        {
            // Get default server in preferencesif exists.
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Initializing HTTP server informations. Please wait...");

            Server server = ApplicationBase.Options.Remote.Servers.FindDefault();

            // Cheking if the server informations are already set.
            if (server == null || server.Key == null)
            {
                // Create new default server parameters
                ApplicationBase.Options.Remote.Servers.Add(new Server
                {
                    Key = "default",
                    Name = "Server by Default",
                    Default = true,
                    Host = "127.0.0.1",
                    Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                    UserName = "LoginIfRequired",
                    Password = "PasswordIfRequired",
                    Comment = "An example of default server informations settings."
                });

                // Retrieve previews set.
                server = ApplicationBase.Options.Remote.Servers.FindDefault();
                Trace.WriteLine("---- Add()");
                Trace.WriteLine("Name : " + server.Name);
                Trace.WriteLine("Key : " + server.Key);
                Trace.WriteLine("Host : " + server.Host);
                Trace.WriteLine("Port : " + server.Port);
                Trace.WriteLine("UserName : " + server.UserName);
                Trace.WriteLine("Password : " + server.Password);
                Trace.WriteLine("Comment : " + server.Comment);

                // Create new default server parameters
                // Add unique Server informations, replace settings if already exists.
                ApplicationBase.Options.Remote.Servers.AddDefaultUnique(new Server
                {
                    Key = "default",
                    Name = "Unique Server by Default",
                    Default = true,
                    Host = NetworkInformations.GetLocalHostIp(),
                    Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                    UserName = "LoginIfRequired",
                    Password = "PasswordIfRequired",
                    Comment = "An example of an unique default server informations settings."
                });

                // Retrieve previews set.
                server = ApplicationBase.Options.Remote.Servers.FindDefault();
                Trace.WriteLine("---- AddDefaultUnique()");
                Trace.WriteLine("Name : " + server.Name);
                Trace.WriteLine("Key : " + server.Key);
                Trace.WriteLine("Host : " + server.Host);
                Trace.WriteLine("Port : " + server.Port);
                Trace.WriteLine("UserName : " + server.UserName);
                Trace.WriteLine("Password : " + server.Password);
                Trace.WriteLine("Comment : " + server.Comment);
            }

            server = ApplicationBase.Options.Remote.Servers.FindDefault();
            Trace.WriteLine("---- FindDefault()");
            Trace.WriteLine("Name : " + server.Name);
            Trace.WriteLine("Key : " + server.Key);
            Trace.WriteLine("Host : " + server.Host);
            Trace.WriteLine("Port : " + server.Port);
            Trace.WriteLine("UserName : " + server.UserName);
            Trace.WriteLine("Password : " + server.Password);
            Trace.WriteLine("Comment : " + server.Comment);
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Method to initialize default server informations.
        /// </summary>
        public static void ReplaceServerInformations()
        {
            // Get default server in preferencesif exists.
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Replacing HTTP server informations. Please wait...");
            Server server = ApplicationBase.Options.Remote.Servers.FindDefault();

            Server server1 = new Server();

            // Create default server parameters if not exists.
            if (server == null || server.Key == null)
            {
                // Create new default server parameters
                ApplicationBase.Options.Remote.Servers.Add(new Server
                {
                    Key = "default",
                    Name = "Server by Default",
                    Default = true,
                    Host = "127.0.0.1",
                    Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                    UserName = "LoginIfRequired",
                    Password = "PasswordIfRequired",
                    Comment = "An example of default server informations settings."
                });

                // Create new default server parameters
                ApplicationBase.Options.Remote.Servers.AddDefaultUnique(new Server
                {
                    Key = "default",
                    Name = "Server by Default override",
                    Default = true,
                    Host = NetworkInformations.GetLocalHostIp(),
                    Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                    UserName = "LoginIfRequired",
                    Password = "PasswordIfRequired",
                    Comment = "An example of default server informations settings."
                });
            }

            Server server2 = new Server()
            {
                Key = "AnotherServer",
                Name = "AnotherServer",
                Default = true,
                Host = NetworkInformations.GetLocalHostIp(),
                Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                UserName = "LoginIfRequired",
                Password = "PasswordIfRequired",
                Comment = "Example override default server informations."
            };



            Client client1 = new Client()
            {
                Key = "AnotherServer",
                Name = "AnotherServer",
                Default = true,
                Host = NetworkInformations.GetLocalHostIp(),
                Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                UserName = "LoginIfRequired",
                Password = "PasswordIfRequired",
                Comment = "Example override default server informations."
            };


            ApplicationBase.Options.Remote.Servers.Add(server2);
            ApplicationBase.Options.Remote.Clients.Add(client1);

            // Example : server not found = null
            // server = ApplicationBase.Options.Servers.Find("Host", "123");

            server = ApplicationBase.Options.Remote.Servers.Find(x => x.Host == NetworkInformations.GetLocalHostIp());

            // server = ApplicationBase.Options.Servers.Find("Toto", "123");

            Console.WriteLine("- server1 : no info if default is loaded");
            Console.WriteLine("Server : " + server1.Name);
            Console.WriteLine("Server Key : " + server1.Key);
            Console.WriteLine("Host : " + server1.Host);
            Console.WriteLine("Port : " + server1.Port);
            Console.WriteLine("UserName : " + server1.UserName);
            Console.WriteLine("Password : " + server1.Password);
            Console.WriteLine("Comment : " + server1.Comment);

            Console.WriteLine("- server2");
            Console.WriteLine("Server : " + server2.Name);
            Console.WriteLine("Server Key : " + server2.Key);
            Console.WriteLine("Host : " + server2.Host);
            Console.WriteLine("Port : " + server2.Port);
            Console.WriteLine("UserName : " + server2.UserName);
            Console.WriteLine("Password : " + server2.Password);
            Console.WriteLine("Comment : " + server2.Comment);
        }

    }
}
