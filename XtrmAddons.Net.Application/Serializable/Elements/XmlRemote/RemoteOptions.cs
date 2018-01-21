namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    public class RemoteOptions
    {
        #region Properties

        /// <summary>
        /// Property to access to the list of Clients informations.
        /// </summary>
        public Clients Clients { get; set; }

        /// <summary>
        /// Property to access to the list of Servers informations.
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
            Clients = new Clients();
        }

        #endregion
    }
}
