using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace XtrmAddons.Net.Network
{
    /// <summary>
    /// Class XtrmAddons Net Common Network ACL checker.
    /// </summary>
    public static class NetworkAclChecker
    {
        /// <summary>
        /// Method to add reserved URL to the ACL checker.
        /// </summary>
        /// <param name="address">The Url to add to the ACL checker.</param>
        public static void NetshAddAddress(string address)
        {
            NetshAddAddress(address, Environment.UserDomainName, Environment.UserName);
        }

        /// <summary>
        /// Method to add reserved URL to the ACL checker asynchronous.
        /// </summary>
        /// <param name="address">The Url to add to the ACL checker.</param>
        public static async Task AddAddressAsync(string address)
        {
            await Task.Run(() =>
            {
                AddAddress(address);
            });
        }

        /// <summary>
        /// Method to add reserved URL to the ACL checker.
        /// </summary>
        /// <param name="address">The address to add to the ACL checker.</param>
        /// <param name="domain">Domain name.</param>
        /// <param name="user">User name.</param>
        public static void NetshAddAddress(string address, string domain, string user)
        {
            NetshRunAs(string.Format(@"http add urlacl url={0} user={1}\{2}", address, domain, user));
        }

        /// <summary>
        /// Method to add reserved URL to the ACL checker asynchronous.
        /// </summary>
        /// <param name="address">The address to add to the ACL checker.</param>
        /// <param name="domain">Domain name.</param>
        /// <param name="user">User name.</param>
        public static async Task NetshAddAddressAsync(string address, string domain, string user)
        {
            await Task.Run(() =>
            {
                NetshAddAddress(address, domain, user);
            });
        }

        /// <summary>
        /// Method to delete reserved URL from the ACL checker.
        /// </summary>
        /// <param name="address">The address to delete from the ACL checker.</param>
        public static void NetshDeleteAddress(string address)
        {
            NetshRunAs(string.Format(@"http delete urlacl url={0}", address));
        }

        /// <summary>
        /// Method to delete reserved URL from the ACL checker asynchronous.
        /// </summary>
        /// <param name="address">The address to delete from the ACL checker.</param>
        public static async void NetshDeleteAddressAsync(string address)
        {
            await Task.Run(() =>
            {
                NetshDeleteAddress(address);
            });
        }

        /// <summary>
        /// Method to execute netsh command.
        /// </summary>
        /// <param name="args">netsh command arguments.</param>
        public static void NetshRunAs(string args)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", args);
            psi.Verb = "runas";
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = true;

            Process.Start(psi).WaitForExit();
        }

        /// <summary>
        /// Method to execute netsh command asynchronous.
        /// </summary>
        /// <param name="args">netsh command arguments.</param>
        public static async Task NetshRunAsAsync(string args)
        {
            await Task.Run(() =>
            {
                NetshRunAs(args);
            });
        }

        /// <summary>
        /// Method to format string URL.
        /// </summary>
        /// <param name="hostname">The host name.</param>
        /// <param name="port">The remote port.</param>
        /// <param name="protocol">The protocol of transport.By default HTTP</param>
        /// <returns>An Url formated string.</returns>
        public static string FormatURL(string hostname, string port, string protocol = "http")
        {
            return protocol + "://" + hostname + ":" + port + "/";
        }
    }
}
