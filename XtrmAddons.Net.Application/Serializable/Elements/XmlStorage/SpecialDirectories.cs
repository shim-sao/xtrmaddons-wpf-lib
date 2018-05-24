using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Application.Serializable.Elements.XmlStorage
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Specials Directories.
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class SpecialDirectories
    {
        /// <summary>
        /// Property application bin directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Bin")]
        [JsonProperty(PropertyName = "Bin")]
        public string Bin { get; set; }

        /// <summary>
        /// Property application cache directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Cache")]
        [JsonProperty(PropertyName = "Cache")]
        public string Cache { get; set; }

        /// <summary>
        /// Property application config directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Config")]
        [JsonProperty(PropertyName = "Config")]
        public string Config { get; set; }

        /// <summary>
        /// Property application data directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Data")]
        [JsonProperty(PropertyName = "Data")]
        public string Data { get; set; }

        /// <summary>
        /// Property application logs directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Logs")]
        [JsonProperty(PropertyName = "Logs")]
        public string Logs { get; set; }

        /// <summary>
        /// Property application plugin directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Plugin")]
        [JsonProperty(PropertyName = "Plugin")]
        public string Plugin { get; set; }

        /// <summary>
        /// Property application theme directory.
        /// </summary>
        [XmlAttribute(DataType = "string", AttributeName = "Theme")]
        [JsonProperty(PropertyName = "Theme")]
        public string Theme { get; set; }
    }


    /// <summary>
    /// Enumerator XtrmAddons Net Application Serializable Elements XML Specials Directories Name.
    /// </summary>
    [Serializable]
    public enum SpecialDirectoriesName
    {
        /// <summary>
        /// Application bin special directory.
        /// </summary>
        [XmlEnum(Name = "Bin")]
        Bin,

        /// <summary>
        /// Application cache special directory.
        /// </summary>
        [XmlEnum(Name = "Cache")]
        Cache,

        /// <summary>
        /// Application config special directory.
        /// </summary>
        [XmlEnum(Name = "Config")]
        Config,

        /// <summary>
        /// Application data special directory.
        /// </summary>
        [XmlEnum(Name = "Data")]
        Data,

        /// <summary>
        /// Application logs special directory.
        /// </summary>
        [XmlEnum(Name = "Logs")]
        Logs,

        /// <summary>
        /// Application plugin special directory.
        /// </summary>
        [XmlEnum(Name = "Plugin")]
        Plugin,

        /// <summary>
        /// Application logs special directory.
        /// </summary>
        [XmlEnum(Name = "Theme")]
        Theme
    }


    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements XML Specials Directories Name Extensions.
    /// </summary>
    public static class SpecialDirectoriesExtensions
    {
        /// <summary>
        /// Method to get Special Directories Enumerator string name.
        /// </summary>
        /// <param name="sdn">A Special Directories Name.</param>
        /// <returns>The special Directories Name string.</returns>
        public static string Name(this SpecialDirectoriesName sdn)
        {
            switch (sdn)
            {
                case SpecialDirectoriesName.Bin:
                    return "Bin";

                case SpecialDirectoriesName.Cache:
                    return "Cache";

                case SpecialDirectoriesName.Config:
                    return "Config";

                case SpecialDirectoriesName.Data:
                    return "Data";

                case SpecialDirectoriesName.Logs:
                    return "Logs";

                case SpecialDirectoriesName.Plugin:
                    return "Plugin";

                case SpecialDirectoriesName.Theme:
                    return "Theme";
            }

            return null;
        }

        /// <summary>
        /// Method to get Special Directories Enumerator to root directory string.
        /// </summary>
        /// <param name="sdn">A Special Directories Name.</param>
        /// <returns>The root directory Special Directories Name.</returns>
        public static string RootDirectory(this SpecialDirectoriesName sdn)
        {
            switch (sdn)
            {
                case SpecialDirectoriesName.Bin:
                    return "{Bin}";

                case SpecialDirectoriesName.Cache:
                    return "{Cache}";

                case SpecialDirectoriesName.Config:
                    return "{Config}";

                case SpecialDirectoriesName.Data:
                    return "{Data}";

                case SpecialDirectoriesName.Logs:
                    return "{Logs}"; ;;

                case SpecialDirectoriesName.Plugin:
                    return "{Plugin}"; ;

                case SpecialDirectoriesName.Theme:
                    return "{Theme}";
            }

            return null;
        }
    }
}