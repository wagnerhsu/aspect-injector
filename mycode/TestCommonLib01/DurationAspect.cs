#region

using System;
using System.Diagnostics;
using AspectInjector.Broker;
using NLog;

#endregion

namespace TestCommonLib01
{
    public class DurationAspect
    {
        private static readonly ILogger Logger = LogManager.GetLogger("DurationAspect");

        [Advice(InjectionPoints.Around, InjectionTargets.Method)]
        public object TraceDuration([AdviceArgument(AdviceArgumentSource.Type)] Type type,
            [AdviceArgument(AdviceArgumentSource.Name)] string name,
            [AdviceArgument(AdviceArgumentSource.Target)] Func<object[], object> target,
            [AdviceArgument(AdviceArgumentSource.Arguments)] object[] arguments)
        {
            if (!Logger.IsInfoEnabled)
                return target(arguments);
            var sw = new Stopwatch();
            sw.Start();

            var result = target(arguments);

            sw.Stop();
            Logger.Info($"[{type.Name}.{name}] took [{sw.ElapsedMilliseconds}] ms");

            return result;
        }
    }
}