using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPFXA.Net.Common.Extensions.ObservableCollection
{
    public static class ObservableCollectionExtension
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        #region Methods

        public static void CopyFrom<T>(this ObservableCollection<T> target, IEnumerable<T> collection) where T : class
        {
            if (collection != null)
            {
                using (IEnumerator<T> enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        target.Add(enumerator.Current);
                    }
                }
            }
        }

        #endregion
    }
}
