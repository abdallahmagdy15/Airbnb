using Airbnb.Models;
using Airbnb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Airbnb.Services
{
    public class MessagingService : IMessagingService
    {
        private readonly IChatRepository chatRepository;
        private readonly IMessageRepository messageRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly string CurrentUserId;

        public MessagingService(IHttpContextAccessor contextAccessor, IChatRepository chatRepository, IMessageRepository messageRepository, UserManager<AppUser> userManager)
        {
            this.chatRepository = chatRepository;
            this.messageRepository = messageRepository;
            this.userManager = userManager;
            CurrentUserId = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task<Chat> CreateChat(string recieverUserId)
        {
            //check if already chat created
            Chat chat = await chatRepository.GetChatWith(CurrentUserId, recieverUserId);
            if (chat != null) // already created
                return chat;
            //if not created 
            chat = new Chat();
            chat.Users = new List<AppUser>();
            var sender = await userManager.FindByIdAsync(CurrentUserId);
            var reciever = await userManager.FindByIdAsync(recieverUserId);
            if (sender != null && reciever != null)
            {
                chat.Users.Add(sender);
                chat.Users.Add(reciever);
                await chatRepository.Add(chat);
                await chatRepository.Save();
                return chat;
            }
            return null;
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
            return await chatRepository.GetChatWith(CurrentUserId, recieverUserId);
        }

        public async Task<List<Chat>> GetMyChats()
        {
            AppUser user = await userManager.FindByIdAsync(CurrentUserId);
            return user.Chats.ToList();
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

        //get users I contacted them before in a chat
        public List<string> GetConnectedContacts()
        {
            var currUser = userManager.Users.FirstOrDefault(x => x.Id == CurrentUserId);
            List<string> contacts = new List<string>();
            if (currUser != null)
            {
                if (currUser.Chats != null)
                    currUser.Chats.ForEach(chat =>
                   {
                       var user = chat.Users.Select(x => x.Id).FirstOrDefault(Id => Id != CurrentUserId);
                       if (user != null)
                       {
                           contacts.Add(user);
                       }
                   });
                return contacts;
            }
            return null;
        }

        //get users I never contacted them before
        public List<AppUser> GetSuggestedContacts()
        {
            var currUser = userManager.Users.FirstOrDefault(x => x.Id == CurrentUserId);
            if (currUser != null)
            {
                //**
                var x = GetConnectedContacts();
                //**
                return userManager.Users.Where(x => !GetConnectedContacts().Contains(x.Id)).ToList();
            }
            return null;
        }
    }

}

