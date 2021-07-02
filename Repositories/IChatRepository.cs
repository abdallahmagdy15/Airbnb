using Airbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Repositories
{
    public interface IChatRepository:IRepositoryBase<Chat>
    {
        public Task<Chat> GetChatWith(string CurrentUserId, string recieverUserId);
        public Task AddUser(string userId, int chatId);
        public Task RemoveUser(string userId, int chatId);

    }
}
