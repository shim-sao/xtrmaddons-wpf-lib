using System;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlStorage
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Storage Options.
    /// </summary>
    [Serializable]
    public class StorageOptions
    {
        #region Properties

        /// <summary>
        /// Property to access to the list of directories informations.
        /// </summary>
        public Directories Directories { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Storage Options Constructor.
        /// </summary>
        public StorageOptions()
        {
            Directories = new Directories();
        }

        #endregion
    }
}