using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
using XtrmAddons.Net.HttpWebServer.Interfaces;

namespace XtrmAddons.Net.HttpWebServer.Requests
{
    /// <summary>
    /// Class XtrmAddons Net Http Web Server Request.
    /// </summary>
     public abstract class WebServerRequest : IHttpRequest
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Variable HTTP listener context.
        /// </summary>
        private readonly HttpListenerContext _ctx;

        /// <summary>
        /// Variable Web Server request URL.
        /// </summary>
        private readonly WebServerRequestUrl _uri;

        #endregion



        #region Properties

        /// <summary>
        /// Property Web Server Request Uri.
        /// </summary>
        public WebServerRequestUrl Uri => _uri;

        /// <summary>
        /// Property to check if http method is POST.
        /// </summary>
        public bool IsPOST => (_ctx.Request.HttpMethod == "POST");

        /// <summary>
        /// Property to check if http method is GET.
        /// </summary>
        public bool IsGET => (_ctx.Request.HttpMethod == "GET");

        /// <summary>
        /// Property to check if http method is PUT.
        /// </summary>
        public bool IsPUT => (_ctx.Request.HttpMethod == "PUT");

        /// <summary>
        /// Property to check if http method is DELETE.
        /// </summary>
        public bool IsDELETE => (_ctx.Request.HttpMethod == "DELETE");

        /// <summary>
        /// Property http GET parameters.
        /// </summary>
        public NameValueCollection _GET => _ctx.Request.QueryString;

        /// <summary>
        /// Property http POST parameters.
        /// </summary>
        public string _POST => ReadPost();

        /// <summary>
        /// Property http REQUEST parameters.
        /// </summary>
        public NameValueCollection _REQUEST => throw new System.NotImplementedException();

        /// <summary>
        /// Property HTTP listener context.
        /// </summary>
        public string Context => new StreamReader(_ctx.Request.InputStream).ReadToEnd();

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Request Constructor.
        /// </summary>
        /// <param name="ctx"></param>
        public WebServerRequest(HttpListenerContext ctx)
        {
            _ctx = ctx;
            _uri = new WebServerRequestUrl(ctx);
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to read POST string.
        /// </summary>
        /// <returns>The POST string otherwise empty string.</returns>
        private string ReadPost()
        {
            if (IsPOST)
            {
                using (StreamReader reader = new StreamReader(_ctx.Request.InputStream, _ctx.Request.ContentEncoding))
                {
                    return reader.ReadToEnd();
                }
            }

            return "";
        }

        #endregion
    }
}
