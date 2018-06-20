using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using XtrmAddons.Net.Common.Extensions;
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
        private readonly HttpListenerContext httpListener;

        /// <summary>
        /// Variable intput stream context.
        /// </summary>
        private string context;

        /// <summary>
        /// Variable request POST.
        /// </summary>
        private NameValueCollection post;

        /// <summary>
        /// Variable request GET.
        /// </summary>
        private NameValueCollection get;

        /// <summary>
        /// Variable request REQUEST.
        /// </summary>
        private NameValueCollection request;

        /// <summary>
        /// Variable is request method POST.
        /// </summary>
        private bool? isPost;

        /// <summary>
        /// Variable is request method GET.
        /// </summary>
        private bool? isGet;

        /// <summary>
        /// Variable is request method PUT.
        /// </summary>
        private bool? isPut;

        /// <summary>
        /// Variable is request method DELETE.
        /// </summary>
        private bool? isDelete;

        #endregion



        #region Properties

        /// <summary>
        /// Property Web Server Request Uri.
        /// </summary>
        public WebServerRequestUrl Uri { get; }

        /// <summary>
        /// Property to check if Http method is POST.
        /// </summary>
        public bool IsPOST
        {
            get
            {
                if (isPost == null)
                {
                    isPost = httpListener.Request.HttpMethod == "POST";
                }

                return (bool)isPost;
            }
        }

        /// <summary>
        /// Property to check if Http method is GET.
        /// </summary>
        public bool IsGET
        {
            get
            {
                if (isGet == null)
                {
                    isGet = httpListener.Request.HttpMethod == "GET";
                }

                return (bool)isGet;
            }
        }

        /// <summary>
        /// Property to check if Http method is PUT.
        /// </summary>
        public bool IsPUT
        {
            get
            {
                if (isPut == null)
                {
                    isPut = httpListener.Request.HttpMethod == "PUT";
                }

                return (bool)isPut;
            }
        }

        /// <summary>
        /// Property to check if Http method is DELETE.
        /// </summary>
        public bool IsDELETE
        {
            get
            {
                if (isDelete == null)
                {
                    isDelete = httpListener.Request.HttpMethod == "DELETE";
                }

                return (bool)isDelete;
            }
        }

        /// <summary>
        /// Property to access to the Http GET parameters.
        /// </summary>
        public NameValueCollection _GET
        {
            get
            {
                if (get == null)
                {
                    get = httpListener.Request.QueryString;
                }

                return get;
            }
        }

        /// <summary>
        /// Property to access to the Http POST parameters.
        /// </summary>
        public NameValueCollection _POST
        {
            get
            {
                if (post == null)
                {
                    post = ReadPost();
                }

                return post;
            }
        }

        /// <summary>
        /// Property http REQUEST parameters.
        /// </summary>
        public NameValueCollection _REQUEST
        {
            get
            {
                if (request == null)
                {
                    request = ReadRequest();
                } 

                return request;
            }
        }

        /// <summary>
        /// Property to access to the request input stream.
        /// </summary>
        public string Context
        {
            get
            {
                if (context == null)
                {
                    context = ReadInputStream();
                }

                return context;
            }
        }

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Request Constructor.
        /// </summary>
        /// <param name="connection">The Http listerner context (named also connection).</param>
        public WebServerRequest(HttpListenerContext connection)
        {
            httpListener = connection;
            Uri = new WebServerRequestUrl(connection);
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to read POST string.
        /// </summary>
        /// <returns>The POST string otherwise empty string.</returns>
        private NameValueCollection ReadPost()
        {
            NameValueCollection nc = new NameValueCollection();

            if (IsPOST)
            {
                try
                {
                    nc = HttpUtility.ParseQueryString(Context);
                }
                catch (Exception ex)
                {
                    log.Info(ex.Output(), ex);
                }
            }

            return nc;
        }

        /// <summary>
        /// Method to create a combination of GET and POST [Name => Value] collection of the request input stream.
        /// </summary>
        /// <returns>A combination of GET and POST [Name => Value] collection.</returns>
        private NameValueCollection ReadRequest()
        {
            NameValueCollection req = new NameValueCollection(_GET);

            if (IsPOST)
            {
                try
                {
                    foreach (string key in _POST)
                    {
                        if (req.AllKeys.Contains(key))
                        {
                            req[key] = _POST[key];
                        }
                        else
                        {
                            req.Add(key, _POST[key]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Info(ex.Output(), ex);
                }
            }

            return req;
        }

        /// <summary>
        /// Method to read the request input stream.
        /// </summary>
        /// <returns>The input request string.</returns>
        private string ReadInputStream()
        {
            using (StreamReader streamReader = new StreamReader(httpListener.Request.InputStream, httpListener.Request.ContentEncoding))
            {
                return streamReader.ReadToEnd();
            }
        }

        #endregion
    }
}
