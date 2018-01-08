using System.IO;
using System.Xml.Serialization;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Application.Serializable.Elements
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Directory.
    /// </summary>
    public class Directory : Element
    {
        #region Properties

        /// <summary>
        /// Property relative path of the directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Value")]
        public string RelativePath { get; set; }

        /// <summary>
        /// Property defines if path of the directory is relative or absolute path.
        /// </summary>
        [XmlAttribute(DataType="boolean", AttributeName= "IsRelative")]
        public bool IsRelative { get; set; }

        /// <summary>
        /// Property root path of the directory if is define to relative path.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Root")]
        public string Root { get; set; }

        /// <summary>
        /// Property absolute path of the directory.
        /// </summary>
        [XmlIgnore]
        public string AbsolutePath
        {
            get
            {
                if(!IsRelative)
                    return RelativePath;

                if (!RelativePath.IsNullOrWhiteSpace())
                    return Path.Combine(GetRootAbsolutePath(), RelativePath);

                return null;
            }
        }

        #endregion Properties


        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements Directory constructor.
        /// </summary>
        public Directory() : base() {}


        /// <summary>
        /// Method to get absolute path root directory.
        /// </summary>
        /// <returns>The absolute path root directory.</returns>
        private string GetRootAbsolutePath()
        {
            switch (Root)
            {
                case "{Cache}":
                    return ApplicationBase.CacheDirectory;

                case "{Config}":
                    return ApplicationBase.ConfigDirectory;

                case "{Data}":
                    return ApplicationBase.DataDirectory;

                case "{Logs}":
                    return ApplicationBase.LogsDirectory;

                case "":
                    return ApplicationBase.BaseDirectory;
            }

            return Root;
        }
    }

    #endregion Methods
}