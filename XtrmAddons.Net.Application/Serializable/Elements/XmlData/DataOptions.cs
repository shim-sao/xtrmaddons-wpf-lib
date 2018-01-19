using System;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlData
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Data Options.
    /// </summary>
    [Serializable]
    public class DataOptions
    {
        #region Properties

        /// <summary>
        /// Property to access to the list of databases informations.
        /// </summary>
        public Databases Databases { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Data Options Constructor.
        /// </summary>
        public DataOptions()
        {
            Databases = new Databases();
        }

        #endregion
    }
}