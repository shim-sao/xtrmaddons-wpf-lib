using System.Diagnostics;
using XtrmAddons.Net.Application.Serializable.Elements.XmlData;
using XtrmAddons.Net.Application.Serializable.Elements.XmlRemote;
using XtrmAddons.Net.Application.Serializable.Elements.XmlStorage;
using XtrmAddons.Net.Network;

namespace XtrmAddons.Net.Application.Examples.Options
{
    /// <summary>
    /// Class XtrmAddons Net Application Examples Options.
    /// </summary>
    public static class OptionsExample
    {
        /// <summary>
        /// Method example of options directories settings adding.
        /// </summary>
        public static void AddStorageDirectories()
        {
            // Example of directory placed in the options [\ApplicationTests\My Pictures] directory
            // C:\Windows\Temp\ApplicationTests\My Pictures
            ApplicationBase.Options.Storage.Directories.Add
            (
                new Directory
                {
                    Key = "My Pictures",
                    RelativePath = "ApplicationTests\\My Pictures",
                    IsRelative = true,
                    Root = "C:\\Windows\\Temp"
                }
            );
        }

        /// <summary>
        /// Method example of options directories settings adding.
        /// </summary>
        public static void AddDataDatabases()
        {
            Database database = new Database
            {
                Key = "Default",
                Name = "My Database by Default",
                Default = true,
                Host = "localhost",
                Port = "8080",
                UserName = "Root",
                Password = "toor",
                Source = "",
                Type = DatabaseType.MySQL,
                Comment = "Example of database settings"
            };
            ApplicationBase.Options.Data.Databases.AddDefaultUnique(database);
        }

        /// <summary>
        /// Method to add some servers informations.
        /// </summary>
        public static void AddServersInformations()
        {
            // Get default server in preferences if exists.
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

            // Retrieve default server settings.
            server = ApplicationBase.Options.Remote.Servers.FindDefault();
            Trace.WriteLine("---- FindDefault()");
            Trace.WriteLine("Name : " + server.Name);
            Trace.WriteLine("Key : " + server.Key);
            Trace.WriteLine("Host : " + server.Host);
            Trace.WriteLine("Port : " + server.Port);
            Trace.WriteLine("UserName : " + server.UserName);
            Trace.WriteLine("Password : " + server.Password);
            Trace.WriteLine("Comment : " + server.Comment);

            // Example of another server settings, not as default.
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
            ApplicationBase.Options.Remote.Servers.Add(server2);

            // Retrieve previews settings by Host for example.
            server2 = ApplicationBase.Options.Remote.Servers.Find(x => x.Host == NetworkInformations.GetLocalHostIp());

            Trace.WriteLine("---- Find(x => x.Host == NetworkInformations.GetLocalHostIp())");
            Trace.WriteLine("Server : " + server2.Name);
            Trace.WriteLine("Server Key : " + server2.Key);
            Trace.WriteLine("Host : " + server2.Host);
            Trace.WriteLine("Port : " + server2.Port);
            Trace.WriteLine("UserName : " + server2.UserName);
            Trace.WriteLine("Password : " + server2.Password);
            Trace.WriteLine("Comment : " + server2.Comment);
            Trace.WriteLine("-------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Method to initialize default server informations.
        /// </summary>
        public static void AddClientsInformations()
        {
            // Add new client informations.
            Client client1 = new Client()
            {
                Key = "Client 1",
                Name = "My first Client",
                Default = true,
                Host = NetworkInformations.GetLocalHostIp(),
                Port = NetworkInformations.GetAvailablePort(6666).ToString(),
                UserName = "LoginIfRequired",
                Password = "PasswordIfRequired",
                Comment = "Example override default server informations."
            };
            ApplicationBase.Options.Remote.Clients.Add(client1);

            // Retrieve previews Client settings.
            client1 = ApplicationBase.Options.Remote.Clients.FindKey("Client 1");
            client1 = ApplicationBase.Options.Remote.Clients.FindKey("My first Client", "Name");
            client1 = ApplicationBase.Options.Remote.Clients.FindKey(NetworkInformations.GetLocalHostIp(), "Host");
        }
    }
}
