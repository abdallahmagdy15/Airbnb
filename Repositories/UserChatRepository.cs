using Airbnb.Data;
using Airbnb.Models.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Airbnb.Repositories
{
    public class UserChatRepository : IUserChatRepository, IDisposable
    {
        private readonly ApplicationDbContext db;

        public UserChatRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task Add(UserChat chatUser)
        {

            if (chatUser != null)
                await db.UsersChats.AddAsync(chatUser);
        }

        public async Task<UserChat> Get(int chatId, string userId)
        {
            var chatuser = await db.UsersChats.FirstOrDefaultAsync(c => c.ChatId == chatId && c.UserId == userId);
            return chatuser;
        }

        public async Task Remove(int chatId, string userId)
        {
            var userChat = await Get(chatId, userId);
            db.UsersChats.Remove(userChat);
        }

        public async Task Update(UserChat userchat)
        {
            var _userChat = await Get(userchat.ChatId, userchat.UserId);
            db.Entry(_userChat).CurrentValues.SetValues(userchat);
        }

        public List<UserChat> GetAll()
        {
            return db.UsersChats.ToList();
        }
        public List<UserChat> Find(Expression<Func<UserChat, bool>> expression)
        {
            return db.UsersChats.Where(expression).ToList();
        }
        public async Task<Chat> GetChatWith(string currentUserId, string recieverId)
        {
            var chat = await (from sender in db.UsersChats
                                from reciever in db.UsersChats.Where(x => x.ChatId == sender.ChatId)
                                where sender.UserId == currentUserId && reciever.UserId == recieverId
                                select sender.Chat).FirstOrDefaultAsync();
            return chat;
        }
        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //unused methods...
        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserChat> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
