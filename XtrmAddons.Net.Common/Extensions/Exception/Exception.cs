using System;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Common Exception Extensions.
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Method to get a quick output formated string of the error.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <returns>A formated string for output.</returns>
        public static string Output(this Exception e)
        {
            string output = e.Source + " > " + e.HResult + " : " + e.Message;
            if(e.InnerException != null)
            {
                output += " (see inner exception)";
            }
            return output;
        }
    }
}
