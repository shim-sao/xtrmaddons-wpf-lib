using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace XtrmAddons.Net.Network
{
    /// <summary>
    /// Class XtrmAddons Net Common Network Informations.
    /// </summary>
    public class NetworkInformations
    {
        /// <summary>
        /// Method to get localhost IP address.
        /// </summary>
        /// <returns>The local IP address.</returns>
        public static string GetLocalHostIp()
        {
            string localIP;

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            if (localIP == null || localIP == "")
            {
                localIP = "127.0.0.1";
            }

            return localIP;
        }
        
        /// <summary>
        /// Method to get localhost IP address asynchronous.
        /// </summary>
        /// <returns>The local IP address.</returns>
        public static async Task<string> GetLocalHostIpAsync()
        {
            return await Task.Run(() =>
            {
                return GetLocalHostIp();
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
    }
}