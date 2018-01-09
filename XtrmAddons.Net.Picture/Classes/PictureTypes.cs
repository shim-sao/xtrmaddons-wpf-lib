using System;
using System.Xml.Serialization;

namespace XtrmAddons.Net.Picture
{
    /// <summary>
    /// Enumerator of Pictures types.
    /// </summary>
    [Serializable]
    public enum PictureTypes
    {
        /// <summary>
        /// Picture type for original Picture. 
        /// </summary>
        [XmlEnum(Name = "Original")]
        Original = 0,

        /// <summary>
        /// Picture type for preview Picture. 
        /// </summary>
        [XmlEnum(Name = "Preview")]
        Preview = 1,

        /// <summary>
        /// Picture type for preview Picture. 
        /// </summary>
        [XmlEnum(Name = "Thumbnail")]
        Thumbnail = 2
    }


    /// <summary>
    /// Class XtrmAddons Net Picture Types Extensions.
    /// </summary>
    public static class PictureTypesExtensions
    {
        /// <summary>
        /// Method to get a string name of a Picture type.
        /// </summary>
        /// <param name="type">The type of the Picture.</param>
        /// <returns>The type string name of the Picture.</returns>
        public static string Name(this PictureTypes type)
        {
            switch(type)
            {
                case PictureTypes.Original:
                    return "Original";

                case PictureTypes.Preview:
                    return "Preview";

                case PictureTypes.Thumbnail:
                    return "Thumbnail";
            }

            return null;
        }
    }
}