using Airbnb.Models.Messaging;
using Airbnb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Controllers
{
    public class MessagingController : Controller
    {
        private readonly IMessagingService messagingService;

        public MessagingController(IMessagingService messagingService)
        {
            this.messagingService = messagingService;
        }
        public async Task<IActionResult> Index()
        {
            var chats = await messagingService.GetMyChats();
            return View(chats);
        }
        public async Task<IActionResult> GetChatById(int chatid)
        {
            await messagingService.RemoveChat(chatid);
            return Ok();
        }
        public async Task<ActionResult<Chat>> GetChatWith(string recieverid)
        {
            return Ok(await messagingService.GetChatWith(recieverid));
        }

        public async Task<IActionResult> RemoveChat(int chatId)
        {
            await messagingService.RemoveChat(chatId);
            return Ok();
        }
    }
}
