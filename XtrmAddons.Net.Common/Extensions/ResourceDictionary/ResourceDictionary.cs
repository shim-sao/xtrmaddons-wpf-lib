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
        #region Methods

        /// <summary>
        /// Extension method that turns a dictionary of string and object to an ExpandoObject
        /// </summary>
        /// <param name="dictionary">The ResourceDictionary to bind.</param>
        /// <returns>An ExpandoObject with dictionary data as properties.</returns>
        /// <see href="http://theburningmonk.com/2011/05/idictionarystring-object-to-expandoobject-extension-method/">theburningmonk.com</see>
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