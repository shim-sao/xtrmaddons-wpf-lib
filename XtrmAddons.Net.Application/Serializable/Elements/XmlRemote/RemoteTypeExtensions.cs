namespace XtrmAddons.Net.Application.Serializable.Elements.XmlRemote
{
    /// <summary>
    /// Class XtrmAddons Net Application Serializable Elements Enumerator XML Server Informations Types Extensions.
    /// </summary>
    public static class RemoteTypeExtensions
    {
        /// <summary>
        /// Method to get string name of a server informations type.
        /// </summary>
        /// <param name="type">The server informations type.</param>
        /// <returns>The string name of the server informations type otherwise return null.</returns>
        public static string Name(this RemoteType type)
        {
            switch (type)
            {
                case RemoteType.Server:
                    return "Server";
                case RemoteType.Client:
                    return "Client";
            }

            return null;
        }

        /// <summary>
        /// Method to get int value of a server informations type.
        /// </summary>
        /// <param name="type">The server informations type.</param>
        /// <returns>The int value of the server informations type otherwise return -1.</returns>
        public static int Value(this RemoteType type)
        {
            switch (type)
            {
                case RemoteType.Server:
                    return 0;
                case RemoteType.Client:
                    return 1;
            }

            return -1;
        }
    }
}
