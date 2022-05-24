namespace IronPython.TelegramBots.Infrastructure.ActionTasks
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ActionTaskAttribute : Attribute
    {
        public ActionTaskAttribute(string name)
        {
            Name=name;
        }

        public string Name { get; }
    }
}
