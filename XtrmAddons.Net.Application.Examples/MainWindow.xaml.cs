using System;
using System.Windows;
using XtrmAddons.Net.Application.Serializable.Elements.XmlStorage;
using XtrmAddons.Net.Application.Serializable.Elements.XmlRemote;
using XtrmAddons.Net.Network;
using XtrmAddons.Net.Application.Examples.Preferences;

namespace XtrmAddons.Net.Application.Examples
{
    /// <summary>
    /// Class XtrmAddons Net Application Examples.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeApplication();
        }


        public void InitializeApplication()
        {
            // Starting the application options & parameters.
            Console.WriteLine("Starting the application options & parameters. Please wait...");
            ApplicationBase.Start();


            InitializePreferences();
            InitializeServerInformations();

            ApplicationBase.Save();
        }


        public void InitializePreferences()
        {
            // Adding some application folders.
            Console.WriteLine(string.Format("Path to application user documents : {0}", ApplicationBase.UserMyDocumentsDirectory));
            PreferencesExample preferences = new PreferencesExample();

            // Retrieving application folders absolute path.
            Console.WriteLine("cfg.server = " + ApplicationBase.Storage.Directories.Find(x => x.Key == "cfg.server")?.AbsolutePath);
            Console.WriteLine("cfg.database = " + ApplicationBase.Storage.Directories.Find(x => x.Key == "cfg.database")?.AbsolutePath);
        }

        /// <summary>
        /// Method to initialize default server informations.
        /// </summary>
        public static void InitializeServerInformations()
        {
            // Get default server in preferences.
            Console.WriteLine("Initializing HTTP server informations. Please wait...");
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

            Console.WriteLine("- default");
            Console.WriteLine("Server : " + server.Name);
            Console.WriteLine("Server Key : " + server.Key);
            Console.WriteLine("Host : " + server.Host);
            Console.WriteLine("Port : " + server.Port);
            Console.WriteLine("UserName : " + server.UserName);
            Console.WriteLine("Password : " + server.Password);
            Console.WriteLine("Comment : " + server.Comment);

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
