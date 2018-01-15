using System;
using System.Windows;
using XtrmAddons.Net.Application.Serializable.Elements.XmlDirectories;
using XtrmAddons.Net.Application.Serializable.Elements.XmlServerInfo;
using XtrmAddons.Net.Network;

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


            InitializeFolders();
            InitializeServerInformations();

            ApplicationBase.Save();
        }


        public void InitializeFolders()
        {
            // Adding some application folders.
            Console.WriteLine(string.Format("Path to application user documents : {0}", ApplicationBase.UserMyDocumentsDirectory));

            ApplicationBase.Directories.Set("cfg.server", "Server", true, SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Config));
            ApplicationBase.Directories.Set("cfg.database", "Database", true, SpecialDirectoriesExtensions.RootDirectory(SpecialDirectoriesName.Config));

            // Retrieving application folders absolute path.
            Console.WriteLine("cfg.server = " + ApplicationBase.Directories.Find("cfg.server").AbsolutePath);
            Console.WriteLine("cfg.database = " + ApplicationBase.Directories.Find("cfg.database").AbsolutePath);
        }

        /// <summary>
        /// Method to initialize default server informations.
        /// </summary>
        public static void InitializeServerInformations()
        {
            // Get default server in preferences.
            Console.WriteLine("Initializing HTTP server informations. Please wait...");
            ServerInfo server = ApplicationBase.Options.Servers.Default();

            // Create default server parameters if not exists.
            if (server == null || server.Key == null)
            {
                server = ApplicationBase.Options.Servers.Set
                    (
                        "default",
                        ServerInfoType.Server,
                        true,
                        NetworkInformations.GetLocalHostIp(),
                        NetworkInformations.GetAvailablePort(6666).ToString(),
                        "LoginIfRequired",
                        "PasswordIfRequired",
                        "Example default server informations."
                    );
            }

            server = ApplicationBase.Options.Servers.Find("Host", "123");

            server = ApplicationBase.Options.Servers.Find("Host", NetworkInformations.GetLocalHostIp());

            // server = ApplicationBase.Options.Servers.Find("Toto", "123");

            Console.WriteLine("Server : " + server.Name);
            Console.WriteLine("Server Key : " + server.Key);
            Console.WriteLine("Host : " + server.Host);
            Console.WriteLine("Port : " + server.Port);
            Console.WriteLine("UserName : " + server.UserName);
            Console.WriteLine("Password : " + server.Password);
            Console.WriteLine("Comment : " + server.Comment);
        }
    }
}
