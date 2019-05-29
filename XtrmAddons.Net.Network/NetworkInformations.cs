using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XtrmAddons.Net.Network
{
    /// <summary>
    /// Class XtrmAddons Net Common Network Informations.
    /// </summary>
    public class NetworkInformations
    {
        #region Variables

        /// <summary>
        /// When a client IP can't be
        /// </summary>
        /// <see href="https://stackoverflow.com/questions/32297517/how-to-get-local-ip-address-behind-the-proxy"/>
        public const string unknownIPV4 = "0.0.0.0";

        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex regIPV4Address = new Regex(@"\b([0-9]{1,3}\.){3}[0-9]{1,3}$",
                                                                RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        #endregion



        #region Methods

        /// <summary>
        /// Method to return true if this is a private network IP
        /// http://en.wikipedia.org/wiki/Private_network
        /// </summary>
        /// <param name="s"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public static bool IsPrivateIPV4(string s, bool proxy = true)
        {
            return s.StartsWith(
                "192.168.", StringComparison.InvariantCulture)
                || s.StartsWith("127.0.0.", StringComparison.InvariantCulture)
                || (proxy && s.StartsWith("10.", StringComparison.InvariantCulture));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adapterProperties"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public static string GetUnicastIPV4Address(IPInterfaceProperties adapterProperties, bool proxy = true)
        {
            UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
            if (uniCast != null)
            {
                foreach (UnicastIPAddressInformation uni in uniCast)
                {
                    Console.WriteLine("Unicast Address V4 ......................... : {0}", uni.Address);
                    if (IsPrivateIPV4($"{uni.Address}", proxy))
                    {
                        Console.WriteLine("Unicast Address V4 private ................... : {0}", uni.Address);
                        return $"{uni.Address}";
                    }
                }
            }

            return unknownIPV4;
        }

        /// <summary>
        /// Method to get localhost IP address.
        /// </summary>
        /// <returns>The local IP address.</returns>
        public static string GetLocalNetworkIp(bool proxy = true)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                string ip = GetUnicastIPV4Address(adapter.GetIPProperties(), proxy);
                if (ip != unknownIPV4)
                {
                    return ip;
                }
            }

            return unknownIPV4;
        }
        
        /// <summary>
        /// Method to get local network IP address asynchronous.
        /// </summary>
        /// <returns>The local IP address.</returns>
        public static async Task<string> GetLocalNetworkIpAsync()
        {
            return await Task.Run(() =>
            {
                return GetLocalNetworkIp();
            });
        }
        
        /// <summary>
        /// Method to check for used ports and retrieves the first free port
        /// </summary>
        /// <param name="startingPort">The starting port.</param>
        /// <returns>A free port or 0 if it did not find a free port</returns>
        public static int GetAvailablePort(int startingPort)
        {
            IPEndPoint[] endPoints;
            List<int> portArray = new List<int>();

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            //getting active connections
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            portArray.AddRange(from n in connections
                               where n.LocalEndPoint.Port >= startingPort
                               select n.LocalEndPoint.Port);

            //getting active tcp listeners - WCF service listening in tcp
            endPoints = properties.GetActiveTcpListeners();
            portArray.AddRange(from n in endPoints
                               where n.Port >= startingPort
                               select n.Port);

            //getting active udp listeners
            endPoints = properties.GetActiveUdpListeners();
            portArray.AddRange(from n in endPoints
                               where n.Port >= startingPort
                               select n.Port);

            portArray.Sort();

            for (int i = startingPort; i < UInt16.MaxValue; i++)
                if (!portArray.Contains(i))
                    return i;

            return 0;
        }

        /// <summary>
        /// Method to check for used ports and retrieves the first free port asyncronous.
        /// </summary>
        /// <param name="startingPort">The starting port.</param>
        /// <returns>A free port or 0 if it did not find a free port</returns>
        public static async Task<int> GetAvailablePortAsync(int startingPort)
        {
            return await Task.Run(() =>
            {
                return GetAvailablePort(startingPort);
            });
        }

        /// <summary>
        /// Provides information about network interfaces that support Internet Protocol version 4 (IPv4) 
        /// or Internet Protocol version 6 (IPv6).
        /// The following code example displays address information.
        /// </summary>
        /// <param name="adapterProperties">A network adapter properties object</param>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/system.net.networkinformation.ipinterfaceproperties?view=netframework-4.8"/>
        public static void ShowIPAddresses(IPInterfaceProperties adapterProperties)
        {
            IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
            if (dnsServers != null)
            {
                foreach (IPAddress dns in dnsServers)
                {
                    Console.WriteLine("  DNS Servers ............................. : {0}",
                        dns.ToString()
                   );
                }
            }
            IPAddressInformationCollection anyCast = adapterProperties.AnycastAddresses;
            if (anyCast != null)
            {
                foreach (IPAddressInformation any in anyCast)
                {
                    Console.WriteLine("  Anycast Address .......................... : {0} {1} {2}",
                        any.Address,
                        any.IsTransient ? "Transient" : "",
                        any.IsDnsEligible ? "DNS Eligible" : ""
                    );
                }
                Console.WriteLine();
            }

            MulticastIPAddressInformationCollection multiCast = adapterProperties.MulticastAddresses;
            if (multiCast != null)
            {
                foreach (IPAddressInformation multi in multiCast)
                {
                    Console.WriteLine("  Multicast Address ....................... : {0} {1} {2}",
                        multi.Address,
                        multi.IsTransient ? "Transient" : "",
                        multi.IsDnsEligible ? "DNS Eligible" : ""
                    );
                }
                Console.WriteLine();
            }
            UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
            if (uniCast != null)
            {
                string lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
                foreach (UnicastIPAddressInformation uni in uniCast)
                {
                    DateTime when;

                    Console.WriteLine("  Unicast Address ......................... : {0}", uni.Address);
                    Console.WriteLine("     Prefix Origin ........................ : {0}", uni.PrefixOrigin);
                    Console.WriteLine("     Suffix Origin ........................ : {0}", uni.SuffixOrigin);
                    Console.WriteLine("     Duplicate Address Detection .......... : {0}",
                        uni.DuplicateAddressDetectionState);

                    // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM
                    // if en-us is the current culture.

                    // Calculate the date and time at the end of the lifetimes.    
                    when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressValidLifetime);
                    when = when.ToLocalTime();
                    Console.WriteLine("     Valid Life Time ...................... : {0}",
                        when.ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture)
                    );
                    when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressPreferredLifetime);
                    when = when.ToLocalTime();
                    Console.WriteLine("     Preferred life time .................. : {0}",
                        when.ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture)
                    );

                    when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.DhcpLeaseLifetime);
                    when = when.ToLocalTime();
                    Console.WriteLine("     DHCP Leased Life Time ................ : {0}",
                        when.ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture)
                    );
                }
                Console.WriteLine();
            }
        }

        #endregion
    }
}