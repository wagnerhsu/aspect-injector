#region

using AspectInjector.Broker;
using TestCommonLib01;

#endregion

namespace TestWinForm01
{
    [Aspect(typeof(TraceAspect))]
    internal class Utilities
    {
        [Aspect(typeof(DurationAspect))]
        public static string Hello(string name)
        {
            return "Hello:" + name;
        }
    }
}