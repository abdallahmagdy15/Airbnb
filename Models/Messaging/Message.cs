using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.Models.Messaging
{
    public class Message
    {
        public int MessageId { get; set; }
        [Required , MinLength(1, ErrorMessage="Can't send an empty message."),
            StringLength(640 , ErrorMessage = "The message text cannot exceed 640 characters.")]
        public string Text { get; set; }
        [ForeignKey("User"),Required]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        [ForeignKey("Chat"),Required]
        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
