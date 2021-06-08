using Airbnb.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public interface IMessagingService
    {
        public Task SendMessage(Message message);
        public Task RemoveMessage(int messageId);
        public Task<Chat> CreateChat(string recieverUserId);
        public Task RemoveChat(int chatId);
        public Task<List<Chat>> GetMyChats();
        public Task<Chat> GetChatById(int chatId);
        public Task<Chat> GetChatWith(string recieverUserId);

    }
}
