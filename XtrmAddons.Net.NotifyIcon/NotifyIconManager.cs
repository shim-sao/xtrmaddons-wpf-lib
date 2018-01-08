using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace WPFXA.Net.NotifyIcons
{
    /// <summary>
    /// Class provided to manage notify icon.
    /// </summary>
    public class NotifyIconManager
    {
        #region Variables

        /// <summary>
        /// Variable application main window.
        /// </summary>
        private static readonly  Window _window = System.Windows.Application.Current.MainWindow;

        /// <summary>
        /// Variable notify icon.
        /// </summary>
        private static NotifyIcon _nIcon = new NotifyIcon();

        #endregion Variables


        #region Methods

        /// <summary>
        /// Class constructor notify icon manager.
        /// </summary>
        public static void AddToTray(string pathIcon = @"Assets\Images\Icons\Favicon.ico")
        {
            pathIcon = Path.Combine(Environment.CurrentDirectory, pathIcon);
            _nIcon.Icon = new Icon(pathIcon);
            _nIcon.Visible = true;
            _nIcon.Click += Switch;
        }

        /// <summary>
        /// Method to switch between window states.
        /// </summary>
        /// <param name="sender">An object sender of the event.</param>
        /// <param name="e">Mouse event arguments.</param>
        private static void Switch(object sender, EventArgs e)
        {
            if (_window.WindowState == WindowState.Normal)
            {
                _window.WindowState = WindowState.Minimized;
                _window.Hide();
            }
            else
            {
                _window.Show();
                _window.WindowState = WindowState.Normal;
                _window.Activate();
                _window.Topmost = true;
            }
        }

        /// <summary>
        /// Method to close and dispose Notify Icon.
        /// </summary>
        public static void Dispose()
        {
            _nIcon.Icon.Dispose();
            _nIcon.Dispose();
        }

        #endregion Methods
    }
}