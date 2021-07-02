using Airbnb.Models;
using Airbnb.Services;
using Airbnb.ViewModels.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Airbnb.Controllers
{
    [Authorize(Roles = "User")]
    public class MessagingController : Controller
    {
        private readonly IMessagingService messagingService;
        private readonly UserManager<AppUser> userManager;

        public MessagingController(IMessagingService messagingService, UserManager<AppUser> userManager)
        {
            this.messagingService = messagingService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }
        public async Task<IActionResult> GetChat(string chatid)
        {
            var currUser = await userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Chat chat ; int _chatId;
            if (chatid == null || !int.TryParse(chatid,out _chatId))
            {
                chat = currUser.Chats.FirstOrDefault();
            }
            else 
                chat = await messagingService.GetChatById(_chatId);

            return View("Chat",new ChatViewModel() { Chat = chat,CurrentUser = currUser });
        }
        
        [HttpGet]
        public ActionResult<List<AppUser>> CreateChat()
        {
            return View(messagingService.GetSuggestedContacts());
        }

        [HttpPost]
        public async Task<IActionResult> CreateChat(string contactId)
        {
            await messagingService.CreateChat(contactId);
            return RedirectToAction("Index");
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
    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult(string script)
        {
            this.Content = script;
            this.ContentType = "application/javascript";
        }
    }
}
