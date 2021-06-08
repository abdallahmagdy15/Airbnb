using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Messaging

{
    public class Chat
    {
        public int ChatId { get; set; }
        public virtual List<Message> Messages{ get; set; }
        public virtual List<UserChat> Users { get; set; }

    }
}
