﻿using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using NotixyBotApp.Models;
using System.Threading.Tasks;

namespace NotixyBotApp.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    await Task.Run(() => command.Execute(message, client));
                    break;
                }
            }

            return Ok();

        }

    }
}
