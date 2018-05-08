using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XtrmAddons.Net.Test.Common
{
    public class ObjectSample
    {
        public int Public_Property_Int_Null { get; set; }

        public int Public_Property_Int { get; set; } = 1299;

        protected int Protected_Property_Int_Null { get; set; }

        protected int Protected_Property_Int { get; set; } = 523;

        private int Private_Property_Int_Null { get; set; }

        private int Private_Property_Int { get; set; } = 75;

        public void OutputValues()
        {
            this.GetHashCode();
            Trace.WriteLine(GetHashCode() + " ---------------------------------------------------------------");
            Trace.WriteLine("Public_Property_Int_Null = " + Public_Property_Int_Null);
            Trace.WriteLine("Public_Property_Int = " + Public_Property_Int);
            Trace.WriteLine("Protected_Property_Int_Null = " + Protected_Property_Int_Null);
            Trace.WriteLine("Protected_Property_Int = " + Protected_Property_Int);
            Trace.WriteLine("Private_Property_Int_Null = " + Private_Property_Int_Null);
            Trace.WriteLine("Private_Property_Int = " + Private_Property_Int);
            Trace.WriteLine("---------------------------------------------------------------");
        }

    }
}
