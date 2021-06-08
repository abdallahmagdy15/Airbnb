using Airbnb.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Repositories
{
    public interface IUserChatRepository:IRepositoryBase<UserChat>
    {
        public Task<Chat> GetChatWith(string currentUserId, string recieverId);
        public Task<UserChat> Get(int chatId, string userId);
        public Task Remove(int chatId, string userId);


    }
}
