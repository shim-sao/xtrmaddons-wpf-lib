using System.Dynamic;

namespace XtrmAddons.Net.Application
{
    /// <summary>
    /// Class provided to manage application session.
    /// Share accessibility to objects to all application components.
    /// </summary>
    public class ApplicationSession
    {
        /// <summary>
        /// Variable application session properties key|value.
        /// </summary>
        public static dynamic Properties = new ExpandoObject();
    }
}