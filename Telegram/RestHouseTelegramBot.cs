using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace MeuTcc
{
    public class RestHouseTelegramBot
    {
        #region varibles
        TelegramBotClient botClient;
        #endregion

        #region constructor
        public RestHouseTelegramBot()
        {
            botClient = new TelegramBotClient("6624294121:AAHt7V3iT1t8GvMG5UvYphgQmRt1it0foa0");
            StartReciever();
        }
        #endregion

        #region methods
        public async Task StartReciever()
        {
            var token = new CancellationTokenSource();
            var cancellationToken = token.Token;
            var ReOpt = new ReceiverOptions { AllowedUpdates = { } };
            await botClient.ReceiveAsync(OnMessage, ErrorMessage, ReOpt, cancellationToken);
        }

        // Receiver Message from Bot
        public async Task OnMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Hello Brother 18.0");
            }
        }

        public async Task ErrorMessage(ITelegramBotClient botClient, Exception e, CancellationToken cancellationToken)
        {
            if (e is ApiRequestException requestException)
            {
                await botClient.SendTextMessageAsync("", e.Message.ToString());
            }
        }

        //public async Task SendMessage(Message message)
        //{

        //}
        #endregion
    }
}
