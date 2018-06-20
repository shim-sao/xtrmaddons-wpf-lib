using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
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
        private string post;

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

                return (bool) isPut;
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
        public string _POST
        {
            get
            {
                if (post.IsNullOrWhiteSpace())
                {
                    post = ReadPost();
                }

                return post;
            }
        }

        /// <summary>
        /// Property http REQUEST parameters.
        /// </summary>
        public NameValueCollection _REQUEST => throw new System.NotImplementedException();

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
        private string ReadPost()
        {
            if (IsPOST)
            {
                using (StreamReader reader = new StreamReader(httpListener.Request.InputStream, httpListener.Request.ContentEncoding))
                {
                    return reader.ReadToEnd();
                }
            }

            return "";
        }

        /// <summary>
        /// Method to read the request input stream.
        /// </summary>
        /// <returns>The input request string.</returns>
        private string ReadInputStream()
        {
            using (StreamReader streamReader = new StreamReader(httpListener.Request.InputStream))
            {
                return streamReader.ReadToEnd();
            }
        }

        #endregion
    }
}
