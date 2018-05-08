using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrmAddons.Net.Common.Extensions;

namespace XtrmAddons.Net.Test.Common
{

    public static class ObjectsTests
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion



        public static ObjectSample Sample1 = new ObjectSample();

        /// <summary>
        /// 
        /// </summary>
        public static ObjectSample Sample2 = new ObjectSample();

        /// <summary>
        /// 
        /// </summary>
        public static void ObjectBind()
        {
            Sample1.OutputValues();
            Sample2.OutputValues();

            Sample1.Public_Property_Int = 2644789;
            Sample1.OutputValues();

            Sample2.Bind(Sample1);
            Sample2.OutputValues();

        }
    }
}
