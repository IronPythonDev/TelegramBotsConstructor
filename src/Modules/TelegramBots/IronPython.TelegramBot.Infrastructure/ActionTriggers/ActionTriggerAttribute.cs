namespace IronPython.TelegramBots.Infrastructure.ActionTriggers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ActionTriggerAttribute : Attribute
    {
        public ActionTriggerAttribute(string name)
        {
            Name=name;
        }

        public string Name { get; }
    }
}
