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
        /// Property access to the Http request context. 
        /// </summary>
        string Context { get; }

        /// <summary>
        /// Property access to the Http request GET.
        /// </summary>
        NameValueCollection _GET { get; }

        /// <summary>
        /// Property access to the Http request POST.
        /// </summary>
        NameValueCollection _POST { get; }

        /// <summary>
        /// Property access to the Http request GET and POST combined.
        /// </summary>
        NameValueCollection _REQUEST { get; }

        #endregion
    }
}
