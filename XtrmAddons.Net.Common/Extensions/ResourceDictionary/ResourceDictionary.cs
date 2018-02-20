using System.Collections.Generic;
using System.Dynamic;
using System.Windows;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// <para>Class XtrmAddons Net Common ResourceDictionary Extensions.</para>
    /// <para>This Class add some methods to ResourceDictionary by extension.</para>
    /// </summary>
    public static class ResourceDictionaryExtension
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        #region Methods

        /// <summary>
        /// Extension method that turns a dictionary of string and object to an ExpandoObject
        /// <see cref="http://theburningmonk.com/2011/05/idictionarystring-object-to-expandoobject-extension-method/"/>
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static ExpandoObject ToExpando(this ResourceDictionary dictionary)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();

            if (dictionary != null)
            {
                foreach (string key in dictionary.Keys)
                {
                    d.Add(key, dictionary[key]);
                }
            }

            return d.ToExpando();
        }

        #endregion
    }
}