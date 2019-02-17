#region

using System;
using System.Reflection;
using System.Text;
using AspectInjector.Broker;
using NLog;

#endregion

namespace TestCommonLib01
{
    public class TraceAspect
    {
        private static readonly ILogger Logger = LogManager.GetLogger("TraceAspect");

        [Advice(InjectionPoints.Before, InjectionTargets.Method)]
        public void TraceStart([AdviceArgument(AdviceArgumentSource.Type)] Type type,
            [AdviceArgument(AdviceArgumentSource.Name)] string name,
            [AdviceArgument(AdviceArgumentSource.Method)] MethodBase methodBase,
            [AdviceArgument(AdviceArgumentSource.Arguments)] object[] args)
        {
            if (!Logger.IsTraceEnabled) return;
            if (args.Length > 0)
            {
                var sb = new StringBuilder();
                foreach (var arg in args)
                {
                    sb.Append("|");
                    if (arg == null) sb.Append("<null>");
                    else sb.Append(arg);
                }

                Logger.Trace($">>{type.Name}.{name} {sb}");
            }
            else
            {
                Logger.Trace($">>{type.Name}.{name}");

            }
        }

        [Advice(InjectionPoints.After, InjectionTargets.Method)]
        public void TraceFinish([AdviceArgument(AdviceArgumentSource.Type)] Type type,
            [AdviceArgument(AdviceArgumentSource.Name)] string name,
            [AdviceArgument(AdviceArgumentSource.ReturnValue)] object returnValue)
        {
            if (!Logger.IsTraceEnabled) return;
            var ret = returnValue?.ToString() ?? "<null>";
            Logger.Trace($"<<{type.Name}.{name} {ret}");
        }
    }
}