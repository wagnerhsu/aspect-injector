using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspectInjector.Broker;

namespace TestCommonLib01
{
    public class TestHelper
    {
        [Aspect(typeof(DurationAspect))]
        [Aspect(typeof(TraceAspect))]
        public static void Foo()
        {
            
        }
    }
}
