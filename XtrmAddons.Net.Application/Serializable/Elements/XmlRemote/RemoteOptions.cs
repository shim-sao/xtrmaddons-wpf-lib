namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    public class RemoteOptions
    {
        #region Properties

        /// <summary>
        /// Property to access to the list of directories informations.
        /// </summary>
        public Servers Servers { get; set; }

        #endregion



        #region Constructors

        /// <summary>
        /// Class XtrmAddons Net Application Serializable Elements XML Remote Options Constructor.
        /// </summary>
        public RemoteOptions()
        {
            Servers = new Servers();
        }

        #endregion
    }
}
