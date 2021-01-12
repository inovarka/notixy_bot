using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NotixyBotApp.Models.Commands
{
    public class AboutCommand : Command
    {
        public override string Name => "about";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            string githubStr = "https://github.com/inovarka/notixy_bot";

            await client.SendTextMessageAsync(chatId, githubStr, replyToMessageId: messageId);
        }
    }
}