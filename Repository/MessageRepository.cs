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
    public class MessageRepository : IMessageRepository, IDisposable
    {
        private readonly ApplicationDbContext db;

        public MessageRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task Add(Message message)
        {

            if (message != null)
                await db.Messages.AddAsync(message);
        }

        public async Task<Message> Get(int messageId)
        {
            var message = await db.Messages.FirstOrDefaultAsync(c => c.MessageId == messageId );
            return message;
        }

        public async Task Remove(int messageId)
        {
            var message = await Get(messageId);
            db.Messages.Remove(message);
        }

        public async Task Update(Message message)
        {
            var _Message = await Get(message.MessageId);
            db.Entry(_Message).CurrentValues.SetValues(message);
        }

        public List<Message> GetAll()
        {
            return db.Messages.ToList();
        }
        public List<Message> Find(Expression<Func<Message, bool>> expression)
        {
            return db.Messages.Where(expression).ToList();
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
