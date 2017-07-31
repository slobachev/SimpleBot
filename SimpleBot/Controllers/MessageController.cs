﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using SimpleBot.Models;
using System.Threading.Tasks;

namespace SimpleBot.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")] //webhook url part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    return Ok();
                }
            }
            return Ok();
        }
    }
}
