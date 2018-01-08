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
        private readonly HttpListenerContext _ctx;

        /// <summary>
        /// Variable Uri desired names/values collection.
        /// </summary>
        private NameValueCollection _uri = new NameValueCollection();

        /// <summary>
        /// Variable Uri additional parameters desired names/values collection.
        /// </summary>
        private string[] _uriParams;

        #endregion



        #region Properties

        /// <summary>
        /// Property to access to the Host URL.
        /// </summary>
        public string Host => _uri["Host"];

        /// <summary>
        /// Property to access to the Host URL.
        /// </summary>
        public string Port => _uri["Port"];

        /// <summary>
        /// Property to access to the absolute URL.
        /// </summary>
        public string AbsoluteUrl => _uri["AbsoluteUrl"];

        /// <summary>
        /// Property to access to the relative URL.
        /// </summary>
        public string RelativeUrl => _uri["RelativeUrl"];

        /// <summary>
        /// Property to access to the request type.
        /// </summary>
        public string RequestType => _uri["RequestType"];

        /// <summary>
        /// Property to access to the method name.
        /// </summary>
        public string ComponentName => _uri["ComponentName"];

        /// <summary>
        /// Property to access to the method name.
        /// </summary>
        public string MethodName => _uri["MethodName"];

        /// <summary>
        /// Property to access to the additional URL parameters.
        /// </summary>
        public string[] Params => _uriParams;

        /// <summary>
        /// Property to access to  the additional URL parameters.
        /// </summary>
        public NameValueCollection QueryString => _ctx.Request.QueryString;

        /// <summary>
        /// Property to access to the relative URL.
        /// </summary>
        public string Extension => Path.GetExtension(_uri["RelativeUrl"]);

        /// <summary>
        /// Property to access to cookies collection.
        /// </summary>
        public CookieCollection Cookies => _ctx.Request.Cookies;

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Url.
        /// </summary>
        /// <param name="ctx">A Http listener context.</param>
        public WebServerRequestUrl(HttpListenerContext ctx)
        {
            _ctx = ctx;
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
            _uri.Add("Host", _ctx.Request.Url.Host);
            _uri.Add("Port", _ctx.Request.Url.Port.ToString());
            _uri.Add("AbsoluteUrl", _ctx.Request.Url.ToString());
            _uri.Add("RelativeUrl", _ctx.Request.RawUrl);

            // Component informations.
            _uri.Add("RequestType", _getSegment(1, "Api", true));
            _uri.Add("ComponentName", _getSegment(2, "Index", true));
            _uri.Add("MethodName", _getSegment(3, "Index", true));

            // Initialize additional parameters
            InitializeUriParameters();
        }

        /// <summary>
        /// Method to set additional Uri parameters.
        /// </summary>
        private void InitializeUriParameters()
        {
            try
            {
                _uriParams = _ctx
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
                log.Debug("Cannot initialize parameters Server request url : " + e.Message);
                throw new ArgumentNullException("Cannot initialize parameters Server request url : " + e.Message, e);
            }
        }

        /// <summary>
        /// Method to get an URL segment at specified index.
        /// </summary>
        /// <param name="index">The index to find.</param>
        /// <param name="init">The default value if the segment doesn't exists.</param>
        /// <param name="ucword">Uppercase first character of the string.</param>
        /// <returns>The segment string.</returns>
        private string _getSegment(int index, string init = "", bool ucword = false)
        {
            try
            {
                string []_segments = _ctx.Request.Url.Segments;

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
                log.Debug("Cannot create segment : " + e.Message);
                throw new ArgumentNullException("Cannot create segment : " + e.Message, e);
            }

            return init;
        }

        #endregion
    }
}