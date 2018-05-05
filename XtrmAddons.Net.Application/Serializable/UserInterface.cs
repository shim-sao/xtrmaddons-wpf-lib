using System.Xml.Serialization;
using XtrmAddons.Net.Application.Serializable.Elements.XmlElementBase;
using XtrmAddons.Net.Application.Serializable.Elements.XmlUiElement;

namespace XtrmAddons.Net.Application.Serializable
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable User Interface.
    /// </summary>
    [XmlRoot("UserInterface", Namespace = "http://www.xtrmaddons.com/", IsNullable = false)]
    public class UserInterface
    {
        #region Properties

        /// <summary>
        /// Property list of UI Elements.
        /// </summary>
        [XmlElement("Properties")]
        public ElementBaseObjects Parameters;

        /// <summary>
        /// Property list of UI Elements.
        /// </summary>
        [XmlElement("UI")]
        public UiElements Controls;

        #endregion



        #region Methods

        /// <summary>
        /// Class XtrmAddons Net Application Serializable User Interface Constructor.
        /// </summary>
        public UserInterface()
        {
            Controls = new UiElements();
            Parameters = new ElementBaseObjects();
        }

        #endregion

    }
}
