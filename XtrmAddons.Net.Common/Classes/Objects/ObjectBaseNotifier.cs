using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XtrmAddons.Net.Common.Objects
{
    /// <summary>
    /// Class XtrmAddons Net Application Object Base Notify Property Changed.
    /// </summary>
    public abstract class ObjectBaseNotifier : INotifyPropertyChanged
    {
        #region Event Handler

        /// <summary>
        /// Delegate property changed event handler of the model.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion



        #region Methods

        /// <summary>
        /// This method is called by the Set accessor of each property.
        /// The CallerMemberName attribute that is applied to the optional propertyName.
        /// parameter causes the property name of the caller to be substituted as an argument.
        /// </summary>
        /// <param name="propertyName">A name of a property to notify changed event.</param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }
}