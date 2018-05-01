using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// <para>Class XtrmAddons Net Common IDictionary Extensions.</para>
    /// <para>This Class add some methods to IDictionary by extension.</para>
    /// </summary>
    public static class IDictionaryExtension
    {
        #region Methods

        /// <summary>
        /// Extension method that turns a dictionary of string and object to an ExpandoObject.
        /// </summary>
        /// <param name="dictionary">The IDictionary to bind.</param>
        /// <returns>An ExpandoObject with dictionary data as properties.</returns>
        /// <see href="http://theburningmonk.com/2011/05/idictionarystring-object-to-expandoobject-extension-method/">theburningmonk.com</see>
        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDic = (IDictionary<string, object>)expando;

            // go through the items in the dictionary and copy over the key value pairs)
            foreach (var kvp in dictionary)
            {
                // if the value can also be turned into an ExpandoObject, then do it!
                if (kvp.Value is IDictionary<string, object>)
                {
                    var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
                    expandoDic.Add(kvp.Key, expandoValue);
                }
                else if (kvp.Value is ICollection)
                {
                    // iterate through the collection and convert any strin-object dictionaries
                    // along the way into expando objects
                    var itemList = new List<object>();
                    foreach (var item in (ICollection)kvp.Value)
                    {
                        if (item is IDictionary<string, object>)
                        {
                            var expandoItem = ((IDictionary<string, object>)item).ToExpando();
                            itemList.Add(expandoItem);
                        }
                        else
                        {
                            itemList.Add(item);
                        }
                    }

                    expandoDic.Add(kvp.Key, itemList);
                }
                else
                {
                    expandoDic.Add(kvp);
                }
            }

            return expando;
        }

        #endregion
    }
}