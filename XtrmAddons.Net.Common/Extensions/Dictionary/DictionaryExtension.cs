using System.Collections.Generic;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// <para>Class XtrmAddons Net Common Dictionary Extensions.</para>
    /// <para>This Class add some methods to Dictionary by extension.</para>
    /// </summary>
    public static class DictionaryExtension
    {
        #region Methods

        /// <summary>
        /// Method to append or merge a <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="dictionary">A <see cref="Dictionary{TKey, TValue}"/>.</param>
        /// <param name="dictionaryToAppend">A <see cref="Dictionary{TKey, TValue}"/> to append or merge.</param>
        /// <param name="replace">True to replace existing keys otherwise false.</param>
        public static Dictionary<T, V> AppendDictionary<T,V>(this Dictionary<T, V> dictionary, Dictionary<T, V> dictionaryToAppend, bool replace = true)
        {
            // go through the items in the dictionary and copy over the key value pairs)
            foreach (var kvp in dictionaryToAppend)
            {
                if(dictionary.ContainsKey(kvp.Key) && replace)
                {
                    dictionary[kvp.Key] = kvp.Value;
                }
                else
                {
                    dictionary.Add(kvp.Key, kvp.Value);
                }
            }

            return dictionary;
        }

        #endregion
    }
}