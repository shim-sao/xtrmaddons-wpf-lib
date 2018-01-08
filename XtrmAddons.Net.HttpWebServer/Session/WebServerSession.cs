using System;
using System.Collections.Generic;

namespace XtrmAddons.Net.HttpWebServer.Session
{
    /// <summary>
    /// Class XtrmAddons Net Http Web Server Session.
    /// </summary>
    public class WebServerSession
    {
        #region Properties

        /// <summary>
        /// Property user session properties key|value.
        /// </summary>
        protected Dictionary<string, Dictionary<string, object>> UsersSessions { get; set; } = new Dictionary<string, Dictionary<string, object>>();

        #endregion



        #region Constructor

        /// <summary>
        /// Class XtrmAddons Net Http Web Server Session Constructor.
        /// </summary>
        public WebServerSession() { }

        #endregion



        #region Methods

        /// <summary>
        /// Method to get a value of an user session property.
        /// </summary>
        /// <param name="userSessionKey">The key of the user session.</param>
        /// <param name="key">They key to retrive</param>
        /// <returns></returns>
        public object Get(string userSessionKey, string key)
        {
            if (UsersSessions.ContainsKey(userSessionKey).Equals(true))
            {
                if (UsersSessions[userSessionKey].ContainsKey(key).Equals(true))
                {
                    return UsersSessions[userSessionKey][key];
                }
            }

            return null;
        }

        /// <summary>
        /// Method to set a value to an user session property.
        /// </summary>
        /// <param name="userSessionKey">The key of the user session.</param>
        /// <param name="key">They key to retrive</param>
        /// <param name="value">The value of the property.</param>
        public void Set(string userSessionKey, string key, object value)
        {
            if (UsersSessions.ContainsKey(userSessionKey).Equals(true))
            {
                if (UsersSessions[userSessionKey].ContainsKey(key).Equals(true))
                {
                    UsersSessions[userSessionKey][key] = value;
                }
                else
                {
                    UsersSessions[userSessionKey].Add(key, value);
                }
            }
            else
            {
                UsersSessions[userSessionKey] = new Dictionary<string, object>();
                UsersSessions[userSessionKey].Add(key, value);
            }
        }

        #endregion
    }
}