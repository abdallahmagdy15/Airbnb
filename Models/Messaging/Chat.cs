using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Messaging

{
    public class Chat
    {
        public int ChatId { get; set; }
        public ICollection<Message> Messages{ get; set; }
        public ICollection<AppUser> Users { get; set; }

    }
}
