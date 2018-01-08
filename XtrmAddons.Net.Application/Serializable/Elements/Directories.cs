using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Directories.
    /// </summary>
    public class Directories
    {
        #region Properties

        /// <summary>
        /// Property list of directories elements.
        /// </summary>
        [XmlElement("Directory")]
        public List<Directory> Elements { get; set; }

        #endregion Properties


        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Directories constructor.
        /// </summary>
        public Directories()
        {
            Elements = new List<Directory>();
        }

        /// <summary>
        /// Method to get a directory by its Key property.
        /// </summary>
        /// <param name="key">A directory Key.</param>
        /// <returns>A Directory object or null.</returns>
        public Directory Get(string key)
        {
            return Elements.SingleOrDefault(e => e.Key == key);
        }

        /// <summary>
        ///  Method to set a directory in the list. Replace database properties if Key property exists.
        /// </summary>
        /// <param name="key">A directory Key.</param>
        /// <param name="relativePath">The relative or absolute path of the directory.</param>
        /// <param name="isRelative">Define if path is relative.</param>
        /// <param name="root">The root of the directory if path is define to relative.</param>
        /// <param name="Default">Property is default directory.</param>
        /// <returns>A Directory object.</returns>
        public Directory Set(string key, string relativePath, bool isRelative = false, string root = "", bool Default = false)
        {
            Directory el = Elements.SingleOrDefault(d => d.Key == key);

            if (Default == true)
            {
                Directory eldef = Elements.SingleOrDefault(d => d.Default == true);
                if (eldef != null && eldef.Key != null)
                {
                    eldef.Default = false;
                }
            }

            if (el != null && el.Key != null)
            {
                el.RelativePath = relativePath;
                el.IsRelative = isRelative;
                el.Root = root;
                el.Default = Default;
            }
            else
            {
                el = new Directory { Key = key, RelativePath = relativePath, IsRelative = isRelative, Root = root, Default = Default };
                Elements.Add(el);
            }

            return el;
        }

        #endregion Methods
    }
}