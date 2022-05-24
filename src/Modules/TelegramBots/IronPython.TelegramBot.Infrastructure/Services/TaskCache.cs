using IronPython.TelegramBots.Domain;
using IronPython.TelegramBots.Infrastructure.ActionTasks;
using IronPython.TelegramBots.Infrastructure.ActionTriggers;
using System.Reflection;

namespace IronPython.TelegramBots.Infrastructure.Services
{
    public class TaskCache
    {
        public TaskCache(IServiceProvider serviceProvider)
        {
            ServiceProvider=serviceProvider;
        }

        public IDictionary<string, BaseTaskHandler> Handlers = new Dictionary<string, BaseTaskHandler>();

        IServiceProvider ServiceProvider { get; }

        public void Load(params Assembly[] assemblies)
        {
            foreach (var type in assemblies.SelectMany(p => p.GetTypes().Where(p => p.GetCustomAttribute<ActionTaskAttribute>() != null)))
            {
                var typeName = type.GetCustomAttribute<ActionTaskAttribute>()!.Name;

                var instance = (BaseTaskHandler)Activator.CreateInstance(type, ServiceProvider)!;

                Handlers.Add(typeName, instance);
            }
        }
    }
}
