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
    public class ChatRepository : IChatRepository, IDisposable
    {
        private readonly ApplicationDbContext db;

        public ChatRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task Add(Chat chat)
        {

            if (chat != null)
                await db.Chats.AddAsync(chat);
        }

        public async Task<Chat> Get(int chatId)
        {
            Chat chat = null;
            chat = await db.Chats.FirstOrDefaultAsync(c => c.ChatId == chatId);
            return chat;
        }

        public async Task Remove(int chatId)
        {
            var chat = await Get(chatId);
            db.Chats.Remove(chat);
        }

        public async Task Update(Chat chat)
        {
            var _chat = await Get(chat.ChatId);
            db.Entry(_chat).CurrentValues.SetValues(chat);
        }

        public List<Chat> GetAll()
        {
            return  db.Chats.ToList();
        }
        public List<Chat> Find(Expression<Func<Chat, bool>> expression)
        {
            return db.Chats.Where(expression).ToList();
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
    }
}
