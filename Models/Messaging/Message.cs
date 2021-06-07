using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Messaging
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
