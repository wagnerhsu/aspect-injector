using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspectInjector.Broker;
using NLog;

namespace TestCommonLib01
{
    [Aspect(typeof(TraceAspect))]
    public class TestService
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public string Display()
        {
            Logger.Debug("Display");
            return "Display";
        }

        public string Display(string name)
        {
            Logger.Debug($"Display:{name}");
            return $"Display:{name}";
        }
    }
}
