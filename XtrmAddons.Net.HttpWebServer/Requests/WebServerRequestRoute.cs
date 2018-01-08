using XtrmAddons.Net.HttpWebServer.Responses;

namespace XtrmAddons.Net.HttpWebServer.Requests
{
    /// <summary>
    /// Class XtrmAddons Net Http Web Server Request Route.
    /// </summary>
    public class WebServerRequestRoute
    {
        #region Properties

        /// <summary>
        /// Property to access to the web server request URL.
        /// </summary>
        protected static WebServerRequestUrl Uri { get; set; }

        /// <summary>
        /// Property to access to the web server response data.
        /// </summary>
        public WebServerResponseData Response { get; protected set; }

        #endregion



        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Request Route Constructor
        /// </summary>
        public WebServerRequestRoute() {}

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Request Route Constructor
        /// </summary>
        /// <param name="uri"></param>
        public WebServerRequestRoute(WebServerRequestUrl uri)
        {
            Uri = uri;
            Response = new WebServerResponseData(Uri.RelativeUrl)
            {
                ContentType = "text/html"
            };
        }

        #endregion
    }
}