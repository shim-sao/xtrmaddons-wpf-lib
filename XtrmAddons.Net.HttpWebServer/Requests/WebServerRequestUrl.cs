using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.HttpWebServer.Requests
{
    /// <summary>
    /// Class XtrmAddons Net Http Web Server Url.
    /// </summary>
    public class WebServerRequestUrl
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Variable HTTP listener context.
        /// </summary>
        private readonly HttpListenerContext httpListener;

        /// <summary>
        /// Variable Uri desired names/values collection.
        /// </summary>
        private NameValueCollection uri = new NameValueCollection();

        /// <summary>
        /// Variable Uri additional parameters desired names/values collection.
        /// </summary>
        private string[] uriParams;

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the Host URL.
        /// </summary>
        public string Host => uri["Host"];

        /// <summary>
        /// Property to access to the Host URL.
        /// </summary>
        public string Port => uri["Port"];

        /// <summary>
        /// Property to access to the absolute URL.
        /// </summary>
        public string AbsoluteUrl => uri["AbsoluteUrl"];

        /// <summary>
        /// Property to access to the relative URL.
        /// </summary>
        public string RelativeUrl => uri["RelativeUrl"];

        /// <summary>
        /// Property to access to the request type.
        /// </summary>
        public string RequestType => uri["RequestType"];

        /// <summary>
        /// Property to access to the method name.
        /// </summary>
        public string ComponentName => uri["ComponentName"];

        /// <summary>
        /// Property to access to the method name.
        /// </summary>
        public string MethodName => uri["MethodName"];

        /// <summary>
        /// Property to access to the additional URL parameters.
        /// </summary>
        public string[] Params
        {
            get
            {
                if(uriParams == null)
                {
                    uriParams = InitializeUriParameters();
                }

                return uriParams;
            }
        }

        /// <summary>
        /// Property to access to  the additional URL parameters.
        /// </summary>
        public NameValueCollection QueryString => httpListener.Request.QueryString;

        /// <summary>
        /// Property to access to the relative URL.
        /// </summary>
        public string Extension => Path.GetExtension(uri["RelativeUrl"]);

        /// <summary>
        /// Property to access to cookies collection.
        /// </summary>
        public CookieCollection Cookies => httpListener.Request.Cookies;

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Url.
        /// </summary>
        /// <param name="connection">A Http listener context.</param>
        public WebServerRequestUrl(HttpListenerContext connection)
        {
            httpListener = connection;
            Initialize();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to initialize object properties.
        /// </summary>
        private void Initialize()
        {
            // Uri informations.
            uri.Add("Host", httpListener.Request.Url.Host);
            uri.Add("Port", httpListener.Request.Url.Port.ToString());
            uri.Add("AbsoluteUrl", httpListener.Request.Url.ToString());
            uri.Add("RelativeUrl", httpListener.Request.RawUrl);

            // Component informations.
            uri.Add("RequestType", GetSegment(1, "Api", true));
            uri.Add("ComponentName", GetSegment(2, "Index", true));
            uri.Add("MethodName", GetSegment(3, "Index", true));

            // Initialize additional parameters
            InitializeUriParameters();
        }

        /// <summary>
        /// Method to set additional Uri parameters.
        /// </summary>
        private string[] InitializeUriParameters()
        {
            try
            {
                return httpListener
                    .Request
                    .Url
                    .Segments
                    .Skip(4)
                    .Select(s => s.Replace("/", ""))
                    .ToArray()
                ;
            }
            catch(Exception e)
            {
                InvalidOperationException ex = new InvalidOperationException($"Initializing Server url request parameters : failed !", e);
                log.Fatal(ex.Output(), ex);
                throw ex;
            }
        }

        /// <summary>
        /// Method to get an URL segment at specified index.
        /// </summary>
        /// <param name="index">The index to find.</param>
        /// <param name="init">The default value if the segment doesn't exists.</param>
        /// <param name="ucword">Uppercase first character of the string.</param>
        /// <returns>The segment string.</returns>
        private string GetSegment(int index, string init = "", bool ucword = false)
        {
            try
            {
                string []_segments = httpListener.Request.Url.Segments;

                if (index > 0 && _segments.Length > index)
                {
                    string segment = _segments[index].Replace("/", "");

                    if (ucword)
                    {
                        segment = segment.UCFirst();
                    }

                    return segment;
                }
            }
            catch (Exception e)
            {
                InvalidOperationException ex = new InvalidOperationException($"Creating Server url request segments : failed !", e);
                log.Fatal(ex.Output(), ex);
                throw ex;
            }

            return init;
        }

        #endregion
    }
}