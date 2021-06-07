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
    public class MessageRepository : IRepositoryBase<Message>, IDisposable
    {
        private readonly ApplicationDbContext db;

        public MessageRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(Message message)
        {
            if (message != null)
                db.Add(message);
        }

        public Message Get(int messageId)
        {
            Message message = null;
            message = db.Messages.FirstOrDefault(c => c.MessageId == messageId);
            return message;
        }

        public void Remove(int messageId)
        {
            db.Remove(Get(messageId));
        }

        public void Update(Message message)
        {
            if (message != null)
                db.Entry(message).State = EntityState.Modified;
        }

        public List<Message> GetAll()
        {
            return db.Messages.ToList();
        }
        public List<Message> Find(Expression<Func<Message, bool>> expression)
        {
            return db.Messages.Where(expression).ToList();
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
