using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Messaging
{
    public class UserChat
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Chat")]
        public int ChatId{ get; set; }
        public virtual Chat Chat { get; set; }
        public virtual AppUser User { get; set; }
    }
}
