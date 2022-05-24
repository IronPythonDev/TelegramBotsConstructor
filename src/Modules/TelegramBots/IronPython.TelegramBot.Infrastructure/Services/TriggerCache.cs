using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Infrastructure.ActionTriggers;
using System.Reflection;

namespace IronPython.TelegramBots.Infrastructure.Services
{
    public class TriggerCache
    {
        public TriggerCache(IServiceProvider serviceProvider)
        {
            ServiceProvider=serviceProvider;
        }

        IDictionary<string, BaseTriggerHandler> Handlers = new Dictionary<string, BaseTriggerHandler>();

        IServiceProvider ServiceProvider { get; }

        public Task<BaseTriggerHandler> GetTrigger()
        {
            throw new NotImplementedException();
        }

        public void Load(params Assembly[] assemblies)
        {
            foreach (var type in assemblies.SelectMany(p => p.GetTypes().Where(p => p.GetCustomAttribute<ActionTriggerAttribute>() != null)))
            {
                var typeName = type.GetCustomAttribute<ActionTriggerAttribute>()!.Name;

                var instance = (BaseTriggerHandler)Activator.CreateInstance(type, ServiceProvider)!;

                Handlers.Add(typeName, instance);
            }
        }
    }
}
