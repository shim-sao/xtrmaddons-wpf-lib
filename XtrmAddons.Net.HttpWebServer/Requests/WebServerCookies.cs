using System;
using System.IO;
using System.Windows;

namespace XtrmAddons.Net.HttpWebServer.Requests
{
    /// <summary>
    /// Class XtrmAddons Net Http Web Server Cookies.
    /// </summary>
    public class WebServerCookies
    {
        #region Variables

        /// <summary>
        /// Variable http web server prefix.
        /// </summary>
        private string _prefix;

        #endregion



        #region Contructors

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Cookies constructor.
        /// </summary>
        /// <param name="prefix">An Uri prefix for Uri cookies.</param>
        public WebServerCookies(string prefix = null)
        {
            if (prefix == null)
            {
                _prefix = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Session");
            }
            else
            {
                _prefix = prefix;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Method to get a cookie.
        /// </summary>
        /// <param name="uri">An uri string prefix.</param>
        /// <returns>A cookie string.</returns>
        public string Get(string uri)
        {
            return Application.GetCookie(new Uri(@uri));
        }
        
        /// <summary>
        /// Method to get a cookie.
        /// </summary>
        /// <param name="uri">An uri prefix.</param>
        /// <returns>A cookie string.</returns>
        public string Get(Uri uri)
        {
            return Application.GetCookie(uri);
        }

        /// <summary>
        /// Method to set a cookie.
        /// </summary>
        /// <param name="uri">The uri string of the cookie</param>
        /// <param name="cookie">The cookie name.</param>
        public void Set(string uri, string cookie)
        {
            Application.SetCookie(new Uri(@uri), cookie);
        }

        /// <summary>
        /// Method to set a cookie.
        /// </summary>
        /// <param name="uri">The uri of the cookie</param>
        /// <param name="cookie">The cookie name.</param>
        public void Set(Uri uri, string cookie)
        {
            Application.SetCookie(uri, cookie);
        }

        /// <summary>
        /// Method to set Session Id cookie.
        /// </summary>
        /// <param name="value">The uri string of the cookie</param>
        public void SetSessionId(string value)
        {
            Set(new Uri(@_prefix + "sid"), "sid="+ value);
        }

        /// <summary>
        /// Method to get Session Id cookie.
        /// </summary>
        /// <return>A cookie string.</return>
        public string GetSessionId()
        {
            return Get(new Uri(@_prefix + "sid"));
        }

        /// <summary>
        /// Method to set Session Token cookie.
        /// </summary>
        /// <param name="value">The value of the cookie.</param>
        public void SetSessionToken(string value)
        {
            Set(new Uri(@_prefix + "stoken"), "stoken=" + value);
        }

        /// <summary>
        /// Method to get Session Token cookie.
        /// </summary>
        /// <return>A cookie string.</return>
        public string GetSessionToken()
        {
            return Get(new Uri(@_prefix + "stoken"));
        }

        #endregion
    }
}
