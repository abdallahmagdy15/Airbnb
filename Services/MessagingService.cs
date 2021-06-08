using Airbnb.Models;
using Airbnb.Models.Messaging;
using Airbnb.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Airbnb.Services
{
    public class MessagingService : IMessagingService
    {
        private readonly IChatRepository chatRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IUserChatRepository userChatRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly string CurrentUserId;

        public MessagingService(IHttpContextAccessor contextAccessor, IChatRepository chatRepository, IMessageRepository messageRepository, IUserChatRepository userChatRepository, UserManager<AppUser> userManager)
        {
            this.chatRepository = chatRepository;
            this.messageRepository = messageRepository;
            this.userChatRepository = userChatRepository;
            this.userManager = userManager;
            CurrentUserId = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task<Chat> CreateChat(string recieverUserId)
        {
            //check if already chat created
            Chat chat = await userChatRepository.GetChatWith(CurrentUserId, recieverUserId);
            if (chat != null) // already created
                return chat;
            //if not created 
            chat = new Chat();
            var sender = await userManager.FindByIdAsync(CurrentUserId);
            var reciever = await userManager.FindByIdAsync(recieverUserId);
            var chatSender = new UserChat() { Chat = chat, User = sender };
            var chatReciever = new UserChat() { Chat = chat, User = reciever };
            await userChatRepository.Add(chatReciever);
            await userChatRepository.Add(chatSender);
            await userChatRepository.Save();
            await chatRepository.Add(chat);
            await chatRepository.Save();
            return chat;
        }
        public async Task<Chat> GetChatById(int chatId)
        {
            var myChats = await GetMyChats();
            var chat = await chatRepository.Get(chatId);
            if (myChats.Contains(chat))
                return chat;
            else
                return null;
        }

        public async Task<Chat> GetChatWith(string recieverUserId)
        {
            return await userChatRepository.GetChatWith(CurrentUserId, recieverUserId);
        }

        public async Task<List<Chat>> GetMyChats()
        {
            AppUser user = await userManager.FindByIdAsync(CurrentUserId);
            return user.Chats.Select(x => x.Chat).ToList();
        }

        public async Task RemoveChat(int chatId)
        {
            var myChats = await GetMyChats();
            var chat = await chatRepository.Get(chatId);
            if (myChats.Contains(chat))
            {
                await chatRepository.Remove(chatId);
                await chatRepository.Save();
            }
        }

        public async Task RemoveMessage(int messageId)
        {
            var message = await messageRepository.Get(messageId);
            if (message.UserId == CurrentUserId)
            {
                await messageRepository.Remove(messageId);
                await messageRepository.Save();
            }
        }

        public async Task SendMessage(Message message)
        {
            var currUser = await userManager.FindByIdAsync(CurrentUserId) as AppUser;
            var chat = currUser.Chats.Where(x => x.ChatId == message.ChatId).FirstOrDefault();
            if (chat != null)
            {
                message.UserId = CurrentUserId;
                await messageRepository.Add(message);
                await messageRepository.Save();
            }
        }
    }

}

