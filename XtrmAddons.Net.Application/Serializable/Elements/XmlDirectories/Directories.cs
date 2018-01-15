using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlDirectories
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Directories.
    /// </summary>
    [Serializable]
    public class Directories : ElementsBase<Directory>
    {
        #region Properties

        /// <summary>
        /// Property list of Directory.
        /// </summary>
        //[XmlElement(ElementName = "Directory"]
       // public override List<Directory> Elements { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Directories Constructor.
        /// </summary>
        public Directories() : base() { }

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Directories Constructor.
        /// </summary>
        public Directories(List<Directory> elements) : base(elements) { }

        #endregion



        #region Methods

        /// <summary>
        /// Method to update a directory informations in the list.
        /// </summary>
        /// <param name="item">The directory informations to update.</param>
        public override void Update(Directory item)
        {
            Set(item.Key, item.RelativePath, item.IsRelative, item.Root, item.Default);
        }

        /// <summary>
        ///  Method to set a directory in the list. Replace directory properties if Key property exists.
        /// </summary>
        /// <param name="key">A directory Key.</param>
        /// <param name="relativePath">The relative or absolute path of the directory.</param>
        /// <param name="isRelative">Define if path is relative.</param>
        /// <param name="root">The root of the directory if path is define to relative.</param>
        /// <param name="Default">Property is default directory.</param>
        /// <returns>A Directory object.</returns>
        public Directory Set(string key, string relativePath, bool isRelative = false, string root = "", bool Default = false)
        {
            Directory el = Find(key);

            if (Default == true)
            {
                Directory eldef = this.Default();
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

        #endregion
    }
}