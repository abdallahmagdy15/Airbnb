using Airbnb.Models;
using System.Collections.Generic;
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
        public List<AppUser> GetSuggestedContacts();
        public List<string> GetConnectedContacts();
    }
}
