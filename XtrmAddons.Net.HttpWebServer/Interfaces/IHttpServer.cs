using System;
using System.Net;
using XtrmAddons.Net.HttpWebServer.Responses;

namespace XtrmAddons.Net.HttpWebServer.Interfaces
{
    /// <summary>
    /// Class XtrmAddons Net Http Server Interface.
    /// </summary>
    public interface IHttpServer : IDisposable
    {
        #region Properties

        /// <summary>
        /// Property to access to the Http Listener.
        /// </summary>
        HttpListener Listener { get; }

        #endregion



        #region Methods

        /// <summary>
        /// Method to initialize and start server for connections listening.
        /// </summary>
        /// <param name="prefix">The prefix for the server urls</param>
        void Start(string prefix = null);

        /// <summary>
        /// Method to run the web server.
        /// </summary>
        void Run();

        /// <summary>
        /// Method to stop the web server.
        /// </summary>
        void Stop();

        /// <summary>
        /// Method to output response of the server.
        /// </summary>
        /// <param name="ctx">The Http listener context to output.</param>
        /// <returns>The response in string format.</returns>
        WebServerResponseData GetResponse(HttpListenerContext ctx);

        #endregion
    }
}
