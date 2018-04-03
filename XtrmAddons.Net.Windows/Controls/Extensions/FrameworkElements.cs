using System;
using System.Windows;

namespace XtrmAddons.Net.Windows.Controls.Extensions
{
    /// <summary>
    /// Class XtrmAddons Windows Controls Framework Element Extensions.
    /// </summary>
    public static class FrameworkElements
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
        /// Method to Stretch a Framework Element Height to a Framework Element Height. 
        /// </summary>
        /// <param name="fe">The Framework Element to stretch.</param>
        /// <param name="source">A Framework Element to get dimensions.</param>
        /// <param name="margin">An optional margin.</param>
        /// <param name="min">An optional minimum dimension.</param>
        public static void StretchToHeight(this FrameworkElement fe, FrameworkElement source, double margin = 0, double min = 0)
        {
            if (fe.Equals(null))
            {
                throw new ArgumentNullException(nameof(fe));
            }

            if (source.Equals(null))
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Height.Equals(null))
            {
                throw new ArgumentNullException(nameof(source.Height));
            }

            if (min.Equals(null))
            {
                throw new ArgumentNullException(nameof(min));
            }

            double dim = source.Height - margin;

            if (dim < 0 && min < 0)
            {
                log.Error(string.Format("Stretching element Height value negative. source.ActualWidth = {0} , min = {1}", source.Height, min));
            }

            fe.Height = Math.Max(Math.Max(dim, min), 0);
        }

        /// <summary>
        /// Method to Stretch a Framework Element Height to a Framework Element Actual Height. 
        /// </summary>
        /// <param name="fe">The Framework Element to stretch.</param>
        /// <param name="source">A Framework Element to get dimensions.</param>
        /// <param name="margin">An optional margin.</param>
        /// <param name="min">An optional minimum dimension.</param>
        public static void StretchToActualHeight(this FrameworkElement fe, FrameworkElement source, double margin = 0, double min = 0)
        {
            if (fe.Equals(null))
            {
                throw new ArgumentNullException(nameof(fe));
            }

            if (source.Equals(null))
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.ActualHeight.Equals(null))
            {
                throw new ArgumentNullException(nameof(source.ActualHeight));
            }

            if (min.Equals(null))
            {
                throw new ArgumentNullException(nameof(min));
            }

            double dim = source.ActualHeight - margin;

            if (dim < 0 && min < 0)
            {
                log.Error(string.Format("Stretching element ActualHeight value negative. source.ActualHeight = {0} , min = {1}", source.ActualHeight, min));
            }

            fe.Height = Math.Max(Math.Max(dim, min), 0);
        }

        /// <summary>
        /// Method to Stretch a Framework Element Height to a Framework Element Width.
        /// </summary>
        /// <param name="fe">The Framework Element to stretch.</param>
        /// <param name="source">A Framework Element to get dimensions.</param>
        /// <param name="margin">An optional margin.</param>
        /// <param name="min">An optional minimum dimension.</param>
        public static void StretchToWidth(this FrameworkElement fe, FrameworkElement source, double margin = 0, double min = 0)
        {
            if (fe.Equals(null))
            {
                throw new ArgumentNullException(nameof(fe));
            }

            if (source.Equals(null))
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Width.Equals(null))
            {
                throw new ArgumentNullException(nameof(source.Width));
            }

            if (min.Equals(null))
            {
                throw new ArgumentNullException(nameof(min));
            }

            double dim = source.Width - margin;

            if (dim < 0 && min < 0)
            {
                log.Error(string.Format("Stretching element Width value negative. source.ActualWidth = {0} , min = {1}", source.ActualWidth, min));
            }

            fe.Width = Math.Max(Math.Max(dim, min), 0);
        }

        /// <summary>
        /// Method to Stretch a Framework Element Height to a Framework Element Actual Width.
        /// </summary>
        /// <param name="fe">The Framework Element to stretch.</param>
        /// <param name="source">A Framework Element to get dimensions.</param>
        /// <param name="margin">An optional margin.</param>
        /// <param name="min">An optional minimum dimension.</param>
        public static void StretchToActualWidth(this FrameworkElement fe, FrameworkElement source, double margin = 0, double min = 0)
        {
            if (fe.Equals(null))
            {
                throw new ArgumentNullException(nameof(fe));
            }

            if (source.Equals(null))
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.ActualWidth.Equals(null))
            {
                throw new ArgumentNullException(nameof(source.Width));
            }

            if (min.Equals(null))
            {
                throw new ArgumentNullException(nameof(min));
            }

            double dim = source.ActualWidth - margin;

            if (dim < 0 && min < 0)
            {
                log.Error(string.Format("Stretching element Width value negative. source.ActualWidth = {0} , min = {1}", source.ActualWidth, min));
            }

            fe.Width = Math.Max(Math.Max(dim, min), 0);
        }

        #endregion
    }
}
