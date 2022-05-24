using IronPython.TelegramBots.Contracts.DTOs;
using IronPython.TelegramBots.Infrastructure.ActionTasks;
using IronPython.TelegramBots.Infrastructure.ActionTriggers;
using IronPython.TelegramBots.Infrastructure.Services;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace IronPython.TelegramBots.Infrastructure.Telegram
{
    class UpdateHandler : IUpdateHandler
    {
        public UpdateHandler(IList<TelegramBotActionDTO> actions, TaskCache taskCache, TriggerCache triggerCache)
        {
            Actions=actions;
            TaskCache=taskCache;
            TriggerCache=triggerCache;
        }

        public IList<TelegramBotActionDTO> Actions { get; }
        public TaskCache TaskCache { get; }
        public TriggerCache TriggerCache { get; }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message)
                return;
            // Only process text messages
            if (update.Message!.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            var tasks = Actions.Where(a =>
            {
                foreach (var triggerDetails in a.Triggers)
                {
                    
                    if (!TriggerCache.Handlers.TryGetValue(triggerDetails.Type!, out BaseTriggerHandler? trigger)) continue;

                    var isNext = trigger
                        .IsNext(update, triggerDetails.Params!)
                        .GetAwaiter()
                        .GetResult();

                    if (!isNext) return false;
                }

                return true;
            }).SelectMany(p => p.Tasks).ToList();

            foreach (var task in tasks)
            {
                if (!TaskCache.Handlers.TryGetValue(task.Type!, out BaseTaskHandler? taskHandler)) continue;

                await taskHandler.Handle(update, botClient, task.Params!);
            }
        }
    }

    public class TelegramBot
    {
        public TelegramBot(string apiKey, IList<TelegramBotActionDTO> actions, TaskCache taskCache, TriggerCache triggerCache)
        {
            ApiKey=apiKey;
            Actions=actions;
            TaskCache=taskCache;
            TriggerCache=triggerCache;
        }

        public string ApiKey { get; }
        public IList<TelegramBotActionDTO> Actions { get; }
        private TelegramBotClient Client { get; set; }

        public TaskCache TaskCache { get; }
        public TriggerCache TriggerCache { get; }

        public async Task Start()
        {
            Client = new TelegramBotClient(ApiKey);

            var cts = new CancellationTokenSource();

            await Client.DeleteWebhookAsync(true);

            Client.StartReceiving(new UpdateHandler(Actions, TaskCache, TriggerCache), cancellationToken: cts.Token);
        }
    }
}
