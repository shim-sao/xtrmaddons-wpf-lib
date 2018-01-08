namespace XtrmAddons.Net.HttpWebServer.Events
{
    /// <summary>
    /// Class XtrmAddons Net Http WebServer Start Event Handler.
    /// </summary>
    public class WebServerStartEventHandler
    {
        #region Properties

        /// <summary>
        /// Property started Web Server
        /// </summary>
        public WebServer WebServer { get; private set; }

        #endregion
        


        #region Properties

        /// <summary>
        /// Class XtrmAddons Net Http WebServer Start Event Handler Constructor.
        /// </summary>
        /// <param name="webServer"></param>
        public WebServerStartEventHandler(WebServer webServer)
        {
            WebServer = webServer;
        }

        #endregion
    }
}
