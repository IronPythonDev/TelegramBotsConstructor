using AspectInjector.Broker;

namespace IronPython.Infrastructure.Aspects
{
    [Aspect(Scope.Global)]
    [Injection(typeof(LogExceptionAttribute))]
    [AttributeUsage(AttributeTargets.Method)]
    public class LogExceptionAttribute : Attribute
    {
        [Advice(Kind.Around, Targets = Target.Method)]
        public object OnException([Argument(Source.Target)] Func<object[], object> target, [Argument(Source.Arguments)] object[] args)
        {
            return target(args);
        }
    }
}
