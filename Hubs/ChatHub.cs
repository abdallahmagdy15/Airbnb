using Airbnb.Models;
using Airbnb.Services;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Airbnb.Hubs
{
    [HubName("chathub")]
    public class ChatHub : Hub
    {
        private readonly IMessagingService messagingService;
        private readonly UserManager<AppUser> userManager;

        public string CurrentUserId { get; }

        public ChatHub(IMessagingService messagingService,
            IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            this.messagingService = messagingService;
            this.userManager = userManager;
            CurrentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task join_chat(string chatId)
        {
            if (!string.IsNullOrEmpty(chatId))
                await Groups.AddToGroupAsync(Context.ConnectionId, "chat" + chatId);
        }

        public async Task leave_chat(string chatId)
        {
            if (chatId != null)
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "chat" + chatId);
        }
        public async Task send_message(string chatId, string text)
        {
            //save to db
            int _chatId;
            var currUser = await userManager.FindByIdAsync(CurrentUserId) as AppUser;

            if (int.TryParse(chatId, out _chatId) && !string.IsNullOrEmpty(text))
            {
                Message message = new Message()
                {
                    ChatId = _chatId,
                    Text = text,
                    User = null,
                    UserId = currUser.Id,
                    DateTime = DateTime.Now
                };
                //send to chat clients
                await Clients.Group("chat" + chatId).SendAsync("new_message",
                    new
                    {
                        chatId = _chatId,
                        text = text,
                        photoUrl = currUser.PhotoUrl,
                        firstName = currUser.FirstName,
                        DateTime = DateTime.Now
                    });
                await messagingService.SendMessage(message);
            }
        }
        public async Task remove_message(string messageId, string chatId)
        {
            //remove from db
            int _chatId; int _messageId;

            if (int.TryParse(chatId, out _chatId) && int.TryParse(messageId, out _messageId))
            {
                //send to chat clients
                await Clients.Group("chat" + _chatId).SendAsync("removed_message", _messageId);

                await messagingService.RemoveMessage(_messageId);
            }
        }
    }
}
