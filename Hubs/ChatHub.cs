using Airbnb.Models;
using Airbnb.Services;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Airbnb.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        private readonly IMessagingService messagingService;
        public ChatHub(IMessagingService messagingService)
        {
            this.messagingService = messagingService;
        }

        public Task JoinChat(int chatId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, "chat"+chatId);
        }

        public Task LeaveChat(int chatId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, "chat"+chatId);
        }
        public void SendMessage(int chatId, string text)
        {
            //save to db
            var message = new Message() { ChatId = chatId, Text = text };
            messagingService.SendMessage(message);
            //send to chat clients
            Clients.Group("chat" + chatId).SendAsync("NewMessage",message);
        }
        public void RemoveMessage(int messageId,int chatId)
        {
            //remove from db
            messagingService.RemoveMessage(messageId);
            //send to chat clients
            Clients.Group("chat" + chatId).SendAsync("RemovedMessage",messageId);
        }
    }
}
