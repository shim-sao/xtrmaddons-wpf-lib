using System.Dynamic;

namespace XtrmAddons.Net.Application
{
    /// <summary>
    /// <para>Class XtrmAddons Net Application Session</para>
    /// <para>This class can be used to manage global application objects.</para>
    /// </summary>
    public class ApplicationSession
    {
        /// <summary>
        /// Property to access to the application session properties in dynamic key|value pair.
        /// </summary>
        public static dynamic Properties { get; } = new ExpandoObject();
    }
}