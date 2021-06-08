﻿using Airbnb.Models;
using Airbnb.Models.Messaging;
using Airbnb.Repository;
using Microsoft.AspNetCore.Identity;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public class MessagingService : IMessagingService
    {
        private readonly IChatRepository chatRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IUserChatRepository userChatRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly string currentUserId;

        public MessagingService(string _currentUserId, IChatRepository chatRepository, IMessageRepository messageRepository, IUserChatRepository userChatRepository, UserManager<AppUser> userManager)
        {
            this.chatRepository = chatRepository;
            this.messageRepository = messageRepository;
            this.userChatRepository = userChatRepository;
            this.userManager = userManager;
            this.currentUserId = _currentUserId;
        }
        public async Task<Chat> CreateChat(string recieverUserId)
        {
            //check if already chat created
            Chat chat = await userChatRepository.GetChatWith(currentUserId, recieverUserId);
            if (chat != null) // already created
                return chat;
            //if not created 
            chat = new Chat();
            var sender = await userManager.FindByIdAsync(currentUserId);
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
            return await chatRepository.Get(chatId);
        }

        public async Task<Chat> GetChatWith(string recieverUserId)
        {
            return await userChatRepository.GetChatWith(currentUserId, recieverUserId);
        }

        public async Task<List<Chat>> GetMyChats()
        {
            AppUser user = await userManager.FindByIdAsync(currentUserId);
            return user.Chats.Select(x => x.Chat).ToList();
        }

        public async Task RemoveChat(int chatId)
        {
            await chatRepository.Remove(chatId);
        }

        public async Task RemoveMessage(int messageId)
        {
            var message = await messageRepository.Get(messageId);
            if (message.UserId == currentUserId)
                await messageRepository.Remove(messageId);
        }

        public async Task SendMessage(Message message)
        {
            var currUser = await userManager.FindByIdAsync(currentUserId) as AppUser;
            var chat = currUser.Chats.Where(x => x.ChatId == message.ChatId).FirstOrDefault();
            if (chat != null)
                await messageRepository.Add(message);
        }
    }

}

