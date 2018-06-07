using System;
using System.Windows.Threading;

namespace XtrmAddons.Net.Common.Extensions
{
    /// <summary>
    /// Class XtrmAddons Net Common Exception Extensions.
    /// </summary>
    public static class DispatcherExtension
    {
        /// <summary>
        /// Method to begin dispatcher invoke if required.
        /// </summary>
        /// <param name="dispatcher">The dispatcher.</param>
        /// <param name="action">The action to add to the dispatcher.</param>
        /// <see href="https://www.codeproject.com/Questions/1173661/Thread-error-in-WPF-already-in-use"/>
        /// <example>
        /// Application.Current.Dispatcher.BeginInvokeIfRequired(()=>Instance.txtReport.Text = "value will set here.");
        /// </example>
        public static void BeginInvokeIfRequired(this Dispatcher dispatcher, Action action)
        {
            if (action == null) return;
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(action);
            }
        }
    }
}
