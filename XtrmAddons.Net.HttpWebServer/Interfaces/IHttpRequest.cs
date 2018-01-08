using System.Collections.Specialized;

namespace XtrmAddons.Net.HttpWebServer.Interfaces
{
    /// <summary>
    /// Class XtrmAddons Net Http Server Interface.
    /// </summary>
    public interface IHttpRequest
    {
        #region Properties

        /// <summary>
        /// Accessors web server request context. 
        /// </summary>
        string Context { get; }

        /// <summary>
        /// Accessors to the GET parameters.
        /// </summary>
        NameValueCollection _GET { get; }

        /// <summary>
        /// Accessors to the POST parameters.
        /// </summary>
        string _POST { get; }

        /// <summary>
        /// Accessors to the GET & POST combined parameters.
        /// </summary>
        NameValueCollection _REQUEST { get; }

        #endregion
    }
}
