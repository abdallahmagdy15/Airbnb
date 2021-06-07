using Airbnb.Data;
using Airbnb.Models.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Airbnb.Repository
{
    public class ChatRepository : IChatRepository, IDisposable
    {
        private readonly ApplicationDbContext db;

        public ChatRepository(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public void Add(Chat chat)
        {

            if (chat != null)
                db.Add(chat);
        }

        public Chat Get(int chatId)
        {
            Chat chat = null;
            chat = db.Chats.FirstOrDefault(c => c.ChatId == chatId);
            return chat;
        }

        public void Remove(int chatId)
        {
            db.Remove(Get(chatId));
        }

        public void Update(Chat chat)
        {
            db.Entry(chat).State = EntityState.Modified;

        }

        public List<Chat> GetAll()
        {
            return db.Chats.ToList();
        }
        public List<Chat> Find(Expression<Func<Chat, bool>> expression)
        {
            return db.Chats.Where(expression).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
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
