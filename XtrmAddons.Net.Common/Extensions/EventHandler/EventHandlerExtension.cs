using System;
using System.Linq;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// Class XtrmAddons Object Extensions.
    /// </summary>
    public static class EventHandlerExtension
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        #region Methods

        /// <summary>
        /// Method to add an event handler once.
        /// </summary>
        /// <param name="h">The event handler.</param>
        /// <param name="handler">A delegate event handler.</param>
        public static void AddHandlerOnce(this EventHandler h, EventHandler handler)
        {
            if (!h.HasHandler(handler))
            {
                h += handler;
            }
        }

        /// <summary>
        /// Method to check if an event handler exists.
        /// </summary>
        /// <param name="h">The delegate event handler.</param>
        /// <param name="handler">A delegate event handler.</param>
        public static bool HasHandler(this EventHandler h, EventHandler handler)
        {
            if (h.GetInvocationList().ToList().Contains(handler))
            {
               return true;
            }

            return false;
        }

        #endregion
    }
}